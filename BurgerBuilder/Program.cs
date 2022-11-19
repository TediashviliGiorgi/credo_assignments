namespace BurgerBuilder
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            var burgerBuilder = new BurgerBuilder();
            var burger = burgerBuilder;

            var menu = new Menu();
            menu.LogMenu(burger);
        }
    }
}
