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
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_19;database=is_1_20_st19_KURS;password=14313537;";
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
            id_cl.Clear();
            string c = "SELECT id_ta,Name_ta FROM tariff";
            MySqlCommand command = new MySqlCommand(c, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_cl.Add(Convert.ToString(reader[0]), Convert.ToString(reader[1]));
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

    }
}
