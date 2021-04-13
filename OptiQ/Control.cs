using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OptiQ
{
    static class Control
    {

        static Point old_loc, default_loc;
        static Size old_size, default_size;

        public static void SetIntial(Form form) //this method should fire when app starts
        {
            old_loc = form.Location;
            old_size = form.Size;
            default_loc = form.Location;
            default_size = form.Size;
        }

        public static void DoMaximize(Form form)
        {

            old_loc = new Point(form.Location.X, form.Location.Y);
            old_size = new Size(form.Size.Width, form.Size.Height);
            Maximize(form);



        }


        static void Fullscreen(Form form)
        {
            if (form.WindowState == FormWindowState.Maximized)
                form.WindowState = FormWindowState.Normal;
            else if (form.WindowState == FormWindowState.Normal)
                form.WindowState = FormWindowState.Maximized;
        }

        static void Maximize(Form form)
        {
            int x = SystemInformation.WorkingArea.Width;
            int y = SystemInformation.WorkingArea.Height;
            form.WindowState = FormWindowState.Normal;
            form.Location = new Point(0, 0);
            form.Size = new Size(x, y);
        }

        public static void Minimize(Form form)
        {
            if (form.WindowState == FormWindowState.Minimized)
                form.WindowState = FormWindowState.Normal;
            else if (form.WindowState == FormWindowState.Normal)
                form.WindowState = FormWindowState.Minimized;
        }

        public static void Exit()
        {
            Application.Exit();
        }
    }
}