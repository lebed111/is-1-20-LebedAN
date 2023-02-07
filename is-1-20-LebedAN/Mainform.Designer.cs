
namespace is_1_20_LebedAN
{
    partial class Mainform
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.metroButton7 = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выбратьБдToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.краткийПодсчетПрибылиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.внестиИзмененияВТаблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(861, 198);
            this.dataGridView1.TabIndex = 7;
            // 
            // metroButton7
            // 
            this.metroButton7.Location = new System.Drawing.Point(638, 301);
            this.metroButton7.Name = "metroButton7";
            this.metroButton7.Size = new System.Drawing.Size(104, 32);
            this.metroButton7.TabIndex = 11;
            this.metroButton7.Text = "Смена акаунта";
            this.metroButton7.UseSelectable = true;
            this.metroButton7.Click += new System.EventHandler(this.metroButton7_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(748, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::is_1_20_LebedAN.Properties.Resources.дельфин;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(23, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(36, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(786, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Просмотр данных";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьБдToolStripMenuItem,
            this.краткийПодсчетПрибылиToolStripMenuItem,
            this.внестиИзмененияВТаблицыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(867, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выбратьБдToolStripMenuItem
            // 
            this.выбратьБдToolStripMenuItem.Name = "выбратьБдToolStripMenuItem";
            this.выбратьБдToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.выбратьБдToolStripMenuItem.Text = "Просмотреть таблицу";
            this.выбратьБдToolStripMenuItem.Click += new System.EventHandler(this.выбратьБдToolStripMenuItem_Click);
            // 
            // краткийПодсчетПрибылиToolStripMenuItem
            // 
            this.краткийПодсчетПрибылиToolStripMenuItem.Name = "краткийПодсчетПрибылиToolStripMenuItem";
            this.краткийПодсчетПрибылиToolStripMenuItem.Size = new System.Drawing.Size(164, 20);
            this.краткийПодсчетПрибылиToolStripMenuItem.Text = "краткий подсчет прибыли";
            this.краткийПодсчетПрибылиToolStripMenuItem.Click += new System.EventHandler(this.краткийПодсчетПрибылиToolStripMenuItem_Click);
            // 
            // внестиИзмененияВТаблицыToolStripMenuItem
            // 
            this.внестиИзмененияВТаблицыToolStripMenuItem.Name = "внестиИзмененияВТаблицыToolStripMenuItem";
            this.внестиИзмененияВТаблицыToolStripMenuItem.Size = new System.Drawing.Size(180, 20);
            this.внестиИзмененияВТаблицыToolStripMenuItem.Text = "Внести изменения в таблицы";
            this.внестиИзмененияВТаблицыToolStripMenuItem.Click += new System.EventHandler(this.внестиИзмененияВТаблицыToolStripMenuItem_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 339);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroButton7);
            this.Controls.Add(this.dataGridView1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mainform";
            this.Load += new System.EventHandler(this.Mainform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private MetroFramework.Controls.MetroButton metroButton7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выбратьБдToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem краткийПодсчетПрибылиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem внестиИзмененияВТаблицыToolStripMenuItem;
    }
}

