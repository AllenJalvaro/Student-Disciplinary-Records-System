using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using ImageSharpImage = SixLabors.ImageSharp.Image;



namespace Student_Disciplinary_Records_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ApplyCircularShape(PictureBox pictureBox)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            Region region = new Region(path);
            pictureBox.Region = region;
        }

        DBConnect conn = new DBConnect();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        public Label UsernameLABEL
        {
            get { return usernameLABEL; }
            set { usernameLABEL = value; }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ApplyCircularShape(picimage);
            conn.Connect();

            string query = "SELECT * FROM user";
            cmd = new MySqlCommand(query, conn.con);
            da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);


            conn.Disconnect();


            picimage.Visible = true;
            usernameLABEL.Visible = true;
            label2.Visible = true;
            FormHome formHome = new FormHome();
            formHome.TopLevel = false;
            changingPanel.Controls.Add(formHome);
            formHome.BringToFront();
            formHome.Show();

            label2.Text = SharedData.SharedRole;

            using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1; port=3306; username=root; database=studentdisciplinaryrecordssystemdb; charset=utf8"))
            {
                conn.Open();

                using (MySqlCommand cm = new MySqlCommand("SELECT image FROM user WHERE username=@username LIMIT 1", conn))
                {
                    cm.Parameters.AddWithValue("@username", SharedData.SharedUsername);

                    using (MySqlDataReader dr = cm.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            if (dr.HasRows)
                            {
                                long len = dr.GetBytes(0, 0, null, 0, 0);
                                byte[] array = new byte[len];
                                dr.GetBytes(0, 0, array, 0, (int)len);

                                using (MemoryStream ms = new MemoryStream(array))
                                {
                                    var image = ImageSharpImage.Load(ms);
                                    var resizedImage = image.Clone(x => x.Resize(new ResizeOptions
                                    {
                                        Size = new SixLabors.ImageSharp.Size(picimage.Width, picimage.Height),
                                        Mode = ResizeMode.Max
                                    }));

                                    using (MemoryStream resizedMs = new MemoryStream())
                                    {
                                        resizedImage.Save(resizedMs, new JpegEncoder()); // You may need to choose the appropriate encoder

                                        // Convert the MemoryStream to a byte array
                                        byte[] resizedArray = resizedMs.ToArray();

                                        // Convert the byte array to a Bitmap
                                        using (MemoryStream bitmapMs = new MemoryStream(resizedArray))
                                        {
                                            picimage.BackgroundImage = new Bitmap(bitmapMs);
                                        }
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

        private void btnProgram_Click(object sender, EventArgs e)
        {
            picimage.Visible = true;
            FormProgram formProgram = new FormProgram();

            formProgram.TopLevel = false;
            changingPanel.Controls.Add(formProgram);
            formProgram.BringToFront();
            formProgram.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to exit the application\nThis will log out your account?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            picimage.Visible = true;
            FormBlock formBlock = new FormBlock();

            formBlock.TopLevel = false;
            changingPanel.Controls.Add(formBlock);
            formBlock.BringToFront();
            formBlock.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            picimage.Visible = true;
            FormAY formAY = new FormAY();

            formAY.TopLevel = false;
            changingPanel.Controls.Add(formAY);
            formAY.BringToFront();
            formAY.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            picimage.Visible = true;
            FormStudentList frmStudentList = new FormStudentList();

            frmStudentList.TopLevel = false;
            changingPanel.Controls.Add(frmStudentList);
            frmStudentList.BringToFront();
            frmStudentList.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            picimage.Visible = true;
            FormViolation formViolation = new FormViolation();

            formViolation.TopLevel = false;
            changingPanel.Controls.Add(formViolation);
            formViolation.BringToFront();
            formViolation.Txtacadyear.Text = conn.GetAYcode();
            formViolation.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            picimage.Visible = true;
            FormRecords formRecords = new FormRecords();

            formRecords.TopLevel = false;
            changingPanel.Controls.Add(formRecords);
            formRecords.BringToFront();
            formRecords.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picimage.Visible = true;
            usernameLABEL.Visible = true;
            label2.Visible = true;
            FormHome formHome = new FormHome();
            formHome.TopLevel = false;
            changingPanel.Controls.Add(formHome);
            formHome.BringToFront();
            formHome.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            picimage.Visible = false;
            FormUserAcc formUserAcc = new FormUserAcc();
            formUserAcc.UsernameLABEL.Text = $"Hello, {usernameLABEL.Text}";
            formUserAcc.TopLevel = false;
            changingPanel.Controls.Add(formUserAcc);
            formUserAcc.BringToFront();
            formUserAcc.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to log out?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                FormLogin formLogin = new FormLogin();
                this.Dispose();
                formLogin.Show();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
