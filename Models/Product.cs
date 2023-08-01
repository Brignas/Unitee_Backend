using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace unitee_supplier_backend.Models
{
    public class Product
    {
        public int Product_ID { get; set; }
        public int Department_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public string Product_Image { get; set; }
        public string Product_Gender { get; set; }
        public int Product_Type_ID { get; set; }
        public float Product_Price { get; set; }
        public int Product_Quantity { get; set; }
    }
}