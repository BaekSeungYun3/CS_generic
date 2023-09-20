using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Data;

namespace _003_로그인창
{

    public partial class MainWindow : Window
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\qortm\source\repos\CS제네릭프로그래밍\003 로그인창\Login.mdf;Integrated Security=True";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sql = string.Format("SELECT COUNT(*) From LoginTable " +
                "WHERE UserName='{0}' AND Password='{1}'", txtUserName.Text, txtPassword.Password);

            SqlCommand comm = new SqlCommand(sql, conn);
            int count = Convert.ToInt32(comm.ExecuteScalar());

            if (count == 1)
                MessageBox.Show("Login 성공!");
            else
                MessageBox.Show("Login 실패!");

            conn.Close();

        }
    }
}
