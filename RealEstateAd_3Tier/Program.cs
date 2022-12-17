using Microsoft.EntityFrameworkCore;
using Polly.Extensions.Http;
using Polly;
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

// Use IHttpClientFactory to implement resilient HTTP requests
builder.Services.AddHttpClient<IOpenMeteoService, OpenMeteoService>(client =>
{
    client.BaseAddress = new Uri("https://api.open-meteo.com/v1");
})
    .AddPolicyHandler(GetRetryPolicy())
    .AddPolicyHandler(GetCircuitBreakerPolicy());

// Retries with exponential backoff
static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
}

// Circuit Breaker pattern
static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
}

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
