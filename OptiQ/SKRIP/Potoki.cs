using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptiQ
{

   static class Potoki
    {


        public static bool zakroi = true;


        public static NpgsqlConnection conblak = new NpgsqlConnection(Global.conectblak);


        public static NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);
        public static string sql;
        public static NpgsqlCommand cmd;
        public static NpgsqlDataReader dr;


        public static NpgsqlConnection conc = new NpgsqlConnection(Global.conectpost);
        public static string sqlc;
        public static NpgsqlCommand cmdc;
        public static NpgsqlDataReader drc;



        public static SqlConnection conoff = new SqlConnection(Global.conectsql);

        public static string sqloff;
        public static SqlCommand cmdoff;
        public static SqlDataReader droff;



        public static NpgsqlConnection con1 = new NpgsqlConnection(Global.conectpost);
        public static string sql1;
        public static NpgsqlCommand cmd1;
        public static NpgsqlDataReader dr1;



        public static SqlConnection conoff1 = new SqlConnection(Global.conectsql);

        public static string sqloff1;
        public static SqlCommand cmdoff1;
        public static SqlDataReader droff1;



        public static NpgsqlConnection con2 = new NpgsqlConnection(Global.conectpost);
        public static string sql2;
        public static NpgsqlCommand cmd2;
        public static NpgsqlDataReader dr2;



        public static SqlConnection conoff2 = new SqlConnection(Global.conectsql);

        public static string sqloff2;
        public static SqlCommand cmdoff2;
        public static SqlDataReader droff2;



        public static NpgsqlConnection con3 = new NpgsqlConnection(Global.conectpost);
        public static string sql3;
        public static NpgsqlCommand cmd3;
        public static NpgsqlDataReader dr3;



        public static SqlConnection conoff3 = new SqlConnection(Global.conectsql);

        public static string sqloff3;
        public static SqlCommand cmdoff3;
        public static SqlDataReader droff3;








        public static bool Globalmagaz
        {
            get { return Globalmagaz; }
            set
            {
                if (value) { Program.main.label1.Visible = true; }
                else { Program.main.label1.Visible = false; }
            }
 
        }



        



        public static void startot() {
            Thread myThread1 = new Thread(new ThreadStart(otpravka));
            myThread1.Start();
        }

        public static void startpro()
        {
            Thread myThread2 = new Thread(new ThreadStart(proverka));
            myThread2.Start();

        }



  




        public static void start() {

            try
            {
                conc.Close();
                conc.Open();
                sqlc = "select by_how,by_komis from buymethod where by_mg_id=" + Global.IDmagaz + ";";
                cmdc = new NpgsqlCommand(sqlc, conc);
                drc = cmdc.ExecuteReader();
                string a = "DELETE FROM buymethod;";
                while (drc.Read())
                {
                    conoff1.Close();
                    conoff1.Open();
                    sqloff1 = a + "INSERT INTO buymethod(by_how, by_komis)VALUES(N'" + drc[0] + "'," + drc[1] + ")";
                    cmdoff1 = new SqlCommand(sqloff1, conoff1);
                    droff1 = cmdoff1.ExecuteReader();
                    droff1.Read();
                    conoff1.Close();
                    a = null;
                }

                conc.Close();
            }
            catch (NpgsqlException) { }



            
            startpro();
          



        }





        







        public static void proverka()
        {


            while (zakroi)
            {


                try{
                    conc.Close();
                    conc.Open();
                    sqlc = "select base_ver,sales_ver from magaz where mg_id=" + Global.IDmagaz + " and (base_ver>" + Global.basever+ "or sales_ver>" + Global.veriaprodaj+")";
                    cmdc = new NpgsqlCommand(sqlc, conc);
                    drc = cmdc.ExecuteReader();
                    if (drc.Read())
                    {
                    //    Globalmagaz = true;

                        if (Convert.ToInt64(drc[0]) > Global.basever)
                        {
                            prihodka(Convert.ToInt64(drc[0]));
                        }
                        if (Convert.ToInt64(drc[1]) > Global.veriaprodaj)
                        {
                            prihodsalo(Convert.ToInt64(drc[1]));
                        }
                        

                    }
                    conc.Close();
                  //  Globalmagaz = false;
                } catch (NpgsqlException) { }

            Thread.Sleep(10000);
        }


        }

















        public static void cari() {

            try {


     

                if (Global.date_open_sesions != 0)
                {

                string delcartmet = "delete from cartbuymet;";
                con2.Close();
                con2.Close();
                con2.Close();
                    con2.Open();
                    sql2 = "select crt_off_id,cbt_by_how,cbt_by_komuis,cbt_sum,cbt_skidon from cart LEFT JOIN cartbuymet ON crt_off_id=cbt_cart_id where id_kassir=" + Global.IDuser + "and crt_date >" + Global.date_open_sesions;
                    cmd2 = new NpgsqlCommand(sql2, con2);
                    dr2 = cmd2.ExecuteReader();

                   

                    while (dr2.Read())
                    {
                        
                        conoff2.Open();
                        sqloff2 = delcartmet+ "INSERT INTO cartbuymet(cbt_cart_id,cbt_by_how,cbt_by_komuis,cbt_sum,cbt_skidon)VALUES(" + dr2[0] + ",N'" + dr2[1] + "'," + dr2[2] + "," + dr2[3] + ",N'"+ dr2[4] +"');";
                        cmdoff2 = new SqlCommand(sqloff2, conoff2);
                        droff2 = cmdoff2.ExecuteReader();
                        droff2.Read();
                        conoff2.Close();
                    delcartmet = null;
                    }
                    con2.Close();



                string delcart = "delete from cart;";

                    con2.Close();
                    con2.Open();
                    sql2 = "select crt_mg_id,id_kassir,crt_sum_fact,crt_date,crt_off_id from cart where id_kassir=" + Global.IDuser + "and crt_date >" + Global.date_open_sesions;
                    cmd2 = new NpgsqlCommand(sql2, con2);
                    dr2 = cmd2.ExecuteReader();


                    while (dr2.Read())
                    {
                       
                        conoff2.Open();
                        sqloff2 = delcart+ "INSERT INTO cart(crt_mg_id,id_kassir,crt_sum_fact,crt_date,crt_off_id)VALUES(" + dr2[0] + "," + dr2[1] + "," + dr2[2] + "," + dr2[3] + "," + dr2[4] + ");";
                        cmdoff2 = new SqlCommand(sqloff2, conoff2);
                        droff2 = cmdoff2.ExecuteReader();
                        droff2.Read();
                        conoff2.Close();
                    delcart = null;

                    }
                    con2.Close();




                }



             



            }catch (NpgsqlException) { }

        }










 







        public static void prihodka(long basver)
        {

            con1.Close();

            try
            {
                string delrazmer = "DELETE FROM razmer_pro;";
                con1.Close();
                con1.Open();
                sql1 = "select rz_id,rz_pr_kod,rz_name,rz_pies,rz_mg_id from razmer_pro where rz_mg_id=" + Global.IDmagaz;
                cmd1 = new NpgsqlCommand(sql1, con1);
                dr1 = cmd1.ExecuteReader();

                while (dr1.Read())
                {

                    conoff1.Close();
                    conoff1.Close();
                    conoff1.Open();
                    sqloff1 = delrazmer + "INSERT INTO razmer_pro(rz_id,rz_pr_kod,rz_name,rz_pies,rz_mg_id)VALUES(" + dr1[0] + "," + dr1[1] + ",N'" + dr1[2] + "'," + dr1[3].ToString().Replace(",", ".") + "," + dr1[4] + ")";
                    cmdoff1 = new SqlCommand(sqloff1, conoff1);
                    droff1 = cmdoff1.ExecuteReader();
                    droff1.Read();
                    conoff1.Close();
                    delrazmer = null;

                }

                con1.Close();
            }
            catch (NpgsqlException) { }





            string delproduc = "DELETE FROM product_pro;";
            con1.Close();

            try{
                con1.Close();
                con1.Open();
                sql1 = "select pr_kod,pr_name,pr_price_co,pr_price_ca,pr_optom,pr_kateg,pr_plu,pr_prov_id,pr_mg_id,pr_provid,pr_kotak from product_pro LEFT JOIN product_ves ON pr_id=pr_silka where pr_mg_id=" + Global.IDmagaz;
                cmd1 = new NpgsqlCommand(sql1, con1);
                dr1 = cmd1.ExecuteReader();
                
                while (dr1.Read())
                {

                    conoff1.Close();
                    conoff1.Close();
                    conoff1.Open();
                    sqloff1 = delproduc+ "INSERT INTO product_pro(pr_kod,pr_name,pr_price_co,pr_price_ca,pr_optom,pr_kateg,pr_plu,pr_prov_id,pr_mg_id,pr_provid,pr_kotak) VALUES(" + dr1[0] + ",N'" + dr1[1] + "'," + dr1[2] + "," + dr1[3] + ","+dr1[4]+ ",0" + dr1[5] + ",0" + dr1[6] + ",0"+ dr1[7] + "," + dr1[8] + ",N'" + dr1[9] + "',0+" + dr1[10] + ")";
                    cmdoff1 = new SqlCommand(sqloff1, conoff1);
                    droff1 = cmdoff1.ExecuteReader();
                    droff1.Read();
                    conoff1.Close();
                delproduc = null;

                }

                con1.Close();
           }catch (NpgsqlException) { }






            string deletekotak = "DELETE FROM kotak;";
            con1.Close();

            try
            {
                con1.Close();
                con1.Open();
                sql1 = "select kot_mg_id,kot_name,kot_rod,kot_chil,kot_marker from kotak where kot_mg_id=" + Global.IDmagaz;
                cmd1 = new NpgsqlCommand(sql1, con1);
                dr1 = cmd1.ExecuteReader();

                while (dr1.Read())
                {

                    conoff1.Close();
                    conoff1.Close();
                    conoff1.Open();
                    sqloff1 = deletekotak + "INSERT INTO kotak(kot_mg_id,kot_name,kot_rod,kot_chil,kot_marker) VALUES(" + dr1[0] + ",N'" + dr1[1] + "'," + dr1[2] + "," + dr1[3] + ",'" + dr1[4] + "')";
                    cmdoff1 = new SqlCommand(sqloff1, conoff1);
                    droff1 = cmdoff1.ExecuteReader();
                    droff1.Read();
                    conoff1.Close();
                    deletekotak = null;


                }

                con1.Close();
            }
            catch (NpgsqlException) { }












            con1.Close();

            try{
         string delkateg= "DELETE FROM kateg;";
            con1.Close();
                con1.Open();
                sql1 = "select kat_mg_id,kat_name,kat_silka from kateg where kat_mg_id=" + Global.IDmagaz;
                cmd1 = new NpgsqlCommand(sql1, con1);
                dr1 = cmd1.ExecuteReader();


                while (dr1.Read())
                {

                    conoff1.Close();
                    conoff1.Open();
                    sqloff1 = delkateg+ "INSERT INTO kateg(kat_mg_id,kat_name,kat_silka) VALUES(" + dr1[0] + ",N'" + dr1[1] + "'," + dr1[2] + ")";
                    cmdoff1 = new SqlCommand(sqloff1, conoff1);
                    droff1 = cmdoff1.ExecuteReader();
                    droff1.Read();
                    conoff1.Close();
                    delkateg = null;

                }

                con1.Close();


              } catch (NpgsqlException) { }


            con1.Close();

               try{
            string delprov = "DELETE FROM myprov;";
            con1.Close();
            con1.Open();
            sql1 = "select mp_mg_id,mp_name,mp_test,mp_id_off from myprov where mp_mg_id=" + Global.IDmagaz;
            cmd1 = new NpgsqlCommand(sql1, con1);
            dr1 = cmd1.ExecuteReader();


            while (dr1.Read())
            {

                conoff1.Close();
                conoff1.Open();
                sqloff1 = delprov + "INSERT INTO myprov(mp_mg_id,mp_name,mp_test,mp_id_off)VALUES(" + dr1[0] + ",N'" + dr1[1] + "','" + dr1[2] + "'," + dr1[3] + ")";
                cmdoff1 = new SqlCommand(sqloff1, conoff1);
                droff1 = cmdoff1.ExecuteReader();
                droff1.Read();
                conoff1.Close();
                delprov = null;

            }

            con1.Close();


            }
            catch (NpgsqlException) { }
            ///////////////////


            con1.Close();
            conoff1.Close();
                    conoff1.Open();
                    sqloff1 = "UPDATE kassirmagaz SET base_ver ="+basver+ " WHERE sir_mg_id ="+Global.IDmagaz;
                    cmdoff1 = new SqlCommand(sqloff1, conoff1);
                    droff1 = cmdoff1.ExecuteReader();
                    droff1.Read();
                    conoff1.Close();
                    Global.basever = basver;

        }






        public static void prihodsalo(long basvers) {



            try { 



            con3.Close();
            con3.Open();
            string delotov = "delete from tov_otlojka_pro;";
            sql3 = "select tov_ot_id,tov_kod,tov_rz,tov_pies,tov_name from tov_otlojka_pro LEFT JOIN otlojka_pro ON tov_ot_id=ot_id  where id_kassir=" + Global.IDuser;
            cmd3 = new NpgsqlCommand(sql3, con3);
            dr3 = cmd3.ExecuteReader();

            while (dr3.Read())
            {

                conoff3.Open();
                sqloff3 = delotov + "INSERT INTO tov_otlojka_pro(tov_ot_id,tov_kod,tov_rz,tov_pies,tov_name)VALUES(" + dr3[0] + "," + dr3[1] + "," + dr3[2] + "," + dr3[3].ToString().Replace(",", ".") + ",N'" + dr3[4] + "');";
                cmdoff3 = new SqlCommand(sqloff3, conoff3);
                droff3 = cmdoff3.ExecuteReader();
                droff3.Read();
                conoff3.Close();
                delotov = null;
            }
            con3.Close();





            con3.Close();
            con3.Open();
            string delotl = "delete from otlojka_pro;";
            sql3 = "select ot_id,id_kassir,ot_text from otlojka_pro where id_kassir=" + Global.IDuser;
            cmd3 = new NpgsqlCommand(sql3, con3);
            dr3 = cmd3.ExecuteReader();

            while (dr3.Read())
            {

                conoff3.Open();
                sqloff3 = delotl + "INSERT INTO otlojka_pro(ot_id,id_kassir,ot_text)VALUES(" + dr3[0] + "," + dr3[1] + ",N'" + dr3[2] + "');";
                cmdoff3 = new SqlCommand(sqloff3, conoff3);
                droff3 = cmdoff3.ExecuteReader();
                droff3.Read();
                conoff3.Close();
                delotl = null;
            }
            con3.Close();



        } catch (NpgsqlException) { }



    con3.Close();


            try{
                con3.Close();
                con3.Open();
                sql3 = "select us_mg_id,us_off_id,us_name,us_danie,us_summa,us_bonus,us_date from users_pro where us_mg_id=" + Global.IDmagaz;
                cmd3 = new NpgsqlCommand(sql3, con3);
                dr3 = cmd3.ExecuteReader();


                string delus = "DELETE FROM users_pro;";


                while (dr3.Read())
                {




                    conoff3.Close();
                    conoff3.Open();
                
                    sqloff3 = delus+ "INSERT INTO users_pro(us_mg_id,us_off_id,us_name,us_danie,us_summa,us_bonus,us_date)" +
                    "VALUES(" + dr3[0] + "," + dr3[1] + ",N'" + dr3[2] + "'," + dr3[3] + "," + dr3[4] + "," + dr3[5] + "," + dr3[6] + ")";
                    cmdoff3 = new SqlCommand(sqloff3, conoff3);
                    droff3 = cmdoff3.ExecuteReader();
                    droff3.Read();
                    conoff3.Close();
                    delus = null;




                }

                con3.Close();


           } catch (NpgsqlException) {
            
            }




                 try { 

  

            long date = DateTimeOffset.Now.ToUnixTimeSeconds() - 1209600;

            string delstr = "delete from sales_pro;";


            con3.Close();
            conblak.Close();
                conblak.Open();

            sql3 = "select sl_crt_id,sl_pieces,sl_cena,sl_name,sl_prihod,sl_skidon,sl_kod,sl_rz_id,cbt_skidon,sl_vozvrat from sales_pro LEFT JOIN cart ON sl_crt_id=crt_off_id where crt_mg_id=" + Global.IDmagaz + " and crt_date >" + date;

            cmd3 = new NpgsqlCommand(sql3, conblak);
            dr3 = cmd3.ExecuteReader();

            while (dr3.Read())
            {
              
                conoff3.Open();

                sqloff3 = delstr + "INSERT INTO sales_pro(sl_crt_id,sl_pieces,sl_cena,sl_name,sl_prihod,sl_skidon,sl_kod,sl_rz_id,cbt_skidon,sl_vozvrat)" +
                    "VALUES(" + dr3[0] + "," + (dr3[1].ToString()).Replace(",", ".") + "," + dr3[2] + ",N'" + dr3[3] + "'," + dr3[4] + ",N'" + dr3[5] + "'," + dr3[6] + "," + dr3[7] + ",N'" + dr3[8] + "'," + (dr3[9].ToString()).Replace(",", ".") + ");";

                cmdoff3 = new SqlCommand(sqloff3, conoff3);
                droff3 = cmdoff3.ExecuteReader();
                droff3.Read();
                conoff3.Close();
                delstr = null;
            }
                sqloff3 = null;
                conblak.Close();

            }
            catch (NpgsqlException) { }

            conoff3.Close();
            conoff3.Open();
            sqloff3 = "UPDATE kassirmagaz SET sales_ver =" + basvers + " WHERE sir_mg_id =" + Global.IDmagaz;
            cmdoff3 = new SqlCommand(sqloff3, conoff3);
            droff3 = cmdoff3.ExecuteReader();
            droff3.Read();
            conoff3.Close();
            Global.veriaprodaj = basvers;



     




}


























        public static void otpravka()
        {

            while (zakroi)
            {





                  try{
                conoff.Close();
                    conoff.Open();

                    sqloff = "select pr_text from productoff";
                    cmdoff = new SqlCommand(sqloff, conoff);
                    droff = cmdoff.ExecuteReader();
                    while (droff.Read())
                    {
                   
                    con.Close();
                    con.Close();
                        con.Open();
                        sql = (droff[0].ToString()).Replace("$", "'");
                        cmd = new NpgsqlCommand(sql, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        con.Close();
                   

                }

                conoff.Close();
                    conoff.Open();
                    sqloff = "delete from productoff";
                    cmdoff = new SqlCommand(sqloff, conoff);
                    droff = cmdoff.ExecuteReader();
                    droff.Read();
                    conoff.Close();

                  }catch (NpgsqlException ) { }




                try{
                conoff.Close();
                    conoff.Open();

                    sqloff = "select pr_text from nigga";
                    cmdoff = new SqlCommand(sqloff, conoff);
                    droff = cmdoff.ExecuteReader();
                    while (droff.Read())
                    {
                        conblak.Close();
                        conblak.Close();
                        conblak.Open();
                        sql = (droff[0].ToString()).Replace("$", "'");
                        cmd = new NpgsqlCommand(sql, conblak);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        conblak.Close();

                    }

                    conoff.Close();
                    conoff.Open();
                    sqloff = "delete from nigga";
                    cmdoff = new SqlCommand(sqloff, conoff);
                    droff = cmdoff.ExecuteReader();
                    droff.Read();
                    conoff.Close();


                }catch (NpgsqlException) { }







                Thread.Sleep(5000);



            }
        }











    }










}
