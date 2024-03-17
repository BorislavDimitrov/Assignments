namespace C__Basics_and_.NET_Basics.Mammals
{
    public class Mammal : Animal
    {
        protected Mammal(string name, int age, int weight, string gender)
            : base(name, age, weight, gender)
        {
        }

        public void GiveBirth()
        {
            Console.WriteLine($"{Name} (the mammal) is giving birth.");
        }

        public override string MakeSound()
        {
            return "Making some mammal sound...";
        }

        public override void Eat(string food)
        {
            Console.WriteLine($"Mammal is eating {food}.");
        }

        public override void Move()
        {
            Console.WriteLine("The mammal is moving.");
        }
    }
}
