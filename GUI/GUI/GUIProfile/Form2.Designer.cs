namespace GUIProfile
{
    partial class Form2
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
            this.SaveBtn = new System.Windows.Forms.Button();
            this.EditNama = new System.Windows.Forms.TextBox();
            this.EditPhone = new System.Windows.Forms.TextBox();
            this.EditAddress = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GUIProfile.Properties.Resources.Halaman_Edit_Profile;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(414, 893);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.SaveBtn.Location = new System.Drawing.Point(25, 524);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(368, 46);
            this.SaveBtn.TabIndex = 1;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditNama
            // 
            this.EditNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditNama.Location = new System.Drawing.Point(25, 241);
            this.EditNama.Multiline = true;
            this.EditNama.Name = "EditNama";
            this.EditNama.Size = new System.Drawing.Size(368, 51);
            this.EditNama.TabIndex = 2;
            this.EditNama.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // EditPhone
            // 
            this.EditPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditPhone.Location = new System.Drawing.Point(25, 340);
            this.EditPhone.Multiline = true;
            this.EditPhone.Name = "EditPhone";
            this.EditPhone.Size = new System.Drawing.Size(368, 51);
            this.EditPhone.TabIndex = 3;
            // 
            // EditAddress
            // 
            this.EditAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditAddress.Location = new System.Drawing.Point(25, 440);
            this.EditAddress.Multiline = true;
            this.EditAddress.Name = "EditAddress";
            this.EditAddress.Size = new System.Drawing.Size(368, 51);
            this.EditAddress.TabIndex = 4;
            this.EditAddress.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 893);
            this.Controls.Add(this.EditAddress);
            this.Controls.Add(this.EditPhone);
            this.Controls.Add(this.EditNama);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TextBox EditNama;
        private System.Windows.Forms.TextBox EditPhone;
        private System.Windows.Forms.TextBox EditAddress;
    }
}