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
        }
        public void num(int i)
        {
            test = i;
            number = test;
            lin = i;
            line = lin;
        }     

    }
}
