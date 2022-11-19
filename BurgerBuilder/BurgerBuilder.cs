
namespace BurgerBuilder
{
    public class BurgerBuilder
    {

        private Burger _burger;

        public BurgerBuilder Start()
        {
            _burger = new Burger();
            return this;
        }

        public BurgerBuilder WithBun()
        {
            _burger.Ingredients.Add("Bun");
            return this;
        }

        public BurgerBuilder WithLettuce()
        {
            _burger.Ingredients.Add("Lettuce");
            return this;
        }

        public BurgerBuilder withMeltedCheese()
        {
            _burger.Ingredients.Add("Melted Cheese");
            return this;
        }

        public BurgerBuilder WithCheese()
        {
            _burger.Ingredients.Add("Cheese");
            return this;
        }

        public BurgerBuilder WithPickles()
        {
            _burger.Ingredients.Add("Pickles");
            return this;
        }

        public BurgerBuilder WithBeef()
        {
            _burger.Ingredients.Add("Beef");
            return this;
        }

        public BurgerBuilder WithChicken()
        {
            _burger.Ingredients.Add("Chicken");
            return this;
        }
        //-----------------------------------------------
        public BurgerBuilder WithSpicySauce()
        {
            _burger.Ingredients.Add("spicy sauce");
            return this;
        }

        public BurgerBuilder WithSweetSauce()
        {
            _burger.Ingredients.Add("sweetSauce");
            return this;
        }

        public BurgerBuilder WithBrandedSauce()
        {
            _burger.Ingredients.Add("branded sauce");
            return this;
        }

        public Burger Build()
        {
            foreach(var item in _burger.Ingredients)
            {
                Console.WriteLine(item);
            }
            return _burger;
        }
    }
}

