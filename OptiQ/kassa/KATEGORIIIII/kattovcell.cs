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
    public partial class kattovcell : UserControl
    {
        public kattovcell()
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

            if (Program.kotek.dtSales2.Rows.Count > id)
            {
                znachenie = Convert.ToInt64(Program.kotek.dtSales2.Rows[id][0]);
                bunifuFlatButton13.Text = Program.kotek.dtSales2.Rows[id][1].ToString();

                this.Visible = true;
            }
            else { this.Visible = false; }

        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            Program.kotek.Close();

            Program.main.backblakhide();
            Program.KASA.textBox1.Text = znachenie.ToString();
            Program.KASA.kassa_pulus(0,Program.KASA.textBox1.Text,true);
           

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

           





        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            conoff.Close();
            conoff.Open();
            sqloff = "UPDATE product set pr_kateg =0 WHERE pr_kod =" + znachenie;
            sqloff += " INSERT INTO productoff(pr_text)VALUES(N'"+ Global.versia + "UPDATE product set pr_kateg = 0 WHERE pr_kod = " + znachenie + " and pr_mg_id=" + Global.IDmagaz + "')";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            droff.Read();
            conoff.Close();

            Program.kotek.tovarzagrsel(Program.kotek.uznat);
        }
    }
}
