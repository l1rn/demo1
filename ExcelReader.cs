using demoex111.core;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoex111
{
    public class ExcelReader
    {
        public void ReadMaterialTypeFromExcelFile(ApplicationContext db, string excelFile)
        {
            ExcelPackage.License.SetNonCommercialPersonal("sadasdfasdgdrafhbrtshrthbtfghfgcgf");
            using var package = new ExcelPackage(new FileInfo(excelFile));
            var worksheet = package.Workbook.Worksheets[0];
            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var name = worksheet.Cells[row, 1].Text;
                var breakPercent = worksheet.Cells[row, 2].Text;

                MaterialType sample = new MaterialType { 
                    Name = name, 
                    PercentBreak = float.Parse(breakPercent.Replace("%", "")) 
                };

                db.MaterialTypes.Add(sample);
                db.SaveChanges();   
            }
        }

        public void ReadProductTypeFromExcelFile(ApplicationContext db, string excelFile)
        {
            ExcelPackage.License.SetNonCommercialPersonal("sadasdfasdgdrafhbrtshrthbtfghfgcgf");
            using var package = new ExcelPackage(new FileInfo(excelFile));
            var worksheet = package.Workbook.Worksheets[0];
            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var name = worksheet.Cells[row, 1].Text;
                var typeCoef = worksheet.Cells[row, 2].Text;

                ProductType sample = new ProductType { Name = name, TypeCoef = float.Parse(typeCoef) };

                db.ProductTypes.Add(sample);
                db.SaveChanges();
            }
        }

        public void ReadMaterial(ApplicationContext db, string excelFile)
        {
            ExcelPackage.License.SetNonCommercialPersonal("sadasdfasdgdrafhbrtshrthbtfghfgcgf");
            using var package = new ExcelPackage(new FileInfo(excelFile));
            var worksheet = package.Workbook.Worksheets[0];
            var materialTypes = db.MaterialTypes.ToDictionary(mt => mt.Name, mt => mt.Id);

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var name = worksheet.Cells[row, 1].Text;
                var materialTypeName = worksheet.Cells[row, 2].Text;

                if(!materialTypes.TryGetValue(materialTypeName, out int materialTypeId))
                {
                    MessageBox.Show("Не удалось получить айди материала");
                    return;
                }

                var priceForOneUnit = worksheet.Cells[row, 3].Text;
                var quantityInStorage= worksheet.Cells[row, 4].Text;
                var minQ = worksheet.Cells[row, 5].Text;
                var qInPackage = worksheet.Cells[row, 6].Text;
                var unitMeasurement = worksheet.Cells[row, 7].Text;

                Material sample = new Material { 
                    Name = name, 
                    MaterialTypeId = materialTypeId,
                    materialType = db.MaterialTypes?.Find(materialTypeId),
                    PriceForOneUnit = float.Parse(priceForOneUnit),
                    QuantityInStorage= float.Parse(quantityInStorage),
                    MinQuantity = float.Parse(minQ),
                    QuantityInPackage = float.Parse(qInPackage),
                    UnitMeasurement = unitMeasurement
                };

                db.Materials.Add(sample);
                db.SaveChanges();
            }
        }

        public void ReadProduct(ApplicationContext db, string excelFile)
        {
            ExcelPackage.License.SetNonCommercialPersonal("sadasdfasdgdrafhbrtshrthbtfghfgcgf");
            using var package = new ExcelPackage(new FileInfo(excelFile));
            var worksheet = package.Workbook.Worksheets[0];
            var productTypes = db.ProductTypes.ToDictionary(pt => pt.Name, pt => pt.Id);

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var productTypeName = worksheet.Cells[row, 1].Text;
                var name = worksheet.Cells[row, 2].Text;
                var article = worksheet.Cells[row, 3].Text;
                var minPriceForPartner = worksheet.Cells[row, 4].Text;
                var width = worksheet.Cells[row, 5].Text;

                if (!productTypes.TryGetValue(productTypeName, out int productTypeId))
                {
                    MessageBox.Show($"Тип продукта {productTypeName} не найден!");
                    continue;
                }

                Product product = new Product
                {
                    Name = name,
                    Article = article,
                    MinimalPriceForPartner = float.Parse(minPriceForPartner),
                    Width = float.Parse(width),
                    ProductTypeId = productTypeId,
                };

                db.Products.AddRange(product);
                db.SaveChanges();
            }
        }
        public void ReadMaterialProduct(ApplicationContext db, string excelFile)
        {
            ExcelPackage.License.SetNonCommercialPersonal("sadasdfasdgdrafhbrtshrthbtfghfgcgf");
            using var package = new ExcelPackage(new FileInfo(excelFile));
            var worksheet = package.Workbook.Worksheets[0];

            var materials = db.Materials.ToDictionary(m => m.Name, m => m.Id);
            var products = db.Products.ToDictionary(p => p.Name, p => p.Id);

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var productName = worksheet.Cells[row, 1].Text;
                var materialName = worksheet.Cells[row, 2].Text;
                var needToProduct = worksheet.Cells[row, 3].Text;

                if(!materials.TryGetValue(materialName, out int materialId))
                {
                    MessageBox.Show("Не удалось получить айди материала");
                    return;
                }
                if (!products.TryGetValue(productName, out int productId))
                {
                    MessageBox.Show("Не удалось получить айди материала");
                    return;
                }
                ProductMaterial sample = new ProductMaterial
                {
                    ProductId = productId,
                    MaterialId = materialId,
                    product = db.Products.Find(productId),
                    material = db.Materials.Find(materialId),
                    NeedToProduct = float.Parse(needToProduct)
                };
                db.ProductsMaterial.Add(sample);
                db.SaveChanges();
            }
        }
    }
}
