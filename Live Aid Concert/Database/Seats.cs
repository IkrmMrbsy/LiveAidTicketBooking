using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Live_Aid_Concert.Database
{
    public class Seats
    {
        private Koneksi koneksi;

        public Seats()
        {
            koneksi = new Koneksi();
        }

        public Dictionary<string, (int Price, string Status)> GetSeatNamesAndPrices(int concertID)
        {
            Dictionary<string, (int Price, string Status)> seatNamesAndPrices = new Dictionary<string, (int Price, string Status)>();
            using (Koneksi koneksi = new Koneksi())
            {

                using (SqlConnection connection = koneksi.con)
                {
                    string query = "SELECT SeatNumber, Price, Status FROM Seats WHERE ConcertID = @ConcertID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ConcertID", concertID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string seatNumber = reader["SeatNumber"].ToString();
                                int price = Convert.ToInt32(reader["Price"]);
                                string status = reader["Status"].ToString();
                                seatNamesAndPrices.Add(seatNumber, (price, status));
                            }
                        }
                    }
                }
            }
            return seatNamesAndPrices;
        }

        public void DecreaseSeatLimit(int concertID, List<string> selectedSeats)
        {
            using (Koneksi koneksi = new Koneksi())
            {
                using (SqlConnection connection = koneksi.con)
                {
                    connection.Open();
                    foreach (string seatNumber in selectedSeats)
                    {
                        string query = "UPDATE Seats SET SeatLimit = SeatLimit - 1, Status = CASE WHEN SeatLimit <= 1 THEN 'Sold Out' ELSE 'Available' END WHERE ConcertID = @ConcertID AND SeatNumber = @SeatNumber";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ConcertID", concertID);
                            command.Parameters.AddWithValue("@SeatNumber", seatNumber);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
