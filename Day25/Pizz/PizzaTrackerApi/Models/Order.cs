using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTrackerApi.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public bool IsPaid { get; set; }
        public float TotalPrice { get; set; }
        [ForeignKey("OrderedBy")]
        public int OrderedBy { get; set; }
        public ICollection<User> OrderedUser  { get; set; }

        public override string ToString()
        {
            return "Order Id : " + OrderId + " OrderedBy : " + OrderedBy + " TotalPrice : " + TotalPrice + " IsPaid : " + IsPaid;

        }
    }
}
