using Databases;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductRepository
    {
        public void AddProduct(Product product)
        {
            Database.products.Add(product);
        }
        public void DeleteProduct(Product product)
        {       
            foreach (var item in GetAllProducts())
            {
                var existingProduct = Database.products.FirstOrDefault(p => p.Name == product.Name);
                Database.products.Remove(existingProduct);
               //if(item.Name == product.Name)
               //{
               //   Database.products.Remove(item);
               //}
            }
        }
        public void UpdateProduct(Product product) 
        { 
            var existingProduct = Database.products.FirstOrDefault(p => p.Name == product.Name);
            if (existingProduct != null)
            {
                existingProduct.Price = product.Price;  
                existingProduct.Quantity = product.Quantity;    
            }
        }
        public List<Product> GetAllProducts() 
        {
            return Database.products;
        }
        public void SaveToTextFile(List<Product> list, string filepath)
        {
            Database.SaveToTextFile(list, filepath);
        }
    }
}
