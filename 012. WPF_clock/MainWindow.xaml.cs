using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _012.WPF_clock
{
    public partial class MainWindow : Window
    {
        bool aClock_Flag = false;   //아날로그와 디지털 선택
        Point center;               //중심점
        double radius;              //반지름
        int hourHand;               //시침의 길이
        int minHand;                //분침의 길이
        int secHand;                // 초침의 길이


        DispatcherTimer timer = new DispatcherTimer();           //Using문 추가
        private bool ms_flag;

        public MainWindow()
        {
            InitializeComponent();
            
            aClockSetting();
            timerSetting();
        }

        private void timerSetting()
        {
            timer.Interval = new TimeSpan(0,0,0,0,10);               //TimeSpan 타입 - 밀리초 단위(일,시,분,초,밀리) == 0.01초
            timer.Tick += Timer_Tick;                                   // == += new EventHandler(Timer_Tick);                              
            timer.Start();  
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime c = DateTime.Now;

            canvas1.Children.Clear();   //현재 화면을 지움

            if (aClock_Flag == true) 
            { 
                DrawClockFace();
            
                //시계 바늘 그리기(핵심)
                double radHr = (c.Hour % 12 + c.Minute / 60.0) * 30 * Math.PI / 180;   //시간당 30도 / 분당 60으로 나눈 30도
                double radMin = (c.Minute + c.Second / 60.0) * 6 * Math.PI / 180;
                double radSec = (c.Second * 6 + c.Millisecond * 6.0/1000) * Math.PI / 180;       //* Math.PI / 180 -> 라디안으로 바꿔주기 위해 계산

                DrawHand(radHr, radMin, radSec);
            }
            else  //디지털 시계
            {
                txtDate.Text = DateTime.Today.ToString("D");
                
                if(ms_flag == false)
                    txtTime.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", c.Hour, c.Minute, c.Second);
                else
                    txtTime.Text = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", c.Hour, c.Minute, c.Second,c.Millisecond);
               
            }    

        }

        //시계바늘을 그리는 함수
        private void DrawHand(double radHr, double radMin, double radSec)
        {
            //시침
            DrawLine(0, 0,
                (int)(hourHand * Math.Sin(radHr)),
                (int)(hourHand * Math.Cos(radHr)),
                Brushes.RoyalBlue, 8);
            //분침
            DrawLine(0, 0,
                (int)(minHand * Math.Sin(radMin)),
                (int)(minHand * Math.Cos(radMin)),
                Brushes.SkyBlue, 6);
            //초침(현재 시간의 좌표를 각도를 이용하여 구하자)
            DrawLine(0, 0,
                (int)(secHand * Math.Sin(radSec)),
                (int)(secHand * Math.Cos(radSec)),
                Brushes.OrangeRed, 4);
  
            //배꼽
            int coreSize = 16;
            Ellipse core = new Ellipse();
            core.Margin = new Thickness(center.X - coreSize / 2, center.Y - coreSize / 2, 0, 0);
            core.Stroke = Brushes.SteelBlue;
            core.StrokeThickness = 3;
            core.Fill = Brushes.LightSteelBlue;
            core.Width = 16;
            core.Height = coreSize;
            canvas1.Children.Add(core);

        }

        private void DrawLine (int x1, int y1, int x2, int y2, Brush brush, int thick)
        {
            Line line = new Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = -y2;
            line.Stroke = brush;
            line.StrokeThickness = thick;
            line.Margin = new Thickness(center.X, center.Y, 0, 0);
            line.StrokeEndLineCap = PenLineCap.Round;
            
            canvas1.Children.Add(line);


        }

        private void DrawClockFace()     //원을 그림
        {
            aClock.Stroke = Brushes.LightSteelBlue;  //테두리
            aClock.StrokeThickness = 30;             //테두리 굵기
            canvas1.Children.Add(aClock);            //캔버스1에 속성지정한 것을 추가
        }

        private void aClockSetting()
        {
            center = new Point(canvas1.Width / 2, canvas1.Height / 2);
            radius = canvas1.Width / 2;

            //시,분,초침 설정 (반지름 x 값)
            hourHand = (int)(radius * 0.45);
            minHand = (int)(radius * 0.55);
            secHand = (int)(radius * 0.65);
        }


        private void aClock_Click(object sender, RoutedEventArgs e)
        {
            aClock_Flag = true;
            txtDate.Text = "";
            txtTime.Text = "";
        }

        private void Digital_Click(object sender, RoutedEventArgs e)
        {
            aClock_Flag = false;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //초단위
        private void Sec_Click(object sender, RoutedEventArgs e)
        {
            timer.Interval = new TimeSpan(0, 0, 0, 10);   //0.01초에 한번씩
        }
        //밀리초 단위
        private void MS_Click(object sender, RoutedEventArgs e)
        {
            ms_flag = true;
            timer.Interval = new TimeSpan(0, 0, 0, 0,10);
        }
    }
}
