using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Configuration;
using Wingtiptoy.Web.Models;

namespace Wingtiptoy.Web.Services
{
    public static class Service
    {
        public static IEnumerable<ProductViewModel> GetProducts(string method)
        {
            IEnumerable<ProductViewModel> products = Enumerable.Empty<ProductViewModel>();
            using (var WingtiptopApi = new System.Net.Http.HttpClient())
            {
                WingtiptopApi.BaseAddress = new Uri(WebConfigurationManager.AppSettings["ApiUrl"]);
                var responseTask = WingtiptopApi.GetAsync(method);
                responseTask.Wait();

                var ApiResponse = responseTask.Result;

                if (ApiResponse.IsSuccessStatusCode)
                {
                    var readTask = ApiResponse.Content.ReadAsAsync<List<ProductViewModel>>();
                    readTask.Wait();

                    products = readTask.Result;
                }
                else //web api sent error response 
                {
                    //TODO log response status here..

                    products = Enumerable.Empty<ProductViewModel>();
                }

            }
            return products;
        }

        public static IEnumerable<ProductViewModel> SearchProductsByCategory(int CategoryID, string searchString, out bool isSuccessStatusCode)
        {
            isSuccessStatusCode = false;
            IEnumerable<ProductViewModel> products = Enumerable.Empty<ProductViewModel>();
            string SearchProductsByCategoryUri = string.Empty;

            SearchProductsByCategoryUri = "/api/Products/SearchProducts/" + CategoryID + "?product=" + searchString;
            if (String.IsNullOrEmpty(searchString) || searchString.Length >= 2)
            {
                using (var WingtiptopApi = new System.Net.Http.HttpClient())
                {
                    WingtiptopApi.BaseAddress = new Uri(WebConfigurationManager.AppSettings["ApiUrl"]);
                    var responseTask = WingtiptopApi.GetAsync(SearchProductsByCategoryUri);
                    responseTask.Wait();

                    var ApiResponse = responseTask.Result;

                    if (ApiResponse.IsSuccessStatusCode)
                    {
                        isSuccessStatusCode = true;
                        var readTask = ApiResponse.Content.ReadAsAsync<List<ProductViewModel>>();
                        readTask.Wait();

                        products = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        isSuccessStatusCode = false;
                        //TODO log response status here..

                        products = Enumerable.Empty<ProductViewModel>();
                    }

                }
            }
            return products;
        }
    }
}