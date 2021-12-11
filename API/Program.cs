using System.Text;
using API.Data;
using API.Data.Interfaces;
using API.Mapper;
using API.Services;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlite<DataContext>(connectionString);
builder.Services.AddControllers();
//  agregamos repositorios
builder.Services.AddScoped<IApiRepository,ApiRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

// se agrega token service
builder.Services.AddScoped<ITokenService, TokenService>();
            
//Mapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

// Agregar configuracion para uso de Token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Token"]) ),
                        ValidateIssuer = false,
                        ValidateAudience = false
                } ;
            });

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


// agregar authenticacion 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
