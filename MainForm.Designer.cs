namespace ApiInvoker
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.facebookButton = new System.Windows.Forms.Button();
            this.locationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 56);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(549, 386);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // facebookButton
            // 
            this.facebookButton.Location = new System.Drawing.Point(13, 13);
            this.facebookButton.Name = "facebookButton";
            this.facebookButton.Size = new System.Drawing.Size(90, 23);
            this.facebookButton.TabIndex = 1;
            this.facebookButton.Text = "Who Am I?";
            this.facebookButton.UseVisualStyleBackColor = true;
            this.facebookButton.Click += new System.EventHandler(this.facebookButton_Click);
            // 
            // locationButton
            // 
            this.locationButton.Location = new System.Drawing.Point(134, 12);
            this.locationButton.Name = "locationButton";
            this.locationButton.Size = new System.Drawing.Size(119, 23);
            this.locationButton.TabIndex = 2;
            this.locationButton.Text = "Locate Me";
            this.locationButton.UseVisualStyleBackColor = true;
            this.locationButton.Click += new System.EventHandler(this.locationButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 457);
            this.Controls.Add(this.locationButton);
            this.Controls.Add(this.facebookButton);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button facebookButton;
        private System.Windows.Forms.Button locationButton;
    }
}

