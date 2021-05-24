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
    public partial class magaz : UserControl
    {
        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;


        public magaz()
        {
            InitializeComponent();
        }

        private void admin_Load(object sender, EventArgs e)
        {
            select();
        }

        public void select() {

            con.Close();
            con.Open();
            sql = $"select mg_name,mg_address,mg_test from magaz where mg_id ={Global.IDmagaz};";
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                magname.Text = dr[0].ToString();
                magadres.Text = dr[1].ToString();
                test.Value = Convert.ToBoolean(dr[2]);
            }
            con.Close();


        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            select();
        }

        public void save()
        {

            if (String.IsNullOrWhiteSpace(magname.Text) || String.IsNullOrWhiteSpace(magadres.Text))
            {Program.msg.uvedomlrnie("Заполните все поля",3);return; }

                con.Close();
                con.Open();
                sql = $"UPDATE magaz SET mg_name='{magname.Text}',mg_address='{magadres.Text}',mg_test= {test.Value} WHERE mg_id = {Global.IDmagaz};";
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                con.Close();
                Program.msg.uvedomlrnie("Данные успешно изменены", 1);




        }

        private void bunifuFlatButton15_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}
