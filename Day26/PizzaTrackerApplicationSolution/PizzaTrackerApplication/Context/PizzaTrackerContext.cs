using Microsoft.EntityFrameworkCore;
using PizzaTrackerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTrackerApi.Context
{
    public class PizzaTrackerContext : DbContext
    {
        public PizzaTrackerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
    
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User() { UserId = 101, Username = "Ramu", Password = Encoding.UTF8.GetBytes("ramu123") });
            modelBuilder.Entity<Pizza>().HasData(new Pizza() { PizzaId = 101, Name = "Dominos", Price = 250, StocksQuantity = 2 }, new Pizza() { PizzaId = 102, Name = "PizzaHut", Price = 150, StocksQuantity = 4 }, new Pizza() { PizzaId = 103,Name = "Taco Bell", Price = 50, StocksQuantity = 0 });           
        }
    }
}
