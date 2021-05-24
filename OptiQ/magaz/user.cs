using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptiQ.magaz
{
    public partial class user : UserControl
    {
        public user()
        {
            InitializeComponent();
        }


        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;


        usercell[] usercell = new usercell[6];


        int a = 0;



        public void create() {


            while (a < 6) {
                usercell[a] = new usercell { Visible = false }; 
                flowLayoutPanel1.Controls.Add(usercell[a]);
                a++;
            }



        }

        public void select()
        {
            int b = 0;

            con.Close();
            con.Open();
            sql = $"select sir,sir_user,sir_name from kassir where sir_mg_id ={Global.IDmagaz};";
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            while (b < 5)
            {
                while (dr.Read() && b < 5)
                {


                    usercell[b].load(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString());
                    b++;
                }

                usercell[b].Visible = false;
                b++;
            }
            con.Close();
        }

        private void user_Load(object sender, EventArgs e)
        {
            create();
            select();
        }
    }
    



   



}
