namespace Test.Departments.Forms
{
    partial class AddMainDept
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
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.insertBtn = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.mainDeptNameBox = new DevExpress.XtraEditors.TextEdit();
            this.mainMemoBox = new DevExpress.XtraEditors.TextEdit();
            this.mainDeptCodeBox = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.asd = new DevExpress.XtraLayout.LayoutControlItem();
            this.mainDeptNameLabel = new DevExpress.XtraLayout.LayoutControlItem();
            this.mainDeptCodeLabel = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptNameBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMemoBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptCodeBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptNameLabel)).BeginInit();
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
            this.bar2.FloatLocation = new System.Drawing.Point(433, 133);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1)});
            this.bar2.OptionsBar.MinHeight = 34;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "상위 부서 추가";
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
            this.barDockControlTop.Size = new System.Drawing.Size(316, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 232);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(316, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 198);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(316, 34);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 198);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Appearance.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Appearance.Options.UseFont = true;
            this.cancelBtn.Appearance.Options.UseForeColor = true;
            this.cancelBtn.Location = new System.Drawing.Point(186, 10);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(10);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(120, 30);
            this.cancelBtn.TabIndex = 24;
            this.cancelBtn.Text = "취소";
            // 
            // insertBtn
            // 
            this.insertBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertBtn.Appearance.ForeColor = System.Drawing.Color.White;
            this.insertBtn.Appearance.Options.UseFont = true;
            this.insertBtn.Appearance.Options.UseForeColor = true;
            this.insertBtn.Location = new System.Drawing.Point(46, 10);
            this.insertBtn.Margin = new System.Windows.Forms.Padding(10);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(120, 30);
            this.insertBtn.TabIndex = 23;
            this.insertBtn.Text = "저장";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.cancelBtn);
            this.flowLayoutPanel1.Controls.Add(this.insertBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 182);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(316, 50);
            this.flowLayoutPanel1.TabIndex = 37;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.mainDeptNameBox);
            this.layoutControl1.Controls.Add(this.mainMemoBox);
            this.layoutControl1.Controls.Add(this.mainDeptCodeBox);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 34);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1190, 63, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(316, 148);
            this.layoutControl1.TabIndex = 38;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // mainDeptNameBox
            // 
            this.mainDeptNameBox.Location = new System.Drawing.Point(169, 44);
            this.mainDeptNameBox.MenuManager = this.barManager1;
            this.mainDeptNameBox.Name = "mainDeptNameBox";
            this.mainDeptNameBox.Size = new System.Drawing.Size(127, 20);
            this.mainDeptNameBox.StyleController = this.layoutControl1;
            this.mainDeptNameBox.TabIndex = 5;
            // 
            // mainMemoBox
            // 
            this.mainMemoBox.Location = new System.Drawing.Point(20, 108);
            this.mainMemoBox.MenuManager = this.barManager1;
            this.mainMemoBox.Name = "mainMemoBox";
            this.mainMemoBox.Size = new System.Drawing.Size(276, 20);
            this.mainMemoBox.StyleController = this.layoutControl1;
            this.mainMemoBox.TabIndex = 6;
            // 
            // mainDeptCodeBox
            // 
            this.mainDeptCodeBox.Location = new System.Drawing.Point(20, 44);
            this.mainDeptCodeBox.Name = "mainDeptCodeBox";
            this.mainDeptCodeBox.Size = new System.Drawing.Size(129, 20);
            this.mainDeptCodeBox.StyleController = this.layoutControl1;
            this.mainDeptCodeBox.TabIndex = 7;
            // 
            // Root
            // 
            this.Root.AppearanceGroup.BackColor = System.Drawing.Color.White;
            this.Root.AppearanceGroup.Options.UseBackColor = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.asd,
            this.mainDeptNameLabel,
            this.mainDeptCodeLabel});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(316, 148);
            this.Root.TextVisible = false;
            // 
            // asd
            // 
            this.asd.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asd.AppearanceItemCaption.Options.UseFont = true;
            this.asd.Control = this.mainMemoBox;
            this.asd.Location = new System.Drawing.Point(0, 64);
            this.asd.Name = "asd";
            this.asd.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.asd.Size = new System.Drawing.Size(296, 64);
            this.asd.Text = "메모";
            this.asd.TextLocation = DevExpress.Utils.Locations.Top;
            this.asd.TextSize = new System.Drawing.Size(100, 21);
            // 
            // mainDeptNameLabel
            // 
            this.mainDeptNameLabel.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainDeptNameLabel.AppearanceItemCaption.Options.UseFont = true;
            this.mainDeptNameLabel.Control = this.mainDeptNameBox;
            this.mainDeptNameLabel.Location = new System.Drawing.Point(149, 0);
            this.mainDeptNameLabel.Name = "mainDeptNameLabel";
            this.mainDeptNameLabel.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.mainDeptNameLabel.Size = new System.Drawing.Size(147, 64);
            this.mainDeptNameLabel.Text = "상위 부서명";
            this.mainDeptNameLabel.TextLocation = DevExpress.Utils.Locations.Top;
            this.mainDeptNameLabel.TextSize = new System.Drawing.Size(100, 21);
            // 
            // mainDeptCodeLabel
            // 
            this.mainDeptCodeLabel.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.mainDeptCodeLabel.AppearanceItemCaption.Options.UseFont = true;
            this.mainDeptCodeLabel.Control = this.mainDeptCodeBox;
            this.mainDeptCodeLabel.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.mainDeptCodeLabel.CustomizationFormText = "상위 부서코드";
            this.mainDeptCodeLabel.Location = new System.Drawing.Point(0, 0);
            this.mainDeptCodeLabel.Name = "mainDeptCodeLabel";
            this.mainDeptCodeLabel.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.mainDeptCodeLabel.Size = new System.Drawing.Size(149, 64);
            this.mainDeptCodeLabel.Text = "상위 부서코드";
            this.mainDeptCodeLabel.TextLocation = DevExpress.Utils.Locations.Top;
            this.mainDeptCodeLabel.TextSize = new System.Drawing.Size(100, 21);
            // 
            // AddMainDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 232);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "AddMainDept";
            this.Text = "AddMainDept";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptNameBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMemoBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptCodeBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptNameLabel)).EndInit();
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
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton insertBtn;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit mainMemoBox;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem asd;
        private DevExpress.XtraLayout.LayoutControlItem mainDeptNameLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.TextEdit mainDeptNameBox;
        private DevExpress.XtraEditors.TextEdit mainDeptCodeBox;
        private DevExpress.XtraLayout.LayoutControlItem mainDeptCodeLabel;
    }
}