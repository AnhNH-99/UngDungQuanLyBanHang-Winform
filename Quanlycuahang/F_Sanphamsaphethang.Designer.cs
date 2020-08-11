namespace Quanlycuahang
{
    partial class F_Sanphamsaphethang
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
            this.dtgvdsspshh = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvdsspshh)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvdsspshh
            // 
            this.dtgvdsspshh.AllowUserToAddRows = false;
            this.dtgvdsspshh.AllowUserToDeleteRows = false;
            this.dtgvdsspshh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvdsspshh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvdsspshh.Location = new System.Drawing.Point(10, 12);
            this.dtgvdsspshh.Name = "dtgvdsspshh";
            this.dtgvdsspshh.ReadOnly = true;
            this.dtgvdsspshh.Size = new System.Drawing.Size(761, 379);
            this.dtgvdsspshh.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Nhập hàng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // F_Sanphamsaphethang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 441);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtgvdsspshh);
            this.Name = "F_Sanphamsaphethang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách sản phẩm sắp hết hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvdsspshh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvdsspshh;
        private System.Windows.Forms.Button button1;
    }
}