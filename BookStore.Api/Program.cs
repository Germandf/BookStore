using BookStore.Api.Common.Behaviors;
using BookStore.Api.Common.Models;
using BookStore.Api.Common.Settings;
using BookStore.Api.Features.Books;
using BookStore.Api.Persistence;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.Mime;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(cfg =>
    {
        cfg.Filters.Add(new ProducesResponseTypeAttribute(typeof(ValidationProblemDetails), 400));
        cfg.Filters.Add(new ProducesResponseTypeAttribute(typeof(ProblemDetails), 409));
        cfg.Filters.Add(new ProducesResponseTypeAttribute(typeof(ProblemDetails), 500));
        cfg.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.Json));
    })
    .AddJsonOptions(cfg =>
    {
        cfg.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection(nameof(RabbitMqSettings)));
builder.Services.Configure<PostgreSqlSettings>(builder.Configuration.GetSection(nameof(PostgreSqlSettings)));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddDbContext<BookStoreDbContext>((sp, cfg) =>
{
    var settings = sp.GetRequiredService<IOptions<PostgreSqlSettings>>().Value;
    cfg.UseNpgsql(settings.ConnectionString);
});
builder.Services.AddMassTransit(cfg =>
{
    cfg.UsingRabbitMq((context, cfg) =>
    {
        var settings = context.GetRequiredService<IOptions<RabbitMqSettings>>().Value;
        cfg.Host(settings.Uri, "/", c =>
        {
            c.Username(settings.UserName);
            c.Password(settings.Password);
        });
        cfg.ConfigureEndpoints(context);
    });
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
