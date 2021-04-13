using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        numerkas[] nmk = new numerkas[15];

        private void Otlojka_Load(object sender, EventArgs e)
        {


            while (opa < 15) {



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
            Program.KASA.schet();

        }

        public void sell()
        {

            for (int i = 0; i < 15; i++)

            {
                if (nmk[i].Visible == false){
                    nmk[i].vgruzit();
                    i = 20;
                    }
                  
                


            }

        }

      
    }
}
