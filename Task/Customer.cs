using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    /// <summary>
    /// Represents a customer that has a Name, Contact Phone and a revenue
    /// in string format
    /// </summary>
    public class Customer : IFormattable
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// phone
        /// </summary>
        public string ContactPhone { get; set; }
        /// <summary>
        /// decimal revenue
        /// </summary>
        public decimal Revenue { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="revenue">revenue</param>
        /// <param name="contactPhone">phone</param>
        public Customer(string name, decimal revenue, string contactPhone)
        {
            this.Name = name;
            this.ContactPhone = contactPhone;
            this.Revenue = revenue;
        }
        /// <summary>
        /// make a custom repsresentation of instance
        /// </summary>
        /// <returns>returns a formatted representation of a customer instance</returns>
        public override string ToString() => this.ToString("G", CultureInfo.CurrentCulture);

        /// <summary>
        ///  make a custom repsresentation of instance
        /// </summary>
        /// <param name="format">name of format</param>
        /// <param name="formatProvider">format provider</param>
        /// <returns>returns a formatted representation of a customer instance</returns>
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