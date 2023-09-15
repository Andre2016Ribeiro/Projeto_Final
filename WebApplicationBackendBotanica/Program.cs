using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApplicationBackendBotanica.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


var builder = WebApplication.CreateBuilder(args);

// Add services to the containerhttps://dev.azure.com/Computencial/_git/Academia2020A.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WebApplicationBackendBotanicaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationBackendBotanicaContext")));





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

