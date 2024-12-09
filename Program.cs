using digonto.DependencyInjection;
using Serilog;
var builder = WebApplication.CreateBuilder(args);
//Add Serilog for Loging---------------------------------------
Log.Logger = new LoggerConfiguration()
.Enrich.FromLogContext()
.WriteTo.Console()
.WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
.CreateLogger();

//builder.Host.UseSerilog();
Log.Logger.Information("Application is building.....");
//---------------------Serilog-----------------------------------
builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddCors(
   builder =>
   {
       builder.AddDefaultPolicy(options =>
       {
           options.AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin()
           .AllowCredentials();
           // .WithOrigins("https://localhost:7025");
       });
   });
try
{


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    Log.Logger.Information("Application is running.....");
    app.Run();
}
catch (Exception ex)
{
    //  Log.Logger.Error(ex, "Application failed to start......");
}
finally
{
    // Log.CloseAndFlush();
}