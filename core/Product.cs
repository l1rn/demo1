using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoex111.core
{
    public class Product
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public float MinimalPriceForPartner { get; set; }
        public float Width { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
