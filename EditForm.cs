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
    public partial class EditForm : Form
    {
        public bool DateUpdated { get; set; } = false;
        private string _productName;
        public EditForm(string _dataname)
        {
            InitializeComponent();
            _productName = _dataname;
        }

        private void EditForm_Load(object sender, EventArgs e)
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
                var products = db.Products.ToDictionary(p => p.Name, p => p);
                if(!products.TryGetValue(_productName, out var product))
                {
                    MessageBox.Show("Не удалось найти продукт");
                    return;
                }

                textBox1.Text = product.Name;
                textBox2.Text = product.Article;
                textBox3.Text = product.MinimalPriceForPartner.ToString();
                textBox4.Text = product.Width.ToString();

                comboBox1.Text = db.ProductTypes.Find(product.ProductTypeId).Name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var productTypes = db.ProductTypes.ToDictionary(pt => pt.Name, pt => pt);
                    if (!productTypes.TryGetValue(comboBox1.Text, out ProductType productType))
                    {
                        return;
                    }
                    var products = db.Products.ToDictionary(p => p.Name, p => p);
                    if (!products.TryGetValue(_productName, out var product))
                    {
                        MessageBox.Show("Не удалось найти продукт");
                        return;
                    }

                    product.Name = textBox1.Text;
                    product.Article = textBox2.Text;
                    product.MinimalPriceForPartner = float.Parse(textBox3.Text);
                    product.Width = float.Parse(textBox4.Text);
                    product.ProductType = productType;
                    product.ProductTypeId = productType.Id;

                    db.Update(product);
                    db.SaveChanges();
                    MessageBox.Show("Объект успешно изменен!");
                    DateUpdated = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex) { 
                MessageBox.Show($"Объект не изменен: {ex.Message}");
                return;
            }
        }
    }
}
