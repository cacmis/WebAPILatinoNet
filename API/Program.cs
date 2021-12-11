using API.Data;
using API.Data.Interfaces;
using API.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlite<DataContext>(connectionString);
builder.Services.AddControllers();
//  agregamos repositorios
builder.Services.AddScoped<IApiRepository,ApiRepository>();

//Mapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);


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
