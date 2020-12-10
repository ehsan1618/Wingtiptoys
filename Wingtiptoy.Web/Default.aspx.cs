using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Wingtiptoy.Web.Models;
using Wingtiptoy.Web.Services;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Wingtiptoy.Web
{
    public partial class _Default : Page
    {
        private int ProductCategory = 1; // TODO: we can generalize it, as of now the requirements are only cars
        private string ApiUrl = Convert.ToString(ConfigurationManager.AppSettings["ApiUrl"]);
        protected string ProductsByCategoryUri;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ProductCategory = 1; // for cars only
                this.ProductsByCategoryUri = this.ApiUrl + "/api/Products/GetProductsByCategory/" + this.ProductCategory;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "getProductsByCategory", "getProductsByCategory('"+ this.ProductsByCategoryUri + "')", true);
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                bool isSuccessStatusCode;
                IEnumerable<ProductViewModel> products = Enumerable.Empty<ProductViewModel>();
                products = Service.SearchProductsByCategory(this.ProductCategory, txtSearch.Text, out isSuccessStatusCode);
                tblSearchResult.Text = SearchProduct(products, isSuccessStatusCode);
            }
        }

        
        private string SearchProduct(IEnumerable<ProductViewModel> Products, bool isSuccessStatusCode)
        {
            StringBuilder sb = new StringBuilder();
            if (isSuccessStatusCode)
            {
                if (Products.Count() == 0)
                {
                    sb.Append("<tr><td>");
                    sb.Append("No Record found");
                    sb.Append("</td><td>");
                }
                else
                {
                    foreach (ProductViewModel Product in Products)
                    {
                        sb.Append("<tr><td><img border = '1' height = '75' src = 'Assets/" + Product.ImagePath + "' width = '100'></td ><td>" + Product.ProductName + "<br><span class='ProductPrice'><strong>Price:</strong>$" + Product.UnitPrice + "</td></tr></span>");
                    }
                }
            }
            else
            {
                sb.Append("<tr><td>");
                sb.Append("Some thing is wrong, Contact your Administrator");
                sb.Append("</td><td>");
            }
            return sb.ToString();
        }
    }
}