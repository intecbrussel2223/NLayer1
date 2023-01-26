using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;

namespace Business
{
    public class ProductBusiness
    {
        ProductRepository repository;

        public ProductBusiness()
        {
            repository = new ProductRepository();   
        }
        public void AddProduct(Product product)
        {
            if (product.Name == null || product.Name == " ")
            {
                throw new Exception("Product name is required");
            }
            if (product.Price <= 0)
            {
                throw new Exception("Product price must be greater than zero");
            }
            repository.AddProduct(product);
        }
        public void DeleteProduct(Product product)
        {       
            repository.DeleteProduct(product);         
        }
        public void UpdateProduct(Product product)
        {
            if (product.Name == null || product.Name == " ")
            {
                throw new Exception("Product name is required");
            }
            if (product.Price <= 0)
            {
                throw new Exception("Product price must be greater than zero");
            }
            repository.UpdateProduct(product);
        }
        public List<Product> GetAllProducts()
        {
            return repository.GetAllProducts(); 
        }
        public void SaveToTextFile(List<Product> list, string filepath)
        {
            repository.SaveToTextFile(list, filepath);
        }
    }
}
