using Microsoft.EntityFrameworkCore;
using ColoursAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>
    (opt => opt.UseInMemoryDatabase("ColourDB"));

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
