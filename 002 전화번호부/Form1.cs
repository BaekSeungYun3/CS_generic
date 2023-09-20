using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;   //OleDbConnection를 사용하기 위해 선언
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _002_전화번호부
{
    public partial class Form1 : Form
    {
        OleDbConnection conn = null;
        OleDbCommand comm = null;
        OleDbDataReader reader = null;

        string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\qortm\Documents\PhoneBook.accdb";  //@: 뒤에 써있는 글자 그대로라는 뜻
        public Form1()
        {
            InitializeComponent();

            ShowStudents();
        }
        //DB에서 학생정보를 읽어와서 리스트박스에 표시
        private void ShowStudents()
        {
            if (conn == null)
            {
                conn = new OleDbConnection(connStr);
                conn.Open();
            }
            string sql = "SELECT * FROM StudentTable";
            comm = new OleDbCommand(sql, conn);
            
            reader = comm.ExecuteReader();
            while(reader.Read())
            {
                string x = "";
                x += reader["ID"] + "\t";
                x += reader["SId"] + "\t";
                x += reader["SName"] + "\t";
                x += reader["Phone"];

                lstStudent.Items.Add(x);
            }
            reader.Close();
            conn.Close();
            conn = null;
        }

        //리스트박스에서 항목을 선택했을 때
        private void lstStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;    //==Listbox lb2 = (ListBox)sender;

            if (lb.SelectedItem == null)
                return;

            string[] s = lb.SelectedItem.ToString().Split('\t');

            txtID.Text = s[0];
            txtSId.Text = s[1];
            txtSName.Text = s[2];
            txtPhone.Text = s[3];
        }

        //추가 버튼을 눌렀을 때
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSId.Text == "" || txtSName.Text == "" || txtPhone.Text == "")
                return;

            connOpen();

            //sql 문장 만들기
            string sql = string.Format("INSERT INTO StudentTable(SId,SName,Phone)" + "VALUES({0},'{1}','{2}')"
                , txtSId.Text, txtSName.Text, txtPhone.Text);

            //명령어 실행
            comm = new OleDbCommand(sql, conn);
            int x = comm.ExecuteNonQuery();

            if (x == 1)
                MessageBox.Show("삽입성공!");

            connClose();
        }


        private void connClose()
        {
            conn.Close();
            conn = null;

            lstStudent.Items.Clear();
            ShowStudents();
        }

        private void connOpen()
        {
            //DB연결
            conn = new OleDbConnection(connStr);
            conn.Open();
        }

        // 삭제 버튼을 눌렀을 때
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSId.Text == "")
                return;

            connOpen();

            string sql = string.Format("DELETE FROM StudentTable WHERE ID={0}",txtID.Text);
            comm = new OleDbCommand(sql, conn);
            
            int x = comm.ExecuteNonQuery();
            if (x == 1)
                MessageBox.Show("삭제 성공!");

            connClose();
        }

        //검색
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" && txtSName.Text == "" && txtPhone.Text == "")
                return;

            connOpen();

            string sql = string.Format("SELECT * FROM StudentTable WHERE ");
            if (txtSId.Text != "")
                sql += "SId = " + txtSId.Text;
            else if(txtSName.Text != "")
                sql += "SName = '" + txtSName.Text + "'";
            else if (txtPhone.Text != "")
                sql += "Phone = '" + txtPhone.Text + "'";

            comm = new OleDbCommand(sql,conn);

            //리스트 박스를 지워줌
            lstStudent.Items.Clear();

            //ShowStudents()에서 복사해온 부분
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string x = "";
                x += reader["ID"] + "\t";
                x += reader["SId"] + "\t";
                x += reader["SName"] + "\t";
                x += reader["Phone"];

                lstStudent.Items.Add(x);
            }
            reader.Close();

            conn.Close();
            conn = null;
        }

        //ViewAll 버튼
        private void btnAll_Click(object sender, EventArgs e)
        {
            lstStudent.Items.Clear();
            ShowStudents();
        }

        //수정
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connOpen();

            string sql = string.Format("UPDATE StudentTable SET " + "SId={0}, SName='{1}', Phone='{2}' WHERE ID={3}",
                txtSId.Text,txtSName.Text,txtPhone.Text,txtID.Text);

            comm = new OleDbCommand(sql, conn);
            
            int x = comm.ExecuteNonQuery();
            if (x == 1)
                MessageBox.Show("수정 성공!");
            
            connClose();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtSId.Text = "";
            txtSName.Text = "";
            txtPhone.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();          //this.Close()도 같은 말임
        }
    }
}
