
namespace GameSokobanFinal
{
    partial class LevelMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelMenu));
            this.ButtonLevel_1 = new System.Windows.Forms.Button();
            this.buttonLevel_2 = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.ButtonLevel_3 = new System.Windows.Forms.Button();
            this.ButtonLevel_4 = new System.Windows.Forms.Button();
            this.ButtonMyLevel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonLevel_1
            // 
            this.ButtonLevel_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonLevel_1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.ButtonLevel_1.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLevel_1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonLevel_1.Location = new System.Drawing.Point(181, 41);
            this.ButtonLevel_1.Name = "ButtonLevel_1";
            this.ButtonLevel_1.Size = new System.Drawing.Size(230, 64);
            this.ButtonLevel_1.TabIndex = 0;
            this.ButtonLevel_1.Text = "Уровень 1";
            this.ButtonLevel_1.UseVisualStyleBackColor = false;
            this.ButtonLevel_1.Click += new System.EventHandler(this.ButtonLevel_1_Click);
            // 
            // buttonLevel_2
            // 
            this.buttonLevel_2.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonLevel_2.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLevel_2.Location = new System.Drawing.Point(181, 139);
            this.buttonLevel_2.Name = "buttonLevel_2";
            this.buttonLevel_2.Size = new System.Drawing.Size(230, 64);
            this.buttonLevel_2.TabIndex = 1;
            this.buttonLevel_2.Text = "Уровень 2";
            this.buttonLevel_2.UseVisualStyleBackColor = false;
            this.buttonLevel_2.Click += new System.EventHandler(this.ButtonLevel_2_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonExit.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(410, 512);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(172, 42);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Назад";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit);
            // 
            // ButtonLevel_3
            // 
            this.ButtonLevel_3.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.ButtonLevel_3.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLevel_3.Location = new System.Drawing.Point(181, 237);
            this.ButtonLevel_3.Name = "ButtonLevel_3";
            this.ButtonLevel_3.Size = new System.Drawing.Size(230, 64);
            this.ButtonLevel_3.TabIndex = 3;
            this.ButtonLevel_3.Text = "Уровень 3";
            this.ButtonLevel_3.UseVisualStyleBackColor = false;
            this.ButtonLevel_3.Click += new System.EventHandler(this.ButtonLevel_3_Click);
            // 
            // ButtonLevel_4
            // 
            this.ButtonLevel_4.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.ButtonLevel_4.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLevel_4.Location = new System.Drawing.Point(181, 335);
            this.ButtonLevel_4.Name = "ButtonLevel_4";
            this.ButtonLevel_4.Size = new System.Drawing.Size(230, 64);
            this.ButtonLevel_4.TabIndex = 4;
            this.ButtonLevel_4.Text = "Уровень 4";
            this.ButtonLevel_4.UseVisualStyleBackColor = false;
            this.ButtonLevel_4.Click += new System.EventHandler(this.ButtonLevel_4_Click);
            // 
            // ButtonMyLevel
            // 
            this.ButtonMyLevel.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.ButtonMyLevel.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonMyLevel.Location = new System.Drawing.Point(181, 433);
            this.ButtonMyLevel.Name = "ButtonMyLevel";
            this.ButtonMyLevel.Size = new System.Drawing.Size(230, 64);
            this.ButtonMyLevel.TabIndex = 5;
            this.ButtonMyLevel.Text = "Мой уровень";
            this.ButtonMyLevel.UseVisualStyleBackColor = false;
            this.ButtonMyLevel.Click += new System.EventHandler(this.ButtonMyLevel_Click);
            // 
            // LevelMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.ButtonMyLevel);
            this.Controls.Add(this.ButtonLevel_4);
            this.Controls.Add(this.ButtonLevel_3);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonLevel_2);
            this.Controls.Add(this.ButtonLevel_1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LevelMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LevelMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonLevel_1;
        private System.Windows.Forms.Button buttonLevel_2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button ButtonLevel_3;
        private System.Windows.Forms.Button ButtonLevel_4;
        private System.Windows.Forms.Button ButtonMyLevel;
    }
}