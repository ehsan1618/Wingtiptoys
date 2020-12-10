using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wingtiptoys.Data;
using System.Web;

namespace Wingtiptoys.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly WingtiptoysEntities dbContext;

        //Dependency injection
        public ProductService(WingtiptoysEntities dbContext)
        {
            this.dbContext = dbContext;
        }
        public Product DeleteProducts()
        {
            throw new NotImplementedException();
        }
        
        public List<Product> GetProducts()
        {
            using (dbContext)
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                return dbContext.Products.ToList();
            }
        }

        public Product GetProducts(int productId)
        {
            using (dbContext)
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                return dbContext.Products.Where(i=>i.ProductID == productId).FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(int categoryID)
        {
            using (dbContext)
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                return dbContext.Products.Where(i => i.CategoryID == categoryID).ToList();
            }
        }

        public List<Product> SearchProducts(string searchString)
        {
            using (dbContext)
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                return dbContext.Products.Where(i => i.ProductName.Contains(searchString)).ToList();
            }
        }

        public List<Product> SearchProducts(int categoryID,string searchString)
        {
            using (dbContext)
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                if (!string.IsNullOrEmpty(searchString))
                {
                    return dbContext.Products.Where(i => i.CategoryID == categoryID && i.ProductName.Contains(searchString)).ToList();
                }
                else // return all list for empty text box search
                {
                    return dbContext.Products.Where(i => i.CategoryID == categoryID).ToList();
                }
            }
        }

        public Product UpdateProducts(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
