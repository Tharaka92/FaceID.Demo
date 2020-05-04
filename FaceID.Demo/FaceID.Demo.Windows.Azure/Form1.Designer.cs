namespace FaceID.Demo.Windows.Azure
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
            this.pic = new System.Windows.Forms.PictureBox();
            this.deviceCmb = new System.Windows.Forms.ComboBox();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.registerBtn = new System.Windows.Forms.Button();
            this.loginbtn = new System.Windows.Forms.Button();
            this.statusLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(12, 60);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(458, 378);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // deviceCmb
            // 
            this.deviceCmb.FormattingEnabled = true;
            this.deviceCmb.Location = new System.Drawing.Point(559, 60);
            this.deviceCmb.Name = "deviceCmb";
            this.deviceCmb.Size = new System.Drawing.Size(229, 21);
            this.deviceCmb.TabIndex = 1;
            this.deviceCmb.SelectedIndexChanged += new System.EventHandler(this.deviceCmb_SelectedIndexChanged);
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(608, 105);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(180, 20);
            this.nameTxt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(556, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(559, 158);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(229, 23);
            this.registerBtn.TabIndex = 4;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // loginbtn
            // 
            this.loginbtn.Location = new System.Drawing.Point(559, 205);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(229, 23);
            this.loginbtn.TabIndex = 5;
            this.loginbtn.Text = "Login";
            this.loginbtn.UseVisualStyleBackColor = true;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Location = new System.Drawing.Point(579, 293);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(170, 20);
            this.statusLbl.TabIndex = 6;
            this.statusLbl.Text = "Status will appear here";
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.deviceCmb);
            this.Controls.Add(this.pic);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.ComboBox deviceCmb;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button loginbtn;
        private System.Windows.Forms.Label statusLbl;
    }
}

