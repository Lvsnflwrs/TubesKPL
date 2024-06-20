namespace HalamanUtama
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
            this.wishlist = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Keranjang = new System.Windows.Forms.Button();
            this.AddKeranjang = new System.Windows.Forms.Button();
            this.AddWishlist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HalamanUtama.Properties.Resources.Halaman_Utama__1_;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(415, 894);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(34, 448);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(337, 292);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // wishlist
            // 
            this.wishlist.Location = new System.Drawing.Point(34, 770);
            this.wishlist.Name = "wishlist";
            this.wishlist.Size = new System.Drawing.Size(75, 43);
            this.wishlist.TabIndex = 3;
            this.wishlist.Text = "Wishlist";
            this.wishlist.UseVisualStyleBackColor = true;
            this.wishlist.Click += new System.EventHandler(this.wishlist_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(56, 95);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Profile";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Keranjang
            // 
            this.Keranjang.Location = new System.Drawing.Point(296, 770);
            this.Keranjang.Name = "Keranjang";
            this.Keranjang.Size = new System.Drawing.Size(75, 43);
            this.Keranjang.TabIndex = 5;
            this.Keranjang.Text = "Keranjang";
            this.Keranjang.UseVisualStyleBackColor = true;
            this.Keranjang.Click += new System.EventHandler(this.Keranjang_Click);
            // 
            // AddKeranjang
            // 
            this.AddKeranjang.Location = new System.Drawing.Point(204, 770);
            this.AddKeranjang.Name = "AddKeranjang";
            this.AddKeranjang.Size = new System.Drawing.Size(75, 43);
            this.AddKeranjang.TabIndex = 6;
            this.AddKeranjang.Text = "+Keranjang";
            this.AddKeranjang.UseVisualStyleBackColor = true;
            this.AddKeranjang.Click += new System.EventHandler(this.AddKeranjang_Click);
            // 
            // AddWishlist
            // 
            this.AddWishlist.Location = new System.Drawing.Point(123, 770);
            this.AddWishlist.Name = "AddWishlist";
            this.AddWishlist.Size = new System.Drawing.Size(75, 43);
            this.AddWishlist.TabIndex = 7;
            this.AddWishlist.Text = "+Wishlist";
            this.AddWishlist.UseVisualStyleBackColor = true;
            this.AddWishlist.Click += new System.EventHandler(this.AddWishlist_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 893);
            this.Controls.Add(this.AddWishlist);
            this.Controls.Add(this.AddKeranjang);
            this.Controls.Add(this.Keranjang);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.wishlist);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Halaman Utama";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button wishlist;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Keranjang;
        private System.Windows.Forms.Button AddKeranjang;
        private System.Windows.Forms.Button AddWishlist;
    }
}

