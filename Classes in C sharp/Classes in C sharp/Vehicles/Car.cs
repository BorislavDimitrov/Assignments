namespace Classes_in_C_sharp.Vehicles
{
    public class Car : Vehicle
    {
        private int _doorsCount;

        public Car(string make, string model, int year, double engineSize, string color, int gears, int doorsCount = 4)
            : base(make, model, year, engineSize, color, gears)
        {
            DoorsCount = doorsCount;
        }

        public int DoorsCount
        {
            get { return _doorsCount; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Engine size must be greater than zero.");
                }
                _doorsCount = value;
            }
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", DoorsCount: {DoorsCount}";
        }
    }
}
