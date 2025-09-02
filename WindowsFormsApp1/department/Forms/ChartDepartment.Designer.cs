namespace WindowsFormsApp1.department.Forms
{
    partial class ChartDepartment
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.deptChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.deptChart)).BeginInit();
            this.SuspendLayout();
            // 
            // deptChart
            // 
            chartArea1.Name = "ChartArea1";
            this.deptChart.ChartAreas.Add(chartArea1);
            this.deptChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.deptChart.Legends.Add(legend1);
            this.deptChart.Location = new System.Drawing.Point(0, 0);
            this.deptChart.Name = "deptChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "department";
            this.deptChart.Series.Add(series1);
            this.deptChart.Size = new System.Drawing.Size(800, 450);
            this.deptChart.TabIndex = 0;
            this.deptChart.Text = "chart1";
            // 
            // ChartDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deptChart);
            this.Name = "ChartDepartment";
            this.Text = "ChartDepartment";
            ((System.ComponentModel.ISupportInitialize)(this.deptChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart deptChart;
    }
}