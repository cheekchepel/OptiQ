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
    public partial class edittovar : Form
    {
        public edittovar()
        {
            InitializeComponent();
        }



        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;
    
        public SqlCommand cmdoff;
        public SqlDataReader droff;











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















        public string kod;
        double res;
        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Program.main.backblakhide();
            this.Close();
        }

        private void edittovar_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 ) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }

        }

        private void edittovar_Shown(object sender, EventArgs e)
        {
            textBox1.Clear();

            textBox1.Focus();

            label1.Text = (Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[1].Value).ToString();

            kod = (Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[0].Value).ToString();




        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {   
            




            bool isInt = Double.TryParse(textBox1.Text.Replace(".", ",") + "0", out res);

            if(isInt==true&&!String.IsNullOrWhiteSpace(textBox1.Text)&&Convert.ToDouble(textBox1.Text) >0) 
            {







                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[2].Value = Convert.ToDouble(textBox1.Text);

                double cena = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[2].Value);
                double kol = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);
                string skidka_str = Convert.ToString(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[5].Value);

                if (skidka_str == "0")
                    Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = cena * kol;
                else if (skidka_str.Length > 0 && skidka_str[skidka_str.Length - 1] == '%')
                {
                    double skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 1));
                    Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = (cena * kol) * (1 + skidka / 100);
                }
                else if (skidka_str.Length > 0 && skidka_str[skidka_str.Length - 1] == '.')
                {
                    double skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 4));
                    Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = (cena + skidka) * kol;
                }
                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = Convert.ToInt64(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value);
                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[7].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[3].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);
                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[8].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[9].Value) - Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);

               







                conoff.Close();
                conoff.Open();
                 sqloff = "UPDATE product set pr_price_ca =" + textBox1.Text + "WHERE pr_kod =" + kod;
                sqloff += " INSERT INTO productoff(pr_text)VALUES(N'"+ Global.versia + "UPDATE product set pr_price_ca = " + textBox1.Text + " WHERE pr_kod = " + kod + " and pr_mg_id="+Global.IDmagaz+"')";
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader(); 
                droff.Read();
                conoff.Close();




                Program.main.backblakhide();
             
                this.Close();
                Program.KASA.summa();
            }
           


        }

        private void edittovar_Load(object sender, EventArgs e)
        {
            this.Top = Program.KASA.panel1.Top - this.Height + 40;
            this.Left = Global.x - this.Width - 307;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
