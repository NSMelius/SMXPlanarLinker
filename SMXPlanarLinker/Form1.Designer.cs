namespace SMXPlanarLinker
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
            this.tbAmsNetId = new System.Windows.Forms.TextBox();
            this.tbAdsPort = new System.Windows.Forms.TextBox();
            this.btnAdsConnect = new System.Windows.Forms.Button();
            this.cbXSymbols = new System.Windows.Forms.ComboBox();
            this.cbYSymbols = new System.Windows.Forms.ComboBox();
            this.cbZSymbols = new System.Windows.Forms.ComboBox();
            this.cbCSymbols = new System.Windows.Forms.ComboBox();
            this.lbAmsNetId = new System.Windows.Forms.Label();
            this.lbAdsPort = new System.Windows.Forms.Label();
            this.tbXAxis = new System.Windows.Forms.TrackBar();
            this.tbYAxis = new System.Windows.Forms.TrackBar();
            this.tbZAxis = new System.Windows.Forms.TrackBar();
            this.tbCAxis = new System.Windows.Forms.TrackBar();
            this.btnX = new System.Windows.Forms.Button();
            this.BtnY = new System.Windows.Forms.Button();
            this.btnZ = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.tbBAxis = new System.Windows.Forms.TrackBar();
            this.cbBSymbols = new System.Windows.Forms.ComboBox();
            this.btnA = new System.Windows.Forms.Button();
            this.tbAAxis = new System.Windows.Forms.TrackBar();
            this.cbASymbols = new System.Windows.Forms.ComboBox();
            this.cbSnapRotationSymbols = new System.Windows.Forms.ComboBox();
            this.btnSnapRotation = new System.Windows.Forms.Button();
            this.chkbDisableRotation = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbXAxis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbYAxis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbZAxis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCAxis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBAxis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAAxis)).BeginInit();
            this.SuspendLayout();
            // 
            // tbAmsNetId
            // 
            this.tbAmsNetId.Location = new System.Drawing.Point(12, 27);
            this.tbAmsNetId.Name = "tbAmsNetId";
            this.tbAmsNetId.Size = new System.Drawing.Size(100, 20);
            this.tbAmsNetId.TabIndex = 0;
            this.tbAmsNetId.Text = "127.0.0.1.1.1";
            // 
            // tbAdsPort
            // 
            this.tbAdsPort.Location = new System.Drawing.Point(118, 27);
            this.tbAdsPort.Name = "tbAdsPort";
            this.tbAdsPort.Size = new System.Drawing.Size(100, 20);
            this.tbAdsPort.TabIndex = 1;
            this.tbAdsPort.Text = "851";
            // 
            // btnAdsConnect
            // 
            this.btnAdsConnect.Location = new System.Drawing.Point(234, 27);
            this.btnAdsConnect.Name = "btnAdsConnect";
            this.btnAdsConnect.Size = new System.Drawing.Size(75, 23);
            this.btnAdsConnect.TabIndex = 2;
            this.btnAdsConnect.Text = "Connect";
            this.btnAdsConnect.UseVisualStyleBackColor = true;
            this.btnAdsConnect.Click += new System.EventHandler(this.btnAdsConnect_Click);
            // 
            // cbXSymbols
            // 
            this.cbXSymbols.FormattingEnabled = true;
            this.cbXSymbols.Location = new System.Drawing.Point(627, 60);
            this.cbXSymbols.Name = "cbXSymbols";
            this.cbXSymbols.Size = new System.Drawing.Size(121, 21);
            this.cbXSymbols.TabIndex = 3;
            this.cbXSymbols.SelectedIndexChanged += new System.EventHandler(this.cbXSymbols_SelectedIndexChanged);
            // 
            // cbYSymbols
            // 
            this.cbYSymbols.FormattingEnabled = true;
            this.cbYSymbols.Location = new System.Drawing.Point(627, 112);
            this.cbYSymbols.Name = "cbYSymbols";
            this.cbYSymbols.Size = new System.Drawing.Size(121, 21);
            this.cbYSymbols.TabIndex = 4;
            this.cbYSymbols.SelectedIndexChanged += new System.EventHandler(this.cbYsymbols_SelectedIndexChanged);
            // 
            // cbZSymbols
            // 
            this.cbZSymbols.FormattingEnabled = true;
            this.cbZSymbols.Location = new System.Drawing.Point(627, 162);
            this.cbZSymbols.Name = "cbZSymbols";
            this.cbZSymbols.Size = new System.Drawing.Size(121, 21);
            this.cbZSymbols.TabIndex = 5;
            this.cbZSymbols.SelectedIndexChanged += new System.EventHandler(this.cbZSymbols_SelectedIndexChanged);
            // 
            // cbCSymbols
            // 
            this.cbCSymbols.FormattingEnabled = true;
            this.cbCSymbols.Location = new System.Drawing.Point(627, 316);
            this.cbCSymbols.Name = "cbCSymbols";
            this.cbCSymbols.Size = new System.Drawing.Size(121, 21);
            this.cbCSymbols.TabIndex = 6;
            this.cbCSymbols.SelectedIndexChanged += new System.EventHandler(this.cbCSymbols_SelectedIndexChanged);
            // 
            // lbAmsNetId
            // 
            this.lbAmsNetId.AutoSize = true;
            this.lbAmsNetId.Location = new System.Drawing.Point(12, 8);
            this.lbAmsNetId.Name = "lbAmsNetId";
            this.lbAmsNetId.Size = new System.Drawing.Size(59, 13);
            this.lbAmsNetId.TabIndex = 7;
            this.lbAmsNetId.Text = "Ams Net Id";
            // 
            // lbAdsPort
            // 
            this.lbAdsPort.AutoSize = true;
            this.lbAdsPort.Location = new System.Drawing.Point(118, 9);
            this.lbAdsPort.Name = "lbAdsPort";
            this.lbAdsPort.Size = new System.Drawing.Size(44, 13);
            this.lbAdsPort.TabIndex = 8;
            this.lbAdsPort.Text = "AdsPort";
            // 
            // tbXAxis
            // 
            this.tbXAxis.BackColor = System.Drawing.SystemColors.Control;
            this.tbXAxis.Location = new System.Drawing.Point(38, 60);
            this.tbXAxis.Maximum = 350;
            this.tbXAxis.Minimum = -350;
            this.tbXAxis.Name = "tbXAxis";
            this.tbXAxis.RightToLeftLayout = true;
            this.tbXAxis.Size = new System.Drawing.Size(564, 45);
            this.tbXAxis.TabIndex = 13;
            this.tbXAxis.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbYAxis
            // 
            this.tbYAxis.BackColor = System.Drawing.SystemColors.Control;
            this.tbYAxis.Location = new System.Drawing.Point(38, 111);
            this.tbYAxis.Maximum = 350;
            this.tbYAxis.Minimum = -350;
            this.tbYAxis.Name = "tbYAxis";
            this.tbYAxis.RightToLeftLayout = true;
            this.tbYAxis.Size = new System.Drawing.Size(564, 45);
            this.tbYAxis.TabIndex = 14;
            this.tbYAxis.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbZAxis
            // 
            this.tbZAxis.BackColor = System.Drawing.SystemColors.Control;
            this.tbZAxis.Location = new System.Drawing.Point(38, 162);
            this.tbZAxis.Maximum = 350;
            this.tbZAxis.Minimum = -350;
            this.tbZAxis.Name = "tbZAxis";
            this.tbZAxis.RightToLeftLayout = true;
            this.tbZAxis.Size = new System.Drawing.Size(564, 45);
            this.tbZAxis.TabIndex = 15;
            this.tbZAxis.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbCAxis
            // 
            this.tbCAxis.BackColor = System.Drawing.SystemColors.Control;
            this.tbCAxis.Location = new System.Drawing.Point(38, 315);
            this.tbCAxis.Maximum = 350;
            this.tbCAxis.Minimum = -350;
            this.tbCAxis.Name = "tbCAxis";
            this.tbCAxis.RightToLeftLayout = true;
            this.tbCAxis.Size = new System.Drawing.Size(564, 45);
            this.tbCAxis.TabIndex = 16;
            this.tbCAxis.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // btnX
            // 
            this.btnX.Location = new System.Drawing.Point(11, 60);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(28, 23);
            this.btnX.TabIndex = 17;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = true;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // BtnY
            // 
            this.BtnY.Location = new System.Drawing.Point(11, 110);
            this.BtnY.Name = "BtnY";
            this.BtnY.Size = new System.Drawing.Size(28, 23);
            this.BtnY.TabIndex = 18;
            this.BtnY.Text = "Y";
            this.BtnY.UseVisualStyleBackColor = true;
            this.BtnY.Click += new System.EventHandler(this.BtnY_Click);
            // 
            // btnZ
            // 
            this.btnZ.Location = new System.Drawing.Point(11, 160);
            this.btnZ.Name = "btnZ";
            this.btnZ.Size = new System.Drawing.Size(28, 23);
            this.btnZ.TabIndex = 19;
            this.btnZ.Text = "Z";
            this.btnZ.UseVisualStyleBackColor = true;
            this.btnZ.Click += new System.EventHandler(this.btnZ_Click);
            // 
            // btnC
            // 
            this.btnC.Location = new System.Drawing.Point(11, 314);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(28, 23);
            this.btnC.TabIndex = 20;
            this.btnC.Text = "C";
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // btnB
            // 
            this.btnB.Location = new System.Drawing.Point(11, 263);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(28, 23);
            this.btnB.TabIndex = 23;
            this.btnB.Text = "B";
            this.btnB.UseVisualStyleBackColor = true;
            this.btnB.Click += new System.EventHandler(this.btnB_Click);
            // 
            // tbBAxis
            // 
            this.tbBAxis.BackColor = System.Drawing.SystemColors.Control;
            this.tbBAxis.Location = new System.Drawing.Point(38, 264);
            this.tbBAxis.Maximum = 350;
            this.tbBAxis.Minimum = -350;
            this.tbBAxis.Name = "tbBAxis";
            this.tbBAxis.RightToLeftLayout = true;
            this.tbBAxis.Size = new System.Drawing.Size(564, 45);
            this.tbBAxis.TabIndex = 22;
            this.tbBAxis.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // cbBSymbols
            // 
            this.cbBSymbols.FormattingEnabled = true;
            this.cbBSymbols.Location = new System.Drawing.Point(627, 265);
            this.cbBSymbols.Name = "cbBSymbols";
            this.cbBSymbols.Size = new System.Drawing.Size(121, 21);
            this.cbBSymbols.TabIndex = 21;
            this.cbBSymbols.SelectedIndexChanged += new System.EventHandler(this.cbBSymbols_SelectedIndexChanged);
            // 
            // btnA
            // 
            this.btnA.Location = new System.Drawing.Point(11, 212);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(28, 23);
            this.btnA.TabIndex = 26;
            this.btnA.Text = "A";
            this.btnA.UseVisualStyleBackColor = true;
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // tbAAxis
            // 
            this.tbAAxis.BackColor = System.Drawing.SystemColors.Control;
            this.tbAAxis.Location = new System.Drawing.Point(38, 213);
            this.tbAAxis.Maximum = 350;
            this.tbAAxis.Minimum = -350;
            this.tbAAxis.Name = "tbAAxis";
            this.tbAAxis.RightToLeftLayout = true;
            this.tbAAxis.Size = new System.Drawing.Size(564, 45);
            this.tbAAxis.TabIndex = 25;
            this.tbAAxis.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // cbASymbols
            // 
            this.cbASymbols.FormattingEnabled = true;
            this.cbASymbols.Location = new System.Drawing.Point(627, 214);
            this.cbASymbols.Name = "cbASymbols";
            this.cbASymbols.Size = new System.Drawing.Size(121, 21);
            this.cbASymbols.TabIndex = 24;
            this.cbASymbols.SelectedIndexChanged += new System.EventHandler(this.cbASymbols_SelectedIndexChanged);
            // 
            // cbSnapRotationSymbols
            // 
            this.cbSnapRotationSymbols.FormattingEnabled = true;
            this.cbSnapRotationSymbols.Location = new System.Drawing.Point(627, 402);
            this.cbSnapRotationSymbols.Name = "cbSnapRotationSymbols";
            this.cbSnapRotationSymbols.Size = new System.Drawing.Size(121, 21);
            this.cbSnapRotationSymbols.TabIndex = 28;
            this.cbSnapRotationSymbols.SelectedIndexChanged += new System.EventHandler(this.cbSnapRotationSymbols_SelectedIndexChanged);
            // 
            // btnSnapRotation
            // 
            this.btnSnapRotation.Location = new System.Drawing.Point(508, 402);
            this.btnSnapRotation.Name = "btnSnapRotation";
            this.btnSnapRotation.Size = new System.Drawing.Size(94, 23);
            this.btnSnapRotation.TabIndex = 30;
            this.btnSnapRotation.Text = "Snap Rotation";
            this.btnSnapRotation.UseVisualStyleBackColor = true;
            this.btnSnapRotation.Click += new System.EventHandler(this.btnSnapRotation_Click);
            // 
            // chkbDisableRotation
            // 
            this.chkbDisableRotation.AutoSize = true;
            this.chkbDisableRotation.Enabled = false;
            this.chkbDisableRotation.Location = new System.Drawing.Point(627, 359);
            this.chkbDisableRotation.Name = "chkbDisableRotation";
            this.chkbDisableRotation.Size = new System.Drawing.Size(104, 17);
            this.chkbDisableRotation.TabIndex = 31;
            this.chkbDisableRotation.Text = "Disable Rotation";
            this.chkbDisableRotation.UseVisualStyleBackColor = true;
            this.chkbDisableRotation.CheckedChanged += new System.EventHandler(this.chkbDisableRotation_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chkbDisableRotation);
            this.Controls.Add(this.btnSnapRotation);
            this.Controls.Add(this.cbSnapRotationSymbols);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.tbAAxis);
            this.Controls.Add(this.cbASymbols);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.tbBAxis);
            this.Controls.Add(this.cbBSymbols);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnZ);
            this.Controls.Add(this.BtnY);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.tbCAxis);
            this.Controls.Add(this.tbZAxis);
            this.Controls.Add(this.tbYAxis);
            this.Controls.Add(this.tbXAxis);
            this.Controls.Add(this.lbAdsPort);
            this.Controls.Add(this.lbAmsNetId);
            this.Controls.Add(this.cbCSymbols);
            this.Controls.Add(this.cbZSymbols);
            this.Controls.Add(this.cbYSymbols);
            this.Controls.Add(this.cbXSymbols);
            this.Controls.Add(this.btnAdsConnect);
            this.Controls.Add(this.tbAdsPort);
            this.Controls.Add(this.tbAmsNetId);
            this.Name = "Form1";
            this.Text = "Joystick Ads Linker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.tbXAxis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbYAxis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbZAxis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCAxis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBAxis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAAxis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAmsNetId;
        private System.Windows.Forms.TextBox tbAdsPort;
        private System.Windows.Forms.Button btnAdsConnect;
        private System.Windows.Forms.ComboBox cbXSymbols;
        private System.Windows.Forms.ComboBox cbYSymbols;
        private System.Windows.Forms.ComboBox cbZSymbols;
        private System.Windows.Forms.ComboBox cbCSymbols;
        private System.Windows.Forms.Label lbAmsNetId;
        private System.Windows.Forms.Label lbAdsPort;
        private System.Windows.Forms.TrackBar tbXAxis;
        private System.Windows.Forms.TrackBar tbYAxis;
        private System.Windows.Forms.TrackBar tbZAxis;
        private System.Windows.Forms.TrackBar tbCAxis;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Button BtnY;
        private System.Windows.Forms.Button btnZ;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.TrackBar tbBAxis;
        private System.Windows.Forms.ComboBox cbBSymbols;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.TrackBar tbAAxis;
        private System.Windows.Forms.ComboBox cbASymbols;
        private System.Windows.Forms.ComboBox cbSnapRotationSymbols;
        private System.Windows.Forms.Button btnSnapRotation;
        private System.Windows.Forms.CheckBox chkbDisableRotation;
    }
}

