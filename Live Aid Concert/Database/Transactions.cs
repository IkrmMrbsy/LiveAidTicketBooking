using System;
using System.Data.SqlClient;

namespace Live_Aid_Concert.Database
{
    public class Transactions
    {
        // Metode untuk memasukkan data transaksi ke dalam tabel Transactions
        public static void InsertTransaction(int userID, int ticketID, DateTime transactionDate, decimal totalPrice)
        {
            using (Koneksi koneksi = new Koneksi())
            {
                string query = "INSERT INTO Transactions (UserID, TicketID, TransactionDate, TotalPrice) " +
                               "VALUES (@UserID, @TicketID, @TransactionDate, @TotalPrice)";

                using (SqlCommand cmd = new SqlCommand(query, koneksi.con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@TicketID", ticketID);
                    cmd.Parameters.AddWithValue("@TransactionDate", transactionDate);
                    cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);

                    try
                    {
                        koneksi.BukaKoneksi();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that occur during the process
                        Console.WriteLine(ex.Message);
                        throw; // Rethrow the exception to notify the caller
                    }
                }
            }
        }
    }
}
