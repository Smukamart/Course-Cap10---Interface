using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Course.Entities
{
    class Invoice
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }
        public double TotalPayment { get { return BasicPayment + Tax; }}

        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public override string ToString()
        {
            return "\nINVOICE"
                + "\nBasic Payment: U$" + BasicPayment.ToString("F2", CultureInfo.InvariantCulture)
                + "\nTax: U$" + Tax.ToString("F2", CultureInfo.InvariantCulture)
                + "\nTotal Payment : U$" + TotalPayment.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
