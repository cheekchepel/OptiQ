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

namespace OptiQ.kassa
{
    public partial class kategory : Form
    {
        public kategory()
        {
            InitializeComponent();
            Program.kotek = this; 
        }


        public DataTable dtSales1 = new DataTable();
        public DataTable dtSales2 = new DataTable();


        public SqlConnection conoff = new SqlConnection(Global.conectsql);
        public string sqloff;
        public SqlCommand cmdoff;
        public SqlDataReader droff;


        bool delet = false;


        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
           
        }

        int opa = 0;
        int raz = 0;
        int list = 0;
        public long uznat = 0;
       public int list2 = 0;

        katcell[] kc = new katcell[40];
        kattovcell[] ktc = new kattovcell[40];

        private void kategory_Load(object sender, EventArgs e)
        {
            delet = false;
            list = 0;
            list2 = 0;
            while (opa < 40)
            {

                kc[opa] = new katcell();
                kc[opa].Visible = false;
                flowLayoutPanel2.Controls.Add(kc[opa]);

                ktc[opa] = new kattovcell();
                ktc[opa].Visible = false;
                flowLayoutPanel3.Controls.Add(ktc[opa]);
                opa++;


            }

            if (raz == 0)
            {

                dtSales1.Columns.Add("kat_silka", typeof(long));
                dtSales1.Columns.Add("kat_name", typeof(string));

                dtSales2.Columns.Add("pr_kod", typeof(long));
                dtSales2.Columns.Add("pr_name", typeof(string));

                raz++;
            }

            flowLayoutPanel2.Enabled = true;
            flowLayoutPanel3.Enabled = true;

            flowLayoutPanel2.Visible = true;
            flowLayoutPanel4.Visible = false;
            bunifuFlatButton9.Visible = true;
            bunifuFlatButton10.Visible = false;
            bunifuFlatButton3.Visible = true;
            bunifuFlatButton1.Visible = false;
            katzagrsel();
           



        }



        public void tovarzagrsel(long nomerkateg)
        {
            uznat = nomerkateg;

            flowLayoutPanel3.Visible = false;
            dtSales2.Rows.Clear();

            conoff.Close();
            conoff.Open();
            sqloff = "select pr_kod,pr_name from product where pr_kateg="+ nomerkateg;
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            while (droff.Read())
            {

                dtSales2.Rows.Add(droff[0], droff[1]);

            }
            conoff.Close();

            
            viewtovar();





        }





        public void katzagrsel()
        {
            dtSales1.Rows.Clear();

            conoff.Close();
            conoff.Open();
            sqloff = "select kat_silka,kat_name from kateg";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            while (droff.Read())
            {

                dtSales1.Rows.Add(droff[0], droff[1]);

            }
            conoff.Close();
            viewkatcell();
        }

        private void kategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            string hopa = "'";

