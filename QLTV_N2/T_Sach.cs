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
    public partial class T_Sach : Form
    {
        public T_Sach()
        {
            InitializeComponent();
        }
        //Tạo chuỗi kết nối
        String chuoi = @"Data Source=DESKTOP-9FMR7OR\HUUDAT;Initial Catalog=QLTV_N2;Integrated Security=True";
        //Khởi tạo đối tượng Connection 
        SqlConnection strconn;
        private SqlCommand myCommand;
        private SqlDataAdapter myDataAdapter;
        private DataTable myTable;
        private SqlConnection myConnection;


        private DataTable ketnoi(string truyvan)
        {
            myConnection = new SqlConnection(chuoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTable = new DataTable();
            myDataAdapter.Fill(myTable);
            dgvsach.DataSource = myTable;
            return myTable;
        }

        private Boolean Kiemtra_Dup()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sql_kt1 = "Select * from T_Sach where Masach=N'" + txtmasach.Text + "'";
            SqlCommand cmd = new SqlCommand(sql_kt1, strconn);
            SqlDataReader Dr = cmd.ExecuteReader();
            Boolean kt = true;
            while (Dr.Read())
            {

                if (tgmasach.Text == Dr[0].ToString())
                {
                    kt = false;
                    MessageBox.Show("Trùng mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtmasach.Text = "";
                    txtmasach.Focus();
                    break;
                }
            }
            strconn.Close();
            return kt;
        }


        private void btthem_Click(object sender, EventArgs e)
        {
            // Khoi tao doi tuong Conne0ction
            strconn = new SqlConnection(chuoi);


            //tạo thêm mã tự động 
            int count = 0;
            count = dgvsach.Rows.Count;
            string chuoi1 = "";
            int chuoi2 = 0;
            chuoi1 = Convert.ToString(dgvsach.Rows[count - 2].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi1.Remove(0, 1)));//loại bỏ ký thự S
            if (chuoi2 + 1 < 10)
                txtmasach.Text = "S00" + (chuoi2 + 1).ToString();//cộng dồn khi thỏa mãn điều kiện
            else if (chuoi2 + 1 < 100)
                txtmasach.Text = "S0" + (chuoi2 + 1).ToString();
            //Mở kết nối
            strconn.Open();
            //Lấy dữ liệu trên Form
            string Masach = txtmasach.Text;
            string Tensach = txttensach.Text;
            string Manxb= cbmanxb.Text;
            string Tacgia = txttacgia.Text;
            string Theloai = txttheloai.Text;
            string Soluong = txtsoluong.Text;
            //chuoi sql dang insert
            //Dùng ký tự N' trước mỗi giá trị kiểu text để insert giá trị có dấu tiếng việt vào CSDL được đúng 

            string sqladd = "Insert into T_Sach values(N'" + Masach + "', N'" + Tensach + "',N'" + Manxb + "',N'" + Tacgia + "',N'" + Theloai + "',N'" + Soluong + "')";
            //khoi tao doi tuong Command

            if (Masach == "")
            {
                MessageBox.Show("Chưa nhập mã sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand cmd = new SqlCommand(sqladd, strconn);
                if (Kiemtra_Dup())
                {
                    cmd.ExecuteNonQuery();
                    DGV_HienThi();
                    Xoa();
                }
            }
            strconn.Close();


            //Truy vấn đến hàm SQL để kiểm tra tồn tại
            string Sql = "Select Masv from T_Sach where Masach ='" + Masach + "'";
        }

        private void T_Sach_Load(object sender, EventArgs e)
        {
            DGV_HienThi();
            Doc_manxb();
        }
        private void DGV_HienThi()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            //Khởi tạo 1 table
            DataTable Dt = new DataTable();
            string sql_Sach = "Select * from T_Sach";
            SqlDataAdapter Mydata = new SqlDataAdapter(sql_Sach, strconn);
            Mydata.Fill(Dt);//đổ dữ liệu Dt
            dgvsach.DataSource = Dt;//hiển thị dữ liệu lên DGView
            strconn.Close();

        }
        private void Doc_manxb()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sql_sach = "select Manxb,Tennxb from T_Nxb";
            SqlCommand cmd = new SqlCommand(sql_sach, strconn);
            SqlDataReader Dr = cmd.ExecuteReader();
            while (Dr.Read())
            {
                cbmanxb.Items.Add(Dr[0].ToString());
            }
            strconn.Close();
        }

        private void dgvsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmasach.Text = dgvsach.CurrentRow.Cells[0].Value.ToString();
            txttensach.Text = dgvsach.CurrentRow.Cells[1].Value.ToString();
            cbmanxb.Text = dgvsach.CurrentRow.Cells[2].Value.ToString();
            txttacgia.Text = dgvsach.CurrentRow.Cells[3].Value.ToString();
            txttheloai.Text = dgvsach.CurrentRow.Cells[4].Value.ToString();
            txtsoluong.Text = dgvsach.CurrentRow.Cells[5].Value.ToString();
            tgmasach.Text = dgvsach.CurrentRow.Cells[0].Value.ToString();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            //kết nối
            strconn = new SqlConnection(chuoi);
            strconn.Open();

            string sql_xoa = "Delete from T_Sach where Masach = N'" + txtmasach.Text + "'";
            SqlCommand cmd = new SqlCommand(sql_xoa, strconn);
            if (txtmasach.Text == "")
            {
                MessageBox.Show("Chưa nhập sách  cần xóa?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmasach.Focus();
            }
            else
            {
                DialogResult Rsult = MessageBox.Show("Có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Rsult == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    Xoa();
                    DGV_HienThi();
                }
            }
            strconn.Close();
        }

        private void btrs_Click(object sender, EventArgs e)
        {
            Xoa();
        }
        private void Xoa()
        {

            txtmasach.Clear();
            txttensach.Clear();
            cbmanxb.Focus();
            txttacgia.Clear();
            txttheloai.Clear();
            txtsoluong.Clear();

        }

        private void btsua_Click(object sender, EventArgs e)
        {
            //ket noi
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string tg = tgmasach.Text;
            string Masach = txtmasach.Text;
            string Tensach = txttensach.Text;
            string Manxb = cbmanxb.Text;
            string Tacgia = txttacgia.Text;
            string Theloai = txttheloai.Text;
            string Soluong = txtsoluong.Text;


            string sql_sua1 = "Update T_Sach set Masach=N'" + Masach + "', Tensach=N'" + Tensach + "',Manxb=N'" + Manxb + "',Tacgia=N'" + Tacgia + "',Theloai=N'" + Theloai + "',Soluong=N'" + Soluong + "' where Masach=N'" + tg + "'";
            string sql_sua2 = "Update T_Sach set Masach=N'" + Masach + "', Tensach=N'" + Tensach + "',Manxb=N'" + Manxb + "',Tacgia=N'" + Tacgia + "',Theloai=N'" + Theloai + "',Soluong=N'" + Soluong + "' where Masach=N'" + tg + "'";

            SqlCommand cmd1 = new SqlCommand(sql_sua1, strconn);
            SqlCommand cmd2 = new SqlCommand(sql_sua2, strconn);


            if (Masach == "")
            {
                MessageBox.Show("Chưa nhập mã sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult Rsult = MessageBox.Show("có chắc chắn sửa không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);



                if (Rsult == DialogResult.Yes)
                {
                    cmd2.ExecuteNonQuery();

                }
                else
                { 
                        cmd1.ExecuteNonQuery();
                }
                Xoa();
                DGV_HienThi();
            }
        }

        private void btsearch_Click(object sender, EventArgs e)
        {
            ///Kết nối
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            if (txttimkiem.Text == "")
            {
                DGV_HienThi();
            }
            else
            {
                //Khởi tạo 1 Table
                DataTable Dt = new DataTable();
                string sql_sach = "Select * from T_Sach where Masach like N'%" + txttimkiem.Text + "%' or Tensach like N'%" + txttimkiem.Text + "%' or Theloai like N'%" + txttimkiem.Text + "%' or Tacgia like N'%" + txttimkiem.Text + "%' or Manxb like N'%" + txttimkiem.Text + "%'";
                SqlDataAdapter Mydata = new SqlDataAdapter(sql_sach, strconn);
                Mydata.Fill(Dt);//Đổ dữ liệu vào Dt
                dgvsach.DataSource = Dt;// Hiển thị dữ liệu lền DGView
                txttimkiem.Clear();
            }

            strconn.Close();
        }
        private void cbmanxb_SelectedIndexChanged(object sender, EventArgs e)
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string laydlnxb = "select * from T_Nxb where Manxb='" + cbmanxb.SelectedItem.ToString() + "'";
            SqlCommand cmd = new SqlCommand(laydlnxb, strconn);
            SqlDataReader Dr5 = cmd.ExecuteReader();
            while (Dr5.Read())
            {
                txttennxb.Text = Dr5.GetString(1);
            }
            strconn.Close();
        }
    }
}
