using System;
using System.Collections.Generic;
using Npgsql;
using StudentGradeManagement.Models;

namespace StudentGradeManagement.Repositories
{
    public class StudentRepository
    {
        public List<Student> GetAll()
        {
            var students = new List<Student>();
            
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand("SELECT id, nume, prenume, email, grupa FROM studenti ORDER BY nume, prenume", connection);
            using var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                students.Add(new Student
                {
                    Id = reader.GetInt32(0),
                    Nume = reader.GetString(1),
                    Prenume = reader.GetString(2),
                    Email = reader.GetString(3),
                    Grupa = reader.GetString(4)
                });
            }
            
            return students;
        }
        
        public Student GetById(int id)
        {
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand("SELECT id, nume, prenume, email, grupa FROM studenti WHERE id = @id", connection);
            command.Parameters.AddWithValue("id", id);
            
            using var reader = command.ExecuteReader();
            
            if (reader.Read())
            {
                return new Student
                {
                    Id = reader.GetInt32(0),
                    Nume = reader.GetString(1),
                    Prenume = reader.GetString(2),
                    Email = reader.GetString(3),
                    Grupa = reader.GetString(4)
                };
            }
            
            return null;
        }
        
        public void Add(Student student)
        {
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand(
                "INSERT INTO studenti (nume, prenume, email, grupa) VALUES (@nume, @prenume, @email, @grupa) RETURNING id", 
                connection);
            
            command.Parameters.AddWithValue("nume", student.Nume);
            command.Parameters.AddWithValue("prenume", student.Prenume);
            command.Parameters.AddWithValue("email", student.Email);
            command.Parameters.AddWithValue("grupa", student.Grupa);
            
            student.Id = (int)command.ExecuteScalar();
        }
        
        public void Update(Student student)
        {
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand(
                "UPDATE studenti SET nume = @nume, prenume = @prenume, email = @email, grupa = @grupa WHERE id = @id", 
                connection);
            
            command.Parameters.AddWithValue("id", student.Id);
            command.Parameters.AddWithValue("nume", student.Nume);
            command.Parameters.AddWithValue("prenume", student.Prenume);
            command.Parameters.AddWithValue("email", student.Email);
            command.Parameters.AddWithValue("grupa", student.Grupa);
            
            command.ExecuteNonQuery();
        }
        
        public void Delete(int id)
        {
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand("DELETE FROM studenti WHERE id = @id", connection);
            command.Parameters.AddWithValue("id", id);
            
            command.ExecuteNonQuery();
        }
    }
}
