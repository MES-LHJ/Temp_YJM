namespace Test.Api.Dept.Forms
{
    partial class ApiDelDept
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.closeBtn = new DevExpress.XtraEditors.SimpleButton();
            this.delDeptBtn = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.delDeptLabel = new DevExpress.XtraLayout.SimpleLabelItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delDeptLabel)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Controls.Add(this.closeBtn);
            this.flowLayoutPanel2.Controls.Add(this.delDeptBtn);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 158);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(328, 50);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // closeBtn
            // 
            this.closeBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Appearance.Options.UseFont = true;
            this.closeBtn.Location = new System.Drawing.Point(198, 10);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(10);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(120, 30);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "닫기";
            // 
            // delDeptBtn
            // 
            this.delDeptBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delDeptBtn.Appearance.Options.UseFont = true;
            this.delDeptBtn.Location = new System.Drawing.Point(58, 10);
            this.delDeptBtn.Margin = new System.Windows.Forms.Padding(10);
            this.delDeptBtn.Name = "delDeptBtn";
            this.delDeptBtn.Size = new System.Drawing.Size(120, 30);
            this.delDeptBtn.TabIndex = 1;
            this.delDeptBtn.Text = "삭제";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 34);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(328, 124);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.AppearanceGroup.BackColor = System.Drawing.Color.White;
            this.Root.AppearanceGroup.Options.UseBackColor = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.delDeptLabel});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(328, 124);
            this.Root.TextVisible = false;
            // 
            // delDeptLabel
            // 
            this.delDeptLabel.AllowHotTrack = false;
            this.delDeptLabel.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delDeptLabel.AppearanceItemCaption.Options.UseFont = true;
            this.delDeptLabel.Location = new System.Drawing.Point(0, 0);
            this.delDeptLabel.Name = "delDeptLabel";
            this.delDeptLabel.Size = new System.Drawing.Size(308, 104);
            this.delDeptLabel.TextSize = new System.Drawing.Size(128, 21);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.labelControl1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(328, 34);
            this.flowLayoutPanel1.TabIndex = 12;
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
            this.labelControl1.Text = "부서 삭제";
            // 
            // ApiDelDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 208);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ApiDelDept";
            this.Text = "ApiDelDept";
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delDeptLabel)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton closeBtn;
        private DevExpress.XtraEditors.SimpleButton delDeptBtn;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.SimpleLabelItem delDeptLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}