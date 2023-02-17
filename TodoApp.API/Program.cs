using Microsoft.EntityFrameworkCore;
using TodoApp.API.Auth;
using TodoApp.API.DB;
using TodoApp.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AuthConfigurator.Configure(builder);

builder.Services.AddDbContext<AppDbContext>
    (x => x.UseSqlServer(builder.Configuration.GetConnectionString("AppToDB")));



builder.Services.AddTransient<ISendEmailRequestRepository, SendEmailRequestRepository>();
builder.Services.AddTransient<ITodoRepository, TodoRepository>();
var app = builder.Build(); 

using (var scope = app.Services.CreateScope())
{
    using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
