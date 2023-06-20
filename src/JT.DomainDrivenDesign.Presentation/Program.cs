using JT.DomainDrivenDesign.Application.Handlers;
using JT.DomainDrivenDesign.Domain.VehicleDomain.Repositories;
using JT.DomainDriverDesign.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IVehicleCreationHandler, VehicleCreationHandler>();
builder.Services.AddScoped<IVehicleRepository, DynamoVehicleRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();