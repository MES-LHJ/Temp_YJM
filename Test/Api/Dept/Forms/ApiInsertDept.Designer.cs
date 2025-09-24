namespace Test.Api.Dept.Forms
{
    partial class ApiInsertDept
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
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.insertBtn = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.deptNameBox = new DevExpress.XtraEditors.TextEdit();
            this.deptCodeBox = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.deptNameLabel = new DevExpress.XtraLayout.LayoutControlItem();
            this.deptCodeLabel = new DevExpress.XtraLayout.LayoutControlItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deptNameBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptCodeBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptNameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptCodeLabel)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Appearance.Options.UseFont = true;
            this.cancelBtn.Location = new System.Drawing.Point(226, 10);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(10);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(120, 30);
            this.cancelBtn.TabIndex = 24;
            this.cancelBtn.Text = "취소";
            // 
            // insertBtn
            // 
            this.insertBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertBtn.Appearance.Options.UseFont = true;
            this.insertBtn.Location = new System.Drawing.Point(86, 10);
            this.insertBtn.Margin = new System.Windows.Forms.Padding(10);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(120, 30);
            this.insertBtn.TabIndex = 23;
            this.insertBtn.Text = "저장";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Controls.Add(this.cancelBtn);
            this.flowLayoutPanel2.Controls.Add(this.insertBtn);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 151);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(356, 50);
            this.flowLayoutPanel2.TabIndex = 38;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.deptNameBox);
            this.layoutControl1.Controls.Add(this.deptCodeBox);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 34);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(356, 117);
            this.layoutControl1.TabIndex = 39;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // deptNameBox
            // 
            this.deptNameBox.Location = new System.Drawing.Point(189, 44);
            this.deptNameBox.Name = "deptNameBox";
            this.deptNameBox.Size = new System.Drawing.Size(147, 20);
            this.deptNameBox.StyleController = this.layoutControl1;
            this.deptNameBox.TabIndex = 5;
            // 
            // deptCodeBox
            // 
            this.deptCodeBox.Location = new System.Drawing.Point(20, 44);
            this.deptCodeBox.Name = "deptCodeBox";
            this.deptCodeBox.Size = new System.Drawing.Size(149, 20);
            this.deptCodeBox.StyleController = this.layoutControl1;
            this.deptCodeBox.TabIndex = 7;
            // 
            // Root
            // 
            this.Root.AppearanceGroup.BackColor = System.Drawing.Color.White;
            this.Root.AppearanceGroup.Options.UseBackColor = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.deptNameLabel,
            this.deptCodeLabel});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(356, 117);
            this.Root.TextVisible = false;
            // 
            // deptNameLabel
            // 
            this.deptNameLabel.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.deptNameLabel.AppearanceItemCaption.Options.UseFont = true;
            this.deptNameLabel.Control = this.deptNameBox;
            this.deptNameLabel.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.deptNameLabel.CustomizationFormText = "상위 부서명";
            this.deptNameLabel.Location = new System.Drawing.Point(169, 0);
            this.deptNameLabel.Name = "deptNameLabel";
            this.deptNameLabel.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.deptNameLabel.Size = new System.Drawing.Size(167, 97);
            this.deptNameLabel.Text = "부서명";
            this.deptNameLabel.TextLocation = DevExpress.Utils.Locations.Top;
            this.deptNameLabel.TextSize = new System.Drawing.Size(64, 21);
            // 
            // deptCodeLabel
            // 
            this.deptCodeLabel.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.deptCodeLabel.AppearanceItemCaption.Options.UseFont = true;
            this.deptCodeLabel.Control = this.deptCodeBox;
            this.deptCodeLabel.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.deptCodeLabel.CustomizationFormText = "상위 부서코드";
            this.deptCodeLabel.Location = new System.Drawing.Point(0, 0);
            this.deptCodeLabel.Name = "deptCodeLabel";
            this.deptCodeLabel.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.deptCodeLabel.Size = new System.Drawing.Size(169, 97);
            this.deptCodeLabel.Text = "부서코드";
            this.deptCodeLabel.TextLocation = DevExpress.Utils.Locations.Top;
            this.deptCodeLabel.TextSize = new System.Drawing.Size(64, 21);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.labelControl1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(356, 34);
            this.flowLayoutPanel1.TabIndex = 40;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 28);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "부서 추가";
            // 
            // ApiInsertDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 201);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ApiInsertDept";
            this.Text = "ApiInsertDept";
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deptNameBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptCodeBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptNameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptCodeLabel)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton insertBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit deptNameBox;
        private DevExpress.XtraEditors.TextEdit deptCodeBox;
        private DevExpress.XtraLayout.LayoutControlItem deptNameLabel;
        private DevExpress.XtraLayout.LayoutControlItem deptCodeLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}