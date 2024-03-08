namespace C__Basics_and_.NET_Basics
{
    public class Reptile : Animal
    {
        public Reptile(string name, int age, int weight) 
            : base(name, age, weight)
        {
        }

        public override string MakeSound()
        {
            return "some reptile sound";
        }
    }
}
