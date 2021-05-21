
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace OptiQ
{
    public partial class productcell : UserControl
    {
        public productcell()
        {
            InitializeComponent();
        }



        public SqlConnection con = new SqlConnection(Global.conectsql);

        public string sql;
        public SqlCommand cmd;
        public SqlDataReader dr;



        public long idtov;
        public int colsoz;
        private double res;





        public void editTrue() {

    
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
          
            edit.Visible = false;
            close.Visible = true;
            savebut.Visible = true;
            textBox4.Focus();
            bunifuFlatButton1.Visible = false;

        }

        public void editFalse() {

           
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
       
            edit.Visible = true;
            close.Visible = false;
            savebut.Visible = false;
            bunifuFlatButton1.Visible = true;
        }

        public void add(long id,long kod,string name,int cenaco, int cenaca,string kol,bool chek) {

               
                idtov = id;
                textBox1.Text = kod.ToString();
                textBox2.Text = name;
                textBox3.Text = cenaco.ToString();
                textBox4.Text = cenaca.ToString();
                textBox5.Text = kol;
                cheker.Checked = chek;
                this.Visible = true;
                editFalse();


        }

        private void close_Click(object sender, EventArgs e)
        {
            editFalse();

        }


     
        private void savebut_Click(object sender, EventArgs e)
        {
            bool isInt = Double.TryParse(textBox5.Text.Replace(".", ",") + "0", out res);

            if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text) && !String.IsNullOrWhiteSpace(textBox3.Text) && !String.IsNullOrWhiteSpace(textBox4.Text) && !String.IsNullOrWhiteSpace(textBox5.Text)&& isInt == true )
            {
               
                    Global.basever++;
                    con.Open();
                    
                    sql = "UPDATE product_pro Set pr_name=N'" + textBox2.Text + "',pr_price_co=" + textBox3.Text + ",pr_price_ca=" + textBox4.Text + " where pr_kod=" + textBox1.Text + " and pr_mg_id="+Global.IDmagaz+";";
                    sql += "INSERT INTO productoff(pr_text)VALUES(N'"+ (Global.versia + sql).Replace("'","$")+"')";

                    cmd = new SqlCommand(sql, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    con.Close();

                    editFalse();





             
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            editTrue();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != '.') // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void productcell_Load(object sender, EventArgs e)
        {
            this.Width = Global.x-44 ;
            edit.Visible = Global.pra_eidittov;
            panel3.Visible = Global.pra_showprih;
            bunifuFlatButton1.Visible = Global.pra_eidittov;
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {



            con.Open();

            sql = "UPDATE product_pro Set pr_chek='" + cheker.Checked + "' where pr_kod=" + textBox1.Text + " and pr_mg_id=" + Global.IDmagaz + ";";

            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();





        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Program.main.backblakshow();
            Program.addprd.shtrih = textBox1.Text;
            Program.addprd.ShowDialog();
            
        }
    }
}
