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
    public partial class numpad : UserControl
    {
        public numpad()
        {
            InitializeComponent();
        }
        InputSimulator Simulator = new InputSimulator();

     

        private void bunifuFlatButton12_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.KeyPress(VirtualKeyCode.BACK);
        }

        private void bunifuFlatButton9_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton9.Text);
        }

        private void bunifuFlatButton11_MouseDown(object sender, EventArgs e)
        {
            //Simulator.Keyboard.TextEntry(bunifuFlatButton11.Text);
        }

        private void bunifuFlatButton10_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton10.Text);
        }

        private void bunifuFlatButton8_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton8.Text);
        }

        private void bunifuFlatButton7_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton7.Text);
        }

        private void bunifuFlatButton6_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton6.Text);
        }

        private void bunifuFlatButton5_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton5.Text);
        }

        private void bunifuFlatButton4_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton4.Text);
        }

        private void bunifuFlatButton2_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton2.Text);
        }

        private void bunifuFlatButton1_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton1.Text);
        }

        private void bunifuFlatButton3_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton3.Text);
        }
    }
}
