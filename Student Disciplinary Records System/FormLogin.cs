
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Student_Disciplinary_Records_System
{
    public partial class FormLogin : Form
    {
        private string username = "", password = "";
        DBConnect conn = new DBConnect();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;
        public FormLogin()
        {
            InitializeComponent();
            ApplyRoundedCorners(textBox1);
            ApplyRoundedCorners(textBox2);
            ApplyRoundedCorners(button1);
        }

        private void ApplyRoundedCorners(Control control)
        {
            int radius = 10;
            int offset = 10;

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius + offset, radius + offset, 180, 90);
            path.AddArc(control.Width - radius - offset, 0, radius + offset, radius + offset, 270, 90);
            path.AddArc(control.Width - radius - offset, control.Height - radius - offset, radius + offset, radius + offset, 0, 90);
            path.AddArc(0, control.Height - radius - offset, radius + offset, radius + offset, 90, 90);

            control.Region = new Region(path);
        }

        private void UpdateButtonState()
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
            button1.BackColor = button1.Enabled ? Color.White : Color.Gray;
            button1.ForeColor = button1.Enabled ? Color.FromArgb(29, 96, 140) : Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Connect();
                string query = "SELECT count(*), user.* FROM user WHERE username = @username and password=@password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn.con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    string userr = "";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        userr = dr["username"].ToString();

                        SharedData.SharedUsername = dr["username"].ToString();
                        SharedData.SharedLastname = dr["lastname"].ToString();
                        SharedData.SharedMiddlename = dr["middlename"].ToString();
                        SharedData.SharedPassword = dr["password"].ToString();
                        SharedData.SharedFirstname = dr["firstname"].ToString();
                        SharedData.SharedRole = dr["role"].ToString();

                    }
                    dr.Close();
                    if (count == 1)
                    {

                        Form1 form1 = new Form1();
                        form1.UsernameLABEL.Text = userr;

                        form1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sorry, the entered username or password is incorrect. Please try again.", "INVALID USERNAME OR PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                conn.Disconnect();
            }
            catch (Exception ex)
            {
                conn.Disconnect();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadUserData(MySqlCommand cmd)
        {
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    SharedData.SharedUsername = dr["username"].ToString();
                    SharedData.SharedLastname = dr["lastname"].ToString();
                    SharedData.SharedMiddlename = dr["middlename"].ToString();
                    SharedData.SharedPassword = dr["password"].ToString();
                    SharedData.SharedFirstname = dr["firstname"].ToString();
                    SharedData.SharedRole = dr["role"].ToString();
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            username = textBox1.Text;
            Array.Clear(Encoding.UTF8.GetBytes(username), 0, Encoding.UTF8.GetBytes(username).Length);


            UpdateButtonState();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox2.Text;
            Array.Clear(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetBytes(password).Length);

            UpdateButtonState();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}
