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
    public partial class Sales : Form
    {




        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;
       
        public SqlCommand cmdoff;
        public SqlDataReader droff;

     


        // int schetelem = 0;


        closesess clclc = new closesess();

        public double sum_kom = 0;

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
                seldoh();
            }
            else { panel2.Visible = false; }
          


        }











        public void scet() {
            int ket = 0;
            sum_kom = 0;
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

                double cena = Convert.ToDouble(grdt_kass.Rows[ket].Cells[2].Value);
                double kom = Convert.ToDouble(grdt_kass.Rows[ket].Cells[6].Value);
                if (kom != 0) { sum_kom += cena * (1-kom / 100); }
                else { sum_kom += cena; }
                

                bunifuFlatButton1.Text =(Convert.ToInt64(bunifuFlatButton1.Text) + (Convert.ToInt64(grdt_kass.Rows[ket].Cells[2].Value))).ToString(); 


                if ((grdt_kass.Rows[ket].Cells[4].Value).ToString() == "Наличный"|| (grdt_kass.Rows[ket].Cells[4].Value).ToString() == "Возврат")
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
                sqloff = "select crt_off_id,cbt_sum,crt_date,cbt_by_how,(SELECT COUNT(*) as count FROM sales_pro WHERE sl_crt_id=crt_off_id  and sl_skidon!='0'),cbt_skidon,cbt_by_komuis from cart LEFT JOIN cartbuymet ON crt_off_id=cbt_cart_id where crt_mg_id="+Global.IDmagaz+" and crt_date>" + Global.date_open_sesions + "and (CAST(crt_off_id as CHAR) LIKE '%" + id_cart + "%') ORDER BY crt_date desc";

                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                while (droff.Read())
                {
                    grdt_kass.Rows.Add(ket+1, droff[0], droff[1], UnixTimeStampToDateTime(Convert.ToDouble(droff[2])), droff[3],droff[5],droff[6]);
                    ket++;

                    if (droff[3].ToString() == "Возврат")
                    {
                        grdt_kass.Rows[grdt_kass.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(240, 71, 71);
                    }
                    else {
                        if (droff[4].ToString()!= "0"|| (droff[5].ToString() != "0" && droff[5].ToString() != "") ) {
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
            clclc.shtoct = 1;
            Program.main.backblakshow();
            clclc.ShowDialog();
           


        }

        private void Closesess_Click(object sender, EventArgs e)
        {
            conoff.Open();
            sqloff = "select date_end_ksas from ksas where id_kassir_ksas=" + Global.IDuser + "and date_end_ksas =0";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();


            if (Global.date_open_sesions!=0)
            {
                clclc.shtoct = 0;
                Program.main.backblakshow();
                clclc.ShowDialog();
              

            }
            else
            {

                Closesess.Visible = false;
                Program.msg.uvedomlrnie("Смена не открыта", 3); 
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
                sqloff = "select sl_name,sl_cena,sl_pieces,sl_skidon from sales_pro where sl_crt_id=" + id_cart;

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

        void seldoh() {

            bunifuFlatButton7.Text = "0";

            long dl = 0;
            if (Global.date_open_sesions > 0)
            {
                conoff.Close();
                conoff.Open();
                sqloff = "select sl_prihod  from sales_pro LEFT JOIN cart ON sl_crt_id=crt_off_id where crt_mg_id="+Global.IDmagaz+" and crt_date >" + Global.date_open_sesions;
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                while (droff.Read())
                {

                    dl += Convert.ToInt64(droff[0]);
                   // MessageBox.Show(sum_kom + "-" + dl);
                }

                conoff.Close();
                bunifuFlatButton7.Text = (Convert.ToInt64(sum_kom) - dl).ToString();
            }

        }

   
    }
}
