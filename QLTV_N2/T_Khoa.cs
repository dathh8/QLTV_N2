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
    public partial class T_Khoa : Form
    {
        public T_Khoa()
        {
            InitializeComponent();
        }
        //Tạo chuỗi kết nối
        String chuoi = @"Data Source=DESKTOP-9FMR7OR\HUUDAT;Initial Catalog=QLTV_N2;Integrated Security=True";
        //Khởi tạo đối tượng Connection
        SqlConnection strconn;
        private Boolean Kiemtra_Dup1()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sql_kt = "Select * from T_Khoa where Makhoa=N'" + txtmakhoa.Text + "'";
            SqlCommand cmd = new SqlCommand(sql_kt, strconn);
            SqlDataReader Dr = cmd.ExecuteReader();
            Boolean kt = true;
            while (Dr.Read())
            {

                if (tgmakhoa.Text == Dr[0].ToString())
                {
                    kt = false;
                    MessageBox.Show("Trùng mã khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtmakhoa.Text = "";
                    txtmakhoa.Focus();
                    break;
                }
            }
            strconn.Close();
            return kt;
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void T_Khoa_Load(object sender, EventArgs e)
        {
            DGV_Hienthi();
        }
        private void DGV_Hienthi()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            //Khởi tạo 1 table
            DataTable Dt = new DataTable();
            String sql_Khoa = "Select * from T_Khoa";
            SqlDataAdapter Mydata = new SqlDataAdapter(sql_Khoa, strconn);
            Mydata.Fill(Dt);//Đổ dữ liệu Dt
            dgvkhoa.DataSource = Dt;//Hiển thị dữ liệu lên DGView
            strconn.Close();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            //Khởi tao đối tượng Connection 
            strconn = new SqlConnection(chuoi);

            //Mở kết nối
            strconn.Open();

            //Lấy dữ liệu trên Form
            string Makhoa = txtmakhoa.Text;
            string Tenkhoa = txttenkhoa.Text;
            string Tentruongkhoa = txttentruongkhoa.Text;
            string Sdtkhoa = txtsdt.Text;
            string Email = txtemail.Text;


            //Chuỗi sql dạng insert
            //Dùng kí tự N' trước mỗi giá trị kiểu text để insert giá trị có dấu Tiếng Việt được đúng

            string sqladd = "Insert into T_Khoa values(N'" + Makhoa + "', N'" + Tenkhoa + "',N'" + Tentruongkhoa + "', N'" + Sdtkhoa + "',N'" + Email + "')";
            //Khởi tạo đối tượng Command
            if (Makhoa == "")
            {
                MessageBox.Show("Chưa nhập mã Khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand cmd = new SqlCommand(sqladd, strconn);
                if (Kiemtra_Dup1())
                {
                    cmd.ExecuteNonQuery();
                    DGV_Hienthi();
                    Xoa();
                }
            }
            
            strconn.Close();

            //Truy vấn đến hàm SQL để kiểm tra tồn tại
            string Sql = "Select Makhoa from T_Khoa where Makhoa = '" + Makhoa + "'";
        }

        private void btrs_Click(object sender, EventArgs e)
        {
            Xoa();
        }
        private void Xoa()
        {
            txtmakhoa.Clear();
            txttenkhoa.Clear();
            txttentruongkhoa.Clear();
            txtsdt.Clear();
            txtemail.Clear();
            tgmakhoa.Clear();
        }

        private void dgvkhoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmakhoa.Text = dgvkhoa.CurrentRow.Cells[0].Value.ToString();
            txttenkhoa.Text = dgvkhoa.CurrentRow.Cells[1].Value.ToString();
            txttentruongkhoa.Text = dgvkhoa.CurrentRow.Cells[2].Value.ToString();
            txtsdt.Text = dgvkhoa.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = dgvkhoa.CurrentRow.Cells[4].Value.ToString();
            tgmakhoa.Text = dgvkhoa.CurrentRow.Cells[0].Value.ToString();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            //kết nối
            strconn = new SqlConnection(chuoi);
            strconn.Open();

            string sql_xoa = "Delete from T_Khoa where Makhoa = N'" + txtmakhoa.Text + "'";
            SqlCommand cmd = new SqlCommand(sql_xoa, strconn);
            if (txtmakhoa.Text == "")
            {
                MessageBox.Show("Chưa nhập khoa  cần xóa?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmakhoa.Focus();
            }
            else
            {
                DialogResult Rsult = MessageBox.Show("Có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Rsult == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    Xoa();
                    DGV_Hienthi();
                }
            }
            strconn.Close();
        }

        private void btsearch_Click(object sender, EventArgs e)
        {
            ///Kết nối
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            if (txttimkiem.Text == "")
            {
                DGV_Hienthi();
            }
            else
            {
                //Khởi tạo 1 Table
                DataTable Dt = new DataTable();
                string sql_khoa = "Select * from T_Khoa where Makhoa like N'%" + txttimkiem.Text + "%' or Tenkhoa like N'%" + txttimkiem.Text + "%' or Tentruongkhoa like N'%" + txttimkiem.Text + "%'";
                SqlDataAdapter Mydata = new SqlDataAdapter(sql_khoa, strconn);
                Mydata.Fill(Dt);//Đổ dữ liệu vào Dt
                dgvkhoa.DataSource = Dt;// Hiển thị dữ liệu lền DGView
                txttimkiem.Clear();
            }

            strconn.Close();
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            //ket noi
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string tg = tgmakhoa.Text;
            string Makhoa = txtmakhoa.Text;
            string Tenkhoa = txttenkhoa.Text;
            string Tentruongkhoa = txttentruongkhoa.Text;
            string Sdtkhoa = txtsdt.Text;
            string Email = txtemail.Text;

            string sql_sua1 = "Update T_Khoa set Makhoa=N'" + Makhoa + "',Tenkhoa=N'" + Tenkhoa + "', Tentruongkhoa=N'" + Tentruongkhoa + "',Sdtkhoa=N'" + Sdtkhoa + "',Email=N'" + Email + "'where Makhoa=N'" + tg + "'";
            string sql_sua2 = "Update T_Khoa set Makhoa=N'" + Makhoa + "',Tenkhoa=N'" + Tenkhoa + "', Tentruongkhoa=N'" + Tentruongkhoa + "',Sdtkhoa=N'" + Sdtkhoa + "',Email=N'" + Email + "'where Makhoa=N'" + tg + "'";

            SqlCommand cmd1 = new SqlCommand(sql_sua1, strconn);
            SqlCommand cmd2 = new SqlCommand(sql_sua2, strconn);


            if (Makhoa == "")
            {
                MessageBox.Show("Chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (Kiemtra_Dup1())
                    {
                        cmd1.ExecuteNonQuery();
                    }
                }
                Xoa();
                DGV_Hienthi();
            }
        }

        private void txttenkhoa_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
