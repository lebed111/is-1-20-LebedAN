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
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
        }//колонки
        public void Clint()
        {
            f2.Client();
            dataGridView1.Columns.Clear();
            table.Columns.Clear();
            table.Rows.Clear();
            table.Columns.Add("ID");
            table.Columns.Add("ФИО");
            table.Columns.Add("Телефон");
            for (int i = 0; i < f2.st1.Count; i++)
            {
                table.Rows.Add(f2.st1[i], f2.st2[i], f2.st3[i]);
            }
            coluumn();
        }
        public void emploee()
        {
            f2.employee();
            dataGridView1.Columns.Clear();
            table.Columns.Clear();
            table.Rows.Clear();
            table.Columns.Add("ID");
            table.Columns.Add("ФИО");
            table.Columns.Add("Телефон");
            table.Columns.Add("Должность");
            table.Columns.Add("уровень доступа");
            table.Columns.Add("Логин");
            table.Columns.Add("Пароль");
            for (int i = 0; i < f2.st1.Count; i++)
            {
                table.Rows.Add(f2.st1[i], f2.st2[i], f2.st3[i],f2.st4[i],f2.st5[i],f2.st6[i],f2.st7[i]);
            }
            coluumn();
        }
        public void expenses()
        {
            f2.expenses();
            dataGridView1.Columns.Clear();
            table.Columns.Clear();
            table.Rows.Clear();
            table.Columns.Add("ID");
            table.Columns.Add("Краткое описание");
            table.Columns.Add("Цена");
            table.Columns.Add("Дата оплаты");
            table.Columns.Add("Ответственный");
            table.Columns.Add("Поставщик");
            for (int i = 0; i < f2.st1.Count; i++)
            {
                table.Rows.Add(f2.st1[i], f2.st2[i], f2.st3[i], f2.st4[i], f2.st5[i], f2.st6[i]);
            }
            coluumn();
        }
        public void orders()
        {
            f2.orders();
            dataGridView1.Columns.Clear();
            table.Columns.Clear();
            table.Rows.Clear();
            table.Columns.Add("ID");
            table.Columns.Add("Клиент");
            table.Columns.Add("Цена");
            table.Columns.Add("Дата оплаты");
            table.Columns.Add("Время действия");
            for (int i = 0; i < f2.st1.Count; i++)
            {
                table.Rows.Add(f2.st1[i], f2.st2[i], f2.st3[i], f2.st4[i], f2.st5[i]);
            }
            coluumn();
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
            Clint();
        }
        // сотрудники(2)
        public void emploe(object sender, EventArgs e)
        {
            emploee();
        }
        // расходы(3)
        public void expens(object sender, EventArgs e)
        {
            expenses();
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
            orders();
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

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Название";
            dataGridView1.Columns[2].HeaderText = "Уровень доступа";
            dataGridView1.Columns[3].HeaderText = "Описание";

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

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Телефон";
            dataGridView1.Columns[2].HeaderText = "Компания";
            dataGridView1.Columns[3].HeaderText = "Адресс";

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

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Цена";
            dataGridView1.Columns[3].HeaderText = "Поставщик";

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
