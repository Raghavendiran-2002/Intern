using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class UserDefinedException
    {
        public class CustomerBL 
        {
           public class NoCustomerIdFound : Exception
            {
                string msg;
                public NoCustomerIdFound()
                {
                    msg = "No Customer Id Found";
                }
                public override string Message => msg;
            }
            
        }
        public class NoCustomerWithGiveIdException : Exception
        {
            string message;
            public NoCustomerWithGiveIdException()
            {
                message = "Customer with the given Id is not present";
            }
            public override string Message => message;
        }
        public class NoProductWithGiveIdException : Exception
        {
            string message;
            public NoProductWithGiveIdException()
            {
                message = "Customer with the given Id is not present";
            }
            public override string Message => message;
        }
        public class NoCartItemWithGiveIdException : Exception
        {
            string message;
            public NoCartItemWithGiveIdException()
            {
                message = "Customer with the given Id is not present";
            }
            public override string Message => message;
        }
        public class NoCartWithGiveIdException : Exception
        {
            string message;
            public NoCartWithGiveIdException()
            {
                message = "Customer with the given Id is not present";
            }
            public override string Message => message;
        }
        public class PurchaseException : Exception
        {
            string message;
            public PurchaseException()
            {
                message = "Already Exist";
            }
            public PurchaseException(string msg)
            {
                message = msg;
            }
            public override string Message => message;
        }
   
    }
}
