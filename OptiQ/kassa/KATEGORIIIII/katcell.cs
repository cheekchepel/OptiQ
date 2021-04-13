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

namespace OptiQ.kassa
{
    public partial class katcell : UserControl
    {
        public katcell()
        {
            InitializeComponent();
        }


        public SqlConnection conoff = new SqlConnection(Global.conectsql);
        public string sqloff;
        public SqlCommand cmdoff;
        public SqlDataReader droff;


        public int id;

        public long znachenie;

        public int ID
        {
            get { return id; }
            set { id = value; add(); }

        }



        public bool picviw;


        public bool _picviw
        {
            get { return picviw; }
            set { picviw = value; bunifuFlatButton7.Visible = value; }

        }



        private void add()
        {

            if (Program.kotek.dtSales1.Rows.Count > id)
            {
                znachenie =Convert.ToInt64(Program.kotek.dtSales1.Rows[id][0]);
                bunifuFlatButton13.Text = Program.kotek.dtSales1.Rows[id][1].ToString();
              
                this.Visible = true;
            }
            else { this.Visible = false; }

        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
           Program.kotek.okno2();
            Program.kotek.list2 = 0;
     
            Program.kotek.tovarzagrsel(znachenie);
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            conoff.Close();
            conoff.Open();
            sqloff = "DELETE FROM kateg WHERE kat_mg_id=" + Global.IDmagaz + " and kat_silka=" + znachenie + ";";
            sqloff += "INSERT INTO productoff(pr_text)VALUES(N'"+ Global.versia + "" + sqloff + "');";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            droff.Read();
            conoff.Close();
            Program.kotek.katzagrsel();
        }
    }
}
