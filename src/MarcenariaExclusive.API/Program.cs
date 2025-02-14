using MarcenariaExclusiveAPI.Application.Interfaces;
using MarcenariaExclusiveAPI.Application.Mappings;
using MarcenariaExclusiveAPI.Infrastructure.Services;
using Microsoft.Win32;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IArmarioService, ArmarioService>();
builder.Services.AddAutoMapper(typeof(ArmarioProfile));
builder.Services.AddAutoMapper(typeof(NivelProfile));

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
