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
    public partial class Vibrazer : Form
    {
        public Vibrazer()
        {
            InitializeComponent();
        }

        long pr_kod1;
        string pr_name1;
        int pr_price_co1;
        int pr_price_ca1;
        int pr_optom1;

        int clic = -1;

        


        private void Vibrazer_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Program.KASA.textBox1.Text = null;
            Program.main.backblakhide();
            Close();
        }

        private void Vibrazer_Load(object sender, EventArgs e)
        {
            clic = -1;
            
            grdt_kass.DataSource = Program.KASA.dtSales;
            
            grdt_kass.Columns[0].Visible = false;
            grdt_kass.Columns[2].Visible = Global.pra_showpie;
          
            grdt_kass.ClearSelection();
           
           

        }


        public void uznat(long pr_kod, string pr_name, int pr_price_co, int pr_price_ca, int pr_optom) {

             pr_kod1= pr_kod;
             pr_name1= pr_name;
            label1.Text = pr_name;
            pr_price_co1 = pr_price_co;
             pr_price_ca1 = pr_price_ca;
             pr_optom1= pr_optom;


        }

        private void bunifuFlatButton15_Click(object sender, EventArgs e)
        {
            if (clic > -1)
            {
                double pies = Convert.ToDouble(grdt_kass.Rows[clic].Cells[2].Value.ToString().Replace(".", ","));
                string rz_name = grdt_kass.Rows[clic].Cells[1].Value.ToString();
                long rz_id = Convert.ToInt64(grdt_kass.Rows[clic].Cells[0].Value);
                Program.KASA.adda(pr_kod1, pr_name1, pr_price_co1, pr_price_ca1, pr_optom1, pies, "[" + rz_name+"] ", rz_id);
                    Program.main.backblakhide();
                    Close();
                
               
                

            }
           

        }

        private void Vibrazer_Shown(object sender, EventArgs e)
        {
            grdt_kass.ClearSelection();
            grdt_kass.Columns[2].Width = 90;
        }
       

        private void grdt_kass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clic = -1;
            grdt_kass.ClearSelection();

           
            if (grdt_kass.Rows.Count > 0)
            {
                clic = grdt_kass.CurrentRow.Index;
                grdt_kass.Rows[clic].Selected = true;
            }
        }
    }
}
