using Npgsql;
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
    public partial class fastaddprovid : Form
    {
        public fastaddprovid()
        {
            InitializeComponent();
            Program.fstpr = this;
        }


        public SqlConnection con = new SqlConnection(Global.conectsql);


        public string sql;
        public SqlCommand cmd;
        public SqlDataReader dr;




        private void fastaddprovid_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            string opa = "'";

            if (number == '$' || number == '%' || number == ',' || number == Convert.ToChar(opa)) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void fastaddprovid_Shown(object sender, EventArgs e)
        {
            text3.Text = null;
           
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(text3.Text))
            {
                try { 
                con.Close();
                con.Open();
                sql = "INSERT INTO myprov(mp_mg_id,mp_name,mp_test,mp_id_off)VALUES(" + Global.IDmagaz + ",N'" + text3.Text + "','false',"+Global.IDuser+""+ DateTimeOffset.Now.ToUnixTimeMilliseconds() + ");";

                sql += "INSERT INTO productoff(pr_text)VALUES(N'"+sql.Replace("'", "$") + "')";

                cmd = new SqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                con.Close();
                Program.addprd.text6.Items.Add(text3.Text);
                Program.addprd.text6.Text = text3.Text.ToString();
                Program.zakup.text6.Items.Add(text3.Text);
                Program.zakup.text6.Text = text3.Text.ToString();
                this.Close();
                }
                catch (NpgsqlException)
                {
                    this.Close();
                    Program.msg.Message.Text = "Необходимо интернет подключение";
                    Program.msg.Width = 450;
                    Program.msg.Show();
                }
            }
        }
    }
}
