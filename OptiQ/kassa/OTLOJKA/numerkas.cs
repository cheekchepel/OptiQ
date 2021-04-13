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
    public partial class numerkas : UserControl
    {
        public numerkas()
        {
            InitializeComponent();
        }




        public void vgruzit() {


            if (Program.KASA.grdt_kass.Rows.Count  > 0)
            {
                int keetti = 0;

                while (keetti < Program.KASA.grdt_kass.Rows.Count )
                {
                   grdt_kass50.Rows.Add(Program.KASA.grdt_kass.Rows[keetti].Cells[0].Value, Program.KASA.grdt_kass.Rows[keetti].Cells[1].Value, Program.KASA.grdt_kass.Rows[keetti].Cells[2].Value, Program.KASA.grdt_kass.Rows[keetti].Cells[3].Value, Program.KASA.grdt_kass.Rows[keetti].Cells[4].Value, Program.KASA.grdt_kass.Rows[keetti].Cells[5].Value, Program.KASA.grdt_kass.Rows[keetti].Cells[6].Value, Program.KASA.grdt_kass.Rows[keetti].Cells[7].Value, Program.KASA.grdt_kass.Rows[keetti].Cells[8].Value);

                    keetti++;
                }
                this.Visible = true;
                Program.KASA.grdt_kass.Rows.Clear();
                grdt_kass50.ClearSelection();
            }
                
        }




        public void vigruzet()
        {
            Program.ooo.Close();
           

            int keetti = 0;

                while (keetti < grdt_kass50.Rows.Count )
                {
                
                Program.KASA.grdt_kass.Rows.Add(grdt_kass50.Rows[keetti].Cells[0].Value, grdt_kass50.Rows[keetti].Cells[1].Value, grdt_kass50.Rows[keetti].Cells[2].Value, grdt_kass50.Rows[keetti].Cells[3].Value, grdt_kass50.Rows[keetti].Cells[4].Value, grdt_kass50.Rows[keetti].Cells[5].Value, grdt_kass50.Rows[keetti].Cells[6].Value, grdt_kass50.Rows[keetti].Cells[7].Value, grdt_kass50.Rows[keetti].Cells[8].Value);
                keetti++;

            }
                this.Visible = false;
                 grdt_kass50.Rows.Clear();
            Program.main.backblakhide();
            Program.KASA.schet();
            Program.KASA.summa();
            //  Program.KASA.kassadeletrow();


        }

        private void grdt_kass50_Click(object sender, EventArgs e)
        {
           
            vigruzet();
        }

        private void grdt_kass50_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vigruzet();
        }

        private void numerkas_MouseClick(object sender, MouseEventArgs e)
        {
            vigruzet();
        }
    }
}
