
namespace OptiQ
{
    partial class numerkas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(numerkas));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.grdt_kass50 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.kod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.shjowkeyboard2 = new OptiQ.shjowkeyboard();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdt_kass50)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // grdt_kass50
            // 
            this.grdt_kass50.AllowUserToAddRows = false;
            this.grdt_kass50.AllowUserToDeleteRows = false;
            this.grdt_kass50.AllowUserToResizeColumns = false;
            this.grdt_kass50.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grdt_kass50.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdt_kass50.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdt_kass50.BackgroundColor = System.Drawing.Color.White;
            this.grdt_kass50.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdt_kass50.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdt_kass50.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdt_kass50.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdt_kass50.ColumnHeadersHeight = 25;
            this.grdt_kass50.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdt_kass50.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kod,
            this.rz,
            this.kol,
            this.name});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdt_kass50.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdt_kass50.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdt_kass50.DoubleBuffered = true;
            this.grdt_kass50.Enabled = false;
            this.grdt_kass50.EnableHeadersVisualStyles = false;
            this.grdt_kass50.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
            this.grdt_kass50.HeaderForeColor = System.Drawing.Color.White;
            this.grdt_kass50.Location = new System.Drawing.Point(0, 0);
            this.grdt_kass50.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.grdt_kass50.MultiSelect = false;
            this.grdt_kass50.Name = "grdt_kass50";
            this.grdt_kass50.ReadOnly = true;
            this.grdt_kass50.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(127)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdt_kass50.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdt_kass50.RowHeadersVisible = false;
            this.grdt_kass50.RowHeadersWidth = 30;
            this.grdt_kass50.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grdt_kass50.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdt_kass50.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grdt_kass50.RowTemplate.DividerHeight = 1;
            this.grdt_kass50.RowTemplate.Height = 30;
            this.grdt_kass50.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grdt_kass50.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdt_kass50.Size = new System.Drawing.Size(180, 53);
            this.grdt_kass50.TabIndex = 2;
            this.grdt_kass50.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdt_kass50_CellContentClick);
            this.grdt_kass50.Click += new System.EventHandler(this.grdt_kass50_Click);
            // 
            // kod
            // 
            this.kod.FillWeight = 89.19894F;
            this.kod.HeaderText = "Код";
            this.kod.MinimumWidth = 6;
            this.kod.Name = "kod";
            this.kod.ReadOnly = true;
            this.kod.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.kod.Visible = false;
            // 
            // rz
            // 
            this.rz.HeaderText = "rz";
            this.rz.Name = "rz";
            this.rz.ReadOnly = true;
            this.rz.Visible = false;
            // 
            // kol
            // 
            this.kol.FillWeight = 58.30635F;
            this.kol.HeaderText = "Количество";
            this.kol.MinimumWidth = 6;
            this.kol.Name = "kol";
            this.kol.ReadOnly = true;
            this.kol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.kol.Visible = false;
            // 
            // name
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name.DefaultCellStyle = dataGridViewCellStyle3;
            this.name.FillWeight = 229.7631F;
            this.name.HeaderText = "Наименование";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.bunifuFlatButton1);
            this.panel1.Controls.Add(this.shjowkeyboard2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 72);
            this.panel1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.textBox1.Location = new System.Drawing.Point(0, 24);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 48);
            this.textBox1.TabIndex = 7;
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.bunifuFlatButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = null;
            this.bunifuFlatButton1.Iconimage_right = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage_right")));
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 7;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 30D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(150, 24);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(30, 48);
            this.bunifuFlatButton1.TabIndex = 13;
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuFlatButton1.MouseDown += new System.EventHandler(this.bunifuFlatButton1_MouseDown);
            this.bunifuFlatButton1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bunifuFlatButton1_MouseClick);
            // 
            // shjowkeyboard2
            // 
            this.shjowkeyboard2.BackColor = System.Drawing.Color.Transparent;
            this.shjowkeyboard2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shjowkeyboard2.Location = new System.Drawing.Point(145, 0);
            this.shjowkeyboard2.Margin = new System.Windows.Forms.Padding(0);
            this.shjowkeyboard2.Name = "shjowkeyboard2";
            this.shjowkeyboard2.Size = new System.Drawing.Size(35, 25);
            this.shjowkeyboard2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Комментарий";
            this.label2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label2_MouseClick);
            // 
            // numerkas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.grdt_kass50);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.Name = "numerkas";
            this.Size = new System.Drawing.Size(180, 125);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numerkas_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.grdt_kass50)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        public Bunifu.Framework.UI.BunifuCustomDataGrid grdt_kass50;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private shjowkeyboard shjowkeyboard2;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn kod;
        private System.Windows.Forms.DataGridViewTextBoxColumn rz;
        private System.Windows.Forms.DataGridViewTextBoxColumn kol;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
    }
}
