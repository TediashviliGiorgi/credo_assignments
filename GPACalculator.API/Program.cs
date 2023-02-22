using GPACalculator.API.DB;
using GPACalculator.API.Features.Students.CalculateGPA;
using GPACalculator.API.Features.Students.Grades;
using GPACalculator.API.Features.Students.RegisterStudent;
using GPACalculator.API.Features.Subjects;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("AppToDb")));
builder.Services.AddTransient<CreateSubjectValidation>();
builder.Services.AddTransient<RegisterStudentValidation>();
builder.Services.AddTransient<AddGradeValidation>();

builder.Services.AddTransient<IAddGradeRepository, AddGradeRepository>();
builder.Services.AddTransient<ICalculateGpaRepository, CalculateGpaRepository>();
builder.Services.AddTransient<ICreateSubjectRepository, CreateSubjectRepository>();
builder.Services.AddTransient<IRegisterStudentRepository, RegisterStudentRepository>();
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
