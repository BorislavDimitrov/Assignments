namespace C__Basics_and_.NET_Basics.Reptiles
{
    public class Crocodile : Reptile
    {
        public Crocodile(string name, int age, int weight, string gender) 
            : base(name, age, weight, gender)
        {
        }

        public override string MakeSound()
        {
            return "Some crocodile sound";
        }

        public override void Move()
        {
            Console.WriteLine("The crocodile is either walking or swimming.");
        }

        public override void Eat(string food)
        {
            Console.WriteLine($"The crocodile is eating {food}.");
        }

        public void Hibernate()
        {
            Console.WriteLine("The crocodile is hibernating.");
        }
    }
}
