using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _009_ecg_PPG
{
    public partial class Form1 : Form
    {
        double[] ecg = new double[100000];
        double[] ppg = new double[100000];

        private int ecgCount;
        private int ppgCount;   //메서드

        Timer t = new Timer();

        public Form1()
        {
            InitializeComponent();
            this.Text = "ECG/PPG";
            this.WindowState = FormWindowState.Maximized;   //시작하면서 화면 가득하게 나옴

            EcgRead();
            PpgRead();
            ChartSetting();

            t.Interval = 10;        //0.01초마다 한자리씩 이동하게 설정
            t.Tick += T_Tick;
        }

        private int cursorX = 0;            //차트에 표시되는 첫번째 데이터
        private bool scrolling = false;     //true이면 스크롤, false이면 정지
        private int dataCount = 500;        //한 화면에 표시되는 데이터 - 이전엔 ecgCount만큼 설정했었음
        private int speed = 2;              //데이터 표시 속도 의미

        private void T_Tick(object sender, EventArgs e)
        {
            if (cursorX + dataCount <= ecgCount)     //합이 ecgCount보다 작거나 같을 때
                chart.ChartAreas[0].AxisX.ScaleView.Zoom(cursorX, cursorX + dataCount);
            else
                t.Stop();
            cursorX += speed;

        }

        private void ChartSetting()
        {
            chart.ChartAreas[0].CursorX.IsUserEnabled = true;   //커서 사용가능
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;  //줌 역할

            chart.ChartAreas[0].BackColor = Color.Black;      // == ChartArea["ChartArea1"]
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = ecgCount;     //최대값은 ecgCount(ppg값이 ecg보다 큼)
            chart.ChartAreas[0].AxisX.Interval = 50;         //50마다 눈금을 그리겠다
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart.ChartAreas[0].BackColor = Color.Black;
            chart.ChartAreas[0].AxisY.Minimum = -2;
            chart.ChartAreas[0].AxisY.Maximum = 6;
            chart.ChartAreas[0].AxisY.Interval = 0.5;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            chart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart.Series.Clear();       //시리즈를 다 지움
            chart.Series.Add("ECG");    //시리즈 추가
            chart.Series.Add("PPG");
            chart.Series[0].ChartType = SeriesChartType.Line;  //  == Series["ECG"]
            chart.Series[0].Color = Color.LightGreen;
            chart.Series[0].BorderWidth = 2;    //선의 굵기
            chart.Series[0].LegendText = "ECG";  //범례 제목 지정

            chart.Series[1].ChartType = SeriesChartType.Line;
            chart.Series[1].Color = Color.Orange;
            chart.Series[1].BorderWidth = 2;
            chart.Series[1].LegendText = "PPG";

            //데이터를 시리즈에 넣는 작업
            foreach (var v in ecg)
            {
                chart.Series["ECG"].Points.Add(v);     //값을 점으로 집어넣어준다
            }
            foreach (var v in ppg)
            {
                chart.Series["PPG"].Points.Add(v);
            }
        }

        private void PpgRead()
        {
            String fileName = "../../Data/ppg.txt";
            String[] lines = File.ReadAllLines(fileName);

            double min = double.MaxValue;
            double max = double.MinValue;

            int i = 0;
            foreach (var line in lines)    //값을 각 라인별로 집어넣어라
            {
                ppg[i] = double.Parse(line);
                if (min > ppg[i])
                    min = ppg[i];
                if (max < ppg[i])
                    max = ppg[i];
                i++;
            }
            ppgCount = i;
            string s = string.Format("PPG: count={0}, min={1}, max={2}", ppgCount, min, max);
            MessageBox.Show(s);

        }

        private void EcgRead()
        {
            String fileName = "../../Data/ecg.txt";
            String[] lines = File.ReadAllLines(fileName);

            double min = double.MaxValue;
            double max = double.MinValue;

            int i = 0;
            foreach (var line in lines)    //값을 각 라인별로 집어넣어라
            {
                ecg[i] = double.Parse(line) + 3;
                if (min > ecg[i])
                    min = ecg[i];
                if (max < ecg[i])
                    max = ecg[i];
                i++;
            }
            ecgCount = i;
            string s = string.Format("ECG: count={0}, min={1}, max={2}", ecgCount, min, max);
            MessageBox.Show(s);

        }


        private void autoScrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t.Start();
            scrolling = true;
        }

        bool scrollFlag = true;
        //차트를 클릭했을 때 처리 메소드
        private void chart_Click(object sender, EventArgs e)
        {
            if (scrollFlag == true)
            {
                t.Stop();
                scrollFlag = false;
            }
            else
            {
                t.Start();
                scrollFlag = true;
            }

        }

        private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.ChartAreas[0].AxisX.ScaleView.Zoom(0, ecgCount);
            t.Stop();
            scrolling = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chart_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            int min = (int)(chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum);
            int max = (int)(chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum);
            cursorX = min;
            dataCount = max - min;
        }


        private void dataCountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataCount *= 2;
        }

        private void dataCountToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dataCount /= 2;
        }

        private void speedUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            speed *= 2;
        }

        private void speedDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            speed /= 2;
        }

        private void chart_MouseClick(object sender, MouseEventArgs e)   //차트를 클릭하는 곳의 데이터 값을 표시
        {
            HitTestResult htr = chart.HitTest(e.X, e.Y);
            if (htr.ChartElementType == ChartElementType.DataPoint) //내가 차트 영역을 클릭한 곳이 데이터가 있는 영역이라면
            {
                string s = string.Format("Count : {0}, ECG : {1}, PPG : {2}", htr.PointIndex,
                        chart.Series["ECG"].Points[htr.PointIndex].YValues[0], chart.Series["PPG"].Points[htr.PointIndex].YValues[0]);
                MessageBox.Show(s);
            }
        }
    }
}
