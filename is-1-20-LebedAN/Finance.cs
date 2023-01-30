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
        class Numbers
        {
            public int clintt;
            public int orders;
            public int sum;
        }

        private void Finance_Load(object sender, EventArgs e)
        {
            f2.con();
            calculations();
            dataGridView1.Visible = false;
        }
        public void calculations()
        {
            var dt = Convert.ToDateTime(dateTimePicker2.Value);
            var str = string.Format("{0}-{1}-{2} {3}:{4}:{5}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            var dt1 = Convert.ToDateTime(dateTimePicker1.Value);
            var str1 = string.Format("{0}-{1}-{2} {3}:{4}:{5}", dt1.Year, dt1.Month, dt1.Day, dt1.Hour, dt1.Minute, dt1.Second);
            // подсчет клиентов
            f2.conn.Open();
            string clint = $"SELECT DISTINCT id_cl FROM Orders WHERE DATE BETWEEN \'{str}\' AND \'{str1}\'";
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
            string orders = $"SELECT id_or FROM Orders WHERE DATE BETWEEN \'{str}\' AND \'{str1}\'";
            MySqlCommand command1 = new MySqlCommand(orders, f2.conn);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                Convert.ToInt32(reader1[0]);
                q2.orders++;
            }
            textBox2.Text = Convert.ToString(q2.clintt);
            f2.conn.Close();
            //Общая сумма заказов
            f2.conn.Open();
            string tarif = $"SELECT id_ta, Price_ta FROM tariff";
            s2.MyDA.SelectCommand = new MySqlCommand(tarif, f2.conn);
            dataGridView1.DataSource = s2.bSource;
            s2.bSource.DataSource = s2.table;
            s2.MyDA.Fill(s2.table);
            f2.conn.Close();
            f2.conn.Open();
            string a = $"SELECT id_ta FROM Orders WHERE DATE BETWEEN \'{str}\' AND \'{str1}\'";
            MySqlCommand command2 = new MySqlCommand(a, f2.conn);          
            MySqlDataReader reader2 = command2.ExecuteReader();
            try
            {
                while (reader2.Read())
                {
                    int rowIndex = Convert.ToInt32(reader2[0]);
                    DataGridViewRow w = dataGridView1.Rows[rowIndex]; 
                    q2.sum += Convert.ToInt32(w.Cells[1].Value);
                }
            }
            catch (Exception ex)
            { MessageBox.Show($"{ex.Message}"); }
            textBox3.Text = Convert.ToString(q2.sum);
            f2.conn.Close();
            s2.table.Clear();
            q2.clintt = 0;
            q2.orders = 0;
            q2.sum = 0;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

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
    }
}
