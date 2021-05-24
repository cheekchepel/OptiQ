using Newtonsoft.Json;
using Npgsql;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
namespace OptiQ
{
    public partial class login : Form
    {


        public ShowMessage mess = new ShowMessage();

        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);

        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;
        public NpgsqlDataReader dr2;


        public int zatkni =0;
        //public SqlConnection conoff = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OFFver.mdf;Integrated Security=True");


        /// public SqlConnection conoff = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= C:\Users\Elon\Desktop\DELTDENGI\OptiQ\OptiQ\OFFver.mdf;Integrated Security=True");
        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;
        public SqlCommand cmdoff;
        public SqlDataReader droff;





        //  int !edt = 0;








        public login()
        {



            InitializeComponent();
            Program.log = this;

        }




        private void login_Load(object sender, EventArgs e)
        {

            



         


            login_form.Location = new Point(((Global.x - 600) / 2), Convert.ToInt32(Convert.ToDouble(Global.y - 728) * 0.5)+40);



        }

        private void pass_text_OnValueChanged(object sender, EventArgs e)
        {
            pass_text.isPassword = true;
            if (String.IsNullOrWhiteSpace(pass_text.Text))
            {
                pass_text.LineIdleColor = Color.Maroon;
            }
            else { pass_text.LineIdleColor = Color.SteelBlue; }

        }

