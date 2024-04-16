using Microsoft.EntityFrameworkCore;
using Vegelog.Server;
using Vegelog.Server.Services;
using Vegelog.Server.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DB>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IVegetableService, VegetableService>();

//cors
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:5059", "https://fukicycle.github.io")
              .WithMethods("GET", "POST", "DELETE", "OPTIONS")
              .WithHeaders("Content-Type")
              .AllowCredentials()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//cors
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
