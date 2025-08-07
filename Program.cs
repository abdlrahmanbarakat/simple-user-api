using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger; // Add this if needed for extension methods
using Microsoft.Extensions.DependencyInjection;
using UserManagementAPI.Middleware;


var builder = WebApplication.CreateBuilder(args);

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
app.UseRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

// Map controller endpoints like UsersController
app.MapControllers();

app.Run();
