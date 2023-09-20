using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace _010_MatchingGame
{
    public partial class MainWindow : Window
    {
        int[] rnd = new int[16];  //TagSet()에서 사용할 배열
        DispatcherTimer myTimer = new DispatcherTimer();   //카드가 뒤집히는 속도를 조절하기 위해 사용 - Using문을 선언해줘야함
        
        public MainWindow()
        {
            InitializeComponent();
            BoardSet();
            myTimer.Interval = new TimeSpan(0, 0, 0, 0,750);  //(일,시,분,초,밀리초) 타이머가 0.75초동안  동작
            myTimer.Tick += MyTimer_Tick;
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            myTimer.Stop();   //카드가 0.75초 다음에 또 뒤집히지 않도록 STOP시킴
            first.Content = MakeImage("../../Images/check.png");
            second.Content = MakeImage("../../Images/check.png");
            first = null;
            second = null;
        }

        private void BoardSet()
        {
            for(int i =0;i < 16; i++)
            {
                Button btn = new Button();          //16개의 버튼 생성    
                btn.Background = Brushes.White;     //버튼의 배경색을 하얀색으로 지정
                btn.Margin = new Thickness(10);
                
                btn.Tag = TagSet();                 //랜덤하고 각 숫자가 2개씩
                btn.Content = MakeImage("../../Images/check.png");

                btn.Click += Btn_Click;             // 버튼의 클릭 이벤트 설정

                board.Children.Add(btn);            
            }
        }

        Button first = null;
        Button second = null;
        private int matched;

        private void Btn_Click(object sender, RoutedEventArgs e)   
        {
            Button btn = sender as Button;

            String[] icon = { "딸기", "레몬", "모과", "배", "사과", "수박", "파인애플", "포도" };
            String fruitName = icon[(int)btn.Tag];     //Tag값에 지정한 숫자의 과일 이름을 얻기 위해 만듦
                       
            if(first == null)  //누른 버튼이 첫번째 버튼이라면
            {
                first = btn;
                btn.Content = MakeImage("../../Images/" + fruitName + ".png");   //과일 이름 지정
                return;
            }
            else if(second == null)  //지금 누른 버튼이 두번째 버튼일 경우
            {
                second = btn;
                btn.Content = MakeImage("../../Images/" + fruitName + ".png");
            }
            else
            {
                return;
            }

            //카트 비교하기
            if((int)first.Tag == (int)second.Tag)  //같다
            {
                first = null;
                second = null;
                matched += 2;   //매칭된 버튼의 개수

                if (matched >= 16)
                {
                    MessageBoxResult res = MessageBox.Show("성공! 다시 하겠습니까?", "Success!", MessageBoxButton.YesNo);   //Result: YesNo값을 받기 위한 것

                    if (res == MessageBoxResult.Yes)   //초기화
                    {
                        RndReset();
                        BoardReset();
                        BoardSet();
                        matched = 0;
                    }
                    else
                        this.Close();
                }
            }
            else    //같지 않다면 카드 뒤집기
            {
                myTimer.Start();
            }

        }

        private void BoardReset()
        {
            board.Children.Clear();
        }

        private void RndReset()
        {
            for (int i = 0; i < 16; i++)
                rnd[i] = 0;
        }

        private Image MakeImage(string v)    //이미지를 리턴해주기 때문에 objec를 Image로 바꿔줌 
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(v,UriKind.Relative);
            bi.EndInit();

            Image myImge = new Image();
            myImge.Margin = new Thickness(10);
            myImge.Stretch = Stretch.Fill;
            myImge.Source = bi;

            return myImge;
        }

        //0~7까지의 그림 종류에 해당하는 번호 - 각 번호는 2개씩 할당되어야 함
        private int TagSet()                        //1~15의 숫자를 사용하기 위해 object에서 int로 변경
        {
            Random r = new Random();

            while (true)
            {
                int n = r.Next(16);                 //0~15까지의 숫자
                    
                if(rnd[n] == 0)                     //n이라는 숫자가 처음 나온 숫자인가를 확인 
                {
                    rnd[n] = 1;
                    return n % 8;
                }
            }
        }
    }
}
