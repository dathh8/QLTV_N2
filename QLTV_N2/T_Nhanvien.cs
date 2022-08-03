using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV_N2
{
    public partial class T_Nhanvien : Form
    {
        public T_Nhanvien()
        {
            InitializeComponent();
        }
        //Tạo chuỗi kết nối
        String chuoi = @"Data Source=DESKTOP-9FMR7OR\HUUDAT;Initial Catalog=QLTV_N2;Integrated Security=True";
        //Khởi tạo đối tượng Connection 
        SqlConnection strconn;
        private Boolean Kiemtra_Dup()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sql_kt1 = "Select * from T_Nhanvien where Manv=N'" + txtmanv.Text + "'";
            SqlCommand cmd = new SqlCommand(sql_kt1, strconn);
            SqlDataReader Dr = cmd.ExecuteReader();
            Boolean kt1 = true;
            while (Dr.Read())
            {

                if (manvtg.Text == Dr[0].ToString())
                {
                    kt1 = false;
                    MessageBox.Show("Trùng mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtmanv.Text = "";
                    txtmanv.Focus();
                    break;
                }
            }
            strconn.Close();
            return kt1;
        }

        private void T_Nhanvien_Load(object sender, EventArgs e)
        {
            DGV_HienThi();
        }
        //hien thi View
        private void DGV_HienThi()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            //Khởi tạo 1 table
            DataTable Dt = new DataTable();
            string sql_Nhanvien = "Select * from T_Nhanvien";
            SqlDataAdapter Mydata = new SqlDataAdapter(sql_Nhanvien, strconn);
            Mydata.Fill(Dt);//đổ dữ liệu Dt
            dgvnhanvien.DataSource = Dt;//hiển thị dữ liệu lên DGView
            strconn.Close();

        }
        private void dgvnhanvien_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }

        private void dgvnhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmanv.Text = dgvnhanvien.CurrentRow.Cells[0].Value.ToString();
            txttennv.Text = dgvnhanvien.CurrentRow.Cells[2].Value.ToString();
            datengaysinh.Text = dgvnhanvien.CurrentRow.Cells[3].Value.ToString();
            cbgioitinh.Text = dgvnhanvien.CurrentRow.Cells[4].Value.ToString();
            txtdiachi.Text = dgvnhanvien.CurrentRow.Cells[5].Value.ToString();
            txtsdt.Text = dgvnhanvien.CurrentRow.Cells[6].Value.ToString();
            txtemail.Text = dgvnhanvien.CurrentRow.Cells[7].Value.ToString();
            txtmatkhau.Text = dgvnhanvien.CurrentRow.Cells[1].Value.ToString();
            manvtg.Text = dgvnhanvien.CurrentRow.Cells[0].Value.ToString();

        }

        private void btthem_Click(object sender, EventArgs e)
        {
            // Khoi tao doi tuong Connection
            strconn = new SqlConnection(chuoi);

            //Mở kết nối
            strconn.Open();
            //Lấy dữ liệu trên Form
            string tg = manvtg.Text;
            string Manv = txtmanv.Text;
            string Tennv = txttennv.Text;
            string Mknv = txtmatkhau.Text;
            string Ngaysinh = datengaysinh.Text;
            string Gioitinh = cbgioitinh.Text;
            string Diachi = txtdiachi.Text;
            string Sdt = txtsdt.Text;
            string Email = txtemail.Text;
            //chuoi sql dang insert
            //Dùng ký tự N' trước mỗi giá trị kiểu text để insert giá trị có dấu tiếng việt vào CSDL được đúng 

            string sqladd = "Insert into T_Nhanvien values(N'" + Manv + "', N'" + Mknv + "',N'" + Tennv + "',N'" + Ngaysinh + "',N'" + Gioitinh + "',N'" + Diachi + "',N'" + Sdt + "',N'" + Email + "')";
            //khoi tao doi tuong Command

            if (Manv == "")
            {
                MessageBox.Show("Chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand cmd = new SqlCommand(sqladd, strconn);
                if (Kiemtra_Dup())
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân viên thành công.", "Thông Báo");
                    DGV_HienThi();
                    Xoa();
                }
            }
            strconn.Close();


            //Truy vấn đến hàm SQL để kiểm tra tồn tại
            string Sql = "Select Manv from T_Nhanvien where Manv ='" + Manv + "'";
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            //kết nối
            strconn = new SqlConnection(chuoi);
            strconn.Open();

            string sql_xoa = "Delete from T_Nhanvien where Manv = N'" + txtmanv.Text + "'";
            SqlCommand cmd = new SqlCommand(sql_xoa, strconn);
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Chưa nhập nhân viên  cần xóa?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanv.Focus();
            }
            else
            {
                DialogResult Rsult = MessageBox.Show("Có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Rsult == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa nhân viên thành công.", "Thông Báo");
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
            manvtg.Clear();
            txtmanv.Clear();
            txttennv.Clear();
            cbgioitinh.Focus();
            txtdiachi.Clear();
            txtsdt.Clear();
            txtemail.Clear();
            txtmatkhau.Clear();

        }

        private void btsua_Click(object sender, EventArgs e)
        {
            //ket noi
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string tg = manvtg.Text;
            string Manv = txtmanv.Text;
            string Matkhau = txtmatkhau.Text;
            string Tennv = txttennv.Text;
            string Ngaysinh = datengaysinh.Text;
            string Gioitinh = cbgioitinh.Text;
            string DiaChi = txtdiachi.Text;
            string Sdt = txtsdt.Text;
            string Email = txtemail.Text;

            string sql_sua1 = "Update T_Nhanvien set Manv=N'" + Manv + "',Mknv=N'" + Matkhau + "', Tennv=N'" + Tennv + "',Ngaysinh=N'" + Ngaysinh + "',Gioitinh=N'" + Gioitinh + "',Diachi=N'" + DiaChi + "',Sdt=N'" + Sdt + "', Email=N'" + Email + "'where manv=N'" + tg + "'";
            string sql_sua2 = "Update T_Nhanvien set Manv=N'" + Manv + "',Mknv=N'" + Matkhau + "', Tennv=N'" + Tennv + "',Ngaysinh=N'" + Ngaysinh + "',Gioitinh=N'" + Gioitinh + "',Diachi=N'" + DiaChi + "',Sdt=N'" + Sdt + "', Email=N'" + Email + "'where manv=N'" + tg + "'";

            SqlCommand cmd1 = new SqlCommand(sql_sua1, strconn);
            SqlCommand cmd2 = new SqlCommand(sql_sua2, strconn);


            if (Manv == "")
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
                    MessageBox.Show("Sửa thông tin nhân viên thành công.", "Thông Báo");

                }
                else
                {
                    if (Kiemtra_Dup())
                    {
                        cmd1.ExecuteNonQuery();
                    }
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
                string sql_nhanvien = "Select * from T_Nhanvien where Manv like N'%" + txttimkiem.Text + "%' or Tennv like N'%" + txttimkiem.Text + "%' or Diachi like N'%" + txttimkiem.Text + "%' or Gioitinh like N'%" + txttimkiem.Text + "%'";
                SqlDataAdapter Mydata = new SqlDataAdapter(sql_nhanvien, strconn);
                Mydata.Fill(Dt);//Đổ dữ liệu vào Dt
                dgvnhanvien.DataSource = Dt;// Hiển thị dữ liệu lền DGView
                txttimkiem.Clear();
            }

            strconn.Close();
        }

        private void datengaysinh_ValueChanged(object sender, EventArgs e)
        {
        
        }

    }
}
