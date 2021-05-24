using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptiQ
{
    public partial class Poderjka : Form
    {
        public Poderjka()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection(Global.conectsql);

        public string sql;
        public SqlCommand cmd;
        public SqlDataReader dr;

        private void Poderjka_Shown(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Height = ok.Top + 50;
        }

        private void Poderjka_Load(object sender, EventArgs e)
        {

            con.Close();
            con.Open();
            sql = "select tex_num from kassirmagaz;";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                num.Text = "+" + dr[0];
                groupBox1.Visible = true;
            }
            else
            {

                groupBox1.Visible = false;

            }
            con.Close();

        }

        private void ok_Click(object sender, EventArgs e)
        {
            Program.zakup.blackback.Hide();
            this.Close();
        }
    }
}
