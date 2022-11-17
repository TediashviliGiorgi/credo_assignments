using System.Reflection.Metadata.Ecma335;

namespace ProductManagment
{
    internal class Warhouse
    {
        public static List<Product> products = new List<Product>();

        //get, validate  and invoke methods----------------
        public static void invokeMethods()
        {
            do
            {
                Console.WriteLine("Pleasee choose options: addProduct, updateProduct, deleteProduct, logProducts");
                string? operation = Console.ReadLine();
                if (operation == "addProduct")
                {
                    Console.WriteLine("Please enter product name");
                    string? name = Console.ReadLine();
                    Console.WriteLine("Please enter product category");
                    string? category = Console.ReadLine();
                    Console.WriteLine("Please enter product price");
                    decimal price = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter product quantity");
                    double inStockQuantity = Convert.ToInt32(Console.ReadLine());
                    if (
                    Validate.validateName(name) == false ||
                        Validate.validateCategory(category) == false ||
                        Validate.validatePrice(price) == false ||
                        Validate.validateInStockQuantity(inStockQuantity) == false
                        )
                    {
                        Console.WriteLine("please enter product specifications correctly");
                        continue;
                    }
                    else
                    {
                        AddProduct(name, category, price, inStockQuantity);
                    }
                }
                else if (operation == "updateProduct")
                {
                    Console.WriteLine("Please enter target product name for updating");
                    string? name = Console.ReadLine();
                    Console.WriteLine("Please enter field for updating (category, price, quantity)");

                    Console.WriteLine($"Update {name} category");
                    string? category = Console.ReadLine();
                    Console.WriteLine($"Update {name} price");
                    decimal price = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Update {name} quantity");
                    double inStockQuantity = Convert.ToInt32(Console.ReadLine());
                    UpdateProduct(name, category, price, inStockQuantity);
                }
                else if (operation == "deleteProduct")
                {
                    Console.WriteLine("Please enter target product name for deleting");
                    string? name = Console.ReadLine();
                    DeleteProduct(name);
                }
                else if (operation == "logProducts")
                {
                    LogProducts();
                }
            } while (true);
        }
        //---------------------------------------------

        // actions ------------------------------------
        static void AddProduct(string name, string category, decimal price, double inStockQuantity)
        {
            var product = products.FirstOrDefault(e => e.Name == name);
            if (product!= null)
            {
                Console.WriteLine("Product with this name already exsists: Please choose anther name");
                return;
            }
            products.Add(new Product(name, category, price, inStockQuantity));
            Console.WriteLine("Product successfully added...");
        }

        static void UpdateProduct(string? name, string category, decimal price, double inStockQuantity)
        {
            var product = products.FirstOrDefault(e => e.Name == name);
            if (product == null)
            {
                Console.WriteLine("There is no such product! Please enter the name correctly for updating product.");
                return;
            }
            else
            {
                product.Category = category;
                product.Price = price;
                product.InStockQuantity = inStockQuantity;
                Console.WriteLine("Product updated succesfully");
            }
        }

        static void DeleteProduct(string? name)
        {
            var product = products.FirstOrDefault(e => e.Name == name);
            if (product == null)
            {
                Console.WriteLine("Product not found");
                return;
            }

            products.Remove(product);
            Console.WriteLine("Product deleted successfully");
        }

        static void LogProducts()
        {
            for (int i = 0; i < products.Count(); i++)
            {
                Console.WriteLine($"---------product{i + 1}--------");
                Console.WriteLine($"Product name: {products[i].Name}");
                Console.WriteLine($"Product category: {products[i].Category}");
                Console.WriteLine($"Product price: {products[i].Price}");
                Console.WriteLine($"In stock: {products[i].InStockQuantity}");
                if (products[i].InStockQuantity == 0)
                {
                    Console.WriteLine($"ar arnis maragshi");
                }
                Console.WriteLine("--------------------------------");
            }
        }
        //------------------------------------------------
        static void Main(string[] args)
        {
            invokeMethods();
        }
    }
}