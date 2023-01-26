using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Databases
{
    public class Database
    {
        public static List<Product> products = new List<Product>()
        {
            new Product(){Name = "Laptop", Category = "Elektro", Price = 600.00 , Quantity = 20},
            new Product(){Name = "TV", Category = "Elektro", Price = 800.00 , Quantity = 150},
            new Product(){Name = "CellPhone", Category = "Elektro", Price = 700.00 , Quantity = 25},
            new Product(){Name = "AntiVirus", Category = "Software", Price = 70.00 , Quantity = 1},
            new Product(){Name = "MS Word", Category = "Software",Price = 50.00 , Quantity = 2},
            new Product(){Name = "MS Excel", Category = "Software", Price = 55.00 , Quantity = 1},
        };
        public static void SaveToTextFile(List<Product> list , string filepath)
        {
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                string HeaderProductName = "Product Name";
                string HeaderCategory = "Category";
                string HeaderPrice = "Price";
                string HeaderQuantity = "Quantity";
                writer.WriteLine(HeaderProductName.PadRight(18) + HeaderCategory.PadRight(13) + HeaderPrice.PadRight(6) + HeaderQuantity.PadLeft(10));
                foreach (Product product in list)
                {
                    writer.WriteLine(product.Name.PadRight(15) + " | " + product.Category.PadRight(10) + " | " +
                        product.Price.ToString().PadRight(5) + " | " +
                        product.Quantity.ToString().PadRight(4)); ;
                }
            }
        }
    }
}
