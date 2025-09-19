namespace demoex111
{
    partial class InfoCard
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            panel1 = new Panel();
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 29);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(40, 29);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 68);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(41, 29);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 112);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(41, 29);
            label3.TabIndex = 2;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 150);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(42, 29);
            label4.TabIndex = 3;
            label4.Text = "label4";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(143, 29);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(42, 29);
            label6.TabIndex = 5;
            label6.Text = "label6";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(541, 35);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(42, 29);
            label7.TabIndex = 6;
            label7.Text = "label7";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(133, 19);
            panel1.Margin = new Padding(4, 6, 4, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(2, 39);
            panel1.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(502, 138);
            button1.Margin = new Padding(4, 6, 4, 6);
            button1.Name = "button1";
            button1.Size = new Size(145, 41);
            button1.TabIndex = 8;
            button1.Text = "Изменить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(337, 97);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 35);
            textBox1.TabIndex = 9;
            // 
            // button2
            // 
            button2.Location = new Point(337, 141);
            button2.Margin = new Padding(4, 6, 4, 6);
            button2.Name = "button2";
            button2.Size = new Size(100, 37);
            button2.TabIndex = 10;
            button2.Text = "Расчитать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(338, 68);
            label5.Name = "label5";
            label5.Size = new Size(103, 29);
            label5.TabIndex = 11;
            label5.Text = "Кол-во продукта";
            // 
            // InfoCard
            // 
            AutoScaleDimensions = new SizeF(7F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Gabriola", 12F);
            Margin = new Padding(4, 6, 4, 6);
            Name = "InfoCard";
            Size = new Size(662, 192);
            Load += InfoCard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private Panel panel1;
        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private Label label5;
    }
}
