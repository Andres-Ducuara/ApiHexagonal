using MyApp.Application.DependencyInjection;
using MyApp.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Swagger + Controllers (para ver la capa HTTP como un "adapter")
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
