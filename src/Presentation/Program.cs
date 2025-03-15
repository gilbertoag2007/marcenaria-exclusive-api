using MarcenariaExclusive.API.Application.Interfaces;
using MarcenariaExclusive.API.Infrastructure.Services;
using MarcenariaExclusiveAPI.Application.Interfaces;
using MarcenariaExclusiveAPI.Infrastructure.Configurations;
using MarcenariaExclusiveAPI.Infrastructure.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });

    // Exibir enums como string
    options.SchemaFilter<EnumSchemaFilter>();
});
builder.Services.AddScoped<IArmarioService, ArmarioService>();
builder.Services.AddScoped<IArmarioValidacaoService, ArmarioValidacaoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
