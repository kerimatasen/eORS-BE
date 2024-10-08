using MediatR;
using eORS.Infrastructure.Data;
using eORS.Infrastructure.Repositories;
using eORS.Infrastructure.UnitOfWork;
using eORS.Application.Commands.Teachers;
using Microsoft.EntityFrameworkCore;
using eORS.Domain.Interfaces;
using System.Reflection;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;

var builder = WebApplication.CreateBuilder(args);
// Serilog yapýlandýrmasý
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var columnOptions = new ColumnOptions
{
    Store = { StandardColumn.LogEvent }
};

// SQL Server için ek sütunlar ekleyebiliriz
columnOptions.AdditionalColumns = new Collection<SqlColumn>
{
    new SqlColumn { ColumnName = "Application", DataType = System.Data.SqlDbType.NVarChar, DataLength = 100 }
};
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.MSSqlServer(
        connectionString,
        sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true },
        columnOptions: columnOptions,
   restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
    .CreateLogger();

// CORS Policy Ekleme
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
// Serilog'u kullanmak üzere uygulama servisini ayarla
builder.Host.UseSerilog();
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Veritabaný baðlantýsýný yapýlandýrma

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Dependency Injection için IUnitOfWork ekleyelim
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Diðer repository ve service'leri ekleyin
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// MediatR Servisi Enjeksiyonu
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());            // API katmaný
    cfg.RegisterServicesFromAssembly(typeof(AddTeacherCommand).Assembly);          // Application katmaný
    cfg.RegisterServicesFromAssembly(typeof(eORS.Application.Queries.Students.GetAllStudentsQuery).Assembly);  // Diðer katmanlar
});




// Uygulama baþlatma ve middleware ayarlarý
var app = builder.Build();
// CORS Politikasýný Uygulama
app.UseCors("AllowAllOrigins");

app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
