using Npgsql;
using OptiQ.OBSHIE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptiQ
{
    public partial class revizia : Form
    {
        public revizia()
        {
            InitializeComponent();
            Program.revix = this;
        }

        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);

        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;

        public NpgsqlConnection con2 = new NpgsqlConnection(Global.conectpost);

        public string sql2;
        public NpgsqlCommand cmd2;
        public NpgsqlDataReader dr2;


        public DataTable dtSales = new DataTable();

        public Yesandno yan = new Yesandno();


       public int id_rev_care =0;

        long id_date_start = 0;




        private void close_Click(object sender, EventArgs e)
        {
            Program.main.backblakhide();
            this.Close();


        }

        revcell[] sel = new revcell[100];

        public void poiskrwv()
        {
            try { 
            dtSales.Rows.Clear();
            con.Close();
            con.Open();
            sql = "select itogrevcard_id_pr,itogrevcard_date_start from itogrevcard where itogrevcard_date_end =0 and itogrevcard_mg_id="+Global.IDmagaz;
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                bunifuFlatButton6.Visible = false;
                bunifuFlatButton7.Visible = true;
                bunifuFlatButton8.Visible = true;
                panel2.Visible = true;
                flowLayoutPanel3.Visible = true;

                id_rev_care =Convert.ToInt32( dr[0]);
                id_date_start = Convert.ToInt64(dr[1]);

                textBox2.Text = (UnixTimeToDateTime(id_date_start)).ToString();
                con.Close();
                con.Open();
                sql = "select rev_kod_pr,rev_name_pr,rev_kol_bilo,rev_kol_stalo,rz_name from revizia where id_rev_cart=" + id_rev_care;
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                while (dr.Read()) {


                    dtSales.Rows.Add(dr[0],dr[1], dr[2], dr[3],Convert.ToInt32(dr[3])- Convert.ToInt32(dr[2]),dr[4]);


                    



                }

                con.Close();




            }
            else {

                bunifuFlatButton6.Visible = true;
                bunifuFlatButton7.Visible = false;
                bunifuFlatButton8.Visible = false;
                panel2.Visible = false;
                flowLayoutPanel3.Visible = false;

            }
        }
            catch (NpgsqlException)
            {
                this.Hide();
        Program.main.KASSA_view();
                Program.msg.Message.Text = "Необходимо интернет подключение";
                Program.msg.Width = 450;
                Program.msg.Show();

            }
}

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {

        }



        public DateTime UnixTimeToDateTime(long unixtime)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            return dtDateTime;
        }

        private void revizia_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

           
         

            if (!Char.IsDigit(number) && number != 8 && number != '.'&& number!=(char)Keys.Enter) // цифры, клавиша BackSpace и запятая
            {
                if (number == '$' || number == '%' || number == ',' || number == Convert.ToChar("'")) // цифры, клавиша BackSpace и запятая
                {
                    e.Handled = true;
                }
            }
        }






        public void viewcell()
        {



            flowLayoutPanel4.Visible = false;
            for (int i = 99; i >= 0; i--)
            {
                if (i < dtSales.Rows.Count)
                {
                    sel[i].ID = i;
                    flowLayoutPanel4.Controls.Add(sel[i]);
                }
                else
                {
                    sel[i].Visible = false;
                }
            }
            flowLayoutPanel4.Visible = true;
        }



        public void createcell()
        {

            for (int i = 0; i < 100; i++)
            {

                sel[i] = new revcell();
                sel[i].ID = i;

                

            }

        }

        private void revizia_Load(object sender, EventArgs e)
        {
            try
            {
                dtSales.Columns.Add("rev_kod_pr", typeof(string));
                dtSales.Columns.Add("rev_name_pr", typeof(string));
                dtSales.Columns.Add("rev_kol_bilo", typeof(string));
                dtSales.Columns.Add("rev_kol_stalo", typeof(string));
                dtSales.Columns.Add("raznica", typeof(string));
                dtSales.Columns.Add("rz_name", typeof(string));
                createcell();
            }
            catch { }
            this.Width = 924;
            this.Height = 668;


        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox5.Text)&& !String.IsNullOrWhiteSpace(textBox3.Text)&& !String.IsNullOrWhiteSpace(textBox4.Text))
            {
               int ket = 0;
                int da = 1;
                try { 
                while (ket < dtSales.Rows.Count) {

                    if (textBox1.Text == dtSales.Rows[ket][0].ToString()&& comboBox2.Text == dtSales.Rows[ket][5].ToString())
                    {
                        Global.yesno = false;
                        yan.ShowDialog();
                        if (Global.yesno == true)
                        {
                            dtSales.Rows.RemoveAt(ket);
                            dtSales.Rows.Add(textBox1.Text, textBox3.Text, textBox4.Text, textBox5.Text, Convert.ToDouble(textBox4.Text.Replace(".", ",")) - Convert.ToDouble(textBox5.Text.Replace(".", ",")), comboBox2.Text); ;
                            viewcell();

                            con.Close();
                            con.Open();
                            sql = "delete from revizia where  rz_name='"+ comboBox2.Text + "' and rev_kod_pr=" + textBox1.Text + " and id_rev_cart =" + id_rev_care + "; INSERT INTO revizia(rev_kod_pr,rev_name_pr,rev_kol_bilo,rev_kol_stalo,rz_name,id_rev_cart)VALUES(" + textBox1.Text + ",'" + textBox3.Text + "'," + textBox4.Text.Replace(",", ".") + "," + textBox5.Text.Replace(",", ".") + ",'" + comboBox2.Text + "'," + id_rev_care + ")";
                            cmd = new NpgsqlCommand(sql, con);
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            con.Close();
                        }
                        da = 0;

                    }
                  

                    ket++;
                
                }
                if (da==1)
                {


                    dtSales.Rows.Add(textBox1.Text, textBox3.Text, textBox4.Text, textBox5.Text, Convert.ToDouble(textBox4.Text) - Convert.ToDouble(textBox5.Text), comboBox2.Text);
                    viewcell();

                    con.Close();
                    con.Open();
                    sql = "INSERT INTO revizia(rev_kod_pr,rev_name_pr,rev_kol_bilo,rev_kol_stalo,rz_name,id_rev_cart)VALUES(" + textBox1.Text + ",'" + textBox3.Text + "'," + textBox4.Text.Replace(",", ".") + "," + textBox5.Text.Replace(",", ".") + "," + comboBox2.Text + "," + id_rev_care + ")";
                    cmd = new NpgsqlCommand(sql, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    con.Close();

                }
          


            textBox1.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox1.Focus();
                }
                catch (NpgsqlException)
                {
                    this.Hide();
                    Program.main.KASSA_view();
                    Program.msg.Message.Text = "Необходимо интернет подключение";
                    Program.msg.Width = 450;
                    Program.msg.Show();

                }
            }

        }

        private void revizia_Shown(object sender, EventArgs e)
        {
           
            poiskrwv();
            viewcell();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            try { 
            con.Close();
            con.Open();
            sql = "INSERT INTO itogrevcard(itogrevcard_mg_id,itogrevcard_date_start,itogrevcard_date_end )VALUES("+Global.IDmagaz+","+ DateTimeOffset.Now.ToUnixTimeSeconds() + ",0)";
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();
            poiskrwv();
        }
            catch (NpgsqlException)
            {
                this.Hide();
        Program.main.KASSA_view();
                Program.msg.Message.Text = "Необходимо интернет подключение";
                Program.msg.Width = 450;
                Program.msg.Show();

            }
}

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter && !String.IsNullOrWhiteSpace(textBox1.Text))
            {
                
                selct();
                textBox5.Focus();
            }

        }



        public void selct() {
            

            string namet = "";

            comboBox2.Items.Clear();

            con.Close();
            con.Open();
            sql = "select pr_name,rz_name from product_pro LEFT JOIN razmer_pro ON crt_off_id=cbt_cart_id where pr_kod =" + textBox1.Text + "and pr_mg_id=" + Global.IDmagaz;
            cmd = new NpgsqlCommand(sql, con);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {


                namet=dr["pr_name"].ToString();

                comboBox2.Items.Add(dr["rz_name"].ToString());



            }

            if (comboBox2.Items.Count < 1) {

                textBox1.Text = null;
                textBox2.Text = null;
               
                return;
            
            }

            textBox2.Text = namet;


            con.Close();

          
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {

            try { 
            con.Close();
            con.Open();
            sql = "DELETE FROM itogrevcard WHERE itogrevcard_id_pr =" + id_rev_care ;
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();

            poiskrwv();
            viewcell();
        }
            catch (NpgsqlException)
            {
                this.Hide();
        Program.main.KASSA_view();
                Program.msg.Message.Text = "Необходимо интернет подключение";
                Program.msg.Width = 450;
                Program.msg.Show();

            }

}

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            try { 
       

                con.Close();
                con.Open();
                sql = "select rev_kod_pr,rev_name_pr,rz_name,rev_kol_bilo,rev_kol_stalo from revizia where id_rev_cart=" + id_rev_care;
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                string cho = "";
                long a = Convert.ToInt64(dr[4])- Convert.ToInt64(dr[3]);
                if (a >= 0) { cho = "+"; } else { cho = ""; }
                    string rzname = dr[2].ToString();
                long kod = Convert.ToInt64(dr[0]);
                  con2.Close();
                     con2.Open();
                    sql2 = "UPDATE razmer_pro Set rz_pies= (Select pr_piec where pr_kod=" + kod+" and pr_mg_id = "+Global.IDmagaz+")"+cho+"" + a + "  WHERE pr_kod =" + kod + " and pr_mg_id=" + Global.IDmagaz + "RETURNING pr_id";
                    cmd2 = new NpgsqlCommand(sql2, con2);
                    dr2 = cmd2.ExecuteReader();
                    dr2.Read();
                 

                    con2.Close();






                }

                con.Close();




            





            con.Close();
            con.Open();
                sql = Global.versia;
            sql += "UPDATE itogrevcard Set itogrevcard_date_end=" + DateTimeOffset.Now.ToUnixTimeSeconds() + "  WHERE itogrevcard_id_pr =" + id_rev_care;
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();
            poiskrwv();
            viewcell();





        }
            catch (NpgsqlException)
            {
                this.Hide();
        Program.main.KASSA_view();
                Program.msg.Message.Text = "Необходимо интернет подключение";
                Program.msg.Width = 450;
                Program.msg.Show();

            }




}

    

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {

            dtSales.Rows.Clear();
            con.Close();
            con.Open();
            sql = "select rz_pies from razmer_pro where rz_pr_kod="+textBox1.Text+" and rz_mg_id="+Global.IDmagaz;
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
            
            
            
            }

        }
    }
}
