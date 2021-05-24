using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptiQ.magaz
{
    public partial class usercell : UserControl
    {
        public usercell()
        {
            InitializeComponent();
        }

        usercontrol usercontrol =new usercontrol();


        int id_us = 0;



        public void load(int id,string name,string kasa) {

            id_us = id;
            nam.Text = name;
            kas.Text = kasa;
            this.Visible = true;


        }

        private void edit_Click(object sender, EventArgs e)
        {
            Program.main.backblakshow();
            usercontrol.id_us = id_us;
            usercontrol.ShowDialog();

        }
    }





    


}
