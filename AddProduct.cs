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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#BBD9B2");
            Label label = new Label();
            label.Text = "Крутой маркет";
            label.Font = new Font("Gabriola", 20);
            label.Size = new Size(200, 100);
            label.Location = new Point(5, 10);

            label1.Text = "Имя продукта";
            label2.Text = "Артикул";
            label3.Text = "Мин. цена для партнера";
            label4.Text = "Ширина продукта";
            label5.Text = "Тип продукции";

            button1.BackColor = ColorTranslator.FromHtml("#2d6033");
            using (ApplicationContext db = new ApplicationContext())
            {
                var productTypes = db.ProductTypes.ToList();
                foreach (var productType in productTypes)
                {
                    comboBox1.Items.Add(productType.Name);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var productTypes = db.ProductTypes.ToDictionary(pt => pt.Name, pt => pt);
                    if(!productTypes.TryGetValue(comboBox1.Text, out ProductType productType))
                    {
                        return;
                    }
                    Product product = new Product
                    {
                        Name = textBox1.Text,
                        Article = textBox2.Text,
                        MinimalPriceForPartner = float.Parse(textBox3.Text),
                        Width = float.Parse(textBox4.Text),
                        ProductTypeId = productType.Id,
                        ProductType = productType,
                    };

                    db.Products.Add(product);
                    db.SaveChanges();
                    MessageBox.Show("Продукт добавлен");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Продукт не добавлен: {ex.Message}");

            }

        }
    }
}
