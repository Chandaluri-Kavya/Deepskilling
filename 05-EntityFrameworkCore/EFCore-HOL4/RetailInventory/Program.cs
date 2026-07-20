using RetailInventory.Data;
using RetailInventory.Models;

using var context = new AppDbContext();

// INSERT
var category = new Category
{
    Name = "Electronics"
};

context.Categories.Add(category);
context.SaveChanges();

var product = new Product
{
    Name = "Laptop",
    Price = 65000,
    CategoryId = category.Id
};

context.Products.Add(product);
context.SaveChanges();

Console.WriteLine("Product inserted successfully.");


// RETRIEVE
var products = context.Products.ToList();

Console.WriteLine("\nProducts:");

foreach (var p in products)
{
    Console.WriteLine($"ID: {p.Id}");
    Console.WriteLine($"Name: {p.Name}");
    Console.WriteLine($"Price: {p.Price}");
    Console.WriteLine("--------------------");
}