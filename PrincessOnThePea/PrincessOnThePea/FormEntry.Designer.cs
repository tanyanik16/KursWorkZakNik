
namespace PrincessOnThePea
{
    partial class FormEntry
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
            this.buttonEntry = new System.Windows.Forms.Button();
            this.buttonReg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEntry
            // 
            this.buttonEntry.Location = new System.Drawing.Point(27, 50);
            this.buttonEntry.Name = "buttonEntry";
            this.buttonEntry.Size = new System.Drawing.Size(110, 33);
            this.buttonEntry.TabIndex = 0;
            this.buttonEntry.Text = "Войти";
            this.buttonEntry.UseVisualStyleBackColor = true;
            this.buttonEntry.Click += new System.EventHandler(this.buttonEntry_Click);
            // 
            // buttonReg
            // 
            this.buttonReg.Location = new System.Drawing.Point(175, 50);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(161, 33);
            this.buttonReg.TabIndex = 1;
            this.buttonReg.Text = "Зарегистрироваться";
            this.buttonReg.UseVisualStyleBackColor = true;
            this.buttonReg.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // FormEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 127);
            this.Controls.Add(this.buttonReg);
            this.Controls.Add(this.buttonEntry);
            this.Name = "FormEntry";
            this.Text = "FormEntry";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEntry;
        private System.Windows.Forms.Button buttonReg;
    }
}