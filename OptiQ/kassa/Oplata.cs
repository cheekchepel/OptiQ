﻿using System;
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
    public partial class Oplata : Form
    {
        public Oplata()
        {
            InitializeComponent();
            Program.oplati = this;
        }
        int o = 0;

        public int che = 0;

        public bool dolber = false;

       public string opa = "";

        private void nal_Click(object sender, EventArgs e)
        {
            nav_clik();
        }


        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;
        public SqlCommand cmdoff;
        public SqlDataReader droff;




        public bool belie = true;


        public long us_id_bon =0;

        public int bonus = 0;

        private bool Drag;
        private int MouseX;
        private int MouseY;


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









        public void nav_clik() {

            color_clear();
            nal.Textcolor = Color.White;
            nal.Normalcolor = nal.Activecolor;
            nalich.Visible = true;
            numpad1.Visible = true;
            cena.Visible = true;
            textBox1.Focus();
            label5Change();
            if (us_id_bon != 0)
            {
                o = 0;


            }
            else {
                o = 1;
            }


            opa = nal.Text;
        }



        private void karta_Click(object sender, EventArgs e)
        {
            color_clear();
            karta.Normalcolor = nal.Activecolor;
            karta.Textcolor = Color.White;
            
            textbonus.Focus();

            if (dolber == true)
            {
                beznal.Visible = true;
                textBox2.Focus();
                label5.Text = label4.Text;
            }
            else { textBox2.Text = label4.Text; }
            
            cena.Visible = false;
            opa = karta.Text;
            che = 1;
           
           // label5Change();
        }

        private void kaspi_Click(object sender, EventArgs e)
        {
            color_clear();
            kaspi.Normalcolor = nal.Activecolor;
            kaspi.Textcolor = Color.White;
            
            textbonus.Focus();
            if (dolber == true)
            {
                kaspiet.Visible = true;
                textBox3.Focus();
                label5.Text = label4.Text;
            }
            else { textBox3.Text = label4.Text; }

          
            cena.Visible = false;
            opa = kaspi.Text;
            che = 2;
            label5Change();
        }

        private void smejno_Click(object sender, EventArgs e)
        {
            color_clear();
            smejno.Normalcolor = nal.Activecolor;
            nalich.Visible = true;
            kaspiet.Visible = Global.Vkaspi;
            beznal.Visible = Global.Vbeznal;
            numpad1.Visible = true;
            REDT.Visible = Global.Vkaspired;
            textBox1.Focus();
            smejno.Textcolor = Color.White;
            cena.Visible = false;
            opa = smejno.Text;
            pbonus.Width = 242;
            skokadolg.Width = 242;
            label5Change();
        }

        private void dolg_Click(object sender, EventArgs e)
        {

            color_clear();
            dolber = true;
            if (us_id_bon != 0)
            {
                nav_clik();
                

            }
            else {

                pbonus.Visible = false;
                dolg.Normalcolor = nal.Activecolor;

                vdolg1.Visible = true;
                dolg.Textcolor = Color.White;
                cena.Visible = false;
                opa = dolg.Text;
                numpad1.Visible = false;

            }
            
            // bunifuFlatButton6.Text = "Записать";

            //  label5.Text = label4.Text;
            // textBox3.Text = label4.Text;


        }

        public void color_clear() {
            o = 0;
           
            bunifuFlatButton6.Text = "Оплатить";
            vdolg1.Visible = false;
            skokadolg.Visible = false;
            nal.Normalcolor = nal.OnHovercolor;
            karta.Normalcolor = nal.OnHovercolor;
            kaspi.Normalcolor = nal.OnHovercolor;
            smejno.Normalcolor = nal.OnHovercolor;
            dolg.Normalcolor = nal.OnHovercolor;
            RED.Normalcolor = nal.OnHovercolor;

            nal.Textcolor = nal.DisabledColor;
            karta.Textcolor = nal.DisabledColor;
            kaspi.Textcolor = nal.DisabledColor;
            smejno.Textcolor = nal.DisabledColor;
            dolg.Textcolor = nal.DisabledColor;
            RED.Textcolor = nal.DisabledColor;


           


            nalich.Visible = false;
            beznal.Visible = false;
            kaspiet.Visible = false;
            REDT.Visible = false;
            this.ActiveControl = null;

            if (us_id_bon != 0)
            {
                pbonus.Visible = true;
                numpad1.Visible = true; 
                
            }
            else {
                pbonus.Visible = false;
                numpad1.Visible = false;
                dolber = false;
                
            }
            if (dolber == true)
            {

                skokadolg.Visible = true;
            }
            else { skokadolg.Visible = false; }
            che = 0;

            pbonus.Width = 300;
            skokadolg.Width = 300;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text=null;
            textbonus.Text=null;
           textdolg.Text=null;



            label5.Text = "0";
            
        }

        private void flowLayoutPanel5_Resize(object sender, EventArgs e)
        {
            
            this.Height = 290 + flowLayoutPanel5.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numpad1.Visible = false;
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Program.main.backblakhide();
            this.Close();
          
        }

        private void Oplata_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void Oplata_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;


            if (number == '$' || number == '%' || number == ',' || number == Convert.ToChar(Program.main.opa)) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (o == 1) { textBox1.Focus(); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label5.Text = (Convert.ToInt32("0" + textBox4.Text) + Convert.ToInt32("0" + textBox1.Text) + Convert.ToInt32("0" + textBox3.Text) + Convert.ToInt32("0" + textBox2.Text) ).ToString();
            if (textBox1.Text.Length > 8) { textBox1.Text = textBox1.Text.Remove(8); textBox1.SelectionStart = textBox1.Text.Length; }

        }

        private void label5_TextChanged(object sender, EventArgs e)
        {
            label5Change();
        }

        public void label5Change() {
            bunifuFlatButton6.Text = "Оплатить";
            int sdaca = Convert.ToInt32(label5.Text) - Convert.ToInt32(label4.Text);
            if (sdaca < 0) { label7.Text = "Суммы недостаточно для оплаты"; label7.Visible = true;

                if (dolber == true)
                {
                    label7.Text = "Недостающая сумма запишется в долг";
                    textdolg.Text = Math.Abs(sdaca).ToString();
                    bunifuFlatButton6.Text = "Записать";
                }
                else { textdolg.Text = "0"; }

            }      
            else { label7.Visible = false; textdolg.Text = "0"; }
            label6.Text = (sdaca).ToString();
           

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 8) { textBox3.Text = textBox3.Text.Remove(8); textBox3.SelectionStart = textBox3.Text.Length; }
        //    label4.Text = (Convert.ToInt32(Program.KASA.bunifuFlatButton1.Text) - Convert.ToInt32("0" + textbonus.Text)).ToString();
           
            label5.Text = (Convert.ToInt32("0" + textBox4.Text) + Convert.ToInt32("0" + textBox1.Text) + Convert.ToInt32("0" + textBox3.Text) + Convert.ToInt32("0" + textBox2.Text) ).ToString();
           
          
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 8) { textBox2.Text = textBox2.Text.Remove(8); textBox2.SelectionStart = textBox2.Text.Length; }
         //  label4.Text = (Convert.ToInt32(Program.KASA.bunifuFlatButton1.Text) - Convert.ToInt32("0" + textbonus.Text)).ToString();
            label5.Text = (Convert.ToInt32("0" + textBox4.Text) + Convert.ToInt32("0" + textBox1.Text) + Convert.ToInt32("0" + textBox3.Text) + Convert.ToInt32("0" + textBox2.Text)).ToString();
          
        }

        private void Oplata_Load(object sender, EventArgs e)
        {


            if (Global.prin == false) { prinnet(); } else { prinda(); }
            us_id_bon = 0;
            dolber = false;

            color_clear();

          bonus = 0;

            textBox5.Text = "Клиент не выбран";
            cifra.Text = "0";



            nav_clik();
            this.Top = (Global.y - this.Height)/2;
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(label6.Text) > -1 ||dolber==true)
            {
                sqloff = null;
                Program.KASA.kakprodalchek = null;

                int chislo = Convert.ToInt32(label6.Text)+ Convert.ToInt32("0"+textdolg.Text);
                string obs = Program.KASA.bunifuFlatButton16.Text;

                Program.KASA.method = null;
                
                    if (!String.IsNullOrWhiteSpace(textBox1.Text) || Convert.ToInt32("0" + textBox1.Text) != 0 || chislo > 0)
                    {
                        Program.KASA.method += "INSERT INTO cartbuymet(cbt_cart_id,cbt_by_how,cbt_by_komuis,cbt_sum,cbt_skidon)VALUES(crtid,N$" + nal.Text + "$,"+Global.nal+"," + (Convert.ToInt32("0"+textBox1.Text) - chislo).ToString() + ",N$" + obs + "$);";
                        Program.KASA.kakprodalchek += nal.Text + " : " + (Convert.ToInt32("0" + textBox1.Text) - chislo).ToString() + "\n";

                    }
                    if (!String.IsNullOrWhiteSpace(textBox2.Text) || Convert.ToInt32("0" + textBox2.Text) != 0)
                    {
                        Program.KASA.method += "INSERT INTO cartbuymet(cbt_cart_id,cbt_by_how,cbt_by_komuis,cbt_sum,cbt_skidon)VALUES(crtid,N$" + karta.Text + "$,"+ Global.beznal + "," + Convert.ToInt32(textBox2.Text).ToString() + ",N$"+ obs + "$);";
                        Program.KASA.kakprodalchek += karta.Text + " : " + Convert.ToInt32(textBox2.Text).ToString() + "\n";
                    }
                    if (!String.IsNullOrWhiteSpace(textBox3.Text) || Convert.ToInt32("0" + textBox3.Text) != 0)
                    {
                        Program.KASA.method += "INSERT INTO cartbuymet(cbt_cart_id,cbt_by_how,cbt_by_komuis,cbt_sum,cbt_skidon)VALUES(crtid,N$" + kaspi.Text + "$," + Global.kaspi + "," + Convert.ToInt32(textBox3.Text).ToString() + ",N$" + obs + "$);";
                        Program.KASA.kakprodalchek += kaspi.Text + " : " + Convert.ToInt32(textBox3.Text).ToString() + "\n";
                    }
                    if (!String.IsNullOrWhiteSpace(textBox4.Text) || Convert.ToInt32("0" + textBox4.Text) != 0)
                    {
                        Program.KASA.method += "INSERT INTO cartbuymet(cbt_cart_id,cbt_by_how,cbt_by_komuis,cbt_sum,cbt_skidon)VALUES(crtid,N$" + RED.Text + "$," + Global.kaspired + "," + Convert.ToInt32(textBox4.Text).ToString() + ",N$" + obs + "$);";
                        Program.KASA.kakprodalchek += RED.Text + " : " + Convert.ToInt32(textBox4.Text).ToString() + "\n";
                    }
                  
                    if(us_id_bon!=0)
                {

                         if (Convert.ToInt32("0" + textbonus.Text) != 0)
                             {
                                Program.KASA.method += "INSERT INTO cartbuymet(cbt_cart_id,cbt_by_how,cbt_by_komuis,cbt_sum,cbt_skidon)VALUES(crtid,N$Бонусы$,0," + Convert.ToInt32(textbonus.Text).ToString() + ",N$" + obs + "$);";

                                 sqloff = "UPDATE users_pro SET us_bonus = ((select us_bonus from users_pro WHERE us_off_id = " + us_id_bon + " and us_mg_id=" + Global.IDmagaz + ")-" + textbonus.Text + " )" +
                                " WHERE us_off_id = " + us_id_bon + " and us_mg_id=" + Global.IDmagaz + ";";

                                 Program.KASA.kakprodalchek += "Бонусы : " + Convert.ToInt32(textbonus.Text).ToString() + "\n";

                             }
                        else if(Convert.ToInt32("0"+ textdolg.Text) == 0)
                            {

                        int nachislino = Convert.ToInt32(Convert.ToDouble(Program.KASA.bunifuFlatButton1.Text) * (Convert.ToDouble(Global.maxbonus) / 100));


                        sqloff = "UPDATE users_pro SET us_bonus = ((select us_bonus from users_pro WHERE us_off_id = " + us_id_bon + " and us_mg_id=" + Global.IDmagaz + ")+" + nachislino + " )" +
                                " WHERE us_off_id = " + us_id_bon + " and us_mg_id=" + Global.IDmagaz + ";";

                            }
                        if (dolber == true &&  Convert.ToInt32("0"+textdolg.Text)!=0)
                            {
                       
                                Program.KASA.method += "INSERT INTO cartbuymet(cbt_cart_id,cbt_by_how,cbt_by_komuis,cbt_sum,cbt_skidon)VALUES(crtid,N$" + dolg.Text + "$,0," + textdolg.Text + ",N$" + obs + "$);";

                                sqloff = "UPDATE users_pro SET us_summa = ((select us_summa from users_pro WHERE us_off_id = " + us_id_bon + " and us_mg_id=" + Global.IDmagaz + ")+" + textdolg.Text + " ),us_date=" + DateTimeOffset.Now.ToUnixTimeSeconds() + "" +
                                " WHERE us_off_id = " + us_id_bon + " and us_mg_id=" + Global.IDmagaz + ";";
                          
                                Program.KASA.kakprodalchek += dolg.Text + " : " + Convert.ToInt32(label4.Text).ToString() + "\n";

                            }




                 }

             


                if (Program.KASA.method != null) {

                        Program.main.backblakhide();
                        this.Close();
                        Program.KASA.oplata();

                    if (sqloff != null)
                    {


                        conoff.Close();
                        conoff.Open();
                        sqloff += "INSERT INTO productoff(pr_text)VALUES(N'" + sqloff.Replace("'", "$") + "');";
                        cmdoff = new SqlCommand(sqloff, conoff);
                        droff = cmdoff.ExecuteReader();
                        droff.Read();
                        conoff.Close();
                        conoff.Close();

                    }


                }



              


            }
        }

        private void bunifuFlatButton2_MouseDown(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToInt64("0" + textBox1.Text) + 200).ToString();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void bunifuFlatButton3_MouseDown(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToInt64("0" + textBox1.Text) + 500).ToString();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void bunifuFlatButton4_MouseDown(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToInt64("0" + textBox1.Text) + 1000).ToString();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void bunifuFlatButton5_MouseDown(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToInt64("0" + textBox1.Text) + 2000).ToString();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void bunifuFlatButton8_MouseDown(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToInt64("0" + textBox1.Text) + 5000).ToString();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void bunifuFlatButton9_MouseDown(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToInt64("0" + textBox1.Text) + 10000).ToString();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void bunifuFlatButton10_MouseDown(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            textBox1.Text = label4.Text;
            textBox1.SelectionStart = textBox1.Text.Length;
        }

     

        private void RED_Click(object sender, EventArgs e)
        {


            color_clear();
            RED.Normalcolor = nal.Activecolor;
            RED.Textcolor = Color.White;
            
            textbonus.Focus();
            if (dolber == true)
            {
                REDT.Visible = true;
                textBox4.Focus();
                label5.Text = label4.Text;
            }
            else { textBox4.Text = label4.Text; }
        
            cena.Visible = false;
            opa = RED.Text;
            che = 3;
            label5Change();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 8) { textBox4.Text = textBox4.Text.Remove(8); textBox4.SelectionStart = textBox4.Text.Length; }
           // label4.Text = (Convert.ToInt32(Program.KASA.bunifuFlatButton1.Text) - Convert.ToInt32("0" + textbonus.Text)).ToString();
            label5.Text = (Convert.ToInt32("0" + textBox4.Text) + Convert.ToInt32("0" + textBox1.Text) + Convert.ToInt32("0" + textBox3.Text) ).ToString();
           
        }

        private void bunifuFlatButton12_MouseDown(object sender, EventArgs e)
        {

            if (Global.prin == true) { prinnet(); } else { prinda(); }

         
        }



        void prinda() {

            Global.prin = true;
            bunifuFlatButton12.Normalcolor= Color.FromArgb(67, 181, 129);
            bunifuFlatButton12.OnHovercolor= Color.FromArgb(67, 181, 129);
            bunifuFlatButton12.Activecolor= Color.FromArgb(67, 181, 129);
        }

        void prinnet()
        {

            Global.prin = false;
            bunifuFlatButton12.Normalcolor = Color.FromArgb(240, 71, 71);
            bunifuFlatButton12.OnHovercolor = Color.FromArgb(240, 71, 71);
            bunifuFlatButton12.Activecolor = Color.FromArgb(240, 71, 71);

        }





        void belnet()
        {

            belie = false;
            bunifuFlatButton13.Normalcolor = Color.FromArgb(116, 127, 141);
            bunifuFlatButton13.OnHovercolor = Color.FromArgb(116, 127, 141);
            bunifuFlatButton13.Activecolor = Color.FromArgb(116, 127, 141);
        }

        void belda()
        {

            belie = true;
            bunifuFlatButton13.Normalcolor = Color.FromArgb(240, 71, 71);
            bunifuFlatButton13.OnHovercolor = Color.FromArgb(240, 71, 71);
            bunifuFlatButton13.Activecolor = Color.FromArgb(240, 71, 71);

        }



        public void viborusers(long us_id, string name, int bon ) {

            us_id_bon = us_id;

            if (us_id != 0) {

                textBox5.Text = name;
                cifra.Text = bon.ToString();



            }
            else
            {

                textBox5.Text = "Клиент не выбран";
                cifra.Text = "0";


            }

            

            





        }

     

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox5_MouseDown();
        }

        public void pictureBox5_MouseDown() {

            us_id_bon = 0;
            bonus = 0;
            color_clear();
            vdolg1.textBox4.Text = null;
            viborusers(0, "", 0);
            vdolg1.Visible = true;
            cena.Visible = false;
            pbonus.Visible = false;
            skokadolg.Visible = false;

        }

        private void textbonus_TextChanged(object sender, EventArgs e)
        {
            if (textbonus.Text.Length > 8) { textbonus.Text = textbonus.Text.Remove(8); textbonus.SelectionStart = textbonus.Text.Length; }


            int porogvozm = Convert.ToInt32(Convert.ToDouble(Program.KASA.bunifuFlatButton1.Text) * (Convert.ToDouble(Global.maxbonusogran) / 100));

            if (Convert.ToInt32("0" + textbonus.Text) > porogvozm)
            { textbonus.Text = porogvozm.ToString(); }


            if (Convert.ToInt32("0"+textbonus.Text)> Convert.ToInt32("0"+cifra.Text)) {
                textbonus.Text = cifra.Text;
                textbonus.SelectionStart = textbonus.Text.Length;
            }

           

            label4.Text= (Convert.ToInt32(Program.KASA.bunifuFlatButton1.Text)- Convert.ToInt32("0" + textbonus.Text)).ToString();

            if (che == 1) { textBox2.Text = label4.Text; }
            else if (che == 2) { textBox3.Text = label4.Text; }
            else if (che == 3) { textBox4.Text = label4.Text; }

            
            label5Change();

        }

     

        private void pictureBox9_MouseDown(object sender, MouseEventArgs e)
        {
            dolber = false;
            skokadolg.Visible = false;
            if (che == 1) { textBox2.Text = label4.Text; }
            else if (che == 2) { textBox3.Text = label4.Text; }
            else if (che == 3) { textBox4.Text = label4.Text; }
            label5Change();
        }

        private void textbonus_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBox5_MouseDown(object sender, EventArgs e)
        {
            pictureBox5_MouseDown();
        }

        private void cifra_MouseDown(object sender, EventArgs e)
        {
            pictureBox5_MouseDown();
        }

        private void bunifuFlatButton13_MouseDown(object sender, EventArgs e)
        {
            if (belie == true) { belnet(); } else { belda(); }
        }
    }
}
