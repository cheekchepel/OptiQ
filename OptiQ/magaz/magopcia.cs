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

namespace OptiQ.magaz
{
    public partial class magopcia : UserControl
    {
        public magopcia()
        {
            InitializeComponent();
        }


        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;



        public void select() {

            con.Close();
            con.Open();
            sql = $"select ns_maxskidnactov,ns_maxskidnacitog,ns_maxbonus,ns_maxbonusogran,ns_ojidanie from nastroiki where ns_mg_id ={Global.IDmagaz};";
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                maxtov.Text = dr[0].ToString();
                maxobsh.Text = dr[1].ToString();
                maxbon.Text = dr[2].ToString();
                maxbonogran.Text = dr[3].ToString();
                bezdei.Text = dr[4].ToString();


            }
            con.Close();



        }

        public void save() { 
        

                con.Close();
                con.Open();
                sql = $"UPDATE nastroiki SET ns_maxskidnactov ={maxtov.Text}, ns_maxskidnacitog ={maxobsh.Text} , ns_maxbonus ={maxbon.Text}, ns_maxbonusogran ={maxbonogran.Text}, ns_ojidanie ={bezdei.Text} WHERE ns_mg_id ={Global.IDmagaz};";
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                con.Close();
                Program.msg.uvedomlrnie("Данные успешно изменены", 1);


        }

        private void maxtov_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void maxobsh_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void maxbon_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void maxbonogran_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void bezdei_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void maxtov_TextChanged(object sender, EventArgs e)
        {
            maxtov.Text = Convert.ToInt32(maxtov.Text).ToString();
            if (Convert.ToInt32(maxtov.Text) > 100) { maxtov.Text = "100"; }
        }

        private void maxobsh_TextChanged(object sender, EventArgs e)
        {
            maxobsh.Text = Convert.ToInt32(maxobsh.Text).ToString();
            if (Convert.ToInt32(maxobsh.Text) > 100) { maxobsh.Text = "100"; }
        }

        private void maxbon_TextChanged(object sender, EventArgs e)
        {
            maxbon.Text = Convert.ToInt32(maxbon.Text).ToString();
            if (Convert.ToInt32(maxbon.Text) > 100) { maxbon.Text = "100"; }
        }

        private void maxbonogran_TextChanged(object sender, EventArgs e)
        {
            maxbonogran.Text = Convert.ToInt32(maxbonogran.Text).ToString();
            if (Convert.ToInt32(maxbonogran.Text) > 100) { maxbonogran.Text = "100"; }
        }

        private void bezdei_TextChanged(object sender, EventArgs e)
        {
            bezdei.Text = Convert.ToInt32(bezdei.Text).ToString();

        }

        private void bunifuFlatButton15_Click(object sender, EventArgs e)
        {
            save();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            select();
        }

        private void magsetings_Load(object sender, EventArgs e)
        {
            select();
        }
    }
}
