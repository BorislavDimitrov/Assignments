namespace C__Basics_and_.NET_Basics
{
    public class Mammal : Animal
    {
        protected Mammal(string name, int age, int weight) : base(name, age, weight)
        {
        }

        public override string MakeSound()
        {
            return "Making some mammal sound...";
        }
    }
}
