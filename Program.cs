using Fieldor_WebAPI.App_Code;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddScoped<CommonClass>();
// Register services in DI container
builder.Services.AddMemoryCache();  // Add memory cache to the DI container
builder.Services.AddSingleton<TimeZoneService>(); // Register the helper class as a Singleton

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddXmlSerializerFormatters();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
if (!app.Environment.IsProduction())
{
    app.Logger.LogInformation("Enabling HTTPS redirection.");
    app.UseHttpsRedirection();
}
else
{
    app.Logger.LogInformation("Skipping HTTPS redirection in Production.");
}



app.UseAuthorization();
app.MapControllers();
app.Run();