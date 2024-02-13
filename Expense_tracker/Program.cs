using Expense_tracker.Models;
using Microsoft.EntityFrameworkCore;

// Variable with SyncFusion Licence

string LicenceKey = Environment.GetEnvironmentVariable("SYNCFUSION_LICENCE_KEY");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews();

// SyncFusion license 
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(LicenceKey);



// Dependency injection 

builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
