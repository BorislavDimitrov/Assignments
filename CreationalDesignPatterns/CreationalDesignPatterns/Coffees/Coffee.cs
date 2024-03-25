namespace CreationalDesignPatterns.Coffees
{
    public abstract class Coffee
    {
        protected Milk? _milkType;
        protected int _coffeeGrams;
        protected int _milkMilliliters;
        protected int _sugarGrams;

        protected Coffee(int coffeeGrams)
        {
            _coffeeGrams = coffeeGrams;
        }

        public Coffee(int coffeeGrams, int milkMilliliters, Milk milkType)
            : this(coffeeGrams)
        {
            _milkMilliliters = milkMilliliters;
            _milkType = milkType;
        }

        public int CoffeeGrams => _coffeeGrams;
        public int MilkMilliliters => _milkMilliliters;
        public int SugarGrams => _sugarGrams;
        public Milk? MilkType => _milkType;

        public void addCoffee(int coffeeGrams)
        {
            if (coffeeGrams <= 0)
            {
                throw new ArgumentException("The coffee grams must be more than 0.");
            }

            _coffeeGrams += coffeeGrams;
        }

        public void addMilk(int milkMilliliters, Milk milkType = Milk.Regular)
        {
            if (_milkType == null)
            {
                _milkType = milkType;
            }

            if (_milkType != milkType)
            {
                throw new InvalidOperationException("Already used different kind of milk.");
            }

            if (milkMilliliters <= 0)
            {
                throw new ArgumentException("The milk milliliters must be more than 0.");
            }

            _milkMilliliters += milkMilliliters;
        }

        public void addSugar(int sugarGrams)
        {
            if (sugarGrams <= 0)
            {
                throw new ArgumentException("The sugar grams must be more than 0.");
            }

            _sugarGrams += sugarGrams;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} has coffee grams: {_coffeeGrams}, milk type: {(_milkType == null ? "none" : _milkType)}, milk milliliters: {(_milkMilliliters == 0 ? "none" : _milkMilliliters)}, sugar grams: {_sugarGrams}.";
        }
    }
}
