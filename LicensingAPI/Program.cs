var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ CORS for Angular
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
