using LicensingAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ REGISTER DB CONTEXT (THIS FIXES YOUR ERROR)
builder.Services.AddDbContext<LicensingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// ✅ CORS for Angular (kept exactly like yours)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", p =>
        p.AllowAnyHeader()
         .AllowAnyMethod()
         .AllowCredentials()
         .SetIsOriginAllowed(origin =>
             origin == "http://localhost:4200" || origin == "https://localhost:4200"));
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

// ✅ IMPORTANT: CORS before MapControllers
app.UseCors("AllowAngular");

app.MapControllers();

app.Run();
