using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace dengluzhucce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    //    private delegate DialogResult MessageBoxShow(string x);
    //    private MessageBoxShow method;
        private int box_show = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string constr = @"server=DESKTOP-D6NGD8R\SQLEXPRESS;database=dlzc;uid=sa;pwd=741213;";
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            string comstr = "insert into dlzc values('" + textUser.Text + "','" + textPwd.Text + "','" + textEmail.Text + "')";
            SqlCommand command = new SqlCommand(comstr, connection);
            int count = command.ExecuteNonQuery();
            if (count > 0)
            {
                MessageBox.Show("注册成功 !");
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constr = @"server=DESKTOP-D6NGD8R\SQLEXPRESS;database=dlzc;uid=sa;pwd=741213;";
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            string sql = "select * from dlzc";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dr = command.ExecuteReader();
            bool cunzai = false;
            while (dr.Read())
            {
                if ((string)dr["用户名"] == Username.Text)
                {
                    cunzai = true;
                    if ((string)dr["密码"] == UserPwd.Text)
                    {
                        MessageBox.Show("登录成功");
                    }
                    else
                        MessageBox.Show("密码不正确");
                }
            }
            if (cunzai == false)
                MessageBox.Show("用户不存在");
            dr.Close();
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constr = @"server=DESKTOP-D6NGD8R\SQLEXPRESS;database=dlzc;uid=sa;pwd=741213;";
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            string sql = "select * from dlzc";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                if ((string)dr["用户名"] == Username.Text)
                {
                    box_show = 1;
                    if ((string)dr["密码"] == UserPwd.Text)
                    {
                        box_show = 2;   
                    }
                    else
                        box_show = 3;
                }
            }
            showbox();
            dr.Close();
            connection.Close();
        }

        private void showbox()
        {
            switch (box_show)
            {
                case 1:
                    MessageBox.Show("用户不存在");
                    break;
                case 2:
                    MessageBox.Show("登录成功");
                    break;
                case 3:
                    MessageBox.Show("密码不正确");
                    break;
                default:
                    break;
            }
        }
    }
}
