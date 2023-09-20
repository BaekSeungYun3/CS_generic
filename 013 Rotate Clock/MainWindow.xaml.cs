using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _013_Rotate_Clock
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DrawFace();             //시계판

            MakeClockHands();       //시계바늘

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            DateTime c = DateTime.Now;

            double hDeg = c.Hour * 30 + c.Minute * 0.5;   //시침가 1시간에 30도씩 움직임 / 1분에 0.5도씩 움직임
            double mDeg = c.Minute * 6;     //분침 1분에 6도씩 돌아감
            double sDeg = c.Second * 6;     //초침가 1초에 6도씩 돌아감

            RotateTransform hRt = new RotateTransform(hDeg);
            hRt.CenterX = hourHand.X1;
            hRt.CenterY = hourHand.Y1;
            hourHand.RenderTransform = hRt;

            RotateTransform mRt = new RotateTransform(mDeg);
            mRt.CenterX = minHand.X1;
            mRt.CenterY = minHand.Y1;
            minHand.RenderTransform = mRt;

            RotateTransform sRt = new RotateTransform(sDeg);
            sRt.CenterX = secHand.X1;
            sRt.CenterY = secHand.Y1;
            secHand.RenderTransform = sRt;
        }

        //시침,분침,초침을 만든다(두께 지정)
        private void MakeClockHands()
        {
            int W = 300;
            int H = 300;

            secHand.X1 = W / 2;
            secHand.Y1 = H / 2;
            secHand.X2 = W / 2;
            secHand.Y2 = 20;

            minHand.X1 = W / 2;
            minHand.Y1 = H / 2;
            minHand.X2 = W / 2;
            minHand.Y2 = 40;         //초침보다 짧기 때문에 40으로 표현

            hourHand.X1 = W / 2;
            hourHand.Y1 = H / 2;
            hourHand.X2 = W / 2;
            hourHand.Y2 = 60;        //분침보다 짧기 때문에 40으로 표현
        }

        private void DrawFace()  //눈금선 표시(60개)
        {
            Line[] marking = new Line[60];
            int W = 300;  //크기

            for (int i = 0; i <60; i++)
            {
                //줄 하나의 속성을  지정 - 이걸 활용해서 60개 만듬
                marking[i] = new Line();
                marking[i].Stroke = Brushes.LightSteelBlue;
                marking[i].X1 = W / 2;
                marking[i].Y1 = 2;
                marking[i].X2 = W / 2;
                marking[i].Y2 = 20;

                //시간 선을 두껍게 표현
                if(i % 5 == 0)
                {
                    marking[i].Y2 = 20;
                    marking[i].StrokeThickness = 5;
                }
                else
                {
                    marking[i].Y2 = 10;
                    marking[i].StrokeThickness = 2;
                }

                RotateTransform rt = new RotateTransform(6*i);   //눈금 하나는 6도씩
                
                rt.CenterX = 150;
                rt.CenterY = 150;

                marking[i].RenderTransform = rt;   //눈금 하나의 6도이고 센터의 좌표는 150,150인 객체 생성
                aClock.Children.Add(marking[i]);
            }
        }
    }
}
