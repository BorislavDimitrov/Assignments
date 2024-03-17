namespace C__Basics_and_.NET_Basics.Reptiles
{
    public class Snake : Reptile
    {
        public Snake(string name, int age, int weight, string gender) 
            : base(name, age, weight, gender)
        {
        }

        public override string MakeSound()
        {
            return "Sss";
        }

        public void ShedSkin()
        {
            Console.WriteLine("Snake is shedding its skin.");
        }

        public override void Move()
        {
            Console.WriteLine("The snake is either slithering or swimming.");
        }

        public override void Eat(string food)
        {
            Console.WriteLine($"The snake is eating {food}.");
        }
    }
}
