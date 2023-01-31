using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace is_1_20_LebedAN
{
    public partial class orders : MetroFramework.Forms.MetroForm
    {
        public orders()
        {
            InitializeComponent();
        }
        Requests.Requests f2 = new Requests.Requests();
        Mainform s2 = new Mainform();

        private void orders_Load(object sender, EventArgs e)
        {
            f2.con();
            f2.conn.Open();
            var dt =  Convert.ToDateTime(f2.date1);
            var str = string.Format("{0}-{1}-{2} {3}:{4}:{5}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            var dt1 =  Convert.ToDateTime(f2.date2);
            var str1 = string.Format("{0}-{1}-{2} {3}:{4}:{5}", dt1.Year, dt1.Month, dt1.Day, dt1.Hour, dt1.Minute, dt1.Second);
            string or = $"SELECT * FROM Orders WHERE DATE BETWEEN \'{str}\' AND \'{str1}\'";
            s2.MyDA.SelectCommand = new MySqlCommand(or, f2.conn);
            dataGridView1.DataSource = s2.bSource;
            s2.bSource.DataSource = s2.table;
            s2.MyDA.Fill(s2.table);
            f2.conn.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
