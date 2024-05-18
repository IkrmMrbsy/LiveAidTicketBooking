using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Live_Aid_Concert.Database
{
    public class Users
    {
        public static int InsertUser(string email, string name, string phone, string nik)
        {
            int UserID = 0;

            using (Koneksi koneksi = new Koneksi())
            {
                koneksi.BukaKoneksi();
                string query = "INSERT INTO Users (Email, Name, Phone, Nik) OUTPUT INSERTED.UserID VALUES (@Email, @Name, @Phone, @Nik)";

                using (SqlCommand cmd = new SqlCommand(query, koneksi.con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Nik", nik);
                    UserID = (int)cmd.ExecuteScalar();
                }
            }

            return UserID;
        }
    }
}

