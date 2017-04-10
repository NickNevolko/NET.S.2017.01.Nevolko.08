using NUnit.Framework;
using System;
using Task;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TaskTests
{
    [TestFixture]
    public class TestClass
    {
        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", "", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100","G", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", "N", ExpectedResult = "Customer record: Jeffrey Richter")]
        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", "R", ExpectedResult = "Customer record: 1,000,000.00")]
        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", "C", ExpectedResult = "Customer record: +1 (425) 555-0100")]
        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", "NR", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", "NC", ExpectedResult = "Customer record: Jeffrey Richter, +1 (425) 555-0100")]
        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", "RC", ExpectedResult = "Customer record: 1,000,000.00, +1 (425) 555-0100")]
        public string Customer_IFormattable_Test(string name, decimal revenue, string contactPhone, string formatStr)
        {
            return new Customer(name, revenue, contactPhone).ToString(formatStr, CultureInfo.InvariantCulture);
        }


        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", "RR", ExpectedResult = "Customer record: ¤1,000,000.00")]
        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", "NCRR", ExpectedResult = "Customer record: Jeffrey Richter, +1 (425) 555-0100, ¤1,000,000.00")]
        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", "NRR", ExpectedResult = "Customer record: Jeffrey Richter, ¤1,000,000.00")]
        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", "GG", ExpectedResult = "this format is not exist")]
        public string Customer_External_Test(string name, decimal revenue, string contactPhone, string formatStr)
        {
            Customer customer = new Customer("Jeffrey Richter", 1000000, "+1 (425) 555-0100");
            IFormatProvider fp = new ExternalFormatter();

            return new ExternalFormatter().Format(formatStr, customer, CultureInfo.InvariantCulture);
        }
    }
}
