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
    public partial class vladelec : UserControl
    {
        public vladelec()
        {
            InitializeComponent();
        }

        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);


        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;


        private void bunifuFlatButton15_Click(object sender, EventArgs e)
        {
            save();
            select();
        }

       

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            select();
        }

        public void select() {

            pass.Enabled = false;
            newpass.Enabled = false;
            panel4.Visible = true;
            panel3.Visible = true;
            panel6.Visible = false;
            newpass.Text = null;
            see.Visible = false;
            see2.Visible = false;


            con.Close();
            con.Open();
            sql = $"select mg_us_name,mg_us_login,mg_us_pass from magaz where mg_id ={Global.IDmagaz};";
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                name.Text = dr[0].ToString();
                login.Text = dr[1].ToString();
                pass.Text = dr[2].ToString();
            }
            con.Close();


        }

        public void save() {


            if (String.IsNullOrWhiteSpace(name.Text) || String.IsNullOrWhiteSpace(login.Text))
            { Program.msg.uvedomlrnie("Заполните все поля", 3); return; }


            if (edit.Visible == true)
            {

                con.Close();
                con.Open();
                sql = $"select mg_us_login from magaz where mg_us_login ='{login.Text}' and mg_id!={Global.IDmagaz};";
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                { Program.msg.uvedomlrnie("Пользователь с таким логином уже существует", 3); return; } 
                con.Close();

                con.Close();
                con.Open();
                sql = $"UPDATE magaz SET mg_us_name='{name.Text}', mg_us_login='{login.Text}' WHERE mg_id ={Global.IDmagaz};";
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                con.Close();
                Program.msg.uvedomlrnie("Данные с успешно изменены", 1);
            }
            else {

                if (String.IsNullOrWhiteSpace(pass.Text) || String.IsNullOrWhiteSpace(newpass.Text))
                { Program.msg.uvedomlrnie("Заполните все поля", 3); return; }
                if (pass.Text != newpass.Text)
                { Program.msg.uvedomlrnie("Пароли не совпадают", 2); return; }

                string hash = Program.log.GetHash(pass.Text);
                con.Close();
                con.Open();
                sql = $"UPDATE magaz SET mg_us_pass='{hash}' WHERE mg_id ={Global.IDmagaz};";
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                con.Close();
                Program.msg.uvedomlrnie("Данные с успешно изменены", 1);



            }

        
        
        
        
        }

        private void edit_Click(object sender, EventArgs e)
        {
            pass.Enabled = true;
            newpass.Enabled = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel6.Visible = true;
            pass.Text = null;
            see.Visible = true;
            see2.Visible = true;
            edit.Visible = false;
        }

        private void see_MouseDown(object sender, EventArgs e)
        {
            pass.PasswordChar ='\0';
        }

        private void see_MouseUp(object sender, EventArgs e)
        {
            pass.PasswordChar = '•';
        }

        private void see_MouseLeave(object sender, EventArgs e)
        {
            if (pass.PasswordChar == '\0') { pass.PasswordChar = '•'; }           
        }

        private void bunifuFlatButton1_MouseDown(object sender, EventArgs e)
        {
            newpass.PasswordChar = '\0';
        }

        private void bunifuFlatButton1_MouseLeave(object sender, EventArgs e)
        {
            if (newpass.PasswordChar == '\0') { newpass.PasswordChar = '•'; }
        }

        private void bunifuFlatButton1_MouseUp(object sender, EventArgs e)
        {
            newpass.PasswordChar = '•';
        }

        private void vladelec_Load(object sender, EventArgs e)
        {
            select();
        }
    }
}
