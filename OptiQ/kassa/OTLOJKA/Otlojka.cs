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
    public partial class Otlojka : Form
    {
        public Otlojka()
        {
            InitializeComponent();
            Program.ooo = this;
        }

         int opa =0;



        public SqlConnection cons = new SqlConnection(Global.conectsql);

        public string sqls;

        public SqlCommand cmds;
        public SqlDataReader drs;



        numerkas[] nmk = new numerkas[20];

        private void Otlojka_Load(object sender, EventArgs e)
        {


            while (opa < 20) {



                nmk[opa] = new numerkas();
                nmk[opa].Visible = false;
                nmk[opa].name.HeaderText = "Клиент "+(opa+1);
                flowLayoutPanel2.Controls.Add(nmk[opa]);

                opa++;

            }




        }

        private void Otlojka_Shown(object sender, EventArgs e)
        {
            sell();

        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            Program.main.backblakhide();
            this.Close();
           // Program.KASA.schet();

        }

        public void sell()
        {
            int i = 0;

            cons.Close();
            cons.Open();
            sqls = "select ot_id from otlojka_pro where id_kassir=" + Global.IDuser;
            cmds = new SqlCommand(sqls, cons);
            drs = cmds.ExecuteReader();

            while (drs.Read()) {

                nmk[i].vgruzit(Convert.ToInt64(drs[0]));

                i++;
            }
            cons.Close();
            while (i < 20){

                nmk[i].Visible=false;

                i++;
            }
            


        }






      
    }
}
