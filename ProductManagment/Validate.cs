namespace ProductManagment
{
    internal class Validate
    {
        public static bool validateOperation(string operation)
        {

            if (operation != "addProduct"
                || operation != "updateProduct"
                || operation != "deleteProduct"
                || operation != "logProducts")
            {
                Console.WriteLine("Choose operation correctly");
                return false;
            }
            else
            {
                return true;
            }

        }
        public static bool validateName(string? name)
        {
            if (name == null || name == "")
            {
                return false;
            }
            else if (name.Length > 50)
            {
                return false;
            }
            else
            {
                return true;
            };
        }

        public static bool validateCategory(string? category)
        {
            if (category == "foods" || category == "technics" || category == "books")
            {
                return true;
            }
            return false;
        }

        public static bool validatePrice(decimal price)
        {
            if (price <= 0)
            {
                return false;
            }
            return true;
        }

        public static bool validateInStockQuantity(double inStockQuantity)
        {
            if (inStockQuantity < 0)
            {
                return false;
            }

            return true;
        }
    }
}
