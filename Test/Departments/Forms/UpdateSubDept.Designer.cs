namespace Test.Departments.Forms
{
    partial class UpdateSubDept
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
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.updateBtn = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.deptCodeComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.deptNameBox = new DevExpress.XtraEditors.TextEdit();
            this.subDeptCodeBox = new DevExpress.XtraEditors.TextEdit();
            this.subDeptNameBox = new DevExpress.XtraEditors.TextEdit();
            this.subMemoBox = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.mainDeptCodeLabel = new DevExpress.XtraLayout.LayoutControlItem();
            this.subDeptCodeLabel = new DevExpress.XtraLayout.LayoutControlItem();
            this.mainDeptNameLabel = new DevExpress.XtraLayout.LayoutControlItem();
            this.subDeptNameLablel = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deptCodeComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptNameBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDeptCodeBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDeptNameBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subMemoBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptCodeLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDeptCodeLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptNameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDeptNameLablel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
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
            this.barStaticItem1.Caption = "하위 부서 수정";
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 282);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(316, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 248);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(316, 34);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 248);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.cancelBtn);
            this.flowLayoutPanel1.Controls.Add(this.updateBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 232);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(316, 50);
            this.flowLayoutPanel1.TabIndex = 34;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Appearance.Options.UseFont = true;
            this.cancelBtn.Location = new System.Drawing.Point(186, 10);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(10);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(120, 30);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "닫기";
            // 
            // updateBtn
            // 
            this.updateBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Appearance.Options.UseFont = true;
            this.updateBtn.Location = new System.Drawing.Point(46, 10);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(10);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(120, 30);
            this.updateBtn.TabIndex = 1;
            this.updateBtn.Text = "저장";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.deptCodeComboBox);
            this.layoutControl1.Controls.Add(this.deptNameBox);
            this.layoutControl1.Controls.Add(this.subDeptCodeBox);
            this.layoutControl1.Controls.Add(this.subDeptNameBox);
            this.layoutControl1.Controls.Add(this.subMemoBox);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 34);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(316, 198);
            this.layoutControl1.TabIndex = 35;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // deptCodeComboBox
            // 
            this.deptCodeComboBox.Location = new System.Drawing.Point(12, 36);
            this.deptCodeComboBox.MenuManager = this.barManager1;
            this.deptCodeComboBox.Name = "deptCodeComboBox";
            this.deptCodeComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deptCodeComboBox.Size = new System.Drawing.Size(128, 20);
            this.deptCodeComboBox.StyleController = this.layoutControl1;
            this.deptCodeComboBox.TabIndex = 4;
            // 
            // deptNameBox
            // 
            this.deptNameBox.Location = new System.Drawing.Point(154, 36);
            this.deptNameBox.MenuManager = this.barManager1;
            this.deptNameBox.Name = "deptNameBox";
            this.deptNameBox.Size = new System.Drawing.Size(140, 20);
            this.deptNameBox.StyleController = this.layoutControl1;
            this.deptNameBox.TabIndex = 5;
            // 
            // subDeptCodeBox
            // 
            this.subDeptCodeBox.Location = new System.Drawing.Point(12, 94);
            this.subDeptCodeBox.MenuManager = this.barManager1;
            this.subDeptCodeBox.Name = "subDeptCodeBox";
            this.subDeptCodeBox.Size = new System.Drawing.Size(128, 20);
            this.subDeptCodeBox.StyleController = this.layoutControl1;
            this.subDeptCodeBox.TabIndex = 6;
            // 
            // subDeptNameBox
            // 
            this.subDeptNameBox.Location = new System.Drawing.Point(154, 94);
            this.subDeptNameBox.MenuManager = this.barManager1;
            this.subDeptNameBox.Name = "subDeptNameBox";
            this.subDeptNameBox.Size = new System.Drawing.Size(140, 20);
            this.subDeptNameBox.StyleController = this.layoutControl1;
            this.subDeptNameBox.TabIndex = 7;
            // 
            // subMemoBox
            // 
            this.subMemoBox.Location = new System.Drawing.Point(12, 152);
            this.subMemoBox.MenuManager = this.barManager1;
            this.subMemoBox.Name = "subMemoBox";
            this.subMemoBox.Size = new System.Drawing.Size(128, 20);
            this.subMemoBox.StyleController = this.layoutControl1;
            this.subMemoBox.TabIndex = 8;
            // 
            // Root
            // 
            this.Root.AppearanceGroup.BackColor = System.Drawing.Color.White;
            this.Root.AppearanceGroup.Options.UseBackColor = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.mainDeptCodeLabel,
            this.subDeptCodeLabel,
            this.mainDeptNameLabel,
            this.subDeptNameLablel,
            this.layoutControlItem5});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(316, 198);
            this.Root.TextVisible = false;
            // 
            // mainDeptCodeLabel
            // 
            this.mainDeptCodeLabel.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainDeptCodeLabel.AppearanceItemCaption.Options.UseFont = true;
            this.mainDeptCodeLabel.Control = this.deptCodeComboBox;
            this.mainDeptCodeLabel.Location = new System.Drawing.Point(0, 0);
            this.mainDeptCodeLabel.Name = "mainDeptCodeLabel";
            this.mainDeptCodeLabel.Size = new System.Drawing.Size(142, 48);
            this.mainDeptCodeLabel.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 10, 0, 0);
            this.mainDeptCodeLabel.Text = "상위부서 코드";
            this.mainDeptCodeLabel.TextLocation = DevExpress.Utils.Locations.Top;
            this.mainDeptCodeLabel.TextSize = new System.Drawing.Size(100, 21);
            // 
            // subDeptCodeLabel
            // 
            this.subDeptCodeLabel.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subDeptCodeLabel.AppearanceItemCaption.Options.UseFont = true;
            this.subDeptCodeLabel.Control = this.subDeptCodeBox;
            this.subDeptCodeLabel.Location = new System.Drawing.Point(0, 48);
            this.subDeptCodeLabel.Name = "subDeptCodeLabel";
            this.subDeptCodeLabel.Size = new System.Drawing.Size(142, 58);
            this.subDeptCodeLabel.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 10, 10, 0);
            this.subDeptCodeLabel.Text = "하위 부서코드";
            this.subDeptCodeLabel.TextLocation = DevExpress.Utils.Locations.Top;
            this.subDeptCodeLabel.TextSize = new System.Drawing.Size(100, 21);
            // 
            // mainDeptNameLabel
            // 
            this.mainDeptNameLabel.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainDeptNameLabel.AppearanceItemCaption.Options.UseFont = true;
            this.mainDeptNameLabel.Control = this.deptNameBox;
            this.mainDeptNameLabel.Location = new System.Drawing.Point(142, 0);
            this.mainDeptNameLabel.Name = "mainDeptNameLabel";
            this.mainDeptNameLabel.Size = new System.Drawing.Size(154, 48);
            this.mainDeptNameLabel.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 10, 0, 0);
            this.mainDeptNameLabel.Text = "상위 부서명";
            this.mainDeptNameLabel.TextLocation = DevExpress.Utils.Locations.Top;
            this.mainDeptNameLabel.TextSize = new System.Drawing.Size(100, 21);
            // 
            // subDeptNameLablel
            // 
            this.subDeptNameLablel.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subDeptNameLablel.AppearanceItemCaption.Options.UseFont = true;
            this.subDeptNameLablel.Control = this.subDeptNameBox;
            this.subDeptNameLablel.Location = new System.Drawing.Point(142, 48);
            this.subDeptNameLablel.Name = "subDeptNameLablel";
            this.subDeptNameLablel.Size = new System.Drawing.Size(154, 130);
            this.subDeptNameLablel.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 10, 10, 0);
            this.subDeptNameLablel.Text = "하위 부서명";
            this.subDeptNameLablel.TextLocation = DevExpress.Utils.Locations.Top;
            this.subDeptNameLablel.TextSize = new System.Drawing.Size(100, 21);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.subMemoBox;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 106);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(142, 72);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 10, 10, 0);
            this.layoutControlItem5.Text = "메모";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(100, 21);
            // 
            // UpdateSubDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 282);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UpdateSubDept";
            this.Text = "UpdateSubDept";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deptCodeComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptNameBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDeptCodeBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDeptNameBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subMemoBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptCodeLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDeptCodeLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptNameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDeptNameLablel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
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
        private DevExpress.XtraEditors.ComboBoxEdit deptCodeComboBox;
        private DevExpress.XtraEditors.TextEdit deptNameBox;
        private DevExpress.XtraEditors.TextEdit subDeptCodeBox;
        private DevExpress.XtraEditors.TextEdit subDeptNameBox;
        private DevExpress.XtraLayout.LayoutControlItem mainDeptCodeLabel;
        private DevExpress.XtraLayout.LayoutControlItem mainDeptNameLabel;
        private DevExpress.XtraLayout.LayoutControlItem subDeptCodeLabel;
        private DevExpress.XtraLayout.LayoutControlItem subDeptNameLablel;
        private DevExpress.XtraEditors.TextEdit subMemoBox;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton updateBtn;
    }
}