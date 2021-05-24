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
    public partial class adminka : Form
    {
        public adminka()
        {
            InitializeComponent();
            Program.adminkaa = this;
        }

        magaz magaz = new magaz();
        vladelec vladelec = new vladelec();
        metodopl metodopl = new metodopl();
        user user = new user();
        magopcia magopcia = new magopcia();
        magsetting magsetting = new magsetting();

        private void adminka_Load(object sender, EventArgs e)
        {

            flowLayoutPanel1.Controls.Add(magaz);
            flowLayoutPanel1.Controls.Add(vladelec);           
            flowLayoutPanel1.Controls.Add(metodopl);
            flowLayoutPanel1.Controls.Add(user);
            flowLayoutPanel1.Controls.Add(magopcia);
            flowLayoutPanel1.Controls.Add(magsetting);



           
        }
    }
}
