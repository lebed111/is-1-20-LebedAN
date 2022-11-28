﻿using System;
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
    public partial class Authorization : Form
    {

        Requests.Requests f2 = new Requests.Requests();


        //Вычисление хэша строки и возрат его из метода
        static string sha256(string randomString)
        {
            //Тут происходит криптографическая магия. Смысл данного метода заключается в том, что строка залетает в метод
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }


        public void GetUserInfo(string login_user)
        {
            //Объявлем переменную для запроса в БД
            string selected_id_stud = textBox1.Text;
            // устанавливаем соединение с БД
            f2.conn.Open();
            // запрос
            string sql = $"SELECT * FROM employee WHERE login_em ='{login_user}'";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, f2.conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                Auth.auth_id = reader[0].ToString();
                Auth.auth_fio = reader[1].ToString();
                Auth.auth_role = Convert.ToInt32(reader[4].ToString());
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            f2.conn.Close();
        }



        public Authorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

                //Запрос в БД на предмет того, если ли строка с подходящим логином и паролем
                string sql = "SELECT login_em, pasword FROM employee WHERE login_em = @un and  pasword = @up";
                //Открытие соединения
                f2.conn.Open();
                //Объявляем таблицу
                DataTable table = new DataTable();
                //Объявляем адаптер
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                //Объявляем команду
                MySqlCommand command = new MySqlCommand(sql, f2.conn);
                //Определяем параметры
                command.Parameters.Add("@un", MySqlDbType.VarChar, 25);
                command.Parameters.Add("@up", MySqlDbType.VarChar, 25);
                //Присваиваем параметрам значение
                command.Parameters["@un"].Value = textBox1.Text;
                command.Parameters["@up"].Value = sha256(textBox2.Text);
                //Заносим команду в адаптер
                adapter.SelectCommand = command;
                //Заполняем таблицу
                adapter.Fill(table);
                //Закрываем соединение
                f2.conn.Close();
                //Если вернулась больше 0 строк, значит такой пользователь существует
                if (table.Rows.Count > 0)
                {
                    //Присваеваем глобальный признак авторизации
                    Auth.auth = true;
                    GetUserInfo(textBox1.Text);
                    //Закрываем форму
                    this.Close();
                }
                else
                {
                    //Отобразить сообщение о том, что авторизаия неуспешна
                    MessageBox.Show("Неверные данные авторизации!");
                }
        }

        //Закрытие формы
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            finally
            {
                this.Close();
            }
        }
        private void Authorization_Load(object sender, EventArgs e)
        {
            f2.con();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
