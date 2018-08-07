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
            String xmlDocPath = "..\\..\\..\\database\\products.xml";

            XDocument xdoc = XDocument.Load(xmlDocPath);
            addingNewXMLelements( xdoc, xmlDocPath);
           // updatingValueOfXMLelement(xdoc, xmlDocPath);
            //removeXMLelement( xdoc, xmlDocPath);
            readingXMLFileWithCondition(xdoc);
           // readingXMLFileWithoutCondition(xdoc);
            Console.ReadLine();

        }
        public static void removeXMLelement(XDocument xdoc, String xmlDocPath)
        {
            xdoc.Root.Elements().Where(x => x.Attribute("id").Value == "105").FirstOrDefault().Remove();
            xdoc.Save(xmlDocPath);
        }

        public static void updatingValueOfXMLelement(XDocument xdoc, String xmlDocPath)
        {
            xdoc.Element("products")
                .Elements("product")
                .Where(x => x.Attribute("id").Value == "105").FirstOrDefault().SetElementValue("price", 2899);
            xdoc.Save(xmlDocPath);
        }

        public static void addingNewXMLelements(XDocument xdoc, String xmlDocPath)
        {
            xdoc.Element("products").Add(
                new XElement("product", new XAttribute("id", 105),
               new XElement("name", "new product"),
              
                new XElement("price", new XAttribute("currency", "USD"),5000)
                ));
            xdoc.Save(xmlDocPath);
        }



        public static void readingXMLFileWithoutCondition(XDocument xdoc)
        {

            xdoc.Descendants("product").Select(p => new
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
        }

        public static void readingXMLFileWithCondition(XDocument xdoc)
        {
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
          
        }


    }

}
