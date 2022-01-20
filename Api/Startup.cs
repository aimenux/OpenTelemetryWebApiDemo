using Api.Helpers;
using Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddControllers();

        services.AddDbContext<TodoDbContext>(options =>
        {
            options.UseInMemoryDatabase("TodoDb");
        });

        services.AddOpenTelemetryTracing(builder =>
        {
            builder
                .AddSource(OpenTelemetrySource.SourceName)
                .SetResourceBuilder(GetResourceBuilder())
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddSqlClientInstrumentation()
                .AddConsoleExporter()
                .AddZipkinExporter(options =>
                {
                    options.Endpoint = new Uri(Configuration.GetValue<string>("ZipKin"));
                });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("OK");
            });

            endpoints.MapControllers();
        });
    }

    private static ResourceBuilder GetResourceBuilder() => ResourceBuilder.CreateDefault().AddService("OpenTelemetryTracer");
}