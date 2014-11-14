using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Pos
{
    public class LocalFileSalesTaxRepository : ISalesTaxRepository
    {
        private readonly string _path;

        public LocalFileSalesTaxRepository(string path)
        {
            _path = path;
        }

        public decimal GetTaxRate(State state)
        {
            string xml;

            using (var reader = new StreamReader(_path))
            {
                xml = reader.ReadToEnd();
            }

            var doc = XDocument.Parse(xml);

            var stateString = state.ToString().ToLower();

            var taxRate =
                from taxRateElement in doc.Root.Elements("TaxRate")
                where taxRateElement.Attribute("state").Value.ToLower() == stateString
                select decimal.Parse(taxRateElement.Value);

            return taxRate.First();
        }
    }
}
