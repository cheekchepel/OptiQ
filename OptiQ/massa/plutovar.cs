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
    public partial class plutovar : UserControl
    {
        public plutovar()
        {
            InitializeComponent();
        }


        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;


        public int id;
        public int idtov;
     
        public int ID
        {
            get { return id; }
            set { id = value; add(); }

        }



        private void add()
        {

            if (Program.vesika.dataGridView1.Rows.Count > id)
            {
                
                idtov = Convert.ToInt32(Program.vesika.dataGridView1.Rows[id].Cells[2].Value);
                textBox1.Text = Program.vesika.dataGridView1.Rows[id].Cells[1].Value.ToString();
                textBox2.Text = Program.vesika.dataGridView1.Rows[id].Cells[3].Value.ToString();
                textBox3.Text = Program.vesika.dataGridView1.Rows[id].Cells[4].Value.ToString();
                textBox4.Text = Program.vesika.dataGridView1.Rows[id].Cells[5].Value.ToString();
              
                this.Visible = true;
            }
            else { this.Visible = false; }

        }

        private void edit_Click(object sender, EventArgs e)
        {
            edit.Visible = false;
            delete.Visible = false;
            close.Visible = true;
            savebut.Visible = true;
           
        }

        private void savebut_Click(object sender, EventArgs e)
        {
            edit.Visible = true;
            delete.Visible = true;
            close.Visible = false;
            savebut.Visible = false;
        }

        private void close_Click(object sender, EventArgs e)
        {
            edit.Visible = true;
            delete.Visible = true;
            close.Visible = false;
            savebut.Visible = false;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            sql = Global.versia;
            sql += "DELETE FROM product_ves WHERE pr_silka =" + idtov + " and mg_id=" + Global.IDmagaz;
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();

            con.Close();
           Program.vesika. zagrsel();
            Program.vesika. viewcell();
        }
    }
}
