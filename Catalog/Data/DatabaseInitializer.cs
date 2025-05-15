using System;
using Npgsql;

namespace StudentGradeManagement
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            // Create tables if they don't exist
            CreateStudentTable(connection);
            CreateDisciplinaTable(connection);
            CreateNotaTable(connection);
        }
        
        private static void CreateStudentTable(NpgsqlConnection connection)
        {
            var command = new NpgsqlCommand(
                @"CREATE TABLE IF NOT EXISTS studenti (
                    id SERIAL PRIMARY KEY,
                    nume VARCHAR(100) NOT NULL,
                    prenume VARCHAR(100) NOT NULL,
                    email VARCHAR(100) NOT NULL UNIQUE,
                    grupa VARCHAR(50) NOT NULL
                )", connection);
            
            command.ExecuteNonQuery();
        }
        
        private static void CreateDisciplinaTable(NpgsqlConnection connection)
        {
            var command = new NpgsqlCommand(
                @"CREATE TABLE IF NOT EXISTS discipline (
                    id SERIAL PRIMARY KEY,
                    nume VARCHAR(100) NOT NULL,
                    acronim VARCHAR(20) NOT NULL,
                    tip_evaluare INTEGER NOT NULL
                )", connection);
            
            command.ExecuteNonQuery();
        }
        
        private static void CreateNotaTable(NpgsqlConnection connection)
        {
            var command = new NpgsqlCommand(
                @"CREATE TABLE IF NOT EXISTS note (
                    id SERIAL PRIMARY KEY,
                    student_id INTEGER NOT NULL,
                    disciplina_id INTEGER NOT NULL,
                    nota INTEGER NOT NULL CHECK (nota >= 1 AND nota <= 10),
                    data_notarii TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (student_id) REFERENCES studenti(id) ON DELETE CASCADE,
                    FOREIGN KEY (disciplina_id) REFERENCES discipline(id) ON DELETE CASCADE
                )", connection);
            
            command.ExecuteNonQuery();
        }
    }
}
