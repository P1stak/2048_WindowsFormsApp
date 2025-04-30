namespace _2048_WindowsFormsApp
{
    partial class RulesWindow
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
            this.labelRules = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelRules
            // 
            this.labelRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRules.Location = new System.Drawing.Point(0, 0);
            this.labelRules.Name = "labelRules";
            this.labelRules.Size = new System.Drawing.Size(467, 347);
            this.labelRules.TabIndex = 0;
            this.labelRules.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RulesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 347);
            this.Controls.Add(this.labelRules);
            this.Name = "RulesWindow";
            this.Text = "RulesWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelRules;
    }
}