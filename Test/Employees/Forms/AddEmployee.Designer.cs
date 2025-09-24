namespace Test.Employees.Forms
{
    partial class AddEmployee
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
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.mainDeptCodeCombo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.mainDeptNameBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.empCodeBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.empNameBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.loginIdBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.passwdBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.empRankBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.empTypeBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.phoneBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.emailBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.messIdBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.memoBox = new DevExpress.XtraEditors.TextEdit();
            this.menCheckBox = new DevExpress.XtraEditors.CheckEdit();
            this.womenCheckBox = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.subDeptCodeCombo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.subDeptNameBox = new DevExpress.XtraEditors.TextEdit();
            this.insertBtn = new DevExpress.XtraEditors.SimpleButton();
            this.closeBtn = new DevExpress.XtraEditors.SimpleButton();
            this.imgBox = new DevExpress.XtraEditors.PictureEdit();
            this.imgSelectBtn = new DevExpress.XtraEditors.SimpleButton();
            this.imgDelBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptCodeCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptNameBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empCodeBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empNameBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginIdBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwdBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empRankBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empTypeBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messIdBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menCheckBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.womenCheckBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDeptCodeCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDeptNameBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "사원 추가";
            this.barStaticItem1.Id = 0;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(421, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 553);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(421, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 533);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(421, 20);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 533);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(22, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "상위 부서 코드";
            // 
            // mainDeptCodeCombo
            // 
            this.mainDeptCodeCombo.Location = new System.Drawing.Point(22, 65);
            this.mainDeptCodeCombo.MenuManager = this.barManager1;
            this.mainDeptCodeCombo.Name = "mainDeptCodeCombo";
            this.mainDeptCodeCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mainDeptCodeCombo.Size = new System.Drawing.Size(100, 20);
            this.mainDeptCodeCombo.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(159, 45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "상위 부서명";
            // 
            // mainDeptNameBox
            // 
            this.mainDeptNameBox.Location = new System.Drawing.Point(159, 65);
            this.mainDeptNameBox.MenuManager = this.barManager1;
            this.mainDeptNameBox.Name = "mainDeptNameBox";
            this.mainDeptNameBox.Properties.ReadOnly = true;
            this.mainDeptNameBox.Size = new System.Drawing.Size(100, 20);
            this.mainDeptNameBox.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(22, 153);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 14);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "사원 코드";
            // 
            // empCodeBox
            // 
            this.empCodeBox.Location = new System.Drawing.Point(22, 173);
            this.empCodeBox.MenuManager = this.barManager1;
            this.empCodeBox.Name = "empCodeBox";
            this.empCodeBox.Size = new System.Drawing.Size(100, 20);
            this.empCodeBox.TabIndex = 9;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(159, 153);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(30, 14);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "사원명";
            // 
            // empNameBox
            // 
            this.empNameBox.Location = new System.Drawing.Point(159, 173);
            this.empNameBox.MenuManager = this.barManager1;
            this.empNameBox.Name = "empNameBox";
            this.empNameBox.Size = new System.Drawing.Size(100, 20);
            this.empNameBox.TabIndex = 11;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(22, 209);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(42, 14);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "로그인ID";
            // 
            // loginIdBox
            // 
            this.loginIdBox.Location = new System.Drawing.Point(22, 229);
            this.loginIdBox.MenuManager = this.barManager1;
            this.loginIdBox.Name = "loginIdBox";
            this.loginIdBox.Size = new System.Drawing.Size(100, 20);
            this.loginIdBox.TabIndex = 13;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(159, 209);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(40, 14);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "비밀번호";
            // 
            // passwdBox
            // 
            this.passwdBox.Location = new System.Drawing.Point(159, 229);
            this.passwdBox.MenuManager = this.barManager1;
            this.passwdBox.Name = "passwdBox";
            this.passwdBox.Properties.PasswordChar = '*';
            this.passwdBox.Size = new System.Drawing.Size(100, 20);
            this.passwdBox.TabIndex = 15;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(22, 271);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(20, 14);
            this.labelControl7.TabIndex = 16;
            this.labelControl7.Text = "직위";
            // 
            // empRankBox
            // 
            this.empRankBox.Location = new System.Drawing.Point(22, 291);
            this.empRankBox.MenuManager = this.barManager1;
            this.empRankBox.Name = "empRankBox";
            this.empRankBox.Size = new System.Drawing.Size(100, 20);
            this.empRankBox.TabIndex = 17;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(159, 271);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(40, 14);
            this.labelControl8.TabIndex = 18;
            this.labelControl8.Text = "고용상태";
            // 
            // empTypeBox
            // 
            this.empTypeBox.Location = new System.Drawing.Point(159, 291);
            this.empTypeBox.MenuManager = this.barManager1;
            this.empTypeBox.Name = "empTypeBox";
            this.empTypeBox.Size = new System.Drawing.Size(100, 20);
            this.empTypeBox.TabIndex = 19;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(22, 331);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(40, 14);
            this.labelControl9.TabIndex = 20;
            this.labelControl9.Text = "휴대전화";
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(22, 351);
            this.phoneBox.MenuManager = this.barManager1;
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(100, 20);
            this.phoneBox.TabIndex = 21;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(159, 331);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(30, 14);
            this.labelControl10.TabIndex = 22;
            this.labelControl10.Text = "이메일";
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(159, 351);
            this.emailBox.MenuManager = this.barManager1;
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(100, 20);
            this.emailBox.TabIndex = 23;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(292, 331);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(42, 14);
            this.labelControl11.TabIndex = 24;
            this.labelControl11.Text = "메신저ID";
            // 
            // messIdBox
            // 
            this.messIdBox.Location = new System.Drawing.Point(292, 351);
            this.messIdBox.MenuManager = this.barManager1;
            this.messIdBox.Name = "messIdBox";
            this.messIdBox.Size = new System.Drawing.Size(100, 20);
            this.messIdBox.TabIndex = 25;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(22, 399);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(20, 14);
            this.labelControl12.TabIndex = 26;
            this.labelControl12.Text = "메모";
            // 
            // memoBox
            // 
            this.memoBox.Location = new System.Drawing.Point(22, 419);
            this.memoBox.MenuManager = this.barManager1;
            this.memoBox.Name = "memoBox";
            this.memoBox.Size = new System.Drawing.Size(370, 20);
            this.memoBox.TabIndex = 27;
            // 
            // menCheckBox
            // 
            this.menCheckBox.Location = new System.Drawing.Point(292, 291);
            this.menCheckBox.MenuManager = this.barManager1;
            this.menCheckBox.Name = "menCheckBox";
            this.menCheckBox.Properties.Caption = "남자";
            this.menCheckBox.Size = new System.Drawing.Size(75, 20);
            this.menCheckBox.TabIndex = 28;
            // 
            // womenCheckBox
            // 
            this.womenCheckBox.Location = new System.Drawing.Point(338, 291);
            this.womenCheckBox.MenuManager = this.barManager1;
            this.womenCheckBox.Name = "womenCheckBox";
            this.womenCheckBox.Properties.Caption = "여자";
            this.womenCheckBox.Size = new System.Drawing.Size(75, 20);
            this.womenCheckBox.TabIndex = 29;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(290, 271);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(20, 14);
            this.labelControl13.TabIndex = 30;
            this.labelControl13.Text = "성별";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl15.Appearance.Options.UseForeColor = true;
            this.labelControl15.Location = new System.Drawing.Point(22, 100);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(68, 14);
            this.labelControl15.TabIndex = 31;
            this.labelControl15.Text = "하위 부서 코드";
            // 
            // subDeptCodeCombo
            // 
            this.subDeptCodeCombo.Location = new System.Drawing.Point(22, 120);
            this.subDeptCodeCombo.MenuManager = this.barManager1;
            this.subDeptCodeCombo.Name = "subDeptCodeCombo";
            this.subDeptCodeCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.subDeptCodeCombo.Size = new System.Drawing.Size(100, 20);
            this.subDeptCodeCombo.TabIndex = 32;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(159, 100);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(54, 14);
            this.labelControl14.TabIndex = 33;
            this.labelControl14.Text = "하위 부서명";
            // 
            // subDeptNameBox
            // 
            this.subDeptNameBox.Location = new System.Drawing.Point(159, 120);
            this.subDeptNameBox.MenuManager = this.barManager1;
            this.subDeptNameBox.Name = "subDeptNameBox";
            this.subDeptNameBox.Properties.ReadOnly = true;
            this.subDeptNameBox.Size = new System.Drawing.Size(100, 20);
            this.subDeptNameBox.TabIndex = 34;
            // 
            // insertBtn
            // 
            this.insertBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.insertBtn.Appearance.ForeColor = System.Drawing.Color.White;
            this.insertBtn.Appearance.Options.UseBackColor = true;
            this.insertBtn.Appearance.Options.UseForeColor = true;
            this.insertBtn.Location = new System.Drawing.Point(92, 473);
            this.insertBtn.LookAndFeel.UseDefaultLookAndFeel = false;
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(75, 23);
            this.insertBtn.TabIndex = 39;
            this.insertBtn.Text = "저장";
            // 
            // closeBtn
            // 
            this.closeBtn.Appearance.BackColor = System.Drawing.Color.Silver;
            this.closeBtn.Appearance.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Appearance.Options.UseBackColor = true;
            this.closeBtn.Appearance.Options.UseForeColor = true;
            this.closeBtn.Location = new System.Drawing.Point(235, 473);
            this.closeBtn.LookAndFeel.UseDefaultLookAndFeel = false;
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 40;
            this.closeBtn.Text = "닫기";
            // 
            // imgBox
            // 
            this.imgBox.Location = new System.Drawing.Point(292, 71);
            this.imgBox.MenuManager = this.barManager1;
            this.imgBox.Name = "imgBox";
            this.imgBox.Properties.AllowZoom = DevExpress.Utils.DefaultBoolean.True;
            this.imgBox.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.imgBox.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.imgBox.Size = new System.Drawing.Size(100, 96);
            this.imgBox.TabIndex = 45;
            // 
            // imgSelectBtn
            // 
            this.imgSelectBtn.Location = new System.Drawing.Point(304, 185);
            this.imgSelectBtn.Name = "imgSelectBtn";
            this.imgSelectBtn.Size = new System.Drawing.Size(75, 23);
            this.imgSelectBtn.TabIndex = 46;
            this.imgSelectBtn.Text = "선택";
            // 
            // imgDelBtn
            // 
            this.imgDelBtn.Location = new System.Drawing.Point(391, 62);
            this.imgDelBtn.Name = "imgDelBtn";
            this.imgDelBtn.Size = new System.Drawing.Size(18, 23);
            this.imgDelBtn.TabIndex = 47;
            this.imgDelBtn.Text = "x";
            // 
            // AddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 553);
            this.Controls.Add(this.imgDelBtn);
            this.Controls.Add(this.imgSelectBtn);
            this.Controls.Add(this.imgBox);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.insertBtn);
            this.Controls.Add(this.subDeptNameBox);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.subDeptCodeCombo);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.womenCheckBox);
            this.Controls.Add(this.menCheckBox);
            this.Controls.Add(this.memoBox);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.messIdBox);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.phoneBox);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.empTypeBox);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.empRankBox);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.passwdBox);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.loginIdBox);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.empNameBox);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.empCodeBox);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.mainDeptNameBox);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.mainDeptCodeCombo);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "AddEmployee";
            this.Text = "AddEmployee";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptCodeCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptNameBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empCodeBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empNameBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginIdBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwdBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empRankBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empTypeBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messIdBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menCheckBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.womenCheckBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDeptCodeCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDeptNameBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SimpleButton imgDelBtn;
        private DevExpress.XtraEditors.SimpleButton imgSelectBtn;
        private DevExpress.XtraEditors.PictureEdit imgBox;
        private DevExpress.XtraEditors.SimpleButton closeBtn;
        private DevExpress.XtraEditors.SimpleButton insertBtn;
        private DevExpress.XtraEditors.TextEdit subDeptNameBox;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.ComboBoxEdit subDeptCodeCombo;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.CheckEdit womenCheckBox;
        private DevExpress.XtraEditors.CheckEdit menCheckBox;
        private DevExpress.XtraEditors.TextEdit memoBox;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit messIdBox;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit emailBox;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit phoneBox;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit empTypeBox;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit empRankBox;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit passwdBox;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit loginIdBox;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit empNameBox;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit empCodeBox;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit mainDeptNameBox;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit mainDeptCodeCombo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}