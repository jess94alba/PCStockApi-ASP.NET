using Microsoft.EntityFrameworkCore;
using PCStockApi.Data; // Asegúrate que este using esté para reconocer AppDbContext

var builder = WebApplication.CreateBuilder(args);

// 1. Leer la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("PCStockConnection");

// 2. Configurar el DbContext con SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

