
namespace OptiQ.TOVAR.DOBAV
{
    partial class kotcell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kotcell));
            this.text1 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.mark = new Bunifu.Framework.UI.BunifuCheckbox();
            this.delete = new Bunifu.Framework.UI.BunifuFlatButton();
            this.edit = new Bunifu.Framework.UI.BunifuFlatButton();
            this.create = new Bunifu.Framework.UI.BunifuFlatButton();
            this.savebut = new Bunifu.Framework.UI.BunifuFlatButton();
            this.close = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pookaz = new Bunifu.Framework.UI.BunifuFlatButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // text1
            // 
            this.text1.BackColor = System.Drawing.Color.White;
            this.text1.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.text1.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.text1.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.text1.BorderThickness = 1;
            this.text1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.text1.Enabled = false;
            this.text1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.text1.isPassword = false;
            this.text1.Location = new System.Drawing.Point(5, 5);
            this.text1.Margin = new System.Windows.Forms.Padding(0);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(230, 30);
            this.text1.TabIndex = 2;
            this.text1.Text = "Категориыя текс";
            this.text1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.text1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.text1_MouseDown);
            this.text1.MouseLeave += new System.EventHandler(this.text1_MouseLeave);
            this.text1.MouseHover += new System.EventHandler(this.text1_MouseHover);
            // 
            // mark
            // 
            this.mark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.mark.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.mark.Checked = true;
            this.mark.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.mark.ForeColor = System.Drawing.Color.White;
            this.mark.Location = new System.Drawing.Point(240, 10);
            this.mark.Margin = new System.Windows.Forms.Padding(5);
            this.mark.Name = "mark";
            this.mark.Size = new System.Drawing.Size(20, 20);
            this.mark.TabIndex = 1;
            this.mark.Visible = false;
            // 
            // delete
            // 
            this.delete.Activecolor = System.Drawing.Color.Transparent;
            this.delete.BackColor = System.Drawing.Color.Transparent;
            this.delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.delete.BorderRadius = 0;
            this.delete.ButtonText = "";
            this.delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete.DisabledColor = System.Drawing.Color.Gray;
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delete.Iconcolor = System.Drawing.Color.Transparent;
            this.delete.Iconimage = ((System.Drawing.Image)(resources.GetObject("delete.Iconimage")));
            this.delete.Iconimage_right = null;
            this.delete.Iconimage_right_Selected = null;
            this.delete.Iconimage_Selected = null;
            this.delete.IconMarginLeft = 0;
            this.delete.IconMarginRight = 0;
            this.delete.IconRightVisible = true;
            this.delete.IconRightZoom = 20D;
            this.delete.IconVisible = true;
            this.delete.IconZoom = 20D;
            this.delete.IsTab = false;
            this.delete.Location = new System.Drawing.Point(325, 5);
            this.delete.Margin = new System.Windows.Forms.Padding(0);
            this.delete.Name = "delete";
            this.delete.Normalcolor = System.Drawing.Color.Transparent;
            this.delete.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.delete.OnHoverTextColor = System.Drawing.Color.White;
            this.delete.selected = false;
            this.delete.Size = new System.Drawing.Size(30, 30);
            this.delete.TabIndex = 18;
            this.delete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.delete.Textcolor = System.Drawing.Color.White;
            this.delete.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delete.Visible = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // edit
            // 
            this.edit.Activecolor = System.Drawing.Color.Transparent;
            this.edit.BackColor = System.Drawing.Color.Transparent;
            this.edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.edit.BorderRadius = 0;
            this.edit.ButtonText = "";
            this.edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edit.DisabledColor = System.Drawing.Color.Gray;
            this.edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edit.Iconcolor = System.Drawing.Color.Transparent;
            this.edit.Iconimage = null;
            this.edit.Iconimage_right = ((System.Drawing.Image)(resources.GetObject("edit.Iconimage_right")));
            this.edit.Iconimage_right_Selected = null;
            this.edit.Iconimage_Selected = null;
            this.edit.IconMarginLeft = 0;
            this.edit.IconMarginRight = 0;
            this.edit.IconRightVisible = true;
            this.edit.IconRightZoom = 20D;
            this.edit.IconVisible = true;
            this.edit.IconZoom = 25D;
            this.edit.IsTab = false;
            this.edit.Location = new System.Drawing.Point(355, 5);
            this.edit.Margin = new System.Windows.Forms.Padding(0);
            this.edit.Name = "edit";
            this.edit.Normalcolor = System.Drawing.Color.Transparent;
            this.edit.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.edit.OnHoverTextColor = System.Drawing.Color.White;
            this.edit.selected = false;
            this.edit.Size = new System.Drawing.Size(30, 30);
            this.edit.TabIndex = 11;
            this.edit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.edit.Textcolor = System.Drawing.Color.White;
            this.edit.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edit.Visible = false;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // create
            // 
            this.create.Activecolor = System.Drawing.Color.Transparent;
            this.create.BackColor = System.Drawing.Color.Transparent;
            this.create.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.create.BorderRadius = 0;
            this.create.ButtonText = "";
            this.create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.create.DisabledColor = System.Drawing.Color.Gray;
            this.create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.create.Iconcolor = System.Drawing.Color.Transparent;
            this.create.Iconimage = ((System.Drawing.Image)(resources.GetObject("create.Iconimage")));
            this.create.Iconimage_right = null;
            this.create.Iconimage_right_Selected = null;
            this.create.Iconimage_Selected = null;
            this.create.IconMarginLeft = 0;
            this.create.IconMarginRight = 0;
            this.create.IconRightVisible = true;
            this.create.IconRightZoom = 20D;
            this.create.IconVisible = true;
            this.create.IconZoom = 20D;
            this.create.IsTab = false;
            this.create.Location = new System.Drawing.Point(385, 5);
            this.create.Margin = new System.Windows.Forms.Padding(0);
            this.create.Name = "create";
            this.create.Normalcolor = System.Drawing.Color.Transparent;
            this.create.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.create.OnHoverTextColor = System.Drawing.Color.White;
            this.create.selected = false;
            this.create.Size = new System.Drawing.Size(30, 30);
            this.create.TabIndex = 14;
            this.create.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.create.Textcolor = System.Drawing.Color.White;
            this.create.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.create.Visible = false;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // savebut
            // 
            this.savebut.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.savebut.BackColor = System.Drawing.Color.Transparent;
            this.savebut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.savebut.BorderRadius = 0;
            this.savebut.ButtonText = "";
            this.savebut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.savebut.DisabledColor = System.Drawing.Color.Gray;
            this.savebut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.savebut.Iconcolor = System.Drawing.Color.Transparent;
            this.savebut.Iconimage = ((System.Drawing.Image)(resources.GetObject("savebut.Iconimage")));
            this.savebut.Iconimage_right = null;
            this.savebut.Iconimage_right_Selected = null;
            this.savebut.Iconimage_Selected = null;
            this.savebut.IconMarginLeft = 0;
            this.savebut.IconMarginRight = 0;
            this.savebut.IconRightVisible = true;
            this.savebut.IconRightZoom = 20D;
            this.savebut.IconVisible = true;
            this.savebut.IconZoom = 20D;
            this.savebut.IsTab = false;
            this.savebut.Location = new System.Drawing.Point(265, 5);
            this.savebut.Margin = new System.Windows.Forms.Padding(0);
            this.savebut.Name = "savebut";
            this.savebut.Normalcolor = System.Drawing.Color.Transparent;
            this.savebut.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.savebut.OnHoverTextColor = System.Drawing.Color.White;
            this.savebut.selected = false;
            this.savebut.Size = new System.Drawing.Size(30, 30);
            this.savebut.TabIndex = 13;
            this.savebut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.savebut.Textcolor = System.Drawing.Color.White;
            this.savebut.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.savebut.Visible = false;
            this.savebut.Click += new System.EventHandler(this.savebut_Click);
            // 
            // close
            // 
            this.close.Activecolor = System.Drawing.Color.Transparent;
            this.close.BackColor = System.Drawing.Color.Transparent;
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close.BorderRadius = 0;
            this.close.ButtonText = "";
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.DisabledColor = System.Drawing.Color.Gray;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.close.Iconcolor = System.Drawing.Color.Transparent;
            this.close.Iconimage = ((System.Drawing.Image)(resources.GetObject("close.Iconimage")));
            this.close.Iconimage_right = null;
            this.close.Iconimage_right_Selected = null;
            this.close.Iconimage_Selected = null;
            this.close.IconMarginLeft = 0;
            this.close.IconMarginRight = 0;
            this.close.IconRightVisible = true;
            this.close.IconRightZoom = 20D;
            this.close.IconVisible = true;
            this.close.IconZoom = 20D;
            this.close.IsTab = false;
            this.close.Location = new System.Drawing.Point(295, 5);
            this.close.Margin = new System.Windows.Forms.Padding(0);
            this.close.Name = "close";
            this.close.Normalcolor = System.Drawing.Color.Transparent;
            this.close.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.close.OnHoverTextColor = System.Drawing.Color.White;
            this.close.selected = false;
            this.close.Size = new System.Drawing.Size(30, 30);
            this.close.TabIndex = 12;
            this.close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.close.Textcolor = System.Drawing.Color.White;
            this.close.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.close.Visible = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this.flowLayoutPanel1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.text1);
            this.flowLayoutPanel1.Controls.Add(this.mark);
            this.flowLayoutPanel1.Controls.Add(this.savebut);
            this.flowLayoutPanel1.Controls.Add(this.close);
            this.flowLayoutPanel1.Controls.Add(this.delete);
            this.flowLayoutPanel1.Controls.Add(this.edit);
            this.flowLayoutPanel1.Controls.Add(this.create);
            this.flowLayoutPanel1.Controls.Add(this.pookaz);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(450, 40);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.text1_MouseDown);
            this.flowLayoutPanel1.MouseLeave += new System.EventHandler(this.text1_MouseLeave);
            this.flowLayoutPanel1.MouseHover += new System.EventHandler(this.text1_MouseHover);
            // 
            // pookaz
            // 
            this.pookaz.Activecolor = System.Drawing.Color.Transparent;
            this.pookaz.BackColor = System.Drawing.Color.Transparent;
            this.pookaz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pookaz.BorderRadius = 0;
            this.pookaz.ButtonText = "";
            this.pookaz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pookaz.DisabledColor = System.Drawing.Color.Gray;
            this.pookaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pookaz.Iconcolor = System.Drawing.Color.Transparent;
            this.pookaz.Iconimage = ((System.Drawing.Image)(resources.GetObject("pookaz.Iconimage")));
            this.pookaz.Iconimage_right = null;
            this.pookaz.Iconimage_right_Selected = null;
            this.pookaz.Iconimage_Selected = null;
            this.pookaz.IconMarginLeft = 0;
            this.pookaz.IconMarginRight = 0;
            this.pookaz.IconRightVisible = true;
            this.pookaz.IconRightZoom = 20D;
            this.pookaz.IconVisible = true;
            this.pookaz.IconZoom = 20D;
            this.pookaz.IsTab = false;
            this.pookaz.Location = new System.Drawing.Point(415, 5);
            this.pookaz.Margin = new System.Windows.Forms.Padding(0);
            this.pookaz.Name = "pookaz";
            this.pookaz.Normalcolor = System.Drawing.Color.Transparent;
            this.pookaz.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.pookaz.OnHoverTextColor = System.Drawing.Color.White;
            this.pookaz.selected = false;
            this.pookaz.Size = new System.Drawing.Size(30, 30);
            this.pookaz.TabIndex = 19;
            this.pookaz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pookaz.Textcolor = System.Drawing.Color.White;
            this.pookaz.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pookaz.Visible = false;
            this.pookaz.Click += new System.EventHandler(this.pookaz_Click);
            // 
            // kotcell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "kotcell";
            this.Size = new System.Drawing.Size(450, 40);
            this.Load += new System.EventHandler(this.kotcell_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.text1_MouseDown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        public Bunifu.Framework.UI.BunifuMetroTextbox text1;
        private Bunifu.Framework.UI.BunifuCheckbox mark;
        private Bunifu.Framework.UI.BunifuFlatButton edit;
        private Bunifu.Framework.UI.BunifuFlatButton create;
        private Bunifu.Framework.UI.BunifuFlatButton savebut;
        private Bunifu.Framework.UI.BunifuFlatButton close;
        private Bunifu.Framework.UI.BunifuFlatButton delete;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Bunifu.Framework.UI.BunifuFlatButton pookaz;
    }
}
