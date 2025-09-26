using demoex111.core;
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
    public partial class InfoCard : UserControl
    {
        private string _productName;
        private Material _material { get; set; }
        public InfoCard(ProductLoadData productLoadData)
        {
            InitializeComponent();
            LoadCards(productLoadData);
        }

        private void InfoCard_Load(object sender, EventArgs e)
        {
            button1.BackColor = ColorTranslator.FromHtml("#2d6033");
            button2.BackColor = ColorTranslator.FromHtml("#2d6033");
        }
        private void LoadCards(ProductLoadData data)
        {
            this.BackColor = ColorTranslator.FromHtml("#BBD9B2");
            label1.Text = data.ProductTypeName;
            label6.Text = data.ProductName;
            label2.Text = data.Article;
            label3.Text = $"{data.MinPricePartner:0.00} р.";
            label4.Text = $"{data.Width:0.00} м.";
            label7.Text = $"{data.Price:0.00} р.";

            label1.AutoEllipsis = true;
            label6.AutoEllipsis = true;
            label1.MaximumSize = new Size(200, 20);

            _productName = data.ProductName;
            _material = data.material;
            label6.MaximumSize = new Size(200, 20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var editForm = new EditForm(_productName))
            {
                if(editForm.ShowDialog() == DialogResult.OK)
                {
                    if (editForm.DateUpdated)
                    {
                        using(ApplicationContext db = new ApplicationContext())
                        {
                            var productsMap = db.Products.ToDictionary(p => p.Name, p => p);
                            if(!productsMap.TryGetValue(_productName, out var product))
                            {
                                return;
                            }

                            label1.Text = db.ProductTypes.Find(product.ProductTypeId).Name;
                            label2.Text = product.Article;
                            label3.Text = $"{product.MinimalPriceForPartner} р.";
                            label4.Text = $"{product.Width} м.";
                            label6.Text = $"{product.Name}";
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext()) {
                    var products = db.Products.ToDictionary(p => p.Name, p => p.Width);
                    var productTypes = db.ProductTypes.ToDictionary(pt => pt.Id, pt => pt.Name);

                    if(!products.TryGetValue(_productName, out float pWidth))
                    {
                        MessageBox.Show("Не получилось найти продукт");
                        return;
                    }
                    Product p = db.Products.Where(p => p.Name == _productName).FirstOrDefault();

                    float p1 = float.Parse(textBox1.Text);
                    float p2 = pWidth;
                    float p3 = db.ProductTypes.Find(p.ProductTypeId).TypeCoef;

                    float m1Divide = _material.QuantityInPackage;
                    float m2 = _material.QuantityInStorage;
                    float m3 = db.MaterialTypes.Find(_material.MaterialTypeId).PercentBreak;

                    float first = p1 * p2 * p3 * m3;
                    float result = first / m1Divide;
                    MessageBox.Show($"Материала потребуется: {result:0.00}");
                }
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
