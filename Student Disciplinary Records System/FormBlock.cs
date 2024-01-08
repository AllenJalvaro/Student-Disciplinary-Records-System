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
    public partial class FormBlock : Form
    {
        public FormBlock()
        {
            InitializeComponent();
        }

        DBConnect conn = new DBConnect();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        MySqlDataReader dr;
        String block_id;

        
        public string Blockid
        {
            get { return block_id; }
            set { block_id = value; }
        }

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
        public string getCmbProgramText()
        {
            return cmbProgram.Text;
        }
        public string getCmbYearLevelText()
        {
            return cmbYearLevel.Text;
        }
        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTable();
            LoadYearLevels();
        }

        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTable();
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
        }

        public void LoadTable()
        {
            try
            {
                this.dataGridView1.Rows.Clear();
                conn.Connect();
                string query = "SELECT block_id, block, yearlevel, program.program_id as pcode, program.program_description as pd FROM block, program WHERE program.program_id=block.program_id";

                if (cmbProgram.SelectedIndex > 0)
                {
                    query += " AND block.program_id = @program_id";
                }

                if (cmbYearLevel.SelectedIndex > 0)
                {
                    query += " AND block.yearlevel = @yearlevel";
                }

                query += " ORDER BY program.program_description, block.yearlevel, block";

                cmd = new MySqlCommand(query, conn.con);

                if (cmbProgram.SelectedIndex > 0)
                {
                    cmd.Parameters.AddWithValue("@program_id", cmbProgram.Text.Trim());
                }

                if (cmbYearLevel.SelectedIndex > 0)
                {
                    cmd.Parameters.AddWithValue("@yearlevel", cmbYearLevel.Text.Trim());
                }


                dr = cmd.ExecuteReader();
                int i = 0;

                while (dr.Read())
                {
                    i++;
                    dataGridView1.Rows.Add(i, dr["block_id"].ToString(), dr["block"].ToString(), dr["yearlevel"].ToString(), dr["pcode"].ToString(), dr["pd"].ToString());
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

        private void loadAllPrograms()
        {
            cmbProgram.Items.Clear();
            cmbProgram.Items.Add("All Programs");
            cmbProgram.SelectedIndex = 0;
            conn.Connect();
            string query = "SELECT * from program";
            cmd = new MySqlCommand(query, conn.con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbProgram.Items.Add(dr["program_id"].ToString());
            }

            dr.Close();
            conn.Disconnect();
        }

        private void FormBlock_Load(object sender, EventArgs e)
        {
            loadAllPrograms();
            LoadTable();
        }
        private void btnaddnew_Click_1(object sender, EventArgs e)
        {
            FormBlockDetails formBlockDetails = new FormBlockDetails(this);
            formBlockDetails.BtnSave.Enabled = true;
            formBlockDetails.BtnUpdate.Visible = false;
            formBlockDetails.ShowDialog();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    block_id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
                if (e.ColumnIndex == dataGridView1.Columns["colEdit"].Index && e.RowIndex >= 0)
                {
                    FormBlockDetails formBlockDetails = new FormBlockDetails(this);
                    formBlockDetails.Txtblock.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    formBlockDetails.CmbProgram.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + " (" + dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() + ")";
                    formBlockDetails.CmbYearLevel.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    formBlockDetails.Txtblock.Enabled = true;
                    formBlockDetails.BtnSave.Visible = false;
                    formBlockDetails.BtnUpdate.Visible = true;
                    formBlockDetails.ShowDialog();

                }
                else if (e.ColumnIndex == dataGridView1.Columns["colDelete"].Index && e.RowIndex >= 0)
                {
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete this block?\nThis action will permanently remove all records associated with this block and cannot be undone.", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            conn.Connect();
                            DeleteRelatedRecords(block_id);
                            string query = $"DELETE from block WHERE block_id='{block_id}'";
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
        private void DeleteRelatedRecords(string blockid)
        {
            try
            {
                conn.Connect();
                string deleteQuery = $"DELETE FROM student WHERE block_id = '{blockid}'";
                MySqlCommand deleteCmd1 = new MySqlCommand(deleteQuery, conn.con);
                deleteCmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                conn.Disconnect();
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProgram_TextChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void cmbProgram_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
