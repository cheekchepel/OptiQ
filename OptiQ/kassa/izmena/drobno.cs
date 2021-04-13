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

namespace OptiQ.kassa.izmena
{
    public partial class drobno : Form
    {
        public drobno()
        {
            InitializeComponent();
        }





        private bool Drag;
        private int MouseX;
        private int MouseY;


        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }
        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
                this.Top = Cursor.Position.Y - MouseY;
                this.Left = Cursor.Position.X - MouseX;
            }
        }
        private void flowLayoutPanel1_MouseUp(object sender, MouseEventArgs e) { Drag = false; }






        InputSimulator Simulator = new InputSimulator();

        private void bunifuFlatButton13_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.KeyPress(VirtualKeyCode.BACK);
        }

        private void bunifuFlatButton3_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton3.Text);
        }

        private void bunifuFlatButton1_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton1.Text);
        }

        private void bunifuFlatButton2_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton2.Text);
        }

        private void bunifuFlatButton4_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton4.Text);
        }

        private void bunifuFlatButton5_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton5.Text);
        }

        private void bunifuFlatButton6_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton6.Text);
        }

        private void bunifuFlatButton9_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton9.Text);
        }

        private void bunifuFlatButton10_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton10.Text);
        }

        private void bunifuFlatButton11_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton11.Text);
        }

        private void bunifuFlatButton12_MouseDown(object sender, EventArgs e)
        {
            Simulator.Keyboard.TextEntry(bunifuFlatButton12.Text);
        }

        private void bunifuFlatButton14_MouseDown(object sender, EventArgs e)
        {

            int indexOfSubstring = textBox1.Text.IndexOf(".");

            if (indexOfSubstring > -1)
            {

               

            }
            else {
                Simulator.Keyboard.TextEntry(bunifuFlatButton14.Text);
            }

          
        }

        private void bunifuFlatButton7_MouseDown(object sender, EventArgs e)
        {
            Program.main.backblakhide();
            this.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void drobno_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != Convert.ToChar(".")) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void drobno_Shown(object sender, EventArgs e)
        {
            textBox1.Clear();

            textBox1.Focus();

            label1.Text = (Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[1].Value).ToString();
        }

        private void drobno_Load(object sender, EventArgs e)
        {
            this.Top = Program.KASA.panel1.Top - this.Height + 40;
            this.Left = Global.x - this.Width - 307;
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            if (Program.KASA.index > -1)
            {

                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value = Convert.ToDouble(textBox1.Text.Replace(".",","));
                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = (Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[2].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value)) - (((Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[2].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value)) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[5].Value)) / 100);
                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = Convert.ToInt64(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value);
                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[7].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[3].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);
                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[8].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[9].Value) - Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);
                Program.KASA.summa();
                Program.main.backblakhide();
                this.Close();

            }
        }
    }
}
