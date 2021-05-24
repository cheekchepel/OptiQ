
namespace OptiQ.magaz
{
    partial class usercell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usercell));
            this.nam = new System.Windows.Forms.Label();
            this.kas = new System.Windows.Forms.Label();
            this.edit = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.SuspendLayout();
            // 
            // nam
            // 
            this.nam.AutoSize = true;
            this.nam.Dock = System.Windows.Forms.DockStyle.Left;
            this.nam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
            this.nam.Location = new System.Drawing.Point(10, 0);
            this.nam.Margin = new System.Windows.Forms.Padding(0);
            this.nam.MaximumSize = new System.Drawing.Size(205, 30);
            this.nam.Name = "nam";
            this.nam.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.nam.Size = new System.Drawing.Size(203, 30);
            this.nam.TabIndex = 6;
            this.nam.Text = "Безналичные00000000";
            // 
            // kas
            // 
            this.kas.AutoSize = true;
            this.kas.Dock = System.Windows.Forms.DockStyle.Right;
            this.kas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
            this.kas.Location = new System.Drawing.Point(212, 0);
            this.kas.Margin = new System.Windows.Forms.Padding(0);
            this.kas.MaximumSize = new System.Drawing.Size(145, 30);
            this.kas.Name = "kas";
            this.kas.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.kas.Size = new System.Drawing.Size(143, 30);
            this.kas.TabIndex = 7;
            this.kas.Text = "Безналичные000";
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
            this.edit.Dock = System.Windows.Forms.DockStyle.Right;
            this.edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edit.Iconcolor = System.Drawing.Color.Transparent;
            this.edit.Iconimage = ((System.Drawing.Image)(resources.GetObject("edit.Iconimage")));
            this.edit.Iconimage_right = null;
            this.edit.Iconimage_right_Selected = null;
            this.edit.Iconimage_Selected = null;
            this.edit.IconMarginLeft = 0;
            this.edit.IconMarginRight = 0;
            this.edit.IconRightVisible = true;
            this.edit.IconRightZoom = 20D;
            this.edit.IconVisible = true;
            this.edit.IconZoom = 25D;
            this.edit.IsTab = false;
            this.edit.Location = new System.Drawing.Point(355, 0);
            this.edit.Margin = new System.Windows.Forms.Padding(0);
            this.edit.Name = "edit";
            this.edit.Normalcolor = System.Drawing.Color.Transparent;
            this.edit.OnHovercolor = System.Drawing.Color.Transparent;
            this.edit.OnHoverTextColor = System.Drawing.Color.White;
            this.edit.selected = false;
            this.edit.Size = new System.Drawing.Size(40, 40);
            this.edit.TabIndex = 8;
            this.edit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.edit.Textcolor = System.Drawing.Color.White;
            this.edit.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // usercell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.kas);
            this.Controls.Add(this.nam);
            this.Controls.Add(this.edit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Name = "usercell";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.Size = new System.Drawing.Size(400, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nam;
        private System.Windows.Forms.Label kas;
        private Bunifu.Framework.UI.BunifuFlatButton edit;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}
