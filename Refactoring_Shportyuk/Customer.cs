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
        private static Dictionary<string, Customer> instances = new Dictionary<string, Customer>();

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
            return instances[name];
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
        

        void PrintOwing()
        {
            PrintBanner();// заменяем код вызовом метода
            double amount = GetAmount();
            string customer = "Покупатель 1";
            PrintDetails(amount,customer);
        }

        //Извлекаем печать итогов в отдельный метод
        void PrintBanner()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("*** Итоги заказов клиента ***");
            Console.WriteLine("*****************************");
        }

        //Извлекаем метод вывода деталей, делаем значения передаваемыми параметрами
        void PrintDetails(double Amount,string customer)
        {
            Console.WriteLine("Имя покупателя: " + customer);
            Console.WriteLine("Количество заказов: " + Amount);
        }

        double GetAmount()
        {
            List<Order> orders = new List<Order>();
            double Amount = 0.0;
            string customer = "Покупатель 1";

            foreach (Order order in orders)
            {
                Amount += NumberOfOrdersFor(orders, customer);
            }

            return Amount;
        }

        // Разбиение условного оператора 
        //(Вычисление стоимости входного билета)
        public double summerRate; 
        public double winterRate;
        DateTime SUMMER_START = new DateTime(2017, 6, 1);
        DateTime SUMMER_END = new DateTime(2017, 8, 31);
        public double GetTicketPrice(DateTime date, int quantity)
        {
            double charge;

            if (NotSummer(date)) //заменяем вызовом метода
            {
                charge = WinterCharge(quantity);//заменяем вызовом метода
            }
            else
            {
                charge = SummerCharge(quantity);
            }

            return charge;
        }

        // Выделяем условие в метод с очевидным названием
        private bool NotSummer(DateTime date)
        {
            return date < SUMMER_START || date > SUMMER_END;
        }
        // Выделяем условие в метод с очевидным названием
        private double WinterCharge(int quantity)
        {
            return quantity * winterRate;
        }
        // Выделяем условие в метод с очевидным названием
        private double SummerCharge(int quantity)
        {
            return quantity * summerRate;
        }
    }


}

