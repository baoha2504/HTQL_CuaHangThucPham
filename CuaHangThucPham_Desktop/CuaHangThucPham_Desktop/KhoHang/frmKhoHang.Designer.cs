namespace CuaHangThucPham_Desktop.KhoHang
{
    partial class frmKhoHang
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhoHang));
            this.mainContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.btnTrangChu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnKhoHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnNhapHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnHangHetHan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnLichSuNhapHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnDoiMatKhau = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnDangXuat = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.lblThoiGian = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.lblHoTen = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem5 = new DevExpress.XtraBars.BarStaticItem();
            this.lblTieuDe = new DevExpress.XtraBars.BarStaticItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(291, 39);
            this.mainContainer.Margin = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(1014, 665);
            this.mainContainer.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Appearance.Item.Hovered.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accordionControl1.Appearance.Item.Hovered.Options.UseFont = true;
            this.accordionControl1.Appearance.Item.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accordionControl1.Appearance.Item.Normal.Options.UseFont = true;
            this.accordionControl1.Appearance.Item.Pressed.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.accordionControl1.Appearance.Item.Pressed.Options.UseFont = true;
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btnTrangChu,
            this.btnKhoHang,
            this.btnNhapHang,
            this.btnHangHetHan,
            this.btnLichSuNhapHang,
            this.btnDoiMatKhau,
            this.btnDangXuat});
            this.accordionControl1.Location = new System.Drawing.Point(0, 39);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(291, 665);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTrangChu.ImageOptions.SvgImage")));
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnTrangChu.Text = "Trang Chủ";
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // btnKhoHang
            // 
            this.btnKhoHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnKhoHang.ImageOptions.SvgImage")));
            this.btnKhoHang.Name = "btnKhoHang";
            this.btnKhoHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnKhoHang.Text = "Kho Hàng";
            this.btnKhoHang.Click += new System.EventHandler(this.btnKhoHang_Click);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNhapHang.ImageOptions.SvgImage")));
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnNhapHang.Text = "Nhập Hàng";
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnHangHetHan
            // 
            this.btnHangHetHan.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHangHetHan.ImageOptions.SvgImage")));
            this.btnHangHetHan.Name = "btnHangHetHan";
            this.btnHangHetHan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnHangHetHan.Text = "Hàng Hết Hạn";
            this.btnHangHetHan.Click += new System.EventHandler(this.btnHangHetHan_Click);
            // 
            // btnLichSuNhapHang
            // 
            this.btnLichSuNhapHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLichSuNhapHang.ImageOptions.SvgImage")));
            this.btnLichSuNhapHang.Name = "btnLichSuNhapHang";
            this.btnLichSuNhapHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnLichSuNhapHang.Text = "Lịch Sử Nhập Hàng";
            this.btnLichSuNhapHang.Click += new System.EventHandler(this.btnLichSuNhapHang_Click);
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDoiMatKhau.ImageOptions.SvgImage")));
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnDoiMatKhau.Text = "Đổi Mật Khẩu";
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDangXuat.ImageOptions.SvgImage")));
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.barStaticItem1,
            this.lblThoiGian,
            this.barStaticItem3,
            this.lblHoTen,
            this.barStaticItem5,
            this.lblTieuDe});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1305, 39);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barStaticItem1);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.lblThoiGian);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barStaticItem3);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.lblHoTen);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barStaticItem5);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.lblTieuDe);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem1";
            this.barSubItem1.Id = 0;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "   ";
            this.barStaticItem1.Id = 1;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblThoiGian.Caption = "barStaticItem2";
            this.lblThoiGian.Id = 2;
            this.lblThoiGian.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblThoiGian.ItemAppearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblThoiGian.ItemAppearance.Normal.Options.UseFont = true;
            this.lblThoiGian.ItemAppearance.Normal.Options.UseForeColor = true;
            this.lblThoiGian.Name = "lblThoiGian";
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem3.Caption = "Thời gian:";
            this.barStaticItem3.Id = 3;
            this.barStaticItem3.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.barStaticItem3.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem3.Name = "barStaticItem3";
            // 
            // lblHoTen
            // 
            this.lblHoTen.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblHoTen.Caption = "barStaticItem4";
            this.lblHoTen.Id = 4;
            this.lblHoTen.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblHoTen.ItemAppearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHoTen.ItemAppearance.Normal.Options.UseFont = true;
            this.lblHoTen.ItemAppearance.Normal.Options.UseForeColor = true;
            this.lblHoTen.Name = "lblHoTen";
            // 
            // barStaticItem5
            // 
            this.barStaticItem5.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem5.Caption = "Họ tên:";
            this.barStaticItem5.Id = 5;
            this.barStaticItem5.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.barStaticItem5.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem5.Name = "barStaticItem5";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Id = 6;
            this.lblTieuDe.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ItemAppearance.Normal.Options.UseFont = true;
            this.lblTieuDe.Name = "lblTieuDe";
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.barStaticItem1,
            this.lblThoiGian,
            this.barStaticItem3,
            this.lblHoTen,
            this.barStaticItem5,
            this.lblTieuDe});
            this.fluentFormDefaultManager1.MaxItemId = 7;
            // 
            // frmKhoHang
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 704);
            this.ControlContainer = this.mainContainer;
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "frmKhoHang";
            this.NavigationControl = this.accordionControl1;
            this.Text = "PHẦN MỀM QUẢN LÝ KHO HÀNG CHO CỬA HÀNG";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer mainContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnTrangChu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnKhoHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnNhapHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnHangHetHan;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnLichSuNhapHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnDoiMatKhau;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnDangXuat;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem5;
        private DevExpress.XtraBars.BarStaticItem lblTieuDe;
        public DevExpress.XtraBars.BarStaticItem lblThoiGian;
        public DevExpress.XtraBars.BarStaticItem lblHoTen;
    }
}