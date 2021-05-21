
namespace OptiQ.TOVAR.DOBAV
{
    partial class Kotak
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kotak));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.create = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label9 = new System.Windows.Forms.Label();
            this.close = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowout = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.panel3.Controls.Add(this.create);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.close);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(540, 35);
            this.panel3.TabIndex = 8;
            // 
            // create
            // 
            this.create.Activecolor = System.Drawing.Color.Transparent;
            this.create.BackColor = System.Drawing.Color.Transparent;
            this.create.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.create.BorderRadius = 0;
            this.create.ButtonText = "Добавить";
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
            this.create.Location = new System.Drawing.Point(232, 2);
            this.create.Margin = new System.Windows.Forms.Padding(0);
            this.create.Name = "create";
            this.create.Normalcolor = System.Drawing.Color.Transparent;
            this.create.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.create.OnHoverTextColor = System.Drawing.Color.White;
            this.create.selected = false;
            this.create.Size = new System.Drawing.Size(151, 30);
            this.create.TabIndex = 15;
            this.create.Text = "Добавить";
            this.create.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.create.Textcolor = System.Drawing.Color.White;
            this.create.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 5);
            this.label9.Margin = new System.Windows.Forms.Padding(0, 15, 12, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 24);
            this.label9.TabIndex = 2;
            this.label9.Text = "Категории";
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
            this.close.Font = new System.Drawing.Font("Impact", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.close.Location = new System.Drawing.Point(505, 0);
            this.close.Margin = new System.Windows.Forms.Padding(0);
            this.close.Name = "close";
            this.close.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.close.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(71)))), ((int)(((byte)(164)))));
            this.close.OnHoverTextColor = System.Drawing.Color.White;
            this.close.selected = false;
            this.close.Size = new System.Drawing.Size(35, 35);
            this.close.TabIndex = 1;
            this.close.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close.Textcolor = System.Drawing.Color.White;
            this.close.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.panel1.Controls.Add(this.flowout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 505);
            this.panel1.TabIndex = 9;
            // 
            // flowout
            // 
            this.flowout.AutoScroll = true;
            this.flowout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
            this.flowout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowout.Location = new System.Drawing.Point(0, 0);
            this.flowout.Name = "flowout";
            this.flowout.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowout.Size = new System.Drawing.Size(540, 505);
            this.flowout.TabIndex = 0;
            // 
            // Kotak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 540);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Kotak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kotak";
            this.Load += new System.EventHandler(this.Kotak_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        public Bunifu.Framework.UI.BunifuFlatButton close;
        private System.Windows.Forms.FlowLayoutPanel flowout;
        private Bunifu.Framework.UI.BunifuFlatButton create;
    }
}