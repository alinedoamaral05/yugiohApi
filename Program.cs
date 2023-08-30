using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.IRepositories;
using YuGiOhApi.Domain.IServices;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Infra.Database.Config.Entity;
using YuGiOhApi.Infra.Database.Config.Identity;
using YuGiOhApi.Infra.Database.Repositories;
using YuGiOhApi.Providers.Implementations;
using YuGiOhApi.Providers.Interfaces;
using YuGiOhApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var userConnectionString = builder.Configuration.GetConnectionString("UserConnection");

builder.Services.AddDbContext<YugiohContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));

builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<YugiohContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUserService<LoginUserDto>, UserService>();
builder.Services.AddScoped<IUserRepository,  UserRepository>();
builder.Services.AddScoped<IUserMapper, UserMapper>();

builder.Services.AddScoped<TokenService>();

builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<ICardMapper, CardMapper>();

builder.Services.AddScoped<ICardTypeService, CardTypeService>();
builder.Services.AddScoped<ICardTypeRepository, CardTypeRepository>();
builder.Services.AddScoped<ICardTypeMapper, CardTypeMapper>();

builder.Services.AddScoped<IDeckService, DeckService>();
builder.Services.AddScoped<IDeckRepository, DeckRepository>();
builder.Services.AddScoped<IDeckMapper, DeckMapper>();

builder.Services.AddAuthentication(opts =>
{
    opts.DefaultAuthenticateScheme =
    JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer( opts =>
{
    opts.TokenValidationParameters = new
    Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("384qfheh89hq89fsda8HFQ349FHE3823HUUHSK")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
}) ;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
