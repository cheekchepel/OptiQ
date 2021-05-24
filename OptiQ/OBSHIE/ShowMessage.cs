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


    public partial class ShowMessage : Form
    {





        public ShowMessage()
        {
            InitializeComponent();
            Program.msg = this;
        }









        public void uvedomlrnie(string text, int red_blu_elow) {

            this.Opacity = 10D;

            if (red_blu_elow == 1)
            {
                BackColor = Color.FromArgb(114, 137, 218);//cсини

            }
            if(red_blu_elow == 2)
            { 
                BackColor = Color.FromArgb(240, 71, 71);//ккрасни

            }
            if (red_blu_elow == 3)
            {
                BackColor = Color.FromArgb(255, 179, 0);//жжелтии
            }


            Message.Text = text;
            this.Show();
            this.Size = new Size(Message.Width + 48,72);
            this.Location = new Point(0,Global.y+40-this.Height);
            timer1.Enabled = true;
 

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (this.Opacity > 0.1D) { this.Opacity -= 0.02D; } else { timer1.Enabled = false; this.Hide(); }
                

        }
    }
}
