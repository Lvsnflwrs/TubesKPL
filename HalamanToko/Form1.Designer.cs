namespace HalamanToko
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            imageList1 = new ImageList(components);
            pictureBox1 = new PictureBox();
            listBox1 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ProdukHarga = new Label();
            NamaProduk = new Label();
            HargaProduk = new Label();
            StokProduk = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Halaman Toko.png");
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(3, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(408, 868);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(39, 176);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(332, 324);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 530);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 2;
            label1.Text = "Produk";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 578);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 3;
            label2.Text = "Harga";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 627);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 4;
            label3.Text = "Stok";
            // 
            // ProdukHarga
            // 
            ProdukHarga.AutoSize = true;
            ProdukHarga.Location = new Point(138, 530);
            ProdukHarga.Name = "ProdukHarga";
            ProdukHarga.Size = new Size(0, 20);
            ProdukHarga.TabIndex = 5;
            // 
            // NamaProduk
            // 
            NamaProduk.AutoSize = true;
            NamaProduk.Location = new Point(138, 530);
            NamaProduk.Name = "NamaProduk";
            NamaProduk.Size = new Size(0, 20);
            NamaProduk.TabIndex = 6;
            NamaProduk.Click += NamaProduk_Click;
            // 
            // HargaProduk
            // 
            HargaProduk.AutoSize = true;
            HargaProduk.Location = new Point(138, 578);
            HargaProduk.Name = "HargaProduk";
            HargaProduk.Size = new Size(0, 20);
            HargaProduk.TabIndex = 7;
            HargaProduk.Click += HargaProduk_Click;
            // 
            // StokProduk
            // 
            StokProduk.AutoSize = true;
            StokProduk.Location = new Point(138, 627);
            StokProduk.Name = "StokProduk";
            StokProduk.Size = new Size(0, 20);
            StokProduk.TabIndex = 8;
            StokProduk.Click += StokProduk_Click;
            // 
            // button1
            // 
            button1.Location = new Point(117, 700);
            button1.Name = "button1";
            button1.Size = new Size(172, 46);
            button1.TabIndex = 9;
            button1.Text = "Modifikasi Produk";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 865);
            Controls.Add(button1);
            Controls.Add(StokProduk);
            Controls.Add(HargaProduk);
            Controls.Add(NamaProduk);
            Controls.Add(ProdukHarga);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ImageList imageList1;
        private PictureBox pictureBox1;
        private ListBox listBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label ProdukHarga;
        private Label NamaProduk;
        private Label HargaProduk;
        private Label StokProduk;
        private Button button1;
    }
}
