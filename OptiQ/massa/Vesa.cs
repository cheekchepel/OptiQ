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
using System.Data.OleDb;
using System.Reflection;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;

namespace OptiQ
{
    public partial class Vesa : Form
    {
        public Vesa()
        {
            InitializeComponent();
            Program.vesika = this;
        }



        int opana = 0;
        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;


        
        public OleDbConnection cona = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source ="+Environment.CurrentDirectory + @"\BASE\maska.mdb");

        public string sqla;
        public OleDbCommand cmda;
        public OleDbDataReader dra;


        public SqlConnection conoff = new SqlConnection(Global.conectsql);
        public string sqloff;
        public SqlCommand cmdoff;
        public SqlDataReader droff;


        plutovar[] plut = new plutovar[60];
        public DataTable dtSales = new DataTable();
        int kolichestvo = 0;
        int list = 0;
        private void Vesa_Load(object sender, EventArgs e)
        {
            kolichestvo = (Global.y - 91) / 40;
      
           
            for (int i = 0; i < kolichestvo*2; i++)
            {
               
                plut[i] = new plutovar { Dock=DockStyle.Top,Visible=false };
                plut[i].textBox1.Text = ""+i;
                panel7.Controls.Add(plut[i]);
              

            }

            dtSales.Columns.Add("vesi_name", typeof(string));
            dtSales.Columns.Add("pr_plu", typeof(int));
            dtSales.Columns.Add("pr_silka", typeof(int));
            dtSales.Columns.Add("pr_name", typeof(string));
            dtSales.Columns.Add("pr_opis", typeof(string));
            dtSales.Columns.Add("pr_price_ca", typeof(int));

      
            try
            {
                con.Close();
            con.Open();
            sql = "select vesi_name from vesi_prot";
            cmd = new NpgsqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            comboBox1.Items.Clear();
          
            while (dr.Read())
            {

                comboBox1.Items.Add(dr[0]);

            }
            con.Close();
                comboBox1.SelectedIndex = 0;

            }
            catch (NpgsqlException)
            {
                Program.main.KASSA_view();
                Program.msg.Message.Text = "Необходимо интернет подключение";
                Program.msg.Width = 450;
                Program.msg.Show();

            }


}


