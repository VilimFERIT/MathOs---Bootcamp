using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1danbc_osnoveOOP
{
    public class Order : IOrder  
    {
        public Employee OrderCreator { get; set; }

        public Customer Customer { get; set; }

        public Guid OrderID   { get; set; }

        public int NumberOfShirtsOrdered { get; set; }

        public double FinalOrderPrice { get; set; }

        public bool OrderStatus { get; set; } = true;

        public DateTime EstimatedArrivalDate { get; set; }


        public void CheckOrderStatus ()
        {
            if (OrderStatus)
                Console.WriteLine("Order is active!");
            else
                Console.WriteLine("Order is inactive!");
        }
        public void ChangeOrderStatus ()
        {
            if (OrderStatus)
                OrderStatus = false;
            else
                OrderStatus = true;
        }

        public Order ()
        { }
        public Order (Employee employee, Customer customer, Guid orderID, int numberOfShirtsOrdered, double finalOrderPrice, bool orderStatus, DateTime estimatedArrivalDate)
        {
            employee = OrderCreator;
            customer = Customer;
            orderID = OrderID;
            numberOfShirtsOrdered = NumberOfShirtsOrdered;
            finalOrderPrice = FinalOrderPrice;
            orderStatus = OrderStatus;
            estimatedArrivalDate = EstimatedArrivalDate;
        }
    }
}
