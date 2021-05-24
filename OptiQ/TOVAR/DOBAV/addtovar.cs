﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace OptiQ
{



    public partial class addtovar : Form
    {
        public addtovar()
        {
            InitializeComponent();
            Program.addprd = this;
        }


        public SqlConnection con = new SqlConnection(Global.conectsql);

        public string shtrih = null;
        public string sql;
        public SqlCommand cmd;
        public SqlDataReader dr;






        fastaddprovid fstadpr = new fastaddprovid();
        //  private double res;
        public DataTable dtSales = new DataTable();

        string itog;
        string url = "https://barcode-list.ru/barcode/RU/%D0%9F%D0%BE%D0%B8%D1%81%D0%BA.htm?barcode=";

        Image img;

        BarcodeWriter qr = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };


        Razmer[] rzm = new Razmer[30];

        private bool Drag;
        private int MouseX;
        private int MouseY;
        public long prkod = 0;
        public long katid = 0;
        public long tov_id_loc = 0;

        public int kol = 0;
        public int kolcreate = 0;


        private void PanelMove_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }
        private void PanelMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
                this.Top = Cursor.Position.Y - MouseY;
                this.Left = Cursor.Position.X - MouseX;
            }
        }
        private void PanelMove_MouseUp(object sender, MouseEventArgs e) { Drag = false; }















        public void clear()
        {
            dtSales.Rows.Clear();
            dtSales.Rows.Add(0,0,"Обычный",0);
            viewcell();
            prkod = 0;
            text1.Text = "";
            text2.Text = "";
            text3.Text = "";
            textopt.Text = "";
            text5.Text = "";

            label9.Text = "Новый товар";

            text6.Items.Clear();

            text6.Items.Add("Нет");
            text6.Text = "Нет";


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

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            rendom();
        }





        public void rendom()
        {


            Random random = new Random();
            long randomNumber = random.Next(20000000, 29999999);

                con.Close();
                con.Open();
                sql = "select pr_kod from product_pro where pr_mg_id = " + Global.IDmagaz + "and pr_kod = " + randomNumber;
                cmd = new SqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    con.Close();
                    rendom();

                }
                else { text1.Text = randomNumber.ToString(); }
                con.Close();




        }

        private void addtovar_Shown(object sender, EventArgs e)
        {

           

            clear();
            text1.Focus();
            if (shtrih != null)
            {
                selct(shtrih);
            }
         




            //this.Height = panel3.Height + bunifuFlatButton6.Location.Y + 65;

        }

        private void text1_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter && !String.IsNullOrWhiteSpace(text1.Text))
            {

                selct(text1.Text);

            }
        }



        public void selct(string kod)
        {

            bool danet = true;
            string prname = "";
            string prco = "";
            string prca = "";
            string prop = "";
            string prprv = "";
            string prkot = "";
            string prkotname = "";
            tov_id_loc = 0;

        katid = 0;
            prkod = 0;
                text2.Text = "";
                text3.Text = "";
                textopt.Text = "";
                text5.Text = "";
                text6.Text = "Нет";



                con.Open();
                sql = "select pr_id,pr_kod,pr_name,pr_price_co,pr_price_ca,pr_optom,pr_provid,rz_id,rz_name,rz_pies,pr_kotak,(select kot_name as name from kotak where kot_chil=pr_kotak) from product_pro " +
                       "LEFT JOIN razmer_pro ON pr_kod = rz_pr_kod where pr_mg_id ="+Global.IDmagaz+" and pr_kod ="+kod+";" ;
                cmd = new SqlCommand(sql, con);
            dtSales.Rows.Clear();
            dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                tov_id_loc =Convert.ToInt64(dr["pr_id"]) ;
                prname = dr["pr_name"].ToString();
                    prco = dr["pr_price_co"].ToString();
                    prca = dr["pr_price_ca"].ToString();
                    prop = dr["pr_optom"].ToString();
                    prprv = dr["pr_provid"].ToString();
                    prkot= dr["pr_kotak"].ToString();
         
                    prkotname =""+ dr[11].ToString();
                if (prkotname == "") {
                    prkotname = "Нет";
                }
              
                    

                danet = false;
                    dtSales.Rows.Add(kod,dr["rz_id"],dr["rz_name"],dr["rz_pies"]);


               // label9.Text = "Изменение товара";

                }
            label9.Text = "Изменение товара";
            prkod =Convert.ToInt64( kod);
                text1.Text = kod.ToString();
                text2.Text = prname;
                text3.Text = prco;
                text5.Text = prca;
                textopt.Text = text5.Text;
                text6.Text = prprv;
                 kotname.Text = prkotname;
                 katid = Convert.ToInt64(prkot); 

                if (Convert.ToInt32(0+prop) != 0)
                {
                    textopt.Text = prop.ToString();
                }

                if (danet)
                {
                label9.Text = "Новый товар";
                    dtSales.Rows.Add(0, 0, "Обычный", 0);
                viewcell();
                    var qe = (HttpWebRequest)WebRequest.Create(url + kod);
                    using (HttpWebResponse response = (HttpWebResponse)qe.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {

                        itog = reader.ReadToEnd();

                    }



                    int dva = itog.IndexOf(" - Штрих-код:");

                    if (dva > 0)
                    {
                        itog = itog.Remove(dva);

                        int odin = itog.IndexOf("<title>");

                        itog = itog.Remove(0, odin + 7);

                        text2.Text = itog.Replace(",", ".");

                        try
                        {
                            con.Close();
                            con.Open();
                            sql = "INSERT INTO productoff(pr_text)VALUES(N'INSERT INTO allpruduct(al_kod, al_name)VALUES(" + kod + ", $" + text2.Text + "$);')"; ;
                            cmd = new SqlCommand(sql, con);
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            con.Close();
                        }
                        catch { }
                    }



                }
                con.Close();
                viewcell();


        }















        private void close_Click(object sender, EventArgs e)
        {
            Program.main.backblakhide();
            this.Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            fstadpr.Location = new Point(Left + Width, Top + 285);
            fstadpr.ShowDialog();

        }

        private void addtovar_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            string opa = "'";

            if (number == '$' || number == '%' || number == ',' || number == Convert.ToChar(opa)) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {


                if (!String.IsNullOrWhiteSpace(rzm[0].textname.Text)&& !String.IsNullOrWhiteSpace(rzm[0].textname.Text) && !String.IsNullOrWhiteSpace(text1.Text) && !String.IsNullOrWhiteSpace(text2.Text) && !String.IsNullOrWhiteSpace(text5.Text) && !String.IsNullOrWhiteSpace(text6.Text))
                {
                    int priha = Convert.ToInt32(0 + text3.Text);
                    int opti = Convert.ToInt32(0 + textopt.Text);
                    if (opti == 0)
                    {
                        opti = Convert.ToInt32(0 + text5.Text);
                    }


                    if (prkod != 0)
                    {

                        con.Close();
                        con.Open();
                        sql = $"select pr_kod from product_pro where pr_mg_id ={Global.IDmagaz}and pr_kod ={text1.Text} and not pr_id="+ tov_id_loc + " ;";
                        cmd = new SqlCommand(sql, con);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {

                           

                            MessageBox.Show("Товар с данным штрих кодом уже существует");

                            con.Close();
                            return;

                        }

                        con.Close();


                        Global.basever++;

                        con.Close();
                        con.Open();
                        sql = "UPDATE product_pro Set pr_kod=" + text1.Text + ", pr_name=N'" + text2.Text + "',pr_price_co=" + priha + ",pr_price_ca=" + text5.Text + ",pr_prov_id=0+(select mp_id_off from myprov where mp_name=N'" + text6.Text + "' and mp_mg_id="+Global.IDmagaz+ " ORDER BY mp_id DESC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY),pr_provid=N'"+ text6.Text + "',pr_optom=" + opti + ", pr_kotak="+katid+" WHERE pr_kod =" + prkod + "and pr_mg_id=" + Global.IDmagaz+";";
                        sql += "INSERT INTO productoff(pr_text)VALUES(N'" + (Global.versia + sql).Replace("'", "$") + "')";
                        cmd = new SqlCommand(sql, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        con.Close();


                    }
                    else
                    {

                        con.Close();
                        con.Open();
                        sql = $"select pr_kod from product_pro where pr_mg_id ={Global.IDmagaz}and pr_kod ={text1.Text};";
                        cmd = new SqlCommand(sql, con);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {

                            MessageBox.Show("Товар с данным штрих кодом уже существует");
                            ;
                            con.Close();
                            return;

                        }

                        con.Close();




                        con.Close();
                        con.Open(); 


                        sql = "INSERT INTO product_pro(pr_mg_id,pr_kod,pr_name,pr_price_co,pr_price_ca,pr_provid,pr_optom,pr_prov_id,pr_kotak)VALUES(" + Global.IDmagaz + "," + text1.Text + ",N'" + text2.Text + "'," + priha + "," + text5.Text + ",N'" + text6.Text + "'," + opti + ",0+(select mp_id_off from myprov where mp_name=N'" + text6.Text + "' and mp_mg_id=" + Global.IDmagaz + " ORDER BY mp_id DESC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY),"+katid+");";

                        sql += "INSERT INTO productoff(pr_text)VALUES(N'"  + (Global.versia + sql).Replace("'", "$") + "select doppler(" + Global.IDmagaz + "," + text1.Text + ");" + "')";

                        cmd = new SqlCommand(sql, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        con.Close();
                  


                    }

                    zapisat();








                    con.Close();
                    Program.main.backblakhide();
                    Program.tov.zagrsel(true);

                    this.Close();


                }

        }

        private void text3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void text4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void text5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }







        private void text3_OnValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(text3.Text))
            {

                text3.Text = (Convert.ToInt32(text3.Text)).ToString();
            }



        }

       

   
    

      
     

     



        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrWhiteSpace(text1.Text) && !String.IsNullOrWhiteSpace(text2.Text))
            {



                PrintDocument printDocument = new PrintDocument();
                PrintDialog PrintDialog = new PrintDialog();

                printDocument.PrintPage += PrintPageHandler;
                PrintDialog.Document = printDocument;
                PrintDialog.ShowDialog();


            }
        }





        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle sourceRectangle = new Rectangle(0, 50, 126, 63);



            int x = 55;
            int y = 65;

            img = qr.Write(text1.Text);



            string text = text2.Text;



            Rectangle destRectangle = new Rectangle(x, y, 200, 100);

            var r = new Rectangle(x - 15, y - 55, 230, 50);
            // e.Graphics.DrawImage(img,x,y,200,50);

            e.Graphics.DrawString(text, new Font("Arial", 16), Brushes.Black, r);

            e.Graphics.DrawImage(img, destRectangle, sourceRectangle, GraphicsUnit.Pixel);





        }

      

    

        private void text5_Leave(object sender, EventArgs e)
        {
            k4.Visible = false;
        }

        private void addtovar_Load(object sender, EventArgs e)
        {
            label3.Visible = Global.pra_showprih;
            text3.Visible = Global.pra_showprih;
            label4.Visible = Global.pra_showprih;
            textopt.Visible = Global.pra_showprih;

            if (kolcreate < 30) {

               dtSales.Columns.Add("kod", typeof(string));
                dtSales.Columns.Add("id", typeof(string));
                dtSales.Columns.Add("name", typeof(string));
                dtSales.Columns.Add("pies", typeof(string));
            }


            while (kolcreate < 30)
            {



                rzm[kolcreate] = new Razmer();
                rzm[kolcreate].Visible = false;

                flowLayoutPanel3.Controls.Add(rzm[kolcreate]);

                kolcreate++;


            }







        }


        public void viewcell()
        {
            
            flowLayoutPanel3.Visible = false;
            for (int i = 0; i < 30; i++)
            {
                if (i < dtSales.Rows.Count)
                {
                    
                    rzm[i].ID = i;
                   // rzm[i].textname.Focus();
                }
                else
                {
                    try { rzm[i - 1].plus.Visible = true; } catch { }
                    
                    rzm[i].Visible = false;
                }
            }
            if (dtSales.Rows.Count == 1)
            {
                rzm[0].delete.Visible = false;
                rzm[0].textname.Enabled = false;
                rzm[0].textname.Text = "Обычный";
            }

           flowLayoutPanel3.Visible = true;
            flowLayoutPanel3.VerticalScroll.Value = flowLayoutPanel3.VerticalScroll.Maximum;
            this.Height = panel4.Height + panel4.Top;
            this.Top = (Global.y - this.Height) / 2;
        }


        public void zapisat()
        {

         
            for (int i = 0; i < 30; i++)
            {
                if (i < dtSales.Rows.Count)
                {
                    rzm[i].insert_update();

                }
                
            }

         
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void edit_Click(object sender, EventArgs e)
        {
            Program.zakup.blackback.Show();
            Program.tov.kot.vibor = true;
            Program.tov.kot.ShowDialog();


        }

        private void text1_Enter(object sender, EventArgs e)
        {
            k1.Visible = true;
        }

        private void text1_Leave(object sender, EventArgs e)
        {
            k1.Visible = false;
        }

        private void text2_Enter(object sender, EventArgs e)
        {
            k2.Visible = true;
        }

        private void text2_Leave(object sender, EventArgs e)
        {
            k2.Visible = false;
        }

        private void text3_Enter(object sender, EventArgs e)
        {
            k3.Visible = true;
        }

        private void text3_Leave(object sender, EventArgs e)
        {
            k3.Visible = false;
        }

        private void text5_Enter(object sender, EventArgs e)
        {
            k4.Visible = true;
        }

        private void textopt_Enter(object sender, EventArgs e)
        {
            k5.Visible = true;
        }

        private void textopt_Leave(object sender, EventArgs e)
        {
            k5.Visible = false;
        }
    }
}
