using JT.DomainDrivenDesign.Application.Vehicle.Dtos;
using JT.DomainDrivenDesign.Application.Vehicle.Handlers;
using JT.DomainDrivenDesign.Domain.Vehicle.Repositories;
using JT.DomainDriverDesign.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IVehicleRepository, DynamoVehicleRepository>();
builder.Services.AddScoped<ICommandHandler<CreateVehicleCommand>, VehicleCreationHandler>();
builder.Services.AddScoped<IQueryHandler<RetrieveVehicleQuery, VehicleDto>, VehicleRetrievalHandler>();

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