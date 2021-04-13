using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace OptiQ
{
    public partial class add : Form
    {
        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);



        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;




        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;
        public SqlCommand cmdoff;
        public SqlDataReader droff;


        string itog;
        string url = "https://barcode-list.ru/barcode/RU/%D0%9F%D0%BE%D0%B8%D1%81%D0%BA.htm?barcode=";












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















        public string id;
        private object keyboardProc;

        public string ID
        {
            get { return id; }
            set { id = value; poisc(); }

        }




        void poisc() {
            try
            {
                textBox1.Text = null;
                textBox2.Text = null;
                textBox2.Focus();

                var qe = (HttpWebRequest)WebRequest.Create(url + id);
                using (HttpWebResponse response = (HttpWebResponse)qe.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {

                    itog = reader.ReadToEnd();

                }



                int dva = itog.IndexOf(" - Штрих-код:");


                textBox2.Focus();
                if (dva > 0)
                {

                    itog = itog.Remove(dva);

                    int odin = itog.IndexOf("<title>");

               

                    itog = itog.Remove(0, odin + 7);

                    textBox2.Text = itog.Replace(",", ".");


                   

                    try
                    {
                        con.Close();
                        con.Open();
                        sql = "INSERT INTO allpruduct(al_kod,al_name)VALUES(" + id + ",'" + textBox2.Text + "')";
                        cmd = new NpgsqlCommand(sql, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        con.Close();
                    }
                    catch { }


                }
                else { textBox2.Text = null; textBox2.Focus(); keynum(); }

            }catch{ textBox2.Focus(); }
       



        }




        void keynum() {

            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string keyboardPath = Path.Combine(progFiles, "TabTip.exe");

            this.keyboardProc = Process.Start(keyboardPath);


        }




        public add()
        {
            InitializeComponent();
            Program.ad = this;
        }

        

        

        private void save_Click(object sender, EventArgs e)
        {
            
            

        }

      

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.main.backblakhide();
            Program.KASA.textBox1.Text = null;
        }

  

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = (Convert.ToInt32(textBox1.Text)).ToString();
                if (textBox1.Text.Length > 6)
                    textBox1.Text = textBox1.Text.Remove(6);
            }
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {


            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox2.Text))
            { }
            else
            {



                conoff.Close();
                conoff.Open();
                sqloff = "INSERT INTO product(pr_name,pr_price_ca,pr_kod,pr_fact_co,pr_piec)VALUES(N'" + textBox2.Text + "'," + textBox1.Text + "," + id + ",0,0);";
                sqloff += "INSERT INTO productoff(pr_text)VALUES(N'"+ Global.versia + "INSERT INTO product(pr_mg_id,pr_name,pr_price_co,pr_price_ca,pr_provid,pr_piec,pr_kod,pr_fact_co)" +
                    "VALUES(" + Global.IDmagaz + ",N$" + textBox2.Text + "$,0," + textBox1.Text + ",0,0," + id + ",0);');";
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                droff.Read();
                conoff.Close();

                Program.KASA.kassa_pulus();
                Program.main.backblakhide();
                this.Close();






            }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            string opa = "'";
            if (number == '$' || number == '%' || number == ',' || number == Convert.ToChar(opa)) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
