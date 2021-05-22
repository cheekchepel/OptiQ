using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptiQ.LOGIN
{
    public partial class logadm : Form
    {
        public logadm()
        {
            InitializeComponent();
        }

        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;

        private void login_button_Click(object sender, EventArgs e)
        {
            
            


        if (String.IsNullOrWhiteSpace(text_login.Text) || String.IsNullOrWhiteSpace(pass_text.Text))
        { Program.msg.uvedomlrnie("Заполните все поля", 3); return; }
            try
            {

                con.Close();
                con.Open();
                sql = "select mg_id,mg_pay,(" + DateTimeOffset.Now.ToUnixTimeSeconds() + "- mg_pay) from magaz where mg_us_login='" + text_login.Text + "' and mg_us_pass='" + Program.log.GetHash(pass_text.Text) + "'";
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.Close();
                    Global.IDmagaz = Convert.ToInt32(dr[0]);
                    Global.mg_pay = Convert.ToInt64(dr[1]);
                    Global.mg_pay_raznica = Convert.ToInt32(dr[2]);
                    Program.main.glavnaya.Visible = true;
                    Program.zakup.blackback.Hide();
                    Program.main.logadministartoe.Visible = false;
                    Program.main.mag_show();
                    con.Close();

                   

                }
                else { Program.msg.uvedomlrnie("Неверный логин или пароль", 2); return; }
                con.Close();
            }
            catch { Program.msg.uvedomlrnie("Необходимо интернет подключение", 3); return; }
                    


        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.zakup.blackback.Hide();
        }

        private void logadm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
        }
    }
}
