using RetailInventory.Data;

using var context = new AppDbContext();

var product = context.Products.FirstOrDefault();

if (product != null)
{
    context.Products.Remove(product);
    context.SaveChanges();

    Console.WriteLine("Product deleted successfully.");
}
else
{
    Console.WriteLine("No product found.");
}