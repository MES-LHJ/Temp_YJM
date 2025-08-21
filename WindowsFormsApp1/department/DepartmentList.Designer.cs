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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.deptInsertBtn = new System.Windows.Forms.ToolStripButton();
            this.deptUpdateBtn = new System.Windows.Forms.ToolStripButton();
            this.deptDelBtn = new System.Windows.Forms.ToolStripButton();
            this.closeBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.deptInsertBtn,
            this.deptUpdateBtn,
            this.deptDelBtn,
            this.closeBtn,
            this.toolStripButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(682, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "부서사원";
            // 
            // deptInsertBtn
            // 
            this.deptInsertBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deptInsertBtn.Image = ((System.Drawing.Image)(resources.GetObject("deptInsertBtn.Image")));
            this.deptInsertBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deptInsertBtn.Margin = new System.Windows.Forms.Padding(400, 1, 0, 2);
            this.deptInsertBtn.Name = "deptInsertBtn";
            this.deptInsertBtn.Size = new System.Drawing.Size(35, 22);
            this.deptInsertBtn.Text = "추가";
            this.deptInsertBtn.Click += new System.EventHandler(this.Insert_Button);
            // 
            // deptUpdateBtn
            // 
            this.deptUpdateBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deptUpdateBtn.Image = ((System.Drawing.Image)(resources.GetObject("deptUpdateBtn.Image")));
            this.deptUpdateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deptUpdateBtn.Name = "deptUpdateBtn";
            this.deptUpdateBtn.Size = new System.Drawing.Size(35, 22);
            this.deptUpdateBtn.Text = "수정";
            this.deptUpdateBtn.Click += new System.EventHandler(this.Update_Button);
            // 
            // deptDelBtn
            // 
            this.deptDelBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deptDelBtn.Image = ((System.Drawing.Image)(resources.GetObject("deptDelBtn.Image")));
            this.deptDelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deptDelBtn.Name = "deptDelBtn";
            this.deptDelBtn.Size = new System.Drawing.Size(35, 22);
            this.deptDelBtn.Text = "삭제";
            this.deptDelBtn.Click += new System.EventHandler(this.Del_Button);
            // 
            // closeBtn
            // 
            this.closeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(35, 22);
            this.closeBtn.Text = "닫기";
            this.closeBtn.Click += new System.EventHandler(this.Close_Btn);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(59, 22);
            this.toolStripButton5.Text = "새로고침";
            this.toolStripButton5.Click += new System.EventHandler(this.Form6_Load);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.department,
            this.departmentName,
            this.memo});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(682, 425);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Cell_Click);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // department
            // 
            this.department.HeaderText = "부서코드";
            this.department.Name = "department";
            // 
            // departmentName
            // 
            this.departmentName.HeaderText = "부서명";
            this.departmentName.Name = "departmentName";
            // 
            // memo
            // 
            this.memo.HeaderText = "메모";
            this.memo.Name = "memo";
            // 
            // DepartmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DepartmentList";
            this.Text = "Form6";
            this.Load += new System.EventHandler(this.Form6_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton closeBtn;
        private System.Windows.Forms.ToolStripButton deptInsertBtn;
        private System.Windows.Forms.ToolStripButton deptUpdateBtn;
        private System.Windows.Forms.ToolStripButton deptDelBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentId;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn department;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn memo;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
    }
}