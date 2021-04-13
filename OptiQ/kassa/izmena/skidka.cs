using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptiQ.kassa.izmena
{
    public partial class skidka : Form
    {
        public skidka()
        {
            InitializeComponent();
        }


        private bool Drag;
        private int MouseX;
        private int MouseY;

        public bool ed = true;


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







        private void skidka_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
           
            
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
         
            this.Close();
            Program.main.backblakhide();
        }

        private void skidka_Shown(object sender, EventArgs e)
        {
            textBox1.Clear();

            textBox1.Focus();

            comboBox1.Items.Clear();



            comboBox1.Items.Add((Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[1].Value).ToString());
            comboBox1.Items.Add("Итоговая сумма");
            comboBox1.SelectedIndex=0;

          
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.Focus();
           
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            if (Program.KASA.index > -1)
            {
                if (comboBox1.SelectedItem.ToString() == "Итоговая сумма")
                {
                    if (textBox1.Text =="" || Convert.ToDouble(textBox1.Text) == 0)
                    {
                        Program.KASA.label4.Visible = false;
                        Program.KASA.bunifuFlatButton16.Text = "0";
                        Program.KASA.bunifuFlatButton16.Visible = false;
                    }
                    else
                    {
                        if (Program.KASA.opend_by == "skidka")
                        {
                            Program.KASA.label4.Text = "Скидка";
                            if (pictureBox1.Visible == true)
                                Program.KASA.bunifuFlatButton16.Text = "-" + Convert.ToDouble(textBox1.Text) + "%";
                            else
                                Program.KASA.bunifuFlatButton16.Text = "-" + Convert.ToDouble(textBox1.Text) + " тг.";
                        }
                        else if (Program.KASA.opend_by == "nacenka")
                        {
                            Program.KASA.label4.Text = "Наценка";
                            if (pictureBox1.Visible == true)
                                Program.KASA.bunifuFlatButton16.Text = "+" + Convert.ToDouble(textBox1.Text) + "%";
                            else
                                Program.KASA.bunifuFlatButton16.Text = "+" + Convert.ToDouble(textBox1.Text) + " тг.";
                        }
                        Program.KASA.label4.Visible = true;
                        Program.KASA.bunifuFlatButton16.Visible = true;
                    }
                }
                else
                {
                    if (pictureBox1.Visible == true)
                    {
                        double cena = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[2].Value);
                        double kol = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);
                        double skidka;
                        if (textBox1.Text == "")
                        {
                            skidka = 0;
                        }
                        else
                        {
                            skidka = Convert.ToDouble(textBox1.Text);
                        }

                        if (Program.KASA.opend_by == "skidka")
                        {
                            if (skidka != 0)
                                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[5].Value = "-" + Convert.ToDouble(textBox1.Text) + "%";
                            else
                                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[5].Value = 0;
                            Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = (cena * kol) * (1 - skidka / 100);
                        }
                        else if (Program.KASA.opend_by == "nacenka")
                        {
                            if (skidka != 0)
                                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[5].Value = "+" + Convert.ToDouble(textBox1.Text) + "%";
                            else
                                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[5].Value = 0;
                            Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = (cena * kol) * (1 + skidka / 100);
                        }
                        Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = Convert.ToInt64(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value);
                        Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[7].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[3].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);
                        Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[8].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[9].Value) - Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);

                    }
                    else
                    {
                        double cena = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[2].Value);
                        double kol = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);
                        double skidka;
                        if (textBox1.Text == "")
                        {
                            skidka = 0;
                        }
                        else
                        {
                            skidka = Convert.ToDouble(textBox1.Text);
                        }
                        if (Program.KASA.opend_by == "skidka")
                        {
                            if (skidka != 0)
                                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[5].Value = "-" + Convert.ToDouble(textBox1.Text) + " тг.";
                            else
                                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[5].Value = 0;
                            Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = (cena - skidka) * kol;
                        }
                        else if (Program.KASA.opend_by == "nacenka")
                        {
                            if (skidka != 0)
                                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[5].Value = "+" + Convert.ToDouble(textBox1.Text) + " тг.";
                            else
                                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[5].Value = 0;
                            Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = (cena + skidka) * kol;
                        }
                        Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = Convert.ToInt64(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value);
                        Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[7].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[3].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);
                        Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[8].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[9].Value) - Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);

                    }
                }

                Program.KASA.summa();
                Program.main.backblakhide();
                this.Close();
            }
        }

        private void skidka_Load(object sender, EventArgs e)
        {
            this.Top = Program.KASA.panel1.Top - this.Height + 40;
            this.Left = Global.x - this.Width - 307;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == true)
            {
                if (textBox1.Text.Length > 3)
                {
                    textBox1.Text.Remove(3);
                }
                if (Convert.ToInt32("0" + textBox1.Text) > 100)
                {
                    textBox1.Text = "100";


                }
                textBox1.SelectionStart = textBox1.Text.Length;
            }
            else
            {
                if(comboBox1.SelectedItem.ToString() != "Итоговая сумма")
                {
                    if (Program.KASA.opend_by == "skidka")
                    {
                        double cena = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[2].Value);
                        if (textBox1.Text.Length > 0 && Convert.ToDouble(textBox1.Text) > cena)
                        {
                            textBox1.Text = cena.ToString();
                        }
                    }
                }
                else
                {
                    if(Program.KASA.opend_by == "skidka")
                    {
                        if(textBox1.Text.Length > 0 && Convert.ToDouble(textBox1.Text) > Convert.ToDouble(Program.KASA.bunifuFlatButton1.Text))
                        {
                            textBox1.Text = Program.KASA.bunifuFlatButton1.Text;
                        }
                    }
                }
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
        }

        private void skidka_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Focus();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }
    }
}
