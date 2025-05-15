using System;
using System.Collections.Generic;
using Npgsql;
using StudentGradeManagement.Models;

namespace StudentGradeManagement.Repositories
{
    public class NotaRepository
    {
        public List<Nota> GetAll()
        {
            var note = new List<Nota>();
            
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand(
                "SELECT id, student_id, disciplina_id, nota, data_notarii FROM note ORDER BY data_notarii DESC", 
                connection);
            
            using var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                note.Add(new Nota
                {
                    Id = reader.GetInt32(0),
                    StudentId = reader.GetInt32(1),
                    DisciplinaId = reader.GetInt32(2),
                    ValoareNota = reader.GetInt32(3),
                    DataNotarii = reader.GetDateTime(4)
                });
            }
            
            return note;
        }
        
        public List<Nota> GetAllWithDetails()
        {
            var note = new List<Nota>();
            
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand(
                @"SELECT n.id, n.student_id, n.disciplina_id, n.nota, n.data_notarii, 
                  s.nume || ' ' || s.prenume AS student_nume, d.nume AS disciplina_nume
                  FROM note n
                  JOIN studenti s ON n.student_id = s.id
                  JOIN discipline d ON n.disciplina_id = d.id
                  ORDER BY n.data_notarii DESC", 
                connection);
            
            using var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                note.Add(new Nota
                {
                    Id = reader.GetInt32(0),
                    StudentId = reader.GetInt32(1),
                    DisciplinaId = reader.GetInt32(2),
                    ValoareNota = reader.GetInt32(3),
                    DataNotarii = reader.GetDateTime(4),
                    StudentNume = reader.GetString(5),
                    DisciplinaNume = reader.GetString(6)
                });
            }
            
            return note;
        }
        
        public Nota GetById(int id)
        {
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand(
                @"SELECT n.id, n.student_id, n.disciplina_id, n.nota, n.data_notarii, 
                  s.nume || ' ' || s.prenume AS student_nume, d.nume AS disciplina_nume
                  FROM note n
                  JOIN studenti s ON n.student_id = s.id
                  JOIN discipline d ON n.disciplina_id = d.id
                  WHERE n.id = @id", 
                connection);
            
            command.Parameters.AddWithValue("id", id);
            
            using var reader = command.ExecuteReader();
            
            if (reader.Read())
            {
                return new Nota
                {
                    Id = reader.GetInt32(0),
                    StudentId = reader.GetInt32(1),
                    DisciplinaId = reader.GetInt32(2),
                    ValoareNota = reader.GetInt32(3),
                    DataNotarii = reader.GetDateTime(4),
                    StudentNume = reader.GetString(5),
                    DisciplinaNume = reader.GetString(6)
                };
            }
            
            return null;
        }
        
        public void Add(Nota nota)
        {
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand(
                @"INSERT INTO note (student_id, disciplina_id, nota, data_notarii) 
                  VALUES (@student_id, @disciplina_id, @nota, @data_notarii) 
                  RETURNING id", 
                connection);
            
            command.Parameters.AddWithValue("student_id", nota.StudentId);
            command.Parameters.AddWithValue("disciplina_id", nota.DisciplinaId);
            command.Parameters.AddWithValue("nota", nota.ValoareNota);
            command.Parameters.AddWithValue("data_notarii", nota.DataNotarii);
            
            nota.Id = (int)command.ExecuteScalar();
        }
        
        public void Update(Nota nota)
        {
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand(
                @"UPDATE note 
                  SET student_id = @student_id, disciplina_id = @disciplina_id, 
                      nota = @nota, data_notarii = @data_notarii 
                  WHERE id = @id", 
                connection);
            
            command.Parameters.AddWithValue("id", nota.Id);
            command.Parameters.AddWithValue("student_id", nota.StudentId);
            command.Parameters.AddWithValue("disciplina_id", nota.DisciplinaId);
            command.Parameters.AddWithValue("nota", nota.ValoareNota);
            command.Parameters.AddWithValue("data_notarii", nota.DataNotarii);
            
            command.ExecuteNonQuery();
        }
        
        public void Delete(int id)
        {
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand("DELETE FROM note WHERE id = @id", connection);
            command.Parameters.AddWithValue("id", id);
            
            command.ExecuteNonQuery();
        }
        
        public List<Nota> GetByStudentId(int studentId)
        {
            var note = new List<Nota>();
            
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand(
                @"SELECT n.id, n.student_id, n.disciplina_id, n.nota, n.data_notarii, 
                  s.nume || ' ' || s.prenume AS student_nume, d.nume AS disciplina_nume
                  FROM note n
                  JOIN studenti s ON n.student_id = s.id
                  JOIN discipline d ON n.disciplina_id = d.id
                  WHERE n.student_id = @student_id
                  ORDER BY n.data_notarii DESC", 
                connection);
            
            command.Parameters.AddWithValue("student_id", studentId);
            
            using var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                note.Add(new Nota
                {
                    Id = reader.GetInt32(0),
                    StudentId = reader.GetInt32(1),
                    DisciplinaId = reader.GetInt32(2),
                    ValoareNota = reader.GetInt32(3),
                    DataNotarii = reader.GetDateTime(4),
                    StudentNume = reader.GetString(5),
                    DisciplinaNume = reader.GetString(6)
                });
            }
            
            return note;
        }
        
        public List<Nota> GetByDisciplinaId(int disciplinaId)
        {
            var note = new List<Nota>();
            
            using var connection = Data.DatabaseConnection.GetConnection();
            connection.Open();
            
            using var command = new NpgsqlCommand(
                @"SELECT n.id, n.student_id, n.disciplina_id, n.nota, n.data_notarii, 
                  s.nume || ' ' || s.prenume AS student_nume, d.nume AS disciplina_nume
                  FROM note n
                  JOIN studenti s ON n.student_id = s.id
                  JOIN discipline d ON n.disciplina_id = d.id
                  WHERE n.disciplina_id = @disciplina_id
                  ORDER BY n.data_notarii DESC", 
                connection);
            
            command.Parameters.AddWithValue("disciplina_id", disciplinaId);
            
            using var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                note.Add(new Nota
                {
                    Id = reader.GetInt32(0),
                    StudentId = reader.GetInt32(1),
                    DisciplinaId = reader.GetInt32(2),
                    ValoareNota = reader.GetInt32(3),
                    DataNotarii = reader.GetDateTime(4),
                    StudentNume = reader.GetString(5),
                    DisciplinaNume = reader.GetString(6)
                });
            }
            
            return note;
        }
    }
}
