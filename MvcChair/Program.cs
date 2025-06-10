using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcChair.Models;
using MvcChair.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcChairContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcChairContext") ?? throw new InvalidOperationException("Connection string 'MvcChairContext' not found.")));

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("MvcChairContext") ?? throw new InvalidOperationException("Connection string 'MvcChairContext' not found.");
//builder.Services.AddDbContext<MvcChairContext>(options =>
//    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MvcChairContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();