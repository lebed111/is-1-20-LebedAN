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
    public partial class expens : MetroFramework.Forms.MetroForm
    {
        public expens()
        {
            InitializeComponent();
        }
        Requests.Requests f2 = new Requests.Requests();
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        public Dictionary<string, string> tupe_price = new Dictionary<string, string>();
        Queue<int> tepy_ex = new Queue<int>();
        Queue<int> respos = new Queue<int>();
        private void expens_Load(object sender, EventArgs e)
        {
            f2.con();
            f2.expens();
            f2.reespoc();
            f2.conn.Open();
            var dt = Convert.ToDateTime(f2.date1);
            var str = string.Format("{0}-{1}-{2} {3}:{4}:{5}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            var dt1 = Convert.ToDateTime(f2.date2);
            var str1 = string.Format("{0}-{1}-{2} {3}:{4}:{5}", dt1.Year, dt1.Month, dt1.Day, dt1.Hour, dt1.Minute, dt1.Second);
            string or = $"SELECT id_ex,date_ex FROM expenses WHERE date_ex BETWEEN \'{str}\' AND \'{str1}\'";
            MyDA.SelectCommand = new MySqlCommand(or, f2.conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);
            f2.conn.Close();
            f2.conn.Open();
            string cl = $"SELECT tepy_ex,date_ex FROM expenses WHERE date_ex BETWEEN \'{str}\' AND \'{str1}\'";
            MySqlCommand command = new MySqlCommand(cl, f2.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tepy_ex.Enqueue(Convert.ToInt32(reader[0]));
            }
            f2.conn.Close();
            table.Columns.Add("Тип расхода");
            int f = tepy_ex.Count();
            for (int i = 0; i < f; i++)
            {
                string q = Convert.ToString(tepy_ex.Dequeue());
                string w = "";
                f2.tupe_ex.TryGetValue(q, out w);
                this.dataGridView1[2, i].Value = Convert.ToString(w);
            }
            //
            f2.conn.Open();
            string ct = $"SELECT tepy_ex,date_ex FROM expenses WHERE date_ex BETWEEN \'{str}\' AND \'{str1}\'";
            MySqlCommand command2 = new MySqlCommand(ct, f2.conn);
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                respos.Enqueue(Convert.ToInt32(reader2[0]));
            }
            f2.conn.Close();
            f2.conn.Open();
            string rt = $"SELECT id_ty,price_ty FROM types_expenses";
            MySqlCommand command3 = new MySqlCommand(rt, f2.conn);
            MySqlDataReader reader3 = command3.ExecuteReader();
            while(reader3.Read())
            {
                tupe_price.Add(Convert.ToString(reader3[0]), Convert.ToString(reader3[1]));
            }
            f2.conn.Close();
            table.Columns.Add("Цена");
            f = respos.Count();
            for (int i = 0; i < f; i++)
            {
                string q = Convert.ToString(respos.Dequeue());
                string w = "";
                tupe_price.TryGetValue(q, out w);
                this.dataGridView1[3, i].Value = Convert.ToString(w);
            }
            //
            f2.conn.Open();
            string c = $"SELECT responsible_ex,date_ex FROM expenses WHERE date_ex BETWEEN \'{str}\' AND \'{str1}\'";
            MySqlCommand command1 = new MySqlCommand(c, f2.conn);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                respos.Enqueue(Convert.ToInt32(reader1[0]));
            }
            f2.conn.Close();
            table.Columns.Add("Ответственный");
            f = respos.Count();
            for (int i = 0; i < f; i++)
            {
                string q = Convert.ToString(respos.Dequeue());
                string w = "";
                f2.respo.TryGetValue(q, out w);
                this.dataGridView1[4, i].Value = Convert.ToString(w);
            }
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
    }
}
