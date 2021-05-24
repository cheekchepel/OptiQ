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
    public partial class metodopl : UserControl
    {
        public metodopl()
        {
            InitializeComponent();
        }
        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;

        private void nal_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void beznal_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void kaspi_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void kaspired_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void nal_TextChanged(object sender, EventArgs e)
        {
            nal.Text = Convert.ToInt32("0" + nal.Text).ToString();
            if (Convert.ToInt32("0" + nal.Text) > 100) {
                nal.Text = "100";
            }
        }

        private void beznal_TextChanged(object sender, EventArgs e)
        {
            beznal.Text = Convert.ToInt32("0" + beznal.Text).ToString();
            if (Convert.ToInt32("0" + beznal.Text) > 100)
            {
                beznal.Text = "100";
            }
        }

        private void kaspi_TextChanged(object sender, EventArgs e)
        {
            kaspi.Text = Convert.ToInt32("0" + kaspi.Text).ToString();
            if (Convert.ToInt32("0" + kaspi.Text) > 100)
            {
                kaspi.Text = "100";
            }
        }

        private void kaspired_TextChanged(object sender, EventArgs e)
        {
            kaspired.Text = Convert.ToInt32("0" + kaspired.Text).ToString();
            if (Convert.ToInt32("0" + kaspired.Text) > 100)
            {
                kaspired.Text = "100";
            }
        }


        public void select() {

            con.Close();
            con.Open();
            sql = $"select nalic,beznalic,kaspi,kaspired from methodsetings where mg_id={Global.IDmagaz};";
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                int b = 0;
                int k = 0;
                int r = 0;
                


                if (Convert.ToInt32(dr[1]) < 0) { bunifuiOSSwitch2.Value = false; b = 101; } else { bunifuiOSSwitch2.Value = true; }
                if (Convert.ToInt32(dr[2]) < 0) { bunifuiOSSwitch3.Value = false; k = 101; } else { bunifuiOSSwitch3.Value = true; }
                if (Convert.ToInt32(dr[3]) < 0) { bunifuiOSSwitch4.Value = false; r = 101; } else { bunifuiOSSwitch4.Value = true; }


                nal.Text = Math.Abs(Convert.ToInt32(dr[0])).ToString();
                beznal.Text = Math.Abs(Convert.ToInt32(dr[1])+b).ToString();
                kaspi.Text = Math.Abs(Convert.ToInt32(dr[2])+k).ToString();
                kaspired.Text = Math.Abs(Convert.ToInt32(dr[3])+r).ToString();

            }
            con.Close();


        }



        private void bunifuiOSSwitch2_OnValueChange(object sender, EventArgs e)
        {
            beznal.Enabled = bunifuiOSSwitch2.Value;
        }

        private void bunifuiOSSwitch3_OnValueChange(object sender, EventArgs e)
        {
            kaspi.Enabled = bunifuiOSSwitch3.Value;
        }

        private void bunifuiOSSwitch4_OnValueChange(object sender, EventArgs e)
        {
            kaspired.Enabled = bunifuiOSSwitch4.Value;
        }

        public void save() {

            string b = "";
            string k = "";
            string r = "";

 
            if (bunifuiOSSwitch2.Value == false) { b = "-101"; } 
            if (bunifuiOSSwitch3.Value == false) { k = "-101"; } 
            if (bunifuiOSSwitch4.Value == false) { r = "-101"; } 

            con.Close();
            con.Open();
            sql = $"UPDATE methodsetings SET nalic={nal.Text},beznalic={beznal.Text+b},kaspi={kaspi.Text+k},kaspired={kaspired.Text+r} WHERE mg_id = {Global.IDmagaz};";
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();
            Program.msg.uvedomlrnie("Данные успешно изменены", 1);

        }

        private void bunifuFlatButton15_Click(object sender, EventArgs e)
        {
            save();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            select();
        }

        private void metodopl_Load(object sender, EventArgs e)
        {
            select();
        }
    }
}
