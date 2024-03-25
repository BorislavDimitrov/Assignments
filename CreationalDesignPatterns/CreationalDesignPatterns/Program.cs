using CreationalDesignPatterns;
var coffeeMachine = new CoffeeMachine();

var espesso = coffeeMachine.MakeCoffee(CoffeeType.Espresso);
Console.WriteLine(espesso.ToString());

Customiztion customization = new Customiztion();
customization.CoffeeGrams = 4;
customization.MilkMilliliters = 50;
customization.MilkType = Milk.Oat;
customization.SugarGrams = 6;
var espresso2 = coffeeMachine.MakeCoffee(CoffeeType.Espresso, custom: customization);
Console.WriteLine(espresso2.ToString());

Customiztion customization2 = new Customiztion();
customization2.SugarGrams = 8;
var espresso3 = coffeeMachine.MakeCoffee(CoffeeType.Espresso, custom: customization2);
Console.WriteLine(espresso3.ToString());

Customiztion customization3 = new Customiztion();
customization3.CoffeeGrams = 4;
customization3.MilkMilliliters = 60;
customization3.MilkType = Milk.Oat;
customization3.SugarGrams = 6;
var espresso4 = coffeeMachine.MakeCoffee(CoffeeType.Espresso, custom: customization3);
Console.WriteLine(espresso4.ToString());

Customiztion customization4 = new Customiztion();
customization4.SugarGrams = 3;
var cappuccino = coffeeMachine.MakeCoffee(CoffeeType.Cappuccino, Milk.Soy, customization4);
Console.WriteLine(cappuccino);

Customiztion customization5 = new Customiztion();
customization5.SugarGrams = 3;
customization5.CoffeeGrams = 4;
customization5.MilkMilliliters = 50;
var cappuccino2 = coffeeMachine.MakeCoffee(CoffeeType.Cappuccino, custom: customization5);
Console.WriteLine(cappuccino2);

Customiztion customization6 = new Customiztion();
customization6.SugarGrams = 3;
customization6.CoffeeGrams = 4;
customization6.MilkMilliliters = 50;
var flatWhite = coffeeMachine.MakeCoffee(CoffeeType.FlatWhite, custom: customization6);
Console.WriteLine(flatWhite);

Customiztion customization7 = new Customiztion();
customization7.SugarGrams = 3;
customization7.CoffeeGrams = 4;
customization7.MilkMilliliters = 50;
customization7.MilkType = Milk.Oat; //This will cause exception
var flatWhite2 = coffeeMachine.MakeCoffee(CoffeeType.FlatWhite, custom: customization7);
Console.WriteLine(flatWhite);
