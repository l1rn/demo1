    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoex111.core
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaterialTypeId { get; set; }
        public float PriceForOneUnit { get; set; }
        public float QuantityInStorage { get; set; }
        public float MinQuantity {  get; set; }
        public float QuantityInPackage { get; set; }
        public string UnitMeasurement {  get; set; }

        public virtual MaterialType materialType { get; set; }
    }
}
