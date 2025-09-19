using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoex111.core
{
    public class ProductMaterial
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MaterialId{ get; set; }
        public float NeedToProduct { get; set; }
        public virtual Product product  { get; set; }
        public virtual Material material { get;set; }

    }
}
