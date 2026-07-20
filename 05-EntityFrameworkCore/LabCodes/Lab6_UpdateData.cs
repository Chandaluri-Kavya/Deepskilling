using RetailInventory.Data;

using var context = new AppDbContext();

var product = context.Products.FirstOrDefault();

if (product != null)
{
    product.Price = 55000;
    context.SaveChanges();

    Console.WriteLine("Product price updated successfully.");
}
else
{
    Console.WriteLine("No product found.");
}