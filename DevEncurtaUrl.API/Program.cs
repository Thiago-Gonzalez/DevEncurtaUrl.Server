using DevEncurtaUrl.Application.Commands.AddShortenedLinkCommand;
using DevEncurtaUrl.Core.Repositories;
using DevEncurtaUrl.Infrastructure.Persistence;
using DevEncurtaUrl.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddDbContext<DevEncurtaUrlDbContext>(options => options.UseInMemoryDatabase("DevEncurtaUrlDb"));

builder.Services.AddMediatR(typeof(AddShortenedLinkCommand));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
