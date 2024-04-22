using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingModelLibrary
{
    public class Payment
    {
        public required string BookingReference { get; set; }    
        public required string PaymentId { get; set; }
        public required bool IsPaid { get; set; }

        public Payment(string bookingReference,string paymentId, bool isPaid) {
            BookingReference = bookingReference;
            IsPaid = isPaid;
            PaymentId = paymentId;
        }
    }
}
