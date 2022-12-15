
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
            this.labelRecords = new System.Windows.Forms.Label();
            this.buttonExitRecords = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelRecords
            // 
            this.labelRecords.AutoSize = true;
            this.labelRecords.BackColor = System.Drawing.Color.White;
            this.labelRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRecords.Location = new System.Drawing.Point(146, 221);
            this.labelRecords.Name = "labelRecords";
            this.labelRecords.Size = new System.Drawing.Size(289, 64);
            this.labelRecords.TabIndex = 0;
            this.labelRecords.Text = "Топ (кол-во шагов):\r\n1. 1000\r\n";
            // 
            // buttonExitRecords
            // 
            this.buttonExitRecords.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonExitRecords.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExitRecords.Location = new System.Drawing.Point(376, 528);
            this.buttonExitRecords.Name = "buttonExitRecords";
            this.buttonExitRecords.Size = new System.Drawing.Size(212, 60);
            this.buttonExitRecords.TabIndex = 3;
            this.buttonExitRecords.Text = "Назад";
            this.buttonExitRecords.UseVisualStyleBackColor = false;
            this.buttonExitRecords.Click += new System.EventHandler(this.buttonExitRecords_Click);
            // 
            // RecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameSokobanFinal.Properties.Resources.fonNG;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.buttonExitRecords);
            this.Controls.Add(this.labelRecords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecordsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRecords;
        private System.Windows.Forms.Button buttonExitRecords;
    }
}