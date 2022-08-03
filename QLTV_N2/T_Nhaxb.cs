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
    public partial class T_Nhaxb : Form
    {
        public T_Nhaxb()
        {
            InitializeComponent();
        }
        //Tạo chuỗi kết nối
        String chuoi = @"Data Source=DESKTOP-9FMR7OR\HUUDAT;Initial Catalog=QLTV_N2;Integrated Security=True";
        //khởi tạo đối tượng Connection
        SqlConnection strconn;
        private Boolean Kiemtra_Dup()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sql_kt = "Select * from T_Nxb where Manxb=N'" + txtmanxb.Text + "'";
            SqlCommand cmd = new SqlCommand(sql_kt, strconn);
            SqlDataReader Dr = cmd.ExecuteReader();
            Boolean kt = true;
            while (Dr.Read())
            {

                if (tgmanxb.Text == Dr[0].ToString())
                {
                    kt = false;
                    MessageBox.Show("Trùng mã nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtmanxb.Text = "";
                    txtmanxb.Focus();
                    break;
                }
            }
            strconn.Close();
            return kt;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void T_Nhaxb_Load(object sender, EventArgs e)
        {
            DGV_Hienthi();
        }
        //Hiển thị view
        private void DGV_Hienthi()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            //khởi tạo table
            DataTable Dt = new DataTable();
            string sql_Nhaxb = "Select * from T_Nxb";
            SqlDataAdapter Mydata = new SqlDataAdapter(sql_Nhaxb, strconn);
            Mydata.Fill(Dt);//Đổ Dữ liệu Dt
            dgvnxb.DataSource = Dt;//hiển thị Dữ liệu lên DGView
            strconn.Close();

        }

        private void dgvnxb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmanxb.Text = dgvnxb.CurrentRow.Cells[0].Value.ToString();
            txttennxb.Text = dgvnxb.CurrentRow.Cells[1].Value.ToString();
            txtdiachi.Text = dgvnxb.CurrentRow.Cells[2].Value.ToString();
            txtsdt.Text = dgvnxb.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = dgvnxb.CurrentRow.Cells[4].Value.ToString();
            tgmanxb.Text = dgvnxb.CurrentRow.Cells[0].Value.ToString();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            //khởi tạo đối tượng conection
            strconn = new SqlConnection(chuoi);
            //mở kết nối
            strconn.Open();
            //lấy dữ liệu trêm from
            string manxb = txtmanxb.Text;
            string tennxb = txttennxb.Text;
            string dcnxb = txtdiachi.Text;
            string email = txtemail.Text;
            string sdtnxb = txtsdt.Text;
            //chuỗi sql đang insert
            //Dùng ký tự N' trước mỗi giá trị kiểu text để insert giá trị có dấu tiếng việt vào CSDL được đúng
            string sqladd = "insert into T_Nxb values(N'" + manxb + "',N'" + tennxb + "',N'" + dcnxb + "',N'" + email + "',N'" + sdtnxb  + "')";
            //khởi tạo đối tượng Command
            if (manxb == "")
            {
                MessageBox.Show("Chưa nhập mã Nhà Xuất Bản", "thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                SqlCommand cmd = new SqlCommand(sqladd, strconn);
                if (Kiemtra_Dup())
                {
                    cmd.ExecuteNonQuery();
                    DGV_Hienthi();
                    xoa();
                }

            }
            strconn.Close();
            //truy vấn đến hàm Sql đến hàm tồn tại
            string sql = " select manxb from T_Nxb where manxb = '" + manxb + "' ";
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            //ket noi
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string tg = tgmanxb.Text;
            string Manxb = txtmanxb.Text;
            string Tennxb = txttennxb.Text;
            string Diachi = txtdiachi.Text;
            string Email = txtemail.Text;
            string Sdt = txtsdt.Text;

            string sql_sua1 = "Update T_Nxb set Manxb=N'" + Manxb + "',Tennxb=N'" + Tennxb + "', Diachi=N'" + Diachi + "',Email=N'" + Email + "',Sdt=N'" + Sdt + "'where Manxb=N'" + tg + "'";
            string sql_sua2 = "Update T_Nxb set Manxb=N'" + Manxb + "',Tennxb=N'" + Tennxb + "', Diachi=N'" + Diachi + "',Email=N'" + Email + "',Sdt=N'" + Sdt + "'where Manxb=N'" + tg + "'";

            SqlCommand cmd1 = new SqlCommand(sql_sua1, strconn);
            SqlCommand cmd2 = new SqlCommand(sql_sua2, strconn);


            if (Manxb == "")
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
                    if (Kiemtra_Dup())
                    {
                        cmd1.ExecuteNonQuery();
                    }
                }
                xoa();
                DGV_Hienthi();
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            //kết nối
            strconn = new SqlConnection(chuoi);
            strconn.Open();

            string sql_xoa = "Delete from T_Nxb where Manxb = N'" + txtmanxb.Text + "'";
            SqlCommand cmd = new SqlCommand(sql_xoa, strconn);
            if (txtmanxb.Text == "")
            {
                MessageBox.Show("Chưa nhập Nhà xuất bản  cần xóa?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanxb.Focus();
            }
            else
            {
                DialogResult Rsult = MessageBox.Show("Có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Rsult == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    xoa();
                    DGV_Hienthi();
                }
            }
            strconn.Close();
        }

        private void bt_Click(object sender, EventArgs e)
        {
            xoa();
        }
        private void xoa()
        {
            txtmanxb.Clear();
            txttennxb.Clear();
            txtdiachi.Clear();
            txtsdt.Clear();
            txtemail.Clear();
            tgmanxb.Clear();
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
                string sql_nxb = "Select * from T_Nxb where Manxb like N'%" + txttimkiem.Text + "%' or Tennxb like N'%" + txttimkiem.Text + "%'";
                SqlDataAdapter Mydata = new SqlDataAdapter(sql_nxb, strconn);
                Mydata.Fill(Dt);//Đổ dữ liệu vào Dt
                dgvnxb.DataSource = Dt;// Hiển thị dữ liệu lền DGView
                txttimkiem.Clear();
            }

            strconn.Close();
        }
    }
}
