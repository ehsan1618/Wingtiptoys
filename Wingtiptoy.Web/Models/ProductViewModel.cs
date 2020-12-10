using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wingtiptoy.Web.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<int> CategoryID { get; set; }
    }
}



    