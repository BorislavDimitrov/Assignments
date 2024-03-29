﻿namespace C__Basics_and_.NET_Basics.Mammals
{
    public class Cat : Mammal
    {
        public Cat(string name, int age, int weight, string gender) 
            : base(name, age, weight, gender)
        {
        }

        public override string MakeSound()
        {
            return "Meow meow";
        }

        public override void Move()
        {
            Console.WriteLine("The cat is walking.");
        }

        public override void Eat(string food)
        {
            Console.WriteLine($"The cat is eating {food}.");
        }
    }
}
