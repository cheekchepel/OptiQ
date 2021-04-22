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

        public ComboBox combrz = new ComboBox();

        private void add(long shtrih)
        {
            kod = shtrih;
        
           new_tov();
              
            



        }


        public void new_tov()
        {


            conoff.Close();
            conoff.Open();
            sqloff = "select pr_name,pr_price_co,pr_price_ca,pr_optom from product where pr_kod=" + kod;
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();

            if (droff.Read())
            {

                textBox1.Text = droff[0].ToString();
                textBox2.Text = droff[1].ToString();
                textBox3.Text = droff[2].ToString();
                textBox4.Text = droff[3].ToString();
                textBox5.Text = "0";
                
            }

            sel_it(0);


            if (comboBox2.Items.Count < 1)
            {

                MessageBox.Show("Товар уже добавлен или не существует");

            }
            else {

                comboBox2.SelectedIndex = 0;
                combrz.SelectedIndex = 0;
                id_rz = Convert.ToInt64(combrz.Text);

                conoff.Open();

                sqloff = "insert into prihod(kod,name,cena_co,cena_ca,cena_opt,rz_id,cena_opt,kol)" +
                    " VALUES ("+kod+",N'"+textBox1.Text+"',"+textBox2.Text+","+textBox3.Text+","+textBox4.Text+","+ combrz.Text + ",0)";
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                droff.Read();
                conoff.Close();

                this.Visible = true;

            }
              


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

            conoff.Close();
            conoff.Open();

            sqloff = " UPDATE prihod SET cena_co =0"+textBox2.Text+",cena_ca=0"+ textBox3.Text + ",cena_opt=0"+ textBox4.Text + ",rz_id="+combrz.Text+",kol=0"+textBox5.Text.Replace(",",".")+"where kod="+kod+ " and rz_id="+id_rz;
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();

            conoff.Close();


        }


        public void zagruz(long kd,string name,string co,string ca,string pr,long rz_id,double kol) {


            kod = kd;
            textBox1.Text = name;
            textBox2.Text = co;
            textBox3.Text = ca;
            textBox4.Text = pr;
            textBox5.Text = kol.ToString().Replace(",",".");

            sel_it(rz_id);

            combrz.Text = rz_id.ToString();

            comboBox2.SelectedIndex = combrz.SelectedIndex;

            Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
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
            timer1.Enabled = false;
            timer1.Enabled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Enabled = true;

            combrz.SelectedIndex = comboBox2.SelectedIndex;

            id_rz =Convert.ToInt64(combrz.Text);

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Enabled = true;
        }

        private void comboBox2_MouseDown(object sender, MouseEventArgs e)
        {


            sel_it(id_rz);

            combrz.Text =id_rz.ToString();

            comboBox2.SelectedIndex = combrz.SelectedIndex;

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
            this.Visible = false;

        }
    }
}
