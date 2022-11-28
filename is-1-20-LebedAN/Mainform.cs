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
    public partial class Mainform : MetroFramework.Forms.MetroForm
    {
        Requests.Requests f2 = new Requests.Requests();
        private BindingSource bSource = new BindingSource();
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        DataTable table = new DataTable();
        public Mainform()
        {
            InitializeComponent();

            ToolStripMenuItem emploMenuItems = new ToolStripMenuItem("Сотруднки");
            ToolStripMenuItem ClientMenuItems = new ToolStripMenuItem("Клиенты");
            ToolStripMenuItem expensMenuItems = new ToolStripMenuItem("Расходы");
            ToolStripMenuItem incomeMenuItems = new ToolStripMenuItem("Доходы");
            ToolStripMenuItem OrderMenuItems = new ToolStripMenuItem("Заказы");
            ToolStripMenuItem privilagMenuItems = new ToolStripMenuItem("Привилегии");
            ToolStripMenuItem providerMenuItems = new ToolStripMenuItem("Поставщики");
            ToolStripMenuItem tariffMenuItems = new ToolStripMenuItem("Тарифы");
            ToolStripMenuItem tep_expensMenuItems = new ToolStripMenuItem("Типы расходов");


            contextMenuStrip1.Items.AddRange(new[] { emploMenuItems, ClientMenuItems,expensMenuItems,incomeMenuItems,OrderMenuItems,privilagMenuItems,providerMenuItems,tariffMenuItems,tep_expensMenuItems});

            metroButton3.ContextMenuStrip = contextMenuStrip1;

            ClientMenuItems.Click += Client;
            emploMenuItems.Click += emploe;
            
        }


        public void Mainform_Load(object sender, EventArgs e)
        {
            this.Hide();
            if (Auth.auth_role == 0)
            {
                Authorization Author = new Authorization();
                Author.ShowDialog();
            }
            if (Auth.auth)
            {
                this.Show();               
            }
            f2.con();

            label1.Text = $"Сотрудник {Auth.auth_fio} \n уровень доступа {Auth.auth_role}";
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Changes f2 = new Changes();
            f2.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            

        }
         public void formClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        public void Client(object sender, EventArgs e)
        {
            f2.conn.Open();
            table.Clear();
            string cl = "SELECT * FROM Client;";
            MyDA.SelectCommand = new MySqlCommand(cl,f2.conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);
             

            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.ColumnHeadersVisible = true;

            f2.conn.Close();
        }
        public void emploe (object sender, EventArgs e)
        {
            f2.conn.Open();           
            table.Clear();
            string cl = "SELECT * FROM employee;";
            MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
            MyDA.Fill(table);

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[6].Visible = false;

            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.ColumnHeadersVisible = true;

            f2.conn.Close();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Authorization f2 = new Authorization();
            f2.Show();
        }
        
        private void metroButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Finance f2 = new Finance();
            f2.Show();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }

    }
}
