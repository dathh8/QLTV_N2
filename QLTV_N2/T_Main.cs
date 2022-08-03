using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace QLTV_N2
{
    public partial class T_Main : Form
    {
        public T_Main()
        {
            InitializeComponent();
        }
        private void T_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("Bạn chắc chắn muốn thoát.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void T_main_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            T_Nhanvien nhanvien = new T_Nhanvien();
            nhanvien.ShowDialog();
            
        }

        private void T_Main_Load(object sender, EventArgs e)
        {
           
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            T_Sinhvien sinhvien = new T_Sinhvien();
            sinhvien.ShowDialog();
          
        }

        private void khoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            T_Khoa khoa = new T_Khoa();
            khoa.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            T_Sach sach = new T_Sach();
            sach.ShowDialog();
        }

        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            T_Nhaxb nhaxb = new T_Nhaxb();
            nhaxb.ShowDialog();
        }

        private void quảnLýMượnTrảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            T_Muontra muontra = new T_Muontra();
            muontra.ShowDialog();
        }

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            T_Baocao baocao = new T_Baocao();
            baocao.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
