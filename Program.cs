using Ch04MovieList.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EF Core dependency injection, allowing the DbContext objects to be properly passed to controllers.
builder.Services.AddDbContext<MovieContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContext")));

// Making URL's lowercase and end with a trailing slash.
builder.Services.AddRouting(options => {
    options.LowercaseUrls = true; options.AppendTrailingSlash = true;
});
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
app.UseAuthorization();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    // Default routing for Dummy1.
    endpoints.MapControllerRoute(
        name: "default",
        // Follows default pattern where the URL matches the controller name and action method.
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // Custom routing for Dummy2.
    endpoints.MapControllerRoute(
        name: "customDummy2",
        // Custom pattern/route defined with the controller and action specified.
        pattern: "CustomRoute/Dummy2",
        new { controller = "DummyPages", action = "Dummy2" });

    // Mapping route for admin area.
    endpoints.MapAreaControllerRoute(
            name: "admin",
            areaName: "Admin",
            pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
});
#pragma warning restore ASP0014 // Suggest using top level route registrations


app.MapControllerRoute(
    name: "default",
    // Adding {slug?} for second optional parameter
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
