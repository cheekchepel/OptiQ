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
using WindowsInput;
using WindowsInput.Native;

namespace OptiQ
{
    public partial class dolgi : Form
    {
        InputSimulator Simulator = new InputSimulator();

        public dolgi()
        {
            InitializeComponent();
        }

        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;

        public SqlCommand cmdoff;
        public SqlDataReader droff;

        int index = 0;


        private void dolgi_Load(object sender, EventArgs e)
        {

            this.Location = new Point(Global.x - this.Width, 0); ;
            this.Height = Global.y + 40;
            zagrizka();

            label4.Text = "Не выбран";
            label3.Text = "0";
            label5.Text = "0";
            index = -1;
            act = false;
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Program.main.backblakhide();
            this.Close();
        }




        bool act =false;




        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }









        public void zagrizka()
        {
            //usid = null;
            grdt_kass.Rows.Clear();

            conoff.Close();
            conoff.Open();
            sqloff = "select us_off_id,us_name,us_danie,us_summa,us_date from users_pro where us_mg_id=" + Global.IDmagaz+" and (LOWER(us_name) LIKE LOWER(N'%" + textBox2.Text + "%'))";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            while (droff.Read())
            {

                grdt_kass.Rows.Add(droff[0], droff[1], droff[2], droff[3], UnixTimeStampToDateTime(Convert.ToInt64(droff[4])));

            }
            conoff.Close();


        }








        private void bunifuFlatButton3_MouseDown(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Focus();
            Simulator.Keyboard.TextEntry(bunifuFlatButton3.Text);

        }

        private void bunifuFlatButton1_MouseDown(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Focus();
            Simulator.Keyboard.TextEntry(bunifuFlatButton1.Text);
        }

        private void bunifuFlatButton2_MouseDown(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Focus();
            Simulator.Keyboard.TextEntry(bunifuFlatButton2.Text);
        }

        private void bunifuFlatButton4_MouseDown(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Focus();
            Simulator.Keyboard.TextEntry(bunifuFlatButton4.Text);
        }

        private void bunifuFlatButton5_MouseDown(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Focus();
            Simulator.Keyboard.TextEntry(bunifuFlatButton5.Text);
        }

        private void bunifuFlatButton8_MouseDown(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Focus();
            Simulator.Keyboard.TextEntry(bunifuFlatButton8.Text);
        }

        private void bunifuFlatButton9_MouseDown(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Focus();
            Simulator.Keyboard.TextEntry(bunifuFlatButton9.Text);
        }

        private void bunifuFlatButton10_MouseDown(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Focus();
            Simulator.Keyboard.TextEntry(bunifuFlatButton10.Text);
        }

        private void bunifuFlatButton11_MouseDown(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Focus();
            Simulator.Keyboard.TextEntry(bunifuFlatButton11.Text);
        }

        private void bunifuFlatButton12_MouseDown(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Focus();
            Simulator.Keyboard.TextEntry(bunifuFlatButton12.Text);
        }

        private void bunifuFlatButton13_MouseDown(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Focus();
            Simulator.Keyboard.KeyPress(VirtualKeyCode.BACK);
        }

        private void grdt_kass_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (grdt_kass.Rows.Count > 0)
            {
                index = grdt_kass.CurrentRow.Index;
                vibor();
            }
            else { act = false; }



        }



        public void vibor() {

            if (index >= 0 && grdt_kass.Rows.Count > 0)
            {
                label5.Text = (grdt_kass.Rows[index].Cells[0].Value).ToString();

                label4.Text = (grdt_kass.Rows[index].Cells[1].Value).ToString();
                label3.Text = (grdt_kass.Rows[index].Cells[3].Value).ToString();
                textBox1.Text = (grdt_kass.Rows[index].Cells[3].Value).ToString();
            }
            else { act = false; }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
                zagrizka();
                vibor();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {

                if (Convert.ToInt32(textBox1.Text) > Convert.ToInt32(label3.Text))
                {
                    act = false;
                    textBox1.Text = label3.Text;
                    
                    


                }
                else
                {


                    act = true;
                    if (label5.Text == "0") { act = false; }
                }
            }
            else { act = false; }

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

            if (act == true) {


                long date = DateTimeOffset.Now.ToUnixTimeSeconds();



                conoff.Close();
                conoff.Open();
                sqloff = "update users_pro set us_summa=(select us_summa from users_pro where us_off_id=" + label5.Text+")-"+textBox1.Text+",us_date = "+ date + " where us_off_id =" + label5.Text+";";
                sqloff+= "INSERT INTO productoff(pr_text)VALUES(N'"+ Global.versia + sqloff+"')";
 
                 cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                droff.Read();
                
                                                  
                conoff.Close();

                zagrizka();
                Program.main.backblakhide();
                this.Close();


            }

        }

        private void dolgi_KeyPress(object sender, KeyPressEventArgs e)
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
    }    

    
}
