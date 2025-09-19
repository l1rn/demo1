namespace demoex111
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();

            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    ExcelReader excelReader = new ExcelReader();
                    db.RemoveRange(db.ProductTypes);
                    db.RemoveRange(db.MaterialTypes);
                    db.RemoveRange(db.Materials);
                    db.RemoveRange(db.Products);
                    db.RemoveRange(db.ProductsMaterial);
                    db.SaveChanges();

                    excelReader.ReadMaterialTypeFromExcelFile(db, "D:\\students\\ИП-302\\Таксатов\\demoex111\\data\\Material_type_import.xlsx");
                    excelReader.ReadProductTypeFromExcelFile(db, "D:\\students\\ИП-302\\Таксатов\\demoex111\\data\\Product_type_import.xlsx");
                    excelReader.ReadMaterial(db, "D:\\students\\ИП-302\\Таксатов\\demoex111\\data\\Materials_import.xlsx");
                    excelReader.ReadProduct(db, "D:\\students\\ИП-302\\Таксатов\\demoex111\\data\\Products_import.xlsx");
                    excelReader.ReadMaterialProduct(db, "D:\\students\\ИП-302\\Таксатов\\demoex111\\data\\Product_materials_import.xlsx");

                    MessageBox.Show("Excel initialized");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return;
            }

            Application.Run(new MainForm());
        }
    }
}