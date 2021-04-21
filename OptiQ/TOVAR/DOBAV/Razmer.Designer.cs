
namespace OptiQ
{
    partial class Razmer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Razmer));
            this.textpie = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.shjowkeyboard5 = new OptiQ.shjowkeyboard();
            this.textname = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.plus = new Bunifu.Framework.UI.BunifuFlatButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.delete = new Bunifu.Framework.UI.BunifuFlatButton();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textpie
            // 
            this.textpie.BackColor = System.Drawing.Color.White;
            this.textpie.BorderColorFocused = System.Drawing.Color.Blue;
            this.textpie.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textpie.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.textpie.BorderThickness = 1;
            this.textpie.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textpie.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textpie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.textpie.isPassword = false;
            this.textpie.Location = new System.Drawing.Point(200, 10);
            this.textpie.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.textpie.Name = "textpie";
            this.textpie.Size = new System.Drawing.Size(200, 30);
            this.textpie.TabIndex = 4;
            this.textpie.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textpie.OnValueChanged += new System.EventHandler(this.textpie_OnValueChanged);
            this.textpie.Enter += new System.EventHandler(this.textopt_Enter);
            this.textpie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textpie_KeyPress);
            this.textpie.Leave += new System.EventHandler(this.textopt_Leave);
            // 
            // shjowkeyboard5
            // 
            this.shjowkeyboard5.BackColor = System.Drawing.Color.Transparent;
            this.shjowkeyboard5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shjowkeyboard5.Location = new System.Drawing.Point(410, 10);
            this.shjowkeyboard5.Margin = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.shjowkeyboard5.Name = "shjowkeyboard5";
            this.shjowkeyboard5.Size = new System.Drawing.Size(30, 30);
            this.shjowkeyboard5.TabIndex = 14;
            this.shjowkeyboard5.Visible = false;
            // 
            // textname
            // 
            this.textname.BackColor = System.Drawing.Color.White;
            this.textname.BorderColorFocused = System.Drawing.Color.Blue;
            this.textname.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textname.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.textname.BorderThickness = 1;
            this.textname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textname.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.textname.isPassword = false;
            this.textname.Location = new System.Drawing.Point(20, 10);
            this.textname.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.textname.Name = "textname";
            this.textname.Size = new System.Drawing.Size(170, 30);
            this.textname.TabIndex = 5;
            this.textname.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textname.OnValueChanged += new System.EventHandler(this.textname_OnValueChanged);
            this.textname.Enter += new System.EventHandler(this.textopt_Enter);
            this.textname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textname_KeyPress);
            this.textname.Leave += new System.EventHandler(this.textopt_Leave);
            // 
            // plus
            // 
            this.plus.Activecolor = System.Drawing.Color.Transparent;
            this.plus.BackColor = System.Drawing.Color.Transparent;
            this.plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plus.BorderRadius = 0;
            this.plus.ButtonText = "";
            this.plus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plus.DisabledColor = System.Drawing.Color.Gray;
            this.plus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plus.Iconcolor = System.Drawing.Color.Transparent;
            this.plus.Iconimage = ((System.Drawing.Image)(resources.GetObject("plus.Iconimage")));
            this.plus.Iconimage_right = null;
            this.plus.Iconimage_right_Selected = null;
            this.plus.Iconimage_Selected = null;
            this.plus.IconMarginLeft = 0;
            this.plus.IconMarginRight = 0;
            this.plus.IconRightVisible = true;
            this.plus.IconRightZoom = 0D;
            this.plus.IconVisible = true;
            this.plus.IconZoom = 35D;
            this.plus.IsTab = false;
            this.plus.Location = new System.Drawing.Point(40, 10);
            this.plus.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.plus.Name = "plus";
            this.plus.Normalcolor = System.Drawing.Color.Transparent;
            this.plus.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.plus.OnHoverTextColor = System.Drawing.Color.White;
            this.plus.selected = false;
            this.plus.Size = new System.Drawing.Size(30, 30);
            this.plus.TabIndex = 15;
            this.plus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.plus.Textcolor = System.Drawing.Color.White;
            this.plus.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.delete);
            this.flowLayoutPanel2.Controls.Add(this.plus);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(450, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(70, 50);
            this.flowLayoutPanel2.TabIndex = 17;
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
            this.delete.IconZoom = 35D;
            this.delete.IsTab = false;
            this.delete.Location = new System.Drawing.Point(0, 10);
            this.delete.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.delete.Name = "delete";
            this.delete.Normalcolor = System.Drawing.Color.Transparent;
            this.delete.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.delete.OnHoverTextColor = System.Drawing.Color.White;
            this.delete.selected = false;
            this.delete.Size = new System.Drawing.Size(30, 30);
            this.delete.TabIndex = 17;
            this.delete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.delete.Textcolor = System.Drawing.Color.White;
            this.delete.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // Razmer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.textname);
            this.Controls.Add(this.textpie);
            this.Controls.Add(this.shjowkeyboard5);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.Name = "Razmer";
            this.Size = new System.Drawing.Size(520, 50);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private shjowkeyboard shjowkeyboard5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public Bunifu.Framework.UI.BunifuFlatButton plus;
        public Bunifu.Framework.UI.BunifuMetroTextbox textpie;
        public Bunifu.Framework.UI.BunifuMetroTextbox textname;
        public Bunifu.Framework.UI.BunifuFlatButton delete;
    }
}
