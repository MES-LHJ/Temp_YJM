namespace WindowsFormsApp1
{
    partial class DelDepartment
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.deptNameLabel = new System.Windows.Forms.Label();
            this.deptCodeLabel = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Silver;
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Location = new System.Drawing.Point(148, 155);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(98, 26);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "취소";
            this.cancelBtn.UseVisualStyleBackColor = false;
            // 
            // delBtn
            // 
            this.delBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.delBtn.ForeColor = System.Drawing.Color.White;
            this.delBtn.Location = new System.Drawing.Point(47, 155);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(98, 26);
            this.delBtn.TabIndex = 10;
            this.delBtn.Text = "삭제";
            this.delBtn.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "삭제하시겠습니까?";
            // 
            // deptNameLabel
            // 
            this.deptNameLabel.AutoSize = true;
            this.deptNameLabel.Location = new System.Drawing.Point(12, 69);
            this.deptNameLabel.Name = "deptNameLabel";
            this.deptNameLabel.Size = new System.Drawing.Size(38, 12);
            this.deptNameLabel.TabIndex = 8;
            this.deptNameLabel.Text = "label2";
            // 
            // deptCodeLabel
            // 
            this.deptCodeLabel.AutoSize = true;
            this.deptCodeLabel.Location = new System.Drawing.Point(12, 46);
            this.deptCodeLabel.Name = "deptCodeLabel";
            this.deptCodeLabel.Size = new System.Drawing.Size(38, 12);
            this.deptCodeLabel.TabIndex = 7;
            this.deptCodeLabel.Text = "label1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(309, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel1.Text = "부서 삭제";
            // 
            // DelDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 236);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deptNameLabel);
            this.Controls.Add(this.deptCodeLabel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DelDepartment";
            this.Text = "Form9";
            this.Load += new System.EventHandler(this.DelDepartment_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label deptNameLabel;
        private System.Windows.Forms.Label deptCodeLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}