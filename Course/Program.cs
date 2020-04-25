using System;
using Course.Entities;
using System.Collections.Generic;
using System.Globalization;
using Course.Services;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rental data");
            Console.Write("Car Model: ");
            string carModel = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
            DateTime pickup = DateTime.Parse(Console.ReadLine());
            Console.Write("Return (dd/MM/yyyy hh:mm): ");
            DateTime finish = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter price per hour: ");
            double pricePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per Day: ");
            double pricePerDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental carRental = new CarRental(pickup, finish, new Vehicle(carModel));
            RentalService rentalService = new RentalService(pricePerHour, pricePerDay, new BrazilTaxService());

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine(carRental.Invoice);
        }
    }
}