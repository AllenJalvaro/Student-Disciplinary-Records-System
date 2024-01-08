using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Student_Disciplinary_Records_System
{
    internal class DBConnect
    {
        public MySqlConnection con = new MySqlConnection();

        public void Connect()
        {
            string constring = "server=127.0.0.1; port=3306; username=root; database=studentdisciplinaryrecordssystemdb; charset=utf8";
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = constring;
                con.Open();
            }
        }

        public void Disconnect()
        {
            con.Close();
            con.Dispose();
        }

        public string GetAYcode()
        {
            string aycode="";
            con.Open();
            string query = "SELECT ay_id from acadyear where status='OPEN'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                if (dr.HasRows)
                { 
                    aycode = dr["ay_id"].ToString();
                }
                else
                {
                    aycode = "";
                }
            }
            dr.Close();
                    con.Close();
            con.Dispose();
            return aycode;
        }
    }
}
