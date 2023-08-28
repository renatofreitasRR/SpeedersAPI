using SpeedersAPI.Data;
using SpeedersAPI.Repositories;
using SpeedersAPI.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUserRepository, UserRepository>();

//string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDatabaseConfiguration(connectionString);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options
.SetIsOriginAllowed(origin => true)
.AllowAnyMethod()
.AllowAnyHeader()
.AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
