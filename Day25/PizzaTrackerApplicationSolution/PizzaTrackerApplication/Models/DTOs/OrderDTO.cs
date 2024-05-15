using PizzaTrackerApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaTrackerApplication.Models.DTOs
{
    public class OrderDTO
    {
        public bool IsPaid { get; set; }
        public float TotalPrice { get; set; }

        public int UserId { get; set; }
       
        public int PizzaId { get; set; }

    }
}