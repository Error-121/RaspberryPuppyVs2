using RaspberryPuppyVs2.Data.EFDbContext;
using RaspberryPuppyVs2.Models;
using RaspberryPuppyVs2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PuppyDbContext>();
builder.Services.AddTransient<GenericPuppy<Personality>, GenericPuppy<Personality>>();
builder.Services.AddTransient<GenericPuppy<TripData>, GenericPuppy<TripData>>();

builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var connectionString = builder.Configuration.GetConnectionString("RaspberryPuppyDB");

var app = builder.Build();

//app.UseSwagger();
//app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
