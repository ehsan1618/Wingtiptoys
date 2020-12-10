using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wingtiptoys.Data;

namespace Wingtiptoys.Service.Services
{
    //TODO Modify this Interface to Generic Interface
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProducts(int productId);
        List<Product> SearchProducts(string product);
        List<Product> GetProductsByCategory(int categoryID);
        List<Product> SearchProducts(int categoryID,string product);
        Product UpdateProducts(Product product);
        Product DeleteProducts();

    }
}
