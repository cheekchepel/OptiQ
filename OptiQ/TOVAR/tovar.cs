using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

using System.Windows.Forms;
using ZXing;
using System.IO;
using System.Data.SqlClient;
using OptiQ.TOVAR.DOBAV;

namespace OptiQ
{
    public partial class tovar : Form
    {


        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;



        public SqlConnection conoff = new SqlConnection(Global.conectsql);
        public string sqloff;
        public SqlCommand cmdoff;
        public SqlDataReader droff;


        productcell[] sel = new productcell[25];
        public addtovar add = new addtovar();

        public Kotak kot = new Kotak();

        public revizia rev = new revizia();

        Zakup zakup = new Zakup();

        DataTable pechat = new DataTable();




       int vobshem=0;

       Excel.Application xlApp = new Excel.Application();




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
       

        public void zagrsel(bool isk)
        {
            string filter = "";

            bool isInt = Double.TryParse(textBox1.Text + "0", out res);


            if (bunifuiOSSwitch1.Value==true)
            {
                filter = "and pr_chek='" + bunifuiOSSwitch1.Value + "'";
            }
            else
            {
                if (isInt == true) { filter = "and CAST(pr_kod AS VARCHAR(20)) LIKE N'%" + textBox1.Text + "%'"; }
                else { filter = " and LOWER(pr_name) LIKE LOWER(N'%" + textBox1.Text + "%')"; }
            }


            vobshem = 0;
            int a = 0;
            conoff.Close();
            conoff.Close();
                conoff.Open();
                sqloff = "select pr_id,pr_kod,pr_name,pr_price_co,pr_price_ca,(SELECT SUM(rz_pies) as sum FROM razmer_pro WHERE rz_mg_id =" + Global.IDmagaz+ " and rz_pr_kod =pr_kod),pr_chek from product_pro where pr_mg_id =" + Global.IDmagaz+" "+ filter+ " order by pr_id asc OFFSET " + bunifuVTrackbar1.Value + " ROWS";
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();

                while (a<kolichestvo)
                {
                    while (droff.Read())
                    {
                   
                        vobshem++;
                        if (a < kolichestvo)
                        {

                        long id = Convert.ToInt64(droff[0]);
                        long kod = Convert.ToInt64(droff[1]);
                        string name = droff[2].ToString();
                        int cenaco = Convert.ToInt32(droff[3]);
                        int cenaca = Convert.ToInt32(droff[4]);
                        string kol = droff[5].ToString();
                        bool chek = Convert.ToBoolean(droff[6]);

                        sel[a].add(id, kod, name, cenaco, cenaca, kol, chek);
                        a++;
                        }
                    }
                        sel[a].Visible = false;
                        a++;
                }
                conoff.Close();
            if (isk) {

                if (vobshem - kolichestvo > kolichestvo) { bunifuVTrackbar1.MaximumValue = vobshem - kolichestvo; bunifuVTrackbar1.Visible = true; }
                else { bunifuVTrackbar1.Visible = false; }

            }
           

        }



        private void tovar_Load(object sender, EventArgs e)
        {

            pechat.Columns.Add("kod", typeof(string));
            pechat.Columns.Add("name", typeof(string));





            kolichestvo = (Global.y - 96) / 40;
            if (kolichestvo > 25) {
                kolichestvo = 25;
            }


            createcell();



           

        

        }


        public void viewcell()
        {
           

        }



       public void createcell()
        {

            for (int i = 0; i < kolichestvo+1 ; i++) {
                
                sel[i] = new productcell {Visible=false};
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
            panel10.Visible = Global.pra_showprih;
            panel16.Visible = Global.pra_eidittov;
            panel5.Visible = Global.pra_eidittov;
            panel7.Visible = Global.pra_showreviz;
            panel17.Visible = Global.pra_showreviz;



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
            
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (bunifuVTrackbar1.Value == 0) { zagrsel(true); }
            else { bunifuVTrackbar1.Value = 0; }


        }

       

        private void bunifuiOSSwitch1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            pechat.Clear();

            conoff.Close();
            conoff.Open();
            sqloff = "select pr_kod,pr_name from product_pro where pr_mg_id =" + Global.IDmagaz + " AND pr_chek='true' ";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();

            while (droff.Read())
            {
                pechat.Rows.Add(droff[0], droff[1]);

            }
            conoff.Close();



            if (pechat.Rows.Count > 0)
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

                conoff.Close();
                conoff.Open();
                sqloff = "UPDATE product_pro Set pr_chek='false' where pr_mg_id=" + Global.IDmagaz + ";";
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                droff.Read();
                conoff.Close();

                bunifuiOSSwitch1.Value = false;

                if (bunifuVTrackbar1.Value == 0) { zagrsel(true); }
                else { bunifuVTrackbar1.Value = 0; }

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

                    if (opana < pechat.Rows.Count)
                    {

                        img = qr.Write(pechat.Rows[opana][0].ToString());



                        string text = pechat.Rows[opana][1].ToString();

                       

                        Rectangle destRectangle = new Rectangle(x, y, 200, 100);

                        var r = new Rectangle(x-15, y - 55, 230, 50);

                        e.Graphics.DrawString(text, new Font("Arial", 16), Brushes.Black, r);

                        e.Graphics.DrawImage(img, destRectangle, sourceRectangle, GraphicsUnit.Pixel);
                        opana++;
                    }
                }
              
               

            }

