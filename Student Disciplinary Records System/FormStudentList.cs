using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Collections.Specialized.BitVector32;

namespace Student_Disciplinary_Records_System
{
    public partial class FormStudentList : Form
    {
        public FormStudentList()
        {
            InitializeComponent();
        }
        DBConnect conn = new DBConnect();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        MySqlDataReader dr;
        String studentid;
        String _stuid = "";
        String _progid = "";
        string _program = "", _block = "", _block2 = "";
        public string CmbProgramText
        {
            get { return cmbProgram.Text; }
            set { cmbProgram.Text = value; }
        }
        public string CmbYearLevelText
        {
            get { return cmbYearLevel.Text; }
            set { cmbYearLevel.Text = value; }
        }
        public string CmbBlockText
        {
            get { return cmbBlock.Text; }
            set { cmbBlock.Text = value; }
        }

        public string getCmbProgramText()
        {
            return cmbProgram.Text;
        }
        public string getCmbYearLevelText()
        {
            return cmbYearLevel.Text;
        }
        public string getBlockText()
        {
            return cmbBlock.Text;
        }
        public string getStuID()
        {
            return _stuid;
        }
        public string getProgID()
        {
            return _progid;
        }
        public string get_block()
        {
            return _block2;
        }

        public void LoadTable()
        {
            try
            {
                this.dataGridView1.Rows.Clear();
                conn.Connect();

                string query = "SELECT student_id, lastname, firstname, middlename, block.block_id as bid, block.program_id as prog, block.block as bloc, address, contactno FROM student, block, program WHERE student.block_id = block.block_id AND block.program_id = program.program_id";

                if (cmbProgram.SelectedIndex > 0)
                {
                    query += " AND program.program_id = @program_id";
                }

                if (cmbYearLevel.SelectedIndex > 0)
                {
                    query += " AND block.yearlevel = @yearlevel";
                }

                if (cmbBlock.SelectedIndex > 0)
                {
                    query += " AND block.block = @block";
                }

                query += " ORDER BY lastname, firstname, middlename, student_id";

                cmd = new MySqlCommand(query, conn.con);

                if (cmbProgram.SelectedIndex > 0)
                {
                    cmd.Parameters.AddWithValue("@program_id", cmbProgram.Text.Trim());
                }

                if (cmbYearLevel.SelectedIndex > 0)
                {
                    cmd.Parameters.AddWithValue("@yearlevel", cmbYearLevel.Text.Trim());
                }

                if (cmbBlock.SelectedIndex > 0)
                {
                    cmd.Parameters.AddWithValue("@block", cmbBlock.Text.Trim());
                }

                dr = cmd.ExecuteReader();
                int i = 0;

                while (dr.Read())
                {
                    i++;
                    dataGridView1.Rows.Add(i, dr["student_id"].ToString(), dr["lastname"].ToString(), dr["firstname"].ToString(), dr["middlename"].ToString(), dr["bid"].ToString(), dr["prog"].ToString(), dr["bloc"].ToString(), dr["address"].ToString(), dr["contactno"].ToString());
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
        private void LoadPrograms()
        {
            cmbProgram.Items.Clear();
            cmbProgram.Items.Add("All Programs");
            cmbProgram.SelectedIndex = 0;

            try
            {
                conn.Connect();
                string query = "SELECT * FROM program";
                cmd = new MySqlCommand(query, conn.con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmbProgram.Items.Add(dr["program_id"].ToString());
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

        private void LoadYearLevels()
        {
            cmbYearLevel.Items.Clear();
            cmbYearLevel.Items.Add("All Year Levels");
            cmbYearLevel.SelectedIndex = 0;

            if (cmbProgram.SelectedIndex > 0)
            {
                try
                {
                    conn.Connect();
                    string query = "SELECT DISTINCT yearlevel FROM block WHERE program_id = @program_id";
                    cmd = new MySqlCommand(query, conn.con);
                    cmd.Parameters.AddWithValue("@program_id", cmbProgram.Text.Trim());
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        cmbYearLevel.Items.Add(dr["yearlevel"].ToString());
                    }

                    dr.Close();
                }
                catch (Exception ex)
                {
                    conn.Disconnect();
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Disconnect();
                }
            }

            cmbYearLevel.Enabled = (cmbProgram.SelectedIndex > 0);
            cmbBlock.Enabled = false;

            LoadTable();
        }

        private void LoadBlocks()
        {
            cmbBlock.Items.Clear();
            cmbBlock.Items.Add("All Blocks");
            cmbBlock.SelectedIndex = 0;

            if (cmbProgram.SelectedIndex > 0 && cmbYearLevel.SelectedIndex > 0)
            {
                try
                {
                    conn.Connect();
                    string query = "SELECT DISTINCT block FROM block WHERE program_id = @program_id AND yearlevel = @yearlevel";
                    cmd = new MySqlCommand(query, conn.con);
                    cmd.Parameters.AddWithValue("@program_id", cmbProgram.Text.Trim());
                    cmd.Parameters.AddWithValue("@yearlevel", cmbYearLevel.Text);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        cmbBlock.Items.Add(dr["block"].ToString());
                    }

                    dr.Close();
                }
                catch (Exception ex)
                {
                    conn.Disconnect();
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Disconnect();
                }
            }

            cmbBlock.Enabled = (cmbYearLevel.SelectedIndex > 0);
            LoadTable();
        }

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadYearLevels();
        }

        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBlocks();
        }

        private void cmbBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTable();
        }
        private void btnaddnew_Click(object sender, EventArgs e)
        {
            FormStudentDetails formStudentDetails = new FormStudentDetails(this);
            formStudentDetails.BtnSave.Enabled = true;
            formStudentDetails.BtnUpdate.Visible = false;
            if (cmbProgram.Text == "All Programs" || cmbProgram.SelectedItem == "All Programs")
            {
                _block2 = "";
            }
            formStudentDetails.ShowDialog();
        }

        private void FormStudentList_Load(object sender, EventArgs e)
        {
            LoadPrograms();
            LoadTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = "";
                if (e.RowIndex >= 0)
                {
                    colName = dataGridView1.Columns[e.ColumnIndex].Name;
                    studentid = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
                if (colName == "colEdit")
                {

                    using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1; port=3306; username=root; database=studentdisciplinaryrecordssystemdb; charset=utf8"))
                    {
                        conn.Open();

                        using (MySqlCommand cm = new MySqlCommand("SELECT image, student_id, lastname, firstname, middlename, block.block_id as bid, block.program_id as prog_id, program.program_description as prog_name, block.block as bloc, address, contactno  FROM student, block, program WHERE student_id LIKE @student_id AND student.block_id = block.block_id AND block.program_id = program.program_id LIMIT 1", conn))
                        {
                            cm.Parameters.AddWithValue("@student_id", dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

                            using (MySqlDataReader dr = cm.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    if (dr.HasRows)
                                    {

                                        using (FormStudentDetails formStudentDetails = new FormStudentDetails(this))
                                        {
                                            long len = dr.GetBytes(0, 0, null, 0, 0);
                                            byte[] array = new byte[len];
                                            dr.GetBytes(0, 0, array, 0, (int)len);

                                            using (MemoryStream ms = new MemoryStream(array))
                                            {
                                                Bitmap bitmap = new Bitmap(ms);
                                                formStudentDetails.txtNo.Text = dr["student_id"].ToString();
                                                _stuid = dr["student_id"].ToString();
                                                formStudentDetails.txtNo.ReadOnly = true;
                                                formStudentDetails.txtLname.Text = dr["lastname"].ToString();
                                                formStudentDetails.txtFname.Text = dr["firstname"].ToString();
                                                formStudentDetails.txtMname.Text = dr["middlename"].ToString();
                                                formStudentDetails.txtAddress.Text = dr["address"].ToString();
                                                formStudentDetails.txtContactno.Text = dr["contactno"].ToString();
                                                _program = dr["prog_id"].ToString() + " (" + dr["prog_name"].ToString() + ")";
                                                _block = dr["bloc"].ToString();

                                                _block2 = dr["bloc"].ToString();
                                                formStudentDetails.Picimage.BackgroundImage = bitmap;
                                                formStudentDetails.BtnSave.Visible = false;
                                                formStudentDetails.BtnUpdate.Visible = true;
                                                dr.Close();
                                                formStudentDetails.CmbProgram.Text = _program;
                                                _progid = _program;
                                                formStudentDetails.CmbBlock.Text = _block;
                                                formStudentDetails.BtnSave.Visible = false;
                                                formStudentDetails.BtnUpdate.Visible = true;


                                                formStudentDetails.ShowDialog();

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
                else if (colName == "colView")
                {
                    string _program = "", _block = "";
                    using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1; port=3306; username=root; database=studentdisciplinaryrecordssystemdb; charset=utf8"))
                    {
                        conn.Open();

                        using (MySqlCommand cm = new MySqlCommand("SELECT image, student_id, lastname, firstname, middlename, block.block_id as bid, block.program_id as prog_id, program.program_description as prog_name, block.block as bloc, address, contactno  FROM student, block, program WHERE student_id LIKE @student_id AND student.block_id = block.block_id AND block.program_id = program.program_id LIMIT 1", conn))
                        {
                            cm.Parameters.AddWithValue("@student_id", dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

                            using (MySqlDataReader dr = cm.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    if (dr.HasRows)
                                    {

                                        using (FormStudentDetails formStudentDetails = new FormStudentDetails(this))
                                        {
                                            long len = dr.GetBytes(0, 0, null, 0, 0);
                                            byte[] array = new byte[len];
                                            dr.GetBytes(0, 0, array, 0, (int)len);

                                            using (MemoryStream ms = new MemoryStream(array))
                                            {
                                                Bitmap bitmap = new Bitmap(ms);
                                                formStudentDetails.txtNo.Text = dr["student_id"].ToString();
                                                _stuid = dr["student_id"].ToString();

                                                formStudentDetails.txtLname.Text = dr["lastname"].ToString();
                                                formStudentDetails.txtFname.Text = dr["firstname"].ToString();
                                                formStudentDetails.txtMname.Text = dr["middlename"].ToString();
                                                formStudentDetails.txtAddress.Text = dr["address"].ToString();
                                                formStudentDetails.txtContactno.Text = dr["contactno"].ToString();
                                                _program = dr["prog_id"].ToString() + " (" + dr["prog_name"].ToString() + ")";
                                                _block = dr["bloc"].ToString();
                                                _block2 = dr["bloc"].ToString();
                                                formStudentDetails.Picimage.BackgroundImage = bitmap;
                                                formStudentDetails.BtnSave.Visible = false;
                                                formStudentDetails.BtnUpdate.Visible = true;
                                                dr.Close();
                                                formStudentDetails.CmbProgram.Text = _program;
                                                _progid = _program;
                                                Console.WriteLine("yeeeeeeeeeeeee: " + _block);
                                                formStudentDetails.CmbBlock.Text = _block;

                                                formStudentDetails.BtnSave.Visible = false;
                                                formStudentDetails.BtnUpdate.Visible = false;
                                                formStudentDetails.BtnCancel.Visible = false;
                                                formStudentDetails.BtnImage.Visible = false;
                                                formStudentDetails.txtNo.ReadOnly = true;
                                                formStudentDetails.txtLname.ReadOnly = true;
                                                formStudentDetails.txtFname.ReadOnly = true;
                                                formStudentDetails.txtMname.ReadOnly = true;
                                                formStudentDetails.txtAddress.ReadOnly = true;
                                                formStudentDetails.txtContactno.ReadOnly = true;
                                                formStudentDetails.CmbProgram.Enabled = false;
                                                formStudentDetails.CmbBlock.Enabled = false;
                                                formStudentDetails.ShowDialog();
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
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete this record of {studentid}?\nThis action will permanently remove all disciplinary records associated with this student and cannot be undone.", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            conn.Connect();
                            DeleteRelatedRecords(studentid);
                            string query = $"DELETE from student WHERE student_id='{studentid}'";
                            cmd = new MySqlCommand(query, conn.con);
                            cmd.ExecuteNonQuery();
                            LoadTable();
                            MessageBox.Show("Record deleted successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void DeleteRelatedRecords(string studid)
        {
            try
            {
                conn.Connect();
                string deleteQuery = $"DELETE FROM violation WHERE student_id = '{studid}'";
                MySqlCommand deleteCmd1 = new MySqlCommand(deleteQuery, conn.con);
                deleteCmd1.ExecuteNonQuery();
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

        private void cmbYearLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbBlock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
