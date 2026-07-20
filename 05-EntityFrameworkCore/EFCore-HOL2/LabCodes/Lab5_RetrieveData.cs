using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

using var context = new AppDbContext();

var products = context.Products
    .Include(p => p.Category)
    .ToList();

foreach (var product in products)
{
    Console.WriteLine($"Product: {product.Name}");
    Console.WriteLine($"Price: {product.Price}");
    Console.WriteLine($"Category: {product.Category.Name}");
    Console.WriteLine();
}