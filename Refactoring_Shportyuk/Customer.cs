using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring_Shportyuk
{
    //Замена значения ссылкой
    class Customer
    {

        public string Name
        {
            get;
            set;
        }

        public Customer(string name)
        {
            this.Name = name;
        }


        public class Order
        {
            private Customer customer;

            public string CustomerName
            {
                get { return customer.Name; }
                set { customer.Name = value; }
            }

            public Order(string customerName)
            {
                this.customer = new Customer(customerName);
            }
        }


        private static int NumberOfOrdersFor(List<Order> orders, string customer)
        {
            int result = 0;

            if (orders != null)
            {
                foreach (Order order in orders)
                {
                    if (string.Equals(order.CustomerName, customer))
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        //Извлечение метода
        void PrintOrders(string customer)
        {
            List<Order> orders = new List<Order>();
            double Amount = 0.0;

            // Баннер 
            Console.WriteLine("*****************************");
            Console.WriteLine("*** Итоги заказов клиента ***");
            Console.WriteLine("*****************************");

          
            foreach (Order order in orders)
            {
                Amount += NumberOfOrdersFor(orders, customer);
            }

            
            Console.WriteLine("Имя покупателя: " + customer);
            Console.WriteLine("Количество заказов: " + Amount);
        }


        // Разбиение условного оператора 

        public double summerRate; 
        public double winterRate;
        DateTime SUMMER_START = new DateTime(2017, 6, 1);
        DateTime SUMMER_END = new DateTime(2017, 8, 31);
        public double GetTicketPrice(DateTime date, int quantity) 
        {
            double value;

            if (date < SUMMER_START || date > SUMMER_END)
            {
                value = quantity * winterRate;
            }
            else
            {
                value = quantity * summerRate;
            }

            return value;
        }


    }
}
