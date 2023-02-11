using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

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

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CarListDbContext>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
    });

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
});

var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "carList.db");
var connection = new SqliteConnection(@$"Data Source={dbPath}");
builder.Services.AddDbContext<CarListDbContext>(options => options.UseSqlite(connection));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

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

    car.Brand = updatePayload.Brand;
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

app.MapPost("/login", async (LoginDto loginDto, UserManager<IdentityUser> userManager) =>
{
    var user = await userManager.FindByNameAsync(loginDto.Username);

    if (user == null)
    {
        return Results.BadRequest();
    }

    var isValidPassword = await userManager.CheckPasswordAsync(user, loginDto.Password);

    if (!isValidPassword)
    {
        return Results.BadRequest();
    }

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]));
    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var roles = await userManager.GetRolesAsync(user);
    var claims = await userManager.GetClaimsAsync(user);
    var tokenClaims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
        }
        .Union(claims)
        .Union(roles.Select(r => new Claim(ClaimTypes.Role, r)))
        .ToList();

    var token = new JwtSecurityToken(
        issuer: builder.Configuration["JwtSettings:Issuer"],
        audience: builder.Configuration["JwtSettings:Audience"],
        claims: tokenClaims,
        expires: DateTime.UtcNow.AddMinutes(int.Parse(builder.Configuration["JwtSettings:DurationMinutes"])),
        signingCredentials: credentials
    );

    var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

    var response = new AuthResponseDto()
    {
        UserId = user.Id,
        Username = user.UserName,
        AccessToken = tokenStr,
    };

    return Results.Ok(response);
}).AllowAnonymous();

var bogdanVisitsCount = 0;

app.MapGet("bogdan/endpoint/", () =>
{
    return Results.Content($"<h1>Богдан Сидоренко Русланович відвідав цю сторінку {bogdanVisitsCount++} {(bogdanVisitsCount == 1 ? "раз" : "разів")}<h1>", "text/html", Encoding.Unicode);
}).AllowAnonymous();

app.Run();

public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class AuthResponseDto
{
    public string UserId { get; set; }
    public string Username { get; set; }
    public string AccessToken { get; set; }
}