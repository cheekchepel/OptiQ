using Npgsql;
using OptiQ.OBSHIE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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


        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;

        public SqlCommand cmdoff;
        public SqlDataReader droff;


        int raz = 0;

        public int count = 0;


        public int id_rev_care =0;

        long id_date_start = 0;




        private void close_Click(object sender, EventArgs e)
        {
            Program.main.backblakhide();
            this.Close();


        }

        revcell[] sel = new revcell[14];

        public void poiskrwv()
        {
            try { 
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
                    flowLayoutPanel4.Visible = true;
                    flowLayoutPanel3.Visible = true;
                   

                    id_rev_care =Convert.ToInt32( dr[0]);
                id_date_start = Convert.ToInt64(dr[1]);
                    textBox7.Enabled = true;

                    textBox2.Text = (UnixTimeToDateTime(id_date_start)).ToString();
    



            }
            else {


                    conoff.Close();
                    conoff.Open();
                    sqloff = "delete from reviz;";
                    cmdoff = new SqlCommand(sqloff, conoff);
                    droff = cmdoff.ExecuteReader();
                    droff.Read();
                    conoff.Close();


                    textBox7.Enabled = false;
                    bunifuFlatButton6.Visible = true;
                bunifuFlatButton7.Visible = false;
                bunifuFlatButton8.Visible = false;
                panel2.Visible = false;
                flowLayoutPanel3.Visible = false;
                flowLayoutPanel4.Visible = false;

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
            string opa = "'";

            if (number == '$' || number == '%' || number == ',' || number == Convert.ToChar(opa)) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }


        }






   




        private void revizia_Shown(object sender, EventArgs e)
        {
            bunifuVTrackbar1.Value = 0;
            poiskrwv();
            select();
            if (count > 13)
            {
                bunifuVTrackbar1.MaximumValue = (count - 12);
                bunifuVTrackbar1.Visible = true;
            }
            else
            {

                bunifuVTrackbar1.Visible = false;

            }
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




                conoff.Close();
                conoff.Open();
                sqloff = "delete from reviz;";
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                droff.Read();
                conoff.Close();





                poiskrwv();

                select();
                bunifuVTrackbar1.Visible = false;

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


            string zaprosoff = null;
            string zaprosonl = null;


            conoff.Close();
            conoff.Open();
            sqloff = "select kod,name,(select rz_name from razmer_pro  where rz_pr_kod=kod and rz_id=c.rz_id ),bilo,stalo,c.rz_id from reviz c where crt_id=" + id_rev_care;
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            while (droff.Read())
            {
                    
               
                long kod = Convert.ToInt64(droff[0]);
                string name = droff[1].ToString();
                string rzname = droff[2].ToString();
                string bilo = droff[3].ToString().Replace(",", ".");
                string stalo = droff[4].ToString().Replace(",",".");
                long rz = Convert.ToInt64(droff[5]);



                zaprosonl += "INSERT INTO revizia(id_rev_cart,rev_kod_pr,rev_name_pr,rz_name,rev_kol_bilo,rev_kol_stalo)VALUES("+id_rev_care+","+ kod + ",'"+ name + "','"+ rzname + "',"+ bilo + ","+ stalo + ");";

                zaprosoff += "UPDATE razmer_pro SET rz_pies=" + stalo + " where rz_pr_kod=" + kod + " and rz_id=" + rz + ";";



                



            }

            conoff.Close();




            zaprosonl+="UPDATE itogrevcard Set itogrevcard_date_end=" + DateTimeOffset.Now.ToUnixTimeSeconds() + "  WHERE itogrevcard_id_pr =" + id_rev_care+";";


            conoff.Close();
            conoff.Open();
            sqloff = "INSERT INTO productoff(pr_text)VALUES(N'"+ (zaprosonl+ zaprosoff).Replace("'","$") + "');";
            sqloff += zaprosoff+"delete from reviz;"; ;
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            droff.Read();
            conoff.Close();
                      


            con.Close();
            con.Open();
            sql = "UPDATE itogrevcard Set itogrevcard_date_end=" + DateTimeOffset.Now.ToUnixTimeSeconds() + "  WHERE itogrevcard_id_pr =" + id_rev_care + ";";
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();

            poiskrwv();
        }






        public void new_tov(string kod)
        {


            long res;
            bool isInt = Int64.TryParse(kod + "0", out res);


            if (!String.IsNullOrWhiteSpace(kod) && isInt == true)
            {
                textBox7.Text = null;
                bunifuVTrackbar1.Value = 0;

                string name = null;

                string rz = null;

                string bilo = null;


                conoff.Close();
                conoff.Open();
                sqloff = "select pr_name from product_pro where pr_kod=" + kod;
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();

                if (droff.Read())
                {

                    name = droff[0].ToString();


                }
                else
                {

                    MessageBox.Show("Товар не существует");

                    return;

                }



                conoff.Close();
                conoff.Open();

                sqloff = "select rz_id,rz_pies from razmer_pro where rz_pr_kod=" + kod + "" +
                    " and not rz_id in (select rz_id from reviz where kod=" + kod + ")";
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();

                if (droff.Read())
                {
                    rz = droff[0].ToString();
                    bilo = droff[1].ToString().Replace(",", ".");

                }
                else
                {

                    MessageBox.Show("Товар уже добавлен или не существует");
                    return;
                }




                conoff.Close();
                conoff.Open();

                sqloff = "insert into reviz(crt_id,kod,name,rz_id,bilo,stalo)" +
                    " VALUES (" + id_rev_care + "," + kod + ",N'" + name + "'," + rz + "," + bilo + ",0)";
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                droff.Read();
                conoff.Close();

                select();
                if (count > 13)
                { 
                    bunifuVTrackbar1.MaximumValue = (count - 12);
                    bunifuVTrackbar1.Visible = true;
                }
                else
                {

                    bunifuVTrackbar1.Visible = false;

                }
            }


                



           

        }











        public void select()
        {

         

          int  kolichestvo = 0;

            conoff.Close();
            conoff.Open();
            sqloff = "select kod,name,rz_id,bilo,stalo,(SELECT COUNT(*) FROM reviz) from reviz order by Id desc OFFSET " + Convert.ToInt32(bunifuVTrackbar1.Value) + " ROWS";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            while (kolichestvo < 13)
            {

                while (kolichestvo < 13 && droff.Read())
                {

                    sel[kolichestvo].zagruz(Convert.ToInt64(droff[0]), droff[1].ToString(), Convert.ToInt64(droff[2]), droff[3].ToString(), droff[4].ToString());


                    kolichestvo++;

                    count = Convert.ToInt32(droff[5]);

                }

                sel[kolichestvo].Visible = false;

                kolichestvo++;


            }


            conoff.Close();

          





        }

        private void revizia_Load(object sender, EventArgs e)
        {
            while (raz < 14)
            {

                sel[raz] = new revcell { Visible = false};

                flowLayoutPanel4.Controls.Add(sel[raz]);


                raz++;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

             
                new_tov(textBox7.Text);

            }
        }

        private void bunifuVTrackbar1_ValueChanged(object sender, EventArgs e)
        {
            select();
        }
    }
}
