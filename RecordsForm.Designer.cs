
namespace GameSokobanFinal
{
    partial class RecordsForm
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
            this.ButtonExitRecords = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ButtonDeleteRecords = new System.Windows.Forms.Button();
            this.textBoxDelete = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonExitRecords
            // 
            this.ButtonExitRecords.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.ButtonExitRecords.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonExitRecords.Location = new System.Drawing.Point(376, 528);
            this.ButtonExitRecords.Name = "ButtonExitRecords";
            this.ButtonExitRecords.Size = new System.Drawing.Size(212, 60);
            this.ButtonExitRecords.TabIndex = 3;
            this.ButtonExitRecords.Text = "Назад";
            this.ButtonExitRecords.UseVisualStyleBackColor = false;
            this.ButtonExitRecords.Click += new System.EventHandler(this.ButtonExitRecords_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(103, 129);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(427, 326);
            this.dataGridView1.TabIndex = 4;
            // 
            // ButtonDeleteRecords
            // 
            this.ButtonDeleteRecords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ButtonDeleteRecords.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDeleteRecords.ForeColor = System.Drawing.SystemColors.Control;
            this.ButtonDeleteRecords.Location = new System.Drawing.Point(3, 528);
            this.ButtonDeleteRecords.Name = "ButtonDeleteRecords";
            this.ButtonDeleteRecords.Size = new System.Drawing.Size(212, 60);
            this.ButtonDeleteRecords.TabIndex = 5;
            this.ButtonDeleteRecords.Text = "Удалить все \r\nрекорды\r\n";
            this.ButtonDeleteRecords.UseVisualStyleBackColor = false;
            this.ButtonDeleteRecords.Click += new System.EventHandler(this.ButtonDeleteRecords_Click);
            // 
            // textBoxDelete
            // 
            this.textBoxDelete.BackColor = System.Drawing.Color.White;
            this.textBoxDelete.Location = new System.Drawing.Point(210, 279);
            this.textBoxDelete.Name = "textBoxDelete";
            this.textBoxDelete.Size = new System.Drawing.Size(212, 22);
            this.textBoxDelete.TabIndex = 6;
            this.textBoxDelete.Text = "Введите пароль:";
            this.textBoxDelete.Visible = false;
            this.textBoxDelete.TextChanged += new System.EventHandler(this.TextBoxDelete_TextChanged);
            this.textBoxDelete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PressTextBox);
            // 
            // RecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameSokobanFinal.Properties.Resources.fonNG;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.textBoxDelete);
            this.Controls.Add(this.ButtonDeleteRecords);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ButtonExitRecords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecordsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonExitRecords;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ButtonDeleteRecords;
        private System.Windows.Forms.TextBox textBoxDelete;
    }
}