        private void text_login_OnValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(text_login.Text))
            {
                text_login.LineIdleColor = Color.Maroon;
            }
            else { text_login.LineIdleColor = Color.SteelBlue; }



        }





        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }





        private void linkLabel_sign_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login_form.Visible = false;


            shjowkeyboard1.Left = -100;
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            INICIALIZ();
        }






        public void prava() {

            conoff.Close();
            conoff.Open();
            sqloff = "select pra_eidittov,pra_editpri,pra_showpie,pra_showprih,pra_showdohd,pra_showreviz,pra_editkotak from prava";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            if (droff.Read()) {

                Global.pra_eidittov =Convert.ToBoolean( droff[0]);

                Global.pra_editpri = Convert.ToBoolean(droff[1]);

                Global.pra_showpie = Convert.ToBoolean(droff[2]);
                Global.pra_showprih = Convert.ToBoolean(droff[3]);
                Global.pra_showdohd = Convert.ToBoolean(droff[4]);
                Global.pra_showreviz = Convert.ToBoolean(droff[5]);
                Global.pra_editkotak = Convert.ToBoolean(droff[6]);

            }
            conoff.Close();








            conoff.Close();
            conoff.Open();
            sqloff = "select ns_maxskidnactov,ns_maxskidnacitog,ns_maxbonus,ns_maxbonusogran,ns_sale_in_minus,ns_ojidanie,ns_vesishow,ns_autopech from nastroiki where ns_mg_id=" + Global.IDmagaz;
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            if (droff.Read())
            {

                Global.maxskidnactov = Convert.ToInt32(droff[0]); 

                Global.maxskidnacitog = Convert.ToInt32(droff[1]);

                Global.maxbonus = Convert.ToInt32(droff[2]);

                Global.maxbonusogran = Convert.ToInt32(droff[3]);

                Global.sale_in_minus = Convert.ToBoolean(droff[4]); 

                Global.ojidanie = Convert.ToInt32(droff[5]); 

                Global.vesishow = Convert.ToBoolean(droff[6]); 

                Global.prin = Convert.ToBoolean(droff[7]);

            }
            conoff.Close();






            conoff.Close();
            conoff.Open();
            sqloff = $"select nalic,beznalic,kaspi,kaspired from methodsetings where mg_id={Global.IDmagaz};";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            if (droff.Read())
            {
               
               Global.nal = Convert.ToInt32(droff[0]); 
               Global.beznal = Convert.ToInt32(droff[1]);
               Global.kaspi = Convert.ToInt32(droff[2]); 
               Global.kaspired = Convert.ToInt32(droff[3]);
               


            }
            conoff.Close();
            int a = 2;
            if (Global.beznal >= 0) { a++; Global.Vbeznal = true; Program.oplati.karta.Visible = true; }
            if (Global.kaspi >= 0) { a++; Global.Vkaspi = true; Program.oplati.kaspi.Visible = true; }
            if (Global.kaspired >= 0) { a++; Global.Vkaspired = true; Program.oplati.RED.Visible = true; }
            if (a == 2) { Program.oplati.smejno.Visible = false; a--; }

            int b = 780 / a;
            Program.oplati.nal.Width = b;
            Program.oplati.karta.Width = b;
            Program.oplati.kaspi.Width = b;
            Program.oplati.RED.Width = b;
            Program.oplati.smejno.Width = b;


        }

     





        public void poisc_sessii_and_view() {



            conoff.Close();
            conoff.Open();

            sqloff = "select id_kassir_ksas,date_start_ksas,date_end_ksas,id_mg_ksas from ksas where date_end_ksas =0 and id_kassir_ksas="+Global.IDuser;
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            if (droff.Read())
            {
                
                Global.date_open_sesions =Convert.ToInt64(droff["date_start_ksas"]);
                Program.ssssss.Opensesess.Visible = false;
                Program.ssssss.Closesess.Visible = true;
                Program.ssssss.date_open.Text ="Смена от "+ UnixTimeStampToDateTime(Global.date_open_sesions);
                Program.main.kassa_but.Visible = true;
           
                
            }
            else
            {
                
                Global.date_open_sesions = 0;
                Program.ssssss.Closesess.Visible = false;
                //Program.ssssss.Opensesess.Visible = true;
                Program.ssssss.date_open.Text = "Смена не открыта";
                Program.main.kassa_but.Visible = false;
                Program.ssssss.Opensesess.Visible = true;
            }
            conoff.Close();
            



        }



        
        

    

     

   

        private void text_login_Enter(object sender, EventArgs e)
        {


            shjowkeyboard1.Visible = true;
      
           
        }

    

        private void pass_text_Enter(object sender, EventArgs e)
        {
            shjowkeyboard2.Visible = true;
        }








        public void INICIALIZ() {





            if (String.IsNullOrWhiteSpace(text_login.Text) || String.IsNullOrWhiteSpace(pass_text.Text))
            { Program.msg.uvedomlrnie("Заполните все поля", 3); }
            else
            {
                try
                {

                    con.Open();

                    sql = "select sir,sir_mg_id,sir_name,sir_user,sir_login,sir_pass,mg_name,mg_pay,mg_address,mg_test,(" + DateTimeOffset.Now.ToUnixTimeSeconds() + "- mg_pay) from kassir LEFT JOIN magaz ON sir_mg_id=mg_id where sir_login='" + text_login.Text + "' and sir_pass='" + pass_text.Text + "'and sir_enabled=true";
                    cmd = new NpgsqlCommand(sql, con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Global.IDuser = Convert.ToInt32(dr["sir"]);
                        Global.IDmagaz = Convert.ToInt32(dr["sir_mg_id"]);
                        Global.namekass = dr["sir_name"].ToString();
                        Global.USname = dr["sir_user"].ToString();
                        Global.login = dr["sir_login"].ToString();
                        Global.pass = dr["sir_pass"].ToString();
                        Global.MGname = dr["mg_name"].ToString();
                        Global.mg_pay = Convert.ToInt64(dr["mg_pay"]);
                        Global.MGadr = dr["mg_address"].ToString();
                        Global.basever = Convert.ToInt64(0);
                        Global.veriaprodaj = Convert.ToInt64(0);

                        Global.mg_test = Convert.ToBoolean(dr["mg_test"]);
                        Global.mg_pay_raznica = Convert.ToInt32(dr[10]);
                        Global.Vers = Global.IDmagaz.ToString();



                        conoff.Open();

                        sqloff = "DELETE FROM kassirmagaz; INSERT INTO kassirmagaz (sir,sir_mg_id,sir_name,sir_user,sir_login,sir_pass,mg_name,mg_pay,mg_address,base_ver,mg_test,off_date,sales_ver)" +
                        "VALUES(" + Global.IDuser + "," + Global.IDmagaz + ",N'" + Global.namekass + "',N'" + Global.USname + "',N'" + Global.login + "',N'" + Global.pass + "',N'" + Global.MGname + "','" + Global.mg_pay + "',N'" + Global.MGadr + "'," + Global.basever + ",'" + Global.mg_test + "'," + DateTimeOffset.Now.ToUnixTimeSeconds() + ","+Global.veriaprodaj+");";

                        cmdoff = new SqlCommand(sqloff, conoff);
                        droff = cmdoff.ExecuteReader();
                        droff.Read();
                        conoff.Close();






                        con.Close();
                        con.Open();
                        sql = "select id_kassir_ksas,date_start_ksas,date_end_ksas,id_mg_ksas from ksas where id_kassir_ksas=" + Global.IDuser + "and date_end_ksas =0";
                        cmd = new NpgsqlCommand(sql, con);
                        dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            
                            conoff.Close();
                            conoff.Open();
                            sqloff = "DELETE FROM ksas;" +
                        "INSERT INTO ksas(id_kassir_ksas,date_start_ksas,date_end_ksas,id_mg_ksas)VALUES(" + dr[0] + "," + dr[1] + "," + dr[2] + "," + dr[3] + ")";
                            cmdoff = new SqlCommand(sqloff, conoff);
                            droff = cmdoff.ExecuteReader();
                            droff.Read();
                            conoff.Close();
                        }

                        con.Close();




                        con.Close();
                        con.Open();
                        sql = "select pra_eidittov,pra_editpri,pra_showpie,pra_showprih,pra_showdohd,pra_showreviz,pra_editkotak from prava where pra_id_kassir=" + Global.IDuser;
                        cmd = new NpgsqlCommand(sql, con);
                        dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            conoff.Close();
                            conoff.Open();
                            sqloff = "DELETE FROM prava;" +
                            "INSERT INTO prava(pra_eidittov,pra_editpri,pra_showpie,pra_showprih,pra_showdohd,pra_showreviz,pra_editkotak)VALUES('" + dr[0] + "','" + dr[1] + "','" + dr[2] + "','" + dr[3] + "','" + dr[4] + "','" + dr[5] + "','" + dr[6] + "')";
                            cmdoff = new SqlCommand(sqloff, conoff);
                            droff = cmdoff.ExecuteReader();
                            droff.Read();
                            conoff.Close();
                        }

                        con.Close();





                        con.Close();
                        con.Open();
                        sql = "select ns_maxskidnactov,ns_maxskidnacitog,ns_maxbonus,ns_maxbonusogran,ns_sale_in_minus,ns_ojidanie,ns_vesishow,ns_autopech from nastroiki where ns_mg_id=" + Global.IDmagaz;
                        cmd = new NpgsqlCommand(sql, con);
                        dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            conoff.Close();
                            conoff.Open();
                            sqloff = "DELETE FROM nastroiki;" +
                        "INSERT INTO nastroiki(ns_mg_id,ns_maxskidnactov,ns_maxskidnacitog,ns_maxbonus,ns_maxbonusogran,ns_sale_in_minus,ns_ojidanie,ns_vesishow,ns_autopech)VALUES(" + Global.IDmagaz+"," + dr[0]+ "," + dr[1] + "," + dr[2] + "," + dr[3] + ",'" + dr[4] + "','" + dr[5] + "','" + dr[6] + "','" + dr[7] + "')";
                            cmdoff = new SqlCommand(sqloff, conoff);
                            droff = cmdoff.ExecuteReader();
                            droff.Read();
                            conoff.Close();
                        }

                        con.Close();
















                        if (Global.mg_pay_raznica / 86400 > 0) { Program.msg.Size = new Size(310, 100); Program.msg.Message.Text = "Приложение не оплачено"; mess.Show(); }
                        else
                        {
                            Program.main.logadministartoe.Visible = false;
                            poisc_sessii_and_view();
                         
                            
                            Potoki.start();
                            prava();
                            Program.main.smenna.Visible = true;
                            Program.main.prodect_but.Visible = true;
                            
                            Program.main.vesovoi.Visible = Global.vesishow;
                            Program.KASA.salesssssssssssssss();
                            Program.main.sobbez(1);
                            Program.main.close.Visible = false;
                            
                        }
                        con.Close();
                        conoff.Close();


                    }
                    else { con.Close(); Program.msg.uvedomlrnie("Неверный логин или пароль", 2); return; }
                }
                catch (NpgsqlException)
                {




                    conoff.Close();
                    conoff.Open();
                    sqloff = "select sir,sir_mg_id,sir_name,sir_user,sir_login,sir_pass,mg_name,mg_pay,mg_address,base_ver,sales_ver,mg_test,(" + DateTimeOffset.Now.ToUnixTimeSeconds() + "-mg_pay),(" + DateTimeOffset.Now.ToUnixTimeSeconds() + "-off_date) from kassirmagaz  where sir_login='" + text_login.Text + "' and sir_pass='" + pass_text.Text + "'";
                    cmdoff = new SqlCommand(sqloff, conoff);
                    droff = cmdoff.ExecuteReader();
                    if (droff.Read())
                    {
                        Global.IDuser = Convert.ToInt32(droff["sir"]);
                        Global.IDmagaz = Convert.ToInt32(droff["sir_mg_id"]);
                        Global.namekass = droff["sir_name"].ToString();
                        Global.USname = droff["sir_user"].ToString();
                        Global.login = droff["sir_login"].ToString();
                        Global.pass = droff["sir_pass"].ToString();
                        Global.MGname = droff["mg_name"].ToString();
                        Global.mg_pay = Convert.ToInt64(droff["mg_pay"]);
                        Global.MGadr = droff["mg_address"].ToString();
                        Global.basever = Convert.ToInt32(droff["base_ver"]);

                        Global.veriaprodaj= Convert.ToInt32(droff["sales_ver"]);

                        Global.mg_test = Convert.ToBoolean(droff["mg_test"]);
                        Global.mg_pay_raznica = Convert.ToInt32(droff[11]);
                        Global.mg_off_raznica = Convert.ToInt32(droff[12]);
                        Global.Vers = Global.IDmagaz.ToString();



                        if (Global.mg_pay_raznica / 86400 > 1) { Program.msg.Size = new Size(310, 100); Program.msg.Message.Text = "Приложение не оплачено"; mess.Show(); }
                        else if (Global.mg_off_raznica / 86400 > 1) { Program.msg.Size = new Size(360, 100); Program.msg.Message.Text = "Необходима синхронизация"; mess.Show(); }
                        else
                        {
                            Program.main.logadministartoe.Visible = false;
                            Program.main.prodect_but.Visible = true;

                            poisc_sessii_and_view();
                            Program.main.smenna.Visible = true;
                           
                        
                            Program.main.close.Visible = false;
                            Program.main.vesovoi.Visible = true;
                            Potoki.start();
                            prava();
                            Program.KASA.salesssssssssssssss();
                            Program.main.sobbez(1);
                        }



                    }

                    else { conoff.Close(); Program.msg.uvedomlrnie("Неверный логин или пароль", 2); return; }

                    conoff.Close();





                }
            }











        }

        private void login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { INICIALIZ(); }
            
        }

        private void text_login_Leave(object sender, EventArgs e)
        {
            shjowkeyboard1.Visible = false;
        }

        private void pass_text_Leave(object sender, EventArgs e)
        {
            shjowkeyboard2.Visible = false;
        }


        public string GetHash(string input)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.hashify.net/hash/md5/hex?value=" + input);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string sReadData = sr.ReadToEnd();
            response.Close();
            dynamic d = JsonConvert.DeserializeObject(sReadData);
            return d.Digest;
        }


    }
}
