
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.grdt_kass50 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.kod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cenaco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vsekol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cenakonco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdt_kass50)).BeginInit();
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdt_kass50.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdt_kass50.ColumnHeadersHeight = 25;
            this.grdt_kass50.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdt_kass50.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kod,
            this.name,
            this.price,
            this.cenaco,
            this.kol,
            this.vsekol,
            this.cenakonco,
            this.a1,
            this.a2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdt_kass50.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(127)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdt_kass50.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdt_kass50.RowHeadersVisible = false;
            this.grdt_kass50.RowHeadersWidth = 30;
            this.grdt_kass50.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grdt_kass50.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdt_kass50.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grdt_kass50.RowTemplate.DividerHeight = 1;
            this.grdt_kass50.RowTemplate.Height = 30;
            this.grdt_kass50.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grdt_kass50.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdt_kass50.Size = new System.Drawing.Size(160, 110);
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
            // name
            // 
            this.name.FillWeight = 229.7631F;
            this.name.HeaderText = "Наименование";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // price
            // 
            this.price.FillWeight = 41.70567F;
            this.price.HeaderText = "Цена";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.price.Visible = false;
            // 
            // cenaco
            // 
            this.cenaco.HeaderText = "Ценаприхода";
            this.cenaco.MinimumWidth = 6;
            this.cenaco.Name = "cenaco";
            this.cenaco.ReadOnly = true;
            this.cenaco.Visible = false;
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
            // vsekol
            // 
            this.vsekol.FillWeight = 81.02573F;
            this.vsekol.HeaderText = "Сумма";
            this.vsekol.MinimumWidth = 6;
            this.vsekol.Name = "vsekol";
            this.vsekol.ReadOnly = true;
            this.vsekol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.vsekol.Visible = false;
            // 
            // cenakonco
            // 
            this.cenakonco.HeaderText = "cenakonco";
            this.cenakonco.MinimumWidth = 6;
            this.cenakonco.Name = "cenakonco";
            this.cenakonco.ReadOnly = true;
            this.cenakonco.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cenakonco.Visible = false;
            // 
            // a1
            // 
            this.a1.HeaderText = "a1";
            this.a1.Name = "a1";
            this.a1.ReadOnly = true;
            this.a1.Visible = false;
            // 
            // a2
            // 
            this.a2.HeaderText = "a2";
            this.a2.Name = "a2";
            this.a2.ReadOnly = true;
            this.a2.Visible = false;
            // 
            // numerkas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.grdt_kass50);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "numerkas";
            this.Size = new System.Drawing.Size(160, 110);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numerkas_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.grdt_kass50)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        public Bunifu.Framework.UI.BunifuCustomDataGrid grdt_kass50;
        private System.Windows.Forms.DataGridViewTextBoxColumn kod;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn cenaco;
        private System.Windows.Forms.DataGridViewTextBoxColumn kol;
        private System.Windows.Forms.DataGridViewTextBoxColumn vsekol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cenakonco;
        private System.Windows.Forms.DataGridViewTextBoxColumn a1;
        private System.Windows.Forms.DataGridViewTextBoxColumn a2;
        public System.Windows.Forms.DataGridViewTextBoxColumn name;
    }
}
