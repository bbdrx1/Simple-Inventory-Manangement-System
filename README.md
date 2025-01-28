# Simple Inventory Management System

This is a simple inventory management system developed in C# that allows you to manage a list of products, including adding, removing, updating quantities, and calculating the total inventory value. It is designed for small-scale inventory management and helps you keep track of your products, their quantities, and prices.

## Features

- **Add Products**: Allows the user to add new products to the inventory by specifying a product ID, name, quantity, and price.
- **Remove Products**: Removes products from the inventory by specifying their product ID.
- **Update Product Quantity**: Allows updating the quantity of an existing product.
- **List Products**: Displays a list of all products currently in the inventory.
- **Calculate Total Inventory Value**: Calculates and displays the total value of all products in the inventory (based on quantity and price).
- **Error Handling**: Provides error messages for invalid operations, such as removing or updating a non-existent product.

## Constraints

- **Product ID**: The product ID must be a positive integer. It serves as the unique identifier for each product in the inventory. If a non-positive integer is entered, the system will prompt the user to re-enter a valid ID.
- **Quantity**: The quantity of a product must be a non-negative integer (0 or greater). Negative quantities are not allowed. When updating a product’s quantity, the user must enter a valid non-negative integer.
- **Price**: The price of a product must be a non-negative decimal number (0 or greater). Prices must be real numbers, and the system will reject invalid price inputs.
- **Inventory Capacity**: The system does not impose a specific limit on the number of products in the inventory. However, the performance of the program may degrade as the inventory size grows significantly, depending on the system’s memory and processing capabilities.
- **Product Uniqueness**: Each product must have a unique ID. The system does not currently handle duplicate product IDs. If a user tries to add a product with an existing ID, the program will not handle the conflict explicitly (this could be improved in future versions).
- **Removal and Update Restrictions**: The system will prevent removing or updating products that do not exist in the inventory. If a non-existent product ID is entered, the system will display an error message.

## Requirements

- .NET Framework 4.7.2 or later
- C# programming knowledge (to understand and modify the code)

## Usage

1. Clone or download this repository to your local machine.
2. Open the project in Visual Studio or another C# development environment.
3. Compile and run the project.
4. The system will prompt you to choose from a menu with the following options:
   - Add a new product to the inventory
   - Remove an existing product from the inventory
   - Update the quantity of an existing product
   - List all products in the inventory
   - Calculate the total value of the inventory
   - Exit the program

## Example Usage

Upon running the program, you will see the following options displayed in the console:

