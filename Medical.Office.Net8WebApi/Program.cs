using Medical.Office.Net8WebApi;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Logging;

Action<CorsPolicyBuilder> cors = builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(_ => true)
                .AllowCredentials();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => options.AddDefaultPolicy(cors));

#region Comentado para agregar Swagger
//builder.Services.AddControllers();
//builder.Services.AddSignalR();
//var app = builder.Build();
#endregion


#region Agregado para integrar Swagger
builder.Services.AddCors(options => options.AddDefaultPolicy(cors));
builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medical.Office.Net8WebApi"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();
app.MapControllers();

// Obtén el logger
var logger = app.Services.GetRequiredService<ILogger<Program>>();

try
{
    app.Run();
    logger.LogInformation("Application started successfully.");
}
catch (Exception ex)
{
    logger.LogError(ex, "Unhandled exception occurred.");
    throw;
}
#endregion
