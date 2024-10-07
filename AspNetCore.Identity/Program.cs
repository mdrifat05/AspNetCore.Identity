using AspNetCore.Identity;
using AspNetCore.Identity.Data;
using AspNetCore.Identity.Extensions;
using AspNetCore.Identity.Swagger;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDoc();

builder.Services.AddAuthentication()
.AddCookie(IdentityConstants.ApplicationScheme);
//.AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorization();

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

builder.Services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Enable Identity APIs
app.CustomMapIdentityApi<User>();
//app.MapIdentityApi<User>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
