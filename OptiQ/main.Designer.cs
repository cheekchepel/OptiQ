﻿
namespace OptiQ
{
    partial class main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.header = new System.Windows.Forms.Panel();
            this.vesovoi = new Bunifu.Framework.UI.BunifuFlatButton();
            this.kassa_but = new Bunifu.Framework.UI.BunifuFlatButton();
            this.smenna = new Bunifu.Framework.UI.BunifuFlatButton();
            this.prodect_but = new Bunifu.Framework.UI.BunifuFlatButton();
            this.turn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.close = new Bunifu.Framework.UI.BunifuFlatButton();
            this.output = new System.Windows.Forms.Panel();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.header.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.header.Controls.Add(this.bunifuFlatButton1);
            this.header.Controls.Add(this.vesovoi);
            this.header.Controls.Add(this.kassa_but);
            this.header.Controls.Add(this.smenna);
            this.header.Controls.Add(this.prodect_but);
            this.header.Controls.Add(this.turn);
            this.header.Controls.Add(this.close);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Margin = new System.Windows.Forms.Padding(0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1024, 40);
            this.header.TabIndex = 1;
            // 
            // vesovoi
            // 
            this.vesovoi.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.vesovoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.vesovoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vesovoi.BorderRadius = 7;
            this.vesovoi.ButtonText = "Весы";
            this.vesovoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vesovoi.DisabledColor = System.Drawing.Color.Gray;
            this.vesovoi.Dock = System.Windows.Forms.DockStyle.Right;
            this.vesovoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.vesovoi.Iconcolor = System.Drawing.Color.Transparent;
            this.vesovoi.Iconimage = null;
            this.vesovoi.Iconimage_right = null;
            this.vesovoi.Iconimage_right_Selected = null;
            this.vesovoi.Iconimage_Selected = null;
            this.vesovoi.IconMarginLeft = 0;
            this.vesovoi.IconMarginRight = 0;
            this.vesovoi.IconRightVisible = true;
            this.vesovoi.IconRightZoom = 0D;
            this.vesovoi.IconVisible = true;
            this.vesovoi.IconZoom = 100D;
            this.vesovoi.IsTab = false;
            this.vesovoi.Location = new System.Drawing.Point(344, 0);
            this.vesovoi.Margin = new System.Windows.Forms.Padding(0);
            this.vesovoi.Name = "vesovoi";
            this.vesovoi.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.vesovoi.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.vesovoi.OnHoverTextColor = System.Drawing.Color.White;
            this.vesovoi.selected = false;
            this.vesovoi.Size = new System.Drawing.Size(150, 40);
            this.vesovoi.TabIndex = 15;
            this.vesovoi.Text = "Весы";
            this.vesovoi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.vesovoi.Textcolor = System.Drawing.Color.White;
            this.vesovoi.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vesovoi.Visible = false;
            this.vesovoi.Click += new System.EventHandler(this.bunifuFlatButton1_Click_2);
            // 
            // kassa_but
            // 
            this.kassa_but.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.kassa_but.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.kassa_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.kassa_but.BorderRadius = 7;
            this.kassa_but.ButtonText = "Касса";
            this.kassa_but.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kassa_but.DisabledColor = System.Drawing.Color.Gray;
            this.kassa_but.Dock = System.Windows.Forms.DockStyle.Right;
            this.kassa_but.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.kassa_but.Iconcolor = System.Drawing.Color.Transparent;
            this.kassa_but.Iconimage = null;
            this.kassa_but.Iconimage_right = null;
            this.kassa_but.Iconimage_right_Selected = null;
            this.kassa_but.Iconimage_Selected = null;
            this.kassa_but.IconMarginLeft = 0;
            this.kassa_but.IconMarginRight = 0;
            this.kassa_but.IconRightVisible = true;
            this.kassa_but.IconRightZoom = 0D;
            this.kassa_but.IconVisible = true;
            this.kassa_but.IconZoom = 100D;
            this.kassa_but.IsTab = false;
            this.kassa_but.Location = new System.Drawing.Point(494, 0);
            this.kassa_but.Margin = new System.Windows.Forms.Padding(0);
            this.kassa_but.Name = "kassa_but";
            this.kassa_but.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.kassa_but.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.kassa_but.OnHoverTextColor = System.Drawing.Color.White;
            this.kassa_but.selected = false;
            this.kassa_but.Size = new System.Drawing.Size(150, 40);
            this.kassa_but.TabIndex = 6;
            this.kassa_but.Text = "Касса";
            this.kassa_but.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.kassa_but.Textcolor = System.Drawing.Color.White;
            this.kassa_but.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kassa_but.Visible = false;
            this.kassa_but.Click += new System.EventHandler(this.kassa_but_Click);
            // 
            // smenna
            // 
            this.smenna.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(250)))));
            this.smenna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.smenna.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smenna.BorderRadius = 7;
            this.smenna.ButtonText = "Смена";
            this.smenna.Cursor = System.Windows.Forms.Cursors.Hand;
            this.smenna.DisabledColor = System.Drawing.Color.Gray;
            this.smenna.Dock = System.Windows.Forms.DockStyle.Right;
            this.smenna.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.smenna.Iconcolor = System.Drawing.Color.Transparent;
            this.smenna.Iconimage = null;
            this.smenna.Iconimage_right = null;
            this.smenna.Iconimage_right_Selected = null;
            this.smenna.Iconimage_Selected = null;
            this.smenna.IconMarginLeft = 0;
            this.smenna.IconMarginRight = 0;
            this.smenna.IconRightVisible = true;
            this.smenna.IconRightZoom = 0D;
            this.smenna.IconVisible = true;
            this.smenna.IconZoom = 100D;
            this.smenna.IsTab = false;
            this.smenna.Location = new System.Drawing.Point(644, 0);
            this.smenna.Margin = new System.Windows.Forms.Padding(0);
            this.smenna.Name = "smenna";
            this.smenna.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.smenna.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(250)))));
            this.smenna.OnHoverTextColor = System.Drawing.Color.White;
            this.smenna.selected = false;
            this.smenna.Size = new System.Drawing.Size(150, 40);
            this.smenna.TabIndex = 14;
            this.smenna.Text = "Смена";
            this.smenna.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.smenna.Textcolor = System.Drawing.Color.White;
            this.smenna.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.smenna.Visible = false;
            this.smenna.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // prodect_but
            // 
            this.prodect_but.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(250)))));
            this.prodect_but.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.prodect_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.prodect_but.BorderRadius = 7;
            this.prodect_but.ButtonText = "Товары";
            this.prodect_but.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prodect_but.DisabledColor = System.Drawing.Color.Gray;
            this.prodect_but.Dock = System.Windows.Forms.DockStyle.Right;
            this.prodect_but.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.prodect_but.Iconcolor = System.Drawing.Color.Transparent;
            this.prodect_but.Iconimage = null;
            this.prodect_but.Iconimage_right = null;
            this.prodect_but.Iconimage_right_Selected = null;
            this.prodect_but.Iconimage_Selected = null;
            this.prodect_but.IconMarginLeft = 0;
            this.prodect_but.IconMarginRight = 0;
            this.prodect_but.IconRightVisible = true;
            this.prodect_but.IconRightZoom = 0D;
            this.prodect_but.IconVisible = true;
            this.prodect_but.IconZoom = 100D;
            this.prodect_but.IsTab = false;
            this.prodect_but.Location = new System.Drawing.Point(794, 0);
            this.prodect_but.Margin = new System.Windows.Forms.Padding(0);
            this.prodect_but.Name = "prodect_but";
            this.prodect_but.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.prodect_but.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(250)))));
            this.prodect_but.OnHoverTextColor = System.Drawing.Color.White;
            this.prodect_but.selected = false;
            this.prodect_but.Size = new System.Drawing.Size(150, 40);
            this.prodect_but.TabIndex = 13;
            this.prodect_but.Text = "Товары";
            this.prodect_but.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.prodect_but.Textcolor = System.Drawing.Color.White;
            this.prodect_but.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prodect_but.Visible = false;
            this.prodect_but.Click += new System.EventHandler(this.prodect_but_Click);
            // 
            // turn
            // 
            this.turn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.turn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.turn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.turn.BorderRadius = 7;
            this.turn.ButtonText = "";
            this.turn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.turn.DisabledColor = System.Drawing.Color.Gray;
            this.turn.Dock = System.Windows.Forms.DockStyle.Right;
            this.turn.Font = new System.Drawing.Font("Impact", 8.25F);
            this.turn.Iconcolor = System.Drawing.Color.Transparent;
            this.turn.Iconimage = ((System.Drawing.Image)(resources.GetObject("turn.Iconimage")));
            this.turn.Iconimage_right = null;
            this.turn.Iconimage_right_Selected = null;
            this.turn.Iconimage_Selected = null;
            this.turn.IconMarginLeft = 0;
            this.turn.IconMarginRight = 0;
            this.turn.IconRightVisible = true;
            this.turn.IconRightZoom = 0D;
            this.turn.IconVisible = true;
            this.turn.IconZoom = 30D;
            this.turn.IsTab = false;
            this.turn.Location = new System.Drawing.Point(944, 0);
            this.turn.Margin = new System.Windows.Forms.Padding(0);
            this.turn.Name = "turn";
            this.turn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.turn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.turn.OnHoverTextColor = System.Drawing.Color.White;
            this.turn.selected = false;
            this.turn.Size = new System.Drawing.Size(40, 40);
            this.turn.TabIndex = 2;
            this.turn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.turn.Textcolor = System.Drawing.Color.White;
            this.turn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turn.Click += new System.EventHandler(this.turn_Click);
            // 
            // close
            // 
            this.close.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close.BorderRadius = 7;
            this.close.ButtonText = "";
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.DisabledColor = System.Drawing.Color.Gray;
            this.close.Dock = System.Windows.Forms.DockStyle.Right;
            this.close.Font = new System.Drawing.Font("Impact", 8.25F);
            this.close.Iconcolor = System.Drawing.Color.Transparent;
            this.close.Iconimage = ((System.Drawing.Image)(resources.GetObject("close.Iconimage")));
            this.close.Iconimage_right = null;
            this.close.Iconimage_right_Selected = null;
            this.close.Iconimage_Selected = null;
            this.close.IconMarginLeft = 0;
            this.close.IconMarginRight = 0;
            this.close.IconRightVisible = true;
            this.close.IconRightZoom = 0D;
            this.close.IconVisible = true;
            this.close.IconZoom = 30D;
            this.close.IsTab = false;
            this.close.Location = new System.Drawing.Point(984, 0);
            this.close.Margin = new System.Windows.Forms.Padding(0);
            this.close.Name = "close";
            this.close.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.close.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.close.OnHoverTextColor = System.Drawing.Color.White;
            this.close.selected = false;
            this.close.Size = new System.Drawing.Size(40, 40);
            this.close.TabIndex = 0;
            this.close.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close.Textcolor = System.Drawing.Color.White;
            this.close.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.Color.White;
            this.output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output.Location = new System.Drawing.Point(0, 40);
            this.output.Margin = new System.Windows.Forms.Padding(4);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(1024, 701);
            this.output.TabIndex = 3;
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 7;
            this.bunifuFlatButton1.ButtonText = "Возврат";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.bunifuFlatButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = null;
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 100D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(194, 0);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(0);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(150, 40);
            this.bunifuFlatButton1.TabIndex = 16;
            this.bunifuFlatButton1.Text = "Возврат";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuFlatButton1.Visible = false;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 741);
            this.ControlBox = false;
            this.Controls.Add(this.output);
            this.Controls.Add(this.header);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "opana";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.main_KeyPress);
            this.header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Bunifu.Framework.UI.BunifuFlatButton close;
        private System.Windows.Forms.Panel header;
        public Bunifu.Framework.UI.BunifuFlatButton turn;
        public Bunifu.Framework.UI.BunifuFlatButton kassa_but;
        public Bunifu.Framework.UI.BunifuFlatButton prodect_but;
        public Bunifu.Framework.UI.BunifuFlatButton smenna;
        public Bunifu.Framework.UI.BunifuFlatButton vesovoi;
        public System.Windows.Forms.Panel output;
        public Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
    }
}
