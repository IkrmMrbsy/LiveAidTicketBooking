using System;
using System.Data.SqlClient;

namespace Live_Aid_Concert.Database
{
    public class Tickets
    {
        // Metode untuk memasukkan data tiket ke dalam tabel Tickets
        public static int InsertTicket(int userID, int concertID, string seatNumber, decimal price, DateTime purchaseDate)
        {
            int ticketID = 0;

            using (Koneksi koneksi = new Koneksi())
            {
                string query = "INSERT INTO Tickets (UserID, ConcertID, SeatNumber, Price, PurchaseDate) " +
                               "OUTPUT INSERTED.TicketID VALUES (@UserID, @ConcertID, @SeatNumber, @Price, @PurchaseDate)";

                using (SqlCommand cmd = new SqlCommand(query, koneksi.con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@ConcertID", concertID);
                    cmd.Parameters.AddWithValue("@SeatNumber", seatNumber);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@PurchaseDate", purchaseDate);

                    try
                    {
                        koneksi.BukaKoneksi();
                        ticketID = (int)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that occur during the process
                        Console.WriteLine(ex.Message);
                        throw; // Rethrow the exception to notify the caller
                    }
                }
            }

            return ticketID;
        }
    }
}
