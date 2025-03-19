using PetFamily.API.Extensions;
using PetFamily.API.Middlewares;
using PetFamily.API.Validation;
using PetFamily.Application;
using PetFamily.Infrastructure;
using Serilog;
using Serilog.Events;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

//добовляем логгер Seq и Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Debug()
    .WriteTo.Seq(builder.Configuration.GetConnectionString("Seq")
                 ?? throw new ArgumentNullException("Seq connection string is missing"))
    .Enrich.WithThreadId()
    .Enrich.WithEnvironmentName()
    .Enrich.WithEnvironmentUserName()
    .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
    .CreateLogger();


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<ApplicationDbContext>();//перенесен в PetFamily.Infrastructure\Inject.cs
//builder.Services.AddScoped<IVolunteerRepository, VolunteerRepository>();//перенесен в PetFamily.Infrastructure\Inject.cs
//builder.Services.AddScoped<DeleteVolunteerRequestHandler>(); //добавляем обработчик запроса на удаление волонтера,перенесен в PetFamily.Infrastructure\Inject.cs и PetFamily.Application\Inject.cs
//builder.Services.AddScoped<CreateVolunteerHandler>(); //перенесен в PetFamily.Application\Inject.cs
//builder.Services.AddScoped<UpdateMainInfoHandler>(); //перенесен в PetFamily.Application\Inject.cs
//builder.Services.AddScoped<UpdateRequisitesHandler>(); //перенесен в PetFamily.Application\Inject.cs
//builder.Services.AddScoped<UpdateSocialNetworksHandler>();//перенесен в PetFamily.Application\Inject.cs 

// Регистрация Serilog в DI-контейнере  (в систему dependency injection (DI) )
builder.Services.AddSerilog();

//добавляем инфраструктуру PetFamily.Infrastructure\Inject.cs  (class Inject)
builder.Services.AddInfrastructure(builder.Configuration);

//добавляем приложение PetFamily.Application\Inject.cs (class Inject)
builder.Services.AddApplication();

//добовляем валидацию - FluentValidation (пакет SharpGrip.FluentValidation.AutoValidation.Mvc)
builder.Services.AddFluentValidationAutoValidation(configuration =>
{
    configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
});

var app = builder.Build();
app.UseExceptionHandleMiddleware();//добавляем обработку исключений
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    await app.ApplyMigration();  //применяем миграции автоматически при запуске проекта
}

app.UseSerilogRequestLogging();//добавляем библиотеки Serilog в конвейер middleware - Включение логирования HTTP-запросов
app.UseAuthorization();
app.MapControllers();

app.Run();
