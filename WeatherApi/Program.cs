var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

const string corsPolicyName = "AllowBlazorClient";
var allowedOrigins = builder.Configuration["AllowedCorsOrigin"] ?? "https://localhost:7237";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy.WithOrigins(allowedOrigins)
            .AllowAnyMethod()  
            .AllowAnyHeader() 
            .AllowCredentials(); 
    });
});

builder.Services.AddControllers();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors(corsPolicyName); 
app.MapControllers();

app.Run();