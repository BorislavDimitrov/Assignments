// See https://aka.ms/new-console-template for more information
using Classes_in_C_sharp.Vehicles;

var vehicle = new Vehicle(make:"Mercedes", model:"S 63", year:2019, engineSize:5500, color:"Black", gears:6);
vehicle.PaintingWithColor("Red");
Console.WriteLine(vehicle.GetInfo());
vehicle.Repair(505, description: "Oil change", date: "20/03/2024");

if (vehicle is not null)
{
    Console.WriteLine(vehicle.GetInfo());
}

Console.WriteLine(new string('-', 100));

var car = new Car(gears: 8, color: "blue", model:"M6 Competition", year:2024, engineSize:3000, make: "BMW", doorsCount:5);
car.PaintingWithColor("Black");
car.Repair();
car.Repair(545.21);

if (car is not null)
{
    Console.WriteLine(car.GetInfo());
}

Console.WriteLine(new string('-', 100));

Car car2 = null;

if (car is null)
{
    Console.WriteLine("The car is not created yet");
}

Console.WriteLine(new string('-', 100));

var motorbike = new Motorbike("Ducati", "some model", 2024, 1000, "Red", "Enduro", 7);
motorbike.PaintingWithColor("Black");

if (motorbike is Vehicle)
{
    Console.WriteLine(motorbike.GetInfo());
}

Console.WriteLine(new string('-', 100));

object motorbike2 = new Motorbike("Kawasaki", "some model", 2024, 1000, "Yellow", "Scooter", 5);
(motorbike2 as Motorbike).PaintingWithColor("Black");
Console.WriteLine((motorbike2 as Motorbike).GetInfo());

if (motorbike2 is Motorbike motorbikeInstance)
{
    Console.WriteLine(motorbikeInstance.GetInfo());
}