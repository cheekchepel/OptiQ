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
using OptiQ.TOVAR.PRIHOD;
using OptiQ.kassa;

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

        prihodcell[] sel = new prihodcell[13];

        public int kolichestvo=0;


        prihodpostav prihpos = new prihodpostav();

        public blackback blackback = new blackback();

        // int sum = 0;
        public int count = 0;

        int raz = 0;


        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            blackback.Show();

            Program.fstpr.ShowDialog();


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

            textBox3.Visible = Global.pra_showprih;
            textBox5.Visible = Global.pra_showprih;
            this.Width = textBox7.Left + 200;

            this.Left = (Global.x - this.Width) / 2;

            while (raz < 13) {

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
            sql = "select kod,name,cena_co,cena_ca,cena_opt,rz_id,kol,(SELECT COUNT(*) FROM prihod) from prihod order by Id desc OFFSET " +Convert.ToInt32(bunifuVTrackbar1.Value)+ " ROWS FETCH NEXT 12 ROWS ONLY";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            while (kolichestvo < 12)
            {

                 while (kolichestvo < 12 && dr.Read()) {

                    sel[kolichestvo].zagruz(Convert.ToInt64(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), Convert.ToInt64(dr[5]), Convert.ToDouble(dr[6]));
                    
                    kolichestvo++;

                    count = Convert.ToInt32(dr[7]) ;

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

                    if (bunifuVTrackbar1.Value == 0)
                    {

                        select();

                    }
                    bunifuVTrackbar1.Value = 0;
                    if (count > 12)
                    {
                        bunifuVTrackbar1.MaximumValue = (count - 11);
                        bunifuVTrackbar1.Visible = true;
                    }
                    else
                    {

                        bunifuVTrackbar1.Visible = false;

                    }
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
            if (count > 12)
            {
                bunifuVTrackbar1.MaximumValue = (count - 11);
                bunifuVTrackbar1.Visible = true;
            }
            else
            {

                bunifuVTrackbar1.Visible = false;

            }
            bunifuVTrackbar1.Value = 0;
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            string cart_id = Global.IDuser + "" + DateTimeOffset.Now.ToUnixTimeSeconds();
            string zapros=null;
            string zaprosoff = null;

            int min = 0;
            int max = 0;
            con.Close();
            con.Open();
            sql = "select kod,name,cena_co,cena_ca,cena_opt,rz_id,kol from prihod";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                
                zapros += "insert into postavproduct(pospro_id_postavki,pospro_kod,pospro_name,pospro_price_co,pospro_price_ca,pospro_rz_id,pospro_piec)" +
                    " VALUES ("+ cart_id + ","+dr[0]+",N'"+dr[1]+"',"+dr[2]+"," + dr[3] + "," + dr[5] + "," + dr[6].ToString().Replace(",",".") + ");";

                zaprosoff+= "UPDATE razmer_pro SET rz_pies=((select rz_pies from razmer_pro where rz_pr_kod=" + dr[0] + " and rz_id=" + dr[5] + ")+" + dr[6].ToString().Replace(",", ".") + ") where rz_pr_kod=" + dr[0]+" and rz_id="+dr[5]+ " and rz_mg_id="+Global.IDmagaz+";";

                zaprosoff+= "UPDATE product_pro SET pr_provid=N'"+text6.Text+ "',pr_prov_id=0+(select mp_id_off from myprov where mp_name=N'" + text6.Text + "' and mp_mg_id=" + Global.IDmagaz + " ORDER BY mp_id DESC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY) where pr_kod=" + dr[0] + " and pr_mg_id=" + Global.IDmagaz + ";";

                min += Convert.ToInt32(dr[2]);
                max += Convert.ToInt32(dr[3]);

            }

            con.Close();

            zapros += "insert into postavki(pos_kassir_id,pos_type,pos_sum_pri,pos_sum_sell,pos_name_prov,pos_mg_id,pos_date,pos_idshnik,pos_prov_id)" +
                " VALUES ("+Global.IDuser+",1,"+min+","+max+",'" +text6.Text+"',"+Global.IDmagaz+","+ DateTimeOffset.Now.ToUnixTimeSeconds() + ","+ cart_id + ",0+(select mp_id_off from myprov where mp_name=N'" + text6.Text + "' and mp_mg_id=" + Global.IDmagaz + " ORDER BY mp_id DESC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY));";



            con.Close();
            con.Open();
            sql = "delete from prihod;" + zaprosoff+"insert into productoff(pr_text) VALUES (N'"+ (zapros + zaprosoff).Replace("'","$") + Global.versia + "');";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();

            Program.main.backblakhide();
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuCustomDataGrid1.Height = 0;
            int idx = 0;

            if (bunifuCustomDataGrid1.Rows.Count > 0)
            {





                idx = bunifuCustomDataGrid1.CurrentRow.Index;

                kassa_pulus((bunifuCustomDataGrid1.Rows[idx].Cells[0].Value).ToString());


               







            }
        }

        private void bunifuVTrackbar1_ValueChanged(object sender, EventArgs e)
        {
            select();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            blackback.Show();           
            prihpos.ShowDialog();
           
        }

        public void prihpos_close() {

            prihpos.Close();
            blackback.Hide();
        }
    }
}
