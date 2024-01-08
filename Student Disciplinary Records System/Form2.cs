using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Student_Disciplinary_Records_System
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        DBConnect conn = new DBConnect();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlDataReader dr;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel the password update?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                this.Dispose();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel the password update?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                this.Dispose();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.btnseePW.Visible = true;
            this.btnseePW.BringToFront();
            this.btnSeePWconfirm.Visible = true;
            this.btnSeePWconfirm.BringToFront();
            oldpassTXT.PasswordChar = '•';
            newpassTXT.PasswordChar = '•';
            confirmPassTXT.PasswordChar = '•';
        }

        private void btnseePW_Click(object sender, EventArgs e)
        {
            this.btnseePW.Visible = false;
            this.btnHIDEpw.Visible = true;
            this.btnHIDEpw.BringToFront();

            newpassTXT.PasswordChar = '\0';
        }

        private void btnHIDEpw_Click(object sender, EventArgs e)
        {
            this.btnseePW.Visible = true;
            this.btnseePW.BringToFront();
            this.btnHIDEpw.Visible = false;

            newpassTXT.PasswordChar = '•';
        }

        private void btnSeePWconfirm_Click(object sender, EventArgs e)
        {
            this.btnSeePWconfirm.Visible = false;
            this.btnHIDEpwConfirm.Visible = true;
            this.btnHIDEpwConfirm.BringToFront();

            confirmPassTXT.PasswordChar = '\0';
        }

        private void btnHIDEpwConfirm_Click(object sender, EventArgs e)
        {

            this.btnSeePWconfirm.Visible = true;
            this.btnSeePWconfirm.BringToFront();
            this.btnHIDEpwConfirm.Visible = false;

            confirmPassTXT.PasswordChar = '•';
        }

        private void btnOldpassHIDE_Click(object sender, EventArgs e)
        {
            this.btnSeePWconfirm.Visible = true;
            this.btnSeePWconfirm.BringToFront();
            this.btnHIDEpwConfirm.Visible = false;

            oldpassTXT.PasswordChar = '•';
        }

        private void btnoldpassSEE_Click(object sender, EventArgs e)
        {
            this.btnSeePWconfirm.Visible = false;
            this.btnHIDEpwConfirm.Visible = true;
            this.btnHIDEpwConfirm.BringToFront();

            oldpassTXT.PasswordChar = '\0';
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(oldpassTXT.Text) || string.IsNullOrWhiteSpace(newpassTXT.Text) ||
                    string.IsNullOrWhiteSpace(confirmPassTXT.Text))
            {
                MessageBox.Show("All fields are required!", "REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (oldpassTXT.Text != SharedData.SharedPassword)
            {
                MessageBox.Show("Password does not match the old one!!", "INVALID OLD PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            DialogResult result = MessageBox.Show($"Are you sure you want to change your password'?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    conn.Connect();
                    string query = $"UPDATE user set password=@password WHERE username={SharedData.SharedUsername}";
                    cmd = new MySqlCommand(query, conn.con);
                    cmd.Parameters.AddWithValue("@password", newpassTXT.Text);
                    cmd.ExecuteNonQuery();
                    conn.Disconnect();
                    MessageBox.Show("Your password has been successfully updated!", "UPDATED PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                catch (Exception ex)
                {
                    conn.Disconnect();
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void oldpassTXT_TextChanged(object sender, EventArgs e)
        {
            if (oldpassTXT.Text != SharedData.SharedPassword)
            {
                hindiItoYonLabel.Visible = true;
                label3.Visible = false;
            }
            else if (oldpassTXT.Text == SharedData.SharedPassword)
            {
                hindiItoYonLabel.Visible = false;
                label3.Visible = true;
            }

            if (string.IsNullOrWhiteSpace(oldpassTXT.Text))
            {
                hindiItoYonLabel.Visible = false;
                label3.Visible = false;
            }
        }

        private void newpassTXT_TextChanged(object sender, EventArgs e)
        {
            if (newpassTXT.Text.Length <5)
            {
                kulangLABEL.Visible = true;
            }
            else
            {
                kulangLABEL.Visible = false;
            }
            if (string.IsNullOrWhiteSpace(newpassTXT.Text))
            {
                kulangLABEL.Visible = false;
            }
        }

        private void confirmPassTXT_TextChanged(object sender, EventArgs e)
        {
            if (confirmPassTXT.Text != newpassTXT.Text)
            {
                donotmatchLABEL.Visible = true;
                matchNaLABEL.Visible = false;
            }
            else if (confirmPassTXT.Text == newpassTXT.Text)
            {
                donotmatchLABEL.Visible = false;
                matchNaLABEL.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(confirmPassTXT.Text))
            {
                donotmatchLABEL.Visible = false;
                matchNaLABEL.Visible = false;
            }
        }

        private void oldpassTXT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void newpassTXT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void confirmPassTXT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
    }
}
