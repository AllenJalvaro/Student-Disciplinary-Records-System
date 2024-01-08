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
    public partial class FormProgramDetails : Form
    {
        private FormProgram parentForm;
        public FormProgramDetails(FormProgram parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        DBConnect conn = new DBConnect();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        MySqlDataReader dr;

        public TextBox Txtpcode
        {
            get { return txtpcode; }
            set { txtpcode = value; }
        }

        public TextBox Txtpdesc
        {
            get { return txtpdesc; }
            set { txtpdesc = value; }
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
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtpcode.Text) || string.IsNullOrWhiteSpace(txtpdesc.Text))
                {
                    MessageBox.Show("All fields are required!", "REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                conn.Connect();
                string query = "INSERT INTO program VALUES(@program_id, @program_description)";
                cmd = new MySqlCommand(query, conn.con);
                cmd.Parameters.AddWithValue("@program_id", txtpcode.Text.Trim());
                cmd.Parameters.AddWithValue("@program_description", txtpdesc.Text.Trim());
                cmd.ExecuteNonQuery();
                conn.Disconnect();
                txtpcode.Enabled = true;
                btnsave.Enabled = true;
                btnupdate.Visible = false;
                parentForm.LoadTable();
                MessageBox.Show($"{txtpcode.Text.Trim()} has been successfully added!", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtpcode.Clear();
                txtpdesc.Clear();

            }
            catch (Exception ex)
            {
                conn.Disconnect();
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtpcode.Text) || string.IsNullOrWhiteSpace(txtpdesc.Text))
            {
                MessageBox.Show("All fields are required!", "REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            conn.Connect();
                string pcode = parentForm.pcodeSt;
                DialogResult result = MessageBox.Show($"Are you sure you want to save changes for {pcode}?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {

                        string query = "UPDATE program SET program_id=@program_id, program_description=@program_description WHERE program_id=@program_idp";
                        cmd = new MySqlCommand(query, conn.con);
                        cmd.Parameters.AddWithValue("@program_id", txtpcode.Text.Trim());
                        cmd.Parameters.AddWithValue("@program_description", txtpdesc.Text.Trim());
                        cmd.Parameters.AddWithValue("@program_idp", pcode);
                        cmd.ExecuteNonQuery();
                        conn.Disconnect();
                        txtpcode.Enabled = true;
                        btnsave.Enabled = true;
                        btnupdate.Visible = false;
                        parentForm.LoadTable();
                        MessageBox.Show("The record has been successfully updated!", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtpcode.Clear();
                        txtpdesc.Clear();
                        this.Dispose();

                    }
                    catch (Exception ex)
                    {
                        conn.Disconnect();
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
