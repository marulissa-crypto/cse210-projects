using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Order 1: Domestic (USA) customer with 3 products
        Address usaAddress = new Address(
            "742 Evergreen Terrace",
            "Springfield",
            "IL",
            "USA"
        );
        Customer usaCustomer = new Customer("Jordan Taylor", usaAddress);

        List<Product> order1Products = new List<Product>
        {
            new Product("Wireless Mechanical Keyboard", "KB-104", 79.99, 1),
            new Product("Ergonomic Vertical Mouse", "MS-208", 34.50, 2),
            new Product("USB-C Hub Adapter", "HB-312", 24.00, 1)
        };

        Order order1 = new Order(usaCustomer, order1Products);

        // Order 2: International customer with 2 products
        Address intlAddress = new Address(
            "221B Baker Street",
            "London",
            "Greater London",
            "United Kingdom"
        );
        Customer intlCustomer = new Customer("Clara Bennett", intlAddress);

        List<Product> order2Products = new List<Product>
        {
            new Product("Noise-Canceling Headphones", "HP-501", 149.00, 1),
            new Product("Braided Charging Cable", "CB-019", 12.50, 3)
        };

        Order order2 = new Order(intlCustomer, order2Products);

        List<Order> orders = new List<Order> { order1, order2 };

        for (int i = 0; i < orders.Count; i++)
        {
            Console.WriteLine($"==================== ORDER #{i + 1} ====================");
            Console.WriteLine(orders[i].GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(orders[i].GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Price (incl. shipping): ${orders[i].GetTotalCost():F2}");
            Console.WriteLine();
        }
    }
}