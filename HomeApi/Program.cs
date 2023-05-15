using HomeApi.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddJsonFile("HomeOptions.json");
builder.Services.Configure<HomeOptions>((IConfiguration)builder.Configuration.AddJsonFile("HomeOptions.json"));
builder.Services.Configure<HomeOptions>(options => options.Area = 120);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "HomeApi",
        Version = "v1"
    });
});

    var app = builder.Build();

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


