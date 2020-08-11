namespace Quanlycuahang
{
    partial class F_LichSuGiaoDich
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
            this.dtgvlichsugiaodich = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvlichsugiaodich)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvlichsugiaodich
            // 
            this.dtgvlichsugiaodich.AllowUserToAddRows = false;
            this.dtgvlichsugiaodich.AllowUserToDeleteRows = false;
            this.dtgvlichsugiaodich.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvlichsugiaodich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvlichsugiaodich.Location = new System.Drawing.Point(12, 12);
            this.dtgvlichsugiaodich.Name = "dtgvlichsugiaodich";
            this.dtgvlichsugiaodich.ReadOnly = true;
            this.dtgvlichsugiaodich.Size = new System.Drawing.Size(776, 426);
            this.dtgvlichsugiaodich.TabIndex = 0;
            this.dtgvlichsugiaodich.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgvlichsugiaodich_CellMouseClick);
            // 
            // F_LichSuGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtgvlichsugiaodich);
            this.Name = "F_LichSuGiaoDich";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách khách hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvlichsugiaodich)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvlichsugiaodich;
    }
}