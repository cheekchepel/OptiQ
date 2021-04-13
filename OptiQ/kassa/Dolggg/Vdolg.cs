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
            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {
                string id_us = Global.IDuser+(Global.IDuser + DateTimeOffset.Now.ToUnixTimeSeconds()).ToString();

                conoff.Close();
                conoff.Open();
                sqloff = "INSERT INTO users(us_name,danie,summa,us_date,us_off_id_date)" +
                    "VALUES(N'" + textBox1.Text + "',N'" + textBox2.Text + "',0," + DateTimeOffset.Now.ToUnixTimeSeconds() + "," + id_us + ");";
                sqloff += "INSERT INTO productoff(pr_text)VALUES(N'"+Global.versia+"INSERT INTO users(us_mg_id,us_name,danie,summa,us_date,us_off_id_date)" +
                    "VALUES(" + Global.IDmagaz + ",N$" + textBox1.Text + "$,N$" + textBox2.Text + "$,0," + DateTimeOffset.Now.ToUnixTimeSeconds() + "," + id_us + ");');";
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
            sqloff = "select us_name,us_off_id_date from users where (LOWER(us_name) LIKE LOWER(N'%" + textBox4.Text + "%'))";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            while (droff.Read()) {

                grdt_kass.Rows.Add(droff[0], droff[1]);
            
            }
            conoff.Close();

            
        }





        private void Vdolg_Load(object sender, EventArgs e)
        {
            zagrizka();
            flowLayoutPanel3.Visible = false;
            textBox4.Text = null;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            usid = null;
            zagrizka();
          
            grdt_kass.ClearSelection();
            if (grdt_kass.Rows.Count > 0)
            {
                grdt_kass.Rows[0].Selected = true;
                index = grdt_kass.CurrentRow.Index;
                usid = (grdt_kass.Rows[index].Cells[1].Value).ToString();

            }
            else {
                usid = null;
            }
        }

        private void grdt_kass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            usid = null;

            if (grdt_kass.Rows.Count > 0)
            {
                index = grdt_kass.CurrentRow.Index;
                usid = (grdt_kass.Rows[index].Cells[1].Value).ToString();
                textBox4.Text = (grdt_kass.Rows[index].Cells[0].Value).ToString();


            }
            else {
                usid = null;

            }
          
        }
    }
}
