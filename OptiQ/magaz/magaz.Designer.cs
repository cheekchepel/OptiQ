
namespace OptiQ.magaz
{
    partial class magaz
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(magaz));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.test = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.label4 = new System.Windows.Forms.Label();
            this.bunifuFlatButton15 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuFlatButton7 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mzSombraPanel1 = new MZControls.MZSombraPanel();
            this.magname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.mzSombraPanel2 = new MZControls.MZSombraPanel();
            this.magadres = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.npgsqlCommandBuilder1 = new Npgsql.NpgsqlCommandBuilder();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.mzSombraPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.mzSombraPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
            this.panel1.Controls.Add(this.test);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 40);
            this.panel1.TabIndex = 0;
            // 
            // test
            // 
            this.test.BackColor = System.Drawing.Color.Transparent;
            this.test.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("test.BackgroundImage")));
            this.test.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.test.Cursor = System.Windows.Forms.Cursors.Hand;
            this.test.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.test.Location = new System.Drawing.Point(10, 10);
            this.test.Margin = new System.Windows.Forms.Padding(5);
            this.test.Name = "test";
            this.test.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
            this.test.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.test.Size = new System.Drawing.Size(35, 20);
            this.test.TabIndex = 16;
            this.test.Value = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(94, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(252, 24);
            this.label4.TabIndex = 60;
            this.label4.Text = "Информация о магазине";
            // 
            // bunifuFlatButton15
            // 
            this.bunifuFlatButton15.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.bunifuFlatButton15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.bunifuFlatButton15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton15.BorderRadius = 7;
            this.bunifuFlatButton15.ButtonText = "Сохранить";
            this.bunifuFlatButton15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton15.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton15.Dock = System.Windows.Forms.DockStyle.Right;
            this.bunifuFlatButton15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuFlatButton15.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton15.Iconimage = null;
            this.bunifuFlatButton15.Iconimage_right = null;
            this.bunifuFlatButton15.Iconimage_right_Selected = null;
            this.bunifuFlatButton15.Iconimage_Selected = null;
            this.bunifuFlatButton15.IconMarginLeft = 0;
            this.bunifuFlatButton15.IconMarginRight = 0;
            this.bunifuFlatButton15.IconRightVisible = true;
            this.bunifuFlatButton15.IconRightZoom = 0D;
            this.bunifuFlatButton15.IconVisible = true;
            this.bunifuFlatButton15.IconZoom = 90D;
            this.bunifuFlatButton15.IsTab = false;
            this.bunifuFlatButton15.Location = new System.Drawing.Point(310, 10);
            this.bunifuFlatButton15.Margin = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.bunifuFlatButton15.Name = "bunifuFlatButton15";
            this.bunifuFlatButton15.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.bunifuFlatButton15.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(111)))), ((int)(((byte)(177)))));
            this.bunifuFlatButton15.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton15.selected = false;
            this.bunifuFlatButton15.Size = new System.Drawing.Size(120, 35);
            this.bunifuFlatButton15.TabIndex = 10;
            this.bunifuFlatButton15.Text = "Сохранить";
            this.bunifuFlatButton15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton15.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton15.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuFlatButton15.Click += new System.EventHandler(this.bunifuFlatButton15_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.bunifuFlatButton7);
            this.panel2.Controls.Add(this.bunifuFlatButton15);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 265);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(440, 55);
            this.panel2.TabIndex = 11;
            // 
            // bunifuFlatButton7
            // 
            this.bunifuFlatButton7.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.bunifuFlatButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.bunifuFlatButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton7.BorderRadius = 7;
            this.bunifuFlatButton7.ButtonText = "Отменить";
            this.bunifuFlatButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton7.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton7.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuFlatButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuFlatButton7.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton7.Iconimage = null;
            this.bunifuFlatButton7.Iconimage_right = null;
            this.bunifuFlatButton7.Iconimage_right_Selected = null;
            this.bunifuFlatButton7.Iconimage_Selected = null;
            this.bunifuFlatButton7.IconMarginLeft = 0;
            this.bunifuFlatButton7.IconMarginRight = 0;
            this.bunifuFlatButton7.IconRightVisible = true;
            this.bunifuFlatButton7.IconRightZoom = 0D;
            this.bunifuFlatButton7.IconVisible = true;
            this.bunifuFlatButton7.IconZoom = 90D;
            this.bunifuFlatButton7.IsTab = false;
            this.bunifuFlatButton7.Location = new System.Drawing.Point(10, 10);
            this.bunifuFlatButton7.Margin = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.bunifuFlatButton7.Name = "bunifuFlatButton7";
            this.bunifuFlatButton7.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.bunifuFlatButton7.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuFlatButton7.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton7.selected = false;
            this.bunifuFlatButton7.Size = new System.Drawing.Size(122, 35);
            this.bunifuFlatButton7.TabIndex = 11;
            this.bunifuFlatButton7.Text = "Отменить";
            this.bunifuFlatButton7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton7.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton7.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuFlatButton7.Click += new System.EventHandler(this.bunifuFlatButton7_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.mzSombraPanel1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.panel3.Size = new System.Drawing.Size(440, 76);
            this.panel3.TabIndex = 12;
            // 
            // mzSombraPanel1
            // 
            this.mzSombraPanel1.AddControl = null;
            this.mzSombraPanel1.Controls.Add(this.magname);
            this.mzSombraPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.mzSombraPanel1.Location = new System.Drawing.Point(10, 30);
            this.mzSombraPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.mzSombraPanel1.Name = "mzSombraPanel1";
            this.mzSombraPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.mzSombraPanel1.Size = new System.Drawing.Size(320, 46);
            this.mzSombraPanel1.TabIndex = 3;
            this.mzSombraPanel1.TipoDeSombra = MZControls.MZSombraPanel.ShadowsPanel.Central;
            // 
            // magname
            // 
            this.magname.BackColor = System.Drawing.Color.White;
            this.magname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.magname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.magname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.magname.Location = new System.Drawing.Point(10, 10);
            this.magname.Name = "magname";
            this.magname.Size = new System.Drawing.Size(300, 26);
            this.magname.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Название магазина";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.mzSombraPanel2);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 116);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel4.Size = new System.Drawing.Size(440, 66);
            this.panel4.TabIndex = 13;
            // 
            // mzSombraPanel2
            // 
            this.mzSombraPanel2.AddControl = null;
            this.mzSombraPanel2.Controls.Add(this.magadres);
            this.mzSombraPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.mzSombraPanel2.Location = new System.Drawing.Point(10, 20);
            this.mzSombraPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.mzSombraPanel2.Name = "mzSombraPanel2";
            this.mzSombraPanel2.Padding = new System.Windows.Forms.Padding(10);
            this.mzSombraPanel2.Size = new System.Drawing.Size(320, 46);
            this.mzSombraPanel2.TabIndex = 3;
            this.mzSombraPanel2.TipoDeSombra = MZControls.MZSombraPanel.ShadowsPanel.Central;
            // 
            // magadres
            // 
            this.magadres.BackColor = System.Drawing.Color.White;
            this.magadres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.magadres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.magadres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.magadres.Location = new System.Drawing.Point(10, 10);
            this.magadres.Name = "magadres";
            this.magadres.Size = new System.Drawing.Size(300, 26);
            this.magadres.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
            this.label2.Location = new System.Drawing.Point(10, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Адрес магазина";
            // 
            // npgsqlCommandBuilder1
            // 
            this.npgsqlCommandBuilder1.QuotePrefix = "\"";
            this.npgsqlCommandBuilder1.QuoteSuffix = "\"";
            // 
            // magaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.Name = "magaz";
            this.Size = new System.Drawing.Size(440, 320);
            this.Load += new System.EventHandler(this.admin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.mzSombraPanel1.ResumeLayout(false);
            this.mzSombraPanel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.mzSombraPanel2.ResumeLayout(false);
            this.mzSombraPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton15;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private MZControls.MZSombraPanel mzSombraPanel1;
        private System.Windows.Forms.TextBox magname;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private MZControls.MZSombraPanel mzSombraPanel2;
        private System.Windows.Forms.TextBox magadres;
        private Bunifu.Framework.UI.BunifuiOSSwitch test;
        private Npgsql.NpgsqlCommandBuilder npgsqlCommandBuilder1;
    }
}
