using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapbuoi7
{
    public class ProductManager : IProduct
    {
        private List<Product> products = new List<Product>();

        public void Insert(Product product)
        {
            products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.Price = product.Price;
            }
        }

        public void Delete(double productId)
        {
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                products.Remove(product);
            }
        }

        public Product Search(double productId)
        {
            return products.FirstOrDefault(p => p.ProductId == productId);
        }
        public Product Searchname(string productname)
        {
            return products.FirstOrDefault(p => p.ProductName == productname);
        }
    }
}
