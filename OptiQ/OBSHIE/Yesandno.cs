using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptiQ.OBSHIE
{
    public partial class Yesandno : Form
    {
        public Yesandno()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Global.yesno = false;
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Global.yesno = true;
            this.Close();
        }
    }
}
