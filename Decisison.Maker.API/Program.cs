using Decisison.Maker.API.Data.Context;
using Decisison.Maker.API.Data.Seeders;
using Decisison.Maker.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddDbContext<DataContext>(options =>
    {
        //options.UseSqlServer(builder.Configuration.GetConnectionString("Decision_DB"));
        options.UseSqlite(builder.Configuration.GetConnectionString("Decicion_DB_Sqlite"));
    });

    builder.Services.AddScoped<IDecisionService, DecisionService>();
    builder.Services.AddScoped<IDecisionSeeder, DecisionSeeder>();

    builder.Services.AddControllers()
        .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Apply migrations and seed data
    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<IDecisionSeeder>();

    await seeder.Seed();

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
}
catch (Exception)
{

    throw new Exception("Application startup failed!");
}
