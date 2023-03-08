using Microsoft.EntityFrameworkCore;
using SimpleCoreWebApiSample.Db;
using SimpleCoreWebApiSample;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("AppDb"));

var app = builder.Build();
//CreateHostBuilder(args).Build().Run();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//static IHostBuilder CreateHostBuilder(string[] args) =>
//Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                })
//                .ConfigureServices((hostContext, services) =>
//                {
//                    services.AddDbContext<AppDbContext>(options =>
//                        options.UseInMemoryDatabase("AppDb"));
//                });
