using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace OptiQ
{
    public partial class login : Form
    {
        public login()
        {

         //   PrivateFontCollection modernFont = new PrivateFontCollection();

          //  modernFont.AddFontFile("OpenSans-ExtraBoldItalic.ttf");

           // this.Font = new Font(modernFont.Families[0], 50);

            InitializeComponent();

           
        }

      

     
        private void login_Load(object sender, EventArgs e)
        {
         
            
        }

        private void pass_text_OnValueChanged(object sender, EventArgs e)
        {
            pass_text.isPassword = true;
            if (String.IsNullOrWhiteSpace(pass_text.Text))
            {
                pass_text.LineIdleColor = Color.Maroon;
            }
            else { pass_text.LineIdleColor = Color.SteelBlue; }

        }

        private void text_login_OnValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(text_login.Text))
            {
                text_login.LineIdleColor = Color.Maroon;
            }
            else { text_login.LineIdleColor = Color.SteelBlue;  }
        }

        private void pass_img_Click(object sender, EventArgs e)
        {

          

        }

     
    }
}
