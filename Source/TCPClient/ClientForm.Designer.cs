namespace TCPClient
{
    partial class TCPClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCPClient));
            this.PortTextbox = new System.Windows.Forms.TextBox();
            this.IPTextbox = new System.Windows.Forms.TextBox();
            this.PortLable = new System.Windows.Forms.Label();
            this.IPLabel = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectedButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.DisplayButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.CodeLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.CodeView = new System.Windows.Forms.TextBox();
            this.NameView = new System.Windows.Forms.TextBox();
            this.PhoneView = new System.Windows.Forms.TextBox();
            this.EmailView = new System.Windows.Forms.TextBox();
            this.DefaultButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.ord = new System.Windows.Forms.TextBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.GoTextbox = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PortTextbox
            // 
            this.PortTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortTextbox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.PortTextbox.Location = new System.Drawing.Point(225, 49);
            this.PortTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.PortTextbox.Name = "PortTextbox";
            this.PortTextbox.Size = new System.Drawing.Size(121, 27);
            this.PortTextbox.TabIndex = 2;
            this.PortTextbox.Text = "4004";
            this.PortTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PortTextbox.Click += new System.EventHandler(this.textBox2_Click);
            this.PortTextbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox2_MouseClick);
            this.PortTextbox.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // IPTextbox
            // 
            this.IPTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPTextbox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.IPTextbox.Location = new System.Drawing.Point(45, 49);
            this.IPTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.IPTextbox.Name = "IPTextbox";
            this.IPTextbox.Size = new System.Drawing.Size(121, 27);
            this.IPTextbox.TabIndex = 1;
            this.IPTextbox.Text = "127.1.1.2";
            this.IPTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IPTextbox.Click += new System.EventHandler(this.textBox1_Click);
            this.IPTextbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            this.IPTextbox.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // PortLable
            // 
            this.PortLable.AutoSize = true;
            this.PortLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortLable.Location = new System.Drawing.Point(265, 25);
            this.PortLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PortLable.Name = "PortLable";
            this.PortLable.Size = new System.Drawing.Size(40, 20);
            this.PortLable.TabIndex = 10;
            this.PortLable.Text = "Port";
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPLabel.Location = new System.Drawing.Point(56, 25);
            this.IPLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(91, 20);
            this.IPLabel.TabIndex = 9;
            this.IPLabel.Text = "IP Address";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectButton.Location = new System.Drawing.Point(463, 43);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(125, 34);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.Connect);
            // 
            // DisconnectedButton
            // 
            this.DisconnectedButton.Enabled = false;
            this.DisconnectedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectedButton.Location = new System.Drawing.Point(816, 42);
            this.DisconnectedButton.Margin = new System.Windows.Forms.Padding(4);
            this.DisconnectedButton.Name = "DisconnectedButton";
            this.DisconnectedButton.Size = new System.Drawing.Size(125, 36);
            this.DisconnectedButton.TabIndex = 15;
            this.DisconnectedButton.Text = "Disconnect";
            this.DisconnectedButton.UseVisualStyleBackColor = true;
            this.DisconnectedButton.Click += new System.EventHandler(this.Disconnect);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.SearchTextBox.Location = new System.Drawing.Point(715, 122);
            this.SearchTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(121, 27);
            this.SearchTextBox.TabIndex = 9;
            this.SearchTextBox.Text = "Nhập code";
            this.SearchTextBox.Enter += new System.EventHandler(this.SearchTextBox_Enter);
            this.SearchTextBox.Leave += new System.EventHandler(this.SearchTextBox_Leave);
            // 
            // DisplayButton
            // 
            this.DisplayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayButton.Location = new System.Drawing.Point(181, 119);
            this.DisplayButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DisplayButton.Name = "DisplayButton";
            this.DisplayButton.Size = new System.Drawing.Size(125, 34);
            this.DisplayButton.TabIndex = 4;
            this.DisplayButton.Text = "Display";
            this.DisplayButton.UseVisualStyleBackColor = true;
            this.DisplayButton.Click += new System.EventHandler(this.Display);
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(569, 119);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(4);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(125, 34);
            this.SearchButton.TabIndex = 10;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.Search);
            // 
            // CodeLabel
            // 
            this.CodeLabel.AutoSize = true;
            this.CodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeLabel.Location = new System.Drawing.Point(37, 222);
            this.CodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CodeLabel.Name = "CodeLabel";
            this.CodeLabel.Size = new System.Drawing.Size(48, 20);
            this.CodeLabel.TabIndex = 16;
            this.CodeLabel.Text = "Code";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(37, 316);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(53, 20);
            this.NameLabel.TabIndex = 17;
            this.NameLabel.Text = "Name";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneLabel.Location = new System.Drawing.Point(37, 415);
            this.PhoneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(56, 20);
            this.PhoneLabel.TabIndex = 18;
            this.PhoneLabel.Text = "Phone";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(37, 518);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(51, 20);
            this.EmailLabel.TabIndex = 19;
            this.EmailLabel.Text = "Email";
            // 
            // CodeView
            // 
            this.CodeView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CodeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeView.Location = new System.Drawing.Point(43, 246);
            this.CodeView.Margin = new System.Windows.Forms.Padding(4);
            this.CodeView.Name = "CodeView";
            this.CodeView.ReadOnly = true;
            this.CodeView.Size = new System.Drawing.Size(404, 27);
            this.CodeView.TabIndex = 11;
            // 
            // NameView
            // 
            this.NameView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NameView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameView.Location = new System.Drawing.Point(43, 340);
            this.NameView.Margin = new System.Windows.Forms.Padding(4);
            this.NameView.Name = "NameView";
            this.NameView.ReadOnly = true;
            this.NameView.Size = new System.Drawing.Size(404, 27);
            this.NameView.TabIndex = 12;
            // 
            // PhoneView
            // 
            this.PhoneView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PhoneView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneView.Location = new System.Drawing.Point(43, 439);
            this.PhoneView.Margin = new System.Windows.Forms.Padding(4);
            this.PhoneView.Name = "PhoneView";
            this.PhoneView.ReadOnly = true;
            this.PhoneView.Size = new System.Drawing.Size(404, 27);
            this.PhoneView.TabIndex = 13;
            // 
            // EmailView
            // 
            this.EmailView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EmailView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailView.Location = new System.Drawing.Point(43, 542);
            this.EmailView.Margin = new System.Windows.Forms.Padding(4);
            this.EmailView.Name = "EmailView";
            this.EmailView.ReadOnly = true;
            this.EmailView.Size = new System.Drawing.Size(404, 27);
            this.EmailView.TabIndex = 14;
            // 
            // DefaultButton
            // 
            this.DefaultButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultButton.Location = new System.Drawing.Point(640, 42);
            this.DefaultButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(125, 36);
            this.DefaultButton.TabIndex = 3;
            this.DefaultButton.Text = "Default";
            this.DefaultButton.UseVisualStyleBackColor = true;
            this.DefaultButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // NextButton
            // 
            this.NextButton.Enabled = false;
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.Location = new System.Drawing.Point(323, 119);
            this.NextButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(125, 34);
            this.NextButton.TabIndex = 7;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.Next_Click);
            // 
            // BackButton
            // 
            this.BackButton.Enabled = false;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(43, 119);
            this.BackButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(125, 34);
            this.BackButton.TabIndex = 8;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.Back_Click);
            // 
            // ord
            // 
            this.ord.BackColor = System.Drawing.SystemColors.Control;
            this.ord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ord.Enabled = false;
            this.ord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ord.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ord.Location = new System.Drawing.Point(181, 94);
            this.ord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ord.Name = "ord";
            this.ord.ReadOnly = true;
            this.ord.Size = new System.Drawing.Size(125, 20);
            this.ord.TabIndex = 31;
            this.ord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ord.Visible = false;
            // 
            // GoButton
            // 
            this.GoButton.Enabled = false;
            this.GoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoButton.Location = new System.Drawing.Point(111, 174);
            this.GoButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(125, 34);
            this.GoButton.TabIndex = 6;
            this.GoButton.Text = "Go";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // GoTextbox
            // 
            this.GoTextbox.Enabled = false;
            this.GoTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoTextbox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.GoTextbox.Location = new System.Drawing.Point(253, 176);
            this.GoTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GoTextbox.Name = "GoTextbox";
            this.GoTextbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GoTextbox.Size = new System.Drawing.Size(121, 27);
            this.GoTextbox.TabIndex = 5;
            this.GoTextbox.Text = "Nhập vị trí";
            this.GoTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.GoTextbox.Enter += new System.EventHandler(this.GoTextbox_Enter);
            this.GoTextbox.Leave += new System.EventHandler(this.GoTextbox_Leave);
            // 
            // pictureBox
            // 
            this.pictureBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.ErrorImage")));
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(541, 201);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 369);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 22;
            this.pictureBox.TabStop = false;
            // 
            // TCPClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 615);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.GoTextbox);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.ord);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.DefaultButton);
            this.Controls.Add(this.EmailView);
            this.Controls.Add(this.PhoneView);
            this.Controls.Add(this.NameView);
            this.Controls.Add(this.CodeView);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.CodeLabel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.DisplayButton);
            this.Controls.Add(this.DisconnectedButton);
            this.Controls.Add(this.PortTextbox);
            this.Controls.Add(this.IPTextbox);
            this.Controls.Add(this.PortLable);
            this.Controls.Add(this.IPLabel);
            this.Controls.Add(this.ConnectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TCPClient";
            this.Text = "TCPClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TCPClient_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox PortTextbox;
        private System.Windows.Forms.TextBox IPTextbox;
        private System.Windows.Forms.Label PortLable;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectedButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button DisplayButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label CodeLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox CodeView;
        private System.Windows.Forms.TextBox NameView;
        private System.Windows.Forms.TextBox PhoneView;
        private System.Windows.Forms.TextBox EmailView;
		private System.Windows.Forms.Button DefaultButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.TextBox ord;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.TextBox GoTextbox;
    }
}

