using E_Project_Pharmacy.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Project_Pharmacy.Database
{
    public class database : DbContext
    {
        public database(DbContextOptions<database> options) : base (options) { 
        
        }
        public DbSet<categare> categare { get; set; }
        public DbSet<Sub_Categare> Sub_Categare { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Why_Choose> Why_choose { get; set;}
        public DbSet<Role> Role { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Quote> Quote { get; set; }
        public DbSet<Carrer> Carrer { get; set; }
        public DbSet<user_resume> user_resume {  get; set; }
        public DbSet<orders> orders { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<user_resume>()
				.Property(b => b.r_resume)
				.HasColumnType("BLOB"); // Configure the column as BLOB
		}


	}
}
