using Business;
using Models;
using System;
using System.Configuration;
using System.IO;

namespace CRUD_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = ConfigurationManager.AppSettings["path"]; // bestandspad uit App.config --> <appSettings> wordt in string variabele path gezet
            string businesspath = ConfigurationManager.AppSettings["businesspath"];
            var color = ConfigurationManager.AppSettings["Color"];
            
            var firstName = ConfigurationManager.AppSettings["FirstName"];
            var lastName = ConfigurationManager.AppSettings["LastName"];

            WriteToFile(path);
            Console.ForegroundColor = SelectColor(color);
            Console.WriteLine($"This color is {color}");
            Console.ForegroundColor = SelectColor("white");
            Console.WriteLine();
            Console.WriteLine(firstName + " " + lastName + " " + path);
            Console.WriteLine();
            
            ProductBusiness business = new ProductBusiness();
            Product product = new Product() { Name = "Playstation", Category = "Elektro", Price = 500.00, Quantity = 12 };
            // Add new product
            try
            {
                business.AddProduct(product);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            // Delete product
            var p = new Product();
            p.Name = "CellPhone";
            try
            {
                business.DeleteProduct(p);
                Console.WriteLine("Product deleted succesfully");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
            // Update product
            Product productToUpdate = new Product();
            productToUpdate.Name = "AntiVirus";
            productToUpdate.Price = 100;
            productToUpdate.Quantity = 12;
            try
            {
                business.UpdateProduct(productToUpdate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var all = business.GetAllProducts();
            foreach (var item in all)
            {
                Console.WriteLine(item);
            }
            // Write to file
            business.SaveToTextFile(business.GetAllProducts(), businesspath); // path wordt geschreven in App.config in <appSettings>
           
        }
        static void WriteToFile(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Create);
            using(StreamWriter sw = new StreamWriter(stream))
            {
                sw.Write("Hello Streamwriter new");
            }
        }
        static ConsoleColor SelectColor(string color)
        {
            if (color == "Red")
                return ConsoleColor.Red;
            if (color == "Blue")
                return ConsoleColor.Blue;
            if (color == "Green")
                return ConsoleColor.Green;
            return ConsoleColor.White;
        }
    }
}
