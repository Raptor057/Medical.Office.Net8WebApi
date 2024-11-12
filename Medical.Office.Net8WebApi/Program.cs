using Medical.Office.Net8WebApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Security.Claims;
using System.Text;

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


builder.Services.AddCors(options => options.AddDefaultPolicy(cors));
builder.Services.AddControllers();

//Agregado para hacer politicas personalizadas
builder.Services.AddAuthorization(options =>
{
    #region Example
    //options.AddPolicy("AdminIT", policy =>
    //           policy.RequireAssertion(context =>
    //               context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "Admin") &&
    //               context.User.HasClaim(c => c.Type == "Department" && c.Value == "IT"))); // Requiere que el usuario sea Admin y pertenezca al departamento de IT

    //options.AddPolicy("IT", policy =>
    //       policy.RequireAssertion(context =>
    //           context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "Admin") &&
    //           context.User.HasClaim(c => c.Type == "Department" && c.Value == "IT"))); // Requiere que el usuario sea Admin y pertenezca al departamento de IT

    //options.AddPolicy("ITDepartmentPolicy", policy =>
    //policy.RequireClaim("Department", "IT")); // Ejemplo de pol�tica que requiere que el usuario pertenezca a los departamentos IT o HR
    #endregion

    options.AddPolicy("All", policy =>
    policy.RequireAssertion(context =>
        context.User.HasClaim(c => c.Type == ClaimTypes.Role &&
            (c.Value == "Programador" ||
             c.Value == "Doctor" ||
             c.Value == "Enfermera" ||
             c.Value == "Secretaria" ||
             c.Value == "Asistente"))));
});

builder.Services.AddServices();
builder.Services.AddSignalR();
//Esto agrega los servicios de autenficicacion
var key = builder.Configuration.GetValue<string>("ApiAuthenticationSettings:SecretKey");

builder.Services.AddAuthentication(
    x =>
    {//Expresion lambda , establece el squema de autentificacion predeterminado como JWT
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
    ).AddJwtBearer(x =>
    {
        //Autentificacion del manejador, esta lambda configura las opciones especificas
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "ERP Medical Office", Version = "v1" });
    options.EnableAnnotations(); // Habilitar anotaciones
});

var app = builder.Build();

// Configure the HTTP request pipeline.
#region Agregado para integrar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medical.Office.Net8WebApi"));
}
#endregion

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

