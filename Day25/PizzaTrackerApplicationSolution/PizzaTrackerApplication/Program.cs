using Microsoft.EntityFrameworkCore;
using PizzaTrackerApi.Context;
using PizzaTrackerApi.Models;
using PizzaTrackerApplication.Interfaces;
using PizzaTrackerApplication.Models.Repositories;
using PizzaTrackerApplication.Services;

namespace PizzaTrackerApplication
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

            #region contexts
            builder.Services.AddDbContext<PizzaTrackerContext>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
               );
            #endregion

            #region repositories
            builder.Services.AddScoped<IRepository<int, Pizza>, PizzaRepository>();
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<IRepository<int, Order>, OrderRepository>();
            #endregion

            #region services
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPizzaService, PizzaService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
