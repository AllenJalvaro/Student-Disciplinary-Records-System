using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Student_Disciplinary_Records_System
{
    public partial class FormProgram : Form
    {

        public FormProgram()
        {
            InitializeComponent();
        }

        DBConnect conn = new DBConnect();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        MySqlDataReader dr;
        String pcode;
        public void LoadTable()
        {
            this.dataGridView1.Rows.Clear();
            conn.Connect();
            string query = "SELECT * FROM program";
            cmd = new MySqlCommand(query, conn.con);
            dr = cmd.ExecuteReader();
            int i = 0;

            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["program_id"].ToString(), dr["program_description"].ToString());
            }

            dr.Close();


            conn.Disconnect();

        }
        

        private void FormProgram_Load(object sender, EventArgs e)
        {
            this.LoadTable();
        }

        public string pcodeSt
        {
            get { return pcode; }
            set { pcode = value; }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                pcode = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
                if (e.ColumnIndex == dataGridView1.Columns["colEdit"].Index && e.RowIndex >= 0)
                {
                    FormProgramDetails formProgramDetails = new FormProgramDetails(this);
                    formProgramDetails.Txtpcode.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    formProgramDetails.Txtpdesc.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    formProgramDetails.Txtpcode.Enabled = true;
                    formProgramDetails.BtnSave.Visible = false;
                    formProgramDetails.BtnUpdate.Visible = true;
                    formProgramDetails.ShowDialog();

                }
                else if (e.ColumnIndex == dataGridView1.Columns["colDelete"].Index && e.RowIndex >= 0)
                {


                    DialogResult result = MessageBox.Show($"Are you sure you want to delete {pcode}?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            conn.Connect();
                            string query = $"DELETE from program WHERE program_id='{pcode}'";
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

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            FormProgramDetails formProgramDetails = new FormProgramDetails(this);
            formProgramDetails.BtnSave.Enabled = true;
            formProgramDetails.BtnUpdate.Visible = false;
            formProgramDetails.ShowDialog();
        }
    }
}
