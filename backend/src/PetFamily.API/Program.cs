using PetFamily.API.Middlewares;
using PetFamily.API.Validation;
using PetFamily.Application.Volunteers;
using PetFamily.Application.Volunteers.Create;
using PetFamily.Infrastructure;
using PetFamily.Infrastructure.Repositories;
using Serilog;
using Serilog.Events;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

//��������� ������ Seq
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
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<CreateVolunteerService>();
builder.Services.AddScoped<IVolunteersRepository, VolunteersRepository>();

builder.Services.AddSerilog();// ����������� Serilog � DI-����������  (� ������� dependency injection (DI) )

//��������� ��������� - FluentValidation (����� SharpGrip.FluentValidation.AutoValidation.Mvc)
builder.Services.AddFluentValidationAutoValidation(configuration =>
{
    configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
});

var app = builder.Build();
app.UseExceptionHandleMiddleware();//��������� ��������� ����������
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // await app.ApplyMigration();  //��������� �������� ������������� ��� ������� �������
}

app.UseSerilogRequestLogging();//��������� ���������� Serilog � �������� middleware - ��������� ����������� HTTP-��������
app.UseAuthorization(); 
app.MapControllers();

app.Run();
