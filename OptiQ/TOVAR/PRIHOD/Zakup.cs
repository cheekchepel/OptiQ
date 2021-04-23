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


       // int sum = 0;


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

                sel[raz] = new prihodcell{Visible=false,selcehk=false};

                flowLayoutPanel1.Controls.Add(sel[raz]);
          

                raz++;
            }


            clear();



        }




        public void select() {

            kolichestvo = 0;

            con.Close();
            con.Open();
            sql = "select kod,name,cena_co,cena_ca,cena_opt,rz_id,kol from prihod order by Id desc ";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            while (kolichestvo<50)
            {
             
                while (dr.Read()&& kolichestvo < 50)
                {

                    
                    sel[kolichestvo].zagruz(Convert.ToInt64(dr[0]),dr[1].ToString(),dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),Convert.ToInt64(dr[5]) , Convert.ToDouble(dr[6]));

                    kolichestvo++;
                }

                sel[kolichestvo].Visible = false;
                kolichestvo++;

            }
            con.Close();




        }











        public void kassa_pulus(string kod)
        {



            long res;
            bool isInt = Int64.TryParse(kod + "0", out res);


            if (!String.IsNullOrWhiteSpace(kod) && isInt == true)
            {





                con.Close();
                con.Open();
                sql = "select pr_kod from product_pro where pr_kod=" + kod;
                cmd = new SqlCommand(sql, con);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    sel[0].selcehk = false;
                    sel[0].add(Convert.ToInt64(kod));
                    textBox1.Text = null;
                    select();

                }
                else
                {

                    textBox1.Text = null;

                }
                con.Close();






            }



        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                kassa_pulus(textBox1.Text);

            }
        }

        private void Zakup_Shown(object sender, EventArgs e)
        {
            select();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            string cart_id = Global.IDuser + "" + DateTimeOffset.Now.ToUnixTimeSeconds();
            string zapros=null;
            string zaprosoff = null;

            int min = 0;

            con.Close();
            con.Open();
            sql = "select kod,name,cena_co,cena_ca,cena_opt,rz_id,kol from prihod";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                
                zapros += "insert into postavproduct(pospro_id_postavki,pospro_kod,pospro_name,pospro_price_co,pospro_price_ca,pospro_rz_id,pospro_piec)" +
                    " VALUES ("+ cart_id + ","+dr[0]+",N'"+dr[1]+"',"+dr[2]+"," + dr[3] + "," + dr[5] + "," + dr[6].ToString().Replace(",",".") + ");";

                zaprosoff+= "UPDATE razmer_pro SET rz_pies=((select rz_pies from razmer_pro where rz_pr_kod=" + dr[0] + " and rz_id=" + dr[5] + ")+" + dr[6].ToString().Replace(",", ".") + ") where rz_pr_kod=" + dr[0]+" and rz_id="+dr[5]+";";

                min += Convert.ToInt32(dr[2]);

            }

            con.Close();

            zapros += "insert into postavki(pos_kassir_id,pos_type,pos_sum_pri,pos_name_prov,pos_mg_id,pos_date,pos_idshnik)" +
                " VALUES ("+Global.IDuser+",1,"+min+",'"+text6.Text+"',"+Global.IDmagaz+","+ DateTimeOffset.Now.ToUnixTimeSeconds() + ","+ cart_id + ");";

            con.Close();
            con.Open();
            sql = "delete from prihod;" + zaprosoff+"insert into productoff(pr_text) VALUES (N'"+ (zapros + zaprosoff).Replace("'","$") + Global.versia + "');";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();

            select();

        }
    }
}
