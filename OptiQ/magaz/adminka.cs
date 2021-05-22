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
        }

        magaz magaz = new magaz();
        vladelec vladelec = new vladelec();

        private void adminka_Load(object sender, EventArgs e)
        {

            flowLayoutPanel1.Controls.Add(magaz);
            flowLayoutPanel1.Controls.Add(vladelec);

        }
    }
}
