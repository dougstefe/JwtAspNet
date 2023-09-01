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


var app = builder.Build();

app.Run();
