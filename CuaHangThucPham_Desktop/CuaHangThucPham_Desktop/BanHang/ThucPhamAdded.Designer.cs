﻿namespace CuaHangThucPham_Desktop.BanHang
{
    partial class ThucPhamAdded
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picture = new System.Windows.Forms.Panel();
            this.productname = new System.Windows.Forms.Label();
            this.lblprice = new System.Windows.Forms.Label();
            this.quantity = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Panel();
            this.minus = new System.Windows.Forms.Panel();
            this.plus = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // picture
            // 
            this.picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture.Location = new System.Drawing.Point(3, 8);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(92, 51);
            this.picture.TabIndex = 0;
            // 
            // productname
            // 
            this.productname.AutoSize = true;
            this.productname.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productname.Location = new System.Drawing.Point(101, 2);
            this.productname.Name = "productname";
            this.productname.Size = new System.Drawing.Size(97, 17);
            this.productname.TabIndex = 2;
            this.productname.Text = "Tên thực phẩm";
            // 
            // lblprice
            // 
            this.lblprice.AutoSize = true;
            this.lblprice.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblprice.Location = new System.Drawing.Point(101, 24);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(31, 17);
            this.lblprice.TabIndex = 3;
            this.lblprice.Text = "Giá:";
            // 
            // quantity
            // 
            this.quantity.AutoSize = true;
            this.quantity.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.quantity.Location = new System.Drawing.Point(182, 24);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(16, 17);
            this.quantity.TabIndex = 4;
            this.quantity.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Thành tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(165, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "*";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Font = new System.Drawing.Font("Times New Roman", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.Location = new System.Drawing.Point(176, 49);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(76, 18);
            this.total.TabIndex = 7;
            this.total.Text = "Thành tiền";
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.price.Location = new System.Drawing.Point(128, 24);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(31, 17);
            this.price.TabIndex = 8;
            this.price.Text = "Giá";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 1);
            this.panel1.TabIndex = 11;
            // 
            // btnXoa
            // 
            this.btnXoa.BackgroundImage = global::CuaHangThucPham_Desktop.Properties.Resources.delete;
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXoa.Location = new System.Drawing.Point(259, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(20, 20);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // minus
            // 
            this.minus.BackgroundImage = global::CuaHangThucPham_Desktop.Properties.Resources.dau_tru;
            this.minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minus.Location = new System.Drawing.Point(227, 26);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(15, 15);
            this.minus.TabIndex = 10;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // plus
            // 
            this.plus.BackgroundImage = global::CuaHangThucPham_Desktop.Properties.Resources.dau_cong;
            this.plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plus.Location = new System.Drawing.Point(207, 26);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(15, 15);
            this.plus.TabIndex = 9;
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // ThucPhamAdded
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.price);
            this.Controls.Add(this.total);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.lblprice);
            this.Controls.Add(this.productname);
            this.Controls.Add(this.picture);
            this.Name = "ThucPhamAdded";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(286, 70);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel picture;
        private System.Windows.Forms.Label productname;
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.Label quantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Panel plus;
        private System.Windows.Forms.Panel minus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel btnXoa;
    }
}
