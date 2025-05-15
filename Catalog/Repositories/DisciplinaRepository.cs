using System;
using System.Collections.Generic;
using Npgsql;
using StudentGradeManagement.Models;

namespace StudentGradeManagement.Repositories
{
    public class DisciplinaRepository
    {
        public List<Disciplina> GetAll()
        {
            var discipline = new List<Disciplina>();
            
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand("SELECT id, nume, acronim, tip_evaluare FROM discipline ORDER BY nume", connection);
            using var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                discipline.Add(new Disciplina
                {
                    Id = reader.GetInt32(0),
                    Nume = reader.GetString(1),
                    Acronim = reader.GetString(2),
                    TipEvaluare = reader.GetInt32(3)
                });
            }
            
            return discipline;
        }
        
        public Disciplina GetById(int id)
        {
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand("SELECT id, nume, acronim, tip_evaluare FROM discipline WHERE id = @id", connection);
            command.Parameters.AddWithValue("id", id);
            
            using var reader = command.ExecuteReader();
            
            if (reader.Read())
            {
                return new Disciplina
                {
                    Id = reader.GetInt32(0),
                    Nume = reader.GetString(1),
                    Acronim = reader.GetString(2),
                    TipEvaluare = reader.GetInt32(3)
                };
            }
            
            return null;
        }
        
        public void Add(Disciplina disciplina)
        {
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand(
                "INSERT INTO discipline (nume, acronim, tip_evaluare) VALUES (@nume, @acronim, @tip_evaluare) RETURNING id", 
                connection);
            
            command.Parameters.AddWithValue("nume", disciplina.Nume);
            command.Parameters.AddWithValue("acronim", disciplina.Acronim);
            command.Parameters.AddWithValue("tip_evaluare", disciplina.TipEvaluare);
            
            disciplina.Id = (int)command.ExecuteScalar();
        }
        
        public void Update(Disciplina disciplina)
        {
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand(
                "UPDATE discipline SET nume = @nume, acronim = @acronim, tip_evaluare = @tip_evaluare WHERE id = @id", 
                connection);
            
            command.Parameters.AddWithValue("id", disciplina.Id);
            command.Parameters.AddWithValue("nume", disciplina.Nume);
            command.Parameters.AddWithValue("acronim", disciplina.Acronim);
            command.Parameters.AddWithValue("tip_evaluare", disciplina.TipEvaluare);
            
            command.ExecuteNonQuery();
        }
        
        public void Delete(int id)
        {
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand("DELETE FROM discipline WHERE id = @id", connection);
            command.Parameters.AddWithValue("id", id);
            
            command.ExecuteNonQuery();
        }
    }
}
