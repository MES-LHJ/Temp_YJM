namespace WindowsFormsApp1
{
    partial class DepartmentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentList));
            this.deptListToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.deptInsertBtn = new System.Windows.Forms.ToolStripButton();
            this.deptUpdateBtn = new System.Windows.Forms.ToolStripButton();
            this.deptDelBtn = new System.Windows.Forms.ToolStripButton();
            this.closeBtn = new System.Windows.Forms.ToolStripButton();
            this.chartBtn = new System.Windows.Forms.ToolStripButton();
            this.deptListView = new System.Windows.Forms.DataGridView();
            this.departmentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptListToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deptListView)).BeginInit();
            this.SuspendLayout();
            // 
            // deptListToolStrip
            // 
            this.deptListToolStrip.AutoSize = false;
            this.deptListToolStrip.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.deptListToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.closeBtn,
            this.chartBtn,
            this.deptDelBtn,
            this.deptUpdateBtn,
            this.deptInsertBtn});
            this.deptListToolStrip.Location = new System.Drawing.Point(0, 0);
            this.deptListToolStrip.Name = "deptListToolStrip";
            this.deptListToolStrip.Size = new System.Drawing.Size(629, 25);
            this.deptListToolStrip.TabIndex = 0;
            this.deptListToolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "부서사원";
            // 
            // deptInsertBtn
            // 
            this.deptInsertBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.deptInsertBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deptInsertBtn.Image = ((System.Drawing.Image)(resources.GetObject("deptInsertBtn.Image")));
            this.deptInsertBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deptInsertBtn.Name = "deptInsertBtn";
            this.deptInsertBtn.Size = new System.Drawing.Size(35, 22);
            this.deptInsertBtn.Text = "추가";
            // 
            // deptUpdateBtn
            // 
            this.deptUpdateBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.deptUpdateBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deptUpdateBtn.Image = ((System.Drawing.Image)(resources.GetObject("deptUpdateBtn.Image")));
            this.deptUpdateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deptUpdateBtn.Name = "deptUpdateBtn";
            this.deptUpdateBtn.Size = new System.Drawing.Size(35, 22);
            this.deptUpdateBtn.Text = "수정";
            // 
            // deptDelBtn
            // 
            this.deptDelBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.deptDelBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deptDelBtn.Image = ((System.Drawing.Image)(resources.GetObject("deptDelBtn.Image")));
            this.deptDelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deptDelBtn.Name = "deptDelBtn";
            this.deptDelBtn.Size = new System.Drawing.Size(35, 22);
            this.deptDelBtn.Text = "삭제";
            // 
            // closeBtn
            // 
            this.closeBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.closeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(35, 22);
            this.closeBtn.Text = "닫기";
            // 
            // chartBtn
            // 
            this.chartBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.chartBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chartBtn.Image = ((System.Drawing.Image)(resources.GetObject("chartBtn.Image")));
            this.chartBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chartBtn.Name = "chartBtn";
            this.chartBtn.Size = new System.Drawing.Size(35, 22);
            this.chartBtn.Text = "차트";
            // 
            // deptListView
            // 
            this.deptListView.BackgroundColor = System.Drawing.Color.White;
            this.deptListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deptListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.departmentCode,
            this.departmentName,
            this.memo});
            this.deptListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deptListView.Location = new System.Drawing.Point(0, 25);
            this.deptListView.Name = "deptListView";
            this.deptListView.RowTemplate.Height = 23;
            this.deptListView.Size = new System.Drawing.Size(629, 425);
            this.deptListView.TabIndex = 1;
            // 
            // departmentCode
            // 
            this.departmentCode.DataPropertyName = "departmentCode";
            this.departmentCode.HeaderText = "부서코드";
            this.departmentCode.Name = "departmentCode";
            // 
            // departmentName
            // 
            this.departmentName.DataPropertyName = "departmentName";
            this.departmentName.HeaderText = "부서명";
            this.departmentName.Name = "departmentName";
            // 
            // memo
            // 
            this.memo.DataPropertyName = "memo";
            this.memo.HeaderText = "메모";
            this.memo.Name = "memo";
            // 
            // DepartmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 450);
            this.Controls.Add(this.deptListView);
            this.Controls.Add(this.deptListToolStrip);
            this.Name = "DepartmentList";
            this.Text = "Form6";
            this.deptListToolStrip.ResumeLayout(false);
            this.deptListToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deptListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip deptListToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton closeBtn;
        private System.Windows.Forms.ToolStripButton deptInsertBtn;
        private System.Windows.Forms.ToolStripButton deptUpdateBtn;
        private System.Windows.Forms.ToolStripButton deptDelBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentId;
        private System.Windows.Forms.DataGridView deptListView;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn memo;
        private System.Windows.Forms.ToolStripButton chartBtn;
    }
}