            e.HasMorePages = (opana < pechat.Rows.Count);

        }



        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel установлен неправильно!");
                return;
            }



            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + Global.MGname +" "+ DateTime.Today.ToShortDateString() + ".xls";


            if (File.Exists(path))
            {
                try { File.Delete(path); }
                catch
                {
                    MessageBox.Show("Закройте предыдущую версию файла " + Global.MGname);
                    return;
                }

            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            
            xlWorkSheet.Cells[1, 1] = "Штрих-Код"; xlWorkSheet.Columns[1].ColumnWidth = 15;

            xlWorkSheet.Cells[1, 2] = "Наименование"; xlWorkSheet.Columns[2].ColumnWidth = 25;
            xlWorkSheet.Cells[1, 3] = "Цена прихода"; xlWorkSheet.Columns[3].ColumnWidth = 15;
            xlWorkSheet.Cells[1, 4] = "Цена продажи"; xlWorkSheet.Columns[4].ColumnWidth = 15;
            xlWorkSheet.Cells[1, 5] = "Цена оптом"; xlWorkSheet.Columns[5].ColumnWidth = 12;
            xlWorkSheet.Cells[1, 6] = "Модификация"; xlWorkSheet.Columns[6].ColumnWidth = 15;
            xlWorkSheet.Cells[1, 7] = "Количество"; xlWorkSheet.Columns[7].ColumnWidth = 12;
            xlWorkSheet.Cells[1, 8] = "Поставщик"; xlWorkSheet.Columns[7].ColumnWidth = 12;





            conoff.Close();
            conoff.Open();
            sqloff = "SELECT pr_kod,pr_name,pr_price_co,pr_price_ca,pr_optom,rz_name,rz_pies,pr_provid FROM product_pro LEFT JOIN razmer_pro ON pr_kod=rz_pr_kod";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            int i = 2;
            while (droff.Read())
            {
                xlWorkSheet.Cells[i, 1] = droff[0].ToString();
                xlWorkSheet.Cells[i, 2] = droff[1].ToString();
                xlWorkSheet.Cells[i, 3] = droff[2].ToString();
                xlWorkSheet.Cells[i, 4] = droff[3].ToString();
                xlWorkSheet.Cells[i, 6] = droff[5].ToString();
                xlWorkSheet.Cells[i, 5] = droff[4].ToString();
                xlWorkSheet.Cells[i, 7] = droff[6].ToString().Replace(",", ".");

                if (String.IsNullOrWhiteSpace(droff[7].ToString())) {xlWorkSheet.Cells[i, 8] = "Нет";}
                else { xlWorkSheet.Cells[i, 8] = droff[7].ToString(); }
                    


                i++;
            }
            conoff.Close();








            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            MessageBox.Show("Файл "+ Global.MGname + " " + DateTime.Today.ToShortDateString() + ".xls создан на рабочем столе");
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Program.zakup.blackback.Show();
            Program.tov.kot.vibor = false;
            kot.ShowDialog();

        }

       

      

        private void bunifuiOSSwitch1_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void bunifuVTrackbar1_ValueChanged_1(object sender, EventArgs e)
        {
            zagrsel(false);
        }

        private void bunifuiOSSwitch1_Click(object sender, EventArgs e)
        {
            if (bunifuVTrackbar1.Value == 0) { zagrsel(true); }
            else { bunifuVTrackbar1.Value = 0; }
            
        }

        private void bunifuVTrackbar1_Scroll(object sender, ScrollEventArgs e)
        {
     
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

        }
    }
}
