Product[] products =
{
    new Product(101, "Laptop", "Electronics"),
    new Product(102, "Mobile", "Electronics"),
    new Product(103, "Keyboard", "Accessories"),
    new Product(104, "Mouse", "Accessories"),
    new Product(105, "Monitor", "Electronics")
};

Console.WriteLine("Linear Search:");

Product? result = SearchService.LinearSearch(products, 103);

if (result != null)
{
    Console.WriteLine($"ID: {result.ProductId}");
    Console.WriteLine($"Name: {result.ProductName}");
    Console.WriteLine($"Category: {result.Category}");
}
else
{
    Console.WriteLine("Product not found");
}

Console.WriteLine();

Console.WriteLine("Binary Search:");

result = SearchService.BinarySearch(products, 103);

if (result != null)
{
    Console.WriteLine($"ID: {result.ProductId}");
    Console.WriteLine($"Name: {result.ProductName}");
    Console.WriteLine($"Category: {result.Category}");
}
else
{
    Console.WriteLine("Product not found");
}