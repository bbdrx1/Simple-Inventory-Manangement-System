using System;
using System.Collections.Generic;

// Class to represent a product
public class Product
{
    public int ProductId { get; set; }       // Unique identifier for the product
    public string Name { get; set; }         // Name of the product
    public int QuantityInStock { get; set; } // Quantity available in stock
    public decimal Price { get; set; }      // Price of the product

    public Product(int productId, string name, int quantityInStock, decimal price)
    {
        ProductId = productId;
        Name = name;
        QuantityInStock = quantityInStock;
        Price = price;
    }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {Name}, Quantity: {QuantityInStock}, Price: {Price:C}, Total Value: {Price * QuantityInStock:C}";
    }
}

// Class to manage the inventory
public class InventoryManager
{
    private List<Product> inventory; // List to store products

    public InventoryManager()
    {
        inventory = new List<Product>(); // Initialize the inventory list
    }

    // Property to get the count of products in the inventory
    public int InventoryCount => inventory.Count;

    public void AddProduct(Product product)
    {
        inventory.Add(product);
        Console.WriteLine($"Product {product.Name} added to the inventory.");
    }

    public void RemoveProduct(int productId)
    {
        // Check if inventory is empty
        if (inventory.Count == 0)
        {
            Console.WriteLine("Error: Inventory is empty. No products to remove.");
            return; // Exit the method without proceeding
        }

        // Proceed with the removal
        Product productToRemove = inventory.Find(p => p.ProductId == productId);
        if (productToRemove != null)
        {
            inventory.Remove(productToRemove);
            Console.WriteLine($"Product {productToRemove.Name} removed from the inventory.");
        }
        else
        {
            Console.WriteLine($"Error: Product with ID {productId} not found in the inventory.");
        }
    }

    public void UpdateProduct(int productId, int newQuantity)
    {
        // Check if inventory is empty
        if (inventory.Count == 0)
        {
            Console.WriteLine("Error: Inventory is empty. No products to update.");
            return; // Exit the method without proceeding
        }

        // Proceed with the update
        Product product = inventory.Find(p => p.ProductId == productId);
        if (product != null)
        {
            product.QuantityInStock = newQuantity;
            Console.WriteLine($"Product {product.Name} quantity updated to {newQuantity}.");
        }
        else
        {
            Console.WriteLine($"Error: Product with ID {productId} not found in the inventory.");
        }
    }

    public void ListProducts()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No products in the inventory.");
        }
        else
        {
            foreach (var product in inventory)
            {
                Console.WriteLine(product);
            }
        }
    }

    public decimal GetTotalValue()
    {
        decimal totalValue = 0;
        foreach (var product in inventory)
        {
            totalValue += product.Price * product.QuantityInStock;
        }
        return totalValue;
    }
}

class Program
{
    static void Main(string[] args)
    {
        InventoryManager inventoryManager = new InventoryManager();
        bool running = true;

        while (running)
        {
            Console.Clear(); 
            Console.WriteLine("Simple Inventory Management System");
            Console.WriteLine("");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Update Product Quantity");
            Console.WriteLine("4. List Products");
            Console.WriteLine("5. Get Total Inventory Value");
            Console.WriteLine("6. Exit");
            Console.WriteLine("");
            Console.Write("Please select an option:");

            string choice = Console.ReadLine();

            if (choice == "1")  // Add Product
            {
                Console.Clear();
                int addProductId = 0;
                while (true)
                {
                    Console.WriteLine("");
                    Console.Write("Enter Product ID:");
                    if (int.TryParse(Console.ReadLine(), out addProductId) && addProductId > 0)
                        break;
                    else
                        Console.WriteLine("Invalid Product ID. Product IDs must be positive integers.");
                }

                Console.Write("Enter Product Name:");
                string addProductName = Console.ReadLine();

                int addProductQuantity = 0;
                while (true)
                {
                    Console.Write("Enter Product Quantity:");
                    if (int.TryParse(Console.ReadLine(), out addProductQuantity) && addProductQuantity >= 0)
                        break;
                    else
                        Console.WriteLine("Invalid Quantity. Quantities must be non-negative integers.");
                }

                decimal addProductPrice = 0;
                while (true)
                {
                    Console.Write("Enter Product Price:");
                    if (decimal.TryParse(Console.ReadLine(), out addProductPrice) && addProductPrice >= 0)
                        break;
                    else
                        Console.WriteLine("Invalid Price. Prices must be non-negative real numbers.");
                }

                Product newProduct = new Product(addProductId, addProductName, addProductQuantity, addProductPrice);
                inventoryManager.AddProduct(newProduct);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (choice == "2")  // Remove Product
            {
                Console.Clear();
                if (inventoryManager.InventoryCount == 0) // Check if inventory is empty
                {
                    Console.WriteLine("");
                    Console.WriteLine("Error: Inventory is empty. Cannot remove products.");
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                }
                else
                {
                    inventoryManager.ListProducts();
                    int productId;
                    while (true)
                    {
                        Console.WriteLine("");
                        Console.Write("Enter Product ID to Remove: ");
                        if (int.TryParse(Console.ReadLine(), out productId) && productId > 0)
                            break;
                        else
                            Console.WriteLine("");
                            Console.WriteLine("Invalid Product ID. Please enter a positive integer.");
                    }
                    inventoryManager.RemoveProduct(productId);
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else if (choice == "3")  // Update Product Quantity
            {
                Console.Clear();
                if (inventoryManager.InventoryCount == 0) // Check if inventory is empty
                {
                    Console.WriteLine("");
                    Console.WriteLine("Error: Inventory is empty. Cannot update products.");
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                }
                else
                {
                    inventoryManager.ListProducts();
                    int productId;
                    while (true)
                    {
                        Console.WriteLine("");
                        Console.Write("Enter Product ID to Update: ");
                        if (int.TryParse(Console.ReadLine(), out productId) && productId > 0)
                            break;
                        else
                            Console.WriteLine("");
                            Console.WriteLine("Invalid Product ID. Please enter a positive integer.");
                    }

                    int newQuantity;
                    while (true)
                    {
                        Console.WriteLine("");
                        Console.Write("Enter New Quantity:");
                        if (int.TryParse(Console.ReadLine(), out newQuantity) && newQuantity >= 0)
                            break;
                        else
                            Console.WriteLine("");
                            Console.WriteLine("Invalid Quantity. Please enter a non-negative integer.");
                    }

                    inventoryManager.UpdateProduct(productId, newQuantity);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else if (choice == "4")  // List Products
            {
                Console.Clear();
                inventoryManager.ListProducts();
                Console.WriteLine("");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (choice == "5")  // Get Total Inventory Value
            {
                Console.Clear();
                decimal totalValue = inventoryManager.GetTotalValue();
                Console.WriteLine("");
                Console.WriteLine($"Total Value of Inventory: {totalValue:C}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (choice == "6")  // Exit
            {
                running = false;
                Console.Clear();
                Console.WriteLine("Exiting the Inventory System. Goodbye!");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Invalid option. Please try again.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
