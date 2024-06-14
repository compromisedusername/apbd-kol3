using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseSqlServer("Name=ConnectionStrings:Default") // Added DbContext
);
builder.Services.AddControllers();  // Added Controllers

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>(); // Added Middleware

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapControllers(); // Map Controllers
app.Run();
