using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    /// <summary>
    /// class that extendss formats for Customer
    /// </summary>
    public class ExternalFormatter: IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// realization of ICustomFormatter
        /// </summary>
        /// <param name="ftype"></param>
        /// <returns></returns>
        public object GetFormat(Type ftype)
        {
            if (ftype == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
        /// <summary>
        /// add a new formats to Customer
        /// </summary>
        /// <param name="format">format</param>
        /// <param name="obj">customer instance</param>
        /// <param name="formatProvider">format provider</param>
        /// <returns>returns new string representation of a customer</returns>
        public string Format(string format, object obj, IFormatProvider formatProvider)
        {
            if (obj == null) throw new ArgumentNullException();

            if (formatProvider == null)
                formatProvider = CultureInfo.InvariantCulture;

            Customer customer = obj as Customer;

            switch (format.ToUpperInvariant())
            {
                case "NCRR": return string.Format(formatProvider, "Customer record: {0}, {1}, {2:C}", customer.Name, customer.ContactPhone, customer.Revenue);
                case "NRR": return string.Format(formatProvider, "Customer record: {0}, {1:C}", customer.Name, customer.Revenue);
                case "RR": return string.Format(formatProvider, "Customer record: {0:C}", customer.Revenue);
                default: return string.Format("this format is not exist");
            }
        }

    }
}
