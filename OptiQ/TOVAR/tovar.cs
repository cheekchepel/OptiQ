using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace OptiQ
{
    public partial class tovar : Form
    {


        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;


        productcell[] sel = new productcell[60];
        public addtovar add = new addtovar();

       public revizia rev = new revizia();

        Zakup zakup = new Zakup();


      public  DataTable dtSales = new DataTable();

        int list = 0;
        private double res;


        int kolichestvo = 0;
        int opana = 0;

        public tovar()
        {
            InitializeComponent();
            Program.tov = this;
        }

        Image img;
        Point imgpo = new Point(0, 0);
        Point imgsz = new Point(0, 0);
        BarcodeWriter qr = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };



        public void zagrsel()
        {

            try
            {
                con.Close();
                con.Open();
                sql = "select pr_id,pr_kod,pr_name,pr_price_co,pr_price_ca,pr_piec from product where pr_mg_id =" + Global.IDmagaz;
                cmd = new NpgsqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                dtSales.Rows.Clear();
                while (dr.Read())
                {

                    dtSales.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], (dr[5].ToString()).Replace(",", "."),false);
                    // dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], (dr[5].ToString()).Replace(",","."));
                }
                con.Close();

                dataGridView1.DataSource = dtSales;

            }
            catch (NpgsqlException) { 
            Program.main.KASSA_view();
                Program.msg.Message.Text = "Необходимо интернет подключение";
                Program.msg.Width = 450;
                Program.msg.Show(); 
               
            }


        }











        private void tovar_Load(object sender, EventArgs e)
        {


            panel10.Visible = Global.pra_showprih;
            panel16.Visible = Global.pra_eidittov;

            kolichestvo = (Global.y - 96) / 40;
          

            createcell();

            dtSales.Columns.Add("pr_id", typeof(int));
            dtSales.Columns.Add("pr_kod", typeof(string));
            dtSales.Columns.Add("pr_name", typeof(string));
            dtSales.Columns.Add("pr_co", typeof(int));
            dtSales.Columns.Add("pr_ca", typeof(int));
            dtSales.Columns.Add("pr_piec", typeof(string));

            dtSales.Columns.Add("pr_pechat", typeof(bool));

           

        

        }


        public void viewcell()
        {
         

            for ( int i =0; i < kolichestvo*2; i++)
            { 
                if (i < dtSales.Rows.Count)
                {
                    sel[i].ID = list + i;
                   
                }
                else {
                    sel[i].Visible = false;
                }
            }

           flowLayoutPanel1.Visible = true;
        }



       public void createcell()
        {

            for (int i = 0; i < kolichestvo * 2; i++) {
                
                sel[i] = new productcell ();
                sel[i].ID = i;
                flowLayoutPanel1.Controls.Add(sel[i]);


            }

        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            Program.main.backblakshow();
            add.shtrih = null;
            add.ShowDialog();
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bunifuiOSSwitch1.Value = false;
            timer1.Enabled = false;
            timer1.Enabled = true;
        }

        private void tovar_Shown(object sender, EventArgs e)
        {
           
            
        }


   



        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Program.main.backblakshow();
            zakup.ShowDialog();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Program.main.backblakshow();
            
            rev.ShowDialog();

        }

        private void flowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            if (flowLayoutPanel1.VerticalScroll.Value > (10*40))
            {
                list += 5;

                flowLayoutPanel1.VerticalScroll.Value = (5 * 40);
                viewcell();
            }
            else if (list!=0&& flowLayoutPanel1.VerticalScroll.Value < (5 * 40)) {

                list -= 5;

                flowLayoutPanel1.VerticalScroll.Value = (10 *40) ;   
                viewcell();
            }
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
           
                
                list = 0;
            flowLayoutPanel1.VerticalScroll.Value = 0;
                bool isInt = Double.TryParse(textBox1.Text + "0", out res);
                if (isInt == true) { dtSales.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "pr_kod", textBox1.Text); }
                else { dtSales.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "pr_name", textBox1.Text); }
            flowLayoutPanel1.Visible = false;
              
                viewcell();

           
        }

       

        private void bunifuiOSSwitch1_MouseClick(object sender, MouseEventArgs e)
        {
            if (bunifuiOSSwitch1.Value == true) { dtSales.DefaultView.RowFilter = "pr_pechat=true"; }
            else { dtSales.DefaultView.RowFilter = null; }
            flowLayoutPanel1.Visible = false;
            viewcell();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            dtSales.DefaultView.RowFilter = "pr_pechat=true";
            if (dataGridView1.Rows.Count > 0)
            {
            
                opana = 0;

                PrintDocument printDocument = new PrintDocument();
               

                printDocument.PrintPage += PrintPageHandler;


                

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

            
                zagrsel();
                flowLayoutPanel1.Visible = false;
                viewcell();
            }

        }




        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle sourceRectangle = new Rectangle(0, 50, 126, 63);

            Pen blackPen = new Pen(Color.Black, 2);
            e.Graphics.DrawLine(blackPen, 287, 0, 287, 1500);
            e.Graphics.DrawLine(blackPen, 547, 0, 547, 1500);
            e.Graphics.DrawLine(blackPen, 0, 147, 1500, 145);
            e.Graphics.DrawLine(blackPen, 0, 292, 1500, 290);
            e.Graphics.DrawLine(blackPen, 0, 437, 1500, 435);
            e.Graphics.DrawLine(blackPen, 0, 582, 1500, 580);
            e.Graphics.DrawLine(blackPen, 0, 727, 1500, 725);
            e.Graphics.DrawLine(blackPen, 0, 872, 1500, 870);
            e.Graphics.DrawLine(blackPen, 0, 1017, 1500, 1015);

            for (int i = 0; i < 8; i++) {
                for (int i2 = 0; i2 < 3; i2++)
                {
                    int x = 260 * (i2)+55;
                    int y = 145 * (i)+65;

                    if (opana < dataGridView1.Rows.Count)
                    {

                        img = qr.Write(dataGridView1.Rows[opana].Cells[1].Value.ToString());



                        string text = dataGridView1.Rows[opana].Cells[2].Value.ToString();

                       

                        Rectangle destRectangle = new Rectangle(x, y, 200, 100);

                        var r = new Rectangle(x-15, y - 55, 230, 50);
                        // e.Graphics.DrawImage(img,x,y,200,50);

                        e.Graphics.DrawString(text, new Font("Arial", 16), Brushes.Black, r);

                        e.Graphics.DrawImage(img, destRectangle, sourceRectangle, GraphicsUnit.Pixel);
                        opana++;
                    }
                }
              
               

            }

            e.HasMorePages = (opana < dataGridView1.Rows.Count);

        }
    }
}
