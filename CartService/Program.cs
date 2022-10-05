using CartApp.Data;
using CartApp.Extensions;
using Microsoft.EntityFrameworkCore;
using System;

namespace CartApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //Data Context
            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));



            //Bring in Automapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.AddRequiredServices();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
                       

            var app = builder.Build();

            using (var servicescope = app.Services.CreateScope())
            {
                var services = servicescope.ServiceProvider;
                var _context = services.GetRequiredService<DatabaseContext>();

                _context.Database.EnsureCreated();
            }

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
        }
    }
}