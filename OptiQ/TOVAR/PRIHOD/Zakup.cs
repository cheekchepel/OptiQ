using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OptiQ
{
    public partial class Zakup : Form
    {
        public Zakup()
        {
            InitializeComponent();
            Program.zakup = this;
        }

        public SqlConnection con = new SqlConnection(Global.conectsql);

        public int chto =1;
        public string nactoumnoju = "0";

        public string sql;
        public SqlCommand cmd;
        public SqlDataReader dr;

        prihodcell[] sel = new prihodcell[50];

        public int kolichestvo=0;


        int sum = 0;


        int raz = 0;


        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {


        }




        public void clear()
        {

            text6.Items.Clear();
            text6.Items.Add("Нет");
           
           
                con.Close();
                con.Open();
                sql = "select mp_name from myprov where mp_mg_id = " + Global.IDmagaz;
                cmd = new SqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    text6.Items.Add(dr[0]);

                }
                con.Close();
            text6.SelectedIndex = 0;
          
        }

        private void close_Click(object sender, EventArgs e)
        {
            Program.main.backblakhide();
            this.Close();
        }



        private void Zakup_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            string opa = "'";

            if (number == '$' || number == '%' || number == ',' || number == Convert.ToChar(opa)) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void Zakup_Load(object sender, EventArgs e)
        {
            //panel8.Visible = Global.pra_showprih;
            // cenaco.Visible = Global.pra_showprih;

            while (raz < 50) {

                sel[raz] = new prihodcell {Visible=false}; 

                raz++;
            }


            clear();



        }




        public void select() {

            kolichestvo = 0;

            con.Close();
            con.Open();
            sql = "select kod,name,cena_co,cena_ca,cena_opt,rz_id,rz_id,kol from prihod order by desc";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            while (kolichestvo<50)
            {

                while (dr.Read())
                {

                    sel[kolichestvo].zagruz(Convert.ToInt64(dr[0]),dr[1].ToString(),dr[3].ToString(), dr[4].ToString(), dr[5].ToString(),Convert.ToInt64(dr[6]) , Convert.ToDouble(dr[7]));

                    kolichestvo++;
                }

                sel[kolichestvo].Visible = false;
                kolichestvo++;

            }
            con.Close();




        }











        public void kassa_pulus(long rz_id, string kod)
        {



            long res;
            bool isInt = Int64.TryParse(kod + "0", out res);


            if (!String.IsNullOrWhiteSpace(kod) && isInt == true)
            {





                conoff.Close();
                conoff.Open();
                sqloff = "select pr_kod,pr_name,pr_price_co,pr_price_ca,pr_optom from product_pro where  pr_kod=" + kod;
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();

                if (droff.Read())
                {

                    select(Convert.ToInt64(droff[0]), droff[1].ToString(), Convert.ToInt32(droff[2]), Convert.ToInt32(droff[3]), Convert.ToInt32(droff[4]), rz_id);


                }
                else
                {
                    if (kod.Length == 13)
                    {
                        pisc_plu(kod.Remove(12).Remove(0, 2));
                    }
                    else
                    {
                        conoff.Close();
                        add.ID = kod;
                        Program.main.backblakshow();
                        add.ShowDialog();

                    }


                }
                conoff.Close();





            }



        }











    }
}
