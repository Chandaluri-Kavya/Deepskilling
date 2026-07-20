using RetailInventory.Data;
using RetailInventory.Models;

using var context = new AppDbContext();

// Create a category
var category = new Category
{
    Name = "Electronics"
};

context.Categories.Add(category);
context.SaveChanges();

// Create a product
var product = new Product
{
    Name = "Laptop",
    Price = 50000,
    CategoryId = category.Id
};

context.Products.Add(product);
context.SaveChanges();

Console.WriteLine("Category and Product added successfully.");