using Microsoft.EntityFrameworkCore;
using MyAppWebAPI_HIENLTH.Data;
using MyAppWebAPI_HIENLTH.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
});

builder.Services.AddAuthentication();

builder.Services.AddScoped<ILoaiReponsitory, LoaiReponsitory>();
builder.Services.AddScoped<ILoaiReponsitory, LoaiReponsitoryInMemory>();
builder.Services.AddScoped<IHangHoaReponsitory, HangHoaReponsitory>();

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
