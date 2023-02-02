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
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        Dictionary<int, int> storage = new Dictionary<int, int>();
        Dictionary<int, string> clint = new Dictionary<int, string>();


        private void orders_Load(object sender, EventArgs e)
        {
            f2.con();
            // инфа о сумме заказа
            f2.conn.Open();
            string tarif = $"SELECT id_ta, Price_ta FROM tariff";
            MySqlCommand command = new MySqlCommand(tarif, f2.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                storage[Convert.ToInt32(reader[0])] = Convert.ToInt32(reader[1]);
            }
            f2.conn.Close();
            //инфа о имени клиента
            f2.conn.Open();
            string cliint = $"SELECT id_cl,fio_cl FROM Client";
            MySqlCommand command1 = new MySqlCommand(cliint, f2.conn);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                clint[Convert.ToInt32(reader1[0])] = Convert.ToString(reader1[1]);
            }
            f2.conn.Close();

            f2.conn.Open();
            var dt =  Convert.ToDateTime(f2.date1);
            var str = string.Format("{0}-{1}-{2} {3}:{4}:{5}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            var dt1 =  Convert.ToDateTime(f2.date2);
            var str1 = string.Format("{0}-{1}-{2} {3}:{4}:{5}", dt1.Year, dt1.Month, dt1.Day, dt1.Hour, dt1.Minute, dt1.Second);
            string or = $"SELECT * FROM Orders WHERE DATE BETWEEN \'{str}\' AND \'{str1}\'";
            MyDA.SelectCommand = new MySqlCommand(or, f2.conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);
            int s = dataGridView1.Rows.Count;
            //тариф
            for(int i = 0; i < s; i++)
            {
                int d;
                int rowIndex = i;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                storage.TryGetValue(Convert.ToInt32(row.Cells[2].Value), out d);
                dataGridView1.Rows[i].Cells[2].Value = Convert.ToInt32(d);
            }
            //имя клиента
            for (int i = 0; i < s; i++)
            {
                string d;
                int rowIndex = i;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                clint.TryGetValue(Convert.ToInt32(row.Cells[1].Value), out d);
                dataGridView1.Rows[i].Cells[1].ValueType = typeof(string);
                dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(d);
            }
            f2.conn.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
