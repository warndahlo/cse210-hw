using System;
using System.Collections.Generic;

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public string GetAddress()
    {
        return address.GetFullAddress();
    }
}

class Product
{
    private string name;
    private string productId;
    private double pricePerUnit;
    private int quantity;

    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.pricePerUnit = pricePerUnit;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return pricePerUnit * quantity;
    }

    public string GetPackingLabel()
    {
        return $"{name} (ID: {productId})";
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }
        total += customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"- {product.GetPackingLabel()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress()}";
    }
}

class Program
{
    static void Main()
    {
        Customer customer1 = new Customer("John Doe", new Address("123 Main St", "New York", "NY", "USA"));
        Customer customer2 = new Customer("Alice Smith", new Address("456 Maple Ave", "Toronto", "ON", "Canada"));

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LAP123", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "MOU456", 25.50, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Headphones", "HEA789", 75.99, 1));
        order2.AddProduct(new Product("Keyboard", "KEY101", 45.75, 1));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():F2}\n");
            Console.WriteLine("-----------------------------\n");
        }
    }
}
