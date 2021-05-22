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

namespace OptiQ
{
    public partial class numerkas : UserControl
    {
        public numerkas()
        {
            InitializeComponent();
            grdt_kass50.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
        }

        public SqlConnection cont = new SqlConnection(Global.conectsql);

        public string sqlt;

        public SqlCommand cmdt;
        public SqlDataReader drt;


        long otl_id = 0;


        public void vgruzit(long id,long num,string text) {

            grdt_kass50.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));

            name.HeaderText = "Клиент " + num;

            textBox1.Text = text;
            panel1.Height = 24;

            otl_id = id;
            grdt_kass50.Rows.Clear();
            cont.Close();
            cont.Open();
            sqlt = "select tov_kod,tov_rz,tov_pies,tov_name from tov_otlojka_pro LEFT JOIN otlojka_pro ON tov_ot_id=ot_id  where tov_ot_id="+id+" and id_kassir=" + Global.IDuser;
            cmdt = new SqlCommand(sqlt, cont);
            drt = cmdt.ExecuteReader();
            while (drt.Read())
            {

                grdt_kass50.Rows.Add(drt[0], drt[1], drt[2], drt[3]);

            }
            cont.Close();

            this.Visible = true;

        }




        public void vigruzet()
        {
            
                int nacht = 0;

               

                string zapros = null;
            string delketzapr = null;
            

                while (nacht < grdt_kass50.Rows.Count)
                {
                    long kod = Convert.ToInt64(grdt_kass50.Rows[nacht].Cells[0].Value);
                    long rz = Convert.ToInt64(grdt_kass50.Rows[nacht].Cells[1].Value);
                    string pies = grdt_kass50.Rows[nacht].Cells[2].Value.ToString().Replace(",", ".");

                Program.KASA.pohav.Rows.Add(kod, rz, pies);
                    
                    zapros += "UPDATE razmer_pro SET rz_pies=((SELECT rz_pies FROM razmer_pro where rz_pr_kod=" + kod + " and rz_id=" + rz + "ORDER BY rz_id DESC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY)+" + pies + ") where rz_id=" + rz + " and rz_pr_kod=" + kod + ";";
                    delketzapr += "delete from tov_otlojka_pro where tov_kod="+kod+" and tov_ot_id=" + otl_id + ";";
                    nacht++;
                }

            
                    delketzapr = "delete from otlojka_pro where id_kassir="+Global.IDuser+" and ot_id=" + otl_id + ";";


                string zaprostext = delketzapr + zapros + "INSERT INTO productoff(pr_text)VALUES(N'" + Global.versia + delketzapr.Replace("'", "$") + zapros.Replace("'", "$") + "');";

            Global.basever++;
            cont.Close();
                cont.Open();
                sqlt = zaprostext;
                cmdt = new SqlCommand(sqlt, cont);
                drt = cmdt.ExecuteReader();
                drt.Read();
                cont.Close();
            Program.KASA.koment.Text = textBox1.Text;


            Program.KASA.poihali();



           


            Program.main.backblakhide();
            Program.ooo.Close();







        }

        private void grdt_kass50_Click(object sender, EventArgs e)
        {
           
         //   vigruzet();
        }

        private void grdt_kass50_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          //  vigruzet();
        }

        private void numerkas_MouseClick(object sender, MouseEventArgs e)
        {
            vigruzet();
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel1.Height == 72)
            { panel1.Height = 24; }
            else { panel1.Height = 72; }
        }

        private void bunifuFlatButton1_MouseClick(object sender, MouseEventArgs e)
        {
          


        }

        private void bunifuFlatButton1_MouseDown(object sender, EventArgs e)
        {
            panel1.Height = 24;


            string zapr = "UPDATE otlojka_pro SET ot_text=N'" + textBox1.Text + "' where ot_id=" + otl_id + "and id_kassir=" + Global.IDuser + ";";


            cont.Close();
            cont.Open();
            sqlt = zapr + "INSERT INTO productoff(pr_text)VALUES(N'" + zapr.Replace("'", "$") + "')";
            cmdt = new SqlCommand(sqlt, cont);
            drt = cmdt.ExecuteReader();
            drt.Read();
            cont.Close();
        }
    }
}
