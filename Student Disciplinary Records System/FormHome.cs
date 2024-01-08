using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts.Wpf;
using LiveCharts;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Windows.Media;
using System.Globalization;

namespace Student_Disciplinary_Records_System
{
    public partial class FormHome : Form
    {
        private int Radius { get; set; } = 10;

      
        private class DisciplinaryRecord
        {
            public string AcademicYear { get; set; }
            public int Month { get; set; }
            public int Count { get; set; }
        }

        public FormHome()
        {
            InitializeComponent();
        }
        DBConnect conn = new DBConnect(); 
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        MySqlDataReader dr;
        string username = "", password = "";
        
        private void FormHome_Load(object sender, EventArgs e)
        {

            LoadAcademicYearsComboBox();
            PopulateChartWithDatabaseData();
            ApplyRoundedCorners(panel4, Radius);
            ApplyRoundedCorners(panel1, Radius);
            ApplyRoundedCorners(panel2, Radius);
            ApplyRoundedCorners(panel3, Radius);
            activeAY();
            totalRec();
            totalStud();
        }

        private void ApplyRoundedCorners(Panel panel, int radius)
        {
            int offset = 10;

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius + offset, radius + offset, 180, 90);
            path.AddArc(panel.Width - radius - offset, 0, radius + offset, radius + offset, 270, 90);
            path.AddArc(panel.Width - radius - offset, panel.Height - radius - offset, radius + offset, radius + offset, 0, 90);
            path.AddArc(0, panel.Height - radius - offset, radius + offset, radius + offset, 90, 90);

            panel.Region = new Region(path);
        }
        private void activeAY()
        {

            string query = "SELECT * FROM acadyear WHERE status='OPEN'";
            conn.Connect();
            using (MySqlCommand command = new MySqlCommand(query, conn.con))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    LabelactiveYear.Text = reader["ay_id"].ToString().Trim();

                }
            }
            conn.Disconnect();
        }

        private void totalStud()
        {

            string query = "SELECT count(*) as ts FROM student";
            conn.Connect();
            using (MySqlCommand command = new MySqlCommand(query, conn.con))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    label7.Text = reader["ts"].ToString().Trim();

                }
            }
            conn.Disconnect();
        }
        private void totalRec()
        {
            string query = "SELECT count(*) as totall FROM violation where ay_id = @ayid";
            conn.Connect();

            using (MySqlCommand command = new MySqlCommand(query, conn.con))
            {
                command.Parameters.AddWithValue("@ayid", LabelactiveYear.Text);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        label6.Text = reader["totall"].ToString().Trim();
                    }
                }
            }

            conn.Disconnect();
        }



        private void LoadAcademicYearsComboBox()
        {
         
            cmbFilter.Items.Clear();

            cmbFilter.Items.Add("All");

            string academicYearsQuery = "SELECT DISTINCT CONCAT(year1, '-', year2) AS AcademicYear FROM acadyear";

            conn.Connect();
            using (MySqlCommand academicYearCommand = new MySqlCommand(academicYearsQuery, conn.con))
            using (MySqlDataReader academicYearReader = academicYearCommand.ExecuteReader())
            {
                while (academicYearReader.Read())
                {
                    cmbFilter.Items.Add(academicYearReader["AcademicYear"].ToString());
                }
            }
            conn.Disconnect();


            cmbFilter.SelectedIndex = 0;
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateChartWithDatabaseData();
            if (cmbFilter.Text=="All")
            {
                labelHello.Text = "Monthly Overview of Student Disciplinary Records for All Academic Years";
            }
            else
            {
                labelHello.Text = $"Monthly Overview of Student Disciplinary Records for Academic Year {cmbFilter.Text}";
            }
        }

        private void cmbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void PopulateChartWithDatabaseData()
        {
            List<DisciplinaryRecord> disciplinaryRecords = new List<DisciplinaryRecord>();

            string query = "SELECT acadyear.year1, acadyear.year2, MONTH(violation.sdate) as Month, COUNT(*) as Count " +
                           "FROM violation " +
                           "JOIN acadyear ON violation.ay_id = acadyear.ay_id " +
                           "GROUP BY acadyear.year1, acadyear.year2, MONTH(violation.sdate)";
            conn.Connect();
            using (MySqlCommand command = new MySqlCommand(query, conn.con))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    disciplinaryRecords.Add(new DisciplinaryRecord
                    {
                        AcademicYear = $"{reader["year1"]}-{reader["year2"]}",
                        Month = Convert.ToInt32(reader["Month"]),
                        Count = Convert.ToInt32(reader["Count"])
                    });
                }
            }
            conn.Disconnect();
            string selectedAcademicYear = cmbFilter.SelectedItem?.ToString();

            if (selectedAcademicYear != "All")
            {
                disciplinaryRecords = disciplinaryRecords.Where(record => record.AcademicYear == selectedAcademicYear).ToList();
            }

            SeriesCollection cartesianSeriesCollection = new SeriesCollection();

            var months = disciplinaryRecords.Select(record => record.Month).Distinct().OrderBy(month => month).ToList();

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Months",
                Labels = months.Select(month => DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(month)).ToArray(),
                Foreground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#227093")),
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 1,
                },
            });

            foreach (var academicYearRecords in disciplinaryRecords.GroupBy(record => record.AcademicYear))
            {
                var lineSeries = new LineSeries
                {
                    Title = academicYearRecords.Key,
                    Values = new ChartValues<double>(),
                    DataLabels = true,
                    PointGeometrySize = 10,
                };

                foreach (var month in months)
                {
                    var recordsForMonth = academicYearRecords.Where(record => record.Month == month);
                    double totalRecordsForMonth = recordsForMonth.Sum(record => record.Count);

                    lineSeries.Values.Add(totalRecordsForMonth);
                }

                cartesianSeriesCollection.Add(lineSeries);
            }

            cartesianChart1.Series = cartesianSeriesCollection;

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Number of Disciplinary Records",
                LabelFormatter = value => value.ToString(),
                Foreground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#227093")),
                MinValue = 0
            });
        }

    }

}
    
