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
    public partial class prihodcell : UserControl
    {
        public prihodcell()
        {
            InitializeComponent();
        }

        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;

        public SqlCommand cmdoff;
        public SqlDataReader droff;




        public SqlConnection conoff1 = new SqlConnection(Global.conectsql);

        public string sqloff1;

        public SqlCommand cmdoff1;
        public SqlDataReader droff1;


        public long kod = 0;
        public long id_rz = 0;

        public bool selcehk=false;

        public ComboBox combrz = new ComboBox();

        public void add(long shtrih)
        {
           
            kod = shtrih;
        
           new_tov();
              
            



        }


        public void new_tov()
        {

         

            string name=null;
            string co=null;
            string ca=null;
            string opt=null;
            string rz = null;


            conoff.Close();
            conoff.Open();
            sqloff = "select pr_name,pr_price_co,pr_price_ca,pr_optom from product_pro where pr_kod=" + kod;
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();

            if (droff.Read())
            {

                name = droff[0].ToString();
                co = droff[1].ToString();
                ca = droff[2].ToString();
                opt = droff[3].ToString();

             
            }
            else {

                MessageBox.Show("Товар не существует");

                return;

            }
          

           
            conoff.Close();
            conoff.Open();

            sqloff = "select rz_id from razmer_pro where rz_pr_kod=" + kod + "" +
                " and not rz_id in (select rz_id from prihod where kod=" + kod + ")";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();

            if (droff.Read())
            {
                rz = droff[0].ToString();

            }
            else {
            
                MessageBox.Show("Товар уже добавлен или не существует");
                return;
            }




                conoff.Close();
                conoff.Open();

                sqloff = "insert into prihod(kod,name,cena_co,cena_ca,cena_opt,rz_id,kol)" +
                    " VALUES ("+kod+",N'"+ name + "',"+ co + ","+ ca + ","+ opt + ","+ rz + ",0)";
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                droff.Read();
                conoff.Close();


            
            


        }



        public void sel_it(long id) {


            conoff.Close();
            conoff.Open();

            sqloff = "select rz_name,rz_id from razmer_pro where rz_pr_kod=" + kod + "" +
                " and (rz_id="+ id + " or not rz_id in (select rz_id from prihod where kod=" + kod + "))";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            comboBox2.Items.Clear();
            combrz.Items.Clear();
            while (droff.Read())
            {

                comboBox2.Items.Add(droff[0].ToString());
                combrz.Items.Add(droff[1].ToString());

            }

            conoff.Close();



        }




        public void update() {

           
                conoff.Close();
                conoff.Open();


                sqloff = " UPDATE prihod SET cena_co =0" + textBox2.Text + ",cena_ca=0" + textBox3.Text + ",cena_opt=0" + textBox4.Text + ",rz_id=" + combrz.Text + ",kol=0" + textBox5.Text.Replace(",", ".") + "where kod=" + kod + " and rz_id=" + id_rz;
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();

                conoff.Close();
            
            
        }




      




        public void zagruz(long kd,string name,string co,string ca,string pr,long rz_id,double kol) {

            id_rz = 0;

            kod = kd;
            textBox1.Text = name;
            textBox2.Text = co;
            textBox3.Text = ca;
            textBox4.Text = pr;
            textBox5.Text = kol.ToString().Replace(",",".");

            sel_it(rz_id);

            combrz.Text = rz_id.ToString();

            comboBox2.SelectedIndex = combrz.SelectedIndex;

            this.Visible = true;
            selcehk = true;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToInt32("0" + textBox2.Text).ToString();
            textBox2.SelectionStart = textBox2.Text.Length;
            timer1.Enabled = false;
            timer1.Enabled = true;

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            update();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToInt32("0" + textBox3.Text).ToString();
            textBox3.SelectionStart = textBox3.Text.Length;
            timer1.Enabled = false;
            timer1.Enabled = true;
          
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToInt32("0" + textBox4.Text).ToString();
            textBox4.SelectionStart = textBox4.Text.Length;
            timer1.Enabled = false;
            timer1.Enabled = true;
           
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
         

            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.SelectionStart = textBox5.Text.Length;
            timer1.Enabled = false;
            timer1.Enabled = true;
          
            
        }

        private void comboBox2_MouseDown(object sender, MouseEventArgs e)
        {



        }

        private void delete_Click(object sender, EventArgs e)
        {

            conoff.Close();
            conoff.Open();

            conoff.Close();
            conoff.Open();

            sqloff = "delete from prihod where kod="+kod+" and rz_id="+id_rz;
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();

            conoff.Close();
            Program.zakup.select();
            

        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
         

            combrz.SelectedIndex = comboBox2.SelectedIndex;
                  
                update();

            
            id_rz = Convert.ToInt64(combrz.Text);  

          
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
         

            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

           

            int indexOfChar = textBox5.Text.IndexOf('.');

            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != '.') // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
            else
            {

                if (number == '.' && indexOfChar != -1) { e.Handled = true; }

            }
        }

        
    }
}
