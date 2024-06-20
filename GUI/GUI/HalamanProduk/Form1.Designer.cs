namespace HalamanProduk
{
    partial class Form1
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
            this.NamaProduki = new System.Windows.Forms.Label();
            this.Review = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Stok = new System.Windows.Forms.Label();
            this.Harga = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.Kuantitas = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NamaProduki
            // 
            this.NamaProduki.AutoSize = true;
            this.NamaProduki.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamaProduki.Location = new System.Drawing.Point(148, 164);
            this.NamaProduki.Name = "NamaProduki";
            this.NamaProduki.Size = new System.Drawing.Size(0, 35);
            this.NamaProduki.TabIndex = 2;
            // 
            // Review
            // 
            this.Review.AutoSize = true;
            this.Review.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Review.Location = new System.Drawing.Point(33, 552);
            this.Review.Name = "Review";
            this.Review.Size = new System.Drawing.Size(0, 20);
            this.Review.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 653);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Stok Produk";
            // 
            // Stok
            // 
            this.Stok.AutoSize = true;
            this.Stok.BackColor = System.Drawing.Color.Transparent;
            this.Stok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stok.Location = new System.Drawing.Point(167, 653);
            this.Stok.Name = "Stok";
            this.Stok.Size = new System.Drawing.Size(0, 20);
            this.Stok.TabIndex = 6;
            // 
            // Harga
            // 
            this.Harga.AutoSize = true;
            this.Harga.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Harga.Location = new System.Drawing.Point(32, 486);
            this.Harga.Name = "Harga";
            this.Harga.Size = new System.Drawing.Size(0, 29);
            this.Harga.TabIndex = 7;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 893);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // Kuantitas
            // 
            this.Kuantitas.Location = new System.Drawing.Point(51, 718);
            this.Kuantitas.Name = "Kuantitas";
            this.Kuantitas.Size = new System.Drawing.Size(78, 20);
            this.Kuantitas.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(154, 712);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 30);
            this.button1.TabIndex = 10;
            this.button1.Text = "+ Keranjang";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HalamanProduk.Properties.Resources.Halaman_Produk__1_;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(416, 895);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 893);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Kuantitas);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.Harga);
            this.Controls.Add(this.Stok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Review);
            this.Controls.Add(this.NamaProduki);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label NamaProduki;
        private System.Windows.Forms.Label Review;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Stok;
        private System.Windows.Forms.Label Harga;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox Kuantitas;
        private System.Windows.Forms.Button button1;
    }
}

