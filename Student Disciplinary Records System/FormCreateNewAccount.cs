using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Student_Disciplinary_Records_System
{
    public partial class FormCreateNewAccount : Form
    {

        private FormUserAcc parentForm;
        public FormCreateNewAccount(FormUserAcc parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }

        DBConnect conn = new DBConnect();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        MySqlDataReader dr;


        public TextBox Usernametxt
        {
            get { return txtUsername; }
            set { txtUsername = value; }
        }

        public TextBox Passwtxt
        {
            get { return txtPW; }
            set { txtPW = value; }
        }

        public TextBox Lnametxt
        {
            get { return txtlastname; }
            set { txtlastname = value; }
        }

        public TextBox Fnametxt
        {
            get { return txtfirstname; }
            set { txtfirstname = value; }
        }
        public TextBox Mnametxt
        {
            get { return txtmidname; }
            set { txtmidname = value; }
        }
        public TextBox TxtPWconfirm
        {
            get { return txtPWconfirm; }
            set { txtPWconfirm = value; }
        }

        public ComboBox Rolecmb
        {
            get { return cmbRoleType; }
            set { cmbRoleType = value; }
        }


        public PictureBox Picimage
        {
            get { return picimage; }
            set { picimage = value; }
        }

        public Button Btn1
        {
            get { return button1; }
            set { button1 = value; }
        }

        public Button BtnSaveACC
        {
            get { return btnSaveAcc; }
            set { btnSaveAcc = value; }
        }

        public Button BtnHIDEpwConfirm
        {
            get { return btnHIDEpwConfirm; }
            set { btnHIDEpwConfirm = value; }
        }

        public Button BtnSeePWconfirm
        {
            get { return btnSeePWconfirm; }
            set { btnSeePWconfirm = value; }
        }
        public Label LabelUsernameIndicator
        {
            get { return labelUsernameIndicator; }
            set { labelUsernameIndicator = value; }
        }

        public Label LabelTitle
        {
            get { return label1; }
            set { label1 = value; }
        }
        public Label LabelmatchIndicator
        {
            get { return labelmatchIndicator; }
            set { labelmatchIndicator = value; }
        }

        public Label LabelmatchIndicator2
        {
            get { return labelmatchIndicator2; }
            set { labelmatchIndicator2 = value; }
        }
        public Label LabelConfirmPassword
        {
            get { return label8; }
            set { label8 = value; }
        }
        public bool Yesdia
        {
            get { return yesDia; }
            set { yesDia = value; }
        }

        public bool YesHideEye
        {
            get { return yesHideEye; }
            set { yesHideEye = value; }
        }
        bool yesDia = true;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(cmbRoleType.Text) && string.IsNullOrWhiteSpace(txtfirstname.Text) &&
                string.IsNullOrWhiteSpace(txtmidname.Text) &&
                string.IsNullOrWhiteSpace(txtlastname.Text) &&
                string.IsNullOrWhiteSpace(txtUsername.Text) &&
                string.IsNullOrWhiteSpace(txtPW.Text) &&
                string.IsNullOrWhiteSpace(txtPWconfirm.Text))
            {
                this.Dispose();
            }
            else
            {

                if (yesDia)
                {

                    DialogResult result = MessageBox.Show($"Are you sure you want to cancel?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (result == DialogResult.Yes)
                    {
                        this.Dispose();
                    }
                }
                else
                {
                    this.Dispose();
                    yesDia = true;
                }
            }
        }

        private void btnseePW_Click(object sender, EventArgs e)
        {
            this.btnseePW.Visible = false;
            this.btnHIDEpw.Visible = true;
            this.btnHIDEpw.BringToFront();

            txtPW.PasswordChar = '\0';
        }

        private void btnHIDEpw_Click(object sender, EventArgs e)
        {
            this.btnseePW.Visible = true;
            this.btnseePW.BringToFront();
            this.btnHIDEpw.Visible = false;

            txtPW.PasswordChar = '•';
        }

        private void btnSeePWconfirm_Click(object sender, EventArgs e)
        {
            this.btnSeePWconfirm.Visible = false;
            this.btnHIDEpwConfirm.Visible = true;
            this.btnHIDEpwConfirm.BringToFront();

            txtPWconfirm.PasswordChar = '\0';
        }

        private void btnHIDEpwConfirm_Click(object sender, EventArgs e)
        {

            this.btnSeePWconfirm.Visible = true;
            this.btnSeePWconfirm.BringToFront();
            this.btnHIDEpwConfirm.Visible = false;

            txtPWconfirm.PasswordChar = '•';
        }

        bool yesHideEye = true;
        private void ApplyCircularShape(PictureBox pictureBox)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            Region region = new Region(path);
            pictureBox.Region = region;
        }
        private void FormCreateNewAccount_Load(object sender, EventArgs e)
        {
            ApplyCircularShape(picimage);
            if ((picimage.BackgroundImage == null) || (picimage.BackgroundImage == Image.FromFile(Path.Combine(Application.StartupPath, "emptyprofile.png"))))
            {
                try
                {
                    picimage.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "emptyprofile.png"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.btnseePW.Visible = true;
            this.btnseePW.BringToFront();
            this.btnSeePWconfirm.Visible = true;
            this.btnSeePWconfirm.BringToFront();
            txtPW.PasswordChar = '•';
            txtPWconfirm.PasswordChar = '•';
            this.btnSaveAcc.Enabled = false;
            if (!yesHideEye)
            {

                this.btnSeePWconfirm.Visible = false;
                this.BtnHIDEpwConfirm.Visible = false;
            }
            if (btnSaveAcc.Text== "UPDATE ACCOUNT")
            {
                labelUsernameIndicator.Visible = false;
                labelCurrentUsername.Text = $"Current Username: {parentForm.getUserNameO()}";
                labelCurrentUsername.Visible = true;
            }
        }

        private void btnSaveAcc_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSaveAcc.Text == "CREATE ACOUNT")
                {

                    System.IO.MemoryStream mstream = new System.IO.MemoryStream();
                    picimage.BackgroundImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] arrImage = mstream.GetBuffer();

                    if (string.IsNullOrWhiteSpace(cmbRoleType.Text) || string.IsNullOrWhiteSpace(txtfirstname.Text) ||
                    string.IsNullOrWhiteSpace(txtmidname.Text) ||
                    string.IsNullOrWhiteSpace(txtlastname.Text) ||
                    string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtPW.Text) ||
                    string.IsNullOrWhiteSpace(txtPWconfirm.Text))
                    {
                        MessageBox.Show("All fields are required!", "REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }




                    DialogResult result = MessageBox.Show($"Are you sure you want to create account for {txtfirstname.Text.Trim()} {txtlastname.Text.Trim()}?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (result == DialogResult.Yes)
                    {
                        conn.Connect();
                        string query = "INSERT INTO user VALUES(@username, @password, @lastname, @firstname, @middlename,@role, @pic)";
                        cmd = new MySqlCommand(query, conn.con);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtPW.Text.Trim());
                        cmd.Parameters.AddWithValue("@lastname", txtlastname.Text.Trim());
                        cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text.Trim());
                        cmd.Parameters.AddWithValue("@middlename", txtmidname.Text.Trim());
                        cmd.Parameters.AddWithValue("@role", cmbRoleType.Text.Trim());
                        cmd.Parameters.AddWithValue("@pic", arrImage);
                        cmd.ExecuteNonQuery();
                        conn.Disconnect();
                        parentForm.LoadTable();
                        MessageBox.Show($"Account {txtUsername.Text.Trim()} has been successfully created!", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        allClear();
                        this.Dispose();
                    }
                }
                else if (btnSaveAcc.Text == "UPDATE ACCOUNT")
                {

                    if (string.IsNullOrWhiteSpace(cmbRoleType.Text) || string.IsNullOrWhiteSpace(txtfirstname.Text) ||
                    string.IsNullOrWhiteSpace(txtmidname.Text) ||
                    string.IsNullOrWhiteSpace(txtlastname.Text) ||
                    string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtPW.Text) ||
                    string.IsNullOrWhiteSpace(txtPWconfirm.Text))
                    {
                        MessageBox.Show("All fields are required!", "REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    conn.Connect();
                    DialogResult result = MessageBox.Show($"Are you sure you want to save changes for '{txtfirstname.Text} {txtlastname.Text}'?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            System.IO.MemoryStream mstream = new System.IO.MemoryStream();
                            picimage.BackgroundImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] arrImage = mstream.GetBuffer();



                            conn.Connect();
                            string query = "";
                            if (openFileDialog1.FileName != "openFileDialog1")
                            {
                                query = "UPDATE user set username=@usernameN, password=@password, lastname=@lastname, firstname=@firstname, middlename=@middlename, role=@role, image=@image WHERE username=@usernameO";
                            }
                            else
                            {
                                query = "UPDATE user set username=@usernameN, password=@password, lastname=@lastname, firstname=@firstname, middlename=@middlename, role=@role WHERE username=@usernameO";

                            }

                            cmd = new MySqlCommand(query, conn.con);
                            cmd.Parameters.AddWithValue("@usernameN", txtUsername.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", txtPW.Text.Trim());
                            cmd.Parameters.AddWithValue("@lastname", txtlastname.Text.Trim());
                            cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text.Trim());
                            cmd.Parameters.AddWithValue("@middlename", txtmidname.Text.Trim());
                            cmd.Parameters.AddWithValue("@role", cmbRoleType.Text.Trim());
                            if (openFileDialog1.FileName != "openFileDialog1")
                            {
                                cmd.Parameters.AddWithValue("@image", arrImage);
                            }

                          
                            
                            cmd.Parameters.AddWithValue("@usernameO", parentForm.getUserNameO());

                           
                            
                            cmd.ExecuteNonQuery();
                            conn.Disconnect();
                            parentForm.LoadTable();
                            MessageBox.Show($"User Account of '{txtfirstname.Text} {txtlastname.Text}' has been successfully updated!", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();

                        }
                        catch (Exception ex)
                        {
                            conn.Disconnect();
                            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }

            }
            catch (Exception ex)
            {
                conn.Disconnect();
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void allClear()
        {
            txtUsername.Clear();
            txtPW.Clear();
            txtPWconfirm.Clear();
            txtlastname.Clear();
            txtfirstname.Clear();
            txtmidname.Clear();
            cmbRoleType.Text = "";
        }

        private void txtPW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txtPWconfirm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void cmbRoleType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        private void userNamecheck()
        {
            string username = txtUsername.Text.Trim();

            conn.Connect();

            try
            {
                string query = "SELECT COUNT(*) FROM user WHERE username = @username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn.con))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        labelUsernameIndicator.Text = "This Username Has Been Taken!";
                        labelUsernameIndicator.ForeColor = Color.Red;
                        labelUsernameIndicator.Visible = true;

                    }
                    else
                    {
                        labelUsernameIndicator.Text = "This Username is Available!";
                        labelUsernameIndicator.ForeColor = Color.Green;
                        labelUsernameIndicator.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Disconnect();
            }
        }

        private void CheckValidationAndEnableSaveButton()
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(txtUsername.Text)
                && !string.IsNullOrWhiteSpace(txtPW.Text)
                && !string.IsNullOrWhiteSpace(txtPWconfirm.Text)
                && !string.IsNullOrWhiteSpace(txtlastname.Text)
                && !string.IsNullOrWhiteSpace(txtfirstname.Text)
                && !string.IsNullOrWhiteSpace(txtmidname.Text)
                && cmbRoleType.SelectedItem != null;

            bool isUsernameAvailable = labelUsernameIndicator.Text.Contains("Available");


            bool passwordsMatch = txtPW.Text == txtPWconfirm.Text;


            bool isPasswordLengthValid = txtPW.Text.Length >= 5;
            if (btnSaveAcc.Text == "UPDATE ACCOUNT")
            {
                labelUsernameIndicator.Visible = false;
                isUsernameAvailable = true;
            }

            btnSaveAcc.Enabled = allFieldsFilled
                && isUsernameAvailable
                && passwordsMatch
                && isPasswordLengthValid;
        }
       
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

            userNamecheck();

            if (txtUsername.Text.Length < 5)
            {
                labelUsernameIndicator.Text = "Username must be at least 5 characters";
                labelUsernameIndicator.ForeColor = Color.DarkGoldenrod;
                labelUsernameIndicator.Visible = true;
            }


            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                labelUsernameIndicator.Visible = false;
            }


            CheckValidationAndEnableSaveButton();

            if (btnSaveAcc.Text=="UPDATE ACCOUNT")
            {
                if (txtUsername.Text.Length < 5)
                {

                    speciallabel.Visible = true;
                }
                if (txtUsername.Text.Length >= 5)
                {
                    speciallabel.Visible = false;
                }
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    
                    speciallabel.Visible = false;
                }
            }
        }

        private void txtPWconfirm_TextChanged(object sender, EventArgs e)
        {

            if (txtPW.Text != txtPWconfirm.Text)
            {
                labelmatchIndicator.Text = "Passwords Do Not Match!";
                labelmatchIndicator.ForeColor = Color.Red;
                labelmatchIndicator.Visible = true;
            }
            else
            {
                labelmatchIndicator.Text = "Passwords Match!";
                labelmatchIndicator.ForeColor = Color.Green;
                labelmatchIndicator.Visible = true;
            }

            if (string.IsNullOrWhiteSpace(txtPWconfirm.Text))
            {
                labelmatchIndicator.Visible = false;
            }

            CheckValidationAndEnableSaveButton();
        }

        private void txtPW_TextChanged(object sender, EventArgs e)
        {
            if (txtPW.Text.Length < 5)
            {
                labelmatchIndicator2.Visible = true;
            }

            if (txtPW.Text.Length >= 5)
            {
                labelmatchIndicator2.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txtPW.Text))
            {
                labelmatchIndicator2.Visible = false;
            }

            CheckValidationAndEnableSaveButton();
        }

        private const long MaxFileSizeBytes = 16 * 1024 * 1024;
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = ofd.FileName;
                    FileInfo fileInfo = new FileInfo(selectedFilePath);
                    if (fileInfo.Length <= MaxFileSizeBytes)
                    {
                        picimage.BackgroundImage = Image.FromFile(selectedFilePath);
                        openFileDialog1.FileName = selectedFilePath;
                    }
                    else
                    {
                        MessageBox.Show($"The selected image exceeds the maximum allowed size of {MaxFileSizeBytes / (1024 * 1024)} MB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
    }
}
