namespace demoex111
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#BBD9B2");
            Label label = new Label();
            label.Text = "Крутой маркет";
            label.Font = new Font("Gabriola", 20);
            label.Size = new Size(200, 100);
            label.Location = new Point(5, 10);

            panel1.Controls.Add(label);

            button1.Text = "Добавить";
            button2.Text = "Посмотреть";
            button1.BackColor = ColorTranslator.FromHtml("#2d6033"); 
            button2.BackColor = ColorTranslator.FromHtml("#2d6033");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowAll showAll = new ShowAll();
            showAll.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
        }
    }
}
