using JwtAspNet;
using JwtAspNet.Repositories;
using JwtAspNet.Repositories.Interfaces;
using JwtAspNet.Services;
using JwtAspNet.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ITokenService, TokenService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAuthentication(x => 
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x => 
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Settings.PrivateKey),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddAuthorization(x => {
    x.AddPolicy("user", policy => policy.RequireRole("user"));
    x.AddPolicy("admin", policy => policy.RequireRole("admin"));
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/login", ([FromBody] LoginRequest login, IAuthService authService) => {
        var response = authService.Auth(login);
        if (response is null)
            return Results.Unauthorized();
        return Results.Ok(response);
    });

app.MapGet("/products", () => "Ok!").RequireAuthorization("user");
app.MapGet("/users", () => "Ok!").RequireAuthorization("admin");

app.Run();
