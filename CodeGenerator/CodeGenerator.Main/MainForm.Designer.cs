namespace CodeGenerator.Main
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
            this.buttonShowCommandGeneratorForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonShowCommandGeneratorForm
            // 
            this.buttonShowCommandGeneratorForm.Location = new System.Drawing.Point(12, 12);
            this.buttonShowCommandGeneratorForm.Name = "buttonShowCommandGeneratorForm";
            this.buttonShowCommandGeneratorForm.Size = new System.Drawing.Size(144, 34);
            this.buttonShowCommandGeneratorForm.TabIndex = 0;
            this.buttonShowCommandGeneratorForm.Text = "Command Generator";
            this.buttonShowCommandGeneratorForm.UseVisualStyleBackColor = true;
            this.buttonShowCommandGeneratorForm.Click += new System.EventHandler(this.buttonShowCommandGeneratorForm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.buttonShowCommandGeneratorForm);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonShowCommandGeneratorForm;
    }
}