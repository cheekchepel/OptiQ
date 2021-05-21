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
            this.Size =new Size(Message.Width + 80,100);
            this.Left = (Global.x - this.Width)/2;
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
        


    }
}
