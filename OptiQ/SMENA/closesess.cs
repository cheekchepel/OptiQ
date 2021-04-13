using Npgsql;
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

namespace OptiQ
{
    public partial class closesess : Form
    {


        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);


        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;



        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;
        public SqlCommand cmdoff;
        public SqlDataReader droff;



        public closesess()
        {
            InitializeComponent();
        }

        private void Message_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            


            if (Global.date_open_sesions!=0)
            {

               


                conoff.Close();
                conoff.Open();
                sqloff = "UPDATE ksas set date_end_ksas= " + DateTimeOffset.Now.ToUnixTimeSeconds() + " where id_kassir_ksas =" + Global.IDuser + "and date_end_ksas =0 and date_start_ksas =" + Global.date_open_sesions;
                sqloff += "INSERT INTO productoff(pr_text)VALUES(N'" + sqloff + "')";
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                droff.Read();
                conoff.Close();





                Program.msg.Size = new Size(360, 100);
                Program.msg.Message.Text = "Смена успешно закрыта"; Program.msg.Show();

            }
            else
            {
                Program.msg.Size = new Size(320, 100);
                Program.msg.Message.Text = "Смена не открыта"; Program.msg.Show();
            }

            conoff.Close();
            Program.ssssss.Closesess.Visible = false;
            this.Hide();
            Program.log.poisc_sessii_and_view();
        }
    }
}
