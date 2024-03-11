﻿public class Vehicle
{
    private string _make;
    private string _model;
    private int _year;
    private string _color;
    private double _engineSize;

    public Vehicle(string make, string model, int year, double engineSize, string color)
    {
        Make = make;
        Model = model;
        Year = year;
        EngineSize = engineSize;
        PaintingWithColor(color);
    }

    public string Make
    {
        get { return _make; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Make cannot be null or empty.");
            }
            _make = value;
        }
    }

    public string Model
    {
        get { return _model; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Model cannot be null or empty.");
            }
            _model = value;
        }
    }

    public int Year
    {
        get { return _year; }
        private set
        {
            if (value < 1900 || value > DateTime.Now.Year)
            {
                throw new ArgumentOutOfRangeException("Year must be between 1900 and the current year.");
            }
            _year = value;
        }
    }

    public double EngineSize
    {
        get { return _engineSize; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Engine size must be greater than zero.");
            }
            _engineSize = value;
        }
    }

    public void PaintingWithColor(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
        {
            throw new ArgumentException("Color cannot be null or empty.");
        }

        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public virtual string GetInfo()
    {
        return $"Make: {Make}, Model: {Model}, Year: {Year}, Color: {GetColor()}, Engine Size: {EngineSize}";
    }

    public virtual void Repair()
    {
        Console.WriteLine($"This {this.GetType().Name.ToLower()} has been repaired");
    }

    public virtual void Repair(double price, string date = "", string description = "Not provided")
    {
        Console.WriteLine($"This {this.GetType().Name.ToLower()} has been repaired at {(string.IsNullOrEmpty(date) ? DateTime.UtcNow.ToString() : date)} and it costed: {price}. Description: {description}");
    }
}
