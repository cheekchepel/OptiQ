using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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


        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);


        public string shtrih=null;

        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;

        fastaddprovid fstadpr = new fastaddprovid();
        private double res;


        string itog;
        string url = "https://barcode-list.ru/barcode/RU/%D0%9F%D0%BE%D0%B8%D1%81%D0%BA.htm?barcode=";

        Image img;
     
        BarcodeWriter qr = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };




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















        public void clear() {


            text1.Text = null;
            text2.Text = null;
            text3.Text = null;
            textopt.Text = null;
            text5.Text = null;
            text6.Items.Clear();
            text7.Text = null;
            text6.Items.Add("Нет");
            text6.Text = "Нет";

            try
            {
                con.Close();
                con.Open();
                sql = "select mp_name from myprov where mp_mg_id = " + Global.IDmagaz;
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    text6.Items.Add(dr[0]);

                }
                con.Close();
            }
            catch (NpgsqlException)
            {
                this.Close();
                Program.main.backblakhide();
                Program.msg.Message.Text = "Необходимо интернет подключение";
                Program.msg.Width = 450;
                Program.msg.Show();
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            rendom();
        }





        public void rendom() {




            Random random = new Random();
            long randomNumber = random.Next(20000000, 29999999);
            try
            {
                con.Close();
                con.Open();
                sql = "select pr_kod from product where pr_mg_id = " + Global.IDmagaz + "and pr_kod = " + randomNumber;
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    con.Close();
                    rendom();

                }
                else { text1.Text = randomNumber.ToString(); }
                con.Close();
            }
            catch (NpgsqlException)
            {
                this.Close();
                Program.main.backblakhide();
                Program.msg.Message.Text = "Необходимо интернет подключение";
                Program.msg.Width = 450;
                Program.msg.Show();
            }



        }

        private void addtovar_Shown(object sender, EventArgs e)
        {
            clear();
            text1.Focus();
            if (shtrih != null) {
                selct(shtrih);
            }
            label3.Visible = Global.pra_showprih;
            text3.Visible = Global.pra_showprih;

            this.Height = panel3.Height + bunifuFlatButton6.Location.Y + 65;

        }

        private void text1_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter&& !String.IsNullOrWhiteSpace(text1.Text))
            {
                
                selct(text1.Text);

            }
        }



        public void selct(string kod) {


            try
            {
               
                text2.Text = null;
                text3.Text = null;
                textopt.Text = null;
                text5.Text = null;
                text6.Text = "Нет";
                text7.Text = null;
              

                con.Open();
                sql = "select * from product where pr_kod =" + kod + "and pr_mg_id=" + Global.IDmagaz;
                cmd = new NpgsqlCommand(sql, con);

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    text1.Text = kod.ToString();
                    text2.Text = dr["pr_name"].ToString();
                    text3.Text = dr["pr_price_co"].ToString();
                    text5.Text = dr["pr_price_ca"].ToString();
                    textopt.Text = text5.Text;
                    text6.Text = dr["pr_provid"].ToString();
                    text7.Text = dr["pr_piec"].ToString().Replace(",",".");
                    if (Convert.ToInt32(dr["pr_optom"]) != 0) {
                        textopt.Text = dr["pr_optom"].ToString();
                    }
                        
                }
                else
                {


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
                            sql = "INSERT INTO allpruduct(al_kod,al_name)VALUES(" + kod + ",'" + text2.Text + "')";
                            cmd = new NpgsqlCommand(sql, con);
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            con.Close();
                        }
                        catch { }
                    }



                }
                con.Close();
            }
            catch (NpgsqlException)
            {
                this.Close(); Program.main.backblakhide();
                Program.msg.Message.Text = "Необходимо интернет подключение";
                Program.msg.Width = 450;
                Program.msg.Show();
            }

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
            bool isInt = Double.TryParse(text7.Text.Replace(".", ",") + "0", out res);
            try { 
            if (!String.IsNullOrWhiteSpace(text1.Text) && !String.IsNullOrWhiteSpace(text2.Text) && !String.IsNullOrWhiteSpace(text5.Text) && !String.IsNullOrWhiteSpace(text6.Text) && !String.IsNullOrWhiteSpace(text7.Text)  && isInt == true)         
            {
                    int priha =Convert.ToInt32(0 + text3.Text);
                    int opti = Convert.ToInt32(0 + textopt.Text);
                    if (opti ==0) {
                        opti= Convert.ToInt32(0 + text5.Text);
                    }

                con.Open();
                sql = "select * from product where pr_mg_id =" + Global.IDmagaz + "and pr_kod=" + text1.Text;
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                if (dr.Read()) {

                    con.Close();
                    con.Open();
                        sql = Global.versia;
                    sql += "UPDATE product Set pr_mg_id="+Global.IDmagaz+",pr_kod=" + text1.Text + ", pr_name='" + text2.Text + "',pr_price_co=" + priha + ",pr_price_ca=" + text5.Text + ",pr_provid='"+text6.Text+"',pr_fact_co=" + priha + ",pr_piec=" + Convert.ToString(Convert.ToDouble(text7.Text.Replace(".", ","))).Replace(",", ".")+ ",pr_optom="+ opti + " WHERE pr_kod =" + text1.Text;
                    cmd = new NpgsqlCommand(sql, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    con.Close();
                    

                }
                else
                {


                    con.Close();
                    con.Open();
                        sql = Global.versia;
                        sql += "INSERT INTO product(pr_mg_id,pr_kod,pr_name,pr_price_co,pr_price_ca,pr_fact_co,pr_provid,pr_piec,pr_optom)VALUES(" + Global.IDmagaz+"," + text1.Text+",'"+text2.Text+"',"+ priha + ","+text5.Text+","+ priha + ",'"+text6.Text+"',"+ Convert.ToString(Convert.ToDouble(text7.Text.Replace(".", ","))).Replace(",", ".") + ","+ opti + ")";
                    cmd = new NpgsqlCommand(sql, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    con.Close();
                    
                  
                }





              




                con.Close();
                Program.main.backblakhide();
                Program.tov.zagrsel();
                Program.tov.viewcell();
                this.Close();
   
            
                }
        }
            catch (NpgsqlException)
            {
                this.Close();
        Program.main.backblakhide();
                Program.msg.Message.Text = "Необходимо интернет подключение";
                Program.msg.Width = 450;
                Program.msg.Show();
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

        private void text7_KeyPress(object sender, KeyPressEventArgs e)
        {

           
            int indexOfChar = text7.Text.IndexOf('.');

            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != '.') // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
            else {

                if (number == '.' && indexOfChar != -1) { e.Handled = true; }
            
            }
        }

        private void text4_Leave(object sender, EventArgs e)
        {


            

            if (!String.IsNullOrWhiteSpace(text3.Text)&& !String.IsNullOrWhiteSpace(textopt.Text)) {


                text5.Text = (((Convert.ToInt32(text3.Text))/100)*(100+(Convert.ToInt32(textopt.Text)))).ToString() ;

            }


        }

     

        private void text3_OnValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(text3.Text))
            {

                text3.Text = (Convert.ToInt32(text3.Text)).ToString();
            }

           

        }

        private void text4_OnValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textopt.Text) > Convert.ToInt32(text5.Text)) {

                textopt.Text = text5.Text;


            }

        }

        private void text2_Enter(object sender, EventArgs e)
        {
            klava_clok();
            shjowkeyboard2.Visible = true;
        }

        public void klava_clok() {

            shjowkeyboard1.Visible = false;
            shjowkeyboard2.Visible = false;
            shjowkeyboard3.Visible = false;
            shjowkeyboard4.Visible = false;
            shjowkeyboard5.Visible = false;
            
        }

        private void text3_Enter(object sender, EventArgs e)
        {
            klava_clok();
            shjowkeyboard3.Visible = true;
        }

        private void text4_Enter(object sender, EventArgs e)
        {
            klava_clok();
            shjowkeyboard4.Visible = true;
        }

        private void text5_Enter(object sender, EventArgs e)
        {
            klava_clok();
            shjowkeyboard5.Visible = true;
        }

        private void text7_Enter(object sender, EventArgs e)
        {
            klava_clok();
            shjowkeyboard1.Visible = true;
        }

        private void text5_Leave(object sender, EventArgs e)
        {
            //if (!String.IsNullOrWhiteSpace(text3.Text) && !String.IsNullOrWhiteSpace(text5.Text) && Convert.ToInt32(text5.Text) > 0)
            //{
            //    if (Convert.ToInt32(text5.Text) < Convert.ToInt32(text3.Text)) {

            //        text5.Text = text3.Text;


            //    }

            //    int a = (Convert.ToInt32(text3.Text)) / 100;
            //    if (a < 1) { a = 1; }
            //    int b = (Convert.ToInt32(text5.Text) / a);


            //    text4.Text = (b - 100).ToString();





            //}
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
    }
}