            if (number == '$' || number == '%' || number == ',' || number == Convert.ToChar(hopa)) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }




        public void viewkatcell()
        {


            for (int i = 0; i <40; i++)
            {
                if (i < dtSales1.Rows.Count)
                {
                    kc[i].ID = list + i;
                    kc[i]._picviw = delet;
                }
                else
                {
                    kc[i].Visible = false;
                }
            }

            flowLayoutPanel2.Visible = true;
        }




        public void viewtovar()
        {
           

            for (int i = 0; i < 40; i++)
            {
                if (i < dtSales2.Rows.Count)
                {
                    ktc[i].ID = list2 + i;
                    ktc[i]._picviw = delet;



                }
                else
                {
                    ktc[i].Visible = false;
                }
            }

            flowLayoutPanel3.Visible = true;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            okno1();
        }

     

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {


            this.Close();
            Program.main.backblakhide();
           
           
        }


        public void okno2() {


            flowLayoutPanel2.Visible = false;
            bunifuFlatButton3.Visible = false;

            bunifuFlatButton2.Visible = true;


            bunifuFlatButton1.Visible = true;

        }


        public void okno1()
        {


            flowLayoutPanel2.Visible = true;
            bunifuFlatButton3.Visible = true;

            bunifuFlatButton2.Visible = false;
          

            bunifuFlatButton1.Visible = false;

        }

      

        private void flowLayoutPanel2_Scroll(object sender, ScrollEventArgs e)
        {

          


            if (flowLayoutPanel2.VerticalScroll.Value > 220)
            {
                int cho = flowLayoutPanel2.VerticalScroll.Value - 220;
                list += 5;

                flowLayoutPanel2.VerticalScroll.Value = 110 + cho;
                viewkatcell();
            }
            else if (list != 0 && flowLayoutPanel2.VerticalScroll.Value < 110)
            {
                int cho = 110 - flowLayoutPanel2.VerticalScroll.Value;
                list -= 5;

                flowLayoutPanel2.VerticalScroll.Value = 220 - cho;
                viewkatcell();
            }



        }

        private void flowLayoutPanel3_Scroll(object sender, ScrollEventArgs e)
        {


            if (flowLayoutPanel3.VerticalScroll.Value > 220)
            {
                int cho = flowLayoutPanel3.VerticalScroll.Value - 220;
                list2 += 5;

                flowLayoutPanel3.VerticalScroll.Value = 110+cho;
                viewtovar();
            }
            else if (list2 != 0 && flowLayoutPanel3.VerticalScroll.Value < 110)
            {
                int cho = 110-flowLayoutPanel3.VerticalScroll.Value;
                list2 -= 5;

                flowLayoutPanel3.VerticalScroll.Value = 220-cho;
               viewtovar();
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            flowLayoutPanel4.Visible = true;
            textBox2.Text = null;
            tovarnadobavku();
            flowLayoutPanel3.Enabled = false;

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            flowLayoutPanel4.Visible = false;
            flowLayoutPanel2.Enabled = true;
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {


            if (String.IsNullOrWhiteSpace(textBox1.Text))
            { }
            else
            {



                conoff.Close();
                conoff.Open();
                sqloff = "INSERT INTO kateg(kat_mg_id,kat_name,kat_silka)VALUES("+Global.IDmagaz+",N'" + textBox1.Text + "',"+Global.IDuser+""+ DateTimeOffset.Now.ToUnixTimeSeconds() + ");";
                sqloff += "INSERT INTO productoff(pr_text)VALUES(N'"+ Global.versia + ""+sqloff.Replace("'","$")+"');";
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                droff.Read();
                conoff.Close();
                flowLayoutPanel4.Visible = false;


                katzagrsel();
                list = 0;
                viewkatcell();

           
                flowLayoutPanel2.Enabled = true;


            }



        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            flowLayoutPanel4.Visible = true;
            textBox1.Text = null;
            flowLayoutPanel2.Enabled = false;
        }

        private void bunifuFlatButton8_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanel4.Visible = false;
            flowLayoutPanel3.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            tovarnadobavku();
        }




        public void tovarnadobavku()
        {
            grdt_kass.Rows.Clear();

            conoff.Close();
            conoff.Open();
            sqloff = " SELECT pr_kod,pr_name FROM product WHERE (LOWER(pr_name) LIKE LOWER(N'%" + textBox2.Text + "%'))";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            while (droff.Read())
            {

                grdt_kass.Rows.Add(false, droff[1], Convert.ToInt64(droff[0]));

            }
            conoff.Close();

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            int a = 0;
            while (a < grdt_kass.Rows.Count) {

               
                if (Convert.ToBoolean(grdt_kass.Rows[a].Cells[0].Value) == true) {

                 



                    conoff.Close();
                    conoff.Open();
                    sqloff = "UPDATE product set pr_kateg =" + uznat + "WHERE pr_kod =" + Convert.ToInt64(grdt_kass.Rows[a].Cells[2].Value)+";";
                    sqloff += "INSERT INTO productoff(pr_text)VALUES(N'"+ Global.versia + "UPDATE product set pr_kateg = " + uznat + " WHERE pr_kod = " + Convert.ToInt64(grdt_kass.Rows[a].Cells[2].Value) + " and pr_mg_id=" + Global.IDmagaz + "')";
                    cmdoff = new SqlCommand(sqloff, conoff);
                    droff = cmdoff.ExecuteReader();
                    droff.Read();
                    conoff.Close();





                }

                a++;
            
            
            
            }
            flowLayoutPanel4.Visible = false;
            tovarzagrsel(uznat);
            flowLayoutPanel3.Enabled = true;


        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            delet = true;
            bunifuFlatButton9.Visible = false;
            bunifuFlatButton10.Visible = true;

            if (flowLayoutPanel2.Visible == true) { viewkatcell(); viewtovar(); }
            
            else { viewtovar(); viewkatcell(); flowLayoutPanel2.Visible = false; }
            
           


        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            delet = false;
            bunifuFlatButton9.Visible = true;
            bunifuFlatButton10.Visible = false;
            if (flowLayoutPanel2.Visible == true) { viewkatcell(); viewtovar(); }

            else { viewtovar(); viewkatcell(); flowLayoutPanel2.Visible = false; }
        }

        private void grdt_kass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdt_kass.Rows.Count > 0)
            {

                if (Convert.ToBoolean(grdt_kass.Rows[grdt_kass.CurrentRow.Index].Cells[0].Value) == false)
                {

                    grdt_kass.Rows[grdt_kass.CurrentRow.Index].Cells[0].Value = true;


                }
                else { grdt_kass.Rows[grdt_kass.CurrentRow.Index].Cells[0].Value = false; }

              

            }
        }
    }
}
