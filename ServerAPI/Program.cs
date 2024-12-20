using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Tilf�jer services til containeren s� der kan bruges dependency injection
//tilf�jer Controllers + API-endpoints
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//registrerer vores repositories som scoped services, s� de kan injectes i controllers bla
builder.Services.AddScoped<ApartmentRepository>();
builder.Services.AddScoped<TaskRepository>();
builder.Services.AddScoped<UserRepository>();

// Cors-Policy, tillader kommunikation mellem frontend og backend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp", policy =>
    {
        policy.WithOrigins("https://projekt-cggugnd7dggchdan.eastus-01.azurewebsites.net") // Din frontend URL
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

// Bruger Cors policy
app.UseCors("AllowBlazorApp"); 


// Swagger dokumentation
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
