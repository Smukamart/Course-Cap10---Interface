using System;
using System.Collections.Generic;
using System.Text;
using Course.Entities;

namespace Course.Services
{
    class RentalService
    {
        public double PricePerHour { get; set; }
        public double PricePerDay { get; set; }
        public ITaxService _taxService { get; set; }

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan timeSpan = carRental.Finish.Subtract(carRental.Start);
            double tax;
            double basicPayment;
            if (timeSpan.TotalHours <= 12)
            {
                basicPayment = Math.Ceiling(timeSpan.TotalHours) * PricePerHour;
                tax = _taxService.Tax(basicPayment);
            }
            else
            {
                basicPayment = Math.Ceiling(timeSpan.TotalDays) * PricePerDay;
                tax = _taxService.Tax(basicPayment);
            }
            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
