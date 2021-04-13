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






        public static int IDmagaz;

        public static int Globalmagaz
        {
            get { return IDmagaz; }
            set { IDmagaz = value; }
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



        public static void potok_vozvrat()
        {
            Thread myThread3 = new Thread(new ThreadStart(potok_vozvrat_func));
            myThread3.Start();
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
                    a = "";
                }

                conc.Close();
            }
            catch (NpgsqlException) { }



            startot();
            startpro();
            potok_vozvrat();



        }





        public static void potok_vozvrat_func() {



            long date = DateTimeOffset.Now.ToUnixTimeSeconds() - 1209600;

            string delstr = "delete from vozvrat;";



            con3.Close();
            con3.Open();

            sql3 = "select sl_id,sl_crt_id,sl_pieces,sl_cena,sl_name,sl_prihod,sl_skidon,(select cbt_skidon from cartbuymet where cbt_cart_id=sl_crt_id limit 1) from sales LEFT JOIN cart ON sl_crt_id=crt_off_id  where crt_mg_id=" + Global.IDmagaz + " and crt_date >" + date;
            cmd3 = new NpgsqlCommand(sql3, con3);
            dr3 = cmd3.ExecuteReader();        

            while (dr3.Read())
            {

                conoff3.Open();
                sqloff3 = delstr+"INSERT INTO vozvrat(sl_id,sl_crt_id,sl_pieces,sl_cena,sl_name,sl_prihod,sl_skidon,cbt_skidon)VALUES(" + dr3[0]+"," + dr3[1] + "," + (dr3[2].ToString()).Replace(",", ".") + "," + dr3[3] + ",N'" + dr3[4] + "'," + dr3[5] + ",N'" + dr3[6] + "',N'" + dr3[7] + "');";
                cmdoff3 = new SqlCommand(sqloff3, conoff3);
                droff3 = cmdoff3.ExecuteReader();
                droff3.Read();
                conoff3.Close();
                delstr = null;
            }
            con3.Close();





        }


        







        public static void proverka()
        {



           




            while (zakroi)
            {


                try{
                    conc.Close();
                    conc.Open();
                    sqlc = "select base_ver from magaz where mg_id=" + Global.IDmagaz + " and base_ver>" + Global.basever;
                    cmdc = new NpgsqlCommand(sqlc, conc);
                    drc = cmdc.ExecuteReader();
                    if (drc.Read())
                    {
                        
                        prihodka(Convert.ToInt64(drc[0]));


                    }
                    conc.Close();
                } catch (NpgsqlException) { }

            Thread.Sleep(10000);
        }





    }

















        public static void cari() {

            try
            {


                
               





                if (Global.date_open_sesions != 0)
                {
                   // Int32 unixTimestamp = (Int32)(DateTime.Today.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;



                    con2.Close();
                    con2.Open();
                    sql2 = "select crt_off_id,cbt_by_how,cbt_by_komuis,cbt_sum,cbt_skidon from cart LEFT JOIN cartbuymet ON crt_off_id=cbt_cart_id where id_kassir=" + Global.IDuser + "and crt_date >" + Global.date_open_sesions;
                    cmd2 = new NpgsqlCommand(sql2, con2);
                    dr2 = cmd2.ExecuteReader();

                    conoff2.Open();
                    sqloff2 = "delete from cartbuymet;";
                    cmdoff2 = new SqlCommand(sqloff2, conoff2);
                    droff2 = cmdoff2.ExecuteReader();
                    droff2.Read();
                    conoff2.Close();

                    while (dr2.Read())
                    {
                        
                        conoff2.Open();
                        sqloff2 = "INSERT INTO cartbuymet(cbt_cart_id,cbt_by_how,cbt_by_komuis,cbt_sum,cbt_skidon)VALUES(" + dr2[0] + ",N'" + dr2[1] + "'," + dr2[2] + "," + dr2[3] + ",N'"+ dr2[4] +"');";
                        cmdoff2 = new SqlCommand(sqloff2, conoff2);
                        droff2 = cmdoff2.ExecuteReader();
                        droff2.Read();
                        conoff2.Close();
                    }
                    con2.Close();





                    con2.Close();
                    con2.Open();
                    sql2 = "select crt_off_id,crt_date from cart where id_kassir=" + Global.IDuser + "and crt_date >" + Global.date_open_sesions;
                    cmd2 = new NpgsqlCommand(sql2, con2);

                    dr2 = cmd2.ExecuteReader();


                    conoff2.Open();
                    sqloff2 = "delete from crt;";
                    cmdoff2 = new SqlCommand(sqloff2, conoff2);
                    droff2 = cmdoff2.ExecuteReader();
                    droff2.Read();
                    conoff2.Close();

                    while (dr2.Read())
                    {
                       
                        conoff2.Open();
                        sqloff2 = "INSERT INTO crt(crt,date)VALUES(" + dr2[0] + "," + dr2[1] + ");";
                        cmdoff2 = new SqlCommand(sqloff2, conoff2);
                        droff2 = cmdoff2.ExecuteReader();
                        droff2.Read();
                        conoff2.Close();

                    }
                    con2.Close();









                    //con2.Close();
                    //con2.Open();
                    //sql2 = "select sl_crt_id,sl_pieces,sl_cena,sl_name,sl_prihod,sl_skidon from sales LEFT JOIN cart ON sl_crt_id=crt_off_id where id_kassir=" + Global.IDuser + "and crt_date >" + Global.date_open_sesions;
                    //cmd2 = new NpgsqlCommand(sql2, con2);

                    //dr2 = cmd2.ExecuteReader();


                    //conoff2.Open();
                    //sqloff2 = "delete from sales;";
                    //cmdoff2 = new SqlCommand(sqloff2, conoff2);
                    //droff2 = cmdoff2.ExecuteReader();
                    //droff2.Read();
                    //conoff2.Close();

                    //while (dr2.Read())
                    //{

                    //    conoff2.Open();
                    //    sqloff2 = "INSERT INTO sales(sl_crt_id,sl_pieces,sl_cena,sl_name,sl_prihod,sl_skidon)VALUES(" + dr2[0] + "," + (dr2[1].ToString()).Replace(",",".") + "," + dr2[2] + ",N'" + dr2[3] + "'," + dr2[4] + ",N'"+dr2[5]+"');";
                    //    cmdoff2 = new SqlCommand(sqloff2, conoff2);
                    //    droff2 = cmdoff2.ExecuteReader();
                    //    droff2.Read();
                    //    conoff2.Close();

                    //}
                    //con2.Close();






                   





                }



             



            }
            catch (NpgsqlException) { }

        }










 







        public static void prihodka(long basver)
        {
            con1.Close();

            try
           {
                con1.Close();
                con1.Open();
                sql1 = "select pr_kod, pr_name, pr_fact_co, pr_price_ca,pr_id,pr_piec,pr_kateg,pr_plu from product LEFT JOIN product_ves ON pr_id=pr_silka where pr_mg_id=" + Global.IDmagaz;
                cmd1 = new NpgsqlCommand(sql1, con1);
                dr1 = cmd1.ExecuteReader();
                conoff1.Close();
                conoff1.Open();
                sqloff1 = "DELETE FROM product";
                cmdoff1 = new SqlCommand(sqloff1, conoff1);
                droff1 = cmdoff1.ExecuteReader();
                droff1.Read();
                conoff1.Close();
                while (dr1.Read())
                {
                    conoff1.Close();
                    conoff1.Close();
                    conoff1.Open();
                    sqloff1 = "INSERT INTO product(pr_id,pr_kod, pr_name, pr_fact_co, pr_price_ca,pr_piec,pr_kateg,pr_plu)VALUES(" + dr1[4] + "," + dr1[0] + ",N'" + dr1[1] + "'," + dr1[2] + "," + dr1[3] + ","+(dr1[5].ToString()).Replace(",",".")+","+dr1[6]+ ",0" + dr1[7] + ")";
                    cmdoff1 = new SqlCommand(sqloff1, conoff1);
                    droff1 = cmdoff1.ExecuteReader();
                    droff1.Read();
                    conoff1.Close();


                }

                con1.Close();
           }
       catch (NpgsqlException) { }





            con1.Close();

            try
            {
                con1.Close();
                con1.Open();
                sql1 = "select kat_mg_id,kat_name,kat_silka from kateg where kat_mg_id=" + Global.IDmagaz;
                cmd1 = new NpgsqlCommand(sql1, con1);
                dr1 = cmd1.ExecuteReader();

                conoff1.Close();
                conoff1.Open();
                sqloff1 = "DELETE FROM kateg";
                cmdoff1 = new SqlCommand(sqloff1, conoff1);
                droff1 = cmdoff1.ExecuteReader();
                droff1.Read();
                conoff1.Close();

                while (dr1.Read())
                {




                    conoff1.Close();
                    conoff1.Open();
                    sqloff1 = "INSERT INTO kateg(kat_mg_id,kat_name,kat_silka) VALUES(" + dr1[0] + ",N'" + dr1[1] + "'," + dr1[2] + ")";
                    cmdoff1 = new SqlCommand(sqloff1, conoff1);
                    droff1 = cmdoff1.ExecuteReader();
                    droff1.Read();
                    conoff1.Close();





                }

                con1.Close();


            }
            catch (NpgsqlException) { }









            con1.Close();


            try {
                con1.Close();
                con1.Open();
                sql1 = "select us_off_id_date,us_name,danie,summa,us_date from users where us_mg_id=" + Global.IDmagaz;
                cmd1 = new NpgsqlCommand(sql1, con1);
                dr1 = cmd1.ExecuteReader();

                conoff1.Close();
                conoff1.Open();
                sqloff1 = "DELETE FROM users";
                cmdoff1 = new SqlCommand(sqloff1, conoff1);
                droff1 = cmdoff1.ExecuteReader();
                droff1.Read();
                conoff1.Close();

                while (dr1.Read()) {




                    conoff1.Close();
                    conoff1.Open();
                    sqloff1 = "INSERT INTO users(us_off_id_date,us_name,danie,summa,us_date) VALUES(" + dr1[0] + ",N'" + dr1[1] + "',N'" + dr1[2] + "'," + dr1[3] + "," + dr1[4] + ")";
                    cmdoff1 = new SqlCommand(sqloff1, conoff1);
                    droff1 = cmdoff1.ExecuteReader();
                    droff1.Read();
                    conoff1.Close();





                }

                con1.Close();

            
           } catch (NpgsqlException) { }





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















        public static void otpravka()
        {

            while (zakroi)
            {



                try{

                    conoff.Close();
                    conoff.Open();

                    sqloff = "select saledate,saleoofudin,salecart from saleoff";
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


                        con.Open();
                        sql = (droff[1].ToString()).Replace("$", "'");
                        cmd = new NpgsqlCommand(sql, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        con.Close();


                        con.Open();
                        sql = (droff[2].ToString()).Replace("$", "'");
                        cmd = new NpgsqlCommand(sql, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        con.Close();

                    }
                    conoff.Close();
                    conoff.Close();
                    conoff.Open();
                    sqloff = "delete from saleoff";
                    cmdoff = new SqlCommand(sqloff, conoff);
                    droff = cmdoff.ExecuteReader();
                    droff.Read();
                    conoff.Close();
           }catch (NpgsqlException) { }


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


            }catch (NpgsqlException) { }


            Thread.Sleep(5000);



            }
        }











    }










}
