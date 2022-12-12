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
using Requests;


namespace is_1_20_LebedAN
{
    public partial class Changes : MetroFramework.Forms.MetroForm
    {
        Mainform s2 = new Mainform();
        popd pop = new popd();
        class popd
        {
           public string max;
            public int maxx;
        }
        public Changes()
        {
            InitializeComponent();
            //contextMenuStrip1
            ToolStripMenuItem emploMenuItems = new ToolStripMenuItem("Сотруднки");
            ToolStripMenuItem ClientMenuItems = new ToolStripMenuItem("Клиенты");
            ToolStripMenuItem expensMenuItems = new ToolStripMenuItem("Расходы");
            ToolStripMenuItem incomeMenuItems = new ToolStripMenuItem("Доходы");
            ToolStripMenuItem OrderMenuItems = new ToolStripMenuItem("Заказы");
            ToolStripMenuItem privilagMenuItems = new ToolStripMenuItem("Привилегии");
            ToolStripMenuItem providerMenuItems = new ToolStripMenuItem("Поставщики");
            ToolStripMenuItem tariffMenuItems = new ToolStripMenuItem("Тарифы");
            ToolStripMenuItem tep_expensMenuItems = new ToolStripMenuItem("Типы расходов");
            //contextMenuStrip2
            ToolStripMenuItem updateMenuItems = new ToolStripMenuItem("Сохранить");
            ToolStripMenuItem deletMenuItems = new ToolStripMenuItem("удалить");

            contextMenuStrip1.Items.AddRange(new[] { emploMenuItems, ClientMenuItems, expensMenuItems, incomeMenuItems, OrderMenuItems, privilagMenuItems, providerMenuItems, tariffMenuItems, tep_expensMenuItems });
            contextMenuStrip2.Items.AddRange(new[] { updateMenuItems, deletMenuItems });

            metroButton4.ContextMenuStrip = contextMenuStrip1;
            dataGridView1.ContextMenuStrip = contextMenuStrip2;
            //contextMenuStrip1
            ClientMenuItems.Click += Client;
            emploMenuItems.Click += emploe;
            expensMenuItems.Click += expens;
            incomeMenuItems.Click += income;
            OrderMenuItems.Click += Order;
            privilagMenuItems.Click += privilag;
            providerMenuItems.Click += provider;
            tariffMenuItems.Click += tariff;
            tep_expensMenuItems.Click += tepes_expens;
            //contextMenuStrip2
            updateMenuItems.Click += update;
        }
        Requests.Requests f2 = new Requests.Requests();

