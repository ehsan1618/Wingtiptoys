using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Wingtiptoys.Service.Services;
using Wingtiptoys.Data;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;

namespace Wingtiptoys.Api.Controllers
{
    [RoutePrefix("Products")]
    [EnableCors(origins: "https://localhost:44352", headers: "*", methods: "*")]
    public class ProductsController : System.Web.Http.ApiController
    {
        //private WingtiptoysEntities dbContext = new WingtiptoysEntities();
        private IProductService productService = new ProductService(new WingtiptoysEntities());

        //TODO Authenticate/Authorize
        // GET: Products

        //public IEnumerable<Product> Get()
        //{
        //    return productService.GetProducts();
        //}


        //TODO Authenticate/Authorize
        // GET: Products
        public Product Get(int Id)
        {
            return productService.GetProducts(Id);
        }
        [HttpGet]
        [Route("Products/Cars/{Id}")]
        public IEnumerable<Product> GetProductsByCategory(int Id)
        {
            return productService.GetProductsByCategory(Id);
        }

        //TODO Authenticate/Authorize
        // GET: Products
        [HttpGet]
        public IEnumerable<Product> SearchProducts(string product)
        {
            return productService.SearchProducts(product);
        }

        //TODO Authenticate/Authorize
        // GET: Products
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public IEnumerable<Product> SearchProducts(int id, string product)
        {
            return productService.SearchProducts(id, product);
        }
    }
}