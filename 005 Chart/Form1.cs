using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _005_Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Using Chart Control";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            chart1.Titles.Add("중간고사 성적");  //타이틀 추가

            for(int i =0; i< 10; i++)
            {
                chart1.Series["Series1"].Points.Add(r.Next(100));      //시리즈1에 값을 더한다는 뜻(0~100사이의 값) //==chart1.Series[0]
                chart1.Series[0].LegendText = "비주얼프로그래밍";       //범례 텍스트
                chart1.Series[0].ChartType = SeriesChartType.Line;  // == System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line (using문으로 대신해줌)
            }
        }
    }
}
