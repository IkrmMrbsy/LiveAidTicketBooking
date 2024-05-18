using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Live_Aid_Concert.Database
{
    internal class Koneksi : IDisposable
    {
        private string Source;
        public SqlConnection con;

        public Koneksi()
        {
            try
            {
                Source = "Integrated Security=true;Initial Catalog=TicketConcert2;Data Source=.";
                con = new SqlConnection(Source);
            }
            catch (Exception Sqle)
            {
                Console.WriteLine("Error : " + Sqle.Message);
            }
        }

        public void BukaKoneksi()
        {
            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    con.Open();
                }
                catch (SqlException Sqle)
                {
                    Console.WriteLine("Error : " + Sqle.Message);
                }
            }
        }

        public void TutupKoneksi()
        {
            if (con.State == ConnectionState.Open)
            {
                try
                {
                    con.Close();
                }
                catch (SqlException Sqle)
                {
                    Console.WriteLine("Error : " + Sqle.Message);
                }
            }
        }

        public void Dispose()
        {
            if (con != null)
            {
                con.Dispose();
            }
        }
    }
}
