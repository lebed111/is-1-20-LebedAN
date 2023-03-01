using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Requests
{
    public class Requests
    {
        public MySqlConnection conn;
        public static int test;
        public int number;
        public static int lin;
        public int line;
        public static string dat1;
        public static string dat2;
        public string date1;
        public string date2;
        public Dictionary<string, string> tupe_ex = new Dictionary<string, string>();
        public Queue<string> expen = new Queue<string>();
        public Dictionary<string, string> respo = new Dictionary<string, string>();
        public Queue<string> respomax = new Queue<string>();
        public Dictionary<string, string> id_cl = new Dictionary<string, string>();
        public Queue<string> id_clmax = new Queue<string>();
        public Dictionary<string, string> id_ta = new Dictionary<string, string>();
        public Queue<string> id_tamax = new Queue<string>();
        public void con()
        {
            string connStr = "server=chuc.sdlik.ru;port=33333;user=st_1_20_19;database=is_1_20_st19_KURS;password=14313537;";
            conn = new MySqlConnection(connStr);
            if(conn == null)
            {
                string connStr1 = "server=10.90.12.110;port=33333;user=st_1_20_19;database=is_1_20_st19_KURS;password=14313537;";
                conn = new MySqlConnection(connStr1);
            }
            number = test;
            date1 = dat1;
            date2 = dat2;
        }
        public void num(int i)
        {
            test = i;
            number = test;
            lin = i;
            line = lin;
        }
        public void date(string e , string r)
        {
            dat1 = e;
            dat2 = r;
            date1 = dat1;
            date2 = dat2;
        }
        #region//пока не нужно, но используеться в коде 
        public void reespoc()
        {
            conn.Open();
            respo.Clear();
            string c = "SELECT id_em,fio_em FROM employee";
            MySqlCommand command = new MySqlCommand(c, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                respo.Add(Convert.ToString(reader[0]), Convert.ToString(reader[1]));
            }
            conn.Close();
        }
        public void expens()
        {
            conn.Open();
            tupe_ex.Clear();
            string c = "SELECT id_ty,name_ty FROM types_expenses";
            MySqlCommand command = new MySqlCommand(c, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tupe_ex.Add(Convert.ToString(reader[0]), Convert.ToString(reader[1]));
            }
            conn.Close();
        }
        public void epensmax()
        {
            conn.Open();
            expen.Clear();
            string c = "SELECT * FROM expenses";
            MySqlCommand command = new MySqlCommand(c, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                expen.Enqueue(Convert.ToString(reader[1]));
                
            }
            conn.Close();
        }
        public void ressposmax()
        {
            conn.Open();
            respomax.Clear();
            string c = "SELECT * FROM expenses";
            MySqlCommand command = new MySqlCommand(c, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                respomax.Enqueue(Convert.ToString(reader[3]));
            }
            conn.Close();
        }
        public void fid_cl()
        {
            conn.Open();
            id_cl.Clear();
            string c = "SELECT id_cl,fio_cl FROM Client";
            MySqlCommand command = new MySqlCommand(c, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_cl.Add(Convert.ToString(reader[0]), Convert.ToString(reader[1]));
            }
            conn.Close();
        }
        public void fid_clmax()
        {
            conn.Open();
            id_clmax.Clear();
            string c = "SELECT * FROM Orders";
            MySqlCommand command = new MySqlCommand(c, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_clmax.Enqueue(Convert.ToString(reader[1]));
            }
            conn.Close();
        }
        public void fid_ta()
        {
            conn.Open();
            id_ta.Clear();
            string c = "SELECT id_ta,Name_ta FROM tariff";
            MySqlCommand command = new MySqlCommand(c, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_ta.Add(Convert.ToString(reader[0]), Convert.ToString(reader[1]));
            }
            conn.Close();
        }
        public void fidtamax()
        {
            conn.Open();
            id_tamax.Clear();
            string c = "SELECT * FROM Orders";
            MySqlCommand command = new MySqlCommand(c, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_tamax.Enqueue(Convert.ToString(reader[2]));
            }
            conn.Close();
        }
        #endregion

        #region//Методы для почти автоматизированного вызова в грид
        public List<string> st1 = new List<string>();
        public List<string> st2 = new List<string>();
        public List<string> st3 = new List<string>();
        public List<string> st4 = new List<string>();
        public List<string> st5 = new List<string>();
        public List<string> st6 = new List<string>();
        public List<string> st7 = new List<string>();
        public List<int> in1 = new List<int>();
        public List<int> in2 = new List<int>();
        public List<int> in3 = new List<int>();
        public List<int> in4 = new List<int>();
        public void ClerList()
        {
            st1.Clear(); st2.Clear(); st3.Clear(); st4.Clear(); st5.Clear(); st6.Clear(); st7.Clear();
            in1.Clear(); in2.Clear(); in3.Clear(); in4.Clear();
        }
        public void Client()
        {
            ClerList();
            number = 1;
            string s = "SELECT * FROM Client";
            conn.Open();
            MySqlCommand command = new MySqlCommand(s, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                st1.Add(Convert.ToString(reader[0]));
                st2.Add(Convert.ToString(reader[1]));
                st3.Add(Convert.ToString(reader[2]));
            }
            conn.Close();
        }
        public void employee()
        {
            ClerList();
            number = 2;
            string s = "SELECT employee.id_em,employee.fio_em,employee.telephone_em,employee.post_em,privilege.name_pr AS role_em, employee.login_em,sha256.password AS pasword FROM employee LEFT JOIN privilege ON employee.role_em = privilege.id_pr LEFT JOIN sha256 ON employee.pasword = sha256.id";
            conn.Open();
            MySqlCommand command = new MySqlCommand(s, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                st1.Add(Convert.ToString(reader[0]));
                st2.Add(Convert.ToString(reader[1]));
                st3.Add(Convert.ToString(reader[2]));
                st4.Add(Convert.ToString(reader[3]));
                st5.Add(Convert.ToString(reader[4]));
                st6.Add(Convert.ToString(reader[5]));
                st7.Add(Convert.ToString(reader[6]));

            }
            conn.Close();
        }
        public void expenses()
        {
            ClerList();
            number = 3;
            string s = "SELECT expenses.id_ex,expenses.description,expenses.price,expenses.date,employee.fio_em AS emploee, provider.company_pr AS provide FROM expenses LEFT JOIN employee ON expenses.emploee = employee.id_em LEFT JOIN provider ON expenses.provide = provider.id_pr";
            conn.Open();
            MySqlCommand command = new MySqlCommand(s, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                st1.Add(Convert.ToString(reader[0]));
                st2.Add(Convert.ToString(reader[1]));
                st3.Add(Convert.ToString(reader[2]));
                st4.Add(Convert.ToString(reader[3]));
                st5.Add(Convert.ToString(reader[4]));
                st6.Add(Convert.ToString(reader[5]));
            }
            conn.Close();
        }
        public void orders()
        {
            ClerList();
            number = 5;
            string s = "SELECT Orders.id_or,Client.fio_cl AS id_cl,tariff.Price_ta AS id_ta,Orders.date,Orders.date_using FROM Orders LEFT JOIN tariff ON Orders.id_ta = tariff.id_ta LEFT JOIN Client ON Orders.id_cl = Client.id_cl";
            conn.Open();
            MySqlCommand command = new MySqlCommand(s, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                st1.Add(Convert.ToString(reader[0]));
                st2.Add(Convert.ToString(reader[1]));
                st3.Add(Convert.ToString(reader[2]));
                st4.Add(Convert.ToString(reader[3]));
                st5.Add(Convert.ToString(reader[4]));
            }
            conn.Close();
        }
            
        #endregion

    }
}
