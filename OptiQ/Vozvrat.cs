﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace OptiQ
{
    public partial class Vozvrat : Form
    {
        public Vozvrat()
        {
            InitializeComponent();
        }


        private string INFO = "";




        public string seleoffproduct;
        private string TOVAR = "";
        private string OVAR = "";
        private string Infoend = "";
        private string itog = "";
        private string itog2 = "";

        Image img;
        Point imga = new Point(75, -50);

        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;
        public string offup;
        public string offdell;
        public string offcard;
        public string method;
        public SqlCommand cmdoff;
        public SqlDataReader droff;
        long numchek = 0;
        int pometka = 0;

        private void Vozvrat_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Global.x - this.Width, 0); ;
            this.Height = Global.y + 40;

            grdt_kass.Rows.Clear();
            label4.Visible = false;
            bunifuFlatButton16.Visible = false;
            bunifuFlatButton1.Text ="";
            textBox2.Text = null;
            textBox2.Focus();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Program.main.backblakhide();
            this.Close();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                kassa_pulus();
                
            }
        }

        private void Vozvrat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8&& number!=(char)Keys.Enter)
            {
                e.Handled = true;
            }
        }



        public void kassa_pulus()
        {
            grdt_kass.Rows.Clear();

            int schet = 0;

            string obshskid = "";
            numchek = 0;

            


            if (!String.IsNullOrWhiteSpace(textBox2.Text))
            {




          
                conoff.Close();
                conoff.Open();
                sqloff = "select sl_kod,sl_name,sl_cena,sl_prihod,sl_pieces,sl_skidon,cbt_skidon,sl_crt_id from vozvrat where sl_crt_id=" + textBox2.Text;
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();

                while (droff.Read())
                {
                  

                    numchek =Convert.ToInt64( droff[7]);
                    obshskid = droff[6].ToString();
                    grdt_kass.Rows.Add(false, droff[0], droff[1], droff[2], droff[3], droff[4], droff[5] , 0, 0);

                    schet = grdt_kass.Rows.Count-1;

                    double cena = Convert.ToDouble(grdt_kass.Rows[schet].Cells[3].Value);
                    double kol = Convert.ToDouble(grdt_kass.Rows[schet].Cells[5].Value);
                    string skidka_str = Convert.ToString(grdt_kass.Rows[schet].Cells[6].Value);

                    if (skidka_str == "0")
                        grdt_kass.Rows[schet].Cells[7].Value = cena * kol;
                    else if (skidka_str.Length > 0 && skidka_str[skidka_str.Length - 1] == '%')
                    {
                        double skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 1));
                        grdt_kass.Rows[schet].Cells[7].Value = (cena * kol) * (1 + skidka / 100);
                    }
                    else if (skidka_str.Length > 0 && skidka_str[skidka_str.Length - 1] == '.')
                    {
                        double skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 4));
                        grdt_kass.Rows[schet].Cells[7].Value = (cena + skidka) * kol;
                    }
                   grdt_kass.Rows[schet].Cells[7].Value = Convert.ToInt64(grdt_kass.Rows[schet].Cells[7].Value);
                    grdt_kass.Rows[schet].Cells[8].Value = Convert.ToDouble(grdt_kass.Rows[schet].Cells[4].Value) * Convert.ToDouble(grdt_kass.Rows[schet].Cells[5].Value);


                   
                   


                }
                conoff.Close();
                bunifuFlatButton16.Text = obshskid;
                summa();

            }





        }


        public void summa()
        {
            label4.Visible = false;
            bunifuFlatButton16.Visible = false;

            long sum = 0;
            long min = 0;
            int tik = 0;
            pometka=0;
            bunifuFlatButton1.Text = "";
            while (tik < grdt_kass.Rows.Count )
            {
                if (Convert.ToBoolean(grdt_kass.Rows[tik].Cells[0].Value) == true)
                
                {

                    sum += Convert.ToInt64(grdt_kass.Rows[tik].Cells[7].Value);
                    bunifuFlatButton1.Text = sum.ToString();

                    min += Convert.ToInt64(grdt_kass.Rows[tik].Cells[8].Value);
                    label3.Text = min.ToString();
                    pometka++;
                    
                }
                tik++;


            }
            if ((bunifuFlatButton16.Text.Length > 2 ) && bunifuFlatButton1.Text != "")
            {
               
                label4.Visible = true;
                bunifuFlatButton16.Visible = true;
                long new_sum = sum;
                string skidka_str = bunifuFlatButton16.Text;
                if (skidka_str[0] == '+')
                {
                    label4.Text = "Наценка";
                }
                else if(skidka_str[0] == '-')
                {
                    label4.Text = "Скидка";
                }

                if (skidka_str.Length > 0 && skidka_str[skidka_str.Length - 1] == '%')
                {
                    double skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 1));
                    new_sum = Convert.ToInt64(sum * (1 + skidka / 100));
                }
                else if (skidka_str.Length > 0 && skidka_str[skidka_str.Length - 1] == '.')
                {
                    double skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 4));
                    new_sum = sum + Convert.ToInt64(skidka/grdt_kass.Rows.Count*pometka);
                }
                bunifuFlatButton1.Text = new_sum.ToString();
            }
            


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
            summa();
        }

     







        private void vozvratketti()
        {
            string generateid = "";

            int keeti = 0;

            string deletetov = "";
           

            if (pometka>0)
            {
                generateid = Global.IDuser + (DateTimeOffset.Now.ToUnixTimeSeconds()).ToString();


                offcard = null;


                offcard = "INSERT INTO cart(crt_mg_id,id_kassir,crt_sum_fact,crt_date,crt_off_id)VALUES(" + Global.IDmagaz + "," + Global.IDuser + "," + label3.Text + "," + DateTimeOffset.Now.ToUnixTimeSeconds() + "," + generateid + ") Returning crt_id";






                offup = null;


                INFO += "М.№" + Global.IDmagaz + "  '" + Global.MGname + "'\n" + "Адрес  " + Global.MGadr + "\n" + "Продажа" + "\n";

                BarcodeWriter qr = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
                img = qr.Write((Global.IDmagaz + Global.IDuser).ToString());

                while (keeti < grdt_kass.Rows.Count)
                {

                    if (Convert.ToBoolean(grdt_kass.Rows[keeti].Cells[0].Value) == true) { 

                    string zena = grdt_kass.Rows[keeti].Cells[3].Value.ToString();
                    string pieces = Convert.ToString(grdt_kass.Rows[keeti].Cells[5].Value).Replace(",", ".");
                    string skid = (grdt_kass.Rows[keeti].Cells[6].Value).ToString().Replace(",", ".");
                    long sum = Convert.ToInt64(grdt_kass.Rows[keeti].Cells[7].Value);
                    long min = Convert.ToInt64(grdt_kass.Rows[keeti].Cells[8].Value);

                    string hodka = grdt_kass.Rows[keeti].Cells[4].Value.ToString();

                    string saloname = Convert.ToString(grdt_kass.Rows[keeti].Cells[2].Value);
                    long kodd = Convert.ToInt64(grdt_kass.Rows[keeti].Cells[1].Value);

                    OVAR = "                                    " + pieces + " X " + zena + " = " + sum;
                    while (OVAR.Length < 70)
                    {
                        OVAR = "  " + OVAR;

                    }



                    TOVAR += kodd + "  " + saloname + "\n" + OVAR + "\n";


                     
                    offup += "UPDATE product SET pr_piec = ((select pr_piec from product WHERE pr_kod = " + kodd + " and pr_mg_id =" + Global.IDmagaz + " limit 1)+" + pieces + " ) WHERE pr_kod = " + kodd + " and pr_mg_id =" + Global.IDmagaz + ";";
                    offup += "INSERT INTO sales(sl_crt_id,sl_pieces,sl_cena,sl_name,sl_prihod,sl_skidon,sl_kod)VALUES(" + generateid + "," + pieces + "," + zena + ",$" + saloname + "$,-" + hodka + ",N$" + skid + "$," + kodd + ");";

                    seleoffproduct += "INSERT INTO sales(sl_crt_id,sl_pieces,sl_cena,sl_name,sl_prihod,sl_skidon)VALUES(" + generateid + "," + pieces + "," + zena + ",N$" + saloname + "$,-" + hodka + ",N$" + skid + "$);";

                    deletetov += "delete from vozvrat where sl_kod=" + kodd + "and sl_crt_id=" + numchek+";";

                }

                    keeti++;


                }

                method = "INSERT INTO cartbuymet(cbt_cart_id,cbt_by_how,cbt_by_komuis,cbt_sum,cbt_skidon)VALUES(crtid,N$Возврат$,0,-" + Convert.ToInt32(bunifuFlatButton1.Text).ToString() + ",N$" + bunifuFlatButton16.Text + "$);";


                




                conoff.Close();
                conoff.Open();
                sqloff = "INSERT INTO saleoff(saleoofudin,saledate,salecart)VALUES(N'" + offup + "',N'" + offcard + "',N'" + method.Replace("crtid", generateid) + "');";
                sqloff += deletetov;
                sqloff += deletetov.Replace("vozvrat", "sales");

                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                droff.Read();
                conoff.Close();


                conoff.Close();
                conoff.Open();
                sqloff = "INSERT INTO crt(crt,date) VALUES(" + generateid + "," + DateTimeOffset.Now.ToUnixTimeSeconds() + ");";
                sqloff += "insert into productoff(pr_text)VALUES(N'" + deletetov.Replace("vozvrat", "sales") + "');";
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                droff.Read();
                conoff.Close();


                conoff.Close();
                conoff.Open();
                sqloff = ((seleoffproduct + method).Replace("$", "'")).Replace("crtid", generateid);
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                droff.Read();
                conoff.Close();








                grdt_kass.Rows.Clear();

                INFO = "";
                TOVAR = "";
                label4.Text = "";
                bunifuFlatButton1.Text = null;
            
                bunifuFlatButton16.Text = "0";

                Program.main.backblakhide();
                Program.msg.Message.Text = "Товар возвращен"; Program.log.mess.Show(); Program.msg.Size = new Size(300, 100);
                this.Close();

                

            }
           


        }




        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {

            e.Graphics.DrawImage(img, imga);
            var r = new Rectangle(0, 60, 300, 5000000);

            e.Graphics.DrawString(INFO + TOVAR, new Font("Arial", 8), Brushes.Black, r);

            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(INFO + TOVAR, new Font("Arial", 8), 300);
            var r2 = new Rectangle(0, Convert.ToInt32(Convert.ToDouble(stringSize.Height) + 60), 300, 5000000);
            var r3 = new Rectangle(0, Convert.ToInt32(Convert.ToDouble(stringSize.Height) + 80), 300, 5000000);
            var r4 = new Rectangle(190, Convert.ToInt32(Convert.ToDouble(stringSize.Height) + 80), 300, 5000000);
            e.Graphics.DrawString(Infoend, new Font("Arial", 8), Brushes.Black, r2);
            e.Graphics.DrawString(itog, new Font("Arial Black", 10), Brushes.Black, r3);
            e.Graphics.DrawString(itog2, new Font("Arial Black", 10), Brushes.Black, r4);
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            vozvratketti();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void Vozvrat_Shown(object sender, EventArgs e)
        {
            textBox2.Focus();
        }
    }
}