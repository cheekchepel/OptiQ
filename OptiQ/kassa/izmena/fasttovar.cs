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
    public partial class fasttovar : Form
    {
        public fasttovar()
        {
            InitializeComponent();
        }









        private bool Drag;
        private int MouseX;
        private int MouseY;


        private void PanelMove_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }
        private void PanelMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
                this.Top = Cursor.Position.Y - MouseY;
                this.Left = Cursor.Position.X - MouseX;
            }
        }
        private void PanelMove_MouseUp(object sender, MouseEventArgs e) { Drag = false; }



















        private void fasttovar_Shown(object sender, EventArgs e)
        {
            
            textBox1.Clear();
            textBox1.Focus();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void fasttovar_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Program.main.backblakhide();
            this.Close();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {
               Program.KASA.grdt_kass.Rows.Add(0, "Товар магазина " + Global.MGname,Convert.ToInt32(textBox1.Text), 0, 1,0,Convert.ToInt32(textBox1.Text),0,0,1);
                Program.KASA.n = Program.KASA.grdt_kass.Rows.Count - 1;

                Program.KASA.grdt_kass.ClearSelection();

                Program.KASA.grdt_kass.Rows[Program.KASA.n].Selected = true;
                Program.KASA.index = Program.KASA.n;

                Program.KASA.summa();
                Program.main.backblakhide();
                this.Close();
               
            }
        }

        private void fasttovar_Load(object sender, EventArgs e)
        {
            this.Top = Program.KASA.panel1.Top - this.Height + 40;
            this.Left = Global.x - this.Width - 96;
        }
    }
}
