namespace _2048_WindowsFormsApp
{
    partial class MainForm
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
            this.Score = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_button_Restart = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_button_Rules = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_button_Results = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_button_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.BestScoreLabel = new System.Windows.Forms.Label();
            this.bestScoreL = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Location = new System.Drawing.Point(244, 9);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(33, 13);
            this.Score.TabIndex = 0;
            this.Score.Text = "Счет:";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(283, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(13, 13);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(319, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip
            // 
            this.menuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_button_Restart,
            this.menu_button_Rules,
            this.menu_button_Results,
            this.menu_button_Exit});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(53, 20);
            this.menuStrip.Text = "Меню";
            // 
            // menu_button_Restart
            // 
            this.menu_button_Restart.Name = "menu_button_Restart";
            this.menu_button_Restart.Size = new System.Drawing.Size(154, 22);
            this.menu_button_Restart.Text = "Перезагрузить";
            this.menu_button_Restart.Click += new System.EventHandler(this.menu_button_Restart_Click);
            // 
            // menu_button_Rules
            // 
            this.menu_button_Rules.Name = "menu_button_Rules";
            this.menu_button_Rules.Size = new System.Drawing.Size(154, 22);
            this.menu_button_Rules.Text = "Правила";
            this.menu_button_Rules.Click += new System.EventHandler(this.menu_button_Rules_Click);
            // 
            // menu_button_Results
            // 
            this.menu_button_Results.Name = "menu_button_Results";
            this.menu_button_Results.Size = new System.Drawing.Size(154, 22);
            this.menu_button_Results.Text = "Результаты";
            this.menu_button_Results.Click += new System.EventHandler(this.menu_button_Results_Click);
            // 
            // menu_button_Exit
            // 
            this.menu_button_Exit.Name = "menu_button_Exit";
            this.menu_button_Exit.Size = new System.Drawing.Size(154, 22);
            this.menu_button_Exit.Text = "Выход";
            this.menu_button_Exit.Click += new System.EventHandler(this.menu_button_Exit_Click);
            // 
            // BestScoreLabel
            // 
            this.BestScoreLabel.AutoSize = true;
            this.BestScoreLabel.Location = new System.Drawing.Point(283, 34);
            this.BestScoreLabel.Name = "BestScoreLabel";
            this.BestScoreLabel.Size = new System.Drawing.Size(13, 13);
            this.BestScoreLabel.TabIndex = 4;
            this.BestScoreLabel.Text = "0";
            // 
            // bestScoreL
            // 
            this.bestScoreL.AutoSize = true;
            this.bestScoreL.Location = new System.Drawing.Point(175, 34);
            this.bestScoreL.Name = "bestScoreL";
            this.bestScoreL.Size = new System.Drawing.Size(102, 13);
            this.bestScoreL.TabIndex = 5;
            this.bestScoreL.Text = "Лучший результат:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 382);
            this.Controls.Add(this.bestScoreL);
            this.Controls.Add(this.BestScoreLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "2048";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menu_button_Restart;
        private System.Windows.Forms.ToolStripMenuItem menu_button_Rules;
        private System.Windows.Forms.ToolStripMenuItem menu_button_Exit;
        private System.Windows.Forms.ToolStripMenuItem menu_button_Results;
        private System.Windows.Forms.Label BestScore;
        private System.Windows.Forms.Label BestScoreLabel;
        private System.Windows.Forms.Label bestScoreL;
    }
}

