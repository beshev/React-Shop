using Data.Models;
using Data.Repositories;
using Infrastructure.Extentions;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterAutoMapper();
builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.RegisterSettings<MongoDbSetting>(builder.Configuration);
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
