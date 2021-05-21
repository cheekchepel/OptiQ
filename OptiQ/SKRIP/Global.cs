using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiQ
{


    



    static class Global
    {


        public static bool yesno =false;



        public static int x;
        public static int y;


        public static bool pra_eidittov=false;
        public static bool pra_editpri = false;
        public static bool pra_showpie = false;
        public static bool pra_showprih = false;
        public static bool pra_showdohd = false;
        public static bool pra_showreviz = false; 
        public static bool pra_editkotak = false;

        public static bool sale_in_minus=true;
        public static int uvedomlenie_ostatoc = 2;
        public static int ojidanie = 10;
        public static bool vesishow = false;


        public static long basever;
        public static long veriaprodaj;

        public static long mg_pay_raznica;
        public static long mg_off_raznica;

        public static long mg_pay;

        public static bool mg_test;


        public static long date_open_sesions;


        public static string login;
        public static string pass;


        public static int nal = 0;
        public static int beznal = 0;
        public static int kaspi = 0;
        public static int kaspired = 0;






        public static int maxbonus = 20;

        public static int maxbonusogran = 20;

        public static int maxskidnactov = 20;

        public static int maxskidnacitog = 10;





        public static string namekass;
        public static int IDuser;
        public static string USname = "";
        public static string USrole="";
        public static int IDmagaz;
        public static string MGname = "";
        public static string MGadr = "";


        public static string conectblak = "Server=45.93.136.41; Port=5432; User Id = postgres; Password=qazwsxedc12; Database=mydb";

        public static string conectpost = "Server=45.9.190.177; Port=5432; User Id = konstantin; Password=kot_520535; Database=optiq";
      //   public static string conectsql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Куаныш\Desktop\Rabota\1ooppa3\OptiQPro\OptiQ\BASE\OFFver.mdf;Integrated Security=True";
        public static string conectsql = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BASE\OFFver.mdf;Integrated Security = True";

        // public static string conectsql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elon\Desktop\Rabota\OPTIQrazrab\OptiQPro\OptiQ\BASE\OFFver.mdf;Integrated Security=True";

        public static string versia ;
        public static string salever; 

        public static string Vers
        {
            get { return versia; }
            set { 
                versia = "select basever(" + value + ");";
                salever = "select salever(" + value + ");";
            }
        }


     



        public static int Globalmagaz
            {
                get { return IDmagaz; }
                set { IDmagaz = value; }
            }
    
        public static string Globalrole
        {
            get { return USrole; }
            set { USrole = value; }
        }



        public static string Globalusname
        {
            get { return USname; }
            set { USname = value; }
        }




        public static string Globalname
        {
            get { return MGname; }
            set { MGname = value; }
        }





        public static string Globaladr
        {
            get { return MGadr; }
            set { MGadr = value; }
        }




        public static int Globalusers
        {
            get { return IDuser; }
            set { IDuser = value; }
        }




        public static int Globalx
        {
            get { return x; }
            set { x = value; }
        }
        public static int Globaly
        {
            get { return y; }
            set { y = value; }
        }




    





    }
}
