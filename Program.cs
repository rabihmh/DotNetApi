using DotNetApi.Data;
using DotNetApi.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace DotNetApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(builder =>builder.UseSqlServer("Server=RABIHMH\\SQL2022;User Id=sa;Password=12345678;Database=API;TrustServerCertificate=true"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<RateLimitingMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<ProfilingMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}
