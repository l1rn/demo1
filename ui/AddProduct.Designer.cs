namespace demoex111
{
    partial class AddProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            panel1 = new Panel();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 6, 3, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 112);
            panel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(559, 349);
            button1.Name = "button1";
            button1.Size = new Size(99, 42);
            button1.TabIndex = 2;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(332, 150);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 35);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(333, 220);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 35);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(332, 290);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 35);
            textBox3.TabIndex = 5;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(332, 353);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 35);
            textBox4.TabIndex = 6;
            // 
            // npgsqlDataAdapter1
            // 
            npgsqlDataAdapter1.DeleteCommand = null;
            npgsqlDataAdapter1.InsertCommand = null;
            npgsqlDataAdapter1.SelectCommand = null;
            npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(333, 118);
            label1.Name = "label1";
            label1.Size = new Size(40, 29);
            label1.TabIndex = 8;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(332, 188);
            label2.Name = "label2";
            label2.Size = new Size(41, 29);
            label2.TabIndex = 9;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(332, 258);
            label3.Name = "label3";
            label3.Size = new Size(41, 29);
            label3.TabIndex = 10;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(332, 328);
            label4.Name = "label4";
            label4.Size = new Size(42, 29);
            label4.TabIndex = 11;
            label4.Text = "label4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(606, 118);
            label5.Name = "label5";
            label5.Size = new Size(41, 29);
            label5.TabIndex = 12;
            label5.Text = "label5";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(537, 150);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 37);
            comboBox1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Наш_декор;
            pictureBox1.Location = new Point(332, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // AddProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 492);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(panel1);
            Font = new Font("Gabriola", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 6, 3, 6);
            Name = "AddProduct";
            Text = "Добавить продукт";
            Load += AddProduct_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBox1;
        private PictureBox pictureBox1;
    }
}