using DevEncurtaUrl.Application.Commands.AddShortenedLinkCommand;
using DevEncurtaUrl.Core.Repositories;
using DevEncurtaUrl.Infrastructure.Persistence;
using DevEncurtaUrl.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(
        policy => {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
    );
});

builder.Services.AddScoped<IShortenedLinkRepository, ShortenedLinkRepository>();

var connectionString = builder.Configuration.GetConnectionString("DevEncurtaUrlCs");

builder.Services.AddDbContext<DevEncurtaUrlDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddMediatR(typeof(AddShortenedLinkCommand));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "DevEncurtaUrl.API",
        Version = "v1",
        Contact = new OpenApiContact {
            Name = "Thiago González",
            Email = "contatothiagogonzalez@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/thiago-gonz%C3%A1lez/")
        }
    });

    var xmlFile = "DevEncurtaUrl.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


builder.Host.ConfigureAppConfiguration((hostingContext, config) => {
    Serilog.Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.MSSqlServer(connectionString, sinkOptions: new MSSqlServerSinkOptions {
            AutoCreateSqlTable = true,
            TableName = "Logs"
        })
        .WriteTo.Console()
        .CreateLogger();
}).UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
