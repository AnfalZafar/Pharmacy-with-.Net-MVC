using E_Project_Pharmacy.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<database>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnection"))

);
builder.WebHost.ConfigureKestrel(options =>
{

    options.Limits.MaxRequestBodySize = 20L * 1024 * 1024 * 1024;

}
);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    ox =>
{
        ox.LoginPath = ("/LoginController1/Index");
        ox.AccessDeniedPath = ("/LoginController1/Index");
}
);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromSeconds(1800);
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;
}
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
