

using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;
using StoreApp.ModelsStore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemplyReference).Assembly);  

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.ConfigureDbContext(builder.Configuration);

builder.Services.ConfigureIdentity();

builder.Services.ConfigureSession();

builder.Services.ConfigureRepositoryRegistration();

builder.Services.ConfigureServiceRegistiration(); 

builder.Services.ConfigureRouting();    

builder.Services.ConfigureApplicationCookie();








builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//app.MapGet("/btk",()=>"BTK Akademi");
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
        );

    endpoints.MapControllerRoute(
       name: "default",
       pattern: "{controller=Home}/{action=Index}/{id?}"
        );

    endpoints.MapRazorPages();
    endpoints.MapControllers(); 
    
});


app.ConfigureAndCheckMigration();
app.ConfigureLocalization();//bilgisayar ingilizce olduðu için çalýþmýyor olabilir
app.ConfigureDefaultAdminUser();
app.Run();
