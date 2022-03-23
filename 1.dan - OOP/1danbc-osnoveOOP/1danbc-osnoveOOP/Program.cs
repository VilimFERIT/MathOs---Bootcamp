using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1danbc_osnoveOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Order> firstBatchOfOrders = new List<Order>();


            for (int i = 0; i <= 3; i++)
            {
                if (firstBatchOfOrders.Count > 3)
                {
                    Console.WriteLine("Please create a new batch of orders!");
                }
                else
                {
                    Order newOrder = new Order();
                    // newOrder = Order(newOrder.order.FirstName=Console.ReadLine(),) ovdje moze i konstruktor
                    Customer exampleOfCustomer = new Customer();
                    Employee exampleOfEmployee = new Employee();

                    newOrder.OrderCreator = exampleOfEmployee;
                    newOrder.Customer = exampleOfCustomer;

                    Console.WriteLine("Please enter your first name\n");
                    exampleOfEmployee.FirstName = Console.ReadLine();

                    Console.WriteLine("Please enter your last name\n");
                    exampleOfEmployee.LastName = Console.ReadLine();

                    Console.WriteLine("Please enter the customers first name\n");
                    exampleOfCustomer.FirstName = Console.ReadLine();

                    Console.WriteLine("Please enter the customers last name\n");
                    exampleOfCustomer.LastName = Console.ReadLine();

                    Console.WriteLine("Please enter the amount of shirts you have ordered");

                    do
                    {
                        newOrder.NumberOfShirtsOrdered = Convert.ToInt32(Console.ReadLine());
                    } while (newOrder.NumberOfShirtsOrdered < 5);

                    newOrder.FinalOrderPrice = newOrder.NumberOfShirtsOrdered * 60;


                    newOrder.EstimatedArrivalDate = Convert.ToDateTime(Console.ReadLine());

                    firstBatchOfOrders.Add(newOrder);
                }

                int lengthOfList = firstBatchOfOrders.Count;


                Console.WriteLine("\n");
                Console.WriteLine($"The total price of the {i+1}. order is:");
                foreach (Order order in firstBatchOfOrders)
                {
                    Console.WriteLine(order.FinalOrderPrice);
                    Console.WriteLine("\n");
                }
            }
        }

        }
    }

