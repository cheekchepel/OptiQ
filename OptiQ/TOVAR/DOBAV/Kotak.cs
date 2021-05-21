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

namespace OptiQ.TOVAR.DOBAV
{
    public partial class Kotak : Form
    {
        public Kotak()
        {
            InitializeComponent();
            Program.kotak = this;
        }


        public SqlConnection con = new SqlConnection(Global.conectsql);
        public string sql;
        public SqlCommand cmd;
        public SqlDataReader dr;

        public SqlConnection con2 = new SqlConnection(Global.conectsql);
        public string sql2;
        public SqlCommand cmd2;
        public SqlDataReader dr2;

        public kotcell[] koti = new kotcell[51];

        public long ID_chil=0;

        public int shagmain=-1;

        int i = 0;
        public int a =0;


        public bool vibor = false;


        public long chevibr = 0;


        private void Kotak_Load(object sender, EventArgs e)
        {
            while ( i < 51)
            {

                koti[i] = new kotcell { Visible = false };
                flowout.Controls.Add(koti[i]);
                i++;

            }
            chevibr = 0;

            create.Visible =! vibor;

            con.Close();
            con.Open();
            sql = "UPDATE kotak Set edit='false' where kot_mg_id=" + Global.IDmagaz + ";";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();

            add();
        }




        public void add()
        {
            a = 0;
            con.Close();
            con.Open();
            sql = "select kot_name,kot_marker,kot_chil,show,edit from kotak where kot_mg_id =" + Global.IDmagaz + " and kot_rod=" + ID_chil;
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            while (a < 50)
            {
                while (dr.Read() && a < 50)
                {

                    koti[a].view(dr[0].ToString(), Convert.ToBoolean(dr[1]), Convert.ToInt64(dr[2]), shagmain + 1, Convert.ToBoolean(dr[3]), vibor, Convert.ToBoolean(dr[4]));
                    a++;

                }
                koti[a].Visible = false;
                a++;

            }
            con.Close();


        }

        private void close_Click(object sender, EventArgs e)
        {
            Program.zakup.blackback.Hide();
            this.Close();
        }

        private void create_Click(object sender, EventArgs e)
        {

            long id =Convert.ToInt64(Global.IDuser + "" + DateTimeOffset.Now.ToUnixTimeMilliseconds());

            string serv = null;

            con.Close();
            con.Open();


            sql = "UPDATE kotak Set edit='false' where kot_mg_id=" + Global.IDmagaz + ";";
            sql += "INSERT INTO kotak(kot_mg_id,kot_name,kot_rod,kot_chil,kot_marker,show,edit)VALUES(" + Global.IDmagaz + ",N' ',0," + id + ",'false','true','true');";

            serv = "INSERT INTO productoff(pr_text)VALUES(N'"+("INSERT INTO kotak(kot_mg_id,kot_name,kot_rod,kot_chil,kot_marker)VALUES(" + Global.IDmagaz + ",N' ',0," + id + ",'false');").Replace("'","$")+"');";




            cmd = new SqlCommand(sql+ serv, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();
            add();
        }


    }

}
