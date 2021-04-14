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


        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);

       // int stop = 0;
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;


        // fastovar fastovar = new fastovar();

        //InputSimulator Simulator = new InputSimulator();
        public bool optom = false;


        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;
        public string offup;
        public string offup2;
        public string offdell;
        public string offcard;
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


        public string generateid = null;


        public int index = -1;
        public int n;


        public string seleoffproduct;
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


              
                generateid = Global.IDuser+(DateTimeOffset.Now.ToUnixTimeSeconds()).ToString();

                    offcard = null;


                    offcard = "INSERT INTO cart(crt_mg_id,id_kassir,crt_sum_fact,crt_date,crt_off_id)VALUES(" + Global.IDmagaz + "," + Global.IDuser + ","+label3.Text+","+ DateTimeOffset.Now.ToUnixTimeSeconds() + ","+ generateid + ") Returning crt_id";



                seleoffproduct = null;


                    offup = null;
                     offup2 = null;

                INFO += "М.№" + Global.IDmagaz + "  '" + Global.MGname + "'\n" + "Адрес  " + Global.MGadr + "\n" + "Продажа" + "\n";

                    BarcodeWriter qr = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
                    img = qr.Write(generateid);

                    while (keeti <= grdt_kass.Rows.Count - 1)
                    {


                        // grdt_kass.Rows[keeti].Cells[3].Value;
                       // string prov = grdt_kass.Rows[keeti].Cells[6].Value.ToString();
                        string zena = grdt_kass.Rows[keeti].Cells[2].Value.ToString();
                        string pieces = Convert.ToString(grdt_kass.Rows[keeti].Cells[4].Value).Replace(",", ".");

                    string ostatok = Convert.ToString(grdt_kass.Rows[keeti].Cells[8].Value).Replace(",", ".");

                    string skid = (grdt_kass.Rows[keeti].Cells[5].Value).ToString().Replace(",",".");
                    long sum = Convert.ToInt64(grdt_kass.Rows[keeti].Cells[6].Value);
                        long min = Convert.ToInt64(grdt_kass.Rows[keeti].Cells[7].Value);
                        string saloname = Convert.ToString(grdt_kass.Rows[keeti].Cells[1].Value);
                        long kodd = Convert.ToInt64(grdt_kass.Rows[keeti].Cells[0].Value);

                        OVAR = "                               " + pieces + " X " + zena + " X " + skid + "% = " + sum;
                        while (OVAR.Length < 70)
                        {
                            OVAR = "  " + OVAR;

                        }


                    conoff.Close();
                    conoff.Open();
                    sqloff = "UPDATE product SET pr_piec="+ ostatok + " where pr_kod="+ kodd ;
                    cmdoff = new SqlCommand(sqloff, conoff);
                    droff = cmdoff.ExecuteReader();
                    droff.Read();
                    conoff.Close();






                    TOVAR +="№"+ (keeti+1) +" - "+ kodd + "  " + saloname + "\n" + OVAR + "\n";


                        offup += "UPDATE product SET pr_piec = ((select pr_piec from product WHERE pr_kod = " + kodd + " and pr_mg_id =" + Global.IDmagaz + " limit 1)-" + pieces + " ) WHERE pr_kod = " + kodd + " and pr_mg_id =" + Global.IDmagaz + ";";
                        offup2 += "INSERT INTO sales(sl_crt_id,sl_pieces,sl_cena,sl_name,sl_prihod,sl_skidon,sl_kod)VALUES(" + generateid + ","+ pieces + ","+Convert.ToInt64(grdt_kass.Rows[keeti].Cells[2].Value)+ ",N$" + saloname+"$,"+ Convert.ToInt64(grdt_kass.Rows[keeti].Cells[3].Value) + ",N$"+ skid + "$,"+ kodd + ");";
                seleoffproduct+= "INSERT INTO vozvrat(sl_crt_id,sl_pieces,sl_cena,sl_name,sl_prihod,sl_skidon,sl_kod,cbt_skidon)VALUES(" + generateid + ","+ pieces + ","+ Convert.ToInt64(grdt_kass.Rows[keeti].Cells[2].Value)+",N$" + saloname + "$," + Convert.ToInt64(grdt_kass.Rows[keeti].Cells[3].Value) + ",N$" + skid + "$," + kodd + ",N$"+bunifuFlatButton16.Text+"$);";
                     ;

                    keeti++;


                    }
                conoff.Close();
                conoff.Open();
                    sqloff = "INSERT INTO saleoff(saleoofudin,saledate,salecart)VALUES(N'" + offup+ offup2 + "',N'" + offcard + "',N'"+ method.Replace("crtid", generateid) + "')";
                    cmdoff = new SqlCommand(sqloff, conoff);
                    droff = cmdoff.ExecuteReader();
                    droff.Read();
                    conoff.Close();


                conoff.Close();
                conoff.Open();
                sqloff = "INSERT INTO crt(crt,date) VALUES(" + generateid+","+ DateTimeOffset.Now.ToUnixTimeSeconds() + ")";
                cmdoff = new SqlCommand(sqloff, conoff);
                droff = cmdoff.ExecuteReader();
                droff.Read();
                conoff.Close();


                conoff.Close();
                conoff.Open();
                sqloff = ((seleoffproduct+ method+ offup2).Replace("$","'")).Replace("crtid", generateid);
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

                n = grdt_kass.Rows.Count - 1;


                grdt_kass.ClearSelection();
                if (n >= 0)
                {
                    grdt_kass.Rows[n].Selected = true;
                }
                index = n;
                summa();

            }


        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dsvdvs");
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                kassa_pulus();

            }
        }




        public void kassa_pulus()
        {

            bool zap = true;
            int schet = 0;

            long res;
            bool isInt = Int64.TryParse(textBox1.Text + "0", out res);


            if (!String.IsNullOrWhiteSpace(textBox1.Text) && isInt == true)
            {





                conoff.Close();
                conoff.Open();
                    sqloff = "select pr_kod,pr_name,pr_fact_co,pr_price_ca,pr_piec,pr_optom from product where  pr_kod=" + textBox1.Text;
                    cmdoff = new SqlCommand(sqloff, conoff);
                    droff = cmdoff.ExecuteReader();

                    if (droff.Read())
                    {
                        while (schet <= (grdt_kass.Rows.Count - 1) && zap == true)
                        {
                            if (Convert.ToInt64(grdt_kass.Rows[schet].Cells[0].Value) == Convert.ToInt64(droff[0]))
                            {


                            grdt_kass.Rows[schet].Cells[4].Value = Convert.ToDouble(grdt_kass.Rows[schet].Cells[4].Value) + 1;

                            double cena = Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[2].Value);
                            double kol = Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[4].Value);
                            string skidka_str = Convert.ToString(grdt_kass.Rows[schet].Cells[5].Value);

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
                        if (zap == true) {
                        string opt = Convert.ToInt32("-"+ droff[3]) - Convert.ToInt32(droff[5])+ " тг.";
                        grdt_kass.Rows.Add(droff[0], droff[1], droff[3], droff[2],1,0,Convert.ToDouble(droff[3]), droff[2],Convert.ToDouble(droff[4])-1, Convert.ToDouble(droff[4]), opt); }



                        n = grdt_kass.Rows.Count - 1;

                        grdt_kass.ClearSelection();

                        grdt_kass.Rows[n].Selected = true;
                        index = n;


                        summa();

                        textBox1.Text = null;
                    }
                    else
                    {
                    if (textBox1.Text.Length == 13)
                    {
                        pisc_plu(textBox1.Text.Remove(12).Remove(0, 2));
                    }
                    else {
                        conoff.Close();
                        add.ID = textBox1.Text;
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
            sqloff = "select pr_kod,pr_name,pr_fact_co,pr_price_ca,pr_piec from product where pr_plu=" + plu;
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();

            if (droff.Read())
            {

                grdt_kass.Rows.Add(droff[0], droff[1], droff[3], droff[2], 1, 0, Convert.ToDouble(droff[3]), droff[2], Convert.ToDouble(droff[4]) - 1, droff[4]);
                int schet = grdt_kass.Rows.Count-1;
                grdt_kass.Rows[schet].Cells[4].Value = ves;
                grdt_kass.Rows[schet].Cells[6].Value = (Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[2].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[4].Value)) - (((Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[2].Value) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[4].Value)) * Convert.ToDouble(Program.KASA.grdt_kass.Rows[schet].Cells[5].Value)) / 100);
                grdt_kass.Rows[schet].Cells[6].Value = Convert.ToInt64(grdt_kass.Rows[schet].Cells[6].Value);
                grdt_kass.Rows[schet].Cells[7].Value = Convert.ToDouble(grdt_kass.Rows[schet].Cells[3].Value) * Convert.ToDouble(grdt_kass.Rows[schet].Cells[4].Value);
                grdt_kass.Rows[schet].Cells[8].Value = Convert.ToDouble(grdt_kass.Rows[schet].Cells[8].Value) - Convert.ToDouble(grdt_kass.Rows[schet].Cells[4].Value);

                n = schet;

                grdt_kass.ClearSelection();

                grdt_kass.Rows[n].Selected = true;
                index = n;


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
            if (index > -1&& grdt_kass.Rows.Count>0)
            {

                grdt_kass.Rows.RemoveAt(index);

                n = grdt_kass.Rows.Count - 1;
              

                grdt_kass.ClearSelection();
                if (n >= 0)
                {
                    grdt_kass.Rows[n].Selected = true;
                }
                index = n;
                summa();

            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
      
            Program.main.backblakshow();
            fas.ShowDialog();
        }


        public void schet() {

            n = grdt_kass.Rows.Count - 1;

            grdt_kass.ClearSelection();
            if (n > -1)
            {
                grdt_kass.Rows[n].Selected = true;
                index = n;
            }
        }



        private void bunifuFlatButton10_MouseDown(object sender, EventArgs e)
        {
            if (index > -1)
            {
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
            index = -1;
            Program.main.backblakshow();
            bunifuFlatButton1.Text = null;
            bunifuFlatButton2.Text = null;
            otl.ShowDialog();
            
        }

        private void KASA_Load(object sender, EventArgs e)
        {
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

           

                if (textBox1.Text.Length > 2 && isInt != true)
            {
                bunifuCustomDataGrid1.Rows.Clear();
                conoff.Close();
                conoff.Open();
                    sqloff = " SELECT pr_kod,pr_name FROM product WHERE (LOWER(pr_name) LIKE LOWER(N'%" + textBox1.Text + "%'))";
                    cmdoff = new SqlCommand(sqloff, conoff);
                    droff = cmdoff.ExecuteReader();
                    while (droff.Read())
                    {
                    bunifuCustomDataGrid1.Rows.Add(Convert.ToInt64(droff[0]), droff[1]);

                    }
                    conoff.Close();

                bunifuCustomDataGrid1.Height = (bunifuCustomDataGrid1.Rows.Count) * 30;
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

                    
                    skidka = Convert.ToDouble(skidka_str.Substring(0, skidka_str.Length - 4));
                    grdt_kass.Rows[schet].Cells[6].Value = (cena - skidka) * kol;
                    grdt_kass.Rows[schet].Cells[5].Value = skidka_str;
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
    }
}
