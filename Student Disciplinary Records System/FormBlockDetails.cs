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
    public partial class FormBlockDetails : Form
    {

        private FormBlock parentForm;
        public FormBlockDetails(FormBlock parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }


        DBConnect conn = new DBConnect();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        MySqlDataReader dr;


        public TextBox Txtblock
        {
            get { return txtblock; }
            set { txtblock = value; }
        }

        public ComboBox CmbProgram
        {
            get { return cmbProgram; }
            set { cmbProgram = value; }
        }

        public ComboBox CmbYearLevel
        {
            get { return cmbYearLevel; }
            set { cmbYearLevel = value; }
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

        private void FormBlockDetails_Load(object sender, EventArgs e)
        {
            cmbProgram.Items.Clear();

            conn.Connect();
            string query = "SELECT * FROM program";
            cmd = new MySqlCommand(query, conn.con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbProgram.Items.Add(dr["program_id"].ToString() + " (" + dr["program_description"].ToString()+")");
            }
            dr.Close();


            string query2 = "SELECT * FROM program where program_id=@program_id";
            cmd = new MySqlCommand(query2, conn.con);
            cmd.Parameters.AddWithValue("@program_id", parentForm.getCmbProgramText());
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cmbProgram.Text= dr["program_id"].ToString() + " (" + dr["program_description"].ToString() + ")";
            }
            dr.Close();

            string query3 = "SELECT program.*, yearlevel FROM program, block where block.program_id=program.program_id and block.program_id=@program_id and yearlevel=@yearlevel";
            cmd = new MySqlCommand(query3, conn.con);
            cmd.Parameters.AddWithValue("@program_id", parentForm.getCmbProgramText());
            cmd.Parameters.AddWithValue("@yearlevel", parentForm.getCmbYearLevelText());
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cmbYearLevel.Text = dr["yearlevel"].ToString();
            }
            dr.Close();
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtblock.Text) || string.IsNullOrWhiteSpace(cmbProgram.Text) || string.IsNullOrWhiteSpace(cmbYearLevel.Text))
                {
                    MessageBox.Show("All fields are required!", "REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string input = cmbProgram.Text;
                string pcode = input.Split(' ')[0];
                conn.Connect();
                string query = "INSERT INTO block VALUES(NULL, @block, @yearlevel, @program_id)";
                cmd = new MySqlCommand(query, conn.con);
                cmd.Parameters.AddWithValue("@block", txtblock.Text.Trim());
                cmd.Parameters.AddWithValue("@yearlevel", cmbYearLevel.Text.Trim());
                cmd.Parameters.AddWithValue("@program_id", pcode);
                cmd.ExecuteNonQuery();
                conn.Disconnect();
                txtblock.Enabled = true;
                btnsave.Enabled = true;
                btnupdate.Visible = false;
                parentForm.CmbProgramText = pcode;
                parentForm.CmbYearLevelText = cmbYearLevel.Text.Trim();
                parentForm.LoadTable();
                MessageBox.Show($"{txtblock.Text.Trim()} has been successfully added!", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtblock.Clear();
                cmbYearLevel.Text = "";
                if (parentForm.getCmbProgramText()=="All Programs")
                {
                cmbProgram.Text = "";
                    cmbYearLevel.Text = "";

                }

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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtblock.Text) || string.IsNullOrWhiteSpace(cmbProgram.Text) || string.IsNullOrWhiteSpace(CmbYearLevel.Text))
            {
                MessageBox.Show("All fields are required!", "REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            conn.Connect();
            string block_id = parentForm.Blockid;
            DialogResult result = MessageBox.Show($"Are you sure you want to save changes for this record?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string input = cmbProgram.Text;
                    string pcode = input.Split(' ')[0];
                    string query = "UPDATE block SET block=@block, yearlevel=@yearlevel, program_id=@program_id WHERE block_id=@block_id";
                    cmd = new MySqlCommand(query, conn.con);
                    cmd.Parameters.AddWithValue("@block", txtblock.Text.Trim());
                    cmd.Parameters.AddWithValue("@yearlevel", cmbYearLevel.Text.Trim());
                    cmd.Parameters.AddWithValue("@program_id", pcode);
                    cmd.Parameters.AddWithValue("@block_id", block_id);
                    cmd.ExecuteNonQuery();
                    conn.Disconnect();
                    txtblock.Enabled = true;
                    btnsave.Enabled = true;
                    btnupdate.Visible = false;
                    parentForm.CmbProgramText = pcode;
                    parentForm.LoadTable();
                    MessageBox.Show("The record has been successfully updated!", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtblock.Clear();
                    cmbProgram.Text = "";
                    cmbYearLevel.Text = "";
                    this.Dispose();

                }
                catch (Exception ex)
                {
                    conn.Disconnect();
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void cmbYearLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
