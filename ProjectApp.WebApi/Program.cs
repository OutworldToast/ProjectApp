using Microsoft.EntityFrameworkCore;
using ProjectApp.WebApi.Data;
using Microsoft.AspNetCore.Identity;
using ProjectApp.WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<OnderzoekContext>( //vulnerability in connection string => TrustServerCertificate = true
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("WDPRConnection"))
    );
builder.Services.AddIdentity<Gebruiker, IdentityRole<int>>()
                .AddEntityFrameworkStores<OnderzoekContext>()
                .AddDefaultTokenProviders();
builder.Services.AddAuthentication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var FrontendOrigin = "allowFrontendOrigin";

builder.Services.AddCors(options => {
    options.AddPolicy(
        name: FrontendOrigin,
        policy =>
        {
            policy.WithOrigins("https://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader();
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(FrontendOrigin);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
