using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Customer : IFormattable
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }

        public Customer(string name, decimal revenue, string contactPhone)
        {
            this.Name = name;
            this.ContactPhone = contactPhone;
            this.Revenue = revenue;
        }

        public override string ToString() => this.ToString("G", CultureInfo.CurrentCulture);


        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format))
                format = "G";

            if (formatProvider == null)
                formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G":
                case "NCR": return string.Format(formatProvider, "Customer record: {0}, {1:N}, {2}", Name, Revenue, ContactPhone);
                case "N":   return string.Format(formatProvider, "Customer record: {0}", Name);
                case "R":   return string.Format(formatProvider, "Customer record: {0:N}", Revenue);
                case "C":   return string.Format(formatProvider, "Customer record: {0}", ContactPhone);
                case "NR":  return string.Format(formatProvider, "Customer record: {0}, {1:N}", Name, Revenue);
                case "NC":  return string.Format(formatProvider, "Customer record: {0}, {1}", Name, ContactPhone);
                case "RC":  return string.Format(formatProvider, "Customer record: {0:N}, {1}", Revenue, ContactPhone);
                default:    throw new FormatException(string.Format($"The format {format} doesn't exist."));
            }

        }
    }
}