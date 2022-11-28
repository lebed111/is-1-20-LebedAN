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

        public void con()
        {
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_19;database=is_1_20_st19_KURS;password=14313537;";
            conn = new MySqlConnection(connStr);
            if(conn == null)
            {
                string connStr1 = "server=10.90.12.110;port=33333;user=st_1_20_19;database=is_1_20_st19_KURS;password=14313537;";
                conn = new MySqlConnection(connStr1);
            }
        }
      //public void BDclint()
      //{
      //     List<string>[] Select()
      //    {
      //        conn.Open();
      //        string clint = "SELECT * FROM Client;";
      //
      //        List<string>[] list = new List<string>[3];
      //
      //        list[0] = new List<string>();
      //        list[1] = new List<string>();
      //        list[2] = new List<string>();
      //
      //        MySqlCommand all = new MySqlCommand(clint, conn);
      //
      //        MySqlDataReader reader = all.ExecuteReader();
      //        while (reader.Read())
      //        {
      //            list[0].Add(reader[0].ToString());
      //            list[1].Add(reader[1].ToString());
      //            list[2].Add(reader[2].ToString());
      //        }
      //        conn.Close();
      //        return list;
      //    }
      //    
      //}

    }
}
