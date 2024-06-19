namespace MOdifProduk
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            Mouse = new ListBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            namaProduk = new TextBox();
            HargaProduk = new TextBox();
            stokProduk = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(0, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(410, 881);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Mouse
            // 
            Mouse.FormattingEnabled = true;
            Mouse.Location = new Point(37, 161);
            Mouse.Name = "Mouse";
            Mouse.Size = new Size(334, 404);
            Mouse.TabIndex = 1;
            Mouse.SelectedIndexChanged += Mouse_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(41, 753);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Tambah";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(156, 753);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 6;
            button2.Text = "Edit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(268, 753);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 7;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 593);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 8;
            label1.Text = "Produk";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 635);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 9;
            label2.Text = "Harga";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 677);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 10;
            label3.Text = "Stok";
            // 
            // namaProduk
            // 
            namaProduk.Location = new Point(113, 593);
            namaProduk.Name = "namaProduk";
            namaProduk.Size = new Size(258, 27);
            namaProduk.TabIndex = 11;
            namaProduk.TextChanged += namaProduk_TextChanged;
            // 
            // HargaProduk
            // 
            HargaProduk.Location = new Point(113, 632);
            HargaProduk.Name = "HargaProduk";
            HargaProduk.Size = new Size(258, 27);
            HargaProduk.TabIndex = 12;
            HargaProduk.TextChanged += HargaProduk_TextChanged;
            // 
            // stokProduk
            // 
            stokProduk.Location = new Point(113, 674);
            stokProduk.Name = "stokProduk";
            stokProduk.Size = new Size(258, 27);
            stokProduk.TabIndex = 13;
            stokProduk.TextChanged += stokProduk_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 885);
            Controls.Add(stokProduk);
            Controls.Add(HargaProduk);
            Controls.Add(namaProduk);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Mouse);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ListBox Mouse;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox namaProduk;
        private TextBox HargaProduk;
        private TextBox stokProduk;
    }
}
