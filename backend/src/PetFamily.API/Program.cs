using PetFamily.API.Extensions;
using PetFamily.API.Middlewares;
using PetFamily.API.Validation;
using PetFamily.Application;
using PetFamily.Infrastructure;
using Serilog;
using Serilog.Events;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

//��������� ������ Seq � Serilog
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
//builder.Services.AddScoped<ApplicationDbContext>();//��������� � PetFamily.Infrastructure\Inject.cs
//builder.Services.AddScoped<IVolunteerRepository, VolunteerRepository>();//��������� � PetFamily.Infrastructure\Inject.cs
//builder.Services.AddScoped<DeleteVolunteerRequestHandler>(); //��������� ���������� ������� �� �������� ���������,��������� � PetFamily.Infrastructure\Inject.cs � PetFamily.Application\Inject.cs
//builder.Services.AddScoped<CreateVolunteerHandler>(); //��������� � PetFamily.Application\Inject.cs
//builder.Services.AddScoped<UpdateMainInfoHandler>(); //��������� � PetFamily.Application\Inject.cs
//builder.Services.AddScoped<UpdateRequisitesHandler>(); //��������� � PetFamily.Application\Inject.cs
//builder.Services.AddScoped<UpdateSocialNetworksHandler>();//��������� � PetFamily.Application\Inject.cs 

// ����������� Serilog � DI-����������  (� ������� dependency injection (DI) )
builder.Services.AddSerilog();

//��������� �������������� PetFamily.Infrastructure\Inject.cs  (class Inject)
builder.Services.AddInfrastructure(builder.Configuration);

//��������� ���������� PetFamily.Application\Inject.cs (class Inject)
builder.Services.AddApplication();

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

    await app.ApplyMigration();  //��������� �������� ������������� ��� ������� �������
}

app.UseSerilogRequestLogging();//��������� ���������� Serilog � �������� middleware - ��������� ����������� HTTP-��������
app.UseAuthorization();
app.MapControllers();

app.Run();
