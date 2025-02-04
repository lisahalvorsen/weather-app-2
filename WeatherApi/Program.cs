var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

const string corsPolicyName = "AllowBlazorClient";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy.WithOrigins("https://localhost:7237")
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