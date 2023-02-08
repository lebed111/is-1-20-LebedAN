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
        Queue<int> id_cl = new Queue<int>();
        Queue<int> id_ta = new Queue<int>();


        private void orders_Load(object sender, EventArgs e)
        {
            f2.con();
            f2.fid_ta();
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
            string or = $"SELECT id_or,date FROM Orders WHERE DATE BETWEEN \'{str}\' AND \'{str1}\'";
            MyDA.SelectCommand = new MySqlCommand(or, f2.conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);
            int s = dataGridView1.Rows.Count;
            f2.conn.Close();
            f2.conn.Open();
            string cl = $"SELECT id_cl,date FROM Orders WHERE DATE BETWEEN \'{str}\' AND \'{str1}\'";
            MySqlCommand command2 = new MySqlCommand(cl, f2.conn);
            MySqlDataReader reader2 = command2.ExecuteReader();
            while(reader2.Read())
            {
                id_cl.Enqueue(Convert.ToInt32(reader2[0]));
            }
            f2.conn.Close();
            table.Columns.Add("ФИО клиента");
            int f = id_cl.Count();
            for (int i = 0; i < f; i++)
            {
                int q = id_cl.Dequeue();
                string w = "";
                clint.TryGetValue(q, out w);
                this.dataGridView1[2, i].Value = Convert.ToString(w);
            }
            f2.conn.Open();
            string ol = $"SELECT id_ta,date FROM Orders WHERE DATE BETWEEN \'{str}\' AND \'{str1}\'";
            MySqlCommand command3 = new MySqlCommand(ol, f2.conn);
            MySqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                id_ta.Enqueue(Convert.ToInt32(reader3[0]));
            }
            f2.conn.Close();
            table.Columns.Add("Цена заказа");
            int r = id_ta.Count();
            for (int i = 0; i < r; i++)
            {
                int q = id_ta.Dequeue();
                int w = 0;
                storage.TryGetValue(q, out w);
                this.dataGridView1[3, i].Value = Convert.ToInt32(w);
            }
            f2.conn.Open();
            string ol1 = $"SELECT id_ta,date FROM Orders WHERE DATE BETWEEN \'{str}\' AND \'{str1}\'";
            MySqlCommand command4 = new MySqlCommand(ol1, f2.conn);
            MySqlDataReader reader4 = command4.ExecuteReader();
            while (reader4.Read())
            {
                id_ta.Enqueue(Convert.ToInt32(reader4[0]));
            }
            f2.conn.Close();
            table.Columns.Add("Название заказа");
            for (int i = 0; i < r; i++)
            {
                string q = Convert.ToString(id_ta.Dequeue());
                string w = "";
                f2.id_ta.TryGetValue(q, out w);
                this.dataGridView1[4, i].Value = Convert.ToString(w);
            }
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
