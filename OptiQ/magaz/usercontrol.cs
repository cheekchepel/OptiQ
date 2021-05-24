using Npgsql;
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
    public partial class usercontrol : Form
    {
        public usercontrol()
        {
            InitializeComponent();
        }

        bool nas_prav = true;

        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;


        public int id_us = 0;


        private void smenna_Click(object sender, EventArgs e)
        {
            nas_prav = true;
            color_nas();
        }


        public void color_nas() {

            if (nas_prav)
            {

                this.nastr.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));

                this.nastr.Textcolor = System.Drawing.Color.White;


                this.razresh.Normalcolor = System.Drawing.Color.White;

                this.razresh.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
                pnas.Visible = true;
                pprav.Visible = false;

            }
            else {

                
                this.razresh.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));

                this.razresh.Textcolor = System.Drawing.Color.White;


                this.nastr.Normalcolor = System.Drawing.Color.White;

                this.nastr.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
                pnas.Visible = false;
                pprav.Visible = true;

            }

        
        
        }


        private void razresh_Click(object sender, EventArgs e)
        {
            nas_prav = false;
            color_nas();
        }

        private void usercontrol_Load(object sender, EventArgs e)
        {
            this.Height = 410;
            nas_prav = true;
            color_nas();
            select();
        }

        private void usercontrol_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;


            if (number == '$' || number == '%' || number == ',' || number == Convert.ToChar("'")) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }




        public void select() {

            con.Close();
            con.Open();

            sql = $"select sir_name,sir_user,sir_login,sir_pass from kassir where sir={id_us};";
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                kasname.Text = dr[0].ToString();
                usname.Text = dr[1].ToString();
                login.Text = dr[2].ToString();
                pass.Text = dr[3].ToString();
            }
            con.Close();

            con.Close();
            con.Open();
            sql = $"select pra_eidittov,pra_editpri,pra_showpie,pra_showprih,pra_showdohd,pra_showreviz,pra_editkotak from prava where  pra_id_kassir={id_us};";
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tovred.Checked =Convert.ToBoolean(dr[0]) ;
                cenared.Checked = Convert.ToBoolean(dr[1]);
                showpie.Checked = Convert.ToBoolean(dr[2]);
                showco.Checked = Convert.ToBoolean(dr[3]);
                showdoh.Checked = Convert.ToBoolean(dr[4]);
                showrev.Checked = Convert.ToBoolean(dr[5]);
                kotred.Checked = Convert.ToBoolean(dr[6]);


            }
            con.Close();





        }

        public void save() {


            if (String.IsNullOrWhiteSpace(kasname.Text) || String.IsNullOrWhiteSpace(usname.Text) || String.IsNullOrWhiteSpace(login.Text) || String.IsNullOrWhiteSpace(pass.Text))
            { Program.msg.uvedomlrnie("Заполните все поля", 3); return; }


            con.Close();
            con.Open();
            sql = $"select sir_login from kassir where sir_login ='{login.Text}' and sir!={id_us};";
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            { Program.msg.uvedomlrnie("Пользователь с таким логином уже существует", 2); return; }
            con.Close();


            con.Open();
                sql = $"UPDATE kassir SET sir_name  ='{kasname.Text}',sir_user  ='{usname.Text}',sir_login ='{login.Text}',sir_pass='{pass.Text}' WHERE sir ={id_us};";
                sql += $"UPDATE prava SET pra_eidittov={tovred.Checked},pra_editpri={cenared.Checked},pra_showpie={showpie.Checked},pra_showprih={showco.Checked},pra_showdohd={showdoh.Checked},pra_showreviz={showrev.Checked},pra_editkotak={kotred.Checked} WHERE pra_id_kassir ={ id_us};";
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                con.Close();

            Program.msg.uvedomlrnie("Данные с успешно изменены", 1);




        }

        private void bunifuFlatButton15_Click(object sender, EventArgs e)
        {
            save();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            select();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Program.main.backblakhide();
            this.Close();
        }
    }
}
