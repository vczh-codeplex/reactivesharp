namespace DemoClickCounter
{
    partial class CounterForm
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
            this.buttonClickMe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonClickMe
            // 
            this.buttonClickMe.Location = new System.Drawing.Point(12, 12);
            this.buttonClickMe.Name = "buttonClickMe";
            this.buttonClickMe.Size = new System.Drawing.Size(292, 84);
            this.buttonClickMe.TabIndex = 0;
            this.buttonClickMe.Text = "Click Me";
            this.buttonClickMe.UseVisualStyleBackColor = true;
            // 
            // CounterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 108);
            this.Controls.Add(this.buttonClickMe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CounterForm";
            this.Text = "Click Counter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClickMe;
    }
}

