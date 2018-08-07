using System;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Reading_XML_using_linq_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {

            XDocument xdoc = XDocument.Load("..\\..\\..\\database\\products.xml");
            //without condition
            //xdoc.Descendants("product").Select(p => new
            //{
            //    id = p.Attribute("id").Value,
            //    name = p.Element("name").Value,
            //    price = p.Element("price").Value,
            //    currency = p.Element("price").Attribute("currency").Value
            //}).ToList().ForEach(p =>
            //{
            //    Console.WriteLine("Id: " + p.id);
            //    Console.WriteLine("Name: " + p.name);
            //    Console.WriteLine("Price: "+ p.price);
            //    Console.WriteLine("currency: "+ p.currency);
            //    Console.WriteLine("");
            //});

            //with condition
            xdoc.Descendants("product").Where(p => Convert.ToInt32(p.Element("price").Value) > 1000)
                .Select(p => new
                {
                    id = p.Attribute("id").Value,
                    name = p.Element("name").Value,
                    price = p.Element("price").Value,
                    currency = p.Element("price").Attribute("currency").Value
                }).ToList().ForEach(p =>
            {
                Console.WriteLine("Id: " + p.id);
                Console.WriteLine("Name: " + p.name);
                Console.WriteLine("Price: " + p.price);
                Console.WriteLine("currency: " + p.currency);
                Console.WriteLine("");
            });
            Console.ReadLine();
        }
    }
}
