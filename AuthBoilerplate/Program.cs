using AuthBP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AuthBoilerplate.Utils;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// Use the pre-existing builder to load Configuration and connect to db
var dbString = builder.Configuration.GetConnectionString("AuthConnectionString");
Debug.WriteLine(dbString);
builder.Services.AddDbContext<AuthBoilerplateDbContext>(options => options.UseNpgsql(dbString));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AuthBoilerplateDbContext>();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Login";
});

var app = builder.Build();

app.RunMigrations();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
