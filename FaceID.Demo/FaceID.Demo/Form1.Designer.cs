namespace FaceID.Demo
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
            this.deviceCmb = new System.Windows.Forms.ComboBox();
            this.btnDetect = new System.Windows.Forms.Button();
            this.DeviceLbl = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // deviceCmb
            // 
            this.deviceCmb.FormattingEnabled = true;
            this.deviceCmb.Location = new System.Drawing.Point(79, 22);
            this.deviceCmb.Name = "deviceCmb";
            this.deviceCmb.Size = new System.Drawing.Size(391, 21);
            this.deviceCmb.TabIndex = 0;
            this.deviceCmb.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnDetect
            // 
            this.btnDetect.Location = new System.Drawing.Point(569, 91);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(75, 23);
            this.btnDetect.TabIndex = 1;
            this.btnDetect.Text = "Detect";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // DeviceLbl
            // 
            this.DeviceLbl.AutoSize = true;
            this.DeviceLbl.Location = new System.Drawing.Point(38, 25);
            this.DeviceLbl.Name = "DeviceLbl";
            this.DeviceLbl.Size = new System.Drawing.Size(41, 13);
            this.DeviceLbl.TabIndex = 2;
            this.DeviceLbl.Text = "Device";
            this.DeviceLbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(12, 66);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(541, 347);
            this.pic.TabIndex = 3;
            this.pic.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 450);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.DeviceLbl);
            this.Controls.Add(this.btnDetect);
            this.Controls.Add(this.deviceCmb);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Face Detection Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox deviceCmb;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.Label DeviceLbl;
        private System.Windows.Forms.PictureBox pic;
    }
}