        public void zagrsel()
        {

            try
            {
                con.Close();
                con.Open();
                sql = "select vesi_name,pr_plu,pr_silka,pr_name,pr_opis,pr_price_ca from product_ves left join product on pr_silka=pr_id left join vesi_prot on pr_vesi_numer=vesi_numer where mg_id =" + Global.IDmagaz+ " order by pr_plu desc";
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                dtSales.Rows.Clear();
                while (dr.Read())
                {

                    dtSales.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4],dr[5]);
           
                }
                con.Close();
                dataGridView1.DataSource = dtSales;


            }
            catch (NpgsqlException)
            {
                Program.main.KASSA_view();
                Program.msg.Message.Text = "Необходимо интернет подключение";
                Program.msg.Width = 450;
                Program.msg.Show();

            }


        }




        public void viewcell()
        {


            for (int i = 0; i < kolichestvo * 2; i++)
            {
                if (i < dtSales.Rows.Count)
                {
                    plut[i].ID = list + i;

                }
                else
                {
                    plut[i].Visible = false;
                }
            }

            panel7.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filter();
        }


        public void filter() {
         
           
           dtSales.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "pr_name", textBox1.Text);
           dtSales.DefaultView.RowFilter += "and vesi_name ='" + comboBox1.Text + "'";


            viewcell();

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            filter();
        }


      

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ШТРИХ-ПРИНТ") {
                shtrish_txt();
            }
            else { massakmdb(); }
            
           // Program.msg.Width = 400;
          //  Program.msg.Message.Text = "Файл создан на рабочем столе";Program.msg.ShowDialog();

            if (dataGridView1.Rows.Count > 0)
            {

                opana = dataGridView1.Rows.Count-1;

                PrintDocument printDocument = new PrintDocument();


                printDocument.PrintPage += PrintPageHandler;

               // PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();


              //  printPreviewDialog1.Document = printDocument;
              
               // printPreviewDialog1.ShowDialog();



                try { printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF"; printDocument.Print(); }
                catch
                {

                    try { printDocument.PrinterSettings.PrinterName = "PDF Writer - bioPDF"; printDocument.Print(); }
                    catch
                    {
                        try { printDocument.PrinterSettings.PrinterName = "doPDF 11"; printDocument.Print(); }
                        catch
                        {

                            try { printDocument.PrinterSettings.PrinterName = "Bullzip PDF Printer"; printDocument.Print(); }
                            catch
                            {
                                try
                                {
                                    printDocument.PrinterSettings.PrinterName = "Microsoft MS-XPS Class Driver 2"; printDocument.Print();
                                }
                                catch { MessageBox.Show("Проверьте драйвера печати или обратитесь к поставщику приложения"); }


                            }
                        }
                    }
                }



                //printPreviewDialog1.Document = printDocument;
                //printPreviewDialog1.Width = 1000;
                // printPreviewDialog1.Height = 700;
                //printPreviewDialog1.ShowDialog();


            }



        }

        public void vsetovari()
        {

            grdt_kass.Rows.Clear();

            conoff.Close();
            conoff.Open();
            sqloff = " SELECT pr_id,pr_name FROM product WHERE pr_plu=0 and (LOWER(pr_name) LIKE LOWER(N'%" + textBox6.Text + "%'))";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            while (droff.Read())
            {

                grdt_kass.Rows.Add(false, droff[0], droff[1]);

            }
            conoff.Close();


        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            vsetovari();
        }

        private void grdt_kass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdt_kass.Rows.Count > 0)
            {

                if (Convert.ToBoolean(grdt_kass.Rows[grdt_kass.CurrentRow.Index].Cells[0].Value) == false)
                {

                    grdt_kass.Rows[grdt_kass.CurrentRow.Index].Cells[0].Value = true;


                }
                else { grdt_kass.Rows[grdt_kass.CurrentRow.Index].Cells[0].Value = false; }



            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            textBox6.Text = null;
            vsetovari();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {



          



            int a = 0;
            while (a < grdt_kass.Rows.Count)
            {


                if (Convert.ToBoolean(grdt_kass.Rows[a].Cells[0].Value) == true)
                {
                   
                    int chet = 1;
                    bool bo = true;

                    con.Close();
                    con.Open();
                    sql = "select pr_plu from product_ves where mg_id =" + Global.IDmagaz+ "order by pr_plu asc";
                    cmd = new NpgsqlCommand(sql, con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read() && bo==true)
                    {

                        if (chet == Convert.ToInt32(dr[0]))
                        { chet++; }
                        else
                        { bo = false; }

                    }
                    
                    con.Close();

                   


                    con.Close();
                    con.Open();
                    sql = Global.versia;
                    sql += "INSERT INTO product_ves(pr_vesi_numer,mg_id,pr_plu,pr_silka,pr_opis)"
                    +"select vesi_numer,"+Global.IDmagaz+","+ chet + ","+ grdt_kass.Rows[a].Cells[1].Value + ",'-' from vesi_prot where vesi_name = '"+ comboBox1.Text + "' ";
                    cmd = new NpgsqlCommand(sql, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();

                    con.Close();





                }

                a++;



            }

            zagrsel();
            viewcell();
            textBox6.Text = null;
            vsetovari();



        }



        public void shtrish_txt() {


            string pathold = Environment.CurrentDirectory + @"\BASE\wares.txt";

            string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\wares.txt";

            string date = DateTime.Now.ToString("dd.MM.yy");
            int ket = 0;
            string stroka = "";
            while (ket < dataGridView1.Rows.Count)
            {

                    stroka = dataGridView1.Rows[ket].Cells[1].Value + ";" +
                    dataGridView1.Rows[ket].Cells[3].Value + ";" +
                     dataGridView1.Rows[ket].Cells[4].Value + ";" +
                     dataGridView1.Rows[ket].Cells[5].Value + ";" +
                     "365;0;0;" +
                     dataGridView1.Rows[ket].Cells[1].Value + ";" +
                     "0;0;;" +
                     date + ";0;0;0;0;01.01.01\r\n" + stroka;

                ket++;
            }
            File.WriteAllText(pathold, stroka, Encoding.Default);

            if (File.Exists(path2))
            {
                File.Delete(path2);
            }

            File.Copy(pathold, path2, true);



        }


        public void massakmdb() {






            cona.Close();
            cona.Open();
            sqla = "Delete from Goods";
            cmda = new OleDbCommand(sqla, cona);
            dra = cmda.ExecuteReader();
            dra.Read();
            cona.Close();
           int ket = 0;
            while (ket < dataGridView1.Rows.Count)
            {

                cona.Close();
                cona.Open();
                sqla = "INSERT INTO Goods(ID,Code,Price,ShelfLife,VisibleName,Name,VisibleIngredients,Ingredients,PLU,MainLabelFormatNumber,TotalLabelFormatNumber)" +
                    "VALUES("+dataGridView1.Rows[ket].Cells[1].Value + "," + dataGridView1.Rows[ket].Cells[1].Value + ",'" + dataGridView1.Rows[ket].Cells[5].Value + ",00'," +
                    "365,'" + dataGridView1.Rows[ket].Cells[3].Value + "','" + dataGridView1.Rows[ket].Cells[3].Value + "','" + dataGridView1.Rows[ket].Cells[4].Value + "'," +
                    "'" + dataGridView1.Rows[ket].Cells[4].Value + "'," + dataGridView1.Rows[ket].Cells[1].Value + ",4,9)";
                cmda = new OleDbCommand(sqla, cona);
                dra = cmda.ExecuteReader();
                dra.Read();

                cona.Close();


                ket++;
            }





           
            string sourceFile  = Environment.CurrentDirectory+@"\BASE\maska.mdb";

         
            
            string destinationFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Massak.mdb";



            if (File.Exists(destinationFile))
            {
                File.Delete(destinationFile);
            }

            File.Copy(sourceFile, destinationFile, true);

            




        }






        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
           
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


            
           



                for (int i2 = 0; i2 < 22; i2++)
                {
                    
                    int y = 50*(i2)+50 ;

                    if (opana >= 0)
                    {



                        string plu = dataGridView1.Rows[opana].Cells[1].Value.ToString();

                        string text = dataGridView1.Rows[opana].Cells[3].Value.ToString();

                        string cena = dataGridView1.Rows[opana].Cells[5].Value.ToString()+"ТГ";

                    Pen blackPen = new Pen(Color.Black, 2);
                        e.Graphics.DrawLine(blackPen, 50, y, 775, y);
                        e.Graphics.DrawLine(blackPen, 50, y+50, 775, y+50);
                    e.Graphics.DrawLine(blackPen, 50, y, 50, y+50);
                        e.Graphics.DrawLine(blackPen, 100, y, 100, y + 50);
                        e.Graphics.DrawLine(blackPen, 650, y, 650, y + 50);
                        e.Graphics.DrawLine(blackPen, 775, y, 775, y + 50);
                    var r = new Rectangle(50 , y+3 , 75, 50);
                    var r1 = new Rectangle(100, y+6, 550, 30);
                    var r2 = new Rectangle(650, y+6, 200, 50);
                        e.Graphics.DrawString(plu, new Font("Arial", 25), Brushes.Black, r);
                        e.Graphics.DrawString(text, new Font("Arial", 22), Brushes.Black, r1);
                        e.Graphics.DrawString(cena, new Font("Arial", 22), Brushes.Black, r2);


                        opana--;
                    }
                }



            

            e.HasMorePages = (opana>=0);

        }





    }
}
