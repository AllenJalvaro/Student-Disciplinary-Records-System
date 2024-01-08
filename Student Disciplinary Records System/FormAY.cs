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
    public partial class FormAY : Form
    {
        public FormAY()
        {
            InitializeComponent();
        }

        DBConnect conn = new DBConnect();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        MySqlDataReader dr;
        String aycode;
        public void LoadTable()
        {
            this.dataGridView1.Rows.Clear();
            conn.Connect();
            string query = "SELECT * FROM acadyear";
            cmd = new MySqlCommand(query, conn.con);
            dr = cmd.ExecuteReader();
            int i = 0;

            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["ay_id"].ToString(), dr["year1"].ToString(), dr["year2"].ToString(), dr["semester"].ToString(), dr["status"].ToString());
            }

            dr.Close();


            conn.Disconnect();

        }

        private void FormAY_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            FormAYdetails formAYdetails = new FormAYdetails(this);
            formAYdetails.BtnSave.Enabled = true;
            formAYdetails.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {
                aycode = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                }

                if (e.ColumnIndex == dataGridView1.Columns["colOpen"].Index && e.RowIndex >= 0)
                {
                    DialogResult result = MessageBox.Show($"Are you sure you want to open ACADEMIC YEAR {aycode}?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {

                            conn.Connect();
                            string sql = "UPDATE acadyear SET status='CLOSED'";
                            cmd = new MySqlCommand(sql, conn.con);
                            cmd.ExecuteNonQuery();
                            conn.Disconnect();



                            conn.Connect();
                            string sql2 = $"UPDATE acadyear SET status='OPEN' WHERE ay_id='{aycode}'";
                            cmd = new MySqlCommand(sql2, conn.con);
                            cmd.ExecuteNonQuery();
                            conn.Disconnect();


                            LoadTable();
                            MessageBox.Show($"ACADEMIC YEAR {aycode} has been successfully opened!", "OPENED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            conn.Disconnect();
                            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
                else if (e.ColumnIndex == dataGridView1.Columns["colClose"].Index && e.RowIndex >= 0)
                {
                    DialogResult result = MessageBox.Show($"Are you sure you want to close ACADEMIC YEAR {aycode}?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            conn.Connect();
                            string sql2 = $"UPDATE acadyear SET status='CLOSED' WHERE ay_id='{aycode}'";
                            cmd = new MySqlCommand(sql2, conn.con);
                            cmd.ExecuteNonQuery();
                            conn.Disconnect();


                            LoadTable();
                            MessageBox.Show($"ACADEMIC YEAR {aycode} has been successfully closed!", "CLOSED", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
