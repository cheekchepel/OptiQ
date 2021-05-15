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
    public partial class Razmer : UserControl
    {
        public Razmer()
        {
            InitializeComponent();
        }
        public SqlConnection conr = new SqlConnection(Global.conectsql);
        public string sqlr;
        public SqlCommand cmdr;
        public SqlDataReader drr;






        public long rz_id=0;
        public long pr_kod = 0;


        private void textopt_Enter(object sender, EventArgs e)
        {
            shjowkeyboard5.Visible = true;
        }

        private void textopt_Leave(object sender, EventArgs e)
        {
            shjowkeyboard5.Visible = false;
        }

        public int id; 

        public int ID
        {
            get { return id; }
            set { id = value; add(); }

        }






        private void add()
        {

            if (Program.addprd.dtSales.Rows.Count > id)
            {

                pr_kod = Convert.ToInt64(Program.addprd.dtSales.Rows[id][0]);
                rz_id = Convert.ToInt64("0"+Program.addprd.dtSales.Rows[id][1]);
                textname.Text = Program.addprd.dtSales.Rows[id][2].ToString(); 
                textpie.Text = Program.addprd.dtSales.Rows[id][3].ToString().Replace(",",".");

                this.Visible = true;
                delete.Visible = true;
                plus.Visible = false;
                textname.Enabled = true;
            }
            else { this.Visible = false; }

        }




        public void delite() {

            if (rz_id != 0)
            {
                Global.basever++;

                conr.Close();
                conr.Open();
                
                sqlr = "delete from razmer_pro WHERE rz_id =" + rz_id + ";";

                sqlr += "INSERT INTO productoff(pr_text)VALUES(N'" + (Global.versia + sqlr).Replace("'", "$") + "')";

                cmdr = new SqlCommand(sqlr, conr);
                drr = cmdr.ExecuteReader();
                drr.Read();
                conr.Close();
                
            }
            Program.addprd.dtSales.Rows.RemoveAt(id);
            Program.addprd.viewcell();
        }
        public void  insert_update() {

            if (!String.IsNullOrWhiteSpace(textname.Text) && !String.IsNullOrWhiteSpace(textpie.Text))
            {
                Global.basever++;
                if (rz_id == 0)
                {
                    conr.Close();
                    conr.Open();

                    sqlr = "INSERT INTO razmer_pro(rz_id,rz_pr_kod,rz_mg_id,rz_name,rz_pies)VALUES("+Global.IDuser+""+ DateTimeOffset.Now.ToUnixTimeMilliseconds() + "," + Program.addprd.text1.Text + "," + Global.IDmagaz + ",'" + textname.Text + "'," + textpie.Text.Replace(",", ".") + ");";
                    sqlr += "INSERT INTO productoff(pr_text)VALUES(N'" + (Global.versia + sqlr).Replace("'", "$") + "')";
                    cmdr = new SqlCommand(sqlr, conr);
                    drr = cmdr.ExecuteReader();
                    drr.Read();
                    conr.Close();

                }
                else
                {
                    conr.Close();
                    conr.Open();

                    sqlr = "UPDATE razmer_pro Set rz_pr_kod=" + Program.addprd.text1.Text + ", rz_name='" + textname.Text + "',rz_pies=" + textpie.Text.Replace(",", ".") + " WHERE rz_id=" + rz_id + "and rz_mg_id=" + Global.IDmagaz + ";";
                    sqlr += "INSERT INTO productoff(pr_text)VALUES(N'" + (Global.versia + sqlr).Replace("'", "$") + "')";
                    cmdr = new SqlCommand(sqlr, conr);
                    drr = cmdr.ExecuteReader();
                    drr.Read();
                    conr.Close();
                   
                }
            }


        }

        private void textpie_KeyPress(object sender, KeyPressEventArgs e)
        {
            int indexOfChar = textpie.Text.IndexOf('.');

            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != '.') // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
            else
            {

                if (number == '.' && indexOfChar != -1) { e.Handled = true; }

            }
        }

        private void textname_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char number = e.KeyChar;
            //string opa = "'";

            //if (number == '$' || number == '%' || number == ',' || number == Convert.ToChar(opa)) // цифры, клавиша BackSpace и запятая
            //{
            //    e.Handled = true;
            //}
        }

        public void zagruzka(string kod,string id,string name,string pies) {
            
            

        }

        private void textname_OnValueChanged(object sender, EventArgs e)
        {
            Program.addprd.dtSales.Rows[id][2] = textname.Text;

        }

        private void delete_Click(object sender, EventArgs e)
        {
            delite();
        }

        private void plus_Click(object sender, EventArgs e)
        {
            Program.addprd.dtSales.Rows.Add(0,0,"","");
            Program.addprd.viewcell();
        }

        private void textpie_OnValueChanged(object sender, EventArgs e)
        {
            Program.addprd.dtSales.Rows[id][3] = textpie.Text;
        }
    }

    }

