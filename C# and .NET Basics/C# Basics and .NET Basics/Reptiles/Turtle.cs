namespace C__Basics_and_.NET_Basics.Reptiles
{
    public class Turtle : Reptile
    {
        public Turtle(string name, int age, int weight, string gender)
            : base(name, age, weight, gender)
        {
        }

        public override string MakeSound()
        {
            return "Some turtle sound";
        }

        public override void Move()
        {
            Console.WriteLine("The turle is either walking or swimming.");
        }

        public override void Eat(string food)
        {
            Console.WriteLine($"The turtle is eating {food}.");
        }
    }
}
