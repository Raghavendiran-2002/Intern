using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTrackerApi.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }
        public int StocksQuantity { get; set; }

        public override string ToString()
        {
            return "Pizza Id : " + Id + " Name : " + Name + " Price : " + Price + " StocksQuantity : " + StocksQuantity;
        }
    }
}
