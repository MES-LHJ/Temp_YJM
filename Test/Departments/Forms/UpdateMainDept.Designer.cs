namespace Test.Departments.Forms
{
    partial class UpdateMainDept
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
            this.mainUpdateBtn = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.mainNameBox = new DevExpress.XtraEditors.TextEdit();
            this.mainMemoBox = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.mainDeptNameLabel = new DevExpress.XtraLayout.LayoutControlItem();
            this.mainDeptCodeBox = new DevExpress.XtraEditors.TextEdit();
            this.mainDeptCodeLabel = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainNameBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMemoBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptNameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptCodeBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptCodeLabel)).BeginInit();
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
            this.barStaticItem1.Caption = "상위부서 수정";
            this.barStaticItem1.Id = 0;
            this.barStaticItem1.ItemAppearance.Disabled.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItem1.ItemAppearance.Disabled.Options.UseFont = true;
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
            this.barDockControlTop.Size = new System.Drawing.Size(316, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 220);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(316, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 186);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(316, 34);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 186);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.closeBtn);
            this.flowLayoutPanel1.Controls.Add(this.mainUpdateBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 170);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(316, 50);
            this.flowLayoutPanel1.TabIndex = 30;
            // 
            // closeBtn
            // 
            this.closeBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Appearance.Options.UseFont = true;
            this.closeBtn.Location = new System.Drawing.Point(186, 10);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(10);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(120, 30);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "닫기";
            // 
            // mainUpdateBtn
            // 
            this.mainUpdateBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainUpdateBtn.Appearance.Options.UseFont = true;
            this.mainUpdateBtn.Location = new System.Drawing.Point(46, 10);
            this.mainUpdateBtn.Margin = new System.Windows.Forms.Padding(10);
            this.mainUpdateBtn.Name = "mainUpdateBtn";
            this.mainUpdateBtn.Size = new System.Drawing.Size(120, 30);
            this.mainUpdateBtn.TabIndex = 0;
            this.mainUpdateBtn.Text = "저장";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.mainNameBox);
            this.layoutControl1.Controls.Add(this.mainMemoBox);
            this.layoutControl1.Controls.Add(this.mainDeptCodeBox);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 34);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(316, 136);
            this.layoutControl1.TabIndex = 31;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // mainNameBox
            // 
            this.mainNameBox.Location = new System.Drawing.Point(161, 36);
            this.mainNameBox.MenuManager = this.barManager1;
            this.mainNameBox.Name = "mainNameBox";
            this.mainNameBox.Size = new System.Drawing.Size(133, 20);
            this.mainNameBox.StyleController = this.layoutControl1;
            this.mainNameBox.TabIndex = 5;
            // 
            // mainMemoBox
            // 
            this.mainMemoBox.Location = new System.Drawing.Point(12, 91);
            this.mainMemoBox.MenuManager = this.barManager1;
            this.mainMemoBox.Name = "mainMemoBox";
            this.mainMemoBox.Size = new System.Drawing.Size(282, 20);
            this.mainMemoBox.StyleController = this.layoutControl1;
            this.mainMemoBox.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.AppearanceGroup.BackColor = System.Drawing.Color.White;
            this.Root.AppearanceGroup.Options.UseBackColor = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.mainDeptNameLabel,
            this.mainDeptCodeLabel});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(316, 136);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.mainMemoBox;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(296, 68);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 10, 7, 0);
            this.layoutControlItem3.Text = "메모";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(100, 21);
            // 
            // mainDeptNameLabel
            // 
            this.mainDeptNameLabel.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainDeptNameLabel.AppearanceItemCaption.Options.UseFont = true;
            this.mainDeptNameLabel.Control = this.mainNameBox;
            this.mainDeptNameLabel.Location = new System.Drawing.Point(149, 0);
            this.mainDeptNameLabel.Name = "mainDeptNameLabel";
            this.mainDeptNameLabel.Size = new System.Drawing.Size(147, 48);
            this.mainDeptNameLabel.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 10, 0, 0);
            this.mainDeptNameLabel.Text = "상위 부서명";
            this.mainDeptNameLabel.TextLocation = DevExpress.Utils.Locations.Top;
            this.mainDeptNameLabel.TextSize = new System.Drawing.Size(100, 21);
            // 
            // mainDeptCodeBox
            // 
            this.mainDeptCodeBox.Location = new System.Drawing.Point(12, 36);
            this.mainDeptCodeBox.MenuManager = this.barManager1;
            this.mainDeptCodeBox.Name = "mainDeptCodeBox";
            this.mainDeptCodeBox.Size = new System.Drawing.Size(135, 20);
            this.mainDeptCodeBox.StyleController = this.layoutControl1;
            this.mainDeptCodeBox.TabIndex = 7;
            // 
            // mainDeptCodeLabel
            // 
            this.mainDeptCodeLabel.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainDeptCodeLabel.AppearanceItemCaption.Options.UseFont = true;
            this.mainDeptCodeLabel.Control = this.mainDeptCodeBox;
            this.mainDeptCodeLabel.Location = new System.Drawing.Point(0, 0);
            this.mainDeptCodeLabel.Name = "mainDeptCodeLabel";
            this.mainDeptCodeLabel.Size = new System.Drawing.Size(149, 48);
            this.mainDeptCodeLabel.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 10, 0, 0);
            this.mainDeptCodeLabel.Text = "상위 부서코드";
            this.mainDeptCodeLabel.TextLocation = DevExpress.Utils.Locations.Top;
            this.mainDeptCodeLabel.TextSize = new System.Drawing.Size(100, 21);
            // 
            // UpdateMainDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 220);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UpdateMainDept";
            this.Text = "UpdateMainDept";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainNameBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMemoBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptNameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptCodeBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptCodeLabel)).EndInit();
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
        private DevExpress.XtraEditors.SimpleButton mainUpdateBtn;
        private DevExpress.XtraEditors.SimpleButton closeBtn;
        private DevExpress.XtraEditors.TextEdit mainNameBox;
        private DevExpress.XtraEditors.TextEdit mainMemoBox;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem mainDeptNameLabel;
        private DevExpress.XtraEditors.TextEdit mainDeptCodeBox;
        private DevExpress.XtraLayout.LayoutControlItem mainDeptCodeLabel;
    }
}