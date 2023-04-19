namespace CuaHangThucPham_Desktop.BanHang
{
    partial class frmBanHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBanHang));
            this.mainContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.btnTrangChu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnDSThucPham = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnLapDonHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnQuetMaSP = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnLichSuBanHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnDoiMatKhau = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnDangXuat = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.lblTieuDe = new DevExpress.XtraBars.BarStaticItem();
            this.lblThoiGian = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            this.lblHoTen = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem6 = new DevExpress.XtraBars.BarStaticItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(345, 39);
            this.mainContainer.Margin = new System.Windows.Forms.Padding(19, 19, 19, 19);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(956, 635);
            this.mainContainer.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Appearance.Item.Hovered.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accordionControl1.Appearance.Item.Hovered.Options.UseFont = true;
            this.accordionControl1.Appearance.Item.Normal.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.accordionControl1.Appearance.Item.Normal.Options.UseFont = true;
            this.accordionControl1.Appearance.Item.Pressed.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accordionControl1.Appearance.Item.Pressed.Options.UseFont = true;
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btnTrangChu,
            this.btnDSThucPham,
            this.btnLapDonHang,
            this.btnQuetMaSP,
            this.btnLichSuBanHang,
            this.btnDoiMatKhau,
            this.btnDangXuat});
            this.accordionControl1.Location = new System.Drawing.Point(0, 39);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(19, 19, 19, 19);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(345, 635);
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
            // btnDSThucPham
            // 
            this.btnDSThucPham.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDSThucPham.ImageOptions.SvgImage")));
            this.btnDSThucPham.Name = "btnDSThucPham";
            this.btnDSThucPham.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnDSThucPham.Text = "Danh Sách Thực Phẩm";
            this.btnDSThucPham.Click += new System.EventHandler(this.btnDSThucPham_Click);
            // 
            // btnLapDonHang
            // 
            this.btnLapDonHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLapDonHang.ImageOptions.SvgImage")));
            this.btnLapDonHang.Name = "btnLapDonHang";
            this.btnLapDonHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnLapDonHang.Text = "Lập Đơn Hàng";
            this.btnLapDonHang.Click += new System.EventHandler(this.btnLapDonHang_Click);
            // 
            // btnQuetMaSP
            // 
            this.btnQuetMaSP.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnQuetMaSP.ImageOptions.SvgImage")));
            this.btnQuetMaSP.Name = "btnQuetMaSP";
            this.btnQuetMaSP.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnQuetMaSP.Text = "Quét Mã Sản Phẩm";
            this.btnQuetMaSP.Click += new System.EventHandler(this.btnQuetMaSP_Click);
            // 
            // btnLichSuBanHang
            // 
            this.btnLichSuBanHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLichSuBanHang.ImageOptions.SvgImage")));
            this.btnLichSuBanHang.Name = "btnLichSuBanHang";
            this.btnLichSuBanHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnLichSuBanHang.Text = "Lịch Sử Bán Hàng";
            this.btnLichSuBanHang.Click += new System.EventHandler(this.btnLichSuBanHang_Click);
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
            this.barStaticItem1,
            this.lblTieuDe,
            this.lblThoiGian,
            this.barStaticItem4,
            this.lblHoTen,
            this.barStaticItem6});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1301, 39);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barStaticItem1);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.lblTieuDe);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.lblThoiGian);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barStaticItem4);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.lblHoTen);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barStaticItem6);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "   ";
            this.barStaticItem1.Id = 0;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Id = 1;
            this.lblTieuDe.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ItemAppearance.Normal.Options.UseFont = true;
            this.lblTieuDe.Name = "lblTieuDe";
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblThoiGian.Caption = "barStaticItem3";
            this.lblThoiGian.Id = 2;
            this.lblThoiGian.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblThoiGian.ItemAppearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblThoiGian.ItemAppearance.Normal.Options.UseFont = true;
            this.lblThoiGian.ItemAppearance.Normal.Options.UseForeColor = true;
            this.lblThoiGian.Name = "lblThoiGian";
            // 
            // barStaticItem4
            // 
            this.barStaticItem4.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem4.Caption = "Thời gian:";
            this.barStaticItem4.Id = 3;
            this.barStaticItem4.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.barStaticItem4.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem4.Name = "barStaticItem4";
            // 
            // lblHoTen
            // 
            this.lblHoTen.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblHoTen.Caption = "barStaticItem5";
            this.lblHoTen.Id = 4;
            this.lblHoTen.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblHoTen.ItemAppearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHoTen.ItemAppearance.Normal.Options.UseFont = true;
            this.lblHoTen.ItemAppearance.Normal.Options.UseForeColor = true;
            this.lblHoTen.Name = "lblHoTen";
            // 
            // barStaticItem6
            // 
            this.barStaticItem6.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem6.Caption = "Họ tên:";
            this.barStaticItem6.Id = 5;
            this.barStaticItem6.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.barStaticItem6.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem6.Name = "barStaticItem6";
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem1,
            this.lblTieuDe,
            this.lblThoiGian,
            this.barStaticItem4,
            this.lblHoTen,
            this.barStaticItem6});
            this.fluentFormDefaultManager1.MaxItemId = 6;
            // 
            // frmBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 674);
            this.ControlContainer = this.mainContainer;
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "frmBanHang";
            this.NavigationControl = this.accordionControl1;
            this.Text = "PHẦN MỀM QUẢN LÝ BÁN HÀNG CHO CỬA HÀNG";
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
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnDSThucPham;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnLapDonHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnQuetMaSP;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnLichSuBanHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnDoiMatKhau;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnDangXuat;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem lblTieuDe;
        private DevExpress.XtraBars.BarStaticItem barStaticItem4;
        private DevExpress.XtraBars.BarStaticItem barStaticItem6;
        public DevExpress.XtraBars.BarStaticItem lblThoiGian;
        public DevExpress.XtraBars.BarStaticItem lblHoTen;
    }
}