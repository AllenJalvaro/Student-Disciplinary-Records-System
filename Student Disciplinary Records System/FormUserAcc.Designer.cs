namespace Student_Disciplinary_Records_System
{
    partial class FormUserAcc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserAcc));
            this.labelHello = new System.Windows.Forms.Label();
            this.labelUserType = new System.Windows.Forms.Label();
            this.txtuserName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colView = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtfname = new System.Windows.Forms.TextBox();
            this.txtmname = new System.Windows.Forms.TextBox();
            this.txtlname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChangeProfile = new System.Windows.Forms.Button();
            this.btnChangePW = new System.Windows.Forms.Button();
            this.btnaddnew = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbRoleFilter = new System.Windows.Forms.ComboBox();
            this.btnBrowsIMG = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelUsernameIndicator = new System.Windows.Forms.Label();
            this.labelCurrentUsername = new System.Windows.Forms.Label();
            this.hindipatakenLABEL = new System.Windows.Forms.Label();
            this.speciallabel = new System.Windows.Forms.Label();
            this.picimage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHello
            // 
            this.labelHello.AutoSize = true;
            this.labelHello.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHello.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelHello.Location = new System.Drawing.Point(297, 24);
            this.labelHello.Name = "labelHello";
            this.labelHello.Size = new System.Drawing.Size(268, 34);
            this.labelHello.TabIndex = 1;
            this.labelHello.Text = "Hello, AllenJames!";
            this.labelHello.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelUserType
            // 
            this.labelUserType.AutoSize = true;
            this.labelUserType.Font = new System.Drawing.Font("Arial", 12F);
            this.labelUserType.ForeColor = System.Drawing.Color.SlateGray;
            this.labelUserType.Location = new System.Drawing.Point(822, 28);
            this.labelUserType.Name = "labelUserType";
            this.labelUserType.Size = new System.Drawing.Size(101, 18);
            this.labelUserType.TabIndex = 2;
            this.labelUserType.Text = "Administrator";
            // 
            // txtuserName
            // 
            this.txtuserName.Enabled = false;
            this.txtuserName.Font = new System.Drawing.Font("Arial", 9F);
            this.txtuserName.Location = new System.Drawing.Point(363, 97);
            this.txtuserName.Name = "txtuserName";
            this.txtuserName.Size = new System.Drawing.Size(219, 21);
            this.txtuserName.TabIndex = 3;
            this.txtuserName.TextChanged += new System.EventHandler(this.txtuserName_TextChanged);
            this.txtuserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtuserName_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(112)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(112)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.colView,
            this.colEdit,
            this.colDelete});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 317);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(919, 220);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "#";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 37;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "USERNAME";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "PASSWORD";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "LAST NAME";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "FIRST NAME";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "MIDDLE NAME";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "ROLE";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 65;
            // 
            // colView
            // 
            this.colView.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colView.HeaderText = "";
            this.colView.Image = ((System.Drawing.Image)(resources.GetObject("colView.Image")));
            this.colView.Name = "colView";
            this.colView.ReadOnly = true;
            this.colView.Width = 5;
            // 
            // colEdit
            // 
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEdit.HeaderText = "";
            this.colEdit.Image = ((System.Drawing.Image)(resources.GetObject("colEdit.Image")));
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Width = 5;
            // 
            // colDelete
            // 
            this.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDelete.HeaderText = "";
            this.colDelete.Image = ((System.Drawing.Image)(resources.GetObject("colDelete.Image")));
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Width = 5;
            // 
            // txtfname
            // 
            this.txtfname.Enabled = false;
            this.txtfname.Font = new System.Drawing.Font("Arial", 9F);
            this.txtfname.Location = new System.Drawing.Point(363, 128);
            this.txtfname.Name = "txtfname";
            this.txtfname.Size = new System.Drawing.Size(219, 21);
            this.txtfname.TabIndex = 5;
            // 
            // txtmname
            // 
            this.txtmname.Enabled = false;
            this.txtmname.Font = new System.Drawing.Font("Arial", 9F);
            this.txtmname.Location = new System.Drawing.Point(363, 159);
            this.txtmname.Name = "txtmname";
            this.txtmname.Size = new System.Drawing.Size(219, 21);
            this.txtmname.TabIndex = 6;
            // 
            // txtlname
            // 
            this.txtlname.Enabled = false;
            this.txtlname.Font = new System.Drawing.Font("Arial", 9F);
            this.txtlname.Location = new System.Drawing.Point(363, 190);
            this.txtlname.Name = "txtlname";
            this.txtlname.Size = new System.Drawing.Size(219, 21);
            this.txtlname.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8F);
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(304, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8F);
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(304, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8F);
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(290, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "Middle Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8F);
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(300, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Last Name";
            // 
            // btnChangeProfile
            // 
            this.btnChangeProfile.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnChangeProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeProfile.FlatAppearance.BorderSize = 0;
            this.btnChangeProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeProfile.ForeColor = System.Drawing.Color.White;
            this.btnChangeProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeProfile.Location = new System.Drawing.Point(741, 89);
            this.btnChangeProfile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnChangeProfile.Name = "btnChangeProfile";
            this.btnChangeProfile.Size = new System.Drawing.Size(190, 37);
            this.btnChangeProfile.TabIndex = 32;
            this.btnChangeProfile.Text = "CHANGE PROFILE";
            this.btnChangeProfile.UseVisualStyleBackColor = false;
            this.btnChangeProfile.Click += new System.EventHandler(this.btnChangeProfile_Click);
            // 
            // btnChangePW
            // 
            this.btnChangePW.BackColor = System.Drawing.Color.SlateGray;
            this.btnChangePW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePW.FlatAppearance.BorderSize = 0;
            this.btnChangePW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePW.ForeColor = System.Drawing.Color.White;
            this.btnChangePW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePW.Location = new System.Drawing.Point(741, 143);
            this.btnChangePW.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnChangePW.Name = "btnChangePW";
            this.btnChangePW.Size = new System.Drawing.Size(190, 37);
            this.btnChangePW.TabIndex = 40;
            this.btnChangePW.Text = "CHANGE PASSWORD";
            this.btnChangePW.UseVisualStyleBackColor = false;
            this.btnChangePW.Click += new System.EventHandler(this.btnChangePW_Click_1);
            // 
            // btnaddnew
            // 
            this.btnaddnew.BackColor = System.Drawing.Color.White;
            this.btnaddnew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnaddnew.FlatAppearance.BorderSize = 0;
            this.btnaddnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddnew.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnaddnew.Image = ((System.Drawing.Image)(resources.GetObject("btnaddnew.Image")));
            this.btnaddnew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnaddnew.Location = new System.Drawing.Point(687, 279);
            this.btnaddnew.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnaddnew.Name = "btnaddnew";
            this.btnaddnew.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnaddnew.Size = new System.Drawing.Size(245, 28);
            this.btnaddnew.TabIndex = 41;
            this.btnaddnew.Text = "        CREATE NEW USER ACCOUNT";
            this.btnaddnew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnaddnew.UseVisualStyleBackColor = false;
            this.btnaddnew.Click += new System.EventHandler(this.btnaddnew_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(9, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 43;
            this.label5.Text = "Filter By ROLE:";
            // 
            // cmbRoleFilter
            // 
            this.cmbRoleFilter.FormattingEnabled = true;
            this.cmbRoleFilter.Items.AddRange(new object[] {
            "ALL",
            "Administrator",
            "Instructor"});
            this.cmbRoleFilter.Location = new System.Drawing.Point(111, 287);
            this.cmbRoleFilter.Name = "cmbRoleFilter";
            this.cmbRoleFilter.Size = new System.Drawing.Size(121, 24);
            this.cmbRoleFilter.TabIndex = 42;
            this.cmbRoleFilter.TextChanged += new System.EventHandler(this.cmbRoleFilter_TextChanged);
            this.cmbRoleFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbRoleFilter_KeyPress);
            // 
            // btnBrowsIMG
            // 
            this.btnBrowsIMG.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnBrowsIMG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowsIMG.Enabled = false;
            this.btnBrowsIMG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowsIMG.Font = new System.Drawing.Font("Arial", 9F);
            this.btnBrowsIMG.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBrowsIMG.Location = new System.Drawing.Point(42, 221);
            this.btnBrowsIMG.Name = "btnBrowsIMG";
            this.btnBrowsIMG.Size = new System.Drawing.Size(190, 25);
            this.btnBrowsIMG.TabIndex = 39;
            this.btnBrowsIMG.Text = "BROWSE IMAGE";
            this.btnBrowsIMG.UseVisualStyleBackColor = false;
            this.btnBrowsIMG.Visible = false;
            this.btnBrowsIMG.Click += new System.EventHandler(this.btnBrowsIMG_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 9F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(363, 221);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 25);
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btncancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncancel.Enabled = false;
            this.btncancel.FlatAppearance.BorderSize = 0;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Arial", 9F);
            this.btncancel.ForeColor = System.Drawing.Color.White;
            this.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncancel.Location = new System.Drawing.Point(481, 221);
            this.btncancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btncancel.Name = "btncancel";
            this.btncancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btncancel.Size = new System.Drawing.Size(100, 25);
            this.btncancel.TabIndex = 30;
            this.btncancel.Text = "CANCEL";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Visible = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelUsernameIndicator
            // 
            this.labelUsernameIndicator.AutoSize = true;
            this.labelUsernameIndicator.Font = new System.Drawing.Font("Arial", 8F);
            this.labelUsernameIndicator.ForeColor = System.Drawing.Color.Red;
            this.labelUsernameIndicator.Location = new System.Drawing.Point(583, 99);
            this.labelUsernameIndicator.Name = "labelUsernameIndicator";
            this.labelUsernameIndicator.Size = new System.Drawing.Size(120, 14);
            this.labelUsernameIndicator.TabIndex = 44;
            this.labelUsernameIndicator.Text = "This username is taken!";
            this.labelUsernameIndicator.Visible = false;
            // 
            // labelCurrentUsername
            // 
            this.labelCurrentUsername.AutoSize = true;
            this.labelCurrentUsername.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCurrentUsername.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelCurrentUsername.Location = new System.Drawing.Point(302, 61);
            this.labelCurrentUsername.Name = "labelCurrentUsername";
            this.labelCurrentUsername.Size = new System.Drawing.Size(76, 15);
            this.labelCurrentUsername.TabIndex = 51;
            this.labelCurrentUsername.Text = "@username";
            this.labelCurrentUsername.Visible = false;
            // 
            // hindipatakenLABEL
            // 
            this.hindipatakenLABEL.AutoSize = true;
            this.hindipatakenLABEL.Font = new System.Drawing.Font("Arial", 8F);
            this.hindipatakenLABEL.ForeColor = System.Drawing.Color.Green;
            this.hindipatakenLABEL.Location = new System.Drawing.Point(582, 99);
            this.hindipatakenLABEL.Name = "hindipatakenLABEL";
            this.hindipatakenLABEL.Size = new System.Drawing.Size(136, 14);
            this.hindipatakenLABEL.TabIndex = 52;
            this.hindipatakenLABEL.Text = "This username is available!";
            this.hindipatakenLABEL.Visible = false;
            // 
            // speciallabel
            // 
            this.speciallabel.AutoSize = true;
            this.speciallabel.Font = new System.Drawing.Font("Arial", 8F);
            this.speciallabel.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.speciallabel.Location = new System.Drawing.Point(585, 98);
            this.speciallabel.Name = "speciallabel";
            this.speciallabel.Size = new System.Drawing.Size(148, 14);
            this.speciallabel.TabIndex = 53;
            this.speciallabel.Text = "must be at least 5 characters";
            this.speciallabel.Visible = false;
            // 
            // picimage
            // 
            this.picimage.Enabled = false;
            this.picimage.Location = new System.Drawing.Point(42, 21);
            this.picimage.Name = "picimage";
            this.picimage.Size = new System.Drawing.Size(190, 190);
            this.picimage.TabIndex = 0;
            this.picimage.TabStop = false;
            // 
            // FormUserAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(943, 549);
            this.ControlBox = false;
            this.Controls.Add(this.speciallabel);
            this.Controls.Add(this.hindipatakenLABEL);
            this.Controls.Add(this.labelCurrentUsername);
            this.Controls.Add(this.labelUsernameIndicator);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbRoleFilter);
            this.Controls.Add(this.btnaddnew);
            this.Controls.Add(this.btnChangePW);
            this.Controls.Add(this.btnBrowsIMG);
            this.Controls.Add(this.btnChangeProfile);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtlname);
            this.Controls.Add(this.txtmname);
            this.Controls.Add(this.txtfname);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtuserName);
            this.Controls.Add(this.labelUserType);
            this.Controls.Add(this.labelHello);
            this.Controls.Add(this.picimage);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormUserAcc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormUserAcc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelHello;
        private System.Windows.Forms.Label labelUserType;
        private System.Windows.Forms.TextBox txtuserName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtfname;
        private System.Windows.Forms.TextBox txtmname;
        private System.Windows.Forms.TextBox txtlname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnChangeProfile;
        private System.Windows.Forms.Button btnChangePW;
        private System.Windows.Forms.Button btnaddnew;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbRoleFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewImageColumn colView;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
        private System.Windows.Forms.Button btnBrowsIMG;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelUsernameIndicator;
        private System.Windows.Forms.Label labelCurrentUsername;
        private System.Windows.Forms.Label hindipatakenLABEL;
        private System.Windows.Forms.Label speciallabel;
        private System.Windows.Forms.PictureBox picimage;
    }
}