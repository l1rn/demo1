using demoex111.core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoex111
{
    public partial class ShowAll : Form
    {
        public ShowAll()
        {
            InitializeComponent();
            LoadCards();
        }

        private void ShowAll_Load(object sender, EventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#BBD9B2");
            Label label = new Label();
            label.Text = "Крутой маркет";
            label.Font = new Font("Gabriola", 20);
            label.Size = new Size(200, 100);
            label.Location = new Point(5, 10);

            panel1.Controls.Add(label);
        }

        private void LoadCards()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    panel2.Controls.Clear();
                    int y = 10;
                    int space = 10;

                    var productMaterials = db.ProductsMaterial
                        .Include(pm => pm.material)
                        .ToList();

                    var productTypes = db.ProductTypes.ToDictionary(pt => pt.Id, pt => pt.Name);

                    foreach (var product in db.Products.ToList()) {
                        float price = 0;
                        var productToMaterials = productMaterials
                            .Where(pm => pm.ProductId == product.Id)
                            .ToList();

                        Material material = new Material();
                        foreach(var productMaterial in productToMaterials)
                        {
                            price += productMaterial.material.PriceForOneUnit * productMaterial.NeedToProduct;
                            material = productMaterial.material;
                        }

                        if(!productTypes.TryGetValue(product.ProductTypeId, out string productTypeName))
                        {
                            return;
                        }

                        ProductLoadData data = new ProductLoadData { 
                            ProductTypeName = productTypeName,
                            ProductName = product.Name,
                            Article = product.Article,
                            MinPricePartner = product.MinimalPriceForPartner,
                            Width = product.Width,
                            Price = price,
                            material = material
                        };

                        InfoCard infoCard = new InfoCard(data);
                        infoCard.Location = new Point(10, y);
                        infoCard.Width = panel2.Width - 40;

                        panel2.Controls.Add(infoCard);
                        panel2.AutoScroll = true;
                        y += infoCard.Height + space;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Не получилось загрузить: {ex.Message}");
                return;
            }
        }
    }
}
