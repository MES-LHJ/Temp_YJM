namespace WindowsFormsApp1
{
    partial class InsertEmployee
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
            this.label1 = new System.Windows.Forms.Label();
            this.deptCodeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.deptNameBox = new System.Windows.Forms.TextBox();
            this.empCodeBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.empNameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.loginIdBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.passwdBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.empRankBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.empTypeBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.messageIdBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.memoBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.cancleBtn = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.womenCheckBox = new System.Windows.Forms.CheckBox();
            this.menCheckBox = new System.Windows.Forms.CheckBox();
            this.imgInsertBox = new System.Windows.Forms.PictureBox();
            this.imgSelectBtn = new System.Windows.Forms.Button();
            this.imgDelBtn = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgInsertBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(572, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "사원추가";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "부서코드";
            // 
            // deptCodeComboBox
            // 
            this.deptCodeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deptCodeComboBox.FormattingEnabled = true;
            this.deptCodeComboBox.Location = new System.Drawing.Point(14, 67);
            this.deptCodeComboBox.Name = "deptCodeComboBox";
            this.deptCodeComboBox.Size = new System.Drawing.Size(150, 20);
            this.deptCodeComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "부서명";
            // 
            // deptNameBox
            // 
            this.deptNameBox.Location = new System.Drawing.Point(198, 66);
            this.deptNameBox.Name = "deptNameBox";
            this.deptNameBox.ReadOnly = true;
            this.deptNameBox.Size = new System.Drawing.Size(150, 21);
            this.deptNameBox.TabIndex = 5;
            // 
            // empCodeBox
            // 
            this.empCodeBox.Location = new System.Drawing.Point(14, 132);
            this.empCodeBox.Name = "empCodeBox";
            this.empCodeBox.Size = new System.Drawing.Size(150, 21);
            this.empCodeBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "사원코드";
            // 
            // empNameBox
            // 
            this.empNameBox.Location = new System.Drawing.Point(198, 132);
            this.empNameBox.Name = "empNameBox";
            this.empNameBox.Size = new System.Drawing.Size(150, 21);
            this.empNameBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(196, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "사원명";
            // 
            // loginIdBox
            // 
            this.loginIdBox.Location = new System.Drawing.Point(14, 200);
            this.loginIdBox.Name = "loginIdBox";
            this.loginIdBox.Size = new System.Drawing.Size(150, 21);
            this.loginIdBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(12, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "로그인ID";
            // 
            // passwdBox
            // 
            this.passwdBox.Location = new System.Drawing.Point(198, 200);
            this.passwdBox.Name = "passwdBox";
            this.passwdBox.PasswordChar = '*';
            this.passwdBox.Size = new System.Drawing.Size(150, 21);
            this.passwdBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(196, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "비밀번호";
            // 
            // empRankBox
            // 
            this.empRankBox.Location = new System.Drawing.Point(14, 272);
            this.empRankBox.Name = "empRankBox";
            this.empRankBox.Size = new System.Drawing.Size(150, 21);
            this.empRankBox.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "직위";
            // 
            // empTypeBox
            // 
            this.empTypeBox.Location = new System.Drawing.Point(198, 272);
            this.empTypeBox.Name = "empTypeBox";
            this.empTypeBox.Size = new System.Drawing.Size(150, 21);
            this.empTypeBox.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(196, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "고용형태";
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(14, 343);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(150, 21);
            this.phoneBox.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "휴대전화";
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(198, 343);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(150, 21);
            this.emailBox.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(196, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "이메일";
            // 
            // messageIdBox
            // 
            this.messageIdBox.Location = new System.Drawing.Point(391, 343);
            this.messageIdBox.Name = "messageIdBox";
            this.messageIdBox.Size = new System.Drawing.Size(150, 21);
            this.messageIdBox.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(389, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 12);
            this.label11.TabIndex = 22;
            this.label11.Text = "메신저ID";
            // 
            // memoBox
            // 
            this.memoBox.Location = new System.Drawing.Point(14, 409);
            this.memoBox.Name = "memoBox";
            this.memoBox.Size = new System.Drawing.Size(527, 21);
            this.memoBox.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 386);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "메모";
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.addBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.addBtn.FlatAppearance.BorderSize = 0;
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Location = new System.Drawing.Point(307, 447);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(98, 26);
            this.addBtn.TabIndex = 26;
            this.addBtn.Text = "저장";
            this.addBtn.UseVisualStyleBackColor = false;
            // 
            // cancleBtn
            // 
            this.cancleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cancleBtn.FlatAppearance.BorderSize = 0;
            this.cancleBtn.ForeColor = System.Drawing.Color.White;
            this.cancleBtn.Location = new System.Drawing.Point(427, 447);
            this.cancleBtn.Name = "cancleBtn";
            this.cancleBtn.Size = new System.Drawing.Size(98, 26);
            this.cancleBtn.TabIndex = 27;
            this.cancleBtn.Text = "취소";
            this.cancleBtn.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(389, 225);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 58;
            this.label13.Text = "성별";
            // 
            // womenCheckBox
            // 
            this.womenCheckBox.AutoSize = true;
            this.womenCheckBox.Location = new System.Drawing.Point(433, 250);
            this.womenCheckBox.Name = "womenCheckBox";
            this.womenCheckBox.Size = new System.Drawing.Size(36, 16);
            this.womenCheckBox.TabIndex = 57;
            this.womenCheckBox.Text = "여";
            this.womenCheckBox.UseVisualStyleBackColor = true;
            // 
            // menCheckBox
            // 
            this.menCheckBox.AutoSize = true;
            this.menCheckBox.Location = new System.Drawing.Point(391, 250);
            this.menCheckBox.Name = "menCheckBox";
            this.menCheckBox.Size = new System.Drawing.Size(36, 16);
            this.menCheckBox.TabIndex = 56;
            this.menCheckBox.Text = "남";
            this.menCheckBox.UseVisualStyleBackColor = true;
            // 
            // imgInsertBox
            // 
            this.imgInsertBox.Location = new System.Drawing.Point(391, 43);
            this.imgInsertBox.Name = "imgInsertBox";
            this.imgInsertBox.Size = new System.Drawing.Size(140, 110);
            this.imgInsertBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgInsertBox.TabIndex = 59;
            this.imgInsertBox.TabStop = false;
            // 
            // imgSelectBtn
            // 
            this.imgSelectBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.imgSelectBtn.ForeColor = System.Drawing.Color.White;
            this.imgSelectBtn.Location = new System.Drawing.Point(415, 177);
            this.imgSelectBtn.Name = "imgSelectBtn";
            this.imgSelectBtn.Size = new System.Drawing.Size(90, 23);
            this.imgSelectBtn.TabIndex = 60;
            this.imgSelectBtn.Text = "이미지 선택";
            this.imgSelectBtn.UseVisualStyleBackColor = false;
            // 
            // imgDelBtn
            // 
            this.imgDelBtn.Location = new System.Drawing.Point(521, 32);
            this.imgDelBtn.Name = "imgDelBtn";
            this.imgDelBtn.Size = new System.Drawing.Size(20, 23);
            this.imgDelBtn.TabIndex = 61;
            this.imgDelBtn.Text = "x";
            this.imgDelBtn.UseVisualStyleBackColor = true;
            // 
            // InsertEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 485);
            this.Controls.Add(this.imgDelBtn);
            this.Controls.Add(this.imgSelectBtn);
            this.Controls.Add(this.imgInsertBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.womenCheckBox);
            this.Controls.Add(this.menCheckBox);
            this.Controls.Add(this.cancleBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.memoBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.messageIdBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.phoneBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.empTypeBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.empRankBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.passwdBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.loginIdBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.empNameBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.empCodeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deptNameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deptCodeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "InsertEmployee";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.AddEmployee_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgInsertBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox deptCodeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox deptNameBox;
        private System.Windows.Forms.TextBox empCodeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox empNameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox loginIdBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passwdBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox empRankBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox empTypeBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox messageIdBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox memoBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button cancleBtn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox womenCheckBox;
        private System.Windows.Forms.CheckBox menCheckBox;
        private System.Windows.Forms.PictureBox imgInsertBox;
        private System.Windows.Forms.Button imgSelectBtn;
        private System.Windows.Forms.Button imgDelBtn;
    }
}