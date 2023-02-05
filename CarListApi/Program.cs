using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", a => a
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod()
    );
});

var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "carList.db");
var connection = new SqliteConnection(@$"Data Source={dbPath}");
builder.Services.AddDbContext<CarListDbContext>(options => options.UseSqlite(connection));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

app.MapGet("/cars", async (CarListDbContext dbContext) => await dbContext.Cars.ToListAsync());
app.MapGet("/cars/{id:int}", async (int id, CarListDbContext dbContext) =>
{
    var car = await dbContext.Cars.FindAsync(id);

    if (car == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(car);
});

app.MapPost("/cars", async ([FromBody] Car postPayload, CarListDbContext dbContext) =>
{
    await dbContext.AddAsync(postPayload);

    await dbContext.SaveChangesAsync();

    return Results.Created($"/cars/{postPayload.Id}", postPayload);
});

app.MapPut("/cars/{id:int}", async (int id, [FromBody] Car updatePayload, CarListDbContext dbContext) =>
{
    var car = await dbContext.Cars.FindAsync(id);

    if (car == null)
    {
        return Results.NotFound();
    }

    car.Brand= updatePayload.Brand;
    car.Model = updatePayload.Model;
    car.Vin = updatePayload.Vin;

    dbContext.Update(car);

    await dbContext.SaveChangesAsync();

    return Results.Ok(car);
});

app.MapDelete("/cars/{id:int}", async (int id, CarListDbContext dbContext) =>
{
    var car = dbContext.Cars.Find(id);

    if (car == null)
    {
        return Results.NotFound();
    }

    dbContext.Cars.Remove(car);

    await dbContext.SaveChangesAsync();

    return Results.Ok(car);
});

app.Run();