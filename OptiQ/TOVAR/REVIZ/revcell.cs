using Npgsql;
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
    public partial class revcell : UserControl
    {
        public revcell()
        {
            InitializeComponent();
        }




        public SqlConnection conoff1 = new SqlConnection(Global.conectsql);

        public string sqloff1;

        public SqlCommand cmdoff1;
        public SqlDataReader droff1;


        public long kod = 0;
        public long id_rz = 0;

   

        public ComboBox combrz = new ComboBox();

        public void add(long shtrih)
        {

            kod = shtrih;




        }







        public void zagruz(long kd, string name, long rz_id, string bilo, string stalo)
        {

            id_rz = 0;

            kod = kd;

            textBox1.Text = name;
            textBox2.Text = bilo.Replace(",", "."); ;
            textBox3.Text = stalo.Replace(",", "."); ;
        //    textBox4.Text = (Convert.ToDouble(bilo)-Convert.ToDouble(stalo)).ToString().Replace(",",".");

            id_rz = rz_id;

            sel_it(rz_id);

            combrz.Text = rz_id.ToString();

            comboBox2.SelectedIndex = combrz.SelectedIndex;

            this.Visible = true;


        }















        public void sel_it(long id)
        {


            conoff1.Close();
            conoff1.Open();

            sqloff1 = "select rz_name,rz_id from razmer_pro where rz_pr_kod=" + kod + "" +
                " and (rz_id=" + id + " or not rz_id in (select rz_id from reviz where kod=" + kod + "))";
            cmdoff1 = new SqlCommand(sqloff1, conoff1);
            droff1 = cmdoff1.ExecuteReader();
            comboBox2.Items.Clear();
            combrz.Items.Clear();
            while (droff1.Read())
            {

                comboBox2.Items.Add(droff1[0].ToString());
                combrz.Items.Add(droff1[1].ToString());

            }

            conoff1.Close();



        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.SelectionStart = textBox4.Text.Length;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            update();
        }




        public void update()
        {


            conoff1.Close();
            conoff1.Open();


            sqloff1 = " UPDATE reviz SET stalo=0" + textBox3.Text.Replace(",", ".") + "where kod=" + kod + " and rz_id=" + id_rz;
            cmdoff1 = new SqlCommand(sqloff1, conoff1);
            droff1 = cmdoff1.ExecuteReader();

            conoff1.Close();

        }



   

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;


            update2();


            Program.revix.select();
        }



        public void update2()
        {


            conoff1.Close();
            conoff1.Open();
            sqloff1 = " UPDATE reviz SET rz_id=" + combrz.Text + ",bilo=(select rz_pies from razmer_pro where rz_pr_kod=" + kod + " and  rz_id  =" + combrz.Text+ "),stalo=0, where kod = " + kod + " and rz_id = " + id_rz + ";";
            cmdoff1 = new SqlCommand(sqloff1, conoff1);
            droff1 = cmdoff1.ExecuteReader();

            conoff1.Close();


        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            combrz.SelectedIndex = comboBox2.SelectedIndex;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            double bil = Convert.ToDouble(textBox2.Text.Replace(".", ","));
            double stal = Convert.ToDouble("0"+textBox3.Text.Replace(".", ","));

            textBox4.Text = (bil - stal).ToString().Replace(",",".");

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            int indexOfChar = textBox3.Text.IndexOf('.');

            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != '.') // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
            else
            {

                if (number == '.' && indexOfChar != -1) { e.Handled = true; }


                timer1.Enabled = false;
                timer1.Enabled = true;



            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            conoff1.Close();
            conoff1.Open();

            conoff1.Close();
            conoff1.Open();

            sqloff1 = "delete from reviz where kod=" + kod + " and rz_id=" + id_rz;
            cmdoff1 = new SqlCommand(sqloff1, conoff1);
            droff1 = cmdoff1.ExecuteReader();

            conoff1.Close();
            Program.revix.bunifuVTrackbar1.Value = 0;
            Program.revix.select();
        }
    }
}