﻿namespace _009_ecg_PPG
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoScrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataCountToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataCountToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.speedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 27);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(800, 423);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            this.chart.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart_SelectionRangeChanged);
            this.chart.Click += new System.EventHandler(this.chart_Click);
            this.chart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAllToolStripMenuItem,
            this.autoScrollToolStripMenuItem,
            this.dataCountToolStripMenuItem,
            this.speedToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewAllToolStripMenuItem
            // 
            this.viewAllToolStripMenuItem.Name = "viewAllToolStripMenuItem";
            this.viewAllToolStripMenuItem.Size = new System.Drawing.Size(70, 23);
            this.viewAllToolStripMenuItem.Text = "View All";
            this.viewAllToolStripMenuItem.Click += new System.EventHandler(this.viewAllToolStripMenuItem_Click);
            // 
            // autoScrollToolStripMenuItem
            // 
            this.autoScrollToolStripMenuItem.Name = "autoScrollToolStripMenuItem";
            this.autoScrollToolStripMenuItem.Size = new System.Drawing.Size(90, 23);
            this.autoScrollToolStripMenuItem.Text = "Auto Scroll";
            this.autoScrollToolStripMenuItem.Click += new System.EventHandler(this.autoScrollToolStripMenuItem_Click);
            // 
            // dataCountToolStripMenuItem
            // 
            this.dataCountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataCountToolStripMenuItem1,
            this.dataCountToolStripMenuItem2});
            this.dataCountToolStripMenuItem.Name = "dataCountToolStripMenuItem";
            this.dataCountToolStripMenuItem.Size = new System.Drawing.Size(88, 23);
            this.dataCountToolStripMenuItem.Text = "DataCount";
            // 
            // dataCountToolStripMenuItem1
            // 
            this.dataCountToolStripMenuItem1.Name = "dataCountToolStripMenuItem1";
            this.dataCountToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
            this.dataCountToolStripMenuItem1.Text = "DataCount++";
            this.dataCountToolStripMenuItem1.Click += new System.EventHandler(this.dataCountToolStripMenuItem1_Click);
            // 
            // dataCountToolStripMenuItem2
            // 
            this.dataCountToolStripMenuItem2.Name = "dataCountToolStripMenuItem2";
            this.dataCountToolStripMenuItem2.Size = new System.Drawing.Size(180, 24);
            this.dataCountToolStripMenuItem2.Text = "DataCount--";
            this.dataCountToolStripMenuItem2.Click += new System.EventHandler(this.dataCountToolStripMenuItem2_Click);
            // 
            // speedToolStripMenuItem
            // 
            this.speedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speedUpToolStripMenuItem,
            this.speedDownToolStripMenuItem});
            this.speedToolStripMenuItem.Name = "speedToolStripMenuItem";
            this.speedToolStripMenuItem.Size = new System.Drawing.Size(59, 23);
            this.speedToolStripMenuItem.Text = "Speed";
            // 
            // speedUpToolStripMenuItem
            // 
            this.speedUpToolStripMenuItem.Name = "speedUpToolStripMenuItem";
            this.speedUpToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.speedUpToolStripMenuItem.Text = "Speed Up";
            this.speedUpToolStripMenuItem.Click += new System.EventHandler(this.speedUpToolStripMenuItem_Click);
            // 
            // speedDownToolStripMenuItem
            // 
            this.speedDownToolStripMenuItem.Name = "speedDownToolStripMenuItem";
            this.speedDownToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.speedDownToolStripMenuItem.Text = "Speed Down";
            this.speedDownToolStripMenuItem.Click += new System.EventHandler(this.speedDownToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(43, 23);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ECG/PPG";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoScrollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataCountToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dataCountToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem speedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speedUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speedDownToolStripMenuItem;
    }
}

