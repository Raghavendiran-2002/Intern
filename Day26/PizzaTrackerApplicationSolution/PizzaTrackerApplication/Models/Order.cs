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
        public int UserId { get; set; }

        public int PizzaId { get; set; }

        public DateTime OrderedDate { get; set; }
   

        [ForeignKey("UserId")]
        public User? User { get; set; }
        

        [ForeignKey("PizzaId")]
  
        public  Pizza Pizza { get; set; }

        public override string ToString()
        {
            return "Order Id : " + OrderId + " User Id : " + UserId+  " Pizza Ordered : " + PizzaId + " IsPaid : " + IsPaid ;

        }
    }
}
