using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace BurgerBuilder
{
    internal class Menu
    {
        string[] possibleIngredients = { "cheese", "melted cheese", "pikles", "meat", "sauce" };
        public void creatingCustomBurger()
        {
            var burgerBuilder = new BurgerBuilder();
            var burger = burgerBuilder
                //default ingredients and start building
                .Start()
                .WithBun()
                .WithLettuce();
            //--------------------------------

            string? choise = "";
            for (int i = 0; i < possibleIngredients.Length; i++)
            {
                Console.WriteLine("Please choose ingredients. Enter yes / no");

                Console.WriteLine($"with {possibleIngredients[i]}");

                choise = Console.ReadLine();

                if (possibleIngredients[i] == "cheese" && choise == "yes")
                {
                    burger.WithCheese();
                }

                if (possibleIngredients[i] == "melted cheese" && choise == "yes")
                {
                    burger.withMeltedCheese();
                }

                if (possibleIngredients[i] == "pickles" && choise == "yes")
                {
                    burger.WithPickles();
                }

                if (possibleIngredients[i] == "meat" && choise == "yes")
                {
                    Console.WriteLine("Please choose meat (chicken, beef, no one)");
                    choise = Console.ReadLine();
                    if (choise == "chicken")
                    {
                        burger.WithChicken();
                    }
                    if (choise == "beef")
                    {
                        burger.WithBeef();
                    }
                    if (choise == "no one")
                    {
                        continue;
                    }
                }

                if (possibleIngredients[i] == "sauce" && choise == "yes")
                {
                    Console.WriteLine("Choose a sauce (spicy, sweet, branded, no one)");
                    choise = Console.ReadLine();

                    if (choise == "spicy")
                    {
                        burger.WithSpicySauce();
                    }
                    if (choise == "sweet")
                    {
                        burger.WithSweetSauce();
                    }
                    if (choise == "branded")
                    {
                        burger.WithBrandedSauce();
                    }
                    if (choise == "no one")
                    {
                        LogBurger(burger);
                    }
                    else if (i == possibleIngredients.Length - 1)
                    {

                        LogBurger(burger);
                    }
                }
            }
        }

        public void gettingPreparedBurger(BurgerBuilder burger)
        {
            do
            {
                Console.WriteLine("Please choose burger (cheeseburger, hamburger or branded)");
                string? choise = Console.ReadLine();
                if (choise == "cheeseburger")
                {
                    burger.Start()
                    .WithBun()
                    .withMeltedCheese()
                    .WithLettuce()
                    .WithPickles()
                    .WithSpicySauce();
                    LogBurger(burger);

                }
                else if (choise == "hamburger")
                {
                    burger.Start()
                    .WithBun()
                    .WithLettuce()
                    .WithPickles()
                    .WithBeef()
                    .WithSweetSauce();
                    LogBurger(burger);
                }
                else if (choise == "branded")
                {
                    burger.Start()
                    .WithBun()
                    .WithLettuce()
                    .WithPickles()
                    .WithChicken()
                    .WithBrandedSauce();
                    LogBurger(burger);
                }
                else 
                {
                    Console.WriteLine("your choise isn't correct. Please try again");
                }
            } while (true);
        }

        public void LogBurger(BurgerBuilder burger)
        {
            Console.WriteLine("============================================(0_-)");
            Console.WriteLine("Required combination is: ");
            burger.Build();
        }

        public void LogMenu(BurgerBuilder burger)
        {
            do
            {
                Console.WriteLine("Please choose order type (custom or prepared)");
                string? orderType = Console.ReadLine();
                if (orderType == "custom")
                {
                    creatingCustomBurger();
                }
                else if (orderType == "prepared")
                {
                    gettingPreparedBurger(burger);
                }
                else
                {
                    Console.WriteLine("Order type isn't correct. Please try again");
                }
            } while (true);
        }


    }
}
