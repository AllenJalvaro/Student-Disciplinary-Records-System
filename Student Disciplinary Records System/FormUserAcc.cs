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
using static System.Collections.Specialized.BitVector32;

namespace Student_Disciplinary_Records_System
{
    public partial class FormUserAcc : Form
    {
        public FormUserAcc()
        {
            InitializeComponent();
        }


        private void LoadAndDisplayUserImageFromDatabase(string username)
        {
            using (MySqlConnection connection = new MySqlConnection("server=127.0.0.1; port=3306; username=root; database=studentdisciplinaryrecordssystemdb; charset=utf8"))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand("SELECT * FROM user WHERE username=@username LIMIT 1", connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                byte[] imageBytes = (byte[])reader["image"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    Bitmap bitmap = new Bitmap(ms);
                                    picimage.BackgroundImage = bitmap;
                                }
                            }
                        }
                        else
                        {
                            reader.Close();
                        }
                    }
                }
            }
        }







        DBConnect conn = new DBConnect();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        MySqlDataReader dr;
        string usernameO = "";
        public string getUserNameO()
        {
            return usernameO;
        }

        public Label UsernameLABEL
        {
            get { return labelHello; }
            set { labelHello = value; }
        }
        public void LoadTable()
        {
            this.dataGridView1.Rows.Clear();
            conn.Connect();
            string query = "";
            if (cmbRoleFilter.Text == "ALL")
            {
                query = "SELECT * FROM user WHERE username!=@loggedUser";
                cmd = new MySqlCommand(query, conn.con);
                cmd.Parameters.AddWithValue("@loggedUser", SharedData.SharedUsername);

            }
            else if (cmbRoleFilter.Text == "Administrator")
            {

                query = "SELECT * FROM user where role=@role and username!=@loggedUser";
                cmd = new MySqlCommand(query, conn.con);
                cmd.Parameters.AddWithValue("@role", cmbRoleFilter.Text.Trim());
                cmd.Parameters.AddWithValue("@loggedUser", SharedData.SharedUsername);
            }
            else if (cmbRoleFilter.Text == "Instructor")
            {

                query = "SELECT * FROM user where role=@role and username!=@loggedUser";
                cmd = new MySqlCommand(query, conn.con);
                cmd.Parameters.AddWithValue("@role", cmbRoleFilter.Text.Trim());
                cmd.Parameters.AddWithValue("@loggedUser", SharedData.SharedUsername);
            }


            dr = cmd.ExecuteReader();
            int i = 0;

            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(
                    i,
                    dr["username"].ToString(),
                    dr["password"].ToString(),
                    dr["lastname"].ToString(),
                    dr["firstname"].ToString(),
                    dr["middlename"].ToString(),
                    dr["role"].ToString());
            }

            dr.Close();


            conn.Disconnect();
        }

        private void ApplyCircularShape(PictureBox pictureBox)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            Region region = new Region(path);
            pictureBox.Region = region;
        }

        private void InitializeFormComponents()
        {
            //ApplyCircularShape(picimage);

            //if ((picimage.BackgroundImage == null) || (picimage.BackgroundImage == Image.FromFile(Path.Combine(Application.StartupPath, "emptyprofile.png"))))
            //{
            //    try
            //    {
            //        picimage.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "emptyprofile.png"));
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

          //  ApplyCircularShape(picimage);

            btnUpdate.Visible = false;
            btncancel.Visible = false;
            btnBrowsIMG.Visible = false;
            txtuserName.ReadOnly = true;
            txtfname.ReadOnly = true;
            txtmname.ReadOnly = true;
            txtlname.ReadOnly = true;
            cmbRoleFilter.SelectedIndex = 0;
            LoadTable();
            labelHello.Text = SharedData.SharedFirstname + "!";
            labelUserType.Text = SharedData.SharedRole;
            txtuserName.Text = SharedData.SharedUsername;
            labelCurrentUsername.Text = "@" + SharedData.SharedUsername;
            txtfname.Text = SharedData.SharedFirstname;
            txtmname.Text = SharedData.SharedMiddlename;
            txtlname.Text = SharedData.SharedLastname;
        }

        private void FormUserAcc_Load(object sender, EventArgs e)
        {

            InitializeFormComponents();
            //LoadAndDisplayUserImageFromDatabase(SharedData.SharedUsername);


        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {

            FormCreateNewAccount formCreateNewAccount = new FormCreateNewAccount(this);
            //formProgramDetails.BtnSave.Enabled = true;
            //formProgramDetails.BtnUpdate.Visible = false;
            formCreateNewAccount.ShowDialog();
        }

        private void cmbRoleFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "PASSWORD")
            {
                if (e.Value != null)
                {
                    string password = e.Value.ToString();
                    e.Value = new string('•', password.Length);
                }
            }
        }

        private void cmbRoleFilter_TextChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = "";
                string usernameTXT = "";
                if (e.RowIndex >= 0)
                {
                    colName = dataGridView1.Columns[e.ColumnIndex].Name;
                    usernameTXT = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
                Console.WriteLine("HEREEEE: " + colName);
                if (colName == "colView")
                {
                    using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1; port=3306; username=root; database=studentdisciplinaryrecordssystemdb; charset=utf8"))
                    {
                        conn.Open();

                        using (MySqlCommand cm = new MySqlCommand("SELECT * FROM user WHERE username=@username LIMIT 1", conn))
                        {
                            cm.Parameters.AddWithValue("@username", usernameTXT);

                            using (MySqlDataReader dr = cm.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    if (dr.HasRows)
                                    {

                                        using (FormCreateNewAccount formCreateNewAccount = new FormCreateNewAccount(this))
                                        {
                                            byte[] imageBytes = (byte[])dr["image"];
                                            using (MemoryStream ms = new MemoryStream(imageBytes))
                                            {
                                                Bitmap bitmap = new Bitmap(ms);
                                                formCreateNewAccount.Usernametxt.Text = dr["username"].ToString();
                                                formCreateNewAccount.Passwtxt.Text = dr["password"].ToString();
                                                formCreateNewAccount.Lnametxt.Text = dr["lastname"].ToString();
                                                formCreateNewAccount.Fnametxt.Text = dr["firstname"].ToString();
                                                formCreateNewAccount.Mnametxt.Text = dr["middlename"].ToString();
                                                formCreateNewAccount.Rolecmb.Text = dr["role"].ToString();
                                                formCreateNewAccount.Picimage.BackgroundImage = bitmap;
                                                formCreateNewAccount.Btn1.Visible = false;
                                                formCreateNewAccount.BtnSaveACC.Visible = false;
                                                formCreateNewAccount.LabelTitle.Text = "VIEW USER ACCOUNT DETAILS";
                                                formCreateNewAccount.LabelConfirmPassword.Visible = false;
                                                formCreateNewAccount.LabelmatchIndicator.Visible = false;
                                                formCreateNewAccount.LabelmatchIndicator2.Visible = false;
                                                formCreateNewAccount.LabelUsernameIndicator.Visible = false;
                                                formCreateNewAccount.Yesdia = false;

                                                formCreateNewAccount.YesHideEye = false;
                                                formCreateNewAccount.Rolecmb.Enabled = false;
                                                formCreateNewAccount.TxtPWconfirm.Visible = false;
                                                formCreateNewAccount.BtnHIDEpwConfirm.Visible = false;
                                                formCreateNewAccount.BtnSeePWconfirm.Visible = false;
                                                formCreateNewAccount.Fnametxt.ReadOnly = true;
                                                formCreateNewAccount.Lnametxt.ReadOnly = true;
                                                formCreateNewAccount.Mnametxt.ReadOnly = true;
                                                formCreateNewAccount.Passwtxt.ReadOnly = true;
                                                formCreateNewAccount.Usernametxt.ReadOnly = true;

                                                formCreateNewAccount.ShowDialog();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    dr.Close();
                                }
                            }
                        }
                    }
                }
                else if (colName == "colEdit")
                {
                    using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1; port=3306; username=root; database=studentdisciplinaryrecordssystemdb; charset=utf8"))
                    {
                        conn.Open();

                        using (MySqlCommand cm = new MySqlCommand("SELECT * FROM user WHERE username=@username LIMIT 1", conn))
                        {
                            cm.Parameters.AddWithValue("@username", usernameTXT);

                            using (MySqlDataReader dr = cm.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    if (dr.HasRows)
                                    {

                                        using (FormCreateNewAccount formCreateNewAccount = new FormCreateNewAccount(this))
                                        {
                                            byte[] imageBytes = (byte[])dr["image"];
                                            using (MemoryStream ms = new MemoryStream(imageBytes))
                                            {
                                                Bitmap bitmap = new Bitmap(ms);
                                                formCreateNewAccount.Usernametxt.Text = dr["username"].ToString();
                                                usernameO = dr["username"].ToString();
                                                formCreateNewAccount.Passwtxt.Text = dr["password"].ToString();
                                                formCreateNewAccount.Lnametxt.Text = dr["lastname"].ToString();
                                                formCreateNewAccount.Fnametxt.Text = dr["firstname"].ToString();
                                                formCreateNewAccount.Mnametxt.Text = dr["middlename"].ToString();
                                                formCreateNewAccount.Rolecmb.Text = dr["role"].ToString();
                                                formCreateNewAccount.Picimage.BackgroundImage = bitmap;
                                                formCreateNewAccount.BtnSaveACC.Text = "UPDATE ACCOUNT";
                                                formCreateNewAccount.LabelTitle.Text = "EDIT USER ACCOUNT DETAILS";

                                                formCreateNewAccount.Yesdia = true;

                                                formCreateNewAccount.YesHideEye = true;



                                                formCreateNewAccount.ShowDialog();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    dr.Close();
                                }
                            }
                        }
                    }
                }
                else if (colName == "colDelete")
                {
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete this account of {usernameTXT}?\nThis action will permanently remove all records associated with this user account and cannot be undone.", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            conn.Connect();
                            string query = $"DELETE from user WHERE username='{usernameTXT}'";
                            cmd = new MySqlCommand(query, conn.con);
                            cmd.ExecuteNonQuery();
                            LoadTable();
                            MessageBox.Show("User Account has been deleted successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btncancel_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you to cancel the update?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                btnUpdate.Visible = false;
                btncancel.Visible = false;
                btnBrowsIMG.Visible = false;
                txtuserName.ReadOnly = true;
                txtfname.ReadOnly = true;
                txtmname.ReadOnly = true;
                txtlname.ReadOnly = true;
                this.Dispose();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtfname.Text) || string.IsNullOrWhiteSpace(txtlname.Text) || string.IsNullOrWhiteSpace(txtuserName.Text) || string.IsNullOrWhiteSpace(txtmname.Text))
            {
                MessageBox.Show("All fields are required!", "REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            conn.Connect();
            DialogResult result = MessageBox.Show($"Are you sure you want to save changes for '{txtfname.Text} {txtlname.Text}'?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {


                    //System.IO.MemoryStream mstream = new System.IO.MemoryStream();
                    //picimage.BackgroundImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //byte[] arrImage = mstream.GetBuffer();




                    conn.Connect();
                    string query = "";
                    if (openFileDialog1.FileName != "openFileDialog1")
                    {
                        query = "UPDATE user set lastname=@lname, firstname=@fname, middlename=@mname, image=@pic where username=@username";
                    }
                    else
                    {
                        query = "UPDATE user set lastname=@lname, firstname=@fname, middlename=@mname where username=@username";

                    }

                    cmd = new MySqlCommand(query, conn.con);
                    cmd.Parameters.AddWithValue("@lname", txtlname.Text.Trim());
                    cmd.Parameters.AddWithValue("@fname", txtfname.Text.Trim());
                    cmd.Parameters.AddWithValue("@mname", txtmname.Text.Trim());
                    //if (openFileDialog1.FileName != "openFileDialog1")
                    //{
                    //    cmd.Parameters.AddWithValue("@pic", arrImage);
                    //}
                    cmd.Parameters.AddWithValue("@username", txtuserName.Text.Trim());
                    cmd.ExecuteNonQuery();
                    conn.Disconnect();

                    SharedData.SharedFirstname = txtlname.Text.Trim();
                   SharedData.SharedUsername = txtuserName.Text.Trim();
                    SharedData.SharedFirstname = txtfname.Text.Trim();
                   SharedData.SharedMiddlename = txtmname.Text.Trim();
                    SharedData.SharedLastname = txtlname.Text.Trim();

                    btnUpdate.Visible = false;
                    btncancel.Visible = false;
                    btnBrowsIMG.Visible = false;
                    txtuserName.ReadOnly = true;
                    txtfname.ReadOnly = true;
                    txtmname.ReadOnly = true;
                    txtlname.ReadOnly = true;
                    btnChangeProfile.Visible = true;
                    this.Refresh();
                    MessageBox.Show($"Your profile has been successfully updated!", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    conn.Disconnect();
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnChangeProfile_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            btncancel.Visible = true;
            btnBrowsIMG.Visible = true;
            txtuserName.ReadOnly = false;
            txtfname.ReadOnly = false;
            txtmname.ReadOnly = false;
            txtlname.ReadOnly = false;
            this.btnChangeProfile.Visible = false;
        }

       
        private const long MaxFileSizeBytes = 16 * 1024 * 1024;
        private void btnBrowsIMG_Click(object sender, EventArgs e)
        {
            // using (OpenFileDialog ofd = new OpenFileDialog())
            //{
            //    ofd.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            //    ofd.Multiselect = false;

            //    if (ofd.ShowDialog() == DialogResult.OK)
            //    {
            //        string selectedFilePath = ofd.FileName;
            //        FileInfo fileInfo = new FileInfo(selectedFilePath);
            //        if (fileInfo.Length <= MaxFileSizeBytes)
            //        {
            //            picimage.BackgroundImage = Image.FromFile(selectedFilePath);
            //            openFileDialog1.FileName = selectedFilePath;
            //        }
            //        else
            //        {
            //            MessageBox.Show($"The selected image exceeds the maximum allowed size of {MaxFileSizeBytes / (1024 * 1024)} MB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }

       

        private void txtuserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void btnChangePW_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }


        private void userNamecheck()
        {
            string username = txtuserName.Text.Trim();

            conn.Connect();

            try
            {
                string query = "SELECT COUNT(*) FROM user WHERE username = @username  AND username!=@currentUsername";
                using (MySqlCommand cmd = new MySqlCommand(query, conn.con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@currentUsername", SharedData.SharedUsername);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        labelUsernameIndicator.Visible = true;

                    }
                    else if(count==0 && username!= SharedData.SharedUsername)
                    {
                        hindipatakenLABEL.Visible = true;
                    }
                    else
                    {
                        hindipatakenLABEL.Visible = false;
                        labelUsernameIndicator.Visible = false;
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

        private void txtuserName_TextChanged(object sender, EventArgs e)
        {
            if (txtuserName.ReadOnly==false)
            {

                userNamecheck();

                if (txtuserName.Text.Length < 5)
                {

                    speciallabel.Visible = true;
                }
                if (txtuserName.Text.Length >= 5)
                {
                    speciallabel.Visible = false;
                }
                if (string.IsNullOrWhiteSpace(txtuserName.Text))
                {

                    speciallabel.Visible = false;
                    hindipatakenLABEL.Visible = false;
                    labelUsernameIndicator.Visible = false;
                }
            }
        }
    }
}
