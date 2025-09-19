using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoex111.core
{
    public class ProductLoadData
    {
        public string ProductTypeName {  get; set; }   
        public string ProductName { get; set; }
        public string Article { get; set; }
        public float MinPricePartner { get; set; }
        public float Width { get; set; }
        public float Price { get; set; }
        public virtual Material material {  get; set; }
    }
}
