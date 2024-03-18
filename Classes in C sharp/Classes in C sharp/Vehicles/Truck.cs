namespace Classes_in_C_sharp.Vehicles
{
    public class Truck : Vehicle
    {
        private int _loadedKilos;
        private int _maxLoadCapacity;

        public Truck(string make, string model, int year, double engineSize, string color, int gears, int maxLoadCapacity = 1500) 
            : base(make, model, year, engineSize, color, gears)
        {
            MaxLoadCapacity = maxLoadCapacity;
        }

        public int MaxLoadCapacity 
        {
            get => _maxLoadCapacity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The maximum load capacity of a truck should be a positive integer.");
                }

                _maxLoadCapacity = value;
            }
        }

        public int LoadedKilograms => _loadedKilos;

        public void Load(int loadKilos)
        {
            if (_loadedKilos + loadKilos > MaxLoadCapacity)
            {
                throw new InvalidOperationException("You cant load more than the capacity of the truck.");
            }

            _loadedKilos += loadKilos;
        }

        public void Unload(int unloadKilos)
        {
            _loadedKilos -= unloadKilos;
        }
    }
}
