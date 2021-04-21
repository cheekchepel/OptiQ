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
            Program.main.backblakhide();
            this.Hide();
        }

        private void ShowMessage_Shown(object sender, EventArgs e)
        {
            this.Size =new Size(Message.Width + 80,100);
        }

        private void Message_TextChanged(object sender, EventArgs e)
        {
         //  
        }
    }
}
