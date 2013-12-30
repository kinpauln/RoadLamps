namespace RoadLamps.Hosting
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusHosting = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusTcpListener = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnTCPListening = new System.Windows.Forms.Button();
            this.lvListeningResult = new System.Windows.Forms.ListView();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusHosting,
            this.toolStripStatusTcpListener});
            this.statusStrip1.Location = new System.Drawing.Point(0, 250);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(435, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusHosting
            // 
            this.toolStripStatusHosting.Name = "toolStripStatusHosting";
            this.toolStripStatusHosting.Size = new System.Drawing.Size(84, 17);
            this.toolStripStatusHosting.Text = "Hosting Status";
            // 
            // toolStripStatusTcpListener
            // 
            this.toolStripStatusTcpListener.Name = "toolStripStatusTcpListener";
            this.toolStripStatusTcpListener.Size = new System.Drawing.Size(73, 17);
            this.toolStripStatusTcpListener.Text = "TCP Listener";
            // 
            // btnTCPListening
            // 
            this.btnTCPListening.Location = new System.Drawing.Point(13, 1);
            this.btnTCPListening.Name = "btnTCPListening";
            this.btnTCPListening.Size = new System.Drawing.Size(147, 25);
            this.btnTCPListening.TabIndex = 1;
            this.btnTCPListening.Text = "Stop TCP Listening";
            this.btnTCPListening.UseVisualStyleBackColor = true;
            this.btnTCPListening.Click += new System.EventHandler(this.btnTCPListening_Click);
            // 
            // lvListeningResult
            // 
            this.lvListeningResult.Location = new System.Drawing.Point(13, 33);
            this.lvListeningResult.Name = "lvListeningResult";
            this.lvListeningResult.Size = new System.Drawing.Size(193, 203);
            this.lvListeningResult.TabIndex = 2;
            this.lvListeningResult.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 272);
            this.Controls.Add(this.lvListeningResult);
            this.Controls.Add(this.btnTCPListening);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusHosting;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTcpListener;
        private System.Windows.Forms.Button btnTCPListening;
        private System.Windows.Forms.ListView lvListeningResult;
    }
}

