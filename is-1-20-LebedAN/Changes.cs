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
    public partial class Changes : MetroFramework.Forms.MetroForm
    {
        public Changes()
        {
            InitializeComponent();
        }
        Requests.Requests f2 = new Requests.Requests();

        private void Changes_Load(object sender, EventArgs e)
        {
            f2.con();
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
    }
}
