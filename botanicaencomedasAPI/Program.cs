using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BotanicaContext;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebApplicationBackendBotanicaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationBackendBotanicaContext") ?? throw new InvalidOperationException("Connection string 'PopulacaoAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.MapControllers();

app.UseCors(options =>
{
    //Vou abrir completamente esta app web api para todos os pedidos de todos os outros projetos:
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});
app.Run();
