using LicensingAPI.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ DB CONTEXT
builder.Services.AddDbContext<LicensingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// ✅ CORS (Angular)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", p =>
        p.WithOrigins("http://localhost:4200", "https://localhost:4200")
         .AllowAnyHeader()
         .AllowAnyMethod()
    );
});

var app = builder.Build();

// ✅ Print runtime DB (this proves if you're using Licensing or not)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LicensingDbContext>();
    var conn = (SqlConnection)db.Database.GetDbConnection();

    Console.WriteLine("=== DB INFO (runtime) ===");
    Console.WriteLine($"DataSource: {conn.DataSource}");
    Console.WriteLine($"Database:   {conn.Database}");
    Console.WriteLine("=========================");
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseCors("AllowAngular");

app.MapControllers();
app.Run();
