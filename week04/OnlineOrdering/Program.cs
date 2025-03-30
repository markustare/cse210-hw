using System;

class Program
{
    static void Main()
    {
        Address addr1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Customer cust1 = new Customer("John Doe", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "L123", 800, 1));
        order1.AddProduct(new Product("Mouse", "M456", 20, 2));

        Address addr2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer cust2 = new Customer("Jane Smith", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Tablet", "T789", 300, 1));
        order2.AddProduct(new Product("Headphones", "H101", 50, 1));

        List<Order> orders = new List<Order> { order1, order2 };
        
        foreach (var order in orders)
        {
            Console.WriteLine("--- Order Summary ---");
            Console.WriteLine("Packing Label:\n" + order.GetPackingLabel());
            Console.WriteLine("Shipping Label:\n" + order.GetShippingLabel());
            Console.WriteLine("Total Cost: $" + order.CalculateTotalCost());
            Console.WriteLine();
        }
    }
}
