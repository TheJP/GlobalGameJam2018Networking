namespace NetworkTesting
{
    partial class Client
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
            this.sendMM = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.moneyName = new System.Windows.Forms.TextBox();
            this.goldValue = new System.Windows.Forms.TextBox();
            this.type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gameOver = new System.Windows.Forms.Button();
            this.success = new System.Windows.Forms.CheckBox();
            this.disconnect = new System.Windows.Forms.Button();
            this.send = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.infoText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sendMM
            // 
            this.sendMM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendMM.Location = new System.Drawing.Point(382, 12);
            this.sendMM.Name = "sendMM";
            this.sendMM.Size = new System.Drawing.Size(139, 51);
            this.sendMM.TabIndex = 0;
            this.sendMM.Text = "Send Money Maker";
            this.sendMM.UseVisualStyleBackColor = true;
            this.sendMM.Click += new System.EventHandler(this.sendMM_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(190, 17);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(59, 13);
            this.label55.TabIndex = 2;
            this.label55.Text = "Gold Value";
            // 
            // moneyName
            // 
            this.moneyName.Location = new System.Drawing.Point(68, 14);
            this.moneyName.Name = "moneyName";
            this.moneyName.Size = new System.Drawing.Size(116, 20);
            this.moneyName.TabIndex = 3;
            // 
            // goldValue
            // 
            this.goldValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goldValue.Location = new System.Drawing.Point(255, 14);
            this.goldValue.Name = "goldValue";
            this.goldValue.Size = new System.Drawing.Size(121, 20);
            this.goldValue.TabIndex = 4;
            // 
            // type
            // 
            this.type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type.FormattingEnabled = true;
            this.type.Items.AddRange(new object[] {
            "Powder",
            "Herb",
            "Liquid",
            "Steam",
            "Processed"});
            this.type.Location = new System.Drawing.Point(68, 42);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(308, 21);
            this.type.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // gameOver
            // 
            this.gameOver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gameOver.Location = new System.Drawing.Point(382, 69);
            this.gameOver.Name = "gameOver";
            this.gameOver.Size = new System.Drawing.Size(139, 23);
            this.gameOver.TabIndex = 6;
            this.gameOver.Text = "Game Over";
            this.gameOver.UseVisualStyleBackColor = true;
            this.gameOver.Click += new System.EventHandler(this.gameOver_Click);
            // 
            // success
            // 
            this.success.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.success.AutoSize = true;
            this.success.Location = new System.Drawing.Point(309, 73);
            this.success.Name = "success";
            this.success.Size = new System.Drawing.Size(67, 17);
            this.success.TabIndex = 7;
            this.success.Text = "Success";
            this.success.UseVisualStyleBackColor = true;
            // 
            // disconnect
            // 
            this.disconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.disconnect.Location = new System.Drawing.Point(382, 127);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(139, 23);
            this.disconnect.TabIndex = 8;
            this.disconnect.Text = "Disconnect";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // send
            // 
            this.send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.send.Location = new System.Drawing.Point(382, 98);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(139, 23);
            this.send.TabIndex = 9;
            this.send.Text = "Send Message";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // message
            // 
            this.message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.message.Location = new System.Drawing.Point(68, 100);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(308, 20);
            this.message.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Message";
            // 
            // infoText
            // 
            this.infoText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoText.Location = new System.Drawing.Point(12, 156);
            this.infoText.Multiline = true;
            this.infoText.Name = "infoText";
            this.infoText.Size = new System.Drawing.Size(509, 129);
            this.infoText.TabIndex = 12;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 297);
            this.Controls.Add(this.infoText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.message);
            this.Controls.Add(this.send);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.success);
            this.Controls.Add(this.gameOver);
            this.Controls.Add(this.type);
            this.Controls.Add(this.goldValue);
            this.Controls.Add(this.moneyName);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendMM);
            this.MinimumSize = new System.Drawing.Size(549, 336);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendMM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox moneyName;
        private System.Windows.Forms.TextBox goldValue;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button gameOver;
        private System.Windows.Forms.CheckBox success;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox infoText;
    }
}