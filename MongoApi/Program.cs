using Microsoft.Extensions.DependencyInjection;
using MongoApi.Context;
using MongoApi.Repository.Abstraction;
using MongoApi.Repository.Book;
using MongoApi.Repository.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// di configuration's  for mongo Settings
builder.Services.AddOptions<MongoSettings>()
    .Bind(builder.Configuration.GetSection("MongoSettings"));

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IBookRepository, BookRepository>();


builder.Services.AddSingleton<IMongoContext, MongoContext>();
// now we need to just hardcode this di for now we fix them later

builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
//builder.Services.AddTransient<IBaseRepository<EtebarDoreh>, BaseRepository<EtebarDoreh>>();


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
