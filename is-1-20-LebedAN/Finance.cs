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
    public partial class Finance : MetroFramework.Forms.MetroForm
    {
        public Finance()
        {
            InitializeComponent();
        }
        Requests.Requests f2 = new Requests.Requests();
        Numbers q2 = new Numbers();
        Mainform s2 = new Mainform();
        Dictionary <int, int> storage = new Dictionary<int, int>();
        class Numbers
        {
            public int clintt;
            public int orders;
            public int sum;
            public int expenss;
            public int sumex;
        }

        private void Finance_Load(object sender, EventArgs e)
        {
            f2.con();
            calculations();
            dataGridView1.Visible = false;
        }
        public void calculations()
        {
            f2.date(Convert.ToString(dateTimePicker2.Value), Convert.ToString(dateTimePicker1.Value));
            var dt = Convert.ToDateTime(f2.date1);
            var str = string.Format("{0}-{1}-{2} {3}:{4}:{5}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            var dt1 = Convert.ToDateTime(f2.date2);
            var str1 = string.Format("{0}-{1}-{2} {3}:{4}:{5}", dt1.Year, dt1.Month, dt1.Day, dt1.Hour, dt1.Minute, dt1.Second);
            // подсчет клиентов
            f2.conn.Open();
            string clint = $"SELECT DISTINCT id_cl FROM Orders WHERE date BETWEEN \'{str}\' AND \'{str1}\'";
            MySqlCommand command = new MySqlCommand(clint, f2.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Convert.ToInt32(reader[0]);
                q2.clintt++;
            }
            textBox1.Text = Convert.ToString(q2.clintt);
            f2.conn.Close();
            // подсчет заказов
            f2.conn.Open();
            string orders = $"SELECT DISTINCT id_or FROM Orders WHERE date BETWEEN \'{str}\' AND \'{str1}\'";
            MySqlCommand command1 = new MySqlCommand(orders, f2.conn);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                Convert.ToInt32(reader1[0]);
                q2.orders++;
            }
            textBox2.Text = Convert.ToString(q2.orders);
            f2.conn.Close();
            //Общая сумма заказов
            f2.conn.Open();
            string tarif = $"SELECT id_ta, Price_ta FROM tariff";
            MySqlCommand command6 = new MySqlCommand(tarif, f2.conn);
            MySqlDataReader reader6 = command6.ExecuteReader();
            while(reader6.Read())
            {
                storage[Convert.ToInt32(reader6[0])] = Convert.ToInt32(reader6[1]);
            }
            f2.conn.Close();
            f2.conn.Open();
            string a = $"SELECT id_ta FROM Orders WHERE date BETWEEN \'{str}\' AND \'{str1}\'";
            MySqlCommand command2 = new MySqlCommand(a, f2.conn);          
            MySqlDataReader reader2 = command2.ExecuteReader();
            try
            {
                while (reader2.Read())
                {
                    int c;
                    storage.TryGetValue(Convert.ToInt32(reader2[0]), out c);
                    q2.sum += c;
                }
            }
            catch (Exception ex)
            { MessageBox.Show($"{ex.Message}"); }
            textBox3.Text = Convert.ToString(q2.sum);
            storage.Clear();
            f2.conn.Close();
            //количество расходов
            f2.conn.Open();
            string expens = $"SELECT id_ex FROM expenses WHERE date_ex BETWEEN \'{str}\' AND \'{str1}\'";
            MySqlCommand command3 = new MySqlCommand(expens, f2.conn);
            MySqlDataReader reader3 = command3.ExecuteReader();
            while(reader3.Read())
            {
                Convert.ToInt32(reader3[0]);
                q2.expenss++;
            }
            textBox4.Text = Convert.ToString(q2.expenss);
            f2.conn.Close();
            //сумма расхода 
            f2.conn.Open();
            string q = $"SELECT id_ty, price_ty FROM types_expenses";
            MySqlCommand command4 = new MySqlCommand(q, f2.conn);
            MySqlDataReader reader4 = command4.ExecuteReader();
            while (reader4.Read())
            {
                storage[Convert.ToInt32(reader4[0])] = Convert.ToInt32(reader4[1]);
            }
            f2.conn.Close();
            f2.conn.Open();
            string expens1 = $"SELECT tepy_ex FROM expenses WHERE date_ex BETWEEN \'{str}\' AND \'{str1}\'";
            MySqlCommand command5 = new MySqlCommand(expens1, f2.conn);
            MySqlDataReader reader5 = command5.ExecuteReader();
            while (reader5.Read())
            {
                int c;
                storage.TryGetValue(Convert.ToInt32(reader5[0]),out c);
                q2.sumex += c;
            }
            textBox5.Text = Convert.ToString(q2.sumex);
            f2.conn.Close();
            //Прибыль
            textBox6.Text = Convert.ToString(q2.sum - q2.sumex);
            // обнуление 
            q2.clintt = 0;
            q2.orders = 0;
            q2.sum = 0;
            q2.expenss = 0;
            q2.sumex = 0;
            storage.Clear();
            s2.table.Clear();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            expens f2 = new expens();
            f2.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainform f2 = new Mainform();
            f2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            calculations();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
 
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            orders f2 = new orders();
            f2.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
