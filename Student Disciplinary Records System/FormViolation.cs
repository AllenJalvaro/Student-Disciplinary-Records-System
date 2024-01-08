using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Student_Disciplinary_Records_System
{
    public partial class FormViolation : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private DataTable studentDataTable;

        public FormViolation()
        {
            InitializeComponent();
            txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
        }


        DBConnect conn = new DBConnect();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlDataReader dr;
        DataTable dt = new DataTable();
        string _user = "admin";
        string vcode = "";
        public TextBox Txtacadyear
        {
            get { return txtacadyear; }
            set { txtacadyear = value; }
        }

        public void LoadTable()
        {
            this.dataGridView1.Rows.Clear();
            conn.Connect();
            string query = "SELECT v.violation_id, v.student_id, s.fullname, s.prog_id, s.bloc, v.ay_id, v.sdate, v.violation_desc, v.violation_type, v.penalty, v.user from violation as v, student_view as s WHERE s.student_id = v.student_id AND v.student_id like @studentno AND ay_id like @aycode";
            cmd = new MySqlCommand(query, conn.con);
            cmd.Parameters.AddWithValue("@studentno", txtstudid.Text.Trim());
            cmd.Parameters.AddWithValue("@aycode", txtacadyear.Text.Trim());
            int i = 0;
            using (dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    i++;
                    dataGridView1.Rows.Add(
                        i,
                        dr["violation_id"].ToString(),
                        dr["violation_desc"].ToString(),
                        dr["violation_type"].ToString(),
                        dr["penalty"].ToString(),
                        FormatDate(dr["sdate"]),
                        dr["user"].ToString()); ;
                }
            }
            conn.Disconnect();

        }

        private string FormatDate(object dateValue)
        {
            if (dateValue != DBNull.Value)
            {
                DateTime rawDateTime = Convert.ToDateTime(dateValue);
                return rawDateTime.ToString("d MMM yyyy, h:mm tt");
            }
            return string.Empty;
        }

        private void LoadStudentData()
        {
            using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1; port=3306; username=root; database=studentdisciplinaryrecordssystemdb; charset=utf8"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT fullname FROM student_view", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                studentDataTable = new DataTable();
                da.Fill(studentDataTable);
                conn.Close();
            }
        }

        private void AutosuggestStudent()
        {

            try
            {
                if (studentDataTable != null)
                {
                    string searchTerm = txtSearch.Text.ToLower();
                    var matchingNames = studentDataTable.AsEnumerable()
                        .Select(row => row.Field<string>("fullname"))
                        .Where(name => name.ToLower().Contains(searchTerm))
                        .Distinct();

                    AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                    col.AddRange(matchingNames.ToArray());

                    txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtSearch.AutoCompleteCustomSource = col;
                    txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        private void FormViolation_Load(object sender, EventArgs e)
        {
            btnsave.Visible = false;
            btnUpdate.Visible = false;
            btncancel.Visible = false;
            txtviolation.Enabled = false;
            cmbtypeviolation.Enabled = false;
            cmbpenalty.Enabled = false;
            LoadStudentData();
            AutosuggestStudent();
           
        }

        private void allClear()
        {
            txtname.Clear();
            txtprogram.Clear();
            txtstudid.Clear();
            txtviolation.Clear();
            txtblock.Clear();
            cmbpenalty.Text = "";
            cmbtypeviolation.Text = "";

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
                conn.Connect();
                string query = "SELECT s.*, f.fnamelname FROM student_view as s, fnamlnam as f where fullname = @fullname and s.student_id=f.student_id";
                cmd = new MySqlCommand(query, conn.con);
                cmd.Parameters.AddWithValue("@fullname", txtSearch.Text);
                using (dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        if (dr.HasRows)
                        {
                            txtstudid.Text = dr["student_id"].ToString();
                            txtname.Text = dr["fullname"].ToString();
                            txtRecordOf.Text = dr["fnamelname"].ToString() + "'s Disciplinary Records during the A.Y. " + txtacadyear.Text;
                            txtprogram.Text = dr["prog_id"].ToString();
                            txtblock.Text = dr["bloc"].ToString();

                            conn.Disconnect();

                            LoadTable();

                        }
                        else
                        {
                            allClear();
                            conn.Disconnect();
                        }
                    }

                }
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {

                    txtRecordOf.Text = "";
                    allClear();
                    dataGridView1.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                conn.Disconnect();

            }

        }

        private void cmbtypeviolation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtviolation.Text) || string.IsNullOrWhiteSpace(cmbtypeviolation.Text) || string.IsNullOrWhiteSpace(cmbpenalty.Text) || string.IsNullOrWhiteSpace(txtstudid.Text))
                {
                    MessageBox.Show("All fields are required!", "REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show($"Are you sure you want to save this disciplinary record?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {



                    conn.Connect();
                    string query = "INSERT INTO violation(student_id, ay_id, violation_desc, penalty, violation_type, user) VALUES(@student_id, @ay_id, @violation_desc, @penalty, @violation_type, @user)";
                    cmd = new MySqlCommand(query, conn.con);
                    cmd.Parameters.AddWithValue("@student_id", txtstudid.Text.Trim());
                    cmd.Parameters.AddWithValue("@ay_id", txtacadyear.Text.Trim());
                    cmd.Parameters.AddWithValue("@violation_desc", txtviolation.Text.Trim());
                    cmd.Parameters.AddWithValue("@penalty", cmbpenalty.Text.Trim());
                    cmd.Parameters.AddWithValue("@violation_type", cmbtypeviolation.Text.Trim());
                    cmd.Parameters.AddWithValue("@user", _user.Trim());
                    cmd.ExecuteNonQuery();
                    conn.Disconnect();
                    LoadTable();
                    MessageBox.Show("A disciplinary record has been successfully added!", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtviolation.Clear();
                    cmbpenalty.Text = "";
                    cmbtypeviolation.Text = "";


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

            if (string.IsNullOrWhiteSpace(txtviolation.Text) && string.IsNullOrWhiteSpace(cmbtypeviolation.Text) && string.IsNullOrWhiteSpace(cmbpenalty.Text))
            {
                return;
            }
            DialogResult result = MessageBox.Show($"Are you sure you want to cancel?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {

                allClear();
                txtSearch.Clear();
                LoadTable();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                vcode = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            if (e.ColumnIndex == dataGridView1.Columns["colEdit"].Index && e.RowIndex >= 0)
            {

                btnsave.Visible = false;
                btnUpdate.Visible = true;
                string originalText = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                int indexx = originalText.IndexOf(" [last edited by");
                if (indexx != -1)
                {
                    txtviolation.Text = originalText.Substring(0, indexx);
                }
                else
                {
                    txtviolation.Text = originalText;
                }
                cmbtypeviolation.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                cmbpenalty.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            }



        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtviolation.Text) || string.IsNullOrWhiteSpace(cmbtypeviolation.Text) || string.IsNullOrWhiteSpace(cmbpenalty.Text))
            {
                MessageBox.Show("All fields are required!", "REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            conn.Connect();
            DialogResult result = MessageBox.Show($"Are you sure you want to update this disciplinary record?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {

                    string query = "UPDATE violation SET violation_desc=@violation_desc,  penalty=@penalty, violation_type=@violation_type WHERE violation_id=@violation_id";
                    cmd = new MySqlCommand(query, conn.con);

                    cmd.Parameters.AddWithValue("@violation_desc", txtviolation.Text.Trim() + " [last edited by " + _user + " on " + FormatDate(DateTime.Now) + "]");
                    cmd.Parameters.AddWithValue("@penalty", cmbpenalty.Text.Trim());
                    cmd.Parameters.AddWithValue("@violation_type", cmbtypeviolation.Text.Trim());
                    cmd.Parameters.AddWithValue("@violation_id", vcode);
                    cmd.ExecuteNonQuery();
                    conn.Disconnect();
                    btnsave.Visible = true;
                    btnUpdate.Visible = false;
                    LoadTable();
                    MessageBox.Show("The record has been successfully updated!", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtviolation.Clear();
                    cmbtypeviolation.Text = "";
                    cmbpenalty.Text = "";

                }
                catch (Exception ex)
                {
                    conn.Disconnect();
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void txtstudid_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtstudid.Text))
            {
                btnsave.Visible = false;
                btnUpdate.Visible = false;
                btncancel.Visible = false;
                txtviolation.Enabled = false;
                cmbtypeviolation.Enabled = false;
                cmbpenalty.Enabled = false;
            }
            else
            {
                btnsave.Visible = true;
                btnUpdate.Visible = true;
                btncancel.Visible = true;
                txtviolation.Enabled = true;
                cmbtypeviolation.Enabled = true;
                cmbpenalty.Enabled = true;
                txtviolation.Clear();
                cmbpenalty.Text = "";
                cmbtypeviolation.Text = "";
            }
        }
    }




}
