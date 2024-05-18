using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Live_Aid_Concert.Database
{
    public class Concerts
    {
        public static Dictionary<string, string> GetConcertDetails(int concertID)
        {
            Dictionary<string, string> concertDetails = new Dictionary<string, string>();

            using (Koneksi koneksi = new Koneksi())
            {
                koneksi.BukaKoneksi();
                string query = "SELECT Name, Description, Date, Location FROM Concerts WHERE ConcertID = @ConcertID";

                using (SqlCommand cmd = new SqlCommand(query, koneksi.con))
                {
                    cmd.Parameters.AddWithValue("@ConcertID", concertID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            concertDetails["Name"] = reader["Name"].ToString();
                            concertDetails["Description"] = reader["Description"].ToString();
                            concertDetails["Date"] = reader["Date"].ToString();
                            concertDetails["Location"] = reader["Location"].ToString(); // Menambah lokasi ke dalam dictionary
                        }
                    }
                }
            }

            return concertDetails;
        }

    }
}