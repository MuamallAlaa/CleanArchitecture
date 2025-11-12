using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

var app = builder.Build();

// Configure the HTTP requestCommand pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.MapOpenApi();
    
// Automatically redirect to Scalar documentation
app.MapScalarApiReference();

app.UseHttpsRedirection();
app.MapControllers();


app.Run();
