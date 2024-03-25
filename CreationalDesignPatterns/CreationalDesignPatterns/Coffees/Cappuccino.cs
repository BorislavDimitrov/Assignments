namespace CreationalDesignPatterns.Coffees
{
    public class Cappuccino : Coffee
    {
        public Cappuccino(int coffeeGrams, int milkMilliliters, Milk milkType = Milk.Regular)
            :base(coffeeGrams ,milkMilliliters, milkType)
        {
        }
    }
}
