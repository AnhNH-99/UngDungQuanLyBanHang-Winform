namespace Quanlycuahang
{
    partial class F_LichSuGiaoDichNCC
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
            this.dtgvlichsugiaodichncc = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvlichsugiaodichncc)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvlichsugiaodichncc
            // 
            this.dtgvlichsugiaodichncc.AllowUserToAddRows = false;
            this.dtgvlichsugiaodichncc.AllowUserToDeleteRows = false;
            this.dtgvlichsugiaodichncc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvlichsugiaodichncc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvlichsugiaodichncc.Location = new System.Drawing.Point(12, 12);
            this.dtgvlichsugiaodichncc.Name = "dtgvlichsugiaodichncc";
            this.dtgvlichsugiaodichncc.ReadOnly = true;
            this.dtgvlichsugiaodichncc.Size = new System.Drawing.Size(776, 426);
            this.dtgvlichsugiaodichncc.TabIndex = 1;
            this.dtgvlichsugiaodichncc.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgvlichsugiaodichncc_CellMouseClick);
            // 
            // F_LichSuGiaoDichNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtgvlichsugiaodichncc);
            this.Name = "F_LichSuGiaoDichNCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách nhà cung cấp";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvlichsugiaodichncc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvlichsugiaodichncc;
    }
}