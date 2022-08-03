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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace QLTV_N2
{
    public partial class T_Muontra : Form
    {
        public T_Muontra()
        {
            InitializeComponent();
        }
        //Tạo chuỗi kết nối
        String chuoi = @"Data Source=DESKTOP-9FMR7OR\HUUDAT;Initial Catalog=QLTV_N2;Integrated Security=True";
        //Khởi tạo đối tượng Connection 
        SqlConnection strconn;
        // Khai báo
        private SqlConnection myConnection;
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private DataTable myTable;
        private DataTable myTableSach;
        private DataTable myTableDG;
        private SqlDataReader myDataReaderSach;
        private SqlDataReader myDataReaderSLSachDaMuon;
        //ket noi sql

        private void tabPage1_Click(object sender, EventArgs e)
        {
            DGV_HienThi();
            Doc_masv();
            Doc_masach();
        }
        // Kết nối tới tblSach

        private void DGV_HienThi1()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            //Khởi tạo 1 table
            DataTable Dt = new DataTable();
            string sql_Muontra = "Select * from T_Muontra";
            SqlDataAdapter Mydata = new SqlDataAdapter(sql_Muontra, strconn);
            Mydata.Fill(Dt);//đổ dữ liệu Dt
            dataGridView2.DataSource = Dt;//hiển thị dữ liệu lên DGView
            strconn.Close();

        }
        private void DGV_HienThi()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            //Khởi tạo 1 table
            DataTable Dt = new DataTable();
            string sql_Muontra = "Select * from T_Muontra";
            SqlDataAdapter Mydata = new SqlDataAdapter(sql_Muontra, strconn);
            Mydata.Fill(Dt);//đổ dữ liệu Dt
            dgvmt.DataSource = Dt;//hiển thị dữ liệu lên DGView
            strconn.Close();

        }
        private void Doc_masv()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sql_Sinhvien = "select Masv,Tensv from T_Sinhvien";
            SqlCommand cmd = new SqlCommand(sql_Sinhvien, strconn);
            SqlDataReader Dr = cmd.ExecuteReader();
            while (Dr.Read())
            {
                cbmasv.Items.Add(Dr[0].ToString());
            }
            strconn.Close();
        }
        private void Doc_masach()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sql_sach = "select Masach,Tensach from T_Sach";
            SqlCommand cmd = new SqlCommand(sql_sach, strconn);
            SqlDataReader Dr = cmd.ExecuteReader();
            while (Dr.Read())
            {
                cbmasach.Items.Add(Dr[0].ToString());
            }
            strconn.Close();
        }

        private void dgvmt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaphieu.Text = dgvmt.CurrentRow.Cells[0].Value.ToString();
            cbmasv.Text = dgvmt.CurrentRow.Cells[1].Value.ToString();
            cbmasach.Text = dgvmt.CurrentRow.Cells[2].Value.ToString();
            txtsoluong.Text = dgvmt.CurrentRow.Cells[3].Value.ToString();
            datengaymuon.Text = dgvmt.CurrentRow.Cells[4].Value.ToString();   
            datengaytra.Text = dgvmt.CurrentRow.Cells[5].Value.ToString();
            cbtinhtrang.Text = dgvmt.CurrentRow.Cells[6].Value.ToString();

       
        }
        private void T_Muontra_Load(object sender, EventArgs e)
        {

            DGV_HienThi1();
            DGV_HienThi();
            Doc_masv();
            Doc_masach();
        }


        private void cbmasach_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string laydlsach = "select * from T_Sach where Masach='" + cbmasach.SelectedItem.ToString() + "'";
            SqlCommand cmd = new SqlCommand(laydlsach, strconn);
            SqlDataReader Dr5 = cmd.ExecuteReader();
            while (Dr5.Read())
            {
                txtmasach.Text = Dr5.GetString(0);
                txttensach.Text = Dr5.GetString(1);
                txtsl.Text = Dr5.GetInt32(5).ToString();
                txttentg.Text = Dr5.GetString(3);
            }
            strconn.Close();
        }


        private void cbmasv_SelectedIndexChanged(object sender, EventArgs e)
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string laydlsv = "select * from T_Sinhvien where Masv='" + cbmasv.SelectedItem.ToString() + "'";
            SqlCommand cmd = new SqlCommand(laydlsv, strconn);
            SqlDataReader Dr5 = cmd.ExecuteReader();
            while (Dr5.Read())
            {
                txtmasinhvien.Text = Dr5.GetString(0);
                txttensinhvien.Text = Dr5.GetString(1);
                txtlopsinhvien.Text = Dr5.GetString(2);
            }
            strconn.Close();
        }

        public int luuslsachdamuon;
        private void slSachDaMuon()
        {
            string strTinhSLSachDaMuon = "select sum(Soluong) as Tong from T_Muontra where Masv='" + cbmasv.Text + "' group by Masv";
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string thuchiencaulenh = strTinhSLSachDaMuon;
            SqlCommand cmd1 = new SqlCommand(thuchiencaulenh, strconn);
            SqlDataReader Dr10 = cmd1.ExecuteReader();
            while (Dr10.Read())
            {
                luuslsachdamuon = Convert.ToInt32(Dr10.GetInt32(0).ToString());
            }
            Dr10.Close();

        }

        

        //Xử lý cho mượn sách:
        public int xuly;
        public static DateTime today = DateTime.Now;  //Get Date time now on system
        public static DateTime newday = today.AddDays(21);
        public string ngaymuon, thangmuon, nammuon, ngaytra, thangtra, namtra, ngaydgmuon, ngaydgtra;
        public int hieumuon, hieutra, catthangmuon, catngaymuon, catngaytra, catthangtra, songaymuon, sothangmuon, sonammuon, songaytra, sothangtra, sonamtra, kq;

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (xuly == 0)
            {
                muonSach();
            }
            else if (xuly == 1)
            {
                giaHanSach();


            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            setControlsMuon(false);
            btnluu.Text = "";
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            dgvmt.Enabled = true;

            dgvmt.Enabled = true;
            btmuon.Enabled = true;
            btrs.Enabled = true;
            btgiahan.Enabled = true;
            btinphieu.Enabled = true;
            btnhuy.Text = "";
        }

        private void btgiahan_Click(object sender, EventArgs e)
        {
            btnhuy.Text = "Hủy";
            btnluu.Text = "Gia hạn";
            setControlsMuon(false);
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
            dgvmt.Enabled = true;
            btmuon.Enabled = false;
            btrs.Enabled = false;
            btgiahan.Enabled = false;
            btinphieu.Enabled = false;
            txtmaphieu.Text = "";
            cbmasv.Text = "";
            cbmasach.Text = "";
            txtsoluong.Text = "";
            datengaymuon.Text = Convert.ToString(today); ;
            datengaytra.Text = Convert.ToString(newday);
            //dtmNgayTra0.Text = "";
            datengaymuon.Enabled = false;
            datengaytra.Enabled = true;
            cbtinhtrang.Text = "";

            txtsl.Text = "";
            xuly = 1;
        }

        private void bttimkiem2_Click(object sender, EventArgs e)
        {
            ///Kết nối
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            if (txttimkiem2.Text == "")
            {
                DGV_HienThi1();
            }
            else
            {
                //Khởi tạo 1 Table
                DataTable Dt = new DataTable();
                string sql_mt = "Select * from T_Muontra where Maphieumuon like N'%" + txttimkiem2.Text + "%' or Masach like N'%" + txttimkiem2.Text + "%' or Masv like N'%" + txttimkiem2.Text + "%' or Tinhtrang like N'%" + txttimkiem2.Text + "%' or Ngaymuon like N'%" + txttimkiem2.Text + "%'";
                SqlDataAdapter Mydata = new SqlDataAdapter(sql_mt, strconn);
                Mydata.Fill(Dt);//Đổ dữ liệu vào Dt
                dataGridView2.DataSource = Dt;// Hiển thị dữ liệu lền DGView
                txttimkiem2.Clear();
            }

            strconn.Close();
        }

        private void btinphieu_Click(object sender, EventArgs e)
        {
            T_Inphieu inphieu = new T_Inphieu();
            inphieu.ShowDialog();
        }

        private void btmuonsach_Click(object sender, EventArgs e)
        {
          
        }

        public void soSanhNgay()
        {
            catngaymuon = datengaymuon.Text.IndexOf("/");
            ngaymuon = datengaymuon.Text.Substring(0, catngaymuon);
            catthangmuon = datengaymuon.Text.LastIndexOf("/");
            hieumuon = (catthangmuon - 1) - catngaymuon;
            thangmuon = datengaymuon.Text.Substring(catngaymuon + 1, hieumuon);
            nammuon = datengaymuon.Text.Substring(catthangmuon + 1, 4);

            songaymuon = Convert.ToInt32(ngaymuon);
            sothangmuon = Convert.ToInt32(thangmuon);
            sonammuon = Convert.ToInt32(nammuon);

            catngaytra = datengaytra.Text.IndexOf("/");
            ngaytra = datengaytra.Text.Substring(0, catngaytra);
            catthangtra = datengaytra.Text.LastIndexOf("/");
            hieutra = (catthangtra - 1) - catngaytra;
            thangtra = datengaytra.Text.Substring(catngaytra + 1, hieutra);
            namtra = datengaytra.Text.Substring(catthangtra + 1, 4);

            songaytra = Convert.ToInt32(ngaytra);
            sothangtra = Convert.ToInt32(thangtra);
            sonamtra = Convert.ToInt32(namtra);

            DateTime tgMuon = new DateTime(sonammuon, sothangmuon, songaymuon);
            DateTime tgTra = new DateTime(sonamtra, sothangtra, songaytra);


            //MessageBox.Show("Ngày mượn: " + ngaymuon + "Tháng mượn: " + thangmuon + "Năm mượn: " + nammuon);
            kq = tgTra.CompareTo(tgMuon);
            //MessageBox.Show("kq: " + kq, "Thông Báo");
            //DateTime ngaymuon= new DateTime()
        }
        private void muonSach()
        {
            // Khoi tao doi tuong Conne0ction
            strconn = new SqlConnection(chuoi);



            //tạo thêm mã tự động 
            int count = 0;
            count = dgvmt.Rows.Count;
            string chuoi1 = "";
            int chuoi2 = 0;
            chuoi1 = Convert.ToString(dgvmt.Rows[count - 2].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi1.Remove(0, 2)));//loại bỏ ký thự SV
            if (chuoi2 + 1 < 10)
                txtmaphieu.Text = "PM00" + (chuoi2 + 2).ToString();//cộng dồn khi thỏa mãn điều kiện
            else if (chuoi2 + 1 < 100)
                txtmaphieu.Text = "PM0" + (chuoi2 + 2).ToString();

            //Mở kết nối
            strconn.Open();
            //Lấy dữ liệu trên Form
            string Maphieu = txtmaphieu.Text;
            string Masv = cbmasv.Text;
            string Masach = cbmasach.Text;
            string Soluong = txtsoluong.Text;
            string Ngaymuon = datengaymuon.Text;
            string Ngaytra = datengaytra.Text;
            string Tinhtrang = cbtinhtrang.Text;
            string Tensv = txttensinhvien.Text;
            string Tensach = txttensach.Text;
            string Lopsv = txtlopsinhvien.Text;
            string Tacgia = txttentg.Text;
            //datengaymuon.Text = Convert.ToString(today); ;
            //datengaytra.Text = Convert.ToString(newday);
            //chuoi sql dang insert
            //Dùng ký tự N' trước mỗi giá trị kiểu text để insert giá trị có dấu tiếng việt vào CSDL được đúng 


            //khoi tao doi tuong Command
            if (cbmasv.Text == "")
            {
                errmasv.SetError(cbmasach, "Vui lòng chọn Mã Sinh viên");
            }
            else
            {
                errmasv.Clear();
            }

            if (cbmasach.Text == "")
            {
                errmasach.SetError(cbmasach, "Vui lòng chọn Mã Sách");
            }
            else
            {
                errmasach.Clear();
            }

            if (txtsl.Text == "")
            {
                errslmuon.SetError(txtsl, "Vui lòng chọn SL Mượn");
            }
            bool nhapsachmuon = int.TryParse(txtsoluong.Text, out SLsachmuon);
            if (nhapsachmuon == false)
            {
                MessageBox.Show("Vui lòng nhập số trong ô SL", "Thông Báo");
            }
            slSachDaMuon();
            SLsachcon = Convert.ToInt32(txtsl.Text);
            luuSLSauChoMuon = SLsachcon - SLsachmuon;
            soSanhNgay();
            if (txtsoluong.Text.Length > 0 && cbmasv.Text.Length > 0 && cbmasach.Text.Length > 0)
            {
                if (SLsachmuon <= SLsachcon)
                {
                    if (kq == 1)
                    {
                        try
                        {
                            ktmuonchua = 0;
                            string sqladd = "Insert into T_Muontra values (N'" + Maphieu + "', N'" + Masv + "',N'" + Masach + "',N'" + Soluong + "',N'" + Ngaymuon + "',N'" + Ngaytra + "' , N'" + Tinhtrang + "',N'" + Tensv + "',N'" + Lopsv + "',N'" + Tensach + "',N'" + Tacgia + "')";
                            SqlCommand cmd2 = new SqlCommand(sqladd, strconn);
                            MessageBox.Show("Cho mượn thành công!", "Thông Báo");
                            cmd2.ExecuteNonQuery();
                            string strluuSLSauChoMuon = luuSLSauChoMuon.ToString();
                            string strCapNhatSLCon = "update T_Sach set Soluong='" + strluuSLSauChoMuon + " ' where MaSach='" + cbmasach.Text + "'";
                            SqlCommand cmd3 = new SqlCommand(strCapNhatSLCon, strconn);
                            cmd3.ExecuteNonQuery();
                            strconn.Close();
                            MessageBox.Show("Đã cập nhật SL Sách vào trong kho.", "Thông Báo");
                            strconn.Close();
                            DGV_HienThi();
                            DGV_HienThi1();
                            ktmuonchua = 0;
                            setControlsMuon(false);
                            btnluu.Text = "";
                            btnluu.Enabled = false;
                            btnhuy.Enabled = false;
                            dgvmt.Enabled = true;

                            dgvmt.Enabled = true;
                            btmuon.Enabled = true;
                            btrs.Enabled = true;
                            btgiahan.Enabled = true;
                            btinphieu.Enabled = true;
                            btnhuy.Text = "";
                        }
                        catch (Exception)
                        {
                            //ktmuonchua = 1;
                        }

                        if (ktmuonchua == 0)
                        {
                            try
                            {
                                string strluuSLSauChoMuon = luuSLSauChoMuon.ToString();
                                string strCapNhatSLCon = "update T_Sach set Soluong='" + strluuSLSauChoMuon + " ' where MaSach='" + cbmasach.Text + "'";
                                SqlCommand cmd2 = new SqlCommand(strCapNhatSLCon, strconn);
                                cmd2.ExecuteNonQuery();
                                strconn.Close();
                                MessageBox.Show("Đã cập nhật SL Sách vào trong kho.", "Thông Báo");
                                btnluu.Enabled = false;
                                setControlsMuon(false);



                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                            MessageBox.Show("Mượn thất bại.", "Thông Báo");
                    }
                    else
                        MessageBox.Show("Vui lòng chọn ngày trả lớn hơn ngày mươn.", "Thông Báo");
                }
                else
                {
                    MessageBox.Show("Số lượng sách < Số lượn sách còn !", "Thông báo");
                    txtsoluong.Clear();
                }





            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin ! ", "Thông báo");
            }

            strconn.Close();


            //Truy vấn đến hàm SQL để kiểm tra tồn tại
            string Sql = "Select Maphieumuon from T_Muontra where Maphieumuon ='" + Maphieu + "'";
        }
        private void setControlsMuon(bool edit)
        {
            cbmasv.Enabled = edit;
            cbmasach.Enabled = edit;
            txtsoluong.Enabled = edit;
            //dtmNgayMuon0.Enabled = edit;
            //dtmNgayTra0.Enabled = edit;
            cbtinhtrang.Enabled = edit;
            datengaymuon.Enabled = edit;
            datengaytra.Enabled = edit;
        }

        public string strluuSLCon;
        public int SLsachcon, SLsachmuon;
        public int luuSLSauChoMuon;
        public int ktmuonchua;
        private void btmuon_Click(object sender, EventArgs e)
        {
            btnhuy.Text = "Hủy";

            btnluu.Text = "Cho Mượn";
            setControlsMuon(true);
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
            dgvmt.Enabled = false;
            btmuon.Enabled = false;
            btrs.Enabled = false;
            btgiahan.Enabled = false;
            btinphieu.Enabled = false;
            txtmaphieu.Text = "";
            cbmasv.Text = "";
            cbmasach.Text = "";
            txtsoluong.Text = "";
            datengaymuon.Enabled = false;
            datengaymuon.Text = Convert.ToString(today); ;
            datengaytra.Text = Convert.ToString(newday);
            //dtmNgayTra0.Text = "";
            cbtinhtrang.Text = "";

            txtsl.Text = "";
            xuly = 0;
        }
        private void giaHanSach()
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            soSanhNgay();
            if (kq == 1)
            {
                string strCapNhatSLCon = "update T_Muontra set Ngaymuon='" + datengaymuon.Text + " ', Ngaytra='" + datengaytra.Text + "' where Maphieumuon='" + txtmaphieu.Text + "'";
                SqlCommand cmd2 = new SqlCommand(strCapNhatSLCon, strconn);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Gia hạn thành công.", "Thông Báo");

                DGV_HienThi();
                DGV_HienThi1();
                strconn.Close();

                setControlsMuon(false);
                
                btnluu.Text = "";
                btnhuy.Text = "";
                btnluu.Enabled = false;
                btmuon.Enabled = true;
                btgiahan.Enabled = true;
                btnhuy.Enabled = false;

                dgvmt.Enabled = true;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ngày trả lớn hơn ngày mượn.", "Thông Báo");
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaphieu2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtmasv2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtmasach2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txtslmuon2.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            datengaymuon2.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            datengaytra2.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            txttinhtrang2.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
        }

        private void tabtrasach_Click(object sender, EventArgs e)
        {
            DGV_HienThi1();
            DGV_HienThi();
            Doc_masv();
            Doc_masach();
        }
        public int luuSLSauTra;
        public string luuSLConTabMuon;
        private void bt_trasach_Click(object sender, EventArgs e)
        {
            
            
            string sqltrasach = "select * from T_Sach where Masach='" + txtmasach2.Text + "'";
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            SqlCommand cmd = new SqlCommand(sqltrasach, strconn);

            SqlDataReader Dr = cmd.ExecuteReader();
            while (Dr.Read())
            {
                luuSLConTabMuon = Dr.GetInt32(5).ToString();
            }

            luuSLSauTra = Convert.ToInt32(txtslmuon2.Text) + Convert.ToInt32(luuSLConTabMuon);
 
            //MessageBox.Show("SL Còn: " + luuSLConTabMuon);
            //MessageBox.Show("SL sau trả: " + luuSLSauTra);
            //MessageBox.Show("SL trả: " + luuSLTra1);
            //kết nối
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sql_xoa = "Delete from T_Muontra where Maphieumuon = N'" + txtmaphieu2.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sql_xoa, strconn);
            if (txtmaphieu2.Text == "")
            {
                MessageBox.Show("Chưa nhập phiếu cần trả?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaphieu2.Focus();
            }
            else
            {
                DialogResult Rsult = MessageBox.Show("Có chắc chắn trả sách không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Rsult == DialogResult.Yes)
                {
                    cmd1.ExecuteNonQuery();
                    string strluuSLSauTra = luuSLSauTra.ToString();
                    string strCapNhatSLCon = "update T_Sach set Soluong='" + strluuSLSauTra + " ' where Masach='" + txtmasach2.Text + "'";
                    SqlCommand cmd2 = new SqlCommand(strCapNhatSLCon, strconn);
                    cmd2.ExecuteNonQuery();
                    strconn.Close();
                    MessageBox.Show("Đã cập nhật SL Sách vào kho.", "Thông Báo");
                    strconn.Close();
                    DGV_HienThi();
                    DGV_HienThi1();
                }
            }
            strconn.Close();
        }

        private void txtmaphieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmasach_TextChanged(object sender, EventArgs e)
        {

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
                string sql_mt = "Select * from T_Muontra where Maphieumuon like N'%" + txttimkiem.Text + "%' or Masach like N'%" + txttimkiem.Text + "%' or Masv like N'%" + txttimkiem.Text + "%' or Tinhtrang like N'%" + txttimkiem.Text + "%' or Ngaymuon like N'%" + txttimkiem.Text + "%' or Tensv like N'%" + txttimkiem.Text + "%' or Lopsv like N'%" + txttimkiem.Text + "%' or Tensach like N'%" + txttimkiem.Text + "%'";
                SqlDataAdapter Mydata = new SqlDataAdapter(sql_mt, strconn);
                Mydata.Fill(Dt);//Đổ dữ liệu vào Dt
                dgvmt.DataSource = Dt;// Hiển thị dữ liệu lền DGView
                txttimkiem.Clear();
            }

            strconn.Close();
        }

        private void btrs_Click(object sender, EventArgs e)
        {
            txtmaphieu.Clear();
            txtsoluong.Clear();
        }

        

    }
    }

