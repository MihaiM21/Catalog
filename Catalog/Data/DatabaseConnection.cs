using System;
using Npgsql;

namespace StudentGradeManagement.Data
{
    public static class DatabaseConnection
    {
        // Instructions to set up PostgreSQL:
        // Database name = catalog_note
        // User = postgres (or the username you have set up)
        // Password = <put password for the postgres user>
        
        // Instructiuni pentru a seta conexiunea cu PostgreSQL:
        // Numele bazei de date = catalog_note
        // User = postgres (sau username-ul ales)
        // Password = <parola pentru user-ul postgres>
        private static readonly string ConnectionString = "Host=localhost;Port=5432;Database=catalog_note;Username=postgres;Password=parola";
        
        public static NpgsqlConnection GetConnection()
        {
            var connection = new NpgsqlConnection(ConnectionString);
            return connection;
        }
    }
}
