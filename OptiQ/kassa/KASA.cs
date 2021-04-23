using Npgsql;
using OptiQ.kassa;
using OptiQ.kassa.izmena;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using ZXing;

namespace OptiQ
{
    public partial class KASA : Form
    {
        public KASA()
        {
            InitializeComponent();
            Program.KASA = this;
        }
        InputSimulator Simulator = new InputSimulator();




        public SqlConnection conr = new SqlConnection(Global.conectsql);

        public string sqlr;

        public SqlCommand cmdr;
        public SqlDataReader drr;


        public DataTable dtSales = new DataTable();


     


        
        public bool optom = false;


        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;
        public string offup;
        public string offdell;

        public string method;
        public SqlCommand cmdoff;
        public SqlDataReader droff;
        public string kakprodalchek;


        Oplata opa = new Oplata();

        fasttovar fas = new fasttovar();
        edittovar edt = new edittovar();

        Otlojka otl = new Otlojka();

        add add = new add();

        dolgi dlg = new dolgi();

        kategory kategory = new kategory();


        skidka skidka1 = new skidka();

        drobno drobno1 = new drobno();


        Vozvrat vozvrat = new Vozvrat();

        Vibrazer vibrazer = new Vibrazer();


       // public string generateid = null;


        public int index = -1;


        public int cenabezskidki = 0;


        public string opend_by;

        private string INFO = "";

        private string TOVAR = "";
        private string OVAR = "";
        private string Infoend = "";
        private string itog = "";
        private string itog2 = "";
       
        Image img;
        Point imga = new Point(75, -50);
        private long res;


      public  void focusses() {
            textBox1.Focus();
        }


        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {

            e.Graphics.DrawImage(img, imga);
            var r = new Rectangle(0, 60, 300, 5000000);

            e.Graphics.DrawString(INFO + TOVAR, new Font("Arial", 8), Brushes.Black, r);

            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(INFO + TOVAR, new Font("Arial", 8), 300);
            var r2 = new Rectangle(0, Convert.ToInt32(Convert.ToDouble(stringSize.Height) + 60), 300, 5000000);
            var r3 = new Rectangle(0, Convert.ToInt32(Convert.ToDouble(stringSize.Height) + 80), 300, 5000000);
            var r4 = new Rectangle(190, Convert.ToInt32(Convert.ToDouble(stringSize.Height) + 80), 300, 5000000);
            e.Graphics.DrawString(Infoend, new Font("Arial", 8), Brushes.Black, r2);
            e.Graphics.DrawString(itog, new Font("Arial Black", 10), Brushes.Black, r3);
            e.Graphics.DrawString(itog2, new Font("Arial Black", 10), Brushes.Black, r4);
        }


        private void KASA_Shown(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.Location = new Point(10, 42);
            bunifuCustomDataGrid1.Height = 0;

          textBox1.Focus();
         
            
        }



