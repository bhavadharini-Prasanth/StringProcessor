using Microsoft.OpenApi.Models;
using StringProcessor.Domain;
using StringProcessor.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container
builder.Services.AddScoped<IStringProcessor, SimpleStringProcessor>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Needed for Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "String Processor API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "String Processor API V1");
});
app.MapGet("/", () => Results.Redirect("/swagger"));
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
