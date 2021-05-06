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

        public int count = 0;

        public SqlConnection cons = new SqlConnection(Global.conectsql);

        public string sqls;

        public SqlCommand cmds;
        public SqlDataReader drs;



        numerkas[] nmk = new numerkas[16];

        private void Otlojka_Load(object sender, EventArgs e)
        {


            while (opa < 16) {



                nmk[opa] = new numerkas();
                nmk[opa].Visible = false;
               
                flowLayoutPanel2.Controls.Add(nmk[opa]);

                opa++;

            }




        }

        private void Otlojka_Shown(object sender, EventArgs e)
        {
            bunifuVTrackbar1.Value = 0;
            sell();
            if (count > 15)
            {
                bunifuVTrackbar1.Visible = true;
                bunifuVTrackbar1.MaximumValue = (count - 14) * 10;


            }
            else
            {

                bunifuVTrackbar1.Visible = false;


            }

        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            Program.main.backblakhide();
            this.Close();
           // Program.KASA.schet();

        }

        public void sell()
        {
          ;
            int i = 0;

            cons.Close();
            cons.Open();
            sqls = "select ot_id,(SELECT COUNT(*) FROM otlojka_pro),Id,ot_text from otlojka_pro where id_kassir=" + Global.IDuser+ "order by ot_id desc OFFSET " + Convert.ToInt32(Math.Floor(Convert.ToDouble(bunifuVTrackbar1.Value)/10)) + " ROWS";
            cmds = new SqlCommand(sqls, cons);
            drs = cmds.ExecuteReader();

            while (i<15) {
                
                while (drs.Read()&& i < 15)
                {
                   

                    count = Convert.ToInt32(drs[1]);

                    nmk[i].vgruzit(Convert.ToInt64(drs[0]),count -i-Convert.ToInt32(bunifuVTrackbar1.Value / 10), drs[3].ToString());
                    i++;


                }

                nmk[i].Visible = false;
                i++;


            }

             

            cons.Close();


          

            


        }

        private void bunifuVTrackbar1_ValueChanged(object sender, EventArgs e)
        {
            sell();
        }

        private void Otlojka_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            string opa = "'";

            if (number == '$' || number == '%' || number == ',' || number == Convert.ToChar(opa)) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }
    }
}
