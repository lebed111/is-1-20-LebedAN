
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
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.metroButton7 = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.White;
            this.metroButton1.Location = new System.Drawing.Point(10, 152);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(128, 38);
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "изменить";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(10, 205);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(128, 38);
            this.metroButton2.TabIndex = 5;
            this.metroButton2.Text = "закрыть бд";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(10, 97);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(128, 38);
            this.metroButton3.TabIndex = 6;
            this.metroButton3.Text = "Выбрать бд ";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(162, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(722, 198);
            this.dataGridView1.TabIndex = 7;
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(10, 258);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(128, 37);
            this.metroButton4.TabIndex = 8;
            this.metroButton4.Text = "Выход";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Location = new System.Drawing.Point(306, 36);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(128, 43);
            this.metroButton5.TabIndex = 9;
            this.metroButton5.Text = "графики";
            this.metroButton5.UseSelectable = true;
            // 
            // metroButton6
            // 
            this.metroButton6.Location = new System.Drawing.Point(162, 36);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(128, 43);
            this.metroButton6.TabIndex = 10;
            this.metroButton6.Text = "финансы";
            this.metroButton6.UseSelectable = true;
            this.metroButton6.Click += new System.EventHandler(this.metroButton6_Click);
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
            this.pictureBox1.Location = new System.Drawing.Point(10, 36);
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
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 339);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroButton7);
            this.Controls.Add(this.metroButton6);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Name = "Mainform";
            this.Load += new System.EventHandler(this.Mainform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroButton metroButton7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

