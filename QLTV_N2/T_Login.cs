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

namespace QLTV_N2
{
    public partial class T_Login : Form
    {
        public T_Login()
        {
            InitializeComponent();
        }
        //tạo chuổi kết nối
        


        private void bt_login_Click(object sender, EventArgs e)
        {
            string strconn = @"Data Source=DESKTOP-9FMR7OR\HUUDAT;Initial Catalog=QLTV_N2;Integrated Security=True";
            SqlConnection sqlconn = new SqlConnection(strconn);
            try
            {
                if (sqlconn.State == ConnectionState.Closed)
                sqlconn.Open();
                string sqlTextCommand = "Select * from T_Nhanvien where Manv='"+txt_username.Text+ "'";
                SqlCommand sqlcmd = new SqlCommand(sqlTextCommand, sqlconn);
                SqlDataReader dt = sqlcmd.ExecuteReader();
                if(dt.HasRows)
                {
                    if(dt.Read())
                    {
                        string Manv = (string)dt[0];
                        string Mk = (string)dt[1];
                        if(Mk == txt_pass.Text)
                        {
                            this.Hide();
                            T_Main main = new T_Main();
                            this.Visible = false;
                            main.ShowDialog();
                            this.Visible = true;

                        } 
                        else
                        {
                            MessageBox.Show("Sai mật khẩu", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }    

                    }   
                    else
                    {
                        MessageBox.Show("Lỗi sảy ra khi đăng nhập","Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }    
                }  
                else
                {
                    MessageBox.Show("Mã nhân viên không tồn tại", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi sảy ra khi truy vấn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (sqlconn.State == ConnectionState.Open)
                sqlconn.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void T_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
