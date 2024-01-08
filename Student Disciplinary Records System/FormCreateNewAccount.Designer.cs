namespace Student_Disciplinary_Records_System
{
    partial class FormCreateNewAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateNewAccount));
            this.txtlastname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveAcc = new System.Windows.Forms.Button();
            this.txtfirstname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmidname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbRoleType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPWconfirm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnseePW = new System.Windows.Forms.Button();
            this.btnSeePWconfirm = new System.Windows.Forms.Button();
            this.btnHIDEpw = new System.Windows.Forms.Button();
            this.btnHIDEpwConfirm = new System.Windows.Forms.Button();
            this.labelmatchIndicator = new System.Windows.Forms.Label();
            this.labelUsernameIndicator = new System.Windows.Forms.Label();
            this.labelmatchIndicator2 = new System.Windows.Forms.Label();
            this.picimage = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.speciallabel = new System.Windows.Forms.Label();
            this.labelCurrentUsername = new System.Windows.Forms.Label();
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtlastname
            // 
            this.txtlastname.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlastname.Location = new System.Drawing.Point(162, 198);
            this.txtlastname.Name = "txtlastname";
            this.txtlastname.Size = new System.Drawing.Size(357, 26);
            this.txtlastname.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Last Name";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(162, 243);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(357, 26);
            this.txtUsername.TabIndex = 10;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Username";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 37);
            this.panel1.TabIndex = 8;
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
            this.linkLabel1.Location = new System.Drawing.Point(790, 7);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(24, 17);
            this.linkLabel1.TabIndex = 2;
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
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "CREATE NEW USER ACCOUNT";
            // 
            // btnSaveAcc
            // 
            this.btnSaveAcc.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSaveAcc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAcc.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaveAcc.Location = new System.Drawing.Point(24, 410);
            this.btnSaveAcc.Name = "btnSaveAcc";
            this.btnSaveAcc.Size = new System.Drawing.Size(495, 40);
            this.btnSaveAcc.TabIndex = 15;
            this.btnSaveAcc.Text = "CREATE ACOUNT";
            this.btnSaveAcc.UseVisualStyleBackColor = false;
            this.btnSaveAcc.Click += new System.EventHandler(this.btnSaveAcc_Click);
            // 
            // txtfirstname
            // 
            this.txtfirstname.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfirstname.Location = new System.Drawing.Point(162, 108);
            this.txtfirstname.Name = "txtfirstname";
            this.txtfirstname.Size = new System.Drawing.Size(357, 26);
            this.txtfirstname.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(73, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "First Name";
            // 
            // txtPW
            // 
            this.txtPW.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPW.Location = new System.Drawing.Point(162, 292);
            this.txtPW.Name = "txtPW";
            this.txtPW.Size = new System.Drawing.Size(357, 26);
            this.txtPW.TabIndex = 19;
            this.txtPW.TextChanged += new System.EventHandler(this.txtPW_TextChanged);
            this.txtPW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPW_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(80, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "Password";
            // 
            // txtmidname
            // 
            this.txtmidname.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmidname.Location = new System.Drawing.Point(162, 153);
            this.txtmidname.Name = "txtmidname";
            this.txtmidname.Size = new System.Drawing.Size(357, 26);
            this.txtmidname.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(57, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "Middle Name";
            // 
            // cmbRoleType
            // 
            this.cmbRoleType.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbRoleType.FormattingEnabled = true;
            this.cmbRoleType.Items.AddRange(new object[] {
            "Administrator",
            "Instructor"});
            this.cmbRoleType.Location = new System.Drawing.Point(162, 63);
            this.cmbRoleType.Name = "cmbRoleType";
            this.cmbRoleType.Size = new System.Drawing.Size(357, 26);
            this.cmbRoleType.TabIndex = 22;
            this.cmbRoleType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbRoleType_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 18);
            this.label7.TabIndex = 23;
            this.label7.Text = "Role/Type of User";
            // 
            // txtPWconfirm
            // 
            this.txtPWconfirm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPWconfirm.Location = new System.Drawing.Point(162, 339);
            this.txtPWconfirm.Name = "txtPWconfirm";
            this.txtPWconfirm.Size = new System.Drawing.Size(357, 26);
            this.txtPWconfirm.TabIndex = 25;
            this.txtPWconfirm.TextChanged += new System.EventHandler(this.txtPWconfirm_TextChanged);
            this.txtPWconfirm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPWconfirm_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 18);
            this.label8.TabIndex = 24;
            this.label8.Text = "Confirm Password";
            // 
            // btnseePW
            // 
            this.btnseePW.BackColor = System.Drawing.Color.Transparent;
            this.btnseePW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnseePW.FlatAppearance.BorderSize = 0;
            this.btnseePW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnseePW.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnseePW.Image = ((System.Drawing.Image)(resources.GetObject("btnseePW.Image")));
            this.btnseePW.Location = new System.Drawing.Point(476, 293);
            this.btnseePW.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnseePW.Name = "btnseePW";
            this.btnseePW.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnseePW.Size = new System.Drawing.Size(39, 24);
            this.btnseePW.TabIndex = 42;
            this.btnseePW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnseePW.UseVisualStyleBackColor = false;
            this.btnseePW.Click += new System.EventHandler(this.btnseePW_Click);
            // 
            // btnSeePWconfirm
            // 
            this.btnSeePWconfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnSeePWconfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeePWconfirm.FlatAppearance.BorderSize = 0;
            this.btnSeePWconfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeePWconfirm.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnSeePWconfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnSeePWconfirm.Image")));
            this.btnSeePWconfirm.Location = new System.Drawing.Point(476, 340);
            this.btnSeePWconfirm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSeePWconfirm.Name = "btnSeePWconfirm";
            this.btnSeePWconfirm.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSeePWconfirm.Size = new System.Drawing.Size(39, 24);
            this.btnSeePWconfirm.TabIndex = 43;
            this.btnSeePWconfirm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeePWconfirm.UseVisualStyleBackColor = false;
            this.btnSeePWconfirm.Click += new System.EventHandler(this.btnSeePWconfirm_Click);
            // 
            // btnHIDEpw
            // 
            this.btnHIDEpw.BackColor = System.Drawing.Color.Transparent;
            this.btnHIDEpw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHIDEpw.FlatAppearance.BorderSize = 0;
            this.btnHIDEpw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHIDEpw.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnHIDEpw.Image = ((System.Drawing.Image)(resources.GetObject("btnHIDEpw.Image")));
            this.btnHIDEpw.Location = new System.Drawing.Point(476, 293);
            this.btnHIDEpw.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnHIDEpw.Name = "btnHIDEpw";
            this.btnHIDEpw.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnHIDEpw.Size = new System.Drawing.Size(39, 24);
            this.btnHIDEpw.TabIndex = 44;
            this.btnHIDEpw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHIDEpw.UseVisualStyleBackColor = false;
            this.btnHIDEpw.Click += new System.EventHandler(this.btnHIDEpw_Click);
            // 
            // btnHIDEpwConfirm
            // 
            this.btnHIDEpwConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnHIDEpwConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHIDEpwConfirm.FlatAppearance.BorderSize = 0;
            this.btnHIDEpwConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHIDEpwConfirm.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnHIDEpwConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnHIDEpwConfirm.Image")));
            this.btnHIDEpwConfirm.Location = new System.Drawing.Point(476, 340);
            this.btnHIDEpwConfirm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnHIDEpwConfirm.Name = "btnHIDEpwConfirm";
            this.btnHIDEpwConfirm.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnHIDEpwConfirm.Size = new System.Drawing.Size(39, 24);
            this.btnHIDEpwConfirm.TabIndex = 45;
            this.btnHIDEpwConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHIDEpwConfirm.UseVisualStyleBackColor = false;
            this.btnHIDEpwConfirm.Click += new System.EventHandler(this.btnHIDEpwConfirm_Click);
            // 
            // labelmatchIndicator
            // 
            this.labelmatchIndicator.AutoSize = true;
            this.labelmatchIndicator.Font = new System.Drawing.Font("Arial", 8F);
            this.labelmatchIndicator.ForeColor = System.Drawing.Color.Red;
            this.labelmatchIndicator.Location = new System.Drawing.Point(159, 368);
            this.labelmatchIndicator.Name = "labelmatchIndicator";
            this.labelmatchIndicator.Size = new System.Drawing.Size(132, 14);
            this.labelmatchIndicator.TabIndex = 46;
            this.labelmatchIndicator.Text = "Passwords Do Not Match!";
            this.labelmatchIndicator.Visible = false;
            // 
            // labelUsernameIndicator
            // 
            this.labelUsernameIndicator.AutoSize = true;
            this.labelUsernameIndicator.Font = new System.Drawing.Font("Arial", 8F);
            this.labelUsernameIndicator.ForeColor = System.Drawing.Color.Red;
            this.labelUsernameIndicator.Location = new System.Drawing.Point(159, 272);
            this.labelUsernameIndicator.Name = "labelUsernameIndicator";
            this.labelUsernameIndicator.Size = new System.Drawing.Size(162, 14);
            this.labelUsernameIndicator.TabIndex = 47;
            this.labelUsernameIndicator.Text = "This Username Has Been Taken!";
            this.labelUsernameIndicator.Visible = false;
            // 
            // labelmatchIndicator2
            // 
            this.labelmatchIndicator2.AutoSize = true;
            this.labelmatchIndicator2.Font = new System.Drawing.Font("Arial", 8F);
            this.labelmatchIndicator2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.labelmatchIndicator2.Location = new System.Drawing.Point(159, 318);
            this.labelmatchIndicator2.Name = "labelmatchIndicator2";
            this.labelmatchIndicator2.Size = new System.Drawing.Size(208, 14);
            this.labelmatchIndicator2.TabIndex = 48;
            this.labelmatchIndicator2.Text = "Passwords must be Atleast 5 Characters!";
            this.labelmatchIndicator2.Visible = false;
            // 
            // picimage
            // 
            this.picimage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picimage.Location = new System.Drawing.Point(542, 63);
            this.picimage.Name = "picimage";
            this.picimage.Size = new System.Drawing.Size(250, 248);
            this.picimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picimage.TabIndex = 39;
            this.picimage.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(542, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 27);
            this.button1.TabIndex = 40;
            this.button1.Text = "BROWSE IMAGE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // speciallabel
            // 
            this.speciallabel.AutoSize = true;
            this.speciallabel.Font = new System.Drawing.Font("Arial", 8F);
            this.speciallabel.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.speciallabel.Location = new System.Drawing.Point(159, 272);
            this.speciallabel.Name = "speciallabel";
            this.speciallabel.Size = new System.Drawing.Size(200, 14);
            this.speciallabel.TabIndex = 49;
            this.speciallabel.Text = "Username must be at least 5 characters";
            this.speciallabel.Visible = false;
            // 
            // labelCurrentUsername
            // 
            this.labelCurrentUsername.AutoSize = true;
            this.labelCurrentUsername.Font = new System.Drawing.Font("Arial", 7F);
            this.labelCurrentUsername.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelCurrentUsername.Location = new System.Drawing.Point(159, 229);
            this.labelCurrentUsername.Name = "labelCurrentUsername";
            this.labelCurrentUsername.Size = new System.Drawing.Size(94, 13);
            this.labelCurrentUsername.TabIndex = 50;
            this.labelCurrentUsername.Text = "Current Username:";
            this.labelCurrentUsername.Visible = false;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandTimeout = 30;
            this.sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // FormCreateNewAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(821, 476);
            this.ControlBox = false;
            this.Controls.Add(this.labelCurrentUsername);
            this.Controls.Add(this.picimage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelmatchIndicator2);
            this.Controls.Add(this.labelUsernameIndicator);
            this.Controls.Add(this.labelmatchIndicator);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbRoleType);
            this.Controls.Add(this.txtmidname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtfirstname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSaveAcc);
            this.Controls.Add(this.txtlastname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSeePWconfirm);
            this.Controls.Add(this.btnseePW);
            this.Controls.Add(this.speciallabel);
            this.Controls.Add(this.btnHIDEpwConfirm);
            this.Controls.Add(this.btnHIDEpw);
            this.Controls.Add(this.txtPW);
            this.Controls.Add(this.txtPWconfirm);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCreateNewAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormCreateNewAccount_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtlastname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveAcc;
        private System.Windows.Forms.TextBox txtfirstname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtmidname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbRoleType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPWconfirm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnseePW;
        private System.Windows.Forms.Button btnSeePWconfirm;
        private System.Windows.Forms.Button btnHIDEpw;
        private System.Windows.Forms.Button btnHIDEpwConfirm;
        private System.Windows.Forms.Label labelmatchIndicator;
        private System.Windows.Forms.Label labelUsernameIndicator;
        private System.Windows.Forms.Label labelmatchIndicator2;
        private System.Windows.Forms.PictureBox picimage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label speciallabel;
        private System.Windows.Forms.Label labelCurrentUsername;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    }
}