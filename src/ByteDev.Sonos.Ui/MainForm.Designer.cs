namespace ByteDev.Sonos.Ui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.shutUpButton = new System.Windows.Forms.Button();
            this.ipAddressTextBox = new System.Windows.Forms.TextBox();
            this.intervalTextBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speakerIpLabel = new System.Windows.Forms.Label();
            this.intervalSecondsLabel = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.setVolButton = new System.Windows.Forms.Button();
            this.volTextBox = new System.Windows.Forms.TextBox();
            this.scanButton = new System.Windows.Forms.Button();
            this.getDeviceButton = new System.Windows.Forms.Button();
            this.getVolumeButton = new System.Windows.Forms.Button();
            this.getQueueButton = new System.Windows.Forms.Button();
            this.removeQueueTrackButton = new System.Windows.Forms.Button();
            this.trackNumberTextBox = new System.Windows.Forms.TextBox();
            this.fadeButton = new System.Windows.Forms.Button();
            this.fadeTargetVolumeTextBox = new System.Windows.Forms.TextBox();
            this.rebootButton = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // shutUpButton
            // 
            this.shutUpButton.Location = new System.Drawing.Point(237, 470);
            this.shutUpButton.Name = "shutUpButton";
            this.shutUpButton.Size = new System.Drawing.Size(75, 23);
            this.shutUpButton.TabIndex = 0;
            this.shutUpButton.Text = "Shut Up";
            this.shutUpButton.UseVisualStyleBackColor = true;
            this.shutUpButton.Click += new System.EventHandler(this.shutUpButton_Click);
            // 
            // ipAddressTextBox
            // 
            this.ipAddressTextBox.Location = new System.Drawing.Point(80, 12);
            this.ipAddressTextBox.Name = "ipAddressTextBox";
            this.ipAddressTextBox.Size = new System.Drawing.Size(120, 20);
            this.ipAddressTextBox.TabIndex = 1;
            this.ipAddressTextBox.Text = "192.168.1.105";
            // 
            // intervalTextBox
            // 
            this.intervalTextBox.Location = new System.Drawing.Point(111, 470);
            this.intervalTextBox.Name = "intervalTextBox";
            this.intervalTextBox.Size = new System.Drawing.Size(121, 20);
            this.intervalTextBox.TabIndex = 2;
            this.intervalTextBox.Text = "120";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(318, 470);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 499);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(610, 22);
            this.statusStrip.TabIndex = 4;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // speakerIpLabel
            // 
            this.speakerIpLabel.AutoSize = true;
            this.speakerIpLabel.Location = new System.Drawing.Point(11, 15);
            this.speakerIpLabel.Name = "speakerIpLabel";
            this.speakerIpLabel.Size = new System.Drawing.Size(63, 13);
            this.speakerIpLabel.TabIndex = 5;
            this.speakerIpLabel.Text = "Speaker IP:";
            // 
            // intervalSecondsLabel
            // 
            this.intervalSecondsLabel.AutoSize = true;
            this.intervalSecondsLabel.Location = new System.Drawing.Point(9, 473);
            this.intervalSecondsLabel.Name = "intervalSecondsLabel";
            this.intervalSecondsLabel.Size = new System.Drawing.Size(96, 13);
            this.intervalSecondsLabel.TabIndex = 6;
            this.intervalSecondsLabel.Text = "Interval (Seconds):";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(0, 44);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTextBox.Size = new System.Drawing.Size(612, 315);
            this.outputTextBox.TabIndex = 7;
            this.outputTextBox.WordWrap = false;
            // 
            // setVolButton
            // 
            this.setVolButton.Location = new System.Drawing.Point(86, 395);
            this.setVolButton.Margin = new System.Windows.Forms.Padding(2);
            this.setVolButton.Name = "setVolButton";
            this.setVolButton.Size = new System.Drawing.Size(75, 23);
            this.setVolButton.TabIndex = 8;
            this.setVolButton.Text = "Set Volume";
            this.setVolButton.UseVisualStyleBackColor = true;
            this.setVolButton.Click += new System.EventHandler(this.setVolButton_Click);
            // 
            // volTextBox
            // 
            this.volTextBox.Location = new System.Drawing.Point(7, 398);
            this.volTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.volTextBox.Name = "volTextBox";
            this.volTextBox.Size = new System.Drawing.Size(76, 20);
            this.volTextBox.TabIndex = 9;
            this.volTextBox.Text = "0";
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(523, 10);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(75, 23);
            this.scanButton.TabIndex = 10;
            this.scanButton.Text = "Scan";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // getDeviceButton
            // 
            this.getDeviceButton.Location = new System.Drawing.Point(206, 10);
            this.getDeviceButton.Name = "getDeviceButton";
            this.getDeviceButton.Size = new System.Drawing.Size(75, 23);
            this.getDeviceButton.TabIndex = 11;
            this.getDeviceButton.Text = "Get Device";
            this.getDeviceButton.UseVisualStyleBackColor = true;
            this.getDeviceButton.Click += new System.EventHandler(this.getDeviceButton_Click);
            // 
            // getVolumeButton
            // 
            this.getVolumeButton.Location = new System.Drawing.Point(166, 396);
            this.getVolumeButton.Name = "getVolumeButton";
            this.getVolumeButton.Size = new System.Drawing.Size(75, 23);
            this.getVolumeButton.TabIndex = 12;
            this.getVolumeButton.Text = "Get Volume";
            this.getVolumeButton.UseVisualStyleBackColor = true;
            this.getVolumeButton.Click += new System.EventHandler(this.getVolumeButton_Click);
            // 
            // getQueueButton
            // 
            this.getQueueButton.Location = new System.Drawing.Point(523, 377);
            this.getQueueButton.Name = "getQueueButton";
            this.getQueueButton.Size = new System.Drawing.Size(75, 23);
            this.getQueueButton.TabIndex = 13;
            this.getQueueButton.Text = "Get Queue";
            this.getQueueButton.UseVisualStyleBackColor = true;
            this.getQueueButton.Click += new System.EventHandler(this.getQueueButton_Click);
            // 
            // removeQueueTrackButton
            // 
            this.removeQueueTrackButton.Location = new System.Drawing.Point(523, 411);
            this.removeQueueTrackButton.Name = "removeQueueTrackButton";
            this.removeQueueTrackButton.Size = new System.Drawing.Size(75, 23);
            this.removeQueueTrackButton.TabIndex = 14;
            this.removeQueueTrackButton.Text = "Rm Q Track";
            this.removeQueueTrackButton.UseVisualStyleBackColor = true;
            this.removeQueueTrackButton.Click += new System.EventHandler(this.removeQueueTrackButton_Click);
            // 
            // trackNumberTextBox
            // 
            this.trackNumberTextBox.Location = new System.Drawing.Point(447, 413);
            this.trackNumberTextBox.Name = "trackNumberTextBox";
            this.trackNumberTextBox.Size = new System.Drawing.Size(70, 20);
            this.trackNumberTextBox.TabIndex = 15;
            this.trackNumberTextBox.Text = "1";
            // 
            // fadeButton
            // 
            this.fadeButton.Location = new System.Drawing.Point(86, 423);
            this.fadeButton.Name = "fadeButton";
            this.fadeButton.Size = new System.Drawing.Size(75, 23);
            this.fadeButton.TabIndex = 16;
            this.fadeButton.Text = "Fade";
            this.fadeButton.UseVisualStyleBackColor = true;
            this.fadeButton.Click += new System.EventHandler(this.fadeButton_Click);
            // 
            // fadeTargetVolumeTextBox
            // 
            this.fadeTargetVolumeTextBox.Location = new System.Drawing.Point(7, 426);
            this.fadeTargetVolumeTextBox.Name = "fadeTargetVolumeTextBox";
            this.fadeTargetVolumeTextBox.Size = new System.Drawing.Size(76, 20);
            this.fadeTargetVolumeTextBox.TabIndex = 17;
            this.fadeTargetVolumeTextBox.Text = "10";
            // 
            // rebootButton
            // 
            this.rebootButton.Location = new System.Drawing.Point(307, 10);
            this.rebootButton.Name = "rebootButton";
            this.rebootButton.Size = new System.Drawing.Size(75, 23);
            this.rebootButton.TabIndex = 18;
            this.rebootButton.Text = "Reboot";
            this.rebootButton.UseVisualStyleBackColor = true;
            this.rebootButton.Click += new System.EventHandler(this.rebootButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 521);
            this.Controls.Add(this.rebootButton);
            this.Controls.Add(this.fadeTargetVolumeTextBox);
            this.Controls.Add(this.fadeButton);
            this.Controls.Add(this.trackNumberTextBox);
            this.Controls.Add(this.removeQueueTrackButton);
            this.Controls.Add(this.getQueueButton);
            this.Controls.Add(this.getVolumeButton);
            this.Controls.Add(this.getDeviceButton);
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.volTextBox);
            this.Controls.Add(this.setVolButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.intervalSecondsLabel);
            this.Controls.Add(this.speakerIpLabel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.intervalTextBox);
            this.Controls.Add(this.ipAddressTextBox);
            this.Controls.Add(this.shutUpButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Sonos UI";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button shutUpButton;
        private System.Windows.Forms.TextBox ipAddressTextBox;
        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label speakerIpLabel;
        private System.Windows.Forms.Label intervalSecondsLabel;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button setVolButton;
        private System.Windows.Forms.TextBox volTextBox;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Button getDeviceButton;
        private System.Windows.Forms.Button getVolumeButton;
        private System.Windows.Forms.Button getQueueButton;
        private System.Windows.Forms.Button removeQueueTrackButton;
        private System.Windows.Forms.TextBox trackNumberTextBox;
        private System.Windows.Forms.Button fadeButton;
        private System.Windows.Forms.TextBox fadeTargetVolumeTextBox;
        private System.Windows.Forms.Button rebootButton;
    }
}

