
namespace is_1_20_LebedAN
{
    partial class Changes
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(674, 208);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(0, 41);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(127, 31);
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "Обновить";
            this.metroButton1.UseSelectable = true;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(562, 41);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(100, 31);
            this.metroButton2.TabIndex = 2;
            this.metroButton2.Text = "Назад";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Изменения";
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(145, 41);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(126, 31);
            this.metroButton4.TabIndex = 5;
            this.metroButton4.Text = "Добавить бд";
            this.metroButton4.UseSelectable = true;
            // 
            // Changes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 299);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Changes";
            this.Load += new System.EventHandler(this.Changes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton metroButton4;
    }
}