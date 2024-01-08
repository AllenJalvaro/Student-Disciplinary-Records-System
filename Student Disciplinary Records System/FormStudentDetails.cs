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
    public partial class FormStudentDetails : Form
    {
        private FormStudentList parentForm;
        public FormStudentDetails(FormStudentList parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        DBConnect conn = new DBConnect();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        MySqlDataReader dr;
        String pcode;
        String stuid;
        public string Stuid
        {
            get { return stuid; }
            set { stuid = value; }
        }
        public ComboBox CmbBlock
        {
            get { return cmbBlock; }
            set { cmbBlock = value; }
        }

        public ComboBox CmbProgram
        {
            get { return cmbProgram; }
            set { cmbProgram = value; }
        }

        public PictureBox Picimage
        {
            get { return picimage; }
            set { picimage = value; }
        }

        public TextBox txtNo
        {
            get { return txtstudid; }
            set { txtstudid = value; }
        }

        public TextBox txtLname
        {
            get { return txtlname; }
            set { txtlname = value; }
        }

        public TextBox txtFname
        {
            get { return txtfname; }
            set { txtfname = value; }
        }

        public TextBox txtMname
        {
            get { return txtmname; }
            set { txtmname = value; }
        }

        public TextBox txtAddress
        {
            get { return txtaddress; }
            set { txtaddress = value; }
        }

        public TextBox txtContactno
        {
            get { return txtcontact; }
            set { txtcontact = value; }
        }

        public Button BtnSave
        {
            get { return btnsave; }
            set { btnsave = value; }
        }
        public Button BtnUpdate
        {
            get { return btnupdate; }
            set { btnupdate = value; }
        }

        public Button BtnCancel
        {
            get { return btncancel; }
            set { btncancel = value; }
        }

        public Button BtnImage
        {
            get { return button1; }
            set { button1 = value; }
        }
        
        private void txtfieldsClear()
        {
            txtaddress.Clear();
            txtcontact.Clear();
            txtfname.Clear();
            txtmname.Clear();
            txtlname.Clear();
            txtstudid.Clear();
            cmbBlock.Text = "";
            cmbProgram.Text = "";

            try
            {
                picimage.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "emptyprofile.png"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            txtstudid.Enabled = true;
            btnsave.Visible = true;
            btnupdate.Visible = false;
        }
        private void ApplyCircularShape(PictureBox pictureBox)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            Region region = new Region(path);
            pictureBox.Region = region;
        }
        private void FormStudentDetails_Load(object sender, EventArgs e)
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

            try
            {
                cmbProgram.Items.Clear();
                cmbBlock.Items.Clear();

                LoadPrograms();
                LoadBlocks();
                if (btnsave.Visible==true)
                {
                    cmbBlock.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Disconnect();
            }
        }

        private void LoadPrograms()
        {
            cmbProgram.Items.Clear();
            conn.Connect();
            string query = "SELECT * FROM program order by program_id";
            using (MySqlCommand cmd1 = new MySqlCommand(query, conn.con))
            {
                using (MySqlDataReader dr1 = cmd1.ExecuteReader())
                {
                    while (dr1.Read())
                    {
                        cmbProgram.Items.Add(dr1["program_id"].ToString() + " (" + dr1["program_description"].ToString() + ")");
                    }
                }
            }

            Console.WriteLine("ZZZZZZZ: " + cmbProgram.Text);
            if (btnsave.Visible == true)
            {
                cmbBlock.Text = "";
            }
            else
            {
            if (cmbBlock.Items.Contains(parentForm.getProgID()))
            {
                cmbBlock.SelectedItem = parentForm.getProgID();

            }

            }
            Console.WriteLine("YYYYYYY: " + cmbProgram.Text);
            //string dd = cmbProgram.Text;
            //cmbProgram.Text = dd;

            //if (parentForm.getCmbProgramText() == "All Programs")
            //{

            //    cmbProgram.Text = "";
            //}
            //else
            //{
            //    cmbProgram.Text = parentForm.getCmbProgramText();
            //}

            conn.Disconnect();
        }

        private void LoadBlocks()
        {

            cmbBlock.Items.Clear();
            Console.WriteLine("AAAAAAAA: "+cmbProgram.Text);
            Console.WriteLine("BBBBBBBB: " + cmbBlock.Text);
            string input = parentForm.getProgID();
            string pcode = input.Split(' ')[0];

            conn.Connect();
            string query3 = "SELECT * FROM block where program_id=@program_id ORDER BY block.block, block.yearlevel";
            using (MySqlCommand cmd3 = new MySqlCommand(query3, conn.con))
            {
                cmd3.Parameters.AddWithValue("@program_id", pcode);
                using (MySqlDataReader dr3 = cmd3.ExecuteReader())
                {
                    while (dr3.Read())
                    {
                        cmbBlock.Items.Add(dr3["block"].ToString());
                    }
                }
            }
            string query4 = "SELECT * FROM student_view where student_id=@student_id";
            using (MySqlCommand cmd4 = new MySqlCommand(query4, conn.con))
            {
                cmd4.Parameters.AddWithValue("@student_id", parentForm.getStuID());
               // cmd4.Parameters.AddWithValue("@prog_id", pcode);
                using (MySqlDataReader dr4 = cmd4.ExecuteReader())
                {
                    if (dr4.Read())
                    {
                        if (cmbBlock.Items.Contains(dr4["bloc"].ToString()))
                        {
                            if (btnsave.Visible == true)
                            {
                                cmbBlock.Text = "";
                            }
                            else
                            {
                                cmbBlock.SelectedItem = dr4["bloc"].ToString();
                            }
                        }
                    }
                }
            }
            //string cc = cmbBlock.Text;
            //cmbBlock.Text = cc;
            Console.WriteLine("BBBBBBBB: " + cmbBlock.Text);

            conn.Disconnect();
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                int block_id = 0;
                string _yearlevel = "";
                conn.Connect();

                string sql = "SELECT block.block_id, block.yearlevel FROM block JOIN program ON block.program_id = program.program_id WHERE block.block = @block AND program.program_id = @program_id";
                cmd = new MySqlCommand(sql, conn.con);
                cmd.Parameters.AddWithValue("@block", cmbBlock.Text);
                cmd.Parameters.AddWithValue("@program_id", cmbProgram.Text.Split(' ')[0]);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["block_id"] != DBNull.Value)
                    {
                        block_id = Convert.ToInt32(dr["block_id"]);
                        _yearlevel = dr["yearlevel"].ToString();
                    }
                }

                dr.Close();


                conn.Disconnect();

                System.IO.MemoryStream mstream = new System.IO.MemoryStream();
                picimage.BackgroundImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arrImage = mstream.GetBuffer();


                if (string.IsNullOrWhiteSpace(txtaddress.Text) || string.IsNullOrWhiteSpace(txtcontact.Text) || string.IsNullOrWhiteSpace(txtfname.Text) || string.IsNullOrWhiteSpace(txtmname.Text) || string.IsNullOrWhiteSpace(txtlname.Text) || string.IsNullOrWhiteSpace(txtstudid.Text) || string.IsNullOrWhiteSpace(cmbBlock.Text) || string.IsNullOrWhiteSpace(cmbProgram.Text))
                {
                    MessageBox.Show("All fields are required!", "REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                conn.Connect();
                string query = "INSERT INTO student VALUES(@student_id, @lname, @fname, @mname, @blockid, @address, @contactno, @pic)";
                cmd = new MySqlCommand(query, conn.con);
                cmd.Parameters.AddWithValue("@student_id", txtstudid.Text.Trim());
                cmd.Parameters.AddWithValue("@lname", txtlname.Text.Trim());
                cmd.Parameters.AddWithValue("@fname", txtfname.Text.Trim());
                cmd.Parameters.AddWithValue("@mname", txtmname.Text.Trim());
                cmd.Parameters.AddWithValue("@blockid", block_id);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text.Trim());
                cmd.Parameters.AddWithValue("@contactno", txtcontact.Text.Trim());
                cmd.Parameters.AddWithValue("@pic", arrImage);
                cmd.ExecuteNonQuery();
                conn.Disconnect();
                parentForm.CmbProgramText = cmbProgram.Text.Split(' ')[0];
                parentForm.CmbYearLevelText = _yearlevel.Trim();
                parentForm.CmbBlockText = cmbBlock.Text.Trim();
                parentForm.LoadTable();
                MessageBox.Show($"'{txtfname.Text} {txtlname.Text}' has been successfully added!", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtfieldsClear();

            }
            catch (Exception ex)
            {
                conn.Disconnect();
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProgram_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbBlock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbBlock_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbProgram.SelectedItem = cmbProgram.Text;
                cmbBlock.Items.Clear();
                cmbBlock.Text = "";
                conn.Connect();


                string input = cmbProgram.Text;
                string pcode = input.Split(' ')[0];
                string query = "SELECT * FROM block where program_id=@program_id";
                cmd = new MySqlCommand(query, conn.con);
                cmd.Parameters.AddWithValue("@program_id", pcode);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmbBlock.Items.Add(dr["block"].ToString());
                }

                dr.Close();

                conn.Disconnect();

            }
            catch (Exception ex)
            {
                conn.Disconnect();
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtaddress.Text) || string.IsNullOrWhiteSpace(txtcontact.Text) || string.IsNullOrWhiteSpace(txtfname.Text) || string.IsNullOrWhiteSpace(txtmname.Text) || string.IsNullOrWhiteSpace(txtlname.Text) || string.IsNullOrWhiteSpace(txtstudid.Text) || string.IsNullOrWhiteSpace(cmbBlock.Text) || string.IsNullOrWhiteSpace(cmbProgram.Text))
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
                    int block_id = 0;
                    string _yearlevel = "";
                    conn.Connect();

                    string sql = "SELECT block.block_id, block.yearlevel FROM block JOIN program ON block.program_id = program.program_id WHERE block.block = @block AND program.program_id = @program_id";
                    cmd = new MySqlCommand(sql, conn.con);
                    cmd.Parameters.AddWithValue("@block", cmbBlock.Text);
                    cmd.Parameters.AddWithValue("@program_id", cmbProgram.Text.Split(' ')[0]);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr["block_id"] != DBNull.Value)
                        {
                            block_id = Convert.ToInt32(dr["block_id"]);
                            _yearlevel = dr["yearlevel"].ToString();
                        }
                    }

                    dr.Close();


                    conn.Disconnect();

                    System.IO.MemoryStream mstream = new System.IO.MemoryStream();
                    picimage.BackgroundImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] arrImage = mstream.GetBuffer();




                    conn.Connect();
                    string query = "";
                    if (openFileDialog1.FileName != "openFileDialog1")
                    {
                        query = "UPDATE student set lastname=@lname, firstname=@fname, middlename=@mname, block_id=@blockid, address=@address, contactno=@contactno, image=@pic where student_id=@student_id";
                    }
                    else
                    {
                        query = "UPDATE student set lastname=@lname, firstname=@fname, middlename=@mname, block_id=@blockid, address=@address, contactno=@contactno where student_id=@student_id";

                    }

                    cmd = new MySqlCommand(query, conn.con);
                    cmd.Parameters.AddWithValue("@lname", txtlname.Text.Trim());
                    cmd.Parameters.AddWithValue("@fname", txtfname.Text.Trim());
                    cmd.Parameters.AddWithValue("@mname", txtmname.Text.Trim());
                    cmd.Parameters.AddWithValue("@blockid", block_id);
                    cmd.Parameters.AddWithValue("@address", txtaddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@contactno", txtcontact.Text.Trim());
                    if (openFileDialog1.FileName != "openFileDialog1")
                    {
                        cmd.Parameters.AddWithValue("@pic", arrImage);
                    }
                    cmd.Parameters.AddWithValue("@student_id", txtstudid.Text.Trim());
                    cmd.ExecuteNonQuery();
                    conn.Disconnect();
                    parentForm.CmbProgramText = cmbProgram.Text.Split(' ')[0];
                    parentForm.CmbYearLevelText = _yearlevel.Trim();
                    parentForm.CmbBlockText = cmbBlock.Text.Trim();
                    parentForm.LoadTable();
                    MessageBox.Show($"'{txtfname.Text} {txtlname.Text}' has been successfully updated!", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtfieldsClear();
                    this.Dispose();

                }
                catch (Exception ex)
                {
                    conn.Disconnect();
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }








        }

        private void cmbProgram_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
