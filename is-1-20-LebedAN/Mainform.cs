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
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        
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

            //metroButton3.ContextMenuStrip = contextMenuStrip1;

            ClientMenuItems.Click += Client;
            emploMenuItems.Click += emploe;
            expensMenuItems.Click += expens;
            incomeMenuItems.Click += income;
            OrderMenuItems.Click += Order;
            privilagMenuItems.Click += privilag;
            providerMenuItems.Click += provider;
            tariffMenuItems.Click += tariff;
            tep_expensMenuItems.Click += tepes_expens;

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

            f2.conn.Open();
            table.Clear();
            table.Columns.Clear();
            string cl = "SELECT * FROM tariff;";
            MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Наименование товара";
            dataGridView1.Columns[2].HeaderText = "Цена";
            dataGridView1.Columns[3].HeaderText = "Краткое описание";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = true;
            f2.num(8);
            f2.conn.Close();
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
        // клиенты(1)
        public void Client(object sender, EventArgs e)
        {
            f2.conn.Open();
            table.Clear();
            table.Columns.Clear();
            string cl = "SELECT * FROM Client;";
            MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[2].HeaderText = "Телефон";

            dataGridView1.ColumnHeadersVisible = true;
            f2.num(1);
            f2.conn.Close();
        }
        // сотрудники(2)
        public void emploe(object sender, EventArgs e)
        {
            f2.conn.Open();
            table.Clear();
            table.Columns.Clear();

            string cl = "SELECT * FROM employee;";
            MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
            MyDA.Fill(table);

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

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[2].HeaderText = "Телефон";
            dataGridView1.Columns[3].HeaderText = "Должность";
            dataGridView1.Columns[4].HeaderText = "Роль в программе";
            dataGridView1.Columns[5].HeaderText = "Логин";
            dataGridView1.ColumnHeadersVisible = true;
            f2.num(2);
            f2.conn.Close();
        }
        // расходы(3)
        public void expens(object sender, EventArgs e)
        {
            f2.ressposmax();
            f2.reespoc();
            f2.expens();
            f2.epensmax();
            f2.conn.Open();
            table.Clear();
            table.Columns.Clear();
            string cl = "SELECT id_ex,date_ex FROM expenses;";
            MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);
            table.Columns.Add("Column1");
            int f = f2.expen.Count();
            for (int i = 0; i < f;i++)
            {
                string q = f2.expen.Dequeue();              
                string w = "";
                f2.tupe_ex.TryGetValue(q,out w);
                this.dataGridView1[2, i].Value = Convert.ToString(w);
            }
            table.Columns.Add("");
            int r = f2.respomax.Count();
            for(int i = 0; i<r;i++)
            {
                string q = f2.respomax.Dequeue();
                string w = "";
                f2.respo.TryGetValue(q, out w);
                this.dataGridView1[3, i].Value = Convert.ToString(w);
            }
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;


            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Дата";
            dataGridView1.Columns[2].HeaderText = "Тип расхода";
            dataGridView1.Columns[3].HeaderText = "Ответственный";


            dataGridView1.ColumnHeadersVisible = true;
            f2.num(3);
            f2.conn.Close();
        }
        // доходы(4)
        public void income(object sender, EventArgs e)
        {
            f2.conn.Open();
            table.Clear();
            table.Columns.Clear();
            string cl = "SELECT * FROM income;";
            MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dataGridView1.ColumnHeadersVisible = true;
            f2.num(4);
            f2.conn.Close();
        }
        // заказы : клинты и время(5) 
        public void Order(object sender, EventArgs e)
        {
            try
            {
                f2.fid_cl();
                f2.fid_clmax();
                f2.conn.Open();
                table.Clear();
                table.Columns.Clear();
                string cl = "SELECT id_or,date FROM Orders;";
                MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                dataGridView1.DataSource = bSource;
                bSource.DataSource = table;
                MyDA.Fill(table);
                table.Columns.Add("Column1");
                int f = f2.id_clmax.Count();
                for (int i = 0; i < f; i++)
                {
                    string q = f2.id_clmax.Dequeue();
                    string w = "";
                    f2.id_cl.TryGetValue(q, out w);
                    this.dataGridView1[2, i].Value = Convert.ToString(w);
                }
                table.Columns.Add("");
                int r = f2.id_tamax.Count();
                for (int i = 0; i < r; i++)
                {
                    string q = f2.id_tamax.Dequeue();
                    string w = "";
                    f2.id_ta.TryGetValue(q, out w);
                    this.dataGridView1[3, i].Value = Convert.ToString(w);
                }

                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;


                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                dataGridView1.ColumnHeadersVisible = true;
                f2.num(5);
                f2.conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        // привилегии и их описание(6)
        public void privilag(object sender, EventArgs e)
        {
            f2.conn.Open();
            table.Clear();
            table.Columns.Clear();
            string cl = "SELECT * FROM privilege;";
            MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.ColumnHeadersVisible = true;
            f2.num(6);
            f2.conn.Close();
        }
        // поставщик (7)
        public void provider(object sender, EventArgs e)
        {
            f2.conn.Open();
            table.Clear();
            table.Columns.Clear();
            string cl = "SELECT * FROM provider;";
            MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.ColumnHeadersVisible = true;
            f2.num(7);
            f2.conn.Close();
        }
        // расценка всех покупок(8)
        public void tariff(object sender, EventArgs e)
        {
            f2.conn.Open();
            table.Clear();
            table.Columns.Clear();
            string cl = "SELECT * FROM tariff;";
            MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Наименование товара";
            dataGridView1.Columns[2].HeaderText = "Цена";
            dataGridView1.Columns[3].HeaderText = "Краткое описание";

            dataGridView1.ColumnHeadersVisible = true;
            f2.num(8);
            f2.conn.Close();
        }
        // типы расходов(9)
        public void tepes_expens(object sender, EventArgs e)
        {
            f2.conn.Open();
            table.Clear();
            table.Columns.Clear();
            string cl = "SELECT * FROM types_expenses;";
            MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.ColumnHeadersVisible = true;
            f2.num(9);
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

        private void краткийПодсчетПрибылиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Finance f2 = new Finance();
            f2.Show();
        }

        private void выбратьБдToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }

        private void внестиИзмененияВТаблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Changes f2 = new Changes();
            f2.Show();
        }
    }
}
