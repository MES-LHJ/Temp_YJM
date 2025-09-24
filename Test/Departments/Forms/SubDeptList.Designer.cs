namespace Test.Departments.Forms
{
    partial class SubDeptList
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
            this.deptListSplit = new DevExpress.XtraEditors.SplitContainerControl();
            this.mainDeptGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DepartmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Memo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.treeLIstBtn = new DevExpress.XtraBars.BarButtonItem();
            this.mainDeptListBtn = new DevExpress.XtraBars.BarButtonItem();
            this.subDeptInsertBtn = new DevExpress.XtraBars.BarButtonItem();
            this.subDeptUpdateBtn = new DevExpress.XtraBars.BarButtonItem();
            this.subDeptDelBtn = new DevExpress.XtraBars.BarButtonItem();
            this.deptChartBtn = new DevExpress.XtraBars.BarButtonItem();
            this.closeBtn = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.subDeptGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SubDeptCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SubDeptName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SubDeptMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.deptListSplit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptListSplit.Panel1)).BeginInit();
            this.deptListSplit.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deptListSplit.Panel2)).BeginInit();
            this.deptListSplit.Panel2.SuspendLayout();
            this.deptListSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDeptGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // deptListSplit
            // 
            this.deptListSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deptListSplit.Location = new System.Drawing.Point(0, 21);
            this.deptListSplit.Name = "deptListSplit";
            // 
            // deptListSplit.Panel1
            // 
            this.deptListSplit.Panel1.Controls.Add(this.mainDeptGrid);
            this.deptListSplit.Panel1.Text = "Panel1";
            // 
            // deptListSplit.Panel2
            // 
            this.deptListSplit.Panel2.Controls.Add(this.subDeptGrid);
            this.deptListSplit.Panel2.Text = "Panel2";
            this.deptListSplit.Size = new System.Drawing.Size(997, 429);
            this.deptListSplit.SplitterPosition = 506;
            this.deptListSplit.TabIndex = 9;
            // 
            // mainDeptGrid
            // 
            this.mainDeptGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDeptGrid.Location = new System.Drawing.Point(0, 0);
            this.mainDeptGrid.MainView = this.gridView1;
            this.mainDeptGrid.MenuManager = this.barManager1;
            this.mainDeptGrid.Name = "mainDeptGrid";
            this.mainDeptGrid.Size = new System.Drawing.Size(506, 429);
            this.mainDeptGrid.TabIndex = 0;
            this.mainDeptGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DepartmentCode,
            this.DepartmentName,
            this.Memo});
            this.gridView1.GridControl = this.mainDeptGrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // DepartmentCode
            // 
            this.DepartmentCode.Caption = "부서 코드";
            this.DepartmentCode.FieldName = "DepartmentCode";
            this.DepartmentCode.Name = "DepartmentCode";
            this.DepartmentCode.Visible = true;
            this.DepartmentCode.VisibleIndex = 0;
            // 
            // DepartmentName
            // 
            this.DepartmentName.Caption = "부서코드";
            this.DepartmentName.FieldName = "DepartmentName";
            this.DepartmentName.Name = "DepartmentName";
            this.DepartmentName.Visible = true;
            this.DepartmentName.VisibleIndex = 1;
            // 
            // Memo
            // 
            this.Memo.Caption = "메모";
            this.Memo.FieldName = "Memo";
            this.Memo.Name = "Memo";
            this.Memo.Visible = true;
            this.Memo.VisibleIndex = 2;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControl2);
            this.barManager1.DockControls.Add(this.barDockControl3);
            this.barManager1.DockControls.Add(this.barDockControl4);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem1,
            this.barStaticItem2,
            this.mainDeptListBtn,
            this.subDeptInsertBtn,
            this.subDeptDelBtn,
            this.subDeptUpdateBtn,
            this.deptChartBtn,
            this.treeLIstBtn,
            this.closeBtn});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 9;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.treeLIstBtn),
            new DevExpress.XtraBars.LinkPersistInfo(this.mainDeptListBtn),
            new DevExpress.XtraBars.LinkPersistInfo(this.subDeptInsertBtn),
            new DevExpress.XtraBars.LinkPersistInfo(this.subDeptUpdateBtn),
            new DevExpress.XtraBars.LinkPersistInfo(this.subDeptDelBtn),
            new DevExpress.XtraBars.LinkPersistInfo(this.deptChartBtn),
            new DevExpress.XtraBars.LinkPersistInfo(this.closeBtn)});
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "부서 목록";
            this.barStaticItem1.Id = 0;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.barStaticItem2.Id = 1;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // treeLIstBtn
            // 
            this.treeLIstBtn.Caption = "트리";
            this.treeLIstBtn.Id = 7;
            this.treeLIstBtn.Name = "treeLIstBtn";
            // 
            // mainDeptListBtn
            // 
            this.mainDeptListBtn.Caption = "상위부서";
            this.mainDeptListBtn.Id = 2;
            this.mainDeptListBtn.Name = "mainDeptListBtn";
            // 
            // subDeptInsertBtn
            // 
            this.subDeptInsertBtn.Caption = "추가";
            this.subDeptInsertBtn.Id = 3;
            this.subDeptInsertBtn.Name = "subDeptInsertBtn";
            // 
            // subDeptUpdateBtn
            // 
            this.subDeptUpdateBtn.Caption = "수정";
            this.subDeptUpdateBtn.Id = 5;
            this.subDeptUpdateBtn.Name = "subDeptUpdateBtn";
            // 
            // subDeptDelBtn
            // 
            this.subDeptDelBtn.Caption = "삭제";
            this.subDeptDelBtn.Id = 4;
            this.subDeptDelBtn.Name = "subDeptDelBtn";
            // 
            // deptChartBtn
            // 
            this.deptChartBtn.Caption = "차트";
            this.deptChartBtn.Id = 6;
            this.deptChartBtn.Name = "deptChartBtn";
            // 
            // closeBtn
            // 
            this.closeBtn.Caption = "닫기";
            this.closeBtn.Id = 8;
            this.closeBtn.Name = "closeBtn";
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManager1;
            this.barDockControl1.Size = new System.Drawing.Size(997, 21);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 450);
            this.barDockControl2.Manager = this.barManager1;
            this.barDockControl2.Size = new System.Drawing.Size(997, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 21);
            this.barDockControl3.Manager = this.barManager1;
            this.barDockControl3.Size = new System.Drawing.Size(0, 429);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(997, 21);
            this.barDockControl4.Manager = this.barManager1;
            this.barDockControl4.Size = new System.Drawing.Size(0, 429);
            // 
            // subDeptGrid
            // 
            this.subDeptGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subDeptGrid.Location = new System.Drawing.Point(0, 0);
            this.subDeptGrid.MainView = this.gridView2;
            this.subDeptGrid.Name = "subDeptGrid";
            this.subDeptGrid.Size = new System.Drawing.Size(481, 429);
            this.subDeptGrid.TabIndex = 0;
            this.subDeptGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SubDeptCode,
            this.SubDeptName,
            this.SubDeptMemo});
            this.gridView2.GridControl = this.subDeptGrid;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // SubDeptCode
            // 
            this.SubDeptCode.Caption = "부서코드";
            this.SubDeptCode.FieldName = "SubDeptCode";
            this.SubDeptCode.Name = "SubDeptCode";
            this.SubDeptCode.Visible = true;
            this.SubDeptCode.VisibleIndex = 0;
            // 
            // SubDeptName
            // 
            this.SubDeptName.Caption = "부서명";
            this.SubDeptName.FieldName = "SubDeptName";
            this.SubDeptName.Name = "SubDeptName";
            this.SubDeptName.Visible = true;
            this.SubDeptName.VisibleIndex = 1;
            // 
            // SubDeptMemo
            // 
            this.SubDeptMemo.Caption = "메모";
            this.SubDeptMemo.FieldName = "Memo";
            this.SubDeptMemo.Name = "SubDeptMemo";
            this.SubDeptMemo.Visible = true;
            this.SubDeptMemo.VisibleIndex = 2;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 21);
            this.barDockControlLeft.Manager = null;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 429);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(997, 21);
            this.barDockControlRight.Manager = null;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 429);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 450);
            this.barDockControlBottom.Manager = null;
            this.barDockControlBottom.Size = new System.Drawing.Size(997, 0);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 21);
            this.barDockControlTop.Manager = null;
            this.barDockControlTop.Size = new System.Drawing.Size(997, 0);
            // 
            // SubDeptList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 450);
            this.Controls.Add(this.deptListSplit);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "SubDeptList";
            this.Text = "SubDeptList";
            ((System.ComponentModel.ISupportInitialize)(this.deptListSplit.Panel1)).EndInit();
            this.deptListSplit.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deptListSplit.Panel2)).EndInit();
            this.deptListSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deptListSplit)).EndInit();
            this.deptListSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDeptGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDeptGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl deptListSplit;
        private DevExpress.XtraGrid.GridControl subDeptGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn SubDeptCode;
        private DevExpress.XtraGrid.Columns.GridColumn SubDeptName;
        private DevExpress.XtraGrid.Columns.GridColumn SubDeptMemo;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarButtonItem mainDeptListBtn;
        private DevExpress.XtraBars.BarButtonItem subDeptInsertBtn;
        private DevExpress.XtraBars.BarButtonItem subDeptDelBtn;
        private DevExpress.XtraBars.BarButtonItem subDeptUpdateBtn;
        private DevExpress.XtraBars.BarButtonItem deptChartBtn;
        private DevExpress.XtraBars.BarButtonItem treeLIstBtn;
        private DevExpress.XtraGrid.GridControl mainDeptGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn DepartmentCode;
        private DevExpress.XtraGrid.Columns.GridColumn DepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn Memo;
        private DevExpress.XtraBars.BarButtonItem closeBtn;
    }
}