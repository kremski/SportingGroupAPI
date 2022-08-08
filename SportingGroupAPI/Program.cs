using Microsoft.EntityFrameworkCore;
using SportingGroupAPI.DAL;
using SportingGroupAPI.Services;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration =
    new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<SportingGroupDbContext>(options =>
    options.UseSqlServer(configuration["ConnectionStrings:SportingGroupDatabase"]));

builder.Services.AddScoped<IBettingService, BettingService>();
builder.Services.AddScoped<IFixtureService, FixtureService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<SportingGroupDbContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
