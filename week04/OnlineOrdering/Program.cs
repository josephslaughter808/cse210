using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("1234 Elm Street", "Phoenix", "Arizona", "USA");
        Customer customer1 = new Customer("Emily Carter", address1);
        List<Product> products1 = new List<Product>();
        products1.Add(new Product("Wireless Mouse", "P100", 25.99, 2));
        products1.Add(new Product("Mechanical Keyboard", "P101", 89.50, 1));
        products1.Add(new Product("USB-C Cable", "P102", 9.99, 3));
        Order order1 = new Order(customer1, products1);

        Address address2 = new Address("77 King Street", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("Daniel Lee", address2);
        List<Product> products2 = new List<Product>();
        products2.Add(new Product("Notebook", "P200", 4.50, 5));
        products2.Add(new Product("Desk Lamp", "P201", 34.99, 1));
        products2.Add(new Product("Backpack", "P202", 54.95, 1));
        Order order2 = new Order(customer2, products2);

        DisplayOrder(order1);
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"Total Price: ${order.GetTotalCost():0.00}");
        Console.WriteLine();
    }
}
