namespace Student_Disciplinary_Records_System
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.oldpassTXT = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.confirmPassTXT = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.newpassTXT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.donotmatchLABEL = new System.Windows.Forms.Label();
            this.kulangLABEL = new System.Windows.Forms.Label();
            this.matchNaLABEL = new System.Windows.Forms.Label();
            this.btnHIDEpw = new System.Windows.Forms.Button();
            this.btnHIDEpwConfirm = new System.Windows.Forms.Button();
            this.btnSeePWconfirm = new System.Windows.Forms.Button();
            this.btnseePW = new System.Windows.Forms.Button();
            this.btnoldpassSEE = new System.Windows.Forms.Button();
            this.btnOldpassHIDE = new System.Windows.Forms.Button();
            this.hindiItoYonLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(527, 51);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.hindiItoYonLabel);
            this.panel2.Controls.Add(this.btnoldpassSEE);
            this.panel2.Controls.Add(this.btnOldpassHIDE);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.oldpassTXT);
            this.panel2.Location = new System.Drawing.Point(26, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(480, 78);
            this.panel2.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 16);
            this.label5.TabIndex = 44;
            this.label5.Text = "Type you old password";
            // 
            // oldpassTXT
            // 
            this.oldpassTXT.Enabled = false;
            this.oldpassTXT.Font = new System.Drawing.Font("Arial", 15F);
            this.oldpassTXT.Location = new System.Drawing.Point(6, 32);
            this.oldpassTXT.Name = "oldpassTXT";
            this.oldpassTXT.PasswordChar = '●';
            this.oldpassTXT.Size = new System.Drawing.Size(458, 30);
            this.oldpassTXT.TabIndex = 32;
            this.oldpassTXT.TextChanged += new System.EventHandler(this.oldpassTXT_TextChanged);
            this.oldpassTXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.oldpassTXT_KeyPress);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkLabel1.AutoEllipsis = true;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkLabel1.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel1.Image")));
            this.linkLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkLabel1.Location = new System.Drawing.Point(491, 16);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(24, 17);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "    ";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "CHANGE PASSWORD";
            // 
            // btnChangePass
            // 
            this.btnChangePass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnChangePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePass.Enabled = false;
            this.btnChangePass.FlatAppearance.BorderSize = 0;
            this.btnChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePass.Font = new System.Drawing.Font("Arial", 9F);
            this.btnChangePass.ForeColor = System.Drawing.Color.White;
            this.btnChangePass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePass.Location = new System.Drawing.Point(32, 323);
            this.btnChangePass.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(458, 40);
            this.btnChangePass.TabIndex = 31;
            this.btnChangePass.Text = "CHANGE PASSWORD";
            this.btnChangePass.UseVisualStyleBackColor = false;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSeePWconfirm);
            this.panel3.Controls.Add(this.btnHIDEpwConfirm);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.confirmPassTXT);
            this.panel3.Location = new System.Drawing.Point(26, 223);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(480, 78);
            this.panel3.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 16);
            this.label4.TabIndex = 44;
            this.label4.Text = "Confirm your new password";
            // 
            // confirmPassTXT
            // 
            this.confirmPassTXT.Enabled = false;
            this.confirmPassTXT.Font = new System.Drawing.Font("Arial", 15F);
            this.confirmPassTXT.Location = new System.Drawing.Point(6, 32);
            this.confirmPassTXT.Name = "confirmPassTXT";
            this.confirmPassTXT.PasswordChar = '●';
            this.confirmPassTXT.Size = new System.Drawing.Size(458, 30);
            this.confirmPassTXT.TabIndex = 32;
            this.confirmPassTXT.TextChanged += new System.EventHandler(this.confirmPassTXT_TextChanged);
            this.confirmPassTXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.confirmPassTXT_KeyPress);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.btnseePW);
            this.panel4.Controls.Add(this.btnHIDEpw);
            this.panel4.Controls.Add(this.newpassTXT);
            this.panel4.Location = new System.Drawing.Point(26, 145);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(480, 78);
            this.panel4.TabIndex = 49;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 16);
            this.label6.TabIndex = 44;
            this.label6.Text = "Type your new password";
            // 
            // newpassTXT
            // 
            this.newpassTXT.Enabled = false;
            this.newpassTXT.Font = new System.Drawing.Font("Arial", 15F);
            this.newpassTXT.Location = new System.Drawing.Point(6, 32);
            this.newpassTXT.Name = "newpassTXT";
            this.newpassTXT.PasswordChar = '●';
            this.newpassTXT.Size = new System.Drawing.Size(458, 30);
            this.newpassTXT.TabIndex = 32;
            this.newpassTXT.TextChanged += new System.EventHandler(this.newpassTXT_TextChanged);
            this.newpassTXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.newpassTXT_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(231, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "CANCEL";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // donotmatchLABEL
            // 
            this.donotmatchLABEL.AutoSize = true;
            this.donotmatchLABEL.Font = new System.Drawing.Font("Arial", 8F);
            this.donotmatchLABEL.ForeColor = System.Drawing.Color.Red;
            this.donotmatchLABEL.Location = new System.Drawing.Point(29, 289);
            this.donotmatchLABEL.Name = "donotmatchLABEL";
            this.donotmatchLABEL.Size = new System.Drawing.Size(132, 14);
            this.donotmatchLABEL.TabIndex = 50;
            this.donotmatchLABEL.Text = "Passwords Do Not Match!";
            this.donotmatchLABEL.Visible = false;
            // 
            // kulangLABEL
            // 
            this.kulangLABEL.AutoSize = true;
            this.kulangLABEL.Font = new System.Drawing.Font("Arial", 8F);
            this.kulangLABEL.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.kulangLABEL.Location = new System.Drawing.Point(31, 210);
            this.kulangLABEL.Name = "kulangLABEL";
            this.kulangLABEL.Size = new System.Drawing.Size(208, 14);
            this.kulangLABEL.TabIndex = 51;
            this.kulangLABEL.Text = "Passwords must be Atleast 5 Characters!";
            this.kulangLABEL.Visible = false;
            // 
            // matchNaLABEL
            // 
            this.matchNaLABEL.AutoSize = true;
            this.matchNaLABEL.Font = new System.Drawing.Font("Arial", 8F);
            this.matchNaLABEL.ForeColor = System.Drawing.Color.Green;
            this.matchNaLABEL.Location = new System.Drawing.Point(29, 291);
            this.matchNaLABEL.Name = "matchNaLABEL";
            this.matchNaLABEL.Size = new System.Drawing.Size(97, 14);
            this.matchNaLABEL.TabIndex = 52;
            this.matchNaLABEL.Text = "Passwords Match!";
            this.matchNaLABEL.Visible = false;
            // 
            // btnHIDEpw
            // 
            this.btnHIDEpw.BackColor = System.Drawing.Color.Transparent;
            this.btnHIDEpw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHIDEpw.FlatAppearance.BorderSize = 0;
            this.btnHIDEpw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHIDEpw.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnHIDEpw.Image = ((System.Drawing.Image)(resources.GetObject("btnHIDEpw.Image")));
            this.btnHIDEpw.Location = new System.Drawing.Point(422, 35);
            this.btnHIDEpw.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnHIDEpw.Name = "btnHIDEpw";
            this.btnHIDEpw.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnHIDEpw.Size = new System.Drawing.Size(39, 24);
            this.btnHIDEpw.TabIndex = 53;
            this.btnHIDEpw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHIDEpw.UseVisualStyleBackColor = false;
            this.btnHIDEpw.Visible = false;
            // 
            // btnHIDEpwConfirm
            // 
            this.btnHIDEpwConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnHIDEpwConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHIDEpwConfirm.FlatAppearance.BorderSize = 0;
            this.btnHIDEpwConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHIDEpwConfirm.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnHIDEpwConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnHIDEpwConfirm.Image")));
            this.btnHIDEpwConfirm.Location = new System.Drawing.Point(422, 35);
            this.btnHIDEpwConfirm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnHIDEpwConfirm.Name = "btnHIDEpwConfirm";
            this.btnHIDEpwConfirm.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnHIDEpwConfirm.Size = new System.Drawing.Size(39, 24);
            this.btnHIDEpwConfirm.TabIndex = 54;
            this.btnHIDEpwConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHIDEpwConfirm.UseVisualStyleBackColor = false;
            this.btnHIDEpwConfirm.Visible = false;
            this.btnHIDEpwConfirm.Click += new System.EventHandler(this.btnHIDEpwConfirm_Click);
            // 
            // btnSeePWconfirm
            // 
            this.btnSeePWconfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnSeePWconfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeePWconfirm.FlatAppearance.BorderSize = 0;
            this.btnSeePWconfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeePWconfirm.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnSeePWconfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnSeePWconfirm.Image")));
            this.btnSeePWconfirm.Location = new System.Drawing.Point(422, 35);
            this.btnSeePWconfirm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSeePWconfirm.Name = "btnSeePWconfirm";
            this.btnSeePWconfirm.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSeePWconfirm.Size = new System.Drawing.Size(39, 24);
            this.btnSeePWconfirm.TabIndex = 54;
            this.btnSeePWconfirm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeePWconfirm.UseVisualStyleBackColor = false;
            this.btnSeePWconfirm.Click += new System.EventHandler(this.btnSeePWconfirm_Click);
            // 
            // btnseePW
            // 
            this.btnseePW.BackColor = System.Drawing.Color.Transparent;
            this.btnseePW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnseePW.FlatAppearance.BorderSize = 0;
            this.btnseePW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnseePW.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnseePW.Image = ((System.Drawing.Image)(resources.GetObject("btnseePW.Image")));
            this.btnseePW.Location = new System.Drawing.Point(422, 35);
            this.btnseePW.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnseePW.Name = "btnseePW";
            this.btnseePW.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnseePW.Size = new System.Drawing.Size(39, 24);
            this.btnseePW.TabIndex = 55;
            this.btnseePW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnseePW.UseVisualStyleBackColor = false;
            this.btnseePW.Click += new System.EventHandler(this.btnseePW_Click);
            // 
            // btnoldpassSEE
            // 
            this.btnoldpassSEE.BackColor = System.Drawing.Color.Transparent;
            this.btnoldpassSEE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnoldpassSEE.FlatAppearance.BorderSize = 0;
            this.btnoldpassSEE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnoldpassSEE.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnoldpassSEE.Image = ((System.Drawing.Image)(resources.GetObject("btnoldpassSEE.Image")));
            this.btnoldpassSEE.Location = new System.Drawing.Point(422, 35);
            this.btnoldpassSEE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnoldpassSEE.Name = "btnoldpassSEE";
            this.btnoldpassSEE.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnoldpassSEE.Size = new System.Drawing.Size(39, 24);
            this.btnoldpassSEE.TabIndex = 56;
            this.btnoldpassSEE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnoldpassSEE.UseVisualStyleBackColor = false;
            this.btnoldpassSEE.Click += new System.EventHandler(this.btnoldpassSEE_Click);
            // 
            // btnOldpassHIDE
            // 
            this.btnOldpassHIDE.BackColor = System.Drawing.Color.Transparent;
            this.btnOldpassHIDE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOldpassHIDE.FlatAppearance.BorderSize = 0;
            this.btnOldpassHIDE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOldpassHIDE.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnOldpassHIDE.Image = ((System.Drawing.Image)(resources.GetObject("btnOldpassHIDE.Image")));
            this.btnOldpassHIDE.Location = new System.Drawing.Point(422, 35);
            this.btnOldpassHIDE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOldpassHIDE.Name = "btnOldpassHIDE";
            this.btnOldpassHIDE.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnOldpassHIDE.Size = new System.Drawing.Size(39, 24);
            this.btnOldpassHIDE.TabIndex = 57;
            this.btnOldpassHIDE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOldpassHIDE.UseVisualStyleBackColor = false;
            this.btnOldpassHIDE.Visible = false;
            this.btnOldpassHIDE.Click += new System.EventHandler(this.btnOldpassHIDE_Click);
            // 
            // hindiItoYonLabel
            // 
            this.hindiItoYonLabel.AutoSize = true;
            this.hindiItoYonLabel.Font = new System.Drawing.Font("Arial", 8F);
            this.hindiItoYonLabel.ForeColor = System.Drawing.Color.Red;
            this.hindiItoYonLabel.Location = new System.Drawing.Point(5, 66);
            this.hindiItoYonLabel.Name = "hindiItoYonLabel";
            this.hindiItoYonLabel.Size = new System.Drawing.Size(192, 14);
            this.hindiItoYonLabel.TabIndex = 53;
            this.hindiItoYonLabel.Text = "Password does not match the old one!";
            this.hindiItoYonLabel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8F);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(5, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 14);
            this.label3.TabIndex = 58;
            this.label3.Text = "Password matches the old one!";
            this.label3.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(527, 406);
            this.ControlBox = false;
            this.Controls.Add(this.matchNaLABEL);
            this.Controls.Add(this.kulangLABEL);
            this.Controls.Add(this.donotmatchLABEL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnChangePass);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.TextBox oldpassTXT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox confirmPassTXT;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox newpassTXT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label donotmatchLABEL;
        private System.Windows.Forms.Label kulangLABEL;
        private System.Windows.Forms.Label matchNaLABEL;
        private System.Windows.Forms.Button btnHIDEpw;
        private System.Windows.Forms.Button btnHIDEpwConfirm;
        private System.Windows.Forms.Button btnSeePWconfirm;
        private System.Windows.Forms.Button btnseePW;
        private System.Windows.Forms.Button btnoldpassSEE;
        private System.Windows.Forms.Button btnOldpassHIDE;
        private System.Windows.Forms.Label hindiItoYonLabel;
        private System.Windows.Forms.Label label3;
    }
}