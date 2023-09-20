using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _008_Cos_x_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Graph using Chart Control";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChartSetting();

        }

        private void ChartSetting()
        {
            chart.ChartAreas[0].BackColor = Color.Black;        //==chart.ChartArea["ChartArea1"]

            //x축과 y축을 설정
            chart.ChartAreas[0].AxisX.Minimum = -20;
            chart.ChartAreas[0].AxisX.Maximum = 20;
            chart.ChartAreas[0].AxisX.Interval = 2;  //그래프 간격
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;  //눈금선의 색깔 지정
            chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart.ChartAreas[0].AxisY.Minimum = -2;
            chart.ChartAreas[0].AxisY.Maximum = 2;
            chart.ChartAreas[0].AxisY.Interval = 0.5;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            chart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            //Series[0] 설정 (sin x)
            chart.Series[0].ChartType = SeriesChartType.Line;
            chart.Series[0].Color = Color.LightGreen;
            chart.Series[0].BorderWidth = 2;
            chart.Series[0].LegendText = "sin(x)/x";

            //Series 추가
            chart.Series.Add("Cos");
            chart.Series["Cos"].LegendText = "Cos(x) / x";
            chart.Series[1].ChartType = SeriesChartType.Line;
            chart.Series[1].Color = Color.Orange;
            chart.Series[1].BorderWidth = 2;


            //데이터 추가
            for (double x = -20; x < 20; x += 0.1)
            {
                double y = Math.Sin(x)/x;
                chart.Series[0].Points.AddXY(x, y);  //값을 집어넣음

                y = Math.Cos(x) / x;
                chart.Series[1].Points.AddXY(x, y);
            }
        }
    }
}

