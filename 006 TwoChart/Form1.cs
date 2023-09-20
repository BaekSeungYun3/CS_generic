using System;
using System.Windows.Forms;

namespace _006_TwoChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Two Charts";
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            chart1.Titles.Add("성적");
            chart1.Series.Add("Series2");                   //Series가 2개 Area는 1개
            chart1.Series["Series1"].LegendText = "수학";
            chart1.Series["Series2"].LegendText = "영어";

            chart1.ChartAreas.Add("ChartArea2");            //Area 1개 추가 = 즉 2개
            chart1.Series["Series2"].ChartArea = "ChartArea2";  //시리즈2의 차트 영역을 Area2로 지정

            Random r = new Random();
            for(int i = 0; i<10; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, r.Next(101));    //AddXY: x,y값을 모두 줄 수 있음
                chart1.Series["Series2"].Points.AddXY(i, r.Next(101));
            }

        }

        private void btnOnechart_Click(object sender, EventArgs e)
        {
            chart1.Series["Series2"].ChartArea = "ChartArea1";
            chart1.ChartAreas.RemoveAt(1);
            // == chart1.ChartAreas.RemoveAt(chart1.ChartAreas.IndexOf("ChartArea2"));

        }

        private void btnTwocharts_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas.Add("수학영역");
            chart1.Series["Series2"].ChartArea = "수학영역";

        }
    }
}
