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

namespace OptiQ.TOVAR.PRIHOD
{
    public partial class prihodpostav : Form
    {
        public prihodpostav()
        {
            InitializeComponent();
        }



        public SqlConnection con = new SqlConnection(Global.conectsql);
        public string sql;
        public SqlCommand cmd;
        public SqlDataReader dr;


        private void prihodpostav_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            string opa = "'";

            if (number == '$' || number == '%' || number == ',' || number == Convert.ToChar(opa)) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }


        public void select() {



            con.Close();
            con.Open();
            sql = "select pr_kod,pr_name,pr_price_co,pr_price_ca,pr_optom,rz_id,rz_name,pr_provid from product_pro LEFT JOIN razmer_pro ON rz_pr_kod = pr_kod WHERE not rz_id is null and not rz_id in (select rz_id from prihod) and pr_provid =N'" + text2.Text + "' and (LOWER(pr_name) LIKE LOWER(N'%" + textBox1.Text + "%'))";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int a = 0;
                bool b = false;
                while (a < grdt_kass.Rows.Count) {


                    if (Convert.ToInt64(grdt_kass.Rows[a].Cells[1].Value) == Convert.ToInt64(dr[0]) && Convert.ToInt64(grdt_kass.Rows[a].Cells[6].Value) == Convert.ToInt64(dr[5]))
                    {
                        
                        b = true;
                        a = grdt_kass.Rows.Count;

                    }
                    a++;
                }

                if (b == false) {

                    grdt_kass.Rows.Add(false, dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);

                }

                


            }
            con.Close();




        }

        public void clear()
        {


            int a = 0;
            while (a < grdt_kass.Rows.Count)
            {

                if (Convert.ToBoolean(grdt_kass.Rows[a].Cells[0].Value) == false)
                {

                    grdt_kass.Rows.RemoveAt(a);

                }
                else {
                    a++;
                }
                
            }




        }

        private void grdt_kass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = grdt_kass.CurrentRow.Index;

           if(Convert.ToBoolean(grdt_kass.Rows[a].Cells[0].Value) == true){

                grdt_kass.Rows[a].Cells[0].Value = false;

           }
           else
           {
                grdt_kass.Rows[a].Cells[0].Value = true;
           }


            
        }


        public void postav(string name)
        {

            text2.Items.Clear();
            text2.Items.Add("Нет");


            con.Close();
            con.Open();
            sql = "select mp_name from myprov where mp_mg_id = " + Global.IDmagaz;
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                text2.Items.Add(dr[0]);

            }
            con.Close();
            text2.SelectedIndex = 0;
            text2.Text = name;

        }

        private void prihodpostav_Load(object sender, EventArgs e)
        {
            postav(Program.zakup.text6.Text);
            grdt_kass.Rows.Clear();
            select();
        }

        private void text2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            clear();
            select();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            clear();
            select();
            
            
        }

        private void close_Click(object sender, EventArgs e)
        {
           Program.zakup.prihpos_close();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

            int a = 0;
            while (a < grdt_kass.Rows.Count)
            {
                if (Convert.ToBoolean(grdt_kass.Rows[a].Cells[0].Value) == true)
                {

                    long kod = Convert.ToInt64(grdt_kass.Rows[a].Cells[1].Value);
                    string name = grdt_kass.Rows[a].Cells[2].Value.ToString();
                    int co = Convert.ToInt32(grdt_kass.Rows[a].Cells[3].Value);
                    int ca = Convert.ToInt32(grdt_kass.Rows[a].Cells[4].Value);
                    int opt = Convert.ToInt32(grdt_kass.Rows[a].Cells[5].Value);
                    long rz = Convert.ToInt64(grdt_kass.Rows[a].Cells[6].Value);

                    con.Close();
                    con.Open();

                    sql = "insert into prihod(kod,name,cena_co,cena_ca,cena_opt,rz_id,kol)" +
                        " VALUES (" + kod + ",N'" + name + "'," + co + "," + ca + "," + opt + "," + rz + ",0)";
                    cmd = new SqlCommand(sql, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    con.Close();
                }


                a++;
                

            }

            Program.zakup.prihpos_close();
            if (Program.zakup.bunifuVTrackbar1.Value == 0)
            {

                Program.zakup.select();

            }

            Program.zakup.bunifuVTrackbar1.Value=0;

        }
    }
}
