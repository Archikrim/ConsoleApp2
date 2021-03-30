using System;
using System.Linq;
using System.Xml;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string path = @"..\..\XMLFile1.xml";
            int cdsCount = 0;
            string countries = "";
            string years = "";
            decimal pricesSum = 0;
            xmlDoc.Load(path);
            foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes)
            {
                pricesSum += Convert.ToDecimal(xmlNode.ChildNodes[4].InnerText);
                cdsCount++;
                countries += $"{xmlNode.ChildNodes[2].InnerText},";
                years += $"{xmlNode.ChildNodes[5].InnerText} ";
            }
            var allCountries = countries.Split(',', (char)StringSplitOptions.RemoveEmptyEntries).Distinct();
            allCountries = allCountries.Select(x => "\"" + x + "\"").ToArray();
            string distinctCountries = string.Join(",", allCountries.ToArray()).TrimEnd(',','\"');
            int[] array = years.Split(' ').
            Where(x => !string.IsNullOrWhiteSpace(x)).
            Select(x => int.Parse(x)).ToArray();
            Console.WriteLine("Jason example:\n{");
            Console.Write($"\t\"cdsCount\": {cdsCount},\n\t\"pricesSum\": {pricesSum},\n\t\"countries\": [{distinctCountries}\"]," +
                          $"\n\t\"minYear\": {array.Min()},\n\t\"maxYear\": {array.Max()}\n");
            Console.WriteLine("}");
        }
    }
}
