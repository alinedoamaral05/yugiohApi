using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.IServices;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Infra.Database.Config.Entity;
using YuGiOhApi.Infra.Database.Config.Identity;
using YuGiOhApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var userConnectionString = builder.Configuration.GetConnectionString("UserConnection");

builder.Services.AddDbContext<YugiohContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(userConnectionString));

builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<UserContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUserService<LoginUserDto>, UserService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
