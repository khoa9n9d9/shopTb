using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShopTB.DbRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ShopTB.sakila;
using ShopTB.Controllers;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
                policy =>
                {
                    policy.WithOrigins("https://localhost:7151", "https://localhost:44485")
                            .WithMethods("POST", "PUT", "DELETE", "GET");
                });
});

var key = builder.Configuration.GetValue<string>("AppSettings:Token");
var signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
builder.Services.AddDbContext<ShoptbContext>(_ =>
{
    _.UseMySQL("server=localhost; user id=root; password=1234; database=shoptb");
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false, 
        ValidateAudience = false,
        RequireExpirationTime = true,
        ValidateLifetime = true,
        IssuerSigningKey = signKey,
        RequireSignedTokens = true,
    }
    );
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// Enable middleware to serve generated Swagger as a JSON endpoint.  
app.UseSwagger();
// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),  
// specifying the Swagger JSON endpoint.  
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
