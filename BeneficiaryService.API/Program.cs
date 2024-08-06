using BeneficiaryService.Application.RepositoryContracts;
using BeneficiaryService.Application.Service;
using BeneficiaryService.Application.ServiceContract;
using BeneficiaryService.Persistence;
using BeneficiaryService.Persistence.RepositoryImplementation;
using Serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BeneficiaryService.API;
using BeneficiaryService.Application;
public class Program
{
    public static void Main(string[] args)
    {
        // Build configuration
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();


        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        //try
        //{
        Log.Information("Starting up the host");
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Host.UseSerilog();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddPersistenceService(builder.Configuration);
        builder.Services.AddApplicationService();
        builder.Services.AddScoped<JwtTokenValidationAttribute>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
        //}
        //catch (Exception ex)
        //{
        //    Log.Information(ex, "Host terminated unexpectedly");
        //}
        //finally
        //{
        //    Log.CloseAndFlush();
        //}
    }
}