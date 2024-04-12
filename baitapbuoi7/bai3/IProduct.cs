using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapbuoi7
{
    public interface IProduct
    {
        void Insert(Product product);
        void Update(Product product);
        void Delete(double productId);
        Product Search(double productId);
    }
}
