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

namespace OptiQ
{
    public partial class revcell : UserControl
    {
        public revcell()
        {
            InitializeComponent();
        }


        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);

        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;


        public int id;
        public int idtov;
        public int colsoz;
  

        public int ID
        {
            get { return id; }
            set { id = value; add(); }


        }






        private void add()
        {

            if (Program.revix.dtSales.Rows.Count > id)
            {
                textBox1.Text = Program.revix.dtSales.Rows[id][0].ToString();
                textBox2.Text = Program.revix.dtSales.Rows[id][1].ToString();
                textBox3.Text = Program.revix.dtSales.Rows[id][2].ToString();
                textBox4.Text = Program.revix.dtSales.Rows[id][3].ToString();
                textBox5.Text = Program.revix.dtSales.Rows[id][4].ToString();
                textBox6.Text = Program.revix.dtSales.Rows[id][5].ToString();

                this.Visible = true;
            }
            else { this.Visible = false; }

        }

        private void close_Click(object sender, EventArgs e)
        {
            try { 

            Program.revix.dtSales.Rows.RemoveAt(id);
            this.Visible = false;
            add();

            con.Close();
            con.Open();
            sql = "DELETE FROM revizia WHERE rev_kod_pr =" + textBox1.Text+" and id_rev_cart="+Program.revix.id_rev_care;
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}