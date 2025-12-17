using Scalar.AspNetCore; 
using Serilog;
using Serilog.Formatting.Json;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
     .WriteTo.File(
        formatter: new JsonFormatter(),
        path: "logs/app-.json",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers().AddApplicationPart(typeof(Program).Assembly); 
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
 

var app = builder.Build();

//Farklý bilgilerin loglanmasý için kullanýyoruz.
app.UseSerilogRequestLogging(options =>
{
    options.EnrichDiagnosticContext = (context, httpContext) =>
    {
        context.Set("UserAgent", httpContext.Request.Headers.UserAgent);
        context.Set("RemoteIP", httpContext.Connection.RemoteIpAddress);
    };
});

app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Unhandled exception occurred");

        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("An unexpected error occurred.");
    }
});



if (app.Environment.IsDevelopment())
{
    //Swagger Benzeri Kütüphane için ekledim
    app.MapOpenApi(); 
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
