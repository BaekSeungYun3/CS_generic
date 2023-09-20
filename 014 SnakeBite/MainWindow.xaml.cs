using System.Windows;

namespace _014_SnakeBite
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game();          //새로운 창 = 윈도우 만들기
            game.Show();                    //게임이 눈에 보이게 해줌 
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
