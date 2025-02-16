using PetFamily.API.Extensions;
using PetFamily.API.Validation;
using PetFamily.Application.Volunteers;
using PetFamily.Application.Volunteers.Create;
using PetFamily.Infrastructure;
using PetFamily.Infrastructure.Repositories;
using Serilog;
using Serilog.Events;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

//добовляем логгер
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Debug()
    .WriteTo.Seq(builder.Configuration.GetConnectionString("Seq")
                 ?? throw new ArgumentNullException("Seq"))
    .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
    .CreateLogger();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<CreateVolunteerService>();
builder.Services.AddScoped<IVolunteersRepository, VolunteersRepository>();

builder.Services.AddSerilog();

//добовляем валидацию - FluentValidation (пакет SharpGrip.FluentValidation.AutoValidation.Mvc)
builder.Services.AddFluentValidationAutoValidation(configuration =>
{
    configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
});

var app = builder.Build(); 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    await app.ApplyMigration();  //применяем миграции автоматически при запуске проекта
}

app.UseAuthorization();

app.MapControllers();

app.Run();
