namespace Test.Api.Dept.Forms
{
    partial class ApiDeptList
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.closeBtn = new DevExpress.XtraEditors.SimpleButton();
            this.delBtn = new DevExpress.XtraEditors.SimpleButton();
            this.updateBtn = new DevExpress.XtraEditors.SimpleButton();
            this.insertBtn = new DevExpress.XtraEditors.SimpleButton();
            this.deptListGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DeptCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeptName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeptMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.mainImgBox = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deptListGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainImgBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.375F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.625F));
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelControl2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 34);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.closeBtn);
            this.panelControl1.Controls.Add(this.delBtn);
            this.panelControl1.Controls.Add(this.updateBtn);
            this.panelControl1.Controls.Add(this.insertBtn);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(150, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(647, 28);
            this.panelControl1.TabIndex = 1;
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.Appearance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.closeBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Appearance.Options.UseBackColor = true;
            this.closeBtn.Appearance.Options.UseFont = true;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Location = new System.Drawing.Point(569, 3);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "닫기";
            // 
            // delBtn
            // 
            this.delBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delBtn.Appearance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.delBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delBtn.Appearance.Options.UseBackColor = true;
            this.delBtn.Appearance.Options.UseFont = true;
            this.delBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delBtn.Location = new System.Drawing.Point(488, 3);
            this.delBtn.Name = "delBtn";
            this.delBtn.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.delBtn.Size = new System.Drawing.Size(75, 23);
            this.delBtn.TabIndex = 1;
            this.delBtn.Text = "삭제";
            // 
            // updateBtn
            // 
            this.updateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateBtn.Appearance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.updateBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Appearance.Options.UseBackColor = true;
            this.updateBtn.Appearance.Options.UseFont = true;
            this.updateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateBtn.Location = new System.Drawing.Point(407, 3);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.updateBtn.Size = new System.Drawing.Size(75, 23);
            this.updateBtn.TabIndex = 2;
            this.updateBtn.Text = "수정";
            // 
            // insertBtn
            // 
            this.insertBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.insertBtn.Appearance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.insertBtn.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertBtn.Appearance.Options.UseBackColor = true;
            this.insertBtn.Appearance.Options.UseFont = true;
            this.insertBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.insertBtn.Location = new System.Drawing.Point(326, 3);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.insertBtn.Size = new System.Drawing.Size(75, 23);
            this.insertBtn.TabIndex = 1;
            this.insertBtn.Text = "추가";
            // 
            // deptListGrid
            // 
            this.deptListGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deptListGrid.Location = new System.Drawing.Point(0, 34);
            this.deptListGrid.MainView = this.gridView1;
            this.deptListGrid.Name = "deptListGrid";
            this.deptListGrid.Size = new System.Drawing.Size(800, 416);
            this.deptListGrid.TabIndex = 2;
            this.deptListGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.White;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DeptCode,
            this.DeptName,
            this.DeptMemo});
            this.gridView1.GridControl = this.deptListGrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // DeptCode
            // 
            this.DeptCode.Caption = "부서코드";
            this.DeptCode.FieldName = "Code";
            this.DeptCode.Name = "DeptCode";
            this.DeptCode.Visible = true;
            this.DeptCode.VisibleIndex = 0;
            // 
            // DeptName
            // 
            this.DeptName.Caption = "부서명";
            this.DeptName.FieldName = "Name";
            this.DeptName.Name = "DeptName";
            this.DeptName.Visible = true;
            this.DeptName.VisibleIndex = 1;
            // 
            // DeptMemo
            // 
            this.DeptMemo.Caption = "메모";
            this.DeptMemo.FieldName = "Memo";
            this.DeptMemo.Name = "DeptMemo";
            this.DeptMemo.Visible = true;
            this.DeptMemo.VisibleIndex = 2;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.mainImgBox);
            this.panelControl2.Location = new System.Drawing.Point(3, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(141, 28);
            this.panelControl2.TabIndex = 2;
            // 
            // mainImgBox
            // 
            this.mainImgBox.Location = new System.Drawing.Point(3, 3);
            this.mainImgBox.Name = "mainImgBox";
            this.mainImgBox.Properties.Appearance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mainImgBox.Properties.Appearance.Options.UseBackColor = true;
            this.mainImgBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.mainImgBox.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.mainImgBox.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.mainImgBox.Size = new System.Drawing.Size(33, 22);
            this.mainImgBox.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(33, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 20);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "부서";
            // 
            // ApiDeptList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deptListGrid);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ApiDeptList";
            this.Text = "ApiDeptList";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deptListGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainImgBox.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton delBtn;
        private DevExpress.XtraEditors.SimpleButton updateBtn;
        private DevExpress.XtraEditors.SimpleButton insertBtn;
        private DevExpress.XtraGrid.GridControl deptListGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn DeptCode;
        private DevExpress.XtraGrid.Columns.GridColumn DeptName;
        private DevExpress.XtraGrid.Columns.GridColumn DeptMemo;
        private DevExpress.XtraEditors.SimpleButton closeBtn;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PictureEdit mainImgBox;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}