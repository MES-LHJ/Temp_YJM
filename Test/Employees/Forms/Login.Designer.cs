namespace Test.Employees.Forms
{
    partial class Login
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.closeBtn = new DevExpress.XtraEditors.SimpleButton();
            this.loginBtn = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.passwdBox = new DevExpress.XtraEditors.TextEdit();
            this.loginIdBox = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.passswd = new DevExpress.XtraLayout.LayoutControlItem();
            this.loginBox = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwdBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginIdBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passswd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginBox)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1)});
            this.bar2.OptionsBar.MinHeight = 34;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "로그인";
            this.barStaticItem1.Id = 0;
            this.barStaticItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(475, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 179);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(475, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 145);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(475, 34);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 145);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.closeBtn);
            this.flowLayoutPanel1.Controls.Add(this.loginBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 129);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(475, 50);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // closeBtn
            // 
            this.closeBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Appearance.Options.UseFont = true;
            this.closeBtn.Location = new System.Drawing.Point(345, 10);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(10);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(120, 30);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "닫기";
            // 
            // loginBtn
            // 
            this.loginBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Appearance.Options.UseFont = true;
            this.loginBtn.Location = new System.Drawing.Point(205, 10);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(10);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(120, 30);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "로그인";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.passwdBox);
            this.layoutControl1.Controls.Add(this.loginIdBox);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 34);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(475, 95);
            this.layoutControl1.TabIndex = 16;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // passwdBox
            // 
            this.passwdBox.Location = new System.Drawing.Point(234, 36);
            this.passwdBox.MenuManager = this.barManager1;
            this.passwdBox.Name = "passwdBox";
            this.passwdBox.Properties.PasswordChar = '*';
            this.passwdBox.Size = new System.Drawing.Size(219, 20);
            this.passwdBox.StyleController = this.layoutControl1;
            this.passwdBox.TabIndex = 6;
            // 
            // loginIdBox
            // 
            this.loginIdBox.Location = new System.Drawing.Point(12, 36);
            this.loginIdBox.MenuManager = this.barManager1;
            this.loginIdBox.Name = "loginIdBox";
            this.loginIdBox.Size = new System.Drawing.Size(208, 20);
            this.loginIdBox.StyleController = this.layoutControl1;
            this.loginIdBox.TabIndex = 7;
            // 
            // Root
            // 
            this.Root.AppearanceGroup.BackColor = System.Drawing.Color.White;
            this.Root.AppearanceGroup.Options.UseBackColor = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.passswd,
            this.loginBox});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(475, 95);
            this.Root.TextVisible = false;
            // 
            // passswd
            // 
            this.passswd.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passswd.AppearanceItemCaption.Options.UseFont = true;
            this.passswd.Control = this.passwdBox;
            this.passswd.Location = new System.Drawing.Point(222, 0);
            this.passswd.Name = "passswd";
            this.passswd.Size = new System.Drawing.Size(233, 75);
            this.passswd.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 10, 0, 0);
            this.passswd.Text = "비밀번호";
            this.passswd.TextLocation = DevExpress.Utils.Locations.Top;
            this.passswd.TextSize = new System.Drawing.Size(64, 21);
            // 
            // loginBox
            // 
            this.loginBox.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBox.AppearanceItemCaption.Options.UseFont = true;
            this.loginBox.Control = this.loginIdBox;
            this.loginBox.Location = new System.Drawing.Point(0, 0);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(222, 75);
            this.loginBox.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 10, 0, 0);
            this.loginBox.Text = "로그인ID";
            this.loginBox.TextLocation = DevExpress.Utils.Locations.Top;
            this.loginBox.TextSize = new System.Drawing.Size(64, 21);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 179);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.passwdBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginIdBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passswd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton closeBtn;
        private DevExpress.XtraEditors.SimpleButton loginBtn;
        private DevExpress.XtraEditors.TextEdit passwdBox;
        private DevExpress.XtraEditors.TextEdit loginIdBox;
        private DevExpress.XtraLayout.LayoutControlItem passswd;
        private DevExpress.XtraLayout.LayoutControlItem loginBox;
    }
}