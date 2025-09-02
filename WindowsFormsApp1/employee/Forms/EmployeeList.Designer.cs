namespace WindowsFormsApp1
{
    partial class EmployeeList
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeList));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.empListToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.closeBtn = new System.Windows.Forms.ToolStripButton();
            this.excelExportBtn = new System.Windows.Forms.ToolStripButton();
            this.empDelBtn = new System.Windows.Forms.ToolStripButton();
            this.loginInfoBtn = new System.Windows.Forms.ToolStripButton();
            this.empUpdateBtn = new System.Windows.Forms.ToolStripButton();
            this.empAddBtn = new System.Windows.Forms.ToolStripButton();
            this.empListBtn = new System.Windows.Forms.ToolStripButton();
            this.deptListBtn = new System.Windows.Forms.ToolStripButton();
            this.empListView = new System.Windows.Forms.DataGridView();
            this.departmentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empListToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empListView)).BeginInit();
            this.SuspendLayout();
            // 
            // empListToolStrip
            // 
            this.empListToolStrip.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.empListToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.closeBtn,
            this.excelExportBtn,
            this.empDelBtn,
            this.loginInfoBtn,
            this.empUpdateBtn,
            this.empAddBtn,
            this.empListBtn,
            this.deptListBtn});
            this.empListToolStrip.Location = new System.Drawing.Point(0, 0);
            this.empListToolStrip.Name = "empListToolStrip";
            this.empListToolStrip.Size = new System.Drawing.Size(1011, 25);
            this.empListToolStrip.TabIndex = 0;
            this.empListToolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "부서코드";
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
            // excelExportBtn
            // 
            this.excelExportBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.excelExportBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.excelExportBtn.Image = ((System.Drawing.Image)(resources.GetObject("excelExportBtn.Image")));
            this.excelExportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.excelExportBtn.Name = "excelExportBtn";
            this.excelExportBtn.Size = new System.Drawing.Size(59, 22);
            this.excelExportBtn.Text = "자료변환";
            // 
            // empDelBtn
            // 
            this.empDelBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.empDelBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.empDelBtn.Image = ((System.Drawing.Image)(resources.GetObject("empDelBtn.Image")));
            this.empDelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.empDelBtn.Name = "empDelBtn";
            this.empDelBtn.Size = new System.Drawing.Size(35, 22);
            this.empDelBtn.Text = "삭제";
            // 
            // loginInfoBtn
            // 
            this.loginInfoBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.loginInfoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loginInfoBtn.Image = ((System.Drawing.Image)(resources.GetObject("loginInfoBtn.Image")));
            this.loginInfoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loginInfoBtn.Name = "loginInfoBtn";
            this.loginInfoBtn.Size = new System.Drawing.Size(71, 22);
            this.loginInfoBtn.Text = "로그인정보";
            // 
            // empUpdateBtn
            // 
            this.empUpdateBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.empUpdateBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.empUpdateBtn.Image = ((System.Drawing.Image)(resources.GetObject("empUpdateBtn.Image")));
            this.empUpdateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.empUpdateBtn.Name = "empUpdateBtn";
            this.empUpdateBtn.Size = new System.Drawing.Size(35, 22);
            this.empUpdateBtn.Text = "수정";
            // 
            // empAddBtn
            // 
            this.empAddBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.empAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.empAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("empAddBtn.Image")));
            this.empAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.empAddBtn.Name = "empAddBtn";
            this.empAddBtn.Size = new System.Drawing.Size(35, 22);
            this.empAddBtn.Text = "추가";
            // 
            // empListBtn
            // 
            this.empListBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.empListBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.empListBtn.Image = ((System.Drawing.Image)(resources.GetObject("empListBtn.Image")));
            this.empListBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.empListBtn.Name = "empListBtn";
            this.empListBtn.Size = new System.Drawing.Size(35, 22);
            this.empListBtn.Text = "조회";
            // 
            // deptListBtn
            // 
            this.deptListBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.deptListBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deptListBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deptListBtn.Name = "deptListBtn";
            this.deptListBtn.Size = new System.Drawing.Size(35, 22);
            this.deptListBtn.Text = "부서";
            // 
            // empListView
            // 
            this.empListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.empListView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.empListView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.empListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.departmentCode,
            this.departmentName,
            this.employeeCode,
            this.employeeName,
            this.loginId,
            this.passwd,
            this.employeeRank,
            this.employeeType,
            this.phone,
            this.email,
            this.messId,
            this.memo});
            this.empListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.empListView.Location = new System.Drawing.Point(0, 25);
            this.empListView.Name = "empListView";
            this.empListView.ReadOnly = true;
            this.empListView.RowTemplate.Height = 23;
            this.empListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.empListView.Size = new System.Drawing.Size(1011, 381);
            this.empListView.TabIndex = 1;
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
            // employeeCode
            // 
            this.employeeCode.DataPropertyName = "employeeCode";
            this.employeeCode.HeaderText = "사원코드";
            this.employeeCode.Name = "employeeCode";
            // 
            // employeeName
            // 
            this.employeeName.DataPropertyName = "employeeName";
            this.employeeName.HeaderText = "사원명";
            this.employeeName.Name = "employeeName";
            // 
            // loginId
            // 
            this.loginId.DataPropertyName = "loginId";
            this.loginId.HeaderText = "로그인ID";
            this.loginId.Name = "loginId";
            // 
            // passwd
            // 
            this.passwd.DataPropertyName = "passwdMask";
            this.passwd.HeaderText = "비밀번호";
            this.passwd.Name = "passwd";
            // 
            // employeeRank
            // 
            this.employeeRank.DataPropertyName = "employeeRank";
            this.employeeRank.HeaderText = "직위";
            this.employeeRank.Name = "employeeRank";
            // 
            // employeeType
            // 
            this.employeeType.DataPropertyName = "employeeType";
            this.employeeType.HeaderText = "고용형태";
            this.employeeType.Name = "employeeType";
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phone";
            this.phone.HeaderText = "전화번호";
            this.phone.Name = "phone";
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "이메일";
            this.email.Name = "email";
            // 
            // messId
            // 
            this.messId.DataPropertyName = "messId";
            this.messId.HeaderText = "메시지ID";
            this.messId.Name = "messId";
            // 
            // memo
            // 
            this.memo.DataPropertyName = "memo";
            this.memo.HeaderText = "메모";
            this.memo.Name = "memo";
            // 
            // EmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 406);
            this.Controls.Add(this.empListView);
            this.Controls.Add(this.empListToolStrip);
            this.Name = "EmployeeList";
            this.empListToolStrip.ResumeLayout(false);
            this.empListToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStrip empListToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton deptListBtn;
        private System.Windows.Forms.ToolStripButton empListBtn;
        private System.Windows.Forms.ToolStripButton empAddBtn;
        private System.Windows.Forms.ToolStripButton empUpdateBtn;
        private System.Windows.Forms.ToolStripButton loginInfoBtn;
        private System.Windows.Forms.ToolStripButton empDelBtn;
        private System.Windows.Forms.ToolStripButton excelExportBtn;
        private System.Windows.Forms.ToolStripButton closeBtn;
        private System.Windows.Forms.DataGridView empListView;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginId;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn messId;
        private System.Windows.Forms.DataGridViewTextBoxColumn memo;
    }
}

