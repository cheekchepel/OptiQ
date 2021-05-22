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

        private void close_Click(object sender, EventArgs e)
        {
            cloce();
        }

        private void ShowMessage_Shown(object sender, EventArgs e)
        {

        }

        private void Message_TextChanged(object sender, EventArgs e)
        {
         //  
        }

        private void ShowMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { cloce(); }
        }

        public void cloce()
        {
            Program.zakup.blackback.Hide();
            Program.main.backblakhide();
            this.Hide();
        }




        public void uvedomlrnie(string text, int red_blu_elow) {

            this.Opacity = 9.9D;

            if (red_blu_elow == 1)
            {
                BackColor = Color.FromArgb(114, 137, 218);

            }
            if(red_blu_elow == 2)
            { 
                BackColor = Color.FromArgb(240, 71, 71);

            }
            if (red_blu_elow == 3)
            {
                BackColor = Color.FromArgb(255, 179, 0);
            }



                Message.Text = text;
            this.Show();
            this.Width = Message.Width + 20;
            this.Location = new Point(0,Global.y+40-this.Height);
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity-= 0.02D;
            if (Opacity <= 0.15D) { timer1.Enabled = false;this.Hide(); }

        }
    }
}
