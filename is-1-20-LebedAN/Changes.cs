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
        Authorization a2 = new Authorization();
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
            ToolStripMenuItem updateMenuItems = new ToolStripMenuItem("Обновить");
            ToolStripMenuItem deletMenuItems = new ToolStripMenuItem("удалить");

            contextMenuStrip1.Items.AddRange(new[] { emploMenuItems, ClientMenuItems, expensMenuItems, incomeMenuItems, OrderMenuItems, privilagMenuItems, providerMenuItems, tariffMenuItems, tep_expensMenuItems });
            contextMenuStrip2.Items.AddRange(new[] { updateMenuItems, deletMenuItems });

            //metroButton4.ContextMenuStrip = contextMenuStrip1;
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
            deletMenuItems.Click += delet;
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
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "ФИО";
                    dataGridView1.Columns[2].HeaderText = "Телефон";
                    break;
                case 2:
                    cl = "SELECT * FROM employee;";
                    s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                    dataGridView1.DataSource = s2.bSource;
                    s2.bSource.DataSource = s2.table;
                    s2.MyDA.Fill(s2.table);
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "ФИО";
                    dataGridView1.Columns[2].HeaderText = "Телефон";
                    dataGridView1.Columns[3].HeaderText = "Должность";
                    dataGridView1.Columns[4].HeaderText = "Роль в программе";
                    dataGridView1.Columns[5].HeaderText = "Логин";
                    dataGridView1.Columns[6].HeaderText = "Пароль в sha256";
                    break;
                case 3:
                    cl = "SELECT * FROM expenses;";
                    s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                    dataGridView1.DataSource = s2.bSource;
                    s2.bSource.DataSource = s2.table;
                    dataGridView1.ColumnHeadersVisible = true;
                    dataGridView1.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd";
                    s2.MyDA.Fill(s2.table);
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Тип расхода";
                    dataGridView1.Columns[2].HeaderText = "Дата";
                    dataGridView1.Columns[3].HeaderText = "Ответственный";
                    break;
                case 4:
                    cl = "SELECT * FROM income;";
                    s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                    dataGridView1.DataSource = s2.bSource;
                    s2.bSource.DataSource = s2.table;
                    s2.MyDA.Fill(s2.table);
                    break;
                case 5:
                    cl = "SELECT * FROM Orders;";
                    s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                    dataGridView1.DataSource = s2.bSource;
                    s2.bSource.DataSource = s2.table;
                    dataGridView1.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd";
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
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Наименование товара";
                    dataGridView1.Columns[2].HeaderText = "Цена";
                    dataGridView1.Columns[3].HeaderText = "Краткое описание";
                    break;
                case 9:
                    cl = "SELECT * FROM types_expenses;";
                    s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                    dataGridView1.DataSource = s2.bSource;
                    s2.bSource.DataSource = s2.table;
                    s2.MyDA.Fill(s2.table);
                    break;
            }
            coluumn();
            dataGridView1.Columns[0].ReadOnly = true;
            f2.conn.Close();
        }//загрузка
        public void delet (object sender, EventArgs e)
        {
            DialogResult result = DialogResult.No;
            try
            {
                 result = MessageBox.Show($"Вы точно хотите удалить данную строчку: {dataGridView1.Rows[f2.line].Cells[0].Value}", "", MessageBoxButtons.YesNo);
            }
            catch
            {
                MessageBox.Show("выберите одну строчку");
            }
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (f2.number == 1)
                    {
                        f2.conn.Open();
                        DataGridViewRow row = dataGridView1.Rows[f2.line];
                        string com = $"DELETE FROM Client WHERE id_cl = {row.Cells[0].Value}";
                        MySqlCommand command = new MySqlCommand(com, f2.conn);
                        command.ExecuteNonQuery();
                        f2.conn.Close();
                        //Обновление таблицы
                        f2.conn.Open();
                        s2.table.Clear();
                        s2.table.Columns.Clear();
                        string cl = "SELECT * FROM Client;";
                        s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                        dataGridView1.DataSource = s2.bSource;
                        s2.bSource.DataSource = s2.table;
                        s2.MyDA.Fill(s2.table);
                        coluumn();
                        dataGridView1.ColumnHeadersVisible = true;
                        f2.num(1);
                        dataGridView1.Columns[0].ReadOnly = true;
                        f2.conn.Close();
                    }
                    else if (f2.number == 2)
                    {
                        f2.conn.Open();
                        DataGridViewRow row = dataGridView1.Rows[f2.line];
                        string com = $"DELETE FROM employee WHERE id_em = {row.Cells[0].Value}";
                        MySqlCommand command = new MySqlCommand(com, f2.conn);
                        command.ExecuteNonQuery();
                        f2.conn.Close();
                        //Обновление таблицы
                        f2.conn.Open();
                        s2.table.Clear();
                        s2.table.Columns.Clear();
                        string cl = "SELECT * FROM employee;";
                        s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                        dataGridView1.DataSource = s2.bSource;
                        s2.bSource.DataSource = s2.table;
                        s2.MyDA.Fill(s2.table);
                        coluumn();
                        dataGridView1.ColumnHeadersVisible = true;
                        f2.num(3);
                        dataGridView1.Columns[0].ReadOnly = true;
                        f2.conn.Close();
                    }
                    else if (f2.number == 3)
                    {

                        f2.conn.Open();
                        DataGridViewRow row = dataGridView1.Rows[f2.line];
                        string com = $"DELETE FROM expenses WHERE id_cex = {row.Cells[0].Value}";
                        MySqlCommand command = new MySqlCommand(com, f2.conn);
                        command.ExecuteNonQuery();
                        f2.conn.Close();
                        //Обновление таблицы
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
                        dataGridView1.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd";
                        f2.num(3);
                        dataGridView1.Columns[0].ReadOnly = true;
                        dataGridView1.Columns[0].HeaderText = "ID";
                        dataGridView1.Columns[1].HeaderText = "Тип расхода";
                        dataGridView1.Columns[2].HeaderText = "Дата";
                        dataGridView1.Columns[3].HeaderText = "Ответственный";
                        f2.conn.Close();
                    }
                    else if (f2.number == 4)
                    {
                        f2.conn.Open();
                        DataGridViewRow row = dataGridView1.Rows[f2.line];
                        string com = $"DELETE FROM income WHERE id_in = {row.Cells[0].Value}";
                        MySqlCommand command = new MySqlCommand(com, f2.conn);
                        command.ExecuteNonQuery();
                        f2.conn.Close();
                        //Обновление таблицы
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
                        dataGridView1.Columns[0].ReadOnly = true;
                        f2.conn.Close();
                    }
                    else if (f2.number == 5)
                    {
                        f2.conn.Open();
                        DataGridViewRow row = dataGridView1.Rows[f2.line];
                        string com = $"DELETE FROM Orders WHERE id_or = {row.Cells[0].Value}";
                        MySqlCommand command = new MySqlCommand(com, f2.conn);
                        command.ExecuteNonQuery();
                        f2.conn.Close();
                        //Обновление таблицы
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
                        dataGridView1.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd";
                        f2.num(5);
                        dataGridView1.Columns[0].ReadOnly = true;
                        f2.conn.Close();

                    }
                    else if (f2.number == 6)
                    {
                        f2.conn.Open();
                        DataGridViewRow row = dataGridView1.Rows[f2.line];
                        string com = $"DELETE FROM privilege WHERE id_pr = {row.Cells[0].Value}";
                        MySqlCommand command = new MySqlCommand(com, f2.conn);
                        command.ExecuteNonQuery();
                        f2.conn.Close();
                        //Обновление таблицы
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
                        dataGridView1.Columns[0].ReadOnly = true;
                        f2.conn.Close();
                    }
                    else if (f2.number == 7)
                    {
                        f2.conn.Open();
                        DataGridViewRow row = dataGridView1.Rows[f2.line];
                        string com = $"DELETE FROM privilege WHERE id_pr = {row.Cells[0].Value}";
                        MySqlCommand command = new MySqlCommand(com, f2.conn);
                        command.ExecuteNonQuery();
                        f2.conn.Close();
                        //Обновление таблицы
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
                        f2.num(7);
                        dataGridView1.Columns[0].ReadOnly = true;
                        f2.conn.Close();
                    }
                    else if (f2.number == 8)
                    {
                        f2.conn.Open();
                        DataGridViewRow row = dataGridView1.Rows[f2.line];
                        string com = $"DELETE FROM tariff WHERE id_ta = {row.Cells[0].Value}";
                        MySqlCommand command = new MySqlCommand(com, f2.conn);
                        command.ExecuteNonQuery();
                        f2.conn.Close();
                        //Обновление таблицы
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
                        dataGridView1.Columns[0].HeaderText = "ID";
                        dataGridView1.Columns[1].HeaderText = "Наименование товара";
                        dataGridView1.Columns[2].HeaderText = "Цена";
                        dataGridView1.Columns[3].HeaderText = "Краткое описание";
                        f2.num(8);
                        dataGridView1.Columns[0].ReadOnly = true;
                        f2.conn.Close();
                    }
                    else if (f2.number == 9)
                    {
                        f2.conn.Open();
                        DataGridViewRow row = dataGridView1.Rows[f2.line];
                        string com = $"DELETE FROM types_expenses WHERE id_ty = {row.Cells[0].Value}";
                        MySqlCommand command = new MySqlCommand(com, f2.conn);
                        command.ExecuteNonQuery();
                        f2.conn.Close();
                        //Обновление таблицы
                        f2.conn.Open();
                        s2.table.Clear();
                        s2.table.Columns.Clear();
                        string cl = "SELECT * FROM types_expenses;";
                        s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
                        dataGridView1.DataSource = s2.bSource;
                        s2.bSource.DataSource = s2.table;
                        s2.MyDA.Fill(s2.table);
                        coluumn();
                        dataGridView1.ColumnHeadersVisible = true;
                        f2.num(7);
                        dataGridView1.Columns[0].ReadOnly = true;
                        f2.conn.Close();
                    }
                }
                catch { }
                finally { f2.conn.Close(); }
            }
            else if (result == DialogResult.No) { }
        }//удаление
        public void update(object sender, EventArgs e)
        {
            if (f2.number == 1)
            {
                f2.conn.Open();
                pop.max = "SELECT COUNT(*) FROM Client;";
                MySqlCommand command = new MySqlCommand(pop.max, f2.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pop.maxx = Convert.ToInt32(reader[0]);
                }
                f2.conn.Close();
                for (int i = 0; i < pop.maxx; i++)
                {
                    try
                    {
                        f2.conn.Open();
                        int rowIndex = i;
                        int q = 0;
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];
                        string a = $"SELECT id_cl FROM Client WHERE id_cl = {row.Cells[0].Value}";
                        MySqlCommand a1 = new MySqlCommand(a, f2.conn);
                        MySqlDataReader reader1 = a1.ExecuteReader();
                        while (reader1.Read())
                        {
                            q = Convert.ToInt32(reader1[0]);
                        }
                        f2.conn.Close();
                        f2.conn.Open();
                        if (q == Convert.ToInt32(row.Cells[0].Value))
                        {
                            string cl = $"UPDATE Client SET fio_cl = \"{row.Cells[1].Value}\", telephon_cl = \"{row.Cells[2].Value}\"  WHERE id_cl ={row.Cells[0].Value};";
                            MySqlCommand command1 = new MySqlCommand(cl, f2.conn);
                            command1.ExecuteNonQuery();
                        }
                        f2.conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                        f2.conn.Close();
                    }
                }
                // добавление новой записи прямо через грид
                int rowCount = s2.table.Rows.Count;
                if (rowCount > pop.maxx)
                {
                    int a = rowCount - pop.maxx;
                    int b = 0;
                    for (int i = 0; i < a; i++)
                    {
                        try
                        {
                            f2.conn.Open();
                            string ba = $"SELECT MAX(id_cl) FROM Client;";
                            MySqlCommand command1 = new MySqlCommand(ba, f2.conn);
                            MySqlDataReader reader1 = command1.ExecuteReader();
                            while (reader1.Read())
                            {
                                b = Convert.ToInt32(reader1[0]);
                            }
                            b++;
                            f2.conn.Close();
                            f2.conn.Open();
                            int rowIndex = pop.maxx++;
                            DataGridViewRow row = dataGridView1.Rows[rowIndex];
                            string cl = $"INSERT Client VALUES ( {b},\"{row.Cells[1].Value}\",\"{row.Cells[2].Value}\")";
                            MySqlCommand command2 = new MySqlCommand(cl, f2.conn);
                            command2.ExecuteNonQuery();
                            f2.conn.Close();
                        }
                        catch (Exception ex) { MessageBox.Show($"{ex.Message}"); }
                    }
                }
                //обновление таблицы
                f2.conn.Open();
                s2.table.Clear();
                s2.table.Columns.Clear();
                string coc = "SELECT * FROM Client;";
                s2.MyDA.SelectCommand = new MySqlCommand(coc, f2.conn);
                dataGridView1.DataSource = s2.bSource;
                s2.bSource.DataSource = s2.table;
                s2.MyDA.Fill(s2.table);
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "ФИО";
                dataGridView1.Columns[2].HeaderText = "Телефон";
                coluumn();
                dataGridView1.ColumnHeadersVisible = true;
                dataGridView1.Columns[0].ReadOnly = true;
                f2.num(1);
                f2.conn.Close();
            }
            else if (f2.number == 2)
            {
                // обновление новых записей прямо в гриде
                f2.conn.Open();
                pop.max = "SELECT COUNT(*) FROM employee;";
                MySqlCommand command = new MySqlCommand(pop.max, f2.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pop.maxx = Convert.ToInt32(reader[0]);
                }
                f2.conn.Close();
                for (int i = 0; i < pop.maxx; i++)
                {
                    try
                    {
                        f2.conn.Open();
                        int rowIndex = i;
                        int q = 0;
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];
                        string a = $"SELECT id_em FROM employee WHERE id_em = {row.Cells[0].Value}";
                        MySqlCommand a1 = new MySqlCommand(a, f2.conn);
                        MySqlDataReader reader1 = a1.ExecuteReader();
                        while (reader1.Read())
                        {
                            q = Convert.ToInt32(reader1[0]);
                        }
                        f2.conn.Close();
                        f2.conn.Open();
                        if (q == Convert.ToInt32(row.Cells[0].Value))
                        {
                            string cl = $"UPDATE employee SET fio_em = \"{row.Cells[1].Value}\", telephone_em = \"{row.Cells[2].Value}\", post_em = \"{row.Cells[3].Value}\"," +
                                $" role_em = {row.Cells[4].Value}, login_em = \"{row.Cells[5].Value}\", pasword = \"{row.Cells[6].Value}\"WHERE id_em ={row.Cells[0].Value};";
                            MySqlCommand command1 = new MySqlCommand(cl, f2.conn);
                            command1.ExecuteNonQuery();
                        }
                        f2.conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                        f2.conn.Close();
                    }
                }
                // добавление новой записи прямо через грид
                int rowCount = s2.table.Rows.Count;
                if (rowCount > pop.maxx)
                {
                    int a = rowCount - pop.maxx;
                    int b = 0;
                    for (int i = 0; i < a; i++)
                    {
                        try
                        {
                            f2.conn.Open();
                            string ba = $"SELECT MAX(id_em) FROM employee;";
                            MySqlCommand command1 = new MySqlCommand(ba, f2.conn);
                            MySqlDataReader reader1 = command1.ExecuteReader();
                            while (reader1.Read())
                            {
                                b = Convert.ToInt32(reader1[0]);
                            }
                            b++;
                            f2.conn.Close();
                            f2.conn.Open();
                            int rowIndex = pop.maxx++;
                            DataGridViewRow row = dataGridView1.Rows[rowIndex];
                            string cl = $"INSERT employee VALUES ( {b},\"{row.Cells[1].Value}\",\"{row.Cells[2].Value}\",\"{row.Cells[3].Value}\",{row.Cells[4].Value},\"{row.Cells[5].Value}\",\"{row.Cells[6].Value}\")";
                            MySqlCommand command2 = new MySqlCommand(cl, f2.conn);
                            command2.ExecuteNonQuery();
                            f2.conn.Close();
                        }
                        catch (Exception ex) { MessageBox.Show($"{ex.Message}"); }
                    }
                }
                //обновление таблицы
                f2.conn.Open();
                s2.table.Clear();
                s2.table.Columns.Clear();
                string coc = "SELECT * FROM employee;";
                s2.MyDA.SelectCommand = new MySqlCommand(coc, f2.conn);
                dataGridView1.DataSource = s2.bSource;
                s2.bSource.DataSource = s2.table;
                s2.MyDA.Fill(s2.table);
                coluumn();
                dataGridView1.ColumnHeadersVisible = true;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "ФИО";
                dataGridView1.Columns[2].HeaderText = "Телефон";
                dataGridView1.Columns[3].HeaderText = "Должность";
                dataGridView1.Columns[4].HeaderText = "Роль в программе";
                dataGridView1.Columns[5].HeaderText = "Логин";
                dataGridView1.Columns[6].HeaderText = "Пароль в sha256";
                f2.num(2);
                f2.conn.Close();
            }
            else if (f2.number == 3)
            {
                //Обновление новых записий прям в гриде
                f2.conn.Open();
                pop.max = "SELECT COUNT(*) FROM expenses;";
                MySqlCommand command = new MySqlCommand(pop.max, f2.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pop.maxx = Convert.ToInt32(reader[0]);
                }
                f2.conn.Close();
                for (int i = 0; i < pop.maxx; i++)
                {
                    try
                    {
                        f2.conn.Open();
                        int rowIndex = i;
                        int q = 0;
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];
                        string a = $"SELECT id_ex FROM expenses WHERE id_ex = {row.Cells[0].Value}";
                        MySqlCommand a1 = new MySqlCommand(a, f2.conn);
                        MySqlDataReader reader1 = a1.ExecuteReader();
                        while (reader1.Read())
                        {
                            q = Convert.ToInt32(reader1[0]);
                        }
                        f2.conn.Close();
                        f2.conn.Open();
                        if (q == Convert.ToInt32(row.Cells[0].Value))
                        {
                            string s =Convert.ToString(row.Cells[2].Value);
                            var dt = Convert.ToDateTime(row.Cells[2].Value);
                            var str = string.Format("{0}-{1}-{2} {3}:{4}:{5}",dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
                            string cl = $"UPDATE expenses SET tepy_ex = {row.Cells[1].Value}, date_ex = \"{str}\", responsible_ex = {row.Cells[3].Value}  WHERE id_ex = {row.Cells[0].Value};";
                            MySqlCommand command1 = new MySqlCommand(cl, f2.conn);
                            command1.ExecuteNonQuery();
                        }
                        f2.conn.Close();
                    }
                    catch (Exception ex)
                    {
                         MessageBox.Show($"{ex.Message}");
                        f2.conn.Close();
                    }
                }
                // добавление новой записи прямо через грид
                int rowCount = s2.table.Rows.Count;
                if (rowCount > pop.maxx)
                {
                    int a = rowCount - pop.maxx;
                    int b = 0;
                    for (int i = 0; i < a; i++)
                    {
                        try
                        {
                            f2.conn.Open();
                            string ba = $"SELECT MAX(id_ex) FROM expenses;";
                            MySqlCommand command1 = new MySqlCommand(ba, f2.conn);
                            MySqlDataReader reader1 = command1.ExecuteReader();
                            while (reader1.Read())
                            {
                                b = Convert.ToInt32(reader1[0]);
                            }
                            b++;
                            f2.conn.Close();
                            f2.conn.Open();
                            int rowIndex = pop.maxx++;
                            DataGridViewRow row = dataGridView1.Rows[rowIndex];
                            var dt = Convert.ToDateTime(row.Cells[2].Value);
                            var str = string.Format("{0}-{1}-{2} {3}:{4}:{5}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
                            string cl = $"INSERT expenses VALUES ( {b},{row.Cells[1].Value},\"{str}\",{row.Cells[3].Value})";
                            MySqlCommand command2 = new MySqlCommand(cl, f2.conn);
                            command2.ExecuteNonQuery();
                            f2.conn.Close();
                        }
                        catch (Exception ex) { f2.conn.Close(); MessageBox.Show($"{ex.Message}"); }
                    }
                }
                //обновление таблицы
                f2.conn.Open();
                s2.table.Clear();
                s2.table.Columns.Clear();
                string coc = "SELECT * FROM expenses;";
                s2.MyDA.SelectCommand = new MySqlCommand(coc, f2.conn);
                dataGridView1.DataSource = s2.bSource;
                s2.bSource.DataSource = s2.table;
                s2.MyDA.Fill(s2.table);
                coluumn();
                dataGridView1.ColumnHeadersVisible = true;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd";
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Тип расхода";
                dataGridView1.Columns[2].HeaderText = "Дата";
                dataGridView1.Columns[3].HeaderText = "Ответственный";
                f2.num(3);
                f2.conn.Close();
            }
            else if (f2.number == 5)
            {
                //Обновление новых записий прям в гриде
                f2.conn.Open();
                pop.max = "SELECT COUNT(*) FROM Orders;";
                MySqlCommand command = new MySqlCommand(pop.max, f2.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pop.maxx = Convert.ToInt32(reader[0]);
                }
                f2.conn.Close();
                for (int i = 0; i < pop.maxx; i++)
                {
                    try
                    {
                        f2.conn.Open();
                        int rowIndex = i;
                        int q = 0;
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];
                        string a = $"SELECT id_or FROM Orders WHERE id_or = {row.Cells[0].Value}";
                        MySqlCommand a1 = new MySqlCommand(a, f2.conn);
                        MySqlDataReader reader1 = a1.ExecuteReader();
                        while (reader1.Read())
                        {
                            q = Convert.ToInt32(reader1[0]);
                        }
                        f2.conn.Close();
                        f2.conn.Open();
                        if (q == Convert.ToInt32(row.Cells[0].Value))
                        {
                            var dt = Convert.ToDateTime(row.Cells[3].Value);
                            var str = string.Format("{0}-{1}-{2} {3}:{4}:{5}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
                            string cl = $"UPDATE Orders SET id_cl = {row.Cells[1].Value}, id_ta = {row.Cells[2].Value}, date = \"{str}\"  WHERE id_or = {row.Cells[0].Value};";
                            MySqlCommand command1 = new MySqlCommand(cl, f2.conn);
                            command1.ExecuteNonQuery();
                        }
                        f2.conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                        f2.conn.Close();
                    }
                }
                // добавление новой записи прямо через грид
                int rowCount = s2.table.Rows.Count;
                if (rowCount > pop.maxx)
                {
                    int a = rowCount - pop.maxx;
                    int b = 0;
                    for (int i = 0; i < a; i++)
                    {
                        try
                        {
                            f2.conn.Open();
                            string ba = $"SELECT MAX(id_or) FROM Orders;";
                            MySqlCommand command1 = new MySqlCommand(ba, f2.conn);
                            MySqlDataReader reader1 = command1.ExecuteReader();
                            while (reader1.Read())
                            {
                                b = Convert.ToInt32(reader1[0]);
                            }
                            b++;
                            f2.conn.Close();
                            f2.conn.Open();
                            int rowIndex = pop.maxx++;
                            DataGridViewRow row = dataGridView1.Rows[rowIndex];
                            var dt = Convert.ToDateTime(row.Cells[3].Value);
                            var str = string.Format("{0}-{1}-{2} {3}:{4}:{5}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
                            string cl = $"INSERT Orders VALUES ( {b},{row.Cells[1].Value},{row.Cells[2].Value},\"{str}\")";
                            MySqlCommand command2 = new MySqlCommand(cl, f2.conn);
                            command2.ExecuteNonQuery();
                            f2.conn.Close();
                        }
                        catch (Exception ex) { MessageBox.Show($"{ex.Message}"); }
                    }
                }
                //обновление таблицы
                f2.conn.Open();
                s2.table.Clear();
                s2.table.Columns.Clear();
                string coc = "SELECT * FROM Orders;";
                s2.MyDA.SelectCommand = new MySqlCommand(coc, f2.conn);
                dataGridView1.DataSource = s2.bSource;
                s2.bSource.DataSource = s2.table;
                s2.MyDA.Fill(s2.table);
                coluumn();
                dataGridView1.ColumnHeadersVisible = true;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd";
                f2.num(5);
                f2.conn.Close();
            }
            else if (f2.number == 6)
            {
                //Обновление новых записий прям в гриде
                f2.conn.Open();
                pop.max = "SELECT COUNT(*) FROM privilege;";
                MySqlCommand command = new MySqlCommand(pop.max, f2.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pop.maxx = Convert.ToInt32(reader[0]);
                }
                f2.conn.Close();
                for (int i = 0; i < pop.maxx; i++)
                {
                    try
                    {
                        f2.conn.Open();
                        int rowIndex = i;
                        int q = 0;
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];
                        string a = $"SELECT id_pr FROM privilege WHERE id_pr = {row.Cells[0].Value}";
                        MySqlCommand a1 = new MySqlCommand(a, f2.conn);
                        MySqlDataReader reader1 = a1.ExecuteReader();
                        while (reader1.Read())
                        {
                            q = Convert.ToInt32(reader1[0]);
                        }
                        f2.conn.Close();
                        f2.conn.Open();
                        if (q == Convert.ToInt32(row.Cells[0].Value))
                        {
                            string cl = $"UPDATE privilege SET name_pr = \"{row.Cells[1].Value}\", level_pr = {row.Cells[2].Value},Description_pr = \"{row.Cells[3].Value}\"  WHERE id_pr ={row.Cells[0].Value};";
                            MySqlCommand command1 = new MySqlCommand(cl, f2.conn);
                            command1.ExecuteNonQuery();
                        }
                        f2.conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                        f2.conn.Close();
                    }
                }
                // добавление новой записи прямо через грид
                int rowCount = s2.table.Rows.Count;
                if (rowCount > pop.maxx)
                {
                    int a = rowCount - pop.maxx;
                    int b = 0;
                    for (int i = 0; i < a; i++)
                    {
                        try
                        {
                            f2.conn.Open();
                            string ba = $"SELECT MAX(id_pr) FROM privilege;";
                            MySqlCommand command1 = new MySqlCommand(ba, f2.conn);
                            MySqlDataReader reader1 = command1.ExecuteReader();
                            while (reader1.Read())
                            {
                                b = Convert.ToInt32(reader1[0]);
                            }
                            b++;
                            f2.conn.Close();
                            f2.conn.Open();
                            int rowIndex = pop.maxx++;
                            DataGridViewRow row = dataGridView1.Rows[rowIndex];
                            string cl = $"INSERT privilege VALUES ( {b},\"{row.Cells[1].Value}\",{row.Cells[2].Value},\"{row.Cells[3].Value}\")";
                            MySqlCommand command2 = new MySqlCommand(cl, f2.conn);
                            command2.ExecuteNonQuery();
                            f2.conn.Close();
                        }
                        catch (Exception ex) { MessageBox.Show($"{ex.Message}"); }
                    }
                }
                //обновление таблицы
                f2.conn.Open();
                s2.table.Clear();
                s2.table.Columns.Clear();
                string coc = "SELECT * FROM privilege;";
                s2.MyDA.SelectCommand = new MySqlCommand(coc, f2.conn);
                dataGridView1.DataSource = s2.bSource;
                s2.bSource.DataSource = s2.table;
                s2.MyDA.Fill(s2.table);
                coluumn();
                dataGridView1.ColumnHeadersVisible = true;
                dataGridView1.Columns[0].ReadOnly = true;
                f2.num(6);
                f2.conn.Close();
            }
            else if (f2.number == 7)
            {
                //Обновление новых записий прям в гриде
                f2.conn.Open();
                pop.max = "SELECT COUNT(*) FROM provider;";
                MySqlCommand command = new MySqlCommand(pop.max, f2.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pop.maxx = Convert.ToInt32(reader[0]);
                }
                f2.conn.Close();
                for (int i = 0; i < pop.maxx; i++)
                {
                    try
                    {
                        f2.conn.Open();
                        int rowIndex = i;
                        int q = 0;
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];
                        string a = $"SELECT id_pr FROM provider WHERE id_pr = {row.Cells[0].Value}";
                        MySqlCommand a1 = new MySqlCommand(a, f2.conn);
                        MySqlDataReader reader1 = a1.ExecuteReader();
                        while (reader1.Read())
                        {
                            q = Convert.ToInt32(reader1[0]);
                        }
                        f2.conn.Close();
                        f2.conn.Open();
                        if (q == Convert.ToInt32(row.Cells[0].Value))
                        {
                            string cl = $"UPDATE provider SET telephone_pr = \"{row.Cells[1].Value}\", company_pr = \"{row.Cells[2].Value}\", address_pr = \"{row.Cells[3].Value}\" WHERE id_pr = {row.Cells[0].Value};";
                            MySqlCommand command1 = new MySqlCommand(cl, f2.conn);
                            command1.ExecuteNonQuery();
                        }
                        f2.conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                        f2.conn.Close();
                    }
                }
                // добавление новой записи прямо через грид
                int rowCount = s2.table.Rows.Count;
                if (rowCount > pop.maxx)
                {
                    int a = rowCount - pop.maxx;
                    int b = 0;
                    for (int i = 0; i < a; i++)
                    {
                        try
                        {
                            f2.conn.Open();
                            string ba = $"SELECT MAX(id_pr) FROM provider;";
                            MySqlCommand command1 = new MySqlCommand(ba, f2.conn);
                            MySqlDataReader reader1 = command1.ExecuteReader();
                            while (reader1.Read())
                            {
                                b = Convert.ToInt32(reader1[0]);
                            }
                            b++;
                            f2.conn.Close();
                            f2.conn.Open();
                            int rowIndex = pop.maxx++;
                            DataGridViewRow row = dataGridView1.Rows[rowIndex];
                            string cl = $"INSERT provider VALUES ( {b},\"{row.Cells[1].Value}\",\"{row.Cells[2].Value}\",\"{row.Cells[3].Value}\")";
                            MySqlCommand command2 = new MySqlCommand(cl, f2.conn);
                            command2.ExecuteNonQuery();
                            f2.conn.Close();
                        }
                        catch (Exception ex) { MessageBox.Show($"{ex.Message}"); }
                    }
                }
                //обновление таблицы
                f2.conn.Open();
                s2.table.Clear();
                s2.table.Columns.Clear();
                string coc = "SELECT * FROM provider;";
                s2.MyDA.SelectCommand = new MySqlCommand(coc, f2.conn);
                dataGridView1.DataSource = s2.bSource;
                s2.bSource.DataSource = s2.table;
                s2.MyDA.Fill(s2.table);
                coluumn();
                dataGridView1.ColumnHeadersVisible = true;
                dataGridView1.Columns[0].ReadOnly = true;
                f2.num(7);
                f2.conn.Close();
            }
            else if (f2.number == 8)
            {
                //Обновление новых записий прям в гриде
                f2.conn.Open();
                pop.max = "SELECT COUNT(*) FROM tariff;";
                MySqlCommand command = new MySqlCommand(pop.max, f2.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pop.maxx = Convert.ToInt32(reader[0]);
                }
                f2.conn.Close();
                for (int i = 0; i < pop.maxx; i++)
                {
                    try
                    {
                        f2.conn.Open();
                        int rowIndex = i;
                        int q = 0;
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];
                        string a = $"SELECT id_ta FROM tariff WHERE id_ta = {row.Cells[0].Value}";
                        MySqlCommand a1 = new MySqlCommand(a, f2.conn);
                        MySqlDataReader reader1 = a1.ExecuteReader();
                        while (reader1.Read())
                        {
                            q = Convert.ToInt32(reader1[0]);
                        }
                        f2.conn.Close();
                        f2.conn.Open();
                        if (q == Convert.ToInt32(row.Cells[0].Value))
                        {
                            string cl = $"UPDATE tariff SET Name_ta = \"{row.Cells[1].Value}\", Price_ta = {row.Cells[2].Value}, Description_ta = \"{row.Cells[3].Value}\"  WHERE id_ta = {row.Cells[0].Value};";
                            MySqlCommand command1 = new MySqlCommand(cl, f2.conn);
                            command1.ExecuteNonQuery();
                        }
                        f2.conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                        f2.conn.Close();
                    }
                }
                // добавление новой записи прямо через грид
                int rowCount = s2.table.Rows.Count;
                if (rowCount > pop.maxx)
                {
                    int a = rowCount - pop.maxx;
                    int b = 0;
                    for (int i = 0; i < a; i++)
                    {
                        try
                        {
                            f2.conn.Open();
                            string ba = $"SELECT MAX(id_ta) FROM tariff;";
                            MySqlCommand command1 = new MySqlCommand(ba, f2.conn);
                            MySqlDataReader reader1 = command1.ExecuteReader();
                            while (reader1.Read())
                            {
                                b = Convert.ToInt32(reader1[0]);
                            }
                            b++;
                            f2.conn.Close();
                            f2.conn.Open();
                            int rowIndex = pop.maxx++;
                            DataGridViewRow row = dataGridView1.Rows[rowIndex];
                            string cl = $"INSERT tariff VALUES ( {b},\"{row.Cells[1].Value}\",{row.Cells[2].Value},\"{row.Cells[3].Value}\")";
                            MySqlCommand command2 = new MySqlCommand(cl, f2.conn);
                            command2.ExecuteNonQuery();
                            f2.conn.Close();
                        }
                        catch (Exception ex) { MessageBox.Show($"{ex.Message}"); }
                    }
                }
                //обновление таблицы
                f2.conn.Open();
                s2.table.Clear();
                s2.table.Columns.Clear();
                string coc = "SELECT * FROM tariff;";
                s2.MyDA.SelectCommand = new MySqlCommand(coc, f2.conn);
                dataGridView1.DataSource = s2.bSource;
                s2.bSource.DataSource = s2.table;
                s2.MyDA.Fill(s2.table);
                coluumn();
                dataGridView1.ColumnHeadersVisible = true;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Наименование товара";
                dataGridView1.Columns[2].HeaderText = "Цена";
                dataGridView1.Columns[3].HeaderText = "Краткое описание";
                f2.num(8);
                f2.conn.Close();
            }
            else if (f2.number == 9)
            {
                //Обновление новых записий прям в гриде
                f2.conn.Open();
                pop.max = "SELECT COUNT(*) FROM types_expenses;";
                MySqlCommand command = new MySqlCommand(pop.max, f2.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pop.maxx = Convert.ToInt32(reader[0]);
                }
                f2.conn.Close();
                for (int i = 0; i < pop.maxx; i++)
                {
                    try
                    {
                        f2.conn.Open();
                        int rowIndex = i;
                        int q = 0;
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];
                        string a = $"SELECT id_ty FROM types_expenses WHERE id_ty = {row.Cells[0].Value}";
                        MySqlCommand a1 = new MySqlCommand(a, f2.conn);
                        MySqlDataReader reader1 = a1.ExecuteReader();
                        while (reader1.Read())
                        {
                            q = Convert.ToInt32(reader1[0]);
                        }
                        f2.conn.Close();
                        f2.conn.Open();
                        if (q == Convert.ToInt32(row.Cells[0].Value))
                        {
                            string cl = $"UPDATE types_expenses SET name_ty = \"{row.Cells[1].Value}\", price_ty = {row.Cells[2].Value}, provider_ty = {row.Cells[3].Value}, employee_ty = {row.Cells[4].Value}  WHERE id_ty = {row.Cells[0].Value};";
                            MySqlCommand command1 = new MySqlCommand(cl, f2.conn);
                            command1.ExecuteNonQuery();
                        }
                        f2.conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                        f2.conn.Close();
                    }
                }
                // добавление новой записи прямо через грид
                int rowCount = s2.table.Rows.Count;
                if (rowCount > pop.maxx)
                {
                    int a = rowCount - pop.maxx;
                    int b = 0;
                    for (int i = 0; i < a; i++)
                    {
                        try
                        {
                            f2.conn.Open();
                            string ba = $"SELECT MAX(id_ty) FROM types_expenses;";
                            MySqlCommand command1 = new MySqlCommand(ba, f2.conn);
                            MySqlDataReader reader1 = command1.ExecuteReader();
                            while (reader1.Read())
                            {
                                b = Convert.ToInt32(reader1[0]);
                            }
                            b++;
                            f2.conn.Close();
                            f2.conn.Open();
                            int rowIndex = pop.maxx++;
                            DataGridViewRow row = dataGridView1.Rows[rowIndex];
                            string cl = $"INSERT types_expenses VALUES ( {b},\"{row.Cells[1].Value}\",{row.Cells[2].Value},{row.Cells[3].Value},{row.Cells[4].Value})";
                            MySqlCommand command2 = new MySqlCommand(cl, f2.conn);
                            command2.ExecuteNonQuery();
                            f2.conn.Close();
                        }
                        catch (Exception ex) { MessageBox.Show($"{ex.Message}"); }
                    }
                }
                //обновление таблицы
                f2.conn.Open();
                s2.table.Clear();
                s2.table.Columns.Clear();
                string coc = "SELECT * FROM types_expenses;";
                s2.MyDA.SelectCommand = new MySqlCommand(coc, f2.conn);
                dataGridView1.DataSource = s2.bSource;
                s2.bSource.DataSource = s2.table;
                s2.MyDA.Fill(s2.table);
                coluumn();
                dataGridView1.ColumnHeadersVisible = true;
                dataGridView1.Columns[0].ReadOnly = true;
                f2.num(9);
                f2.conn.Close();
            }
        }//обновить
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
        }//колонки
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
            coluumn();
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[2].HeaderText = "Телефон";
            f2.num(1);
            f2.conn.Close();
        }// клиенты(1)
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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[2].HeaderText = "Телефон";
            dataGridView1.Columns[3].HeaderText = "Должность";
            dataGridView1.Columns[4].HeaderText = "Роль в программе";
            dataGridView1.Columns[5].HeaderText = "Логин";
            dataGridView1.Columns[6].HeaderText = "Пароль в sha256";
            f2.num(2);
            f2.conn.Close();
        }// сотрудники(2)
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
            dataGridView1.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Тип расхода";
            dataGridView1.Columns[2].HeaderText = "Дата";
            dataGridView1.Columns[3].HeaderText = "Ответственный";
            f2.num(3);
            f2.conn.Close();
        }// расходы(3)
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
        }// доходы(4)
        public void Order(object sender, EventArgs e)// заказы : клинты и время(5)
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
            dataGridView1.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd";
            f2.num(5);
            dataGridView1.Columns[0].ReadOnly = true;
            f2.conn.Close();
        }
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
        }// привилегии и их описание(6)
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
        }// поставщик (7)
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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Наименование товара";
            dataGridView1.Columns[2].HeaderText = "Цена";
            dataGridView1.Columns[3].HeaderText = "Краткое описание";
            f2.num(8);
            f2.conn.Close();
        }// расценка всех покупок(8)
        public void tepes_expens(object sender, EventArgs e)
        {
            f2.conn.Open();
            s2.table.Clear();
            s2.table.Columns.Clear();
            string cl = "SELECT * FROM types_expenses;";
            s2.MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = s2.bSource;
            s2.bSource.DataSource = s2.table;
            s2.MyDA.Fill(s2.table);
            coluumn();
            dataGridView1.ColumnHeadersVisible = true;
            f2.num(9);
            f2.conn.Close();
        }// типы расходов(9)

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            f2.line = rowIndex;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void приветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            update(a2,e);
        }
    }
}
