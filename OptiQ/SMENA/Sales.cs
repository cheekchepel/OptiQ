﻿using Npgsql;
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
    public partial class Sales : Form
    {




        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;
       
        public SqlCommand cmdoff;
        public SqlDataReader droff;

     


        // int schetelem = 0;


        closesess clclc = new closesess();



       public int crt_index = 0;

        public string id_cart ="";

        public Sales()
        {
            InitializeComponent();
            Program.ssssss = this;

        }

        public void Sales_Shown()
        {

            id_cart = "";
     
            addact();
            scet();
            if (Global.pra_showdohd == true)
            {
                panel2.Visible = true;
                seldoh(bunifuFlatButton1.Text);
            }
            else { panel2.Visible = false; }
          


        }











        public void scet() {
            int ket = 0;
            bunifuFlatButton1.Text = "0";
            bunifuFlatButton2.Text = "0";
            bunifuFlatButton3.Text = "0";
            bunifuFlatButton4.Text = "0";
            bunifuFlatButton5.Text = "0";
            bunifuFlatButton7.Text = "0";
            bunifuFlatButton8.Text = "0";

            while (grdt_kass.Rows.Count > ket)
            {
               // MessageBox.Show(""+(Convert.ToInt64(grdt_kass.Rows[ket].Cells[2].Value))+"    "+ grdt_kass.Rows[ket].Cells[2].Value);

                bunifuFlatButton1.Text = (Convert.ToInt64(bunifuFlatButton1.Text) + (Convert.ToInt64(grdt_kass.Rows[ket].Cells[2].Value))).ToString(); 


                if ((grdt_kass.Rows[ket].Cells[4].Value).ToString() == "Наличный")
                {


                    bunifuFlatButton2.Text = "" + (Convert.ToInt32(bunifuFlatButton2.Text) + Convert.ToInt32(grdt_kass.Rows[ket].Cells[2].Value));

                }
                if ((grdt_kass.Rows[ket].Cells[4].Value).ToString() == "Kaspi")
                {

                    bunifuFlatButton3.Text = "" + (Convert.ToInt32(bunifuFlatButton3.Text) + Convert.ToInt32(grdt_kass.Rows[ket].Cells[2].Value));


                }

                if ((grdt_kass.Rows[ket].Cells[4].Value).ToString() == "Безналичный")
                {


                    bunifuFlatButton4.Text = "" + (Convert.ToInt32(bunifuFlatButton4.Text) + Convert.ToInt32(grdt_kass.Rows[ket].Cells[2].Value));

                }
                if ((grdt_kass.Rows[ket].Cells[4].Value).ToString() == "В долг")
                {


                    bunifuFlatButton5.Text = "" + (Convert.ToInt32( bunifuFlatButton5.Text) + Convert.ToInt32(grdt_kass.Rows[ket].Cells[2].Value));

                }
                if ((grdt_kass.Rows[ket].Cells[4].Value).ToString() == "Kaspi RED")
                {


                    bunifuFlatButton8.Text = "" + (Convert.ToInt32(bunifuFlatButton8.Text) + Convert.ToInt32(grdt_kass.Rows[ket].Cells[2].Value));

                }




                ket++;







            }


        }




 




        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }



        public void addact()
        {
            // Int32 unixTimestamp = (Int32)(DateTime.Today.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            tovartut.Visible = false;
            bunifuFlatButton6.Visible = false;
            int ket = 0;
            grdt_kass.Rows.Clear();
            if (Global.date_open_sesions != 0)
            {
                conoff.Close(); 
                conoff.Open();
                sqloff = "select crt,cbt_sum,date,cbt_by_how,(SELECT COUNT(*) as count FROM sales WHERE sl_crt_id=crt  and sl_skidon!='0'),cbt_skidon from crt LEFT JOIN cartbuymet ON crt=cbt_cart_id where date>" + Global.date_open_sesions + "and (crt LIKE '%" + id_cart + "%') ORDER BY date desc";

                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                while (droff.Read())
                {
                    grdt_kass.Rows.Add(ket+1, droff[0], droff[1], UnixTimeStampToDateTime(Convert.ToDouble(droff[2])), droff[3],droff[5]);
                    ket++;

                    if (droff[3].ToString() == "Возврат")
                    {
                        grdt_kass.Rows[grdt_kass.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(240, 71, 71);
                    }
                    else {
                        if (droff[4].ToString()!= "0"|| droff[5].ToString() != "0") {
                            grdt_kass.Rows[grdt_kass.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(255, 179, 0);

                        }
                    }

                }
                conoff.Close();
            }
            grdt_kass.Height = 40 + (30 * ket);
            if (grdt_kass.Height > Global.y) { grdt_kass.Height = Global.y; }
            grdt_kass.ClearSelection();



        }



    






        private void Sales_Load(object sender, EventArgs e)
        {
            Potoki.cari();
         


        }

        private void exit_but_Click(object sender, EventArgs e)
        {
          

            Potoki.zakroi = false;
            
            Application.Exit();
        }

        private void Opensesess_Click(object sender, EventArgs e)
        {

            long date1 = DateTimeOffset.Now.ToUnixTimeSeconds();

            conoff.Open();
            sqloff = "INSERT INTO ksas(id_kassir_ksas,date_start_ksas,date_end_ksas,id_mg_ksas)VALUES(" + Global.IDuser + "," + date1 + ",0," + Global.IDmagaz + ");";
            sqloff+= "INSERT INTO productoff(pr_text)VALUES(N'"+ sqloff + "')";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            droff.Read();
            conoff.Close();
            Program.log.poisc_sessii_and_view();
            addact();
        }

        private void Closesess_Click(object sender, EventArgs e)
        {
            conoff.Open();
            sqloff = "select date_end_ksas from ksas where id_kassir_ksas=" + Global.IDuser + "and date_end_ksas =0";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();


            if (Global.date_open_sesions!=0)
            {

                clclc.Show();

            }
            else
            {
                Program.msg.Size = new Size(320, 100);
                Program.msg.Message.Text = "Смена не открыта"; Program.msg.Show();
                Closesess.Visible = false;
            }

            conoff.Close();
        }

        private void grdt_kass_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (grdt_kass.Rows.Count > 0)
            {
                crt_index = grdt_kass.CurrentRow.Index;
                vzat_num_cherk();
                addact();
                tovar_select();
            }



        }





        public void vzat_num_cherk() {


            if (crt_index < 0)
            {


                id_cart = "";


            }
            else {

                id_cart = (grdt_kass.Rows[crt_index].Cells[1].Value).ToString();

            }
        
        
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            
            id_cart = "";
            addact();
        }




        public void tovar_select() {

            tovartut.Visible = true;
            bunifuFlatButton6.Visible = true;
            int ket = 0;
            tovartut.Rows.Clear();
            if (Global.date_open_sesions != 0)
            {
                conoff.Close();
                conoff.Open();
                sqloff = "select sl_name,sl_cena,sl_pieces,sl_skidon  from sales where sl_crt_id=" + id_cart;

                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                while (droff.Read())
                {
                    tovartut.Rows.Add(ket + 1, droff[0], droff[1],droff[2], droff[3]);
                    ket++;

                    if (Convert.ToInt32(droff[1]) < 0)
                    {
                        tovartut.Rows[tovartut.Rows.Count-1].DefaultCellStyle.BackColor = Color.FromArgb(240, 71, 71);
                    }
                    else
                    {
                        if (droff[3].ToString() != "0")
                        {
                            tovartut.Rows[tovartut.Rows.Count-1].DefaultCellStyle.BackColor = Color.FromArgb(255, 179, 0);

                        }
                    }

                }
                conoff.Close();
            }

            tovartut.MaximumSize =new Size(grdt_kass.Width-125, 35 + (30 * ket));
            tovartut.Size = new Size(grdt_kass.Width - 125, 35 + (30 * ket));
            tovartut.ClearSelection();

        }

        void seldoh(string obh) {

            long dl = 0;

            conoff.Close();
            conoff.Open();
            sqloff = "select sl_prihod  from sales ";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            while (droff.Read()) {

                dl +=Convert.ToInt64( droff[0]);
            
            }
            conoff.Close();

            bunifuFlatButton7.Text = (Convert.ToInt64(obh) - dl).ToString();

        }

   
    }
}
