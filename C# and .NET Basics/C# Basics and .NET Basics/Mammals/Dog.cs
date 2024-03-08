namespace C__Basics_and_.NET_Basics.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, int age, int weight) 
            : base(name, age, weight)
        {
        }

        public override string MakeSound()
        {
            return "Woof woof";
        }
    }
}
