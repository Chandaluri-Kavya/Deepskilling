using RetailInventory.Data;
using RetailInventory.Models;

using var context = new AppDbContext();

// Create Category
var category = new Category
{
    Name = "Electronics"
};

context.Categories.Add(category);
context.SaveChanges();

// Create Product
var product = new Product
{
    Name = "Laptop",
    Price = 75000,
    CategoryId = category.Id
};

context.Products.Add(product);
context.SaveChanges();

Console.WriteLine("Category and Product inserted successfully.");