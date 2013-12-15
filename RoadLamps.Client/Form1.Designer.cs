namespace RoadLamps.Client
{
    partial class Form1
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
            this.btnCallAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCallAdd
            // 
            this.btnCallAdd.Location = new System.Drawing.Point(34, 25);
            this.btnCallAdd.Name = "btnCallAdd";
            this.btnCallAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCallAdd.TabIndex = 0;
            this.btnCallAdd.Text = "Call Add";
            this.btnCallAdd.UseVisualStyleBackColor = true;
            this.btnCallAdd.Click += new System.EventHandler(this.btnCallAdd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnCallAdd);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCallAdd;

    }
}

