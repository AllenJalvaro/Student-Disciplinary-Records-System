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
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Student_Disciplinary_Records_System
{
    public partial class FormAYdetails : Form
    {

        private FormAY parentForm;
        public FormAYdetails(FormAY parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        DBConnect conn = new DBConnect();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        MySqlDataReader dr;

        public Button BtnSave
        {
            get { return btnsave; }
            set { btnsave = value; }
        }

        private void UpdateAYCode()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtyearfrom.Text) || cmbSem.SelectedItem != null)
                {
                    txtyearto.Text = (long.Parse(txtyearfrom.Text) + 1).ToString();
                    txtaycode.Text = $"{txtyearfrom.Text}-{txtyearto.Text} {cmbSem.SelectedItem}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtyearfrom_TextChanged(object sender, EventArgs e)
        {
            UpdateAYCode();
        }

        private void txtyearfrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

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

                conn.Connect();
                string sql = "UPDATE acadyear SET status='CLOSED'";
                cmd = new MySqlCommand(sql, conn.con);
                cmd.ExecuteNonQuery();
                conn.Disconnect();

                if (string.IsNullOrWhiteSpace(txtyearfrom.Text) || string.IsNullOrWhiteSpace(cmbSem.Text))
                {
                    MessageBox.Show("All fields are required!", "REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                conn.Connect();
                string query = "INSERT INTO acadyear(ay_id, year1, year2, semester) VALUES(@ay_id, @year1, @year2, @semester)";
                cmd = new MySqlCommand(query, conn.con);
                cmd.Parameters.AddWithValue("@ay_id", txtaycode.Text.Trim());
                cmd.Parameters.AddWithValue("@year1", txtyearfrom.Text.Trim());
                cmd.Parameters.AddWithValue("@year2", txtyearto.Text.Trim());
                cmd.Parameters.AddWithValue("@semester", cmbSem.Text.Trim());
                cmd.ExecuteNonQuery();
                conn.Disconnect();
                btnsave.Enabled = true;
                parentForm.LoadTable();
                MessageBox.Show($"{txtaycode.Text.Trim()} has been successfully added!", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();

            }
            catch (Exception ex)
            {
                conn.Disconnect();
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAYCode();
        }

        private void FormAYdetails_Load(object sender, EventArgs e)
        {

        }
    }
}
