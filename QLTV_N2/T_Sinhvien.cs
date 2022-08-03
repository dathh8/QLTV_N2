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
    public partial class T_Sinhvien : Form
    {

        //Tạo chuỗi kết nối
        String chuoi = @"Data Source=DESKTOP-9FMR7OR\HUUDAT;Initial Catalog=QLTV_N2;Integrated Security=True";
        //Khởi tạo đối tượng Connection 
        SqlConnection strconn;

        public T_Sinhvien()
        {
            InitializeComponent();
        }
        private Boolean Kiemtra_Dup()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sql_kt1 = "Select * from T_Sinhvien where Masv=N'" + txtmasv.Text + "'";
            SqlCommand cmd = new SqlCommand(sql_kt1, strconn);
            SqlDataReader Dr = cmd.ExecuteReader();
            Boolean kt = true;
            while (Dr.Read())
            {

                if (tgmasv.Text == Dr[0].ToString())
                {
                    kt = false;
                    MessageBox.Show("Trùng mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtmasv.Text = "";
                    txtmasv.Focus();
                    break;
                }
            }
            strconn.Close();
            return kt;
        }


            private void T_Sinhvien_Load(object sender, EventArgs e)
        {
            DGV_HienThi();
            Doc_makhoa();
        } 
        private void DGV_HienThi()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            //Khởi tạo 1 table
            DataTable Dt = new DataTable();
            string sql_Sinhvien = "Select * from T_Sinhvien";
            SqlDataAdapter Mydata = new SqlDataAdapter(sql_Sinhvien, strconn);
            Mydata.Fill(Dt);//đổ dữ liệu Dt
            dgv.DataSource = Dt;//hiển thị dữ liệu lên DGView
            strconn.Close();

        }
        private void Doc_makhoa()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sql_khoa = "select Makhoa,Tenkhoa from T_Khoa";
            SqlCommand cmd = new SqlCommand(sql_khoa, strconn);
            SqlDataReader Dr = cmd.ExecuteReader();
            while (Dr.Read())
            {
                cbmakhoa.Items.Add(Dr[0].ToString());
            }
            strconn.Close();
        }


        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmasv.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txttensv.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txtlop.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            cbmakhoa.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            datengaysinh.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            cbgioitinh.Text = dgv.CurrentRow.Cells[5].Value.ToString();
            txtsdt.Text = dgv.CurrentRow.Cells[6].Value.ToString();
            txtemail.Text = dgv.CurrentRow.Cells[7].Value.ToString();
            txtdiachi.Text = dgv.CurrentRow.Cells[8].Value.ToString();
            tgmasv.Text = dgv.CurrentRow.Cells[0].Value.ToString();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
   
        private void Xoa()
        {

            txtmasv.Clear();
            txttensv.Clear();
            txtlop.Clear();
            cbmakhoa.Focus();
            cbgioitinh.Focus();
            txtsdt.Clear();
            txtemail.Clear();
            txtdiachi.Clear();

        }

        private void cbmakhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string laydlkhoa = "select * from T_Khoa where  Makhoa='" + cbmakhoa.SelectedItem.ToString() + "'";
            SqlCommand cmd = new SqlCommand(laydlkhoa, strconn);
            SqlDataReader Dr5 = cmd.ExecuteReader();
            while (Dr5.Read())
            {
                txttenkhoa.Text = Dr5.GetString(1);
            }
            strconn.Close();

        }

       

        private void btthem_Click_1(object sender, EventArgs e)
        {
            // Khoi tao doi tuong Conne0ction
            strconn = new SqlConnection(chuoi);

            //tạo thêm mã tự động 
            int count = 0;
            count = dgv.Rows.Count;
            string chuoi1 = "";
            int chuoi2 = 0;
            chuoi1 = Convert.ToString(dgv.Rows[count - 2].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi1.Remove(0, 2)));//loại bỏ ký thự SV
            if (chuoi2 + 1 < 10)
                txtmasv.Text = "SV00" + (chuoi2 + 1).ToString();//cộng dồn khi thỏa mãn điều kiện
            else if (chuoi2 + 1 < 100)
                txtmasv.Text = "SV0" + (chuoi2 + 1).ToString();

            //Mở kết nối
            strconn.Open();
            //Lấy dữ liệu trên Form
            string Masv = txtmasv.Text;
            string Tensv = txttensv.Text;
            string Lop = txtlop.Text;
            string Makhoa = cbmakhoa.Text;
            string Ngaysinh = datengaysinh.Text;
            string Gioitinh = cbgioitinh.Text;
            string Sdt = txtsdt.Text;
            string Email = txtemail.Text;
            string Diachi = txtdiachi.Text;
            string Tenkhoa = txttenkhoa.Text;
            //chuoi sql dang insert
            //Dùng ký tự N' trước mỗi giá trị kiểu text để insert giá trị có dấu tiếng việt vào CSDL được đúng 

            string sqladd = "Insert into T_Sinhvien values(N'" + Masv + "', N'" + Tensv + "',N'" + Lop + "',N'" + Makhoa + "',N'" + Ngaysinh + "',N'" + Gioitinh + "',N'" + Sdt + "',N'" + Email + "',N'" + Diachi + "',N'" + Tenkhoa + "')";
            //khoi tao doi tuong Command

            if (Masv == "")
            {
                MessageBox.Show("Chưa nhập mã sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand cmd = new SqlCommand(sqladd, strconn);
                
                
                    cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm sinh viên thành công.", "Thông Báo");
                DGV_HienThi();
                    Xoa();
                
            }
            strconn.Close();


            //Truy vấn đến hàm SQL để kiểm tra tồn tại
            string Sql = "Select Masv from T_Sinhvien where Masv ='" + Masv + "'";
        }

        private void btsua_Click_1(object sender, EventArgs e)
        {
            //ket noi
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string tg = tgmasv.Text;
            string Masv = txtmasv.Text;
            string Tensv = txttensv.Text;
            string Lop = txtlop.Text;
            string Makhoa = cbmakhoa.Text;
            string Ngaysinh = datengaysinh.Text;
            string Gioitinh = cbgioitinh.Text;
            string Sdt = txtsdt.Text;
            string Email = txtemail.Text;
            string DiaChi = txtdiachi.Text;
            string Tenkhoa = txttenkhoa.Text;


            string sql_sua1 = "Update T_Sinhvien set Masv=N'" + Masv + "', Tensv=N'" + Tensv + "',Lop=N'" + Lop + "',Makhoa=N'" + Makhoa + "',Ngaysinh=N'" + Ngaysinh + "',Gioitinh=N'" + Gioitinh + "', Sdt=N'" + Sdt + "',Email=N'" + Email + "',Diachi=N'" + DiaChi + "',Tenkhoa=N'" + Tenkhoa + "' where Masv=N'" + tg + "'";
            string sql_sua2 = "Update T_Sinhvien set Masv=N'" + Masv + "', Tensv=N'" + Tensv + "',Lop=N'" + Lop + "',Makhoa=N'" + Makhoa + "',Ngaysinh=N'" + Ngaysinh + "',Gioitinh=N'" + Gioitinh + "', Sdt=N'" + Sdt + "',Email=N'" + Email + "',Diachi=N'" + DiaChi + "',Tenkhoa=N'" + Tenkhoa + "' where Masv=N'" + tg +"'";

            SqlCommand cmd1 = new SqlCommand(sql_sua1, strconn);
            SqlCommand cmd2 = new SqlCommand(sql_sua2, strconn);


            if (Masv == "")
            {
                MessageBox.Show("Chưa nhập mã sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult Rsult = MessageBox.Show("có chắc chắn sửa không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);



                if (Rsult == DialogResult.Yes)
                {
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Sửa thông tin sinh viên thành công.", "Thông Báo");

                }
                else
                {
                    
                    
                        cmd1.ExecuteNonQuery();
                    
                }
                Xoa();
                DGV_HienThi();
            }
        }

        private void btsearch_Click_1(object sender, EventArgs e)
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
                string sql_nhanvien = "Select * from T_Sinhvien where Masv like N'%" + txttimkiem.Text + "%' or Tensv like N'%" + txttimkiem.Text + "%' or Diachi like N'%" + txttimkiem.Text + "%' or Gioitinh like N'%" + txttimkiem.Text + "%' or Tenkhoa like N'%" + txttimkiem.Text + "%'";
                SqlDataAdapter Mydata = new SqlDataAdapter(sql_nhanvien, strconn);
                Mydata.Fill(Dt);//Đổ dữ liệu vào Dt
                dgv.DataSource = Dt;// Hiển thị dữ liệu lền DGView
                txttimkiem.Clear();
            }

            strconn.Close();
        }

        private void btxoa_Click_1(object sender, EventArgs e)
        {
            //kết nối
            strconn = new SqlConnection(chuoi);
            strconn.Open();

            string sql_xoa = "Delete from T_Sinhvien where Masv = N'" + txtmasv.Text + "'";
            SqlCommand cmd = new SqlCommand(sql_xoa, strconn);
            if (txtmasv.Text == "")
            {
                MessageBox.Show("Chưa nhập sinh viên  cần xóa?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmasv.Focus();
            }
            else
            {
                DialogResult Rsult = MessageBox.Show("Có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Rsult == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa sinh viên thành công.", "Thông Báo");
                    Xoa();
                    DGV_HienThi();
                }
            }
            strconn.Close();
        }

        private void btrs_Click_1(object sender, EventArgs e)
        {
            Xoa();
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
           
           
        }
    }
    }
    

