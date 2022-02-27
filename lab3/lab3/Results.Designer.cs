
namespace lab3
{
    partial class Results
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Agee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GNDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Crs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Avg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Com = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.BurlyWood;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NSL,
            this.Birth,
            this.Agee,
            this.GNDR,
            this.SPC,
            this.Crs,
            this.Grp,
            this.Avg,
            this.Adr,
            this.Com});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.Tan;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1304, 453);
            this.dataGridView1.TabIndex = 23;
            // 
            // NSL
            // 
            this.NSL.HeaderText = "ФИО";
            this.NSL.MinimumWidth = 6;
            this.NSL.Name = "NSL";
            this.NSL.ReadOnly = true;
            this.NSL.Width = 125;
            // 
            // Birth
            // 
            this.Birth.HeaderText = "Дата рождения";
            this.Birth.MinimumWidth = 6;
            this.Birth.Name = "Birth";
            this.Birth.ReadOnly = true;
            this.Birth.Width = 125;
            // 
            // Agee
            // 
            this.Agee.HeaderText = "Возраст";
            this.Agee.MinimumWidth = 6;
            this.Agee.Name = "Agee";
            this.Agee.ReadOnly = true;
            this.Agee.Width = 125;
            // 
            // GNDR
            // 
            this.GNDR.HeaderText = "Пол";
            this.GNDR.MinimumWidth = 6;
            this.GNDR.Name = "GNDR";
            this.GNDR.ReadOnly = true;
            this.GNDR.Width = 125;
            // 
            // SPC
            // 
            this.SPC.HeaderText = "Специальность";
            this.SPC.MinimumWidth = 6;
            this.SPC.Name = "SPC";
            this.SPC.ReadOnly = true;
            this.SPC.Width = 125;
            // 
            // Crs
            // 
            this.Crs.HeaderText = "Курс";
            this.Crs.MinimumWidth = 6;
            this.Crs.Name = "Crs";
            this.Crs.ReadOnly = true;
            this.Crs.Width = 125;
            // 
            // Grp
            // 
            this.Grp.HeaderText = "Группа";
            this.Grp.MinimumWidth = 6;
            this.Grp.Name = "Grp";
            this.Grp.ReadOnly = true;
            this.Grp.Width = 125;
            // 
            // Avg
            // 
            this.Avg.HeaderText = "Средний балл";
            this.Avg.MinimumWidth = 6;
            this.Avg.Name = "Avg";
            this.Avg.ReadOnly = true;
            this.Avg.Width = 125;
            // 
            // Adr
            // 
            this.Adr.HeaderText = "Адрес";
            this.Adr.MinimumWidth = 6;
            this.Adr.Name = "Adr";
            this.Adr.ReadOnly = true;
            this.Adr.Width = 125;
            // 
            // Com
            // 
            this.Com.HeaderText = "Компания";
            this.Com.MinimumWidth = 6;
            this.Com.Name = "Com";
            this.Com.ReadOnly = true;
            this.Com.Width = 125;
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 453);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Results";
            this.Text = "Результаты";
            this.Shown += new System.EventHandler(this.Results_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NSL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Agee;
        private System.Windows.Forms.DataGridViewTextBoxColumn GNDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Crs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Avg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Com;
    }
}

