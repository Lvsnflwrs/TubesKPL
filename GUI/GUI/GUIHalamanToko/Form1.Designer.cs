namespace GUIHalamanToko
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NamaProduk = new System.Windows.Forms.Label();
            this.HargaProduk = new System.Windows.Forms.Label();
            this.StokProduk = new System.Windows.Forms.Label();
            this.ModifikasiButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GUIHalamanToko.Properties.Resources.Halaman_Produk__2_;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(414, 893);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(32, 143);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(349, 368);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 543);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Produk";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 586);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Harga";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 631);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stok";
            // 
            // NamaProduk
            // 
            this.NamaProduk.AutoSize = true;
            this.NamaProduk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamaProduk.Location = new System.Drawing.Point(129, 544);
            this.NamaProduk.Name = "NamaProduk";
            this.NamaProduk.Size = new System.Drawing.Size(38, 15);
            this.NamaProduk.TabIndex = 5;
            this.NamaProduk.Text = "label4";
            this.NamaProduk.Click += new System.EventHandler(this.NamaProduk_Click);
            // 
            // HargaProduk
            // 
            this.HargaProduk.AutoSize = true;
            this.HargaProduk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HargaProduk.Location = new System.Drawing.Point(129, 588);
            this.HargaProduk.Name = "HargaProduk";
            this.HargaProduk.Size = new System.Drawing.Size(38, 15);
            this.HargaProduk.TabIndex = 6;
            this.HargaProduk.Text = "label5";
            this.HargaProduk.Click += new System.EventHandler(this.HargaProduk_Click);
            // 
            // StokProduk
            // 
            this.StokProduk.AutoSize = true;
            this.StokProduk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StokProduk.Location = new System.Drawing.Point(129, 633);
            this.StokProduk.Name = "StokProduk";
            this.StokProduk.Size = new System.Drawing.Size(38, 15);
            this.StokProduk.TabIndex = 7;
            this.StokProduk.Text = "label6";
            this.StokProduk.Click += new System.EventHandler(this.StokProduk_Click);
            // 
            // ModifikasiButton
            // 
            this.ModifikasiButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifikasiButton.Location = new System.Drawing.Point(132, 725);
            this.ModifikasiButton.Name = "ModifikasiButton";
            this.ModifikasiButton.Size = new System.Drawing.Size(132, 43);
            this.ModifikasiButton.TabIndex = 8;
            this.ModifikasiButton.Text = "Modifikasi Produk";
            this.ModifikasiButton.UseVisualStyleBackColor = true;
            this.ModifikasiButton.Click += new System.EventHandler(this.ModifikasiButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 893);
            this.Controls.Add(this.ModifikasiButton);
            this.Controls.Add(this.StokProduk);
            this.Controls.Add(this.HargaProduk);
            this.Controls.Add(this.NamaProduk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label NamaProduk;
        private System.Windows.Forms.Label HargaProduk;
        private System.Windows.Forms.Label StokProduk;
        private System.Windows.Forms.Button ModifikasiButton;
    }
}

