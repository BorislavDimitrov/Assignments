namespace C__Basics_and_.NET_Basics.Reptiles
{
    public class Snake : Reptile
    {
        public Snake(string name, int age, int weight) 
            : base(name, age, weight)
        {
        }

        public override string MakeSound()
        {
            return "Sss";
        }
    }
}
