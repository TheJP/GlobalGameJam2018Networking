namespace NetworkTesting
{
    partial class Server
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
            this.infoText = new System.Windows.Forms.TextBox();
            this.startLevel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.levelName = new System.Windows.Forms.TextBox();
            this.colour = new System.Windows.Forms.ComboBox();
            this.type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.stop = new System.Windows.Forms.Button();
            this.sendIngredient = new System.Windows.Forms.Button();
            this.sendChat = new System.Windows.Forms.Button();
            this.chat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // infoText
            // 
            this.infoText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoText.Location = new System.Drawing.Point(15, 128);
            this.infoText.Multiline = true;
            this.infoText.Name = "infoText";
            this.infoText.ReadOnly = true;
            this.infoText.Size = new System.Drawing.Size(446, 241);
            this.infoText.TabIndex = 0;
            // 
            // startLevel
            // 
            this.startLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startLevel.Location = new System.Drawing.Point(359, 12);
            this.startLevel.Name = "startLevel";
            this.startLevel.Size = new System.Drawing.Size(102, 23);
            this.startLevel.TabIndex = 1;
            this.startLevel.Text = "Start Level";
            this.startLevel.UseVisualStyleBackColor = true;
            this.startLevel.Click += new System.EventHandler(this.startLevel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Level Name";
            // 
            // levelName
            // 
            this.levelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.levelName.Location = new System.Drawing.Point(82, 14);
            this.levelName.Name = "levelName";
            this.levelName.Size = new System.Drawing.Size(271, 20);
            this.levelName.TabIndex = 3;
            // 
            // colour
            // 
            this.colour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colour.FormattingEnabled = true;
            this.colour.Items.AddRange(new object[] {
            "Green",
            "Blue",
            "Yellow",
            "Orange",
            "Red",
            "Violet",
            "Black"});
            this.colour.Location = new System.Drawing.Point(82, 43);
            this.colour.Name = "colour";
            this.colour.Size = new System.Drawing.Size(109, 21);
            this.colour.TabIndex = 4;
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
            this.type.Location = new System.Drawing.Point(197, 43);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(156, 21);
            this.type.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ingredient";
            // 
            // stop
            // 
            this.stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stop.Location = new System.Drawing.Point(359, 99);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(102, 23);
            this.stop.TabIndex = 1;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // sendIngredient
            // 
            this.sendIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendIngredient.Location = new System.Drawing.Point(359, 41);
            this.sendIngredient.Name = "sendIngredient";
            this.sendIngredient.Size = new System.Drawing.Size(102, 23);
            this.sendIngredient.TabIndex = 1;
            this.sendIngredient.Text = "Send Ingredient";
            this.sendIngredient.UseVisualStyleBackColor = true;
            this.sendIngredient.Click += new System.EventHandler(this.sendIngredient_Click);
            // 
            // sendChat
            // 
            this.sendChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendChat.Location = new System.Drawing.Point(359, 70);
            this.sendChat.Name = "sendChat";
            this.sendChat.Size = new System.Drawing.Size(102, 23);
            this.sendChat.TabIndex = 7;
            this.sendChat.Text = "Send Chat";
            this.sendChat.UseVisualStyleBackColor = true;
            this.sendChat.Click += new System.EventHandler(this.sendChat_Click);
            // 
            // chat
            // 
            this.chat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chat.Location = new System.Drawing.Point(82, 72);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(271, 20);
            this.chat.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chat";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 381);
            this.Controls.Add(this.sendChat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.type);
            this.Controls.Add(this.colour);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.levelName);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendIngredient);
            this.Controls.Add(this.startLevel);
            this.Controls.Add(this.infoText);
            this.MinimumSize = new System.Drawing.Size(429, 195);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox infoText;
        private System.Windows.Forms.Button startLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox levelName;
        private System.Windows.Forms.ComboBox colour;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button sendIngredient;
        private System.Windows.Forms.Button sendChat;
        private System.Windows.Forms.TextBox chat;
        private System.Windows.Forms.Label label3;
    }
}