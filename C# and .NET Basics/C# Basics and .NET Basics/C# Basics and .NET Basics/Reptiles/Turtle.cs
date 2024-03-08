namespace C__Basics_and_.NET_Basics.Reptiles
{
    public class Turtle : Reptile
    {
        public Turtle(string name, int age, int weight)
            : base(name, age, weight)
        {
        }

        public override string MakeSound()
        {
            return "some turtle sound";
        }
    }
}
