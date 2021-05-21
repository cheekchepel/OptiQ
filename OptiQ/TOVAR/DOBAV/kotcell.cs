using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptiQ.TOVAR.DOBAV
{
    public partial class kotcell : UserControl
    {
        public kotcell()
        {
            InitializeComponent();
        }

        public SqlConnection con = new SqlConnection(Global.conectsql);
        public string sql;
        public SqlCommand cmd;
        public SqlDataReader dr;



        public long ID_chil;

        public int shagmain;

        public bool shouu;

        bool vibor2;

        private void kotcell_Load(object sender, EventArgs e)
        {
            
        }

        public void view(string name,bool marker,long ID_rod, int shag,bool show,bool vibor,bool neuu) {

            

            this.Visible = true;
            text1.Text = name;
            mark.Checked = marker;

            ID_chil = ID_rod;
            shagmain = shag;
            shouu = show;
            vibor2 = vibor;


            if (vibor)
            {
                delete.Visible = false;
                edit.Visible = false;
                text1.Enabled = false;
                mark.Visible = false;
                savebut.Visible = false;
                close.Visible = false;
                create.Visible = false;

            }
            else {


                text1.Enabled = neuu;
                mark.Visible = neuu;
                savebut.Visible = neuu;
                close.Visible = neuu;
                delete.Visible = neuu;
                edit.Visible = !neuu;
                create.Visible = !neuu;

               // text1.Focus();

            }




           





            




            this.Margin = new Padding(40* shag, 0, 0, 0);

            if (shagmain < 4)
            {



                if (shouu)
                {
                    add(vibor);
                }
                else {
                    pookaz.Visible = true;
                }

                

            }
            else { create.Visible = false; pookaz.Visible = false; }
            

        }

        public void add(bool vibor)
        {

            int c = 0;
            con.Close();
            con.Open();
            sql = "select kot_name,kot_marker,kot_chil,show,edit from kotak where kot_mg_id =" + Global.IDmagaz + " and kot_rod=" + ID_chil;
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            while (dr.Read() && Program.kotak.a < 50)
            {
                Program.kotak.a++;
                Program.kotak.koti[Program.kotak.a].view(dr[0].ToString(), Convert.ToBoolean(dr[1]), Convert.ToInt64(dr[2]), shagmain + 1, Convert.ToBoolean(dr[3]), vibor, Convert.ToBoolean(dr[4]));

                c = 2;
            }
            if (c == 0) { pookaz.Visible = false; } else { pookaz.Visible = true; }

            con.Close();




        }

        private void delete_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            sql = "delete from kotak where kot_mg_id =" + Global.IDmagaz + " and kot_chil=" + ID_chil+";";
            sql += "INSERT INTO productoff(pr_text)VALUES(N'" + (sql).Replace("'", "$") + "');";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();
            Program.kotak.add();
        }

        private void create_Click(object sender, EventArgs e)
        {

            long id = Convert.ToInt64(Global.IDuser + "" + DateTimeOffset.Now.ToUnixTimeMilliseconds());

            string serv = null;

            con.Close();
            con.Open();
            sql = "UPDATE kotak Set edit='false' where kot_mg_id=" + Global.IDmagaz + ";";

            sql += "INSERT INTO kotak(kot_mg_id,kot_name,kot_rod,kot_chil,kot_marker,show,edit)VALUES(" + Global.IDmagaz + ",N' ',"+ ID_chil + ","+ id + ",'false','true','true');";

            serv = "INSERT INTO productoff(pr_text)VALUES(N'" + ("INSERT INTO kotak(kot_mg_id,kot_name,kot_rod,kot_chil,kot_marker)VALUES(" + Global.IDmagaz + ",N' '," + ID_chil + "," + id + ",'false');").Replace("'", "$") + "');";

            cmd = new SqlCommand(sql+ serv, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();
            Program.kotak.add();

        }

        private void close_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            sql = "UPDATE kotak Set edit='false' where kot_mg_id=" + Global.IDmagaz + ";";

            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();



            Program.kotak.add();
        }

        private void edit_Click(object sender, EventArgs e)
        {

            text1.Enabled = true;
            mark.Visible = true;
            savebut.Visible = true;
            close.Visible = true;
            delete.Visible = true;
            pookaz.Visible = false;

            
            edit.Visible = false;
            create.Visible = false;

        }

        private void savebut_Click(object sender, EventArgs e)
        {

            string serv = null;

            con.Close();
            con.Open();
            sql += "UPDATE kotak Set edit='false', kot_name=N'" + text1.Text + "',kot_marker='" + mark.Checked + "' where kot_chil=" + ID_chil + " and kot_mg_id=" + Global.IDmagaz + ";";
            serv = "INSERT INTO productoff(pr_text)VALUES(N'" + ("UPDATE kotak Set kot_name = N'" + text1.Text + "',kot_marker = '" + mark.Checked + "' where kot_chil = " + ID_chil + " and kot_mg_id = " + Global.IDmagaz + ";").Replace("'", "$") + "');";
            cmd = new SqlCommand(sql+ serv, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();
            Program.kotak.add();

        }

        private void pookaz_Click(object sender, EventArgs e)
        {
            if (shouu == true) { shouu = false; } else { shouu = true; }

            con.Close();
            con.Open();
            sql = "UPDATE kotak Set show=N'" + shouu + "' where kot_chil=" + ID_chil + " and kot_mg_id=" + Global.IDmagaz + ";";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            con.Close();
            Program.kotak.add();

        }

        private void text1_MouseDown(object sender, MouseEventArgs e)
        {
            if (vibor2) {

                Program.addprd.katid = ID_chil;
                Program.addprd.kotname.Text = text1.Text;
                Program.zakup.blackback.Hide();
                Program.kotak.Close();
            }
            
        }

        private void text1_MouseHover(object sender, EventArgs e)
        {
            if (vibor2) {

                flowLayoutPanel1.BackColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));

            }
                
        }

        private void text1_MouseLeave(object sender, EventArgs e)
        {
            

                flowLayoutPanel1.BackColor = Color.White;

            
        }
    }
}
