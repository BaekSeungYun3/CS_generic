using System;
using System.Drawing;
using System.Windows.Forms;

namespace _011_Form_Clock
{
    public partial class Form1 : Form
    {
        // 필드 속성

        Graphics g;                 //Graphics 객체
        bool aClock_Flag = false;   //아날로그와 디지털 선택
        Point center;               //중심점
        double radius;              //반지름
        int hourHand;               //시침의 길이
        int minHand;                //분침의 길이
        int secHand;                // 초침의 길이
        const int clientSize = 300;   // 타이틀바를 제외한 폼의 영역
        const int clockSize = 200;    //시계의 사이즈

        public Form1()
        {
            InitializeComponent();

            this.ClientSize = new Size(clientSize, clientSize+menuStrip1.Height);
            this.Text = "Form Clock";

            panel1.BackColor = Color.WhiteSmoke;

            g = panel1.CreateGraphics();   //this를 사용하면 폼에 만들어짐 - 폼이 덮여져 있기 때문에 이렇게 사용시 눈에 안보임
            
            aClockSetting();        
            TimerSetting();
        }

        private void TimerSetting()
        {
            Timer timer = new Timer();     //타이머 생성
            timer.Interval = 1000;          //1초에 한번씩
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime c = DateTime.Now;  //DateTime = 구조체

            panel1.Refresh();  //패널을 지우고 다시 그려줌

            if (aClock_Flag == true) { 


                DrawClockFace();    //시계판 - 도넛모양 판

                //시계 바늘 그리기(핵심)
                double radHr = (c.Hour % 12 + c.Minute / 60.0) * 30 * Math.PI / 180;   //시간당 30도 / 분당 60으로 나눈 30도
                double radMin = (c.Minute + c.Second / 60.0) * 6 * Math.PI / 180;
                double radSec = c.Second * 6 * Math.PI / 180;       //* Math.PI / 180 -> 라디안으로 바꿔주기 위해 계산  

                DrawHand(radHr,radMin,radSec);
            }
            else
            {
                Font fDate = new Font("맑은 고딕", 12, FontStyle.Bold);
                Font fTime = new Font("맑은 고딕", 32, FontStyle.Bold | FontStyle.Italic);
                Brush bDate = Brushes.SkyBlue;
                Brush bTime = Brushes.SteelBlue;

                string date = DateTime.Today.ToString("D");
                string time = string.Format("{0:D2}:{1:D2}:{2:D2}",c.Hour,c.Minute,c.Second);

                g.DrawString(date, fDate, bDate, new Point(50, 100));
                g.DrawString(time, fTime, bTime, new Point(50, 120));

            }

        }

        //시계바늘 그리는 메소드
        private void DrawHand(double radHr, double radMin, double radSec)
        {
            //시침
            DrawLine(0, 0, (int)(hourHand * Math.Sin(radHr)), 
                           (int)(hourHand * Math.Cos(radHr)), 
                           Brushes.RoyalBlue,8);

            //분침
            DrawLine(0, 0, (int)(minHand * Math.Sin(radMin)), 
                           (int)(minHand * Math.Cos(radMin)),
                           Brushes.SkyBlue, 6);

            //초침(현재 시간의 좌표를  각도를 이용하여 구하자)
            DrawLine(0, 0, (int)(secHand * Math.Sin(radSec)), 
                           (int)(secHand * Math.Cos(radSec)),
                           Brushes.Orange,4);    //x좌표, Y좌표

            //배꼽
            int coreSize = 16;

            Rectangle r = new Rectangle(center.X - coreSize / 2, center.Y - coreSize / 2, coreSize, coreSize); //(x,y,넓이, 높이)
            g.FillEllipse(Brushes.Gold, r);                //원을 그리고 색을 채워줌
            g.DrawEllipse(new Pen(Brushes.Green,3), r);   //그린색의 두께가 3인 내접한 배꼽을 그려라

        }

        //그래픽으로 선을 그리는 함수
        private void DrawLine(int x1, int y1, int x2, int y2, Brush brush, int thick)
        {
            Pen p = new Pen(brush,thick);

            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;      //화살표의 끝 모양을 지정해줌(둥근 모양)
            
            g.DrawLine(p, center.X+x1, center.Y + y1, center.X + x2, center.Y - y2);
        }

        private void DrawClockFace()
        {
            Pen p = new Pen(Brushes.LightSteelBlue, 30);  //()안에 색깔과 두께를 넣을 수 있음
            g.DrawEllipse(p,center.X - clockSize / 2, center.Y - clockSize / 2, clockSize,clockSize);  //타원을 그리는 것(사각형 안에 내접한 원을 그리는 것 / x,y좌표)
        }

        //아날로그 시계 세팅
        private void aClockSetting()   
        {
            center = new Point(clientSize / 2, clientSize / 2); //Center = Point 구조체 / client사이즈의 중간 값을 괄호에 넣어줌(x,y좌표)
            radius = clockSize / 2;

            //시,분,초침 설정 (반지름 x 값)
            hourHand = (int)(radius * 0.45);    
            minHand = (int)(radius * 0.55);
            secHand = (int)(radius * 0.65);
        }

        private void 아날로그ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aClock_Flag = true;
        }
        //이 두개는 Timer_tick 함수에서 처리됨
        private void 디지털ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aClock_Flag = false;
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
