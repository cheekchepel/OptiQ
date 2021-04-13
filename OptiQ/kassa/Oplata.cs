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
    public partial class Oplata : Form
    {
        public Oplata()
        {
            InitializeComponent();
        }
        int o = 0;

        bool dolber = false;

       public string opa = "";

        private void nal_Click(object sender, EventArgs e)
        {
            nav_clik();
        }


        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;
        public SqlCommand cmdoff;
        public SqlDataReader droff;


        public bool prin = true;






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
            o = 1;
            opa = nal.Text;
        }



        private void karta_Click(object sender, EventArgs e)
        {
            color_clear();
            karta.Normalcolor = nal.Activecolor;
            karta.Textcolor = Color.White;
            label5.Text = label4.Text;
            textBox2.Text = label4.Text;
            cena.Visible = false;
            opa = karta.Text;
        }

        private void kaspi_Click(object sender, EventArgs e)
        {
            color_clear();
            kaspi.Normalcolor = nal.Activecolor;
            kaspi.Textcolor = Color.White;
            label5.Text = label4.Text;
            textBox3.Text = label4.Text;
            cena.Visible = false;
            opa = kaspi.Text;
        }

        private void smejno_Click(object sender, EventArgs e)
        {
            color_clear();
            smejno.Normalcolor = nal.Activecolor;
            nalich.Visible = true;
            kaspiet.Visible = true;
            beznal.Visible = true;
            numpad1.Visible = true;
            REDT.Visible = true;
            textBox1.Focus();
            smejno.Textcolor = Color.White;
            cena.Visible = false;
            opa = smejno.Text;
        }

        private void dolg_Click(object sender, EventArgs e)
        {

            color_clear();
            dolg.Normalcolor = nal.Activecolor;
            dolber = true;
            vdolg1.Visible = true;
            dolg.Textcolor = Color.White;
            cena.Visible = false;
            label5.Text = label4.Text;
            textBox3.Text = label4.Text;
            opa = dolg.Text;

        }

        public void color_clear() {

            vdolg1.Visible = false;

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

            dolber = false;
            numpad1.Visible = false;
            nalich.Visible = false;
            beznal.Visible = false;
            kaspiet.Visible = false;
            REDT.Visible = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            o = 0;
            label5.Text = "0";
            

        }

        private void flowLayoutPanel5_Resize(object sender, EventArgs e)
        {
            this.Height = 295 + flowLayoutPanel5.Height;
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
            label5.Text = (Convert.ToInt32("0" + textBox4.Text) + Convert.ToInt32("0" + textBox1.Text) + Convert.ToInt32("0"+textBox3.Text) + Convert.ToInt32("0" + textBox2.Text)).ToString();

            if (textBox1.Text.Length > 8) { textBox1.Text = textBox1.Text.Remove(8); textBox1.SelectionStart = textBox1.Text.Length; }

        }

        private void label5_TextChanged(object sender, EventArgs e)
        {
            int sdaca = Convert.ToInt32(label5.Text) - Convert.ToInt32(label4.Text);
            if (sdaca < 0) { label7.Visible = true; } else { label7.Visible = false; }
            label6.Text = (sdaca).ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label5.Text = (Convert.ToInt32("0" + textBox4.Text) + Convert.ToInt32("0" + textBox1.Text) + Convert.ToInt32("0" + textBox3.Text) + Convert.ToInt32("0" + textBox2.Text)).ToString();
            if (textBox3.Text.Length > 8) { textBox3.Text = textBox3.Text.Remove(8); textBox3.SelectionStart = textBox3.Text.Length; }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Text = (Convert.ToInt32("0" + textBox4.Text) + Convert.ToInt32("0" + textBox1.Text) + Convert.ToInt32("0" + textBox3.Text) + Convert.ToInt32("0" + textBox2.Text)).ToString();
            if (textBox2.Text.Length > 8) { textBox2.Text = textBox2.Text.Remove(8); textBox2.SelectionStart = textBox2.Text.Length; }
        }

        private void Oplata_Load(object sender, EventArgs e)
        {
            nav_clik();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(label6.Text) > -1)
            {
                Program.KASA.kakprodalchek = null;

                int chislo = Convert.ToInt32(label6.Text);
                string obs = Program.KASA.bunifuFlatButton16.Text;

                Program.KASA.method = null;
                if (dolber == false)
                {
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


                    if (Program.KASA.method != null) {

                        Program.main.backblakhide();
                        this.Close();
                        Program.KASA.oplata();

                    }


                    


                }
                else {

                     if (!String.IsNullOrWhiteSpace(Program.dlg.usid))
                         {
                        Program.KASA.method += "INSERT INTO cartbuymet(cbt_cart_id,cbt_by_how,cbt_by_komuis,cbt_sum,cbt_skidon)VALUES(crtid,N$" + dolg.Text + "$,0," + label4.Text + ",N$" + obs + "$);";
                        conoff.Close();
                        conoff.Close();
                        conoff.Open();

                        sqloff = "UPDATE users SET summa = ((select summa from users WHERE us_off_id_date = " + Program.dlg.usid + " )+" + label4.Text + " ),us_date=" + DateTimeOffset.Now.ToUnixTimeSeconds() + " WHERE us_off_id_date = " + Program.dlg.usid + ";";
                        sqloff += "INSERT INTO productoff(pr_text)VALUES(N'UPDATE users SET summa = ((select summa from users WHERE us_off_id_date = " + Program.dlg.usid + " and us_mg_id =" + Global.IDmagaz + " limit 1)+" + label4.Text + " ),us_date=" + DateTimeOffset.Now.ToUnixTimeSeconds() + " WHERE us_off_id_date = " + Program.dlg.usid + ";');";
                        cmdoff = new SqlCommand(sqloff, conoff);
                        droff = cmdoff.ExecuteReader();
                        droff.Read();
                        conoff.Close();
                        conoff.Close();

                        Program.KASA.kakprodalchek += dolg.Text + " : " + Convert.ToInt32(label4.Text).ToString() + "\n";

                        Program.main.backblakhide();
                        this.Close();
                        Program.KASA.oplata();

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

        private void vdolg1_KeyPress(object sender, KeyPressEventArgs e)
        {

           


        }

        private void RED_Click(object sender, EventArgs e)
        {


            color_clear();
            RED.Normalcolor = nal.Activecolor;
            RED.Textcolor = Color.White;
            label5.Text = label4.Text;
            textBox4.Text = label4.Text;
            cena.Visible = false;
            opa = RED.Text;


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label5.Text = (Convert.ToInt32("0" + textBox4.Text) + Convert.ToInt32("0" + textBox1.Text) + Convert.ToInt32("0" + textBox3.Text) + Convert.ToInt32("0" + textBox2.Text)).ToString();
            if (textBox3.Text.Length > 8) { textBox4.Text = textBox4.Text.Remove(8); textBox4.SelectionStart = textBox4.Text.Length; }
        }

        private void bunifuFlatButton12_MouseDown(object sender, EventArgs e)
        {

            if (prin == true) { prinnet(); } else { prinda(); }

         
        }



        void prinda() {

            prin = true;
            bunifuFlatButton12.Normalcolor= Color.FromArgb(67, 181, 129);
            bunifuFlatButton12.OnHovercolor= Color.FromArgb(67, 181, 129);
            bunifuFlatButton12.Activecolor= Color.FromArgb(67, 181, 129);
        }

        void prinnet()
        {
            
            prin = false;
            bunifuFlatButton12.Normalcolor = Color.FromArgb(240, 71, 71);
            bunifuFlatButton12.OnHovercolor = Color.FromArgb(240, 71, 71);
            bunifuFlatButton12.Activecolor = Color.FromArgb(240, 71, 71);

        }



    }
}
