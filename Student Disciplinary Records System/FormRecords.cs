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
    public partial class FormRecords : Form
    {
        public FormRecords()
        {
            InitializeComponent();
        }
        DBConnect conn = new DBConnect();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        MySqlDataReader dr;
        String pcode;
        private void loadAY()
        {
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("All");
            cmbFilter.SelectedIndex = 0;
            conn.Connect();
            string query = "SELECT * from acadyear";
            cmd = new MySqlCommand(query, conn.con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbFilter.Items.Add(dr["ay_id"].ToString());

            }

            dr.Close();


            conn.Disconnect();
        }
        public void LoadTable()
        {
            try
            {

                this.dataGridView1.Rows.Clear();
                conn.Connect();
                string query = "";
                if (cmbFilter.Text == "All")
                {
                    query = "SELECT distinct v.student_id, s.fullname, s.prog_id, s.bloc, count(v.student_id) as totalrecord from violation as v, student_view as s WHERE v.student_id=s.student_id GROUP BY v.student_id";
                    cmd = new MySqlCommand(query, conn.con);

                }
                else
                {
                    query = "SELECT distinct v.student_id, s.fullname, s.prog_id, s.bloc, count(v.student_id) as totalrecord from violation as v, student_view as s WHERE v.student_id=s.student_id AND v.ay_id=@ay_id GROUP BY v.student_id";
                    cmd = new MySqlCommand(query, conn.con);
                    cmd.Parameters.AddWithValue("@ay_id", cmbFilter.Text.Trim());
                }
                dr = cmd.ExecuteReader();
                int i = 0;

                while (dr.Read())
                {
                    i++;
                    dataGridView1.Rows.Add(
                            i,
                            dr["student_id"].ToString(),
                            dr["fullname"].ToString(),
                            dr["prog_id"].ToString(),
                            dr["bloc"].ToString(),
                            dr["totalrecord"].ToString()
                    );

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

        private void LoadViolation(string studentid)
        {
            try
            {

                this.dataGridView2.Rows.Clear();
                conn.Connect();
                string query = "";
                if (cmbFilter.Text == "All")
                {
                    query = "SELECT v.*, f.fnamelname from violation as v, fnamlnam as f where v.student_id=@student_id and f.student_id=@student_id";
                    cmd = new MySqlCommand(query, conn.con);
                    cmd.Parameters.AddWithValue("@student_id", studentid.Trim());
                }
                else
                {
                    query = "SELECT v.*, f.fnamelname from violation as v, fnamlnam as f where v.student_id=@student_id and ay_id=@ay_id and f.student_id=@student_id";
                    cmd = new MySqlCommand(query, conn.con);
                    cmd.Parameters.AddWithValue("@student_id", studentid.Trim());
                    cmd.Parameters.AddWithValue("@ay_id", cmbFilter.Text.Trim());
                }
                dr = cmd.ExecuteReader();
                int i = 0;

                while (dr.Read())
                {
                    i++;
                    dataGridView2.Rows.Add(
                        i,
                        dr["violation_desc"].ToString(),
                        dr["violation_type"].ToString(),
                        dr["penalty"].ToString(),
                        FormatDate(dr["sdate"]),
                        dr["user"].ToString());

                    txtRecordOf.Text = dr["fnamelname"].ToString() + "'s Disciplinary Records"+" ("+cmbFilter.Text+")";
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
        private string FormatDate(object dateValue)
        {
            if (dateValue != DBNull.Value)
            {
                DateTime rawDateTime = Convert.ToDateTime(dateValue);
                return rawDateTime.ToString("d MMM yyyy, h:mm tt");
            }
            return string.Empty;
        }
        private void FormRecords_Load(object sender, EventArgs e)
        {
            loadAY();
            LoadTable();
        }

        private void cmbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbFilter_TextChanged(object sender, EventArgs e)
        {
            LoadTable();
            this.dataGridView2.Rows.Clear();
            txtRecordOf.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = "";
                string studentid = "";
                if (e.RowIndex >= 0)
                {
                    colName = dataGridView1.Columns[e.ColumnIndex].Name;
                    studentid = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                }

                if (colName == "colView")
                {
                    LoadViolation(studentid);
                }

            }
            catch (Exception ex)
            {
                conn.Disconnect();
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
