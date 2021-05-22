
namespace OptiQ.LOGIN
{
    partial class logadm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(logadm));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.shjowkeyboard2 = new OptiQ.shjowkeyboard();
            this.shjowkeyboard1 = new OptiQ.shjowkeyboard();
            this.login_button = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pass_text = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pass_img = new System.Windows.Forms.Label();
            this.label_label = new System.Windows.Forms.Label();
            this.text_login = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.close = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // shjowkeyboard2
            // 
            this.shjowkeyboard2.BackColor = System.Drawing.Color.White;
            this.shjowkeyboard2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shjowkeyboard2.Location = new System.Drawing.Point(305, 135);
            this.shjowkeyboard2.Margin = new System.Windows.Forms.Padding(0);
            this.shjowkeyboard2.Name = "shjowkeyboard2";
            this.shjowkeyboard2.Size = new System.Drawing.Size(30, 30);
            this.shjowkeyboard2.TabIndex = 27;
            this.shjowkeyboard2.Visible = false;
            // 
            // shjowkeyboard1
            // 
            this.shjowkeyboard1.BackColor = System.Drawing.Color.White;
            this.shjowkeyboard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shjowkeyboard1.Location = new System.Drawing.Point(305, 46);
            this.shjowkeyboard1.Margin = new System.Windows.Forms.Padding(0);
            this.shjowkeyboard1.Name = "shjowkeyboard1";
            this.shjowkeyboard1.Size = new System.Drawing.Size(30, 30);
            this.shjowkeyboard1.TabIndex = 26;
            this.shjowkeyboard1.Visible = false;
            // 
            // login_button
            // 
            this.login_button.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.login_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.login_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.login_button.BorderRadius = 7;
            this.login_button.ButtonText = "Войти";
            this.login_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login_button.DisabledColor = System.Drawing.Color.Gray;
            this.login_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_button.Iconcolor = System.Drawing.Color.Transparent;
            this.login_button.Iconimage = null;
            this.login_button.Iconimage_right = null;
            this.login_button.Iconimage_right_Selected = null;
            this.login_button.Iconimage_Selected = null;
            this.login_button.IconMarginLeft = 0;
            this.login_button.IconMarginRight = 0;
            this.login_button.IconRightVisible = true;
            this.login_button.IconRightZoom = 0D;
            this.login_button.IconVisible = true;
            this.login_button.IconZoom = 90D;
            this.login_button.IsTab = false;
            this.login_button.Location = new System.Drawing.Point(15, 190);
            this.login_button.Margin = new System.Windows.Forms.Padding(0);
            this.login_button.Name = "login_button";
            this.login_button.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.login_button.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(111)))), ((int)(((byte)(177)))));
            this.login_button.OnHoverTextColor = System.Drawing.Color.White;
            this.login_button.selected = false;
            this.login_button.Size = new System.Drawing.Size(320, 40);
            this.login_button.TabIndex = 22;
            this.login_button.Text = "Войти";
            this.login_button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.login_button.Textcolor = System.Drawing.Color.White;
            this.login_button.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // pass_text
            // 
            this.pass_text.BackColor = System.Drawing.Color.White;
            this.pass_text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pass_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pass_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.pass_text.HintForeColor = System.Drawing.Color.DarkGray;
            this.pass_text.HintText = "пароль";
            this.pass_text.isPassword = true;
            this.pass_text.LineFocusedColor = System.Drawing.Color.BlueViolet;
            this.pass_text.LineIdleColor = System.Drawing.Color.DarkGray;
            this.pass_text.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(92)))), ((int)(((byte)(179)))));
            this.pass_text.LineThickness = 4;
            this.pass_text.Location = new System.Drawing.Point(15, 131);
            this.pass_text.Margin = new System.Windows.Forms.Padding(4);
            this.pass_text.Name = "pass_text";
            this.pass_text.Size = new System.Drawing.Size(320, 38);
            this.pass_text.TabIndex = 21;
            this.pass_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // pass_img
            // 
            this.pass_img.AutoSize = true;
            this.pass_img.BackColor = System.Drawing.Color.White;
            this.pass_img.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pass_img.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
            this.pass_img.Location = new System.Drawing.Point(15, 105);
            this.pass_img.Name = "pass_img";
            this.pass_img.Size = new System.Drawing.Size(82, 24);
            this.pass_img.TabIndex = 24;
            this.pass_img.Text = "Пароль";
            // 
            // label_label
            // 
            this.label_label.AutoSize = true;
            this.label_label.BackColor = System.Drawing.Color.White;
            this.label_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
            this.label_label.Location = new System.Drawing.Point(15, 15);
            this.label_label.Name = "label_label";
            this.label_label.Size = new System.Drawing.Size(69, 24);
            this.label_label.TabIndex = 23;
            this.label_label.Text = "Логин";
            // 
            // text_login
            // 
            this.text_login.BackColor = System.Drawing.Color.White;
            this.text_login.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.text_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.text_login.HintForeColor = System.Drawing.Color.DarkGray;
            this.text_login.HintText = "логин";
            this.text_login.isPassword = false;
            this.text_login.LineFocusedColor = System.Drawing.Color.BlueViolet;
            this.text_login.LineIdleColor = System.Drawing.Color.DarkGray;
            this.text_login.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(92)))), ((int)(((byte)(179)))));
            this.text_login.LineThickness = 4;
            this.text_login.Location = new System.Drawing.Point(15, 42);
            this.text_login.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.text_login.Name = "text_login";
            this.text_login.Size = new System.Drawing.Size(320, 38);
            this.text_login.TabIndex = 20;
            this.text_login.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.close.Location = new System.Drawing.Point(305, 0);
            this.close.Margin = new System.Windows.Forms.Padding(0);
            this.close.Name = "close";
            this.close.Normalcolor = System.Drawing.Color.Transparent;
            this.close.OnHovercolor = System.Drawing.Color.Transparent;
            this.close.OnHoverTextColor = System.Drawing.Color.White;
            this.close.selected = false;
            this.close.Size = new System.Drawing.Size(40, 40);
            this.close.TabIndex = 28;
            this.close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.close.Textcolor = System.Drawing.Color.White;
            this.close.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // logadm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 245);
            this.Controls.Add(this.close);
            this.Controls.Add(this.shjowkeyboard2);
            this.Controls.Add(this.shjowkeyboard1);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.pass_text);
            this.Controls.Add(this.pass_img);
            this.Controls.Add(this.label_label);
            this.Controls.Add(this.text_login);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "logadm";
            this.Text = "logadm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.logadm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private shjowkeyboard shjowkeyboard2;
        private shjowkeyboard shjowkeyboard1;
        private Bunifu.Framework.UI.BunifuFlatButton login_button;
        private Bunifu.Framework.UI.BunifuMaterialTextbox pass_text;
        private System.Windows.Forms.Label pass_img;
        private System.Windows.Forms.Label label_label;
        private Bunifu.Framework.UI.BunifuMaterialTextbox text_login;
        private Bunifu.Framework.UI.BunifuFlatButton close;
    }
}