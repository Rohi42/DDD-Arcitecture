using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using JWTHandler;
using Ocelot.Values;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddCustomJWTAuthentication();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder =>
        builder.WithOrigins("http://localhost:4200") // Specify the allowed origin
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());
});


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.UseCors("MyCorsPolicy");
await app.UseOcelot();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
