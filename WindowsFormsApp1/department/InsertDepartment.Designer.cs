namespace WindowsFormsApp1
{
    partial class InsertDepartment
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.memoBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.deptNameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.deptCodeBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.insertBtn = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(416, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel1.Text = "부서 추가";
            // 
            // memoBox
            // 
            this.memoBox.Location = new System.Drawing.Point(14, 145);
            this.memoBox.Name = "memoBox";
            this.memoBox.Size = new System.Drawing.Size(334, 21);
            this.memoBox.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "메모";
            // 
            // deptNameBox
            // 
            this.deptNameBox.Location = new System.Drawing.Point(198, 77);
            this.deptNameBox.Name = "deptNameBox";
            this.deptNameBox.Size = new System.Drawing.Size(150, 21);
            this.deptNameBox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(196, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "부서명";
            // 
            // deptCodeBox
            // 
            this.deptCodeBox.Location = new System.Drawing.Point(14, 77);
            this.deptCodeBox.Name = "deptCodeBox";
            this.deptCodeBox.Size = new System.Drawing.Size(150, 21);
            this.deptCodeBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "부서코드";
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Location = new System.Drawing.Point(257, 212);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(98, 26);
            this.cancelBtn.TabIndex = 29;
            this.cancelBtn.Text = "취소";
            this.cancelBtn.UseVisualStyleBackColor = false;
            // 
            // insertBtn
            // 
            this.insertBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.insertBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.insertBtn.FlatAppearance.BorderSize = 0;
            this.insertBtn.ForeColor = System.Drawing.Color.White;
            this.insertBtn.Location = new System.Drawing.Point(137, 212);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(98, 26);
            this.insertBtn.TabIndex = 28;
            this.insertBtn.Text = "저장";
            this.insertBtn.UseVisualStyleBackColor = false;
            // 
            // InsertDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 312);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.insertBtn);
            this.Controls.Add(this.memoBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.deptNameBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.deptCodeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip1);
            this.Name = "InsertDepartment";
            this.Text = "Form7";
            this.Load += new System.EventHandler(this.InsertDepartment_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TextBox memoBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox deptNameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox deptCodeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button insertBtn;
    }
}