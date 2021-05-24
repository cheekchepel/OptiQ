using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Drawing.Text;

using System.Diagnostics;
using System.IO;
using WindowsInput;
using System.Data.SqlClient;
using ZXing;
//

//using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

using Color = System.Drawing.Color;

using OptiQ.kassa;
using System.Runtime.InteropServices;
using OptiQ.magaz;
using OptiQ.LOGIN;

namespace OptiQ
{
    public partial class main : Form

    {

        Poderjka Poderjka = new Poderjka();


        KASA newkass = new KASA() { Dock = DockStyle.Fill, TopLevel = false };

        login log = new login() { Dock = DockStyle.Fill, TopLevel = false };


        Vesa vesa =new Vesa() { Dock = DockStyle.Fill, TopLevel = false };

        blackback bb = new blackback();

        tovar prd = new tovar() { Dock = DockStyle.Fill, TopLevel = false };

        adminka admin =new adminka() { Dock = DockStyle.Fill, TopLevel = false };

        logadm logadm = new logadm();

        public Sales sslllaasslo = new Sales() { Dock = DockStyle.Fill, TopLevel = false };

        public double vremya = 0;

        public NpgsqlConnection con = new NpgsqlConnection(Global.conectpost);


        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;
       


        public SqlConnection conoff = new SqlConnection(Global.conectsql);

        public string sqloff;
        public SqlCommand cmdoff;
        public SqlDataReader droff;



       public string opa  ="'";
    

        public main()
        {

            InitializeComponent();
            Program.main = this;

        }






        public void backblakshow() {

            bb.Show();
        
        }
        public void backblakhide()
        {

            bb.Hide();

        }



        private void Form1_Load(object sender, EventArgs e)
        {

           Potoki.startot();





              Global.x = SystemInformation.WorkingArea.Width;
            Global.y = SystemInformation.WorkingArea.Height;
            output.Controls.Add(log);

          
         
            log.Show();
         

        }

        private void close_Click(object sender, EventArgs e)
        {
            Potoki.zakroi  = false;
           
            Application.Exit();

        }

      

        private void turn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
     



     

   







        public void KASSA_view() {

            hide_form();

            output.Controls.Add(newkass);
            newkass.Show();


            
        }
   

     




      

     

        private void exit_but_Click(object sender, EventArgs e)
        {
            Potoki.zakroi = false;
            Application.Restart();
        }

        



       

     

        private void main_KeyPress(object sender, KeyPressEventArgs e)
        {
                   
            char number = e.KeyChar;


            if ( number == '$' || number == '%' ||  number == ',' ||  number == Convert.ToChar(opa)) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

     
   

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
           
           
        }

        private void Opensesess_Click(object sender, EventArgs e)
        {
           
        }

        private void prodect_but_Click(object sender, EventArgs e)
        {
            hide_form();
            output.Controls.Add(prd);
            
            prd.Show();
            prd.zagrsel(true);
        }



        public void hide_form()
        {

          //  output.Controls.Clear();
            log.Hide();
           prd.Hide();
            sslllaasslo.Hide();
            newkass.Hide();
            vesa.Hide();
            admin.Hide();
          
        }

        private void kassa_but_Click(object sender, EventArgs e)
        {
            KASSA_view();
          Program.KASA.textBox1.Focus(); 
            Program.tov.rev.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Program.KASA.salesssssssssssssss();
        }





        public void sobbez(int choon) {




            conoff.Close();
            conoff.Open();

            sqloff = " INSERT INTO productoff(pr_text)VALUES(N'INSERT INTO sobbez(sb_ksas_id,sb_date,sb_con)VALUES(" + Global.IDuser + "," + DateTimeOffset.Now.ToUnixTimeSeconds() + "," + choon + ")')";
            cmdoff = new SqlCommand(sqloff, conoff);
            droff = cmdoff.ExecuteReader();
            droff.Read();
            conoff.Close();



        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.IDuser > 0)
            {
                if (vremya >= Global.ojidanie)
                {


                    try
                    {
                        con.Close();
                        con.Open();

                        sql = "INSERT INTO sobbez(sb_ksas_id,sb_date,sb_con)VALUES(" + Global.IDuser + "," + DateTimeOffset.Now.ToUnixTimeSeconds() + "," + 3 + ")";
                        cmd = new NpgsqlCommand(sql, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        con.Close();

                    }
                    catch { sobbez(3); }


                }
                else {


                    try
                    {
                        con.Close();
                        con.Open();

                        sql = "INSERT INTO sobbez(sb_ksas_id,sb_date,sb_con)VALUES(" + Global.IDuser + "," + DateTimeOffset.Now.ToUnixTimeSeconds() + "," + 2 + ")";
                        cmd = new NpgsqlCommand(sql, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        con.Close();
                    }
                    catch { sobbez(2); }



                }


             
               


           

                

            }
          
            
            
        }

        private void bunifuFlatButton1_Click_2(object sender, EventArgs e)
        {
            output.Controls.Add(vesa);
            hide_form();

            vesa.Show();
            Program.vesika.zagrsel();
            Program.vesika.viewcell();
            Program.vesika.vsetovari();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Program.main.backblakshow();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string a = "";

            //if (InputTimer.GetInputIdleTime() >= Global.ojidanie) {


            //    vremya = InputTimer.GetInputIdleTime();
            //    Potoki.zakroi = false;
            //    Application.Exit();


            //}
            
            if (Potoki.sinserv == 1) {
                a += " сервер";
            }
            if (Potoki.sinprodaj == 1) {
                a += " продаж";
            }
            if (Potoki.sintovar == 1)
            {
                a += " товаров";
            }
            if (a == "" && label1.Text != "")
            {
                label1.Text = a;
            }
            else if (a == "" && label1.Text == "") { }
            else { label1.Text = "Cинхронизация"+ a; }
            




        }



        //public static class InputTimer
        //{
        //    public static double GetInputIdleTime()
        //    {
        //        var plii = new NativeMethods.LastInputInfo();
        //        plii.cbSize = (UInt32)Marshal.SizeOf(plii);

        //        if (NativeMethods.GetLastInputInfo(ref plii))
        //        {
        //            return Math.Floor(Convert.ToDouble(Environment.TickCount - plii.dwTime) / 60000);
        //        }
        //        else
        //        {
        //            throw new Win32Exception(Marshal.GetLastWin32Error());
        //        }
        //    }



        //    private static class NativeMethods
        //    {
        //        public struct LastInputInfo
        //        {
        //            public UInt32 cbSize;
        //            public UInt32 dwTime;
        //        }

        //        [DllImport("user32.dll")]
        //        public static extern bool GetLastInputInfo(ref LastInputInfo plii);
        //    }
        //}

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (logadministartoe.Text == "Войти")
            {

                Program.zakup.blackback.Show();
                logadm.ShowDialog();

            }
            else {

                hide_form();
                output.Controls.Add(log);
                log.Show();
                logadministartoe.Text = "Войти";
                glavnaya.Visible = false;
            }
            

        }


        public void mag_show()
        {

            output.Controls.Add(admin);

            hide_form();

            admin.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Program.zakup.blackback.Show();
            Poderjka.ShowDialog();
        }
    }

} 