        public void summa()
        {
           
            long sum = 0;
            long min = 0;
            int tik = 0;
            bunifuFlatButton1.Text = null;
            while (tik <= (grdt_kass.Rows.Count - 1))
            {


                sum += Convert.ToInt64(grdt_kass.Rows[tik].Cells[6].Value);
                bunifuFlatButton1.Text = sum.ToString();
                cenabezskidki =Convert.ToInt32(sum);
                min += Convert.ToInt64(grdt_kass.Rows[tik].Cells[7].Value);
                label3.Text = min.ToString();

                tik++;

            }
            if (bunifuFlatButton16.Text != "")
            {
                long new_sum = sum;
                string skidka_str = bunifuFlatButton16.Text;
                if (skidka_str.Length > 0 && skidka_str[skidka_str.Length - 1] == '%')
                {
                    double skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 1));
                    new_sum =Convert.ToInt64(sum * (1 + skidka / 100));
                }
                else if (skidka_str.Length > 0 && skidka_str[skidka_str.Length - 1] == '.')
                {
                    double skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 4));
                    new_sum = sum + Convert.ToInt64(skidka);
                }
                bunifuFlatButton1.Text = new_sum.ToString();
            }
            bunifuFlatButton2.Text = (grdt_kass.Rows.Count).ToString();


        }

   

        private void grdt_kass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (grdt_kass.Rows.Count > 0)
            {
                index = grdt_kass.CurrentRow.Index;
              
            }
        }

    




        public void oplata() {


            int keeti = 0;

            if ((grdt_kass.Rows.Count - 1) > -1)
            {
                sqloff = null;


                string generateid = Global.IDuser+(DateTimeOffset.Now.ToUnixTimeSeconds()).ToString();




               
              




                offup = null;
                   

                INFO += "М.№" + Global.IDmagaz + "  '" + Global.MGname + "'\n" + "Адрес  " + Global.MGadr + "\n" + "Продажа" + "\n";

                    BarcodeWriter qr = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
                    img = qr.Write(generateid);

                    while (keeti <= grdt_kass.Rows.Count - 1)
                    {


                      
                        string zena = grdt_kass.Rows[keeti].Cells[2].Value.ToString();
                        string pieces = Convert.ToString(grdt_kass.Rows[keeti].Cells[4].Value).Replace(",", ".");

                        string ostatok = Convert.ToString(grdt_kass.Rows[keeti].Cells[8].Value).Replace(",", ".");

                        string skid = (grdt_kass.Rows[keeti].Cells[5].Value).ToString().Replace(",",".");
                        long sum = Convert.ToInt64(grdt_kass.Rows[keeti].Cells[6].Value);
                        long min = Convert.ToInt64(grdt_kass.Rows[keeti].Cells[7].Value);
                        string saloname = Convert.ToString(grdt_kass.Rows[keeti].Cells[1].Value);
                        long kodd = Convert.ToInt64(grdt_kass.Rows[keeti].Cells[0].Value);
                        long rz_id= Convert.ToInt64(grdt_kass.Rows[keeti].Cells[11].Value);
                        string osttok = Convert.ToString(grdt_kass.Rows[keeti].Cells[8].Value).Replace(",", ".");

                    show_ost(Global.pra_showpie, Convert.ToInt32(ostatok), saloname);
                        

                    OVAR = "                               " + pieces + " X " + zena + " X " + skid + "% = " + sum;
                        while (OVAR.Length < 70)
                        {
                            OVAR = "  " + OVAR;

                        }


                        
                    sqloff += "UPDATE razmer_pro SET rz_pies=(SELECT rz_pies FROM razmer_pro where rz_pr_kod="+ kodd + " and rz_id="+ rz_id + "ORDER BY rz_id DESC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY)-" + pieces + " where rz_id=" + rz_id+ " and rz_pr_kod="+ kodd+";";

                    sqloff += "INSERT INTO sales_pro(sl_crt_id,sl_pieces,sl_cena,sl_name,sl_prihod,sl_skidon,sl_kod,sl_rz_id,cbt_skidon,sl_vozvrat)VALUES(" + generateid + ","+ pieces + ","+Convert.ToInt64(grdt_kass.Rows[keeti].Cells[2].Value)+ ",N$" + saloname+"$,"+ Convert.ToInt64(grdt_kass.Rows[keeti].Cells[3].Value) + ",N$"+ skid + "$,"+ kodd + ","+rz_id+",N'"+ bunifuFlatButton16.Text +"',"+pieces+");";

                    TOVAR += "№" + (keeti + 1) + " - " + kodd + "  " + saloname + "\n" + OVAR + "\n";

                    keeti++;


                    }


                sqloff += "INSERT INTO cart(crt_mg_id,id_kassir,crt_sum_fact,crt_date,crt_off_id)VALUES(" + Global.IDmagaz + "," + Global.IDuser + "," + label3.Text + "," + DateTimeOffset.Now.ToUnixTimeSeconds() + "," + generateid + ");";

                conoff.Close();
                conoff.Open();
                sqloff =(sqloff + method.Replace("crtid", generateid)).Replace("$","'");
                sqloff += "insert into productoff(pr_text)VALUES(N'" + sqloff.Replace("'", "$") + "');";

                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                droff.Read();
                conoff.Close();




                

                Infoend = "ТОВАРОВ " + keeti + "\n" + "Способ оплаты " + kakprodalchek+ "Продавец " + Global.USname + "\n" + DateTime.Now + "\n\n\n\n\n\n" + "Спасибо за покупку!";
                itog = "\n\n\n\n" + "ИТОГ";
                itog2 = "\n\n\n\n" + "= " + bunifuFlatButton1.Text;



               PrintDocument printDocument = new PrintDocument();

             


                // обработчик события печати
                printDocument.PrintPage += PrintPageHandler;

                if (opa.prin == true) { printDocument.Print(); }

                 // печатаем







                grdt_kass.Rows.Clear();
               // Program.msg.Message.Text = "Продажа прошла успешно"; Program.log.mess.Show(); Program.msg.Size = new Size(400, 100);


                INFO = "";
                TOVAR = "";
                label3.Text = "";
                bunifuFlatButton1.Text = "0";
                bunifuFlatButton2.Text = "0";
                
               label4.Visible = false;
               bunifuFlatButton16.Text = "0";
                bunifuFlatButton16.Visible = false;

            }
            else { Program.msg.Message.Text = "Корзина пуста"; Program.log.mess.Show(); Program.msg.Size = new Size(300, 100); }


        }



        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }




        public void kassadeletrow()
        {



            if (index > -1)
            {

                grdt_kass.Rows.RemoveAt(index);

                index = grdt_kass.Rows.Count - 1;


                grdt_kass.ClearSelection();
                if (index >= 0)
                {
                    grdt_kass.Rows[index].Selected = true;
                }
                
                summa();

            }


        }

       

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                kassa_pulus(0, textBox1.Text);

            }
        }




        public void kassa_pulus(long rz_id,string kod)
        {

           

            long res;
            bool isInt = Int64.TryParse(kod + "0", out res);


            if (!String.IsNullOrWhiteSpace(kod) && isInt == true)
            {


           


                conoff.Close();
                conoff.Open();
                    sqloff = "select pr_kod,pr_name,pr_price_co,pr_price_ca,pr_optom from product_pro where  pr_kod=" + kod;
                    cmdoff = new SqlCommand(sqloff, conoff);
                    droff = cmdoff.ExecuteReader();

                    if (droff.Read())
                    {

                    select(Convert.ToInt64(droff[0]), droff[1].ToString(),Convert.ToInt32(droff[2]),Convert.ToInt32(droff[3]),Convert.ToInt32(droff[4]), rz_id);
                  

                    }
                    else
                    {
                    if (kod.Length == 13)
                    {
                        pisc_plu(kod.Remove(12).Remove(0, 2));
                    }
                    else {
                        conoff.Close();
                        add.ID = kod;
                        Program.main.backblakshow();
                        add.ShowDialog();
                     
                    }
                   

                }
                    conoff.Close();


                


            }



        }



        public void pisc_plu(string kod) {
            int plu =Convert.ToInt32(kod.Remove(5));
            double ves = Convert.ToDouble(kod.Remove(0,5).Insert(2, ",")) ;
       
            conoff.Close();
            conoff.Open();
            sqloff = "select pr_kod,pr_name,pr_price_co,pr_price_ca from product where pr_plu=" + plu;
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();

            if (droff.Read())
            {

                grdt_kass.Rows.Add(droff[0], droff[1], droff[3], droff[2], 1, 0, Convert.ToDouble(droff[3]), droff[2], Convert.ToDouble(droff[4]) - 1, droff[4],0,0);
                int schet = grdt_kass.Rows.Count-1;
                grdt_kass.Rows[schet].Cells[4].Value = ves;
                grdt_kass.Rows[schet].Cells[6].Value = (Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[2].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[4].Value)) - (((Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[2].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[4].Value)) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[5].Value)) / 100);
                grdt_kass.Rows[schet].Cells[6].Value = Convert.ToInt64(grdt_kass.Rows[schet].Cells[6].Value);
                grdt_kass.Rows[schet].Cells[7].Value = Convert.ToDouble(grdt_kass.Rows[schet].Cells[3].Value) * Convert.ToDouble(grdt_kass.Rows[schet].Cells[4].Value);
                grdt_kass.Rows[schet].Cells[8].Value = Convert.ToDouble(grdt_kass.Rows[schet].Cells[8].Value) - Convert.ToDouble(grdt_kass.Rows[schet].Cells[4].Value);

                index = schet;

                grdt_kass.ClearSelection();

                grdt_kass.Rows[index].Selected = true;
                


                summa();

                textBox1.Text = null;

            }
            else 
            {
                conoff.Close();
                add.ID = textBox1.Text;
                Program.main.backblakshow();
                add.ShowDialog();
               

            }



            }


        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            if (grdt_kass.Rows.Count - 1 > -1)
            {
                opa.label4.Text = (Convert.ToInt32("0" + bunifuFlatButton1.Text)).ToString();
                Program.main.backblakshow();
                opa.ShowDialog();
            }
        }

       

        private void bunifuFlatButton7_Click_1(object sender, EventArgs e)
        {
            if (index > -1 && grdt_kass.Rows.Count > 0)
            {

                grdt_kass.Rows.RemoveAt(index);

                index = grdt_kass.Rows.Count - 1;


                grdt_kass.ClearSelection();
                if (index >= 0)
                {
                    grdt_kass.Rows[index].Selected = true;
                }

                summa();

                if (grdt_kass.Rows.Count == 1) {
                    bunifuFlatButton16.Text = "0";
                
                }

            }
           
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
      
            Program.main.backblakshow();
            fas.ShowDialog();
        }


        public void schet() {

            index = grdt_kass.Rows.Count - 1;

            grdt_kass.ClearSelection();
            if (index > -1)
            {
                grdt_kass.Rows[index].Selected = true;
                
            }
        }



        private void bunifuFlatButton10_MouseDown(object sender, EventArgs e)
        {
            if (index > -1)
            {

                if (Convert.ToInt64(Program.KASA.grdt_kass.Rows[index].Cells[8].Value) < 1 && !Global.sale_in_minus)
                {
                    Program.KASA.textBox1.Text = "";
                    Program.main.backblakshow();
                    Program.msg.Show();
                    Program.msg.Message.Text = "Товар отсутствует на складе";
                    return;
                }


                grdt_kass.Rows[index].Cells[4].Value = Convert.ToDouble(grdt_kass.Rows[index].Cells[4].Value) + 1;

                double cena = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[2].Value);
                double kol = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);
                string skidka_str = Convert.ToString(grdt_kass.Rows[index].Cells[5].Value);

                if(skidka_str == "0")
                    Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = cena * kol;
                else if(skidka_str.Length>0 && skidka_str[skidka_str.Length - 1] == '%')
                {
                    double skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 1));
                    Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = (cena * kol) * (1 + skidka / 100);
                }
                else if (skidka_str.Length > 0 && skidka_str[skidka_str.Length - 1] == '.')
                {
                    double skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 4));
                    Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = (cena + skidka) * kol;
                }
                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = Convert.ToInt64(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value);
                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[7].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[3].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);
                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[8].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[9].Value) - Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);

                summa();
            }
        }

        private void bunifuFlatButton9_MouseDown(object sender, EventArgs e)
        {
            if (index > -1 && Convert.ToInt64(grdt_kass.Rows[index].Cells[4].Value) > 1)
            {
                grdt_kass.Rows[index].Cells[4].Value = Convert.ToDouble(grdt_kass.Rows[index].Cells[4].Value) - 1;

                double cena = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[2].Value);
                double kol = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);
                string skidka_str = Convert.ToString(grdt_kass.Rows[index].Cells[5].Value);

                if (skidka_str == "0")
                    Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = cena * kol;
                else if (skidka_str.Length > 0 && skidka_str[skidka_str.Length - 1] == '%')
                {
                    double skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 1));
                    Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = (cena * kol) * (1 + skidka / 100);
                }
                else if (skidka_str.Length > 0 && skidka_str[skidka_str.Length - 1] == '.')
                {
                    double skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 4));
                    Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = (cena + skidka) * kol;
                }
                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value = Convert.ToInt64(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[6].Value);
                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[7].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[3].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);
                Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[8].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[9].Value) - Convert.ToDouble(Program.KASA.grdt_kass.Rows[Program.KASA.index].Cells[4].Value);

                summa();
            }
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            if (index > -1)
            {
                Program.main.backblakshow();
                edt.ShowDialog();
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            if (grdt_kass.Rows.Count >0) {
                rezervaciz();
            }

            pohav.Rows.Clear();

            index = -1;
            Program.main.backblakshow();
            bunifuFlatButton1.Text = null;
            bunifuFlatButton2.Text = null;
            otl.ShowDialog();
            
        }

        private void KASA_Load(object sender, EventArgs e)
        {
            dtSales.Columns.Add("rz_id", typeof(string));
            dtSales.Columns.Add("Модификация", typeof(string));
            dtSales.Columns.Add("Остаток", typeof(string));
            bunifuFlatButton8.Visible = Global.pra_editpri;
            piec.Visible = Global.pra_showpie;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {


            Program.main.backblakshow();
            kategory.ShowDialog();




        }

        

        public void salesssssssssssssss()
        {

            Program.main.hide_form();
            Program.main.output.Controls.Add(Program.main.sslllaasslo);
            Program.main.sslllaasslo.Show();
            Program.main.sslllaasslo.Sales_Shown();
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.Height = 0;

            bool isInt = Int64.TryParse(textBox1.Text + "0", out res);

           

                if (textBox1.Text.Length > 1 && isInt != true)
            {
                bunifuCustomDataGrid1.Rows.Clear();
                conoff.Close();
                conoff.Open();
                    sqloff = " SELECT pr_kod,pr_name FROM product_pro WHERE (LOWER(pr_name) LIKE LOWER(N'%" + textBox1.Text + "%'))";
                    cmdoff = new SqlCommand(sqloff, conoff);
                    droff = cmdoff.ExecuteReader();
                    while (droff.Read())
                    {
                    bunifuCustomDataGrid1.Rows.Add(Convert.ToInt64(droff[0]), droff[1]);

                    }
                    conoff.Close();

                bunifuCustomDataGrid1.Height = (bunifuCustomDataGrid1.Rows.Count) * 28;
                bunifuCustomDataGrid1.Width = 510;
                bunifuCustomDataGrid1.Location = new Point(10,42);
                bunifuCustomDataGrid1.ClearSelection();

            }
            
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = 0;

            if (bunifuCustomDataGrid1.Rows.Count > 0)
            {





                idx = bunifuCustomDataGrid1.CurrentRow.Index;

                textBox1.Text = (bunifuCustomDataGrid1.Rows[idx].Cells[0].Value).ToString();


                Simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);







            }
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            Program.main.backblakshow();
            dlg.ShowDialog();
        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            if (index > -1)
            {
                opend_by = "skidka";
                Program.main.backblakshow();
                skidka1.ShowDialog();
            }
        }

        private void bunifuFlatButton15_Click(object sender, EventArgs e)
        {
            if (index > -1)
            {
                Program.main.backblakshow();
                drobno1.ShowDialog();
            }
        }

        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
            if (index > -1)
            {
                opend_by = "nacenka";
                Program.main.backblakshow();
                skidka1.ShowDialog();
            }
        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            vozvrat.grdt_kass.Rows.Clear();
            Program.main.backblakshow();
            vozvrat.ShowDialog();
        }

        private void bunifuFlatButton17_MouseClick(object sender, MouseEventArgs e)
        {
          
        }


        public void opt_fun() {

            int schet = 0;

            

            while (schet < grdt_kass.Rows.Count) 
            {

               


                double cena = Convert.ToDouble(grdt_kass.Rows[schet].Cells[2].Value);
                double kol = Convert.ToDouble(grdt_kass.Rows[schet].Cells[4].Value);
                double skidka;
                string skidka_str = Convert.ToString(grdt_kass.Rows[schet].Cells[10].Value);
                if (optom == true)
                {
                    if (skidka_str.Length > 4) {
                        skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 4));
                        grdt_kass.Rows[schet].Cells[6].Value = (cena + skidka) * kol;
                        grdt_kass.Rows[schet].Cells[5].Value = skidka_str;

                    }
                    
                    
                }
                else {

                    grdt_kass.Rows[schet].Cells[6].Value = cena * kol;
                    grdt_kass.Rows[schet].Cells[5].Value = 0;
                }
                
                grdt_kass.Rows[schet].Cells[6].Value = Convert.ToInt64(grdt_kass.Rows[schet].Cells[6].Value);
                grdt_kass.Rows[schet].Cells[7].Value = Convert.ToDouble(grdt_kass.Rows[schet].Cells[3].Value) * Convert.ToDouble(grdt_kass.Rows[schet].Cells[4].Value);
                grdt_kass.Rows[schet].Cells[8].Value = Convert.ToDouble(grdt_kass.Rows[schet].Cells[9].Value) - Convert.ToDouble(grdt_kass.Rows[schet].Cells[4].Value);





                schet++;








            }

            summa();



        }

        private void bunifuFlatButton17_Click(object sender, EventArgs e)
        {
            if (bunifuFlatButton17.Text == "Оптом")
            {
                bunifuFlatButton17.Text = "Розница";
                optom = true;

            }
            else
            {

                bunifuFlatButton17.Text = "Оптом";
                optom = false;

            }
            opt_fun();
        }

        private void show_ost(bool need, int ost, string name_ost)
        {
            if (need)
            {
                if (ost <= Global.uvedomlenie_ostatoc)
                {
                    Program.main.backblakshow();
                    Program.msg.Show();
                    Program.msg.Message.Text = name_ost + " осталось " + ost;
                }
                
            }
            else
            {
                if (ost <= Global.uvedomlenie_ostatoc)
                {
                    Program.main.backblakshow();
                    Program.msg.Show();
                    Program.msg.Message.Text = "Количество " + name_ost + " ограничено";
                }
                
            }
        }


        public void select(long pr_kod, string pr_name, int pr_price_co, int pr_price_ca, int pr_optom,long otl)
        {
            string otl_fun = null;

            if (otl!=0) {

                otl_fun = "rz_id=" + otl + " and";
               
            }

            

            dtSales.Rows.Clear();

            conr.Close();
            conr.Open();
            sqlr = "select rz_id,rz_name,rz_pies from razmer_pro where "+ otl_fun + " rz_pr_kod=" + pr_kod;
            cmdr = new SqlCommand(sqlr, conr);
            drr = cmdr.ExecuteReader();
            while (drr.Read())
            {

                dtSales.Rows.Add(drr[0], drr[1], drr[2]);

                
            }
            conr.Close();


            if (dtSales.Rows.Count < 1 && !Global.sale_in_minus)
            {
                Program.KASA.textBox1.Text = "";
                Program.main.backblakshow();
                Program.msg.Show();
                Program.msg.Message.Text = "Товар отсутствует на складе";
                return;
            }



            if (dtSales.Rows.Count == 1)
            {
               
                double pies = Convert.ToDouble(dtSales.Rows[0][2].ToString().Replace(".", ","));
                string rz_name = dtSales.Rows[0][1].ToString();
                long rz_id = Convert.ToInt64(dtSales.Rows[0][0]);
                adda(pr_kod, pr_name, pr_price_co, pr_price_ca, pr_optom, pies, "", rz_id);
            }
            else
            {
                vibrazer.uznat(pr_kod, pr_name, pr_price_co, pr_price_ca, pr_optom);
                Program.main.backblakshow();
                vibrazer.ShowDialog();
                

            }

        }




        public void adda(long kod, string name, int price_co, int price_ca, int optom, double pies, string rz_name, long rz_id)
        {
                      

            bool zap = true;
            int schet = 0;

            string new_neme_tov = rz_name + name;


            if (pies <= 0 && !Global.sale_in_minus)
            {
                Program.KASA.textBox1.Text = "";
                Program.main.backblakshow();
                Program.msg.Show();
                Program.msg.Message.Text = "Товар отсутствует на складе";
                return;
            }



            while (schet < Program.KASA.grdt_kass.Rows.Count && zap == true)
            {
                if (Convert.ToInt64(Program.KASA.grdt_kass.Rows[schet].Cells[0].Value) == kod && Convert.ToInt64(Program.KASA.grdt_kass.Rows[schet].Cells[11].Value) == rz_id)
                {

                    if (Convert.ToInt64(Program.KASA.grdt_kass.Rows[schet].Cells[8].Value) <1 && !Global.sale_in_minus)
                    {
                        Program.KASA.textBox1.Text = "";
                        Program.main.backblakshow();
                        Program.msg.Show();
                        Program.msg.Message.Text = "Товар отсутствует на складе";
                        return;
                    }


                   
                    Program.KASA.grdt_kass.Rows[schet].Cells[4].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[4].Value) + 1;

                    double cena = Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[2].Value);
                    double kol = Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[4].Value);
                    string skidka_str = Convert.ToString(Program.KASA.grdt_kass.Rows[schet].Cells[5].Value);

                    if (skidka_str == "0")
                        Program.KASA.grdt_kass.Rows[schet].Cells[6].Value = cena * kol;
                    else if (skidka_str.Length > 0 && skidka_str[skidka_str.Length - 1] == '%')
                    {
                        double skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 1));
                        Program.KASA.grdt_kass.Rows[schet].Cells[6].Value = (cena * kol) * (1 + skidka / 100);
                    }
                    else if (skidka_str.Length > 0 && skidka_str[skidka_str.Length - 1] == '.')
                    {
                        double skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 4));
                        Program.KASA.grdt_kass.Rows[schet].Cells[6].Value = (cena + skidka) * kol;
                    }
                    Program.KASA.grdt_kass.Rows[schet].Cells[6].Value = Convert.ToInt64(Program.KASA.grdt_kass.Rows[schet].Cells[6].Value);
                    Program.KASA.grdt_kass.Rows[schet].Cells[7].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[3].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[4].Value);
                    Program.KASA.grdt_kass.Rows[schet].Cells[8].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[9].Value) - Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[4].Value);


                    zap = false;



                }
                schet++;
            }
            if (zap == true)
            {
              
                string opt = "-" + (Math.Abs(price_ca - optom)) + " тг.";
                grdt_kass.Rows.Add(kod, new_neme_tov, price_ca, price_co, 1, 0, price_ca, price_co, pies - 1, pies, opt, rz_id);
            }


            index = grdt_kass.Rows.Count - 1;

            grdt_kass.ClearSelection();

            grdt_kass.Rows[index].Selected = true;



        summa();

            textBox1.Text = null;


        }






        public void rezervaciz()
        {
            int nacht = 0;

            string create_id = Global.IDuser + (DateTimeOffset.Now.ToUnixTimeSeconds()).ToString();

            string zapros = null;
            

            while (nacht < grdt_kass.Rows.Count)
            {
                long kod =Convert.ToInt64( grdt_kass.Rows[nacht].Cells[0].Value);
                long rz = Convert.ToInt64(grdt_kass.Rows[nacht].Cells[11].Value);
                string pies = grdt_kass.Rows[nacht].Cells[4].Value.ToString().Replace(",",".");
                string name= grdt_kass.Rows[nacht].Cells[1].Value.ToString();

                zapros += "INSERT INTO tov_otlojka_pro(tov_ot_id, tov_kod, tov_rz, tov_pies, tov_name)VALUES("+ create_id + ","+kod+","+rz+","+ pies + ",N'"+ name + "');";
                zapros += "UPDATE razmer_pro SET rz_pies=((SELECT rz_pies FROM razmer_pro where rz_pr_kod=" + kod + " and rz_id=" + rz + "ORDER BY rz_id DESC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY)-" + pies + ") where rz_id=" + rz + " and rz_pr_kod=" + kod + ";";
                nacht++;
            }
            
            string cretezapr = "INSERT INTO otlojka_pro(ot_id,id_kassir)VALUES(" + create_id + "," +Global.IDuser+ ");";
            string zaprostext = cretezapr + zapros + "INSERT INTO productoff(pr_text)VALUES(N'" + Global.versia + cretezapr.Replace("'", "$") + zapros.Replace("'", "$") + "');";
            conoff.Close();
            conoff.Open();
            sqloff =zaprostext ;
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            droff.Read();
            conoff.Close();

            grdt_kass.Rows.Clear();

        }



        public void poihali() {

            grdt_kass.Rows.Clear();
            int nacht=0;

            while (nacht < pohav.Rows.Count)
            {
                long kod = Convert.ToInt64(pohav.Rows[nacht].Cells[0].Value);
                long rz = Convert.ToInt64(pohav.Rows[nacht].Cells[1].Value);
                string pies = pohav.Rows[nacht].Cells[2].Value.ToString().Replace(",", ".");


            
                Program.KASA.kassa_pulus(rz, kod.ToString());

                int ind = Program.KASA.grdt_kass.Rows.Count - 1;

                Program.KASA.grdt_kass.Rows[ind].Cells[4].Value = Convert.ToDouble(pies.Replace(".", ","));
                Program.KASA.grdt_kass.Rows[ind].Cells[6].Value = (Convert.ToDouble(Program.KASA.grdt_kass.Rows[ind].Cells[2].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[ind].Cells[4].Value)) - (((Convert.ToDouble(Program.KASA.grdt_kass.Rows[ind].Cells[2].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[ind].Cells[4].Value)) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[ind].Cells[5].Value)) / 100);
                Program.KASA.grdt_kass.Rows[ind].Cells[6].Value = Convert.ToInt64(Program.KASA.grdt_kass.Rows[ind].Cells[6].Value);
                Program.KASA.grdt_kass.Rows[ind].Cells[7].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[ind].Cells[3].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[ind].Cells[4].Value);
                Program.KASA.grdt_kass.Rows[ind].Cells[8].Value = Convert.ToDouble(Program.KASA.grdt_kass.Rows[ind].Cells[9].Value) - Convert.ToDouble(Program.KASA.grdt_kass.Rows[ind].Cells[4].Value);

                nacht++;

            }
            pohav.Rows.Clear();
            Program.KASA.summa();
        }

        private void vozvtov_Click(object sender, EventArgs e)
        {
            if (grdt_kass.Rows.Count > 0)
            {
                int tik = 0;

                vozvrat.grdt_kass.Rows.Clear();

                while (grdt_kass.Rows.Count > tik)
                {

                    long kod = Convert.ToInt64(grdt_kass.Rows[tik].Cells[0].Value) ;
                    string name = Convert.ToString(grdt_kass.Rows[tik].Cells[1].Value);
                    int cena= Convert.ToInt32(grdt_kass.Rows[tik].Cells[2].Value);
                    int priha= Convert.ToInt32(grdt_kass.Rows[tik].Cells[3].Value);
                    double pies= Convert.ToDouble(grdt_kass.Rows[tik].Cells[4].Value.ToString().Replace(".",","));
                    string razcen =Convert.ToString(grdt_kass.Rows[tik].Cells[5].Value);
                    int suma= Convert.ToInt32(grdt_kass.Rows[tik].Cells[6].Value);
                    int sumprih= Convert.ToInt32(grdt_kass.Rows[tik].Cells[7].Value);
                    long idRz= Convert.ToInt64(grdt_kass.Rows[tik].Cells[11].Value);



                    vozvrat.grdt_kass.Rows.Add(false, kod, name, cena, priha, pies, razcen, suma, sumprih, idRz); ;




                    tik++;
                }
                vozvrat.bunifuFlatButton16.Text = bunifuFlatButton16.Text;
                Program.main.backblakshow();
                vozvrat.ShowDialog();
            }
        }
    }
}
