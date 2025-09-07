using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movement.Domain.Contracts;
using Movement.Infrastructure.Base;
using Movement.Infrastructure.Persistence.Context;
using Movement.Infrastructure.Persistence.Contracts;
using Movement.WebAPI.Commons;
using Movement.WebAPI.ConfigMap;
using Movement.WebAPI.Controllers.Deb_t;
using Movement.WebAPI.Controllers.Pa_y;
using System.Reflection;

#pragma warning disable CS8600
#pragma warning disable CS8604

var builder = WebApplication.CreateBuilder(args);

//[LV] Configuración del Mediador...
Assembly appAssembly = Assembly.Load(Constants.Program.MOVEMENT_APPLICATION);
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

//[LV] builder.Services.AddScoped<SurveyDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMovementDbContext, MovementDbContext>();

//[LV] Configuración de autorización de acceso CORS...
string ipAuthorize = builder.Configuration.GetSection(Constants.Program.IP_AUTHORIZED).Value;
builder.Services.AddCors(p =>
    p.AddPolicy(Constants.Program.CORS_POLICY, builder =>
    {
        builder.WithOrigins(ipAuthorize)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
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

var app = builder.Build();

//[LV] Correr Migración al levantar la API.
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MovementDbContext>();
    context.Database.Migrate();
}

//[LV] Configuración del uso de Swagger
app.UseSwagger();
app.UseSwaggerUI();

//[LV] Uso del  Hub como herramienta Real Time.
app.UseRouting();

//[LV] Configuración de los recursos del API (Minimals)
app.CreateDebtEndPoint();
app.ActivateDebtEndPoint();
app.GetAllDebtsByUserEndPoint();
app.GetAllDebtsEndPoint();
app.GetAnyDebtActiveByIdEndPoint();
app.GetAnyDebtByIdEndPoint();
app.CreatePayDebtEndPoint();
app.DeleteDebtEndPoint();

// Configure the HTTP request pipeline.
app.MapControllers();
app.MapOpenApi();
app.MapGet(Constants.Program.SLASH, context =>
{
    context.Response.Redirect(Constants.Program.SLASH_SWAGGER);
    return Task.CompletedTask;
});
app.UseHttpsRedirection();
app.UseCors(Constants.Program.CORS_POLICY);
app.UseAuthentication();
app.UseAuthorization();
app.Run();