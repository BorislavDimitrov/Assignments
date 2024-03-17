namespace C__Basics_and_.NET_Basics.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, int age, int weight, string gender) 
            : base(name, age, weight, gender)
        {
        }

        public override string MakeSound()
        {
            return "Woof woof";
        }

        public override void Move()
        {
            Console.WriteLine("The dog is walking.");
        }

        public override void Eat(string food)
        {
            Console.WriteLine($"The dog is eating {food}.");
        }
    }
}
