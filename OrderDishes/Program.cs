﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OrderDishes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();

            customer.Order += waiter.Action;

            customer.Action();
        }
    }

    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }


    public class Customer
    {
        public event EventHandler Order;
        public double Bill { get; set; }

        public void PayBill()
        {
            System.Console.WriteLine("I will pay {0} dollars!", this.Bill);
        }

        internal void Action()
        {
            System.Console.WriteLine("It's action!");
            Thread.Sleep(1000);

            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "Water";
                e.Size = "large";
                Order(this, e);
                PayBill();
                System.Console.ReadLine();
            }
        }
    }

    public class Waiter 
    {

        public void Action(object c, EventArgs e)
        {
            Customer customer  = c as Customer;
            OrderEventArgs einfo = e as OrderEventArgs;

            double bill = 10;
            Console.WriteLine("Dish is {0}, Size is {1}.", einfo.DishName, einfo.Size);
            switch (einfo.Size)
            {
                case "large":
                    bill *= 1.5;
                    break;
                case "small":
                    bill *= 0.5;
                    break;
                default: break;
            }
            customer.Bill += bill;
        }

    }
}
