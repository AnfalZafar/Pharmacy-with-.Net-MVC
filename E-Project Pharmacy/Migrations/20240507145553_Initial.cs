using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Project_Pharmacy.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    about_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    about_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    about_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    about_img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cheak_one = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cheak_two = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cheak_three = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.about_id);
                });

            migrationBuilder.CreateTable(
                name: "Carrer",
                columns: table => new
                {
                    carrer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carrer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carrer_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carrer_location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrer", x => x.carrer_id);
                });

            migrationBuilder.CreateTable(
                name: "categare",
                columns: table => new
                {
                    c_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    c_img = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categare", x => x.c_id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    contact_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contact_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.contact_id);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    doctor_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctor_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    doctor_position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    doctor_img = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.doctor_id);
                });

            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    Quote_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quote_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quote_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quote_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quote_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quote_post = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quote_country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quote_message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.Quote_id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sub_Categare",
                columns: table => new
                {
                    sub_c_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sub_c_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sub_c_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sub_c_price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sub_c_img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cat_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sub_Categare", x => x.sub_c_id);
                });

            migrationBuilder.CreateTable(
                name: "user_resume",
                columns: table => new
                {
                    r_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    r_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    r_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    r_location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    r_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    r_edu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    r_country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    r_resume = table.Column<byte[]>(type: "BLOB", nullable: false),
                    c_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_resume", x => x.r_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Why_choose",
                columns: table => new
                {
                    w_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    w_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    w_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    w_img = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Why_choose", x => x.w_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.DropTable(
                name: "Carrer");

            migrationBuilder.DropTable(
                name: "categare");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Quote");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Sub_Categare");

            migrationBuilder.DropTable(
                name: "user_resume");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Why_choose");
        }
    }
}
