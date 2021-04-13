
namespace OptiQ
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.login_form = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.login_button = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pass_text = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pass_img = new System.Windows.Forms.Label();
            this.avtor_label = new System.Windows.Forms.Label();
            this.label_label = new System.Windows.Forms.Label();
            this.text_login = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.login_img = new System.Windows.Forms.PictureBox();
            this.form_login_elips = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.linkLabel_sign = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.login_form.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.login_img)).BeginInit();
            this.SuspendLayout();
            // 
            // login_form
            // 
            this.login_form.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.login_form.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("login_form.BackgroundImage")));
            this.login_form.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.login_form.Controls.Add(this.label1);
            this.login_form.Controls.Add(this.linkLabel_sign);
            this.login_form.Controls.Add(this.login_button);
            this.login_form.Controls.Add(this.pass_text);
            this.login_form.Controls.Add(this.pass_img);
            this.login_form.Controls.Add(this.avtor_label);
            this.login_form.Controls.Add(this.label_label);
            this.login_form.Controls.Add(this.text_login);
            this.login_form.Controls.Add(this.login_img);
            this.login_form.ForeColor = System.Drawing.Color.White;
            this.login_form.GradientBottomLeft = System.Drawing.Color.White;
            this.login_form.GradientBottomRight = System.Drawing.Color.Transparent;
            this.login_form.GradientTopLeft = System.Drawing.Color.Empty;
            this.login_form.GradientTopRight = System.Drawing.Color.Empty;
            this.login_form.Location = new System.Drawing.Point(300, 118);
            this.login_form.Name = "login_form";
            this.login_form.Quality = 10;
            this.login_form.Size = new System.Drawing.Size(600, 554);
            this.login_form.TabIndex = 7;
            // 
            // login_button
            // 
            this.login_button.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.login_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(92)))), ((int)(((byte)(179)))));
            this.login_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.login_button.BorderRadius = 0;
            this.login_button.ButtonText = "Войти";
            this.login_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login_button.DisabledColor = System.Drawing.Color.Gray;
            this.login_button.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.login_button.Location = new System.Drawing.Point(225, 405);
            this.login_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.login_button.Name = "login_button";
            this.login_button.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(92)))), ((int)(((byte)(179)))));
            this.login_button.OnHovercolor = System.Drawing.Color.RoyalBlue;
            this.login_button.OnHoverTextColor = System.Drawing.Color.White;
            this.login_button.selected = false;
            this.login_button.Size = new System.Drawing.Size(150, 50);
            this.login_button.TabIndex = 3;
            this.login_button.Text = "Войти";
            this.login_button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.login_button.Textcolor = System.Drawing.Color.White;
            this.login_button.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // pass_text
            // 
            this.pass_text.BackColor = System.Drawing.Color.White;
            this.pass_text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pass_text.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pass_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.pass_text.HintForeColor = System.Drawing.Color.Gray;
            this.pass_text.HintText = "пароль";
            this.pass_text.isPassword = true;
            this.pass_text.LineFocusedColor = System.Drawing.Color.BlueViolet;
            this.pass_text.LineIdleColor = System.Drawing.Color.Gray;
            this.pass_text.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(92)))), ((int)(((byte)(179)))));
            this.pass_text.LineThickness = 4;
            this.pass_text.Location = new System.Drawing.Point(150, 322);
            this.pass_text.Margin = new System.Windows.Forms.Padding(4);
            this.pass_text.Name = "pass_text";
            this.pass_text.Size = new System.Drawing.Size(300, 40);
            this.pass_text.TabIndex = 2;
            this.pass_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pass_text.OnValueChanged += new System.EventHandler(this.pass_text_OnValueChanged);
            // 
            // pass_img
            // 
            this.pass_img.AutoSize = true;
            this.pass_img.BackColor = System.Drawing.Color.White;
            this.pass_img.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pass_img.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.pass_img.Location = new System.Drawing.Point(146, 295);
            this.pass_img.Name = "pass_img";
            this.pass_img.Size = new System.Drawing.Size(74, 23);
            this.pass_img.TabIndex = 10;
            this.pass_img.Text = "Пароль";
            this.pass_img.Click += new System.EventHandler(this.pass_img_Click);
            // 
            // avtor_label
            // 
            this.avtor_label.AutoSize = true;
            this.avtor_label.BackColor = System.Drawing.Color.White;
            this.avtor_label.Font = new System.Drawing.Font("Bahnschrift", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.avtor_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.avtor_label.Location = new System.Drawing.Point(143, 93);
            this.avtor_label.Name = "avtor_label";
            this.avtor_label.Size = new System.Drawing.Size(314, 58);
            this.avtor_label.TabIndex = 13;
            this.avtor_label.Text = "Авторизация";
            // 
            // label_label
            // 
            this.label_label.AutoSize = true;
            this.label_label.BackColor = System.Drawing.Color.White;
            this.label_label.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.label_label.Location = new System.Drawing.Point(146, 194);
            this.label_label.Name = "label_label";
            this.label_label.Size = new System.Drawing.Size(64, 23);
            this.label_label.TabIndex = 9;
            this.label_label.Text = "Логин";
            // 
            // text_login
            // 
            this.text_login.BackColor = System.Drawing.Color.White;
            this.text_login.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.text_login.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.text_login.HintForeColor = System.Drawing.Color.Gray;
            this.text_login.HintText = "логин";
            this.text_login.isPassword = false;
            this.text_login.LineFocusedColor = System.Drawing.Color.BlueViolet;
            this.text_login.LineIdleColor = System.Drawing.Color.Gray;
            this.text_login.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(92)))), ((int)(((byte)(179)))));
            this.text_login.LineThickness = 4;
            this.text_login.Location = new System.Drawing.Point(150, 222);
            this.text_login.Margin = new System.Windows.Forms.Padding(5);
            this.text_login.Name = "text_login";
            this.text_login.Size = new System.Drawing.Size(300, 40);
            this.text_login.TabIndex = 1;
            this.text_login.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.text_login.OnValueChanged += new System.EventHandler(this.text_login_OnValueChanged);
            // 
            // login_img
            // 
            this.login_img.BackColor = System.Drawing.Color.White;
            this.login_img.Dock = System.Windows.Forms.DockStyle.Fill;
            this.login_img.Image = ((System.Drawing.Image)(resources.GetObject("login_img.Image")));
            this.login_img.Location = new System.Drawing.Point(0, 0);
            this.login_img.Name = "login_img";
            this.login_img.Size = new System.Drawing.Size(600, 554);
            this.login_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.login_img.TabIndex = 0;
            this.login_img.TabStop = false;
            // 
            // form_login_elips
            // 
            this.form_login_elips.ElipseRadius = 40;
            this.form_login_elips.TargetControl = this.login_form;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this.login_button;
            // 
            // linkLabel_sign
            // 
            this.linkLabel_sign.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.linkLabel_sign.AutoSize = true;
            this.linkLabel_sign.BackColor = System.Drawing.Color.White;
            this.linkLabel_sign.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.linkLabel_sign.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabel_sign.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.linkLabel_sign.Location = new System.Drawing.Point(298, 494);
            this.linkLabel_sign.Name = "linkLabel_sign";
            this.linkLabel_sign.Size = new System.Drawing.Size(177, 19);
            this.linkLabel_sign.TabIndex = 14;
            this.linkLabel_sign.TabStop = true;
            this.linkLabel_sign.Text = "Присоедениться к нам";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(140, 494);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Нет учетной записи?";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.Controls.Add(this.login_form);
            this.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(148)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "login";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 800, 0);
            this.Text = "login";
            this.Load += new System.EventHandler(this.login_Load);
            this.login_form.ResumeLayout(false);
            this.login_form.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.login_img)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuGradientPanel login_form;
        private System.Windows.Forms.Label pass_img;
        private System.Windows.Forms.Label avtor_label;
        private System.Windows.Forms.Label label_label;
        private Bunifu.Framework.UI.BunifuElipse form_login_elips;
        private Bunifu.Framework.UI.BunifuMaterialTextbox text_login;
        private System.Windows.Forms.PictureBox login_img;
        private Bunifu.Framework.UI.BunifuMaterialTextbox pass_text;
        private Bunifu.Framework.UI.BunifuFlatButton login_button;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.LinkLabel linkLabel_sign;
        private System.Windows.Forms.Label label1;
    }
}