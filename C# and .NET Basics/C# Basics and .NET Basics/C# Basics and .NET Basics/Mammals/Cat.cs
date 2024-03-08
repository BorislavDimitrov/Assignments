namespace C__Basics_and_.NET_Basics.Mammals
{
    public class Cat : Mammal
    {
        public Cat(string name, int age, int weight) 
            : base(name, age, weight)
        {
        }

        public override string MakeSound()
        {
            return "Meow meow";
        }
    }
}
