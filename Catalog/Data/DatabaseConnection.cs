using System;
using Npgsql;

namespace StudentGradeManagement.Data
{
    public static class DatabaseConnection
    {
        private static readonly string ConnectionString = "Host=localhost;Port=5432;Database=catalog_note;Username=postgres;Password=CodyCody21";
        
        public static NpgsqlConnection GetConnection()
        {
            var connection = new NpgsqlConnection(ConnectionString);
            return connection;
        }
    }
}
