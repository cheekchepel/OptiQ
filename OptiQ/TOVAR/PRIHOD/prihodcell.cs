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
    public partial class prihodcell : UserControl
    {
        public prihodcell()
        {
            InitializeComponent();
        }


        public int id;
        public int idtov;
        public int colsoz;
        

        public int ID
        {
            get { return id; }
            set { id = value; add();  }

        }




        private void savebut_Click(object sender, EventArgs e)
        {
            savebut.Visible = false;
        }





        private void add()
        {

            if (Program.tov.dataGridView1.Rows.Count > id)
            {
                
                textBox1.Text = Program.tov.dataGridView1.Rows[id].Cells[0].Value.ToString();
                textBox2.Text = Program.tov.dataGridView1.Rows[id].Cells[1].Value.ToString();
                textBox3.Text = Program.tov.dataGridView1.Rows[id].Cells[2].Value.ToString();
                textBox4.Text = Program.tov.dataGridView1.Rows[id].Cells[3].Value.ToString();
                textBox5.Text = Program.tov.dataGridView1.Rows[id].Cells[4].Value.ToString();
                this.Visible = true;
            }
            else { this.Visible = false; }

        }





    }
}
