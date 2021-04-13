using Npgsql;
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
    public partial class Zakup : Form
    {
        public Zakup()
        {
            InitializeComponent();
            Program.zakup = this;
        }

        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);

        public int chto =0;
        public string nactoumnoju = "0";

        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;

        prihodcell[] sel = new prihodcell[50];
        public DataTable dtSales = new DataTable();

        int ket = 0;
        int sum = 0;
        long date = 0;



        public int idpost;

        string itog;
        string url = "https://barcode-list.ru/barcode/RU/%D0%9F%D0%BE%D0%B8%D1%81%D0%BA.htm?barcode=";

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Program.fstpr.Location = new Point(Left + Width, Top + 285);
            Program.fstpr.ShowDialog();

        }




        public void clear()
        {
            bunifuFlatButton7.Normalcolor = Color.Transparent;
            bunifuFlatButton1.Normalcolor = Color.Transparent;
            text6.Items.Clear();

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
                this.Hide();
                Program.main.KASSA_view();
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

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            chto = 1;
            nactoumnoju = "+";
            bunifuFlatButton1.Normalcolor = bunifuFlatButton1.OnHovercolor;
            bunifuFlatButton7.Normalcolor = Color.Transparent;

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            chto = 2;
            nactoumnoju = "-";

            bunifuFlatButton7.Normalcolor = bunifuFlatButton7.OnHovercolor;
            bunifuFlatButton1.Normalcolor = Color.Transparent;
        }

        private void Zakup_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            string opa = "'";

            if (number == '$' || number == '%' || number == ',' || number == Convert.ToChar(opa)) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void Zakup_Load(object sender, EventArgs e)
        {
            panel8.Visible = Global.pra_showprih;
            cenaco.Visible = Global.pra_showprih;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                kassa_pulus();

            }

            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }

        }





        public void kassa_pulus()
        {


            long res;
            bool isInt = Int64.TryParse(textBox1.Text + "0", out res);


            if (!String.IsNullOrWhiteSpace(textBox1.Text) && isInt == true)
            {

                try { 


                con.Open();
                sql = "select pr_name,pr_price_ca,pr_price_co from product where pr_kod=" + textBox1.Text + "and pr_mg_id =" + Global.IDmagaz;
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    textBox2.Text = dr[0].ToString();
                    textBox3.Text = dr[1].ToString();
                    textBox4.Text = dr[2].ToString();
                    textBox5.Text = null;
                    con.Close();
                }
                else
                {
                    con.Close();
                    con.Open();
                    sql = "select al_name from allpruduct where al_kod=" + textBox1.Text;
                    cmd = new NpgsqlCommand(sql, con);
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        textBox2.Text = dr[0].ToString();
                        textBox3.Text = null;
                        textBox4.Text = null;
                        textBox5.Text = null;
                        con.Close();
                    }
                    else {





                        var qe = (HttpWebRequest)WebRequest.Create(url + textBox1.Text);
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

                            textBox2.Text = itog.Replace(",", ".");

                            try
                            {
                                con.Close();
                                con.Open();
                                sql = "INSERT INTO allpruduct(al_kod,al_name)VALUES(" + textBox1.Text + ",'" + textBox2.Text + "')";
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
                con.Close();

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

        private void savebut_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text) && !String.IsNullOrWhiteSpace(textBox4.Text) && !String.IsNullOrWhiteSpace(textBox5.Text))
            {

                int ketq = 0;

                int prihod = Convert.ToInt32(0+textBox3.Text);



                while (ketq < grdt_kass.Rows.Count)
                {

                    if (textBox1.Text == grdt_kass.Rows[ketq].Cells[0].Value.ToString())
                    {

                        grdt_kass.Rows.RemoveAt(ketq);
                    
                       
                    }
                  

                    ketq++;

                }
                

                grdt_kass.Rows.Add(textBox1.Text, textBox2.Text, prihod, textBox4.Text, textBox5.Text);


               
              
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
            }

        }

        private void Zakup_Shown(object sender, EventArgs e)
        {
            clear();
            chto = 0;
             ket = 0;
            sum = 0;
          date = 0;
              chto = 0;
      nactoumnoju = "0";
    }


        public void summa() {
             ket =0;
            sum = 0;
             date = 0;
            while (ket <= grdt_kass.Rows.Count - 1) {


                sum +=Convert.ToInt32( grdt_kass.Rows[ket].Cells[2].Value);

                ket++;

            }

            date = DateTimeOffset.Now.ToUnixTimeSeconds();

        } 




        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            summa();
            int keeti = 0;
            try { 
            if ((grdt_kass.Rows.Count - 1) > -1 && chto != 0)
            {




                con.Close();
                con.Open();
                    sql = Global.versia;
                sql += "INSERT INTO postavki(pos_kassir_id,pos_type,pos_sum_pri,pos_name_prov,pos_mg_id,pos_date)VALUES("+Global.IDuser+","+ chto + ","+sum+",'"+text6.Text+"',"+Global.IDmagaz+","+date+") Returning pos";
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                if (dr.Read()) {

                    idpost = Convert.ToInt32( dr[0]);


                };
                con.Close();




               


                

                while (keeti <= grdt_kass.Rows.Count - 1)
                {



                    con.Close();
                    con.Open();
                    sql = "INSERT INTO postavproduct(pospro_id_postavki,pospro_kod,pospro_name,pospro_price_co,pospro_price_ca,pospro_piec)" +
                        "VALUES("+idpost+","+ grdt_kass.Rows[keeti].Cells[0].Value + ",'"+ grdt_kass.Rows[keeti].Cells[1].Value + "',"+ grdt_kass.Rows[keeti].Cells[2].Value + ","+ grdt_kass.Rows[keeti].Cells[3].Value + ","+ grdt_kass.Rows[keeti].Cells[4].Value + ")";
                    cmd = new NpgsqlCommand(sql, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    con.Close();






                    con.Open();
                    sql = "select pr_name,pr_price_ca,pr_price_co from product where pr_kod=" + grdt_kass.Rows[keeti].Cells[0].Value + "and pr_mg_id =" + Global.IDmagaz;
                    cmd = new NpgsqlCommand(sql, con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {


                        con.Close();
                        con.Open();
                        sql = " UPDATE product SET pr_piec = ((select pr_piec from product WHERE pr_kod = " + grdt_kass.Rows[keeti].Cells[0].Value + "and pr_mg_id = " + Global.IDmagaz + " limit 1 )"+nactoumnoju+"" + grdt_kass.Rows[keeti].Cells[4].Value + " )" +
                            ",pr_name='" + grdt_kass.Rows[keeti].Cells[1].Value + "',pr_price_co=" + grdt_kass.Rows[keeti].Cells[2].Value + ",pr_price_ca=" + grdt_kass.Rows[keeti].Cells[3].Value + ",pr_provid='" + text6.Text + "',pr_fact_co=" + grdt_kass.Rows[keeti].Cells[2].Value + "" +
                            " WHERE pr_kod = " + grdt_kass.Rows[keeti].Cells[0].Value + " and pr_mg_id = " + Global.IDmagaz;
                        cmd = new NpgsqlCommand(sql, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();



                    }
                    else
                    {

                        con.Close();
                        con.Open();
                        sql = "INSERT INTO product(pr_kod,pr_mg_id,pr_name,pr_price_co,pr_price_ca,pr_provid,pr_fact_co,pr_piec)" +
                            "VALUES(" + grdt_kass.Rows[keeti].Cells[0].Value + "," + Global.IDmagaz + ",'" + grdt_kass.Rows[keeti].Cells[1].Value + "'," + grdt_kass.Rows[keeti].Cells[2].Value + "," + grdt_kass.Rows[keeti].Cells[3].Value + ",'" + text6.Text + "'," + grdt_kass.Rows[keeti].Cells[2].Value + "," + grdt_kass.Rows[keeti].Cells[4].Value + ")";
                        cmd = new NpgsqlCommand(sql, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        con.Close();

                    }

                    con.Close();

                    keeti++;

                    con.Close();

                }
                Program.main.backblakhide();
                this.Close();
                grdt_kass.Rows.Clear();
                Program.tov.zagrsel();
                Program.tov.viewcell();

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }
    }
}
