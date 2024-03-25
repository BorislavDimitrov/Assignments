using CreationalDesignPatterns.Coffees;

namespace CreationalDesignPatterns
{
    public class CoffeeMachine
    {
        public Coffee MakeCoffee(CoffeeType coffeeType, Milk milkType = Milk.Regular, Customiztion? custom = null)
        {
            switch (coffeeType)
            {
                case CoffeeType.Espresso:
                    Espresso newEspresso = new Espresso(Constants.DefaultCoffeeGrams);
                    ApplyCustomAdds(newEspresso, custom);
                    return newEspresso;
                case CoffeeType.Cappuccino:
                    Cappuccino newCappucino = new Cappuccino(Constants.DefaultCoffeeGrams, Constants.DefaultMilkMilliliters, milkType);
                    ApplyCustomAdds(newCappucino, custom);
                    return newCappucino;
                case CoffeeType.FlatWhite:
                    FlatWhite newFlatWhite = new FlatWhite(Constants.DefaultCoffeeGrams * 2, Constants.DefaultMilkMilliliters, milkType);
                    ApplyCustomAdds(newFlatWhite, custom);
                    return newFlatWhite;
                default:
                    throw new InvalidOperationException("Coffee type not supported");
            }
        }

        private void ApplyCustomAdds(Coffee coffeeDrink, Customiztion? custom)
        {
            if (custom == null)
                return;

            if (custom.CoffeeGrams > 0)
                coffeeDrink.addCoffee(custom.CoffeeGrams);

            if (custom.MilkMilliliters > 0)
            {
                if (custom.MilkType == null)
                {
                    coffeeDrink.addMilk(custom.MilkMilliliters);
                }
                else
                {
                    coffeeDrink.addMilk(custom.MilkMilliliters, (Milk)custom.MilkType);
                }
            }

            if (custom.SugarGrams > 0)
                coffeeDrink.addSugar(custom.SugarGrams);
        }
    }
}
