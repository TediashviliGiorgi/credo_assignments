namespace ProductManagment
{
    internal class Product
    {
        public string? Name;
        public string? Category;
        public decimal Price;
        public double InStockQuantity;

        public Product(string? name, string? categorry, decimal price, double inStockCuantity)
        {
            Name = name;
            Category = categorry;
            Price = price;
            InStockQuantity = inStockCuantity;
        }
    }
}
