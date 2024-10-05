using ERPAPI_APP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json");
var configuration = configurationBuilder.Build();
builder.Services.AddDbContext<ErpDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseDeveloperExceptionPage();

app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

app.MapControllers();

app.Use(async (context, next) =>
{
    // Do work that can write to the Response.
    await next.Invoke();
    Console.WriteLine("Request Date Time : "+ DateTime.Now.ToString("dd/MM/yyyy")+" \n\t\t: Request Type ["+ context.Request.Method +" ] Request Method [" 
        + context.Request.Path+ " ]");
    // Do logging or other work that doesn't write to the Response.
});

app.Run();
