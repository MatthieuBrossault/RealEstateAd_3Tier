using Microsoft.EntityFrameworkCore;
using RealEstateAd_3Tier_BLL.Contracts;
using RealEstateAd_3Tier_BLL.Services;
using RealEstateAd_3Tier_DAL.Contracts;
using RealEstateAd_3Tier_DAL.Data;
using RealEstateAd_3Tier_DAL.Repositories;
using RealEstateAd_3Tier_DAL.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add DbContext
builder.Services.AddDbContext<RealEstateAdDb>(opt => opt.UseInMemoryDatabase("RealEstateAdList"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IRealEstateAdService, RealEstateAdService>();

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
