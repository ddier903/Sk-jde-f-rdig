using ServerAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Tilføj CORS service med en politik
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin",
		policy => policy.WithOrigins("https://localhost:7227") // Tillader din frontend applikation
			.AllowAnyHeader()
			.AllowAnyMethod());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ApartmentRepository>();
builder.Services.AddScoped<TaskRepository>();
builder.Services.AddScoped<UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