        private void Changes_Load(object sender, EventArgs e)
        {
            f2.con();
            f2.conn.Open();
            string cl;
            switch (f2.number)
            {
                case 1:
                    cl = "SELECT * FROM Client;";
                    s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                    dataGridView1.DataSource = s2.bSource;
                    s2.bSource.DataSource = s2.table;
                    s2.MyDA.Fill(s2.table);
                    break;
                case 2:
                    cl = "SELECT * FROM employee;";
                    s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                    dataGridView1.DataSource = s2.bSource;
                    s2.bSource.DataSource = s2.table;
                    s2.MyDA.Fill(s2.table);
                    break;
                case 3:
                    cl = "SELECT * FROM expenses;";
                    s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                    dataGridView1.DataSource = s2.bSource;
                    s2.bSource.DataSource = s2.table;
                    s2.MyDA.Fill(s2.table);
                    break;
                case 4:
                    cl = "SELECT * FROM income;";
                    s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                    dataGridView1.DataSource = s2.bSource;
                    s2.bSource.DataSource = s2.table;
                    s2.MyDA.Fill(s2.table);
                    break;
                case 5:
                    cl = "SELECT * FROM Order;";
                    s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                    dataGridView1.DataSource = s2.bSource;
                    s2.bSource.DataSource = s2.table;
                    s2.MyDA.Fill(s2.table);
                    break;
                case 6:
                   cl = "SELECT * FROM privilege;";
                    s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                    dataGridView1.DataSource = s2.bSource;
                    s2.bSource.DataSource = s2.table;
                    s2.MyDA.Fill(s2.table);
                    break;
                case 7:
                    cl = "SELECT * FROM provider;";
                    s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                    dataGridView1.DataSource = s2.bSource;
                    s2.bSource.DataSource = s2.table;
                    s2.MyDA.Fill(s2.table);
                    break;
                case 8:
                    cl = "SELECT * FROM tariff;";
                    s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                    dataGridView1.DataSource = s2.bSource;
                    s2.bSource.DataSource = s2.table;
                    s2.MyDA.Fill(s2.table);
                    break;
                case 9:
                    cl = "SELECT * FROM tepes_exenses;";
                    s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                    dataGridView1.DataSource = s2.bSource;
                    s2.bSource.DataSource = s2.table;
                    s2.MyDA.Fill(s2.table);
                    break;
            }
            coluumn();
            f2.conn.Close();
        }
        public void update(object sender, EventArgs e)
        {
            switch (f2.number)
            {
                case 5:
                    f2.conn.Open();
                    pop.max = "SELECT MAX(id_or) FROM Orders;";
                    MySqlCommand command = new MySqlCommand(pop.max,f2.conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        pop.maxx = Convert.ToInt32(reader[0]);
                    }
                    f2.conn.Close();
                    f2.conn.Open();              
                    for (int i = 1; i <= pop.maxx; i++)
                    {
                        int rowIndex = i;
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];
                        string cl = $"UPDATE Orders SET id_cl = {row.Cells[1].Value}, id_ta = {row.Cells[2].Value}, date_or = \"{row.Cells[3].Value}\"  WHERE id_or ={i};";
                        //command.Parameters.Add("@un", MySqlDbType.Int32);
                        //command.Parameters.Add("@uw", MySqlDbType.Int32);
                        //command.Parameters.Add("@ue", MySqlDbType.Date);
                        //command.Parameters.Add("@uq", MySqlDbType.Int32);
                        //command.Parameters["@un"].Value = row.Cells[1].Value;
                        //command.Parameters["@uw"].Value = row.Cells[2].Value;
                        //command.Parameters["@ue"].Value = row.Cells[3].Value;
                        //command.Parameters["@uq"].Value = i;
                        MySqlCommand command1 = new MySqlCommand(cl, f2.conn);
                        command1.ExecuteNonQuery();
                    }
                    f2.conn.Close();
                    break;
            }

        }
        public void coluumn()
        {
            int colum = dataGridView1.Columns.Count;
            if (colum == 1)
            {
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (colum == 2)
            {
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (colum == 3)
            {
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (colum == 4)
            {
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (colum == 5)
            {
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (colum == 6)
            {
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (colum == 7)
            {
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        // клиенты(1)
        public void Client(object sender, EventArgs e)
        {
            f2.conn.Open();
            s2.table.Clear();
            s2.table.Columns.Clear();
            string cl = "SELECT * FROM Client;";
            s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = s2.bSource;
            s2.bSource.DataSource = s2.table;
            s2.MyDA.Fill(s2.table);
            dataGridView1.ColumnHeadersVisible = true;
            f2.num(1);
            f2.conn.Close();
        }
        // сотрудники(2)
        public void emploe(object sender, EventArgs e)
        {
            f2.conn.Open();
            s2.table.Clear();
            s2.table.Columns.Clear();
            string cl = "SELECT * FROM employee;";
            s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            s2.bSource.DataSource = s2.table;
            dataGridView1.DataSource = s2.bSource;
            s2.MyDA.Fill(s2.table);
            coluumn();
            dataGridView1.ColumnHeadersVisible = true;
            f2.num(2);
            f2.conn.Close();
        }
        // расходы(3)
        public void expens(object sender, EventArgs e)
        {
            f2.conn.Open();
            s2.table.Clear();
            s2.table.Columns.Clear();
            string cl = "SELECT * FROM expenses;";
            s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = s2.bSource;
            s2.bSource.DataSource = s2.table;
            s2.MyDA.Fill(s2.table);
            coluumn();
            dataGridView1.ColumnHeadersVisible = true;
            f2.num(3);
            f2.conn.Close();
        }
        // доходы(4)
        public void income(object sender, EventArgs e)
        {
            f2.conn.Open();
            s2.table.Clear();
            s2.table.Columns.Clear();
            string cl = "SELECT * FROM income;";
            s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = s2.bSource;
            s2.bSource.DataSource = s2.table;
            s2.MyDA.Fill(s2.table);
            coluumn();
            dataGridView1.ColumnHeadersVisible = true;
            f2.num(4);
            f2.conn.Close();
        }
        // заказы : клинты и время(5) 
        public void Order(object sender, EventArgs e)
        {
            f2.conn.Open();
            s2.table.Clear();
            s2.table.Columns.Clear();
            string cl = "SELECT * FROM Orders;";
            s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = s2.bSource;
            s2.bSource.DataSource = s2.table;
            s2.MyDA.Fill(s2.table);
            coluumn();
            dataGridView1.ColumnHeadersVisible = true;
            f2.num(5);
            f2.conn.Close();
        }
        // привилегии и их описание(6)
        public void privilag(object sender, EventArgs e)
        {
            f2.conn.Open();
            s2.table.Clear();
            s2.table.Columns.Clear();
            string cl = "SELECT * FROM privilege;";
            s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = s2.bSource;
            s2.bSource.DataSource = s2.table;
            s2.MyDA.Fill(s2.table);
            coluumn();
            dataGridView1.ColumnHeadersVisible = true;
            f2.num(6);
            f2.conn.Close();
        }
        // поставщик (7)
        public void provider(object sender, EventArgs e)
        {
            f2.conn.Open();
            s2.table.Clear();
            s2.table.Columns.Clear();
            string cl = "SELECT * FROM provider;";
            s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = s2.bSource;
            s2.bSource.DataSource = s2.table;
            s2.MyDA.Fill(s2.table);
            coluumn();
            dataGridView1.ColumnHeadersVisible = true;
            f2.num(7);
            f2.conn.Close();
        }
        // расценка всех покупок(8)
        public void tariff(object sender, EventArgs e)
        {
            f2.conn.Open();
            s2.table.Clear();
            s2.table.Columns.Clear();
            string cl = "SELECT * FROM tariff;";
            s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = s2.bSource;
            s2.bSource.DataSource = s2.table;
            s2.MyDA.Fill(s2.table);
            coluumn();
            dataGridView1.ColumnHeadersVisible = true;
            f2.num(8);
            f2.conn.Close();
        }
        // типы расходов(9)
        public void tepes_expens(object sender, EventArgs e)
        {
            f2.conn.Open();
            s2.table.Clear();
            s2.table.Columns.Clear();
            string cl = "SELECT * FROM tepes_exenses;";
            s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = s2.bSource;
            s2.bSource.DataSource = s2.table;
            s2.MyDA.Fill(s2.table);
            coluumn();
            dataGridView1.ColumnHeadersVisible = true;
            f2.num(9);
            f2.conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainform f2 = new Mainform();
            f2.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }
    }
}
