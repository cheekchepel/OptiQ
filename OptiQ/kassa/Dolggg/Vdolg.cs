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
    public partial class Vdolg : UserControl
    {
        public Vdolg()
        {
            InitializeComponent();
            Program.dlg = this;
        }


        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;
        public SqlCommand cmdoff;
        public SqlDataReader droff;

        public int index;

        

        public string usid;


        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            flowLayoutPanel3.Visible = false;
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            flowLayoutPanel3.Visible = true;
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text)&& textBox2.Text.Length==10)
            {
                string id_us = Global.IDuser+(DateTimeOffset.Now.ToUnixTimeSeconds()).ToString();
                Global.veriaprodaj++;
                conoff.Close();
                conoff.Open();
                sqloff = "INSERT INTO users_pro(us_mg_id,us_off_id,us_name,us_danie,us_summa,us_bonus,us_date)" +
                    "VALUES("+Global.IDmagaz+ ","+id_us+",N'" + textBox1.Text + "',7" + textBox2.Text + ",0,0," + DateTimeOffset.Now.ToUnixTimeSeconds() + ");";

                sqloff += "INSERT INTO productoff(pr_text)VALUES(N'"+Global.salever + sqloff.Replace("'", "$") + "');";
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                droff.Read();
                conoff.Close();


                flowLayoutPanel3.Visible = false;

                textBox4.Text = textBox1.Text;
                
            }
            

        }



        public void zagrizka() {
            usid = null;
            grdt_kass.Rows.Clear();

            conoff.Close();
            conoff.Open();
            sqloff = "select us_off_id,us_name,us_danie,us_bonus from users_pro where us_mg_id="+Global.IDmagaz+" and (LOWER(us_name) LIKE LOWER(N'%" + textBox4.Text + "%')) ";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            while (droff.Read()) {

                grdt_kass.Rows.Add(droff[0], droff[1],"+"+droff[2], droff[3]);
            
            }
            conoff.Close();

            grdt_kass.ClearSelection();
        }





        private void Vdolg_Load(object sender, EventArgs e)
        {
            zagrizka();
            flowLayoutPanel3.Visible = false;
            textBox4.Text = null;
            grdt_kass.ClearSelection();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            usid = null;
            zagrizka();
          
            grdt_kass.ClearSelection();
          
        }

        private void grdt_kass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //grdt_kass.ClearSelection();

            usid = null;

            if (grdt_kass.Rows.Count > 0)
            {
                index = grdt_kass.CurrentRow.Index;
                usid = (grdt_kass.Rows[index].Cells[0].Value).ToString();
                

                Program.oplati.viborusers(Convert.ToInt64(usid), grdt_kass.Rows[index].Cells[1].Value.ToString(), Convert.ToInt32(grdt_kass.Rows[index].Cells[3].Value));

                

                    Program.oplati.nav_clik();


                
                
                





            }
            else {
                usid = null;

            }
          
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox2.SelectionStart = textBox2.Text.Length;
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 10) {

                textBox2.Text= textBox2.Text.Remove(10);
                textBox2.SelectionStart = textBox2.Text.Length;
            }
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.Focus();
        }
    }
}
