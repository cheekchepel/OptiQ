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
    public partial class magsetting : UserControl
    {
        public magsetting()
        {
            InitializeComponent();
        }

        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;


        public void select()
        {

            con.Close();
            con.Open();
            sql = $"select ns_sale_in_minus,ns_vesishow,ns_autopech from nastroiki where ns_mg_id ={Global.IDmagaz};";
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                min.Checked = Convert.ToBoolean(dr[0]);
                vesi.Checked = Convert.ToBoolean(dr[1]);
                pechat.Checked = Convert.ToBoolean(dr[2]);

            }
            con.Close();






        }




        public void save()
        {


            con.Close();
            con.Open();
            sql = $"UPDATE nastroiki SET ns_sale_in_minus={min.Checked},ns_vesishow={vesi.Checked},ns_autopech={pechat.Checked} WHERE ns_mg_id ={Global.IDmagaz};";
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();
            Program.msg.uvedomlrnie("Данные успешно изменены", 1);


        }

        private void magsetting_Load(object sender, EventArgs e)
        {
            select();
            if (this.Top + this.Height > Global.y) { Program.adminkaa.flowLayoutPanel1.AutoScroll = true; }

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            select();
        }

        private void bunifuFlatButton15_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}