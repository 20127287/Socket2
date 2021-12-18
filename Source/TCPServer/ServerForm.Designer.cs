namespace Project1
{
    partial class TCPServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCPServer));
            this.StartButton = new System.Windows.Forms.Button();
            this.IPLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.IPTextbox = new System.Windows.Forms.TextBox();
            this.PortTextbox = new System.Windows.Forms.TextBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.DefaultButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(35, 112);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(88, 36);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPLabel.Location = new System.Drawing.Point(47, 27);
            this.IPLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(91, 20);
            this.IPLabel.TabIndex = 5;
            this.IPLabel.Text = "IP Address";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortLabel.Location = new System.Drawing.Point(263, 27);
            this.PortLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(40, 20);
            this.PortLabel.TabIndex = 6;
            this.PortLabel.Text = "Port";
            // 
            // IPTextbox
            // 
            this.IPTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPTextbox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.IPTextbox.Location = new System.Drawing.Point(35, 52);
            this.IPTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IPTextbox.Name = "IPTextbox";
            this.IPTextbox.Size = new System.Drawing.Size(121, 27);
            this.IPTextbox.TabIndex = 1;
            this.IPTextbox.TabStop = false;
            this.IPTextbox.Text = "127.1.1.2";
            this.IPTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IPTextbox.Click += new System.EventHandler(this.textBox1_Click);
            this.IPTextbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            this.IPTextbox.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // PortTextbox
            // 
            this.PortTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortTextbox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.PortTextbox.Location = new System.Drawing.Point(223, 52);
            this.PortTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PortTextbox.Name = "PortTextbox";
            this.PortTextbox.Size = new System.Drawing.Size(121, 27);
            this.PortTextbox.TabIndex = 2;
            this.PortTextbox.Text = "4004";
            this.PortTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PortTextbox.Click += new System.EventHandler(this.textBox2_Click);
            this.PortTextbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox2_MouseClick);
            this.PortTextbox.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopButton.Location = new System.Drawing.Point(257, 112);
            this.StopButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(88, 36);
            this.StopButton.TabIndex = 4;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // DefaultButton
            // 
            this.DefaultButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultButton.Location = new System.Drawing.Point(145, 112);
            this.DefaultButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(88, 36);
            this.DefaultButton.TabIndex = 3;
            this.DefaultButton.Text = "Default";
            this.DefaultButton.UseVisualStyleBackColor = true;
            this.DefaultButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // TCPServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 178);
            this.Controls.Add(this.DefaultButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.PortTextbox);
            this.Controls.Add(this.IPTextbox);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.IPLabel);
            this.Controls.Add(this.StartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TCPServer";
            this.Text = "TCPSever";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TCPServer_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox IPTextbox;
        private System.Windows.Forms.TextBox PortTextbox;
        private System.Windows.Forms.Button StopButton;
		private System.Windows.Forms.Button DefaultButton;
	}
}

