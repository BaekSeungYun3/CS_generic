using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Data.SqlClient;
using System.Threading;

namespace _004_splash
{
    public partial class MainWindow : Window
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\qortm\source\repos\CS제네릭프로그래밍\004 splash\Colors.mdf;Integrated Security = True";

        List<Border> borderList;
        DispatcherTimer t = new DispatcherTimer();    //Timer t = new Timer()와 같은 말
        Random r = new Random();

        
        
        public MainWindow()
        {
            InitializeComponent();
            borderList = new List<Border>()
            {
                bd1,bd2,bd3,bd4,bd5,
                bd6,bd7,bd8,bd9,bd10,
                bd11,bd12,bd13,bd14,bd15,
                bd16,bd17,bd18,bd19,bd20 };

            t.Interval = new TimeSpan(0,0,1);  //1초 (시, 분, 초)
            t.Tick += T_Tick;
        }

        int index;  //리스트 박스 스크롤을 위해 생성

        private void T_Tick(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("hh:mm:ss");
            lblDate.Text = date;
            lblTime.Text = time;

            byte[] colors = new byte[20];   //컬러는 바이트 값을 가지기 때문에 바이트 배열 생성
            for(int i = 0; i<colors.Length; i++)
            {
                colors[i] = (byte)(r.Next(255));
                borderList[i].Background =
                    new SolidColorBrush(Color.FromRgb(0, colors[i], 0));
            }

            string s = "";
            s += date + "" + time + " ";

            for(int i = 0; i< borderList.Count; i++)
            {
                s += colors[i] + " ";       //랜덤하게 만들어진 값이 s에 추가됨
            }

            lstDB.Items.Add(s);             //랜덤하게 만들어진 20개의 값을 리스트박스에 추가

            //리스트 박스에 랜덤한 값이 들어갈 때마다 스크롤 하기 위해 생성
            lstDB.SelectedIndex = index++;  
            lstDB.ScrollIntoView(lstDB.SelectedItem);

            //데이터베이스에 저장
            string sql = string.Format("INSERT INTO ColorTable Values ('{0}','{1}'",date,time);   //string형이기에 '' 필요
            
            for (int i = 0; i < 20; i++)    //colors의 개수는 20개
            {
                sql += ", " + colors[i];  
            }
            sql += ")";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand comm = new SqlCommand(sql, conn))
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
        }

        bool flag = false;        //동일한 버튼을 두번 누를 수 있게 해주기 위해 생성
        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {

            if(flag == false)
            {
                t.Start();                     //날짜, 시간이 시작
                btnRandom.Content = "중지";     //버튼의 텍스트를 바꿔줌
                flag = true;
            }
            else
            {
                t.Stop();                      //날짜,시간이 정지됨
                btnRandom.Content = "Random 색깔표시";
                flag = false;
            }

        }
        int id = 0; //스크롤을 만들기 위해서 필요

        //DB에서 읽어오기
        private void btnDB_Click(object sender, RoutedEventArgs e)
        {
            lstDB.Items.Clear();

            string sql = "SELECT * FROM ColorTable";
            int[] colors = new int[20];

            using(SqlConnection conn = new SqlConnection(connStr))
            using(SqlCommand comm = new SqlCommand(sql, conn))
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                string s = "";
                while (reader.Read())     //읽어오는 줄마다 실행됨
                {
                    s = "";    //빈칸으로 만들어줘야 새로운 줄이 추가됨
                    lblDate.Text = reader["Date"].ToString();
                    s += lblDate.Text + " ";
                    lblTime.Text = reader["Time"].ToString();
                    s += lblTime.Text + " ";

                    for (int i = 0; i < 20; i++)
                    {
                        colors[i] = int.Parse(reader[i + 3].ToString());    //P1이 날짜 시간때문에 3번째로 시작 그래서 +3을 해줌
                        s += colors[i] + " ";
                    }
                    lstDB.Items.Add(s);
                    lstDB.SelectedIndex = id++;
                    lstDB.ScrollIntoView(lstDB.SelectedItem);

                    for(int i = 0; i<colors.Length; i++)
                    {
                        borderList[i].Background = new SolidColorBrush(Color.FromRgb(0, (byte)colors[i], 0)); //색의 값을 받아옴
                    }

                    //WPF delay 주기(딜레이) using문 사용
                    Dispatcher.Invoke((ThreadStart)(() => { }), DispatcherPriority.ApplicationIdle);
                    Thread.Sleep(20);  //20ms
                }

            }
        }

        //DB값을 지운다
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            lstDB.Items.Clear();
            string sql = "DELETE FROM ColorTable";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand comm = new SqlCommand(sql, conn))
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
