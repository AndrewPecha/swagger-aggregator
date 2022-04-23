using Microsoft.AspNetCore.Routing.Template;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(x =>
{
    x.AllowAnyOrigin();
    x.AllowAnyHeader();
    x.AllowAnyMethod();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("https://localhost:7152/swagger/v1/swagger.json", "Banana API");
        x.SwaggerEndpoint("https://localhost:7084/swagger/v1/swagger.json", "Grapefruit API");
    });
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();