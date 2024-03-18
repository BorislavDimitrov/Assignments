namespace Classes_in_C_sharp.Vehicles
{
    public class Motorbike : Vehicle
    {
        private string _type;

        public Motorbike(string make, string model, int year, double engineSize, string color, string type, int gears)
            : base(make, model, year, engineSize, color, gears)
        {
          Type = type;
        }

        public string Type
        {
            get { return _type; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Type cannot be null or empty.");
                }
                _type = value;
            }
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Motorbike type: {Type}";
        }

        public override void StartEngine()
        {
            Console.WriteLine("Motorbike engine starting...");
        }
    }
}
