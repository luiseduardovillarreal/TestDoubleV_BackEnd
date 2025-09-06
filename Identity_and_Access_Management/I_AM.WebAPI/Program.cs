using AutoMapper;
using I_AM.Domain.Contracts;
using I_AM.Infrastructure.Base;
using I_AM.Infrastructure.Persistence.Context;
using I_AM.Infrastructure.Persistence.Contracts;
using I_AM.WebAPI.Commons;
using I_AM.WebAPI.ConfigMap;
using I_AM.WebAPI.Controllers.Login;
using I_AM.WebAPI.Listener;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

#pragma warning disable CS8600
#pragma warning disable CS8604

var builder = WebApplication.CreateBuilder(args);

//[LV] Configuración del Mediador...
Assembly appAssembly = Assembly.Load(Constants.Program.I_AM_APPLICATION);
builder.Services.AddMediatR(p => p.RegisterServicesFromAssemblies(appAssembly));

//[LV] Configuración del Contexto de base de datos..
string defConn = Constants.Program.DEFAULT_CONNECTION;
string connStr = Constants.Program.CONNECTION_STRINGS;
builder.Services.AddDbContext<MovementDbContext>(dbContextOptions => dbContextOptions
    .UseNpgsql(builder.Configuration.GetConnectionString(defConn)
        ?? builder.Configuration.GetConnectionString($"{connStr}:{defConn}")));

//[LV] Configuración de AutoMapper...
MapperConfiguration mapperConfiguration = new(config => {
    config.AddProfile(new AutoMapperConfigurations());
});
IMapper mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

//[LV] Inyectando dependencias...
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMovementDbContext, MovementDbContext>();

//[LV] Inyectando servicios de escucha...
builder.Services.AddHostedService<RabbitMQConsumerService>();

//[LV] Configuración de autorización de acceso CORS...
string ipAuthorize = builder.Configuration.GetSection(Constants.Program.IP_AUTHORIZED).Value;
builder.Services.AddCors(p =>
    p.AddPolicy(Constants.Program.CORS_APP, builder =>
    {
        builder.WithOrigins(ipAuthorize)
            .AllowAnyMethod()
            .AllowAnyHeader();
    })
);

//[LV] Configuración de documentación con Swagger...
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(c => c.FullName);
    options.SwaggerDoc(Constants.Program.V1, new()
    {
        Version = Constants.Program.V1,
        Title = Constants.Program.TITLE,
        Description = Constants.Program.DESCRIPTION,
        TermsOfService = new(Constants.Program.TERMS_OF_SERVICE),
        Contact = new()
        {
            Name = Constants.Program.CONTACT_NAME,
            Url = new(Constants.Program.CONTACT_URL)
        },
        License = new()
        {
            Name = Constants.Program.LICENSE_NAME,
            Url = new(Constants.Program.LICENSE_URL)
        }
    });
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//[LV] Minimals APIs...
app.LogInEndPoint();

// Configure the HTTP request pipeline.
app.MapControllers();
app.MapOpenApi();
app.MapGet(Constants.Program.SLASH, context =>
{
    context.Response.Redirect(Constants.Program.SLASH_SWAGGER);
    return Task.CompletedTask;
});
app.UseHttpsRedirection();
app.UseCors(Constants.Program.CORS_APP);
app.UseAuthentication();
app.UseAuthorization();
app.Run();