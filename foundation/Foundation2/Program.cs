using System;
using System.Collections.Generic;

// Address class
class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    // Constructor for Address
    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    // Method to return the full address as a string
    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

// Customer class
class Customer
{
    private string name;
    private Address address;

    // Constructor for Customer
    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    // Method to check if the customer lives in the USA
    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }

    // Method to return the customer's name
    public string GetName()
    {
        return name;
    }

    // Method to return the customer's address
    public string GetAddress()
    {
        return address.GetFullAddress();
    }
}

// Product class
class Product
{
    private string name;
    private string id;
    private double price;
    private int quantity;

    // Constructor for Product
    public Product(string name, string id, double price, int quantity)
    {
        this.name = name;
        this.id = id;
        this.price = price;
        this.quantity = quantity;
    }

    // Method to calculate total cost of the product
    public double GetTotalCost()
    {
        return price * quantity;
    }

    // Method to get the product info for the packing label
    public string GetProductInfo()
    {
        return $"{name} (ID: {id})";
    }
}

// Order class
class Order
{
    private List<Product> productList;
    private Customer customer;

    // Constructor for Order
    public Order(Customer customer)
    {
        this.customer = customer;
        this.productList = new List<Product>();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        productList.Add(product);
    }

    // Method to calculate the total price of the order
    public double GetTotalPrice()
    {
        double totalCost = 0;

        // Add the cost of all products
        foreach (Product product in productList)
        {
            totalCost += product.GetTotalCost();
        }

        // Add shipping cost
        if (customer.LivesInUSA())
        {
            totalCost += 5; // Shipping for USA
        }
        else
        {
            totalCost += 35; // Shipping for outside USA
        }

        return totalCost;
    }

    // Method to get the packing label
    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (Product product in productList)
        {
            packingLabel += product.GetProductInfo() + "\n";
        }
        return packingLabel;
    }

    // Method to get the shipping label
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress()}";
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        // Create Address objects
        Address address1 = new Address("100 Oak St", "Dallas", "TX", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        // Create Customer objects
        Customer customer1 = new Customer("Alice Johnson", address1);
        Customer customer2 = new Customer("Bob Smith", address2);

        // Create Product objects
        Product product1 = new Product("Phone", "P001", 600.00, 1);
        Product product2 = new Product("Charger", "P002", 25.00, 2);
        Product product3 = new Product("Headphones", "P003", 100.00, 1);

        // Create Order 1 and add products
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // Create Order 2 and add products
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);

        // Display the details of Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.GetTotalPrice());
        Console.WriteLine();

        // Display the details of Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.GetTotalPrice());
    }
}
