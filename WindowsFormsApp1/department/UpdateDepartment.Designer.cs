namespace WindowsFormsApp1
{
    partial class UpdateDepartment
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.memoBtn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.deptNameBtn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.deptCodeBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Silver;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(257, 213);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(98, 26);
            this.closeBtn.TabIndex = 38;
            this.closeBtn.Text = "닫기";
            this.closeBtn.UseVisualStyleBackColor = false;
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.updateBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.updateBtn.FlatAppearance.BorderSize = 0;
            this.updateBtn.ForeColor = System.Drawing.Color.White;
            this.updateBtn.Location = new System.Drawing.Point(137, 213);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(98, 26);
            this.updateBtn.TabIndex = 37;
            this.updateBtn.Text = "저장";
            this.updateBtn.UseVisualStyleBackColor = false;
            // 
            // memoBtn
            // 
            this.memoBtn.Location = new System.Drawing.Point(14, 146);
            this.memoBtn.Name = "memoBtn";
            this.memoBtn.Size = new System.Drawing.Size(334, 21);
            this.memoBtn.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "메모";
            // 
            // deptNameBtn
            // 
            this.deptNameBtn.Location = new System.Drawing.Point(198, 78);
            this.deptNameBtn.Name = "deptNameBtn";
            this.deptNameBtn.Size = new System.Drawing.Size(150, 21);
            this.deptNameBtn.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(196, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "부서명";
            // 
            // deptCodeBox
            // 
            this.deptCodeBox.Location = new System.Drawing.Point(14, 78);
            this.deptCodeBox.Name = "deptCodeBox";
            this.deptCodeBox.Size = new System.Drawing.Size(150, 21);
            this.deptCodeBox.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "부서코드";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(427, 25);
            this.toolStrip1.TabIndex = 30;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel1.Text = "부서 수정";
            // 
            // UpdateDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 275);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.memoBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.deptNameBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.deptCodeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UpdateDepartment";
            this.Text = "Form8";
            this.Load += new System.EventHandler(this.UpdateDepartment_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.TextBox memoBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox deptNameBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox deptCodeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}