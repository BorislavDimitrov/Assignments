namespace C__Basics_and_.NET_Basics.Mammals
{
    public class Dolphin : Mammal
    {
        protected Dolphin(string name, int age, int weight, string gender)
            : base(name, age, weight, gender)
        {
        }

        public override string MakeSound()
        {
            return "Some dolphin sound.";
        }

        public override void Move()
        {
            Console.WriteLine("The dolphin is swimming.");
        }

        public override void Eat(string food)
        {
            Console.WriteLine($"The dolphin is eating {food}.");
        }
    }
}
