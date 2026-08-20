
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace PrimeSieve
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            static void ConfigureOpenTelemetryResource(ResourceBuilder builder)
                => builder.AddService(serviceName: "PrimeSieve", serviceVersion: "1.0.0");

            static void ConfigureOpenTelemetryTracing(TracerProviderBuilder builder)
                => builder.AddAspNetCoreInstrumentation().AddOtlpExporter();
                
            builder.Services.AddOpenTelemetry()
                .ConfigureResource(ConfigureOpenTelemetryResource)
                .WithTracing(ConfigureOpenTelemetryTracing);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
