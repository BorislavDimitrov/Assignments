namespace C__Basics_and_.NET_Basics
{
    public class Animal
    {
        private string _name;

        private int _age;

        private int _weight;

        private string _gender;

        public Animal(string name, int age, int weight, string gender)
        {
            Name = name;
            Age = age;
            Weight = weight;
            SetGender(gender);
        }

        public string Name {

            get { return _name; }

            set { 

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name cant be null or empty string");
                }
                _name = value;
            }
        }

        public int Age
        {
            get { return _age; }

            set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentOutOfRangeException("The age must be in the range of 0 - 200 ");
                }
            }
        }

        public int Weight
        {
            get { return _weight; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
            }
        }

        public string GetGender()
        {
            return _gender;
        }

        public void SetGender(string gender)
        {
            if (string.IsNullOrEmpty(gender))
            {
                throw new ArgumentNullException("Gender cant be null or empty string");
            }

            _gender = gender;
        }

        public virtual string MakeSound()
        {
            return "Making some animal sound...";
        }

        public string MakeSound(string sound)
        {
            return sound;
        }

        public virtual void Eat(string food)
        {
            Console.WriteLine($"Animal is eating {food}.");
        }

        public virtual void Move()
        {
            Console.WriteLine("The animal is moving.");
        }
    }
}
