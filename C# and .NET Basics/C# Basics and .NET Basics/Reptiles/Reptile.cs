namespace C__Basics_and_.NET_Basics.Reptiles
{
    public class Reptile : Animal
    {
        public Reptile(string name, int age, int weight, string gender)
            : base(name, age, weight, gender)
        {
        }

        public void LayEggs()
        {
            Console.WriteLine($"{Name} (the reptile) is laying some eggs.");
        }

        public void LayEggs(int numberOfEggs)
        {
            Console.WriteLine($"{Name} (the reptile) is laying {numberOfEggs} eggs.");
        }

        public override string MakeSound()
        {
            return "Making some reptile sound...";
        }

        public override void Eat(string food)
        {
            Console.WriteLine($"Reptile is eating {food}.");
        }

        public override void Move()
        {
            Console.WriteLine("The reptile is moving.");
        }
    }
}
