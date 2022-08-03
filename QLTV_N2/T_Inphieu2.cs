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
using Microsoft.Reporting.WinForms;

namespace QLTV_N2
{
    public partial class T_Inphieu2 : Form
    {
        //Tạo chuỗi kết nối
        String chuoi = @"Data Source=DESKTOP-9FMR7OR\HUUDAT;Initial Catalog=QLTV_N2;Integrated Security=True";
        //Khởi tạo đối tượng Connection
        SqlConnection strconn = null;
        public T_Inphieu2()
        {
            InitializeComponent();
        }


        private void T_Inphieu2_Load(object sender, EventArgs e)
        {
            if (strconn == null)
            {
                strconn = new SqlConnection(chuoi);
            }
            string sql = "select * from T_Muontra";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, strconn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "T_Muontra");
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLTV_N2.Inphieu.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "Inphieumuon";
            rds.Value = ds.Tables["T_Muontra"];
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
