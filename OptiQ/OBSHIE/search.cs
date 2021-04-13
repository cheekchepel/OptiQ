using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace OptiQ
{

   

    public partial class search : UserControl
    {
        public search()
        {
            InitializeComponent();
        }
        InputSimulator Simulator = new InputSimulator();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
    }
}
