using CalculoFrete.Api.Configurations;
using CalculoFrete.Api.Configurations.AutoMapper;
using CalculoFrete.Api.Configurations.Seed;
using CalculoFrete.Core.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options => options.Filters.Add<ExceptionFilter>())
    .AddJsonOptions(options => { options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull; });

builder.AddSwagger(); ;
builder.AddAutoMapper();
builder.Services.RegisterServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UsarSwagger();
    app.Seed();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
