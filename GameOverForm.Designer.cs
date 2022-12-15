
namespace GameSokobanFinal
{
    partial class GameOverForm
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
            this.buttonNextLevel = new System.Windows.Forms.Button();
            this.labelCountMove = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonNextLevel
            // 
            this.buttonNextLevel.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonNextLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNextLevel.Location = new System.Drawing.Point(85, 370);
            this.buttonNextLevel.Name = "buttonNextLevel";
            this.buttonNextLevel.Size = new System.Drawing.Size(416, 59);
            this.buttonNextLevel.TabIndex = 1;
            this.buttonNextLevel.Text = "Выбрать следующий уровень";
            this.buttonNextLevel.UseVisualStyleBackColor = false;
            this.buttonNextLevel.Click += new System.EventHandler(this.ButtonNextLevel_Click);
            // 
            // labelCountMove
            // 
            this.labelCountMove.AutoSize = true;
            this.labelCountMove.BackColor = System.Drawing.Color.Gold;
            this.labelCountMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountMove.Location = new System.Drawing.Point(80, 189);
            this.labelCountMove.Name = "labelCountMove";
            this.labelCountMove.Size = new System.Drawing.Size(421, 29);
            this.labelCountMove.TabIndex = 2;
            this.labelCountMove.Text = "Ты прошел уровень за 89 шагов!";
            // 
            // GameOverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameSokobanFinal.Properties.Resources.fonNG;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.labelCountMove);
            this.Controls.Add(this.buttonNextLevel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameOverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameOverForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonNextLevel;
        private System.Windows.Forms.Label labelCountMove;
    }
}