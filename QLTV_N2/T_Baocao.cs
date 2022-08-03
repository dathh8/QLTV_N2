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
    public partial class T_Baocao : Form
    {
        public T_Baocao()
        {
            InitializeComponent();
        }
        //Tạo chuỗi kết nối
        String chuoi = @"Data Source=DESKTOP-9FMR7OR\HUUDAT;Initial Catalog=QLTV_N2;Integrated Security=True";
        //khởi tạo đối tượng Connection
        SqlConnection strconn;
        
        private SqlCommand myCommand;
        private SqlDataAdapter myDataAdapter;
        private DataTable myTable;


        private DataTable ketnoi(string truyvan)
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, strconn);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTable = new DataTable();
            myDataAdapter.Fill(myTable);
            dgvsvqh.DataSource = myTable;
            return myTable;
        }


        private void slDauSach()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string slsach = "select count(MaSach) as TongSLDauSach, sum(Soluong) as TongSLSach  from T_Sach";
            SqlCommand cmd = new SqlCommand(slsach, strconn);
            SqlDataReader Dr = cmd.ExecuteReader();
            while (Dr.Read())
            {
                txtsldausach.Text = Dr[0].ToString();
                txtslsach.Text = Dr[1].ToString();
            }
            strconn.Close();

        }
        // Tính SL Mượn
        private void slsachmuon()
        {
            string strTinhSLMuon = "select sum(Soluong) as Tong from T_Muontra";
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            myCommand = new SqlCommand(strTinhSLMuon, strconn);
            SqlDataReader Dr = myCommand.ExecuteReader();
            while (Dr.Read())
            {
                txtslsachmuon.Text = Dr.GetInt32(0).ToString();
            }

        }
        //tính số sinh viên 
        private void slsinhvien()
        {
            string str_slsv = "select count(Masv) as TongSLDG from T_Sinhvien";
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            myCommand = new SqlCommand(str_slsv, strconn);
            SqlDataReader Dr = myCommand.ExecuteReader();
            while (Dr.Read())
            {
                txtslsv.Text = Dr.GetInt32(0).ToString();
            }
        }
        // Tính SLDG Đã Mượn sách
        private void slsvMuonsach()
        {
            string str_slsvms = "select (count(distinct(Masv))) as TongSLDGMuon from T_Muontra";
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            myCommand = new SqlCommand(str_slsvms, strconn);
            SqlDataReader Dr = myCommand.ExecuteReader();
            while (Dr.Read())
            {
                txtslsvms.Text = Dr.GetInt32(0).ToString();
            }
        }
        private void dgvthongke_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void T_Baocao_Load(object sender, EventArgs e)
        {
            slDauSach();
            slsachmuon();
            slsinhvien();
            slsvMuonsach();
            slSachQuaHan();
            slDSVuaHan();
            //Tính số lượng sách còn lại   
            int slsachcon = Convert.ToInt32(txtslsach.Text) - Convert.ToInt32(txtslsachmuon.Text);
            txtslsachcon.Text = slsachcon.ToString();
        }

        // SL sách quá hạn
        public string luuSLSQuaHan;
        private void slSachQuaHan()
        {
            string str_slsqh = "SELECT count(distinct(Soluong)) as TongSLQuaHan from T_Muontra where CONVERT (datetime, NgayTra, 103) < getdate()";
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            myCommand = new SqlCommand(str_slsqh, strconn);
            SqlDataReader Dr = myCommand.ExecuteReader();
            while (Dr.Read())
            {
                txtsachquahan.Text = Dr.GetInt32(0).ToString();
            }

        }

        // SL SV quá hạn
        public string luuSLSVQuaHan;
        private void slDSVuaHan()
        {
            string str_slsqh = "SELECT count(distinct(Masv)) as TongSLQuaHan from T_Muontra where CONVERT (datetime, NgayTra, 103) < getdate()";
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            myCommand = new SqlCommand(str_slsqh, strconn);
            SqlDataReader Dr = myCommand.ExecuteReader();
            while (Dr.Read())
            {
                txtslsvqh.Text = Dr.GetInt32(0).ToString();
            }

        }
        //hien thi View
        private void DGV_HienThisinhvienquahan()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            //Khởi tạo 1 table
            DataTable Dt = new DataTable();
            string sql_Nhanvien = @"SELECT Masv as 'Mã SV', count(Soluong) as 'SL Sách Mượn' from T_Muontra where CONVERT (datetime, NgayTra, 103) <= getdate() group by Masv";
            SqlDataAdapter Mydata = new SqlDataAdapter(sql_Nhanvien, strconn);
            Mydata.Fill(Dt);//đổ dữ liệu Dt
            dgvsvqh.DataSource = Dt;//hiển thị dữ liệu lên DGView
            strconn.Close();

        }


        private void txtsldausach_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btsvqh_Click(object sender, EventArgs e)
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            //Khởi tạo 1 table
            DataTable Dt = new DataTable();
            string sql_Nhanvien = @"SELECT Masv as 'Mã SV', count(Soluong) as 'SL Sách Mượn' from T_Muontra where CONVERT (datetime, NgayTra, 103) <= getdate() group by Masv";
            SqlDataAdapter Mydata = new SqlDataAdapter(sql_Nhanvien, strconn);
            Mydata.Fill(Dt);//đổ dữ liệu Dt
            dgvsvqh.DataSource = Dt;//hiển thị dữ liệu lên DGView
            strconn.Close();
        }

        private void btsachqh_Click(object sender, EventArgs e)
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            //Khởi tạo 1 table
            DataTable Dt = new DataTable();
            string sql_Nhanvien = @"SELECT Maphieumuon as 'Mã Phiếu', Masv as 'Mã SV', Masach as 'Mã Sách', Ngaymuon as 'Ngày Mượn', Ngaytra as 'Ngày Trả', Tinhtrang as 'Tình trạng' from T_Muontra where CONVERT (datetime, NgayTra, 103) < getdate()";
            SqlDataAdapter Mydata = new SqlDataAdapter(sql_Nhanvien, strconn);
            Mydata.Fill(Dt);//đổ dữ liệu Dt
            dgvsvqh.DataSource = Dt;//hiển thị dữ liệu lên DGView
            strconn.Close();
        }

        private void btsvqht_Click(object sender, EventArgs e)
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            //Khởi tạo 1 table
            DataTable Dt = new DataTable();
            string sql_Nhanvien = @"SELECT Maphieumuon as 'Mã Phiếu', Masv as 'Mã SV',Tensv as 'Tên SV',Lopsv as 'Lớp',Masach as 'Mã Sách',Tensach as 'Tên sách', Tacgia as 'Tác giả', Ngaymuon as 'Ngày Mượn', Ngaytra as 'Ngày Trả', Tinhtrang as 'Tình trạng' from T_Muontra where CONVERT (datetime, NgayTra, 103) < getdate()";
            SqlDataAdapter Mydata = new SqlDataAdapter(sql_Nhanvien, strconn);
            Mydata.Fill(Dt);//đổ dữ liệu Dt
            dgvsvqh.DataSource = Dt;//hiển thị dữ liệu lên DGView
            strconn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            T_Inphieu2 inphieu2 = new T_Inphieu2();
            inphieu2.ShowDialog();
        }
    }
}
