using Microsoft.EntityFrameworkCore;
using System;
using WebApplication5.Model;
using WebApplication5.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var s = builder.Configuration.GetConnectionString("connect");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(s));
builder.Services.AddScoped<ITask, TaskRepo>();
builder.Services.AddScoped<IClassroom, ClassRoomRepo>();
builder.Services.AddScoped<ICources, CourcesRepo>();

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
