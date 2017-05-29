using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace Refactoring_Shportyuk
{
    //Замена значения ссылкой
    class Customer
    {
        //Хранение  с помощью статического поля ( Предоставление доступа к экземплярам класса покупателя) Реестр, который содержит пул всех обьектов ссылок 
        //и получать нужные экземпляры из него (Позволит сделать несколько позиций в обьекте заказе)
        private static Hashtable instances = new Hashtable();

        public string Name
        {
            get;
            private set; //Запрет изменения имени покупателя, т.к. он создается заранее
        }

        private Customer(string name)
        {
            this.Name = name;
        }

        //Модифицируем чтобы он возвращал заранее созданного покупателя
        public static Customer GetByName(string name)
        {
            return (Customer)instances[name];
        }
        
        //Создаем покупателей заранее ( Загружаем тех клиентов, которые находятся в работе, можно брать из базы данных или файла)
        public static void LoadCustomers()
        {
            new Customer("Компания №1").Store();
            new Customer("Компания №2").Store();
            new Customer("Компания №3").Store();
        }
        private void Store()
        {
            instances.Add(this.Name, this);
        }

        //CustomerName убираем так как сеттер стал приватным и извне доступен только для чтения, убираем возможность его установки.
    

    // Пропала возможность динамически устанавливать покупателя для заказа по его имени (Добавим новый метод Order)
    public class Order
    {
        
        private Customer customer;

        public string CustomerName
        {
            get { return customer.Name; }
        }

        public Order(string customerName)
        {
            SetCustomer(customerName);
        }
        //Выделим код который уже используется в конструкторе заказа в новый метод
        public void SetCustomer(string customerName)
        {
            customer = Customer.GetByName(customerName);
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
