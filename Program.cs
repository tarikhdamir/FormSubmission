using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database & Dependency Injection
builder.Services.AddDbContext<FormDbContext>(options =>
    options.UseSqlite("Data Source=formsubmission.db"));

builder.Services.AddScoped<IFormRepository, FormRepository>();
builder.Services.AddScoped<FormService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueFrontend",
        policy => policy
            .WithOrigins("http://localhost:5173") // Allow frontend
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowVueFrontend");
app.UseAuthorization();
app.MapControllers();
app.Run();
