using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using StudentGradeManagement.Models;
using StudentGradeManagement.Repositories;

namespace StudentGradeManagement.Views
{
    public partial class DisciplinaGradesWindow : Window
    {
        private readonly Disciplina _disciplina;
        private readonly NotaRepository _notaRepository;
        private readonly StudentRepository _studentRepository;
        
        public DisciplinaGradesWindow(Disciplina disciplina)
        {
            InitializeComponent();
            
            _disciplina = disciplina;
            _notaRepository = new NotaRepository();
            _studentRepository = new StudentRepository();
            
            LoadDisciplinaInfo();
            LoadGrades();
        }
        
        private void LoadDisciplinaInfo()
        {
            txtDisciplinaInfo.Text = _disciplina.Nume;
            txtDisciplinaDetails.Text = $"Acronim: {_disciplina.Acronim} | Tip Evaluare: {_disciplina.TipEvaluareString}";
        }
        
        private void LoadGrades()
        {
            var disciplinaNotes = _notaRepository.GetByDisciplinaId(_disciplina.Id);
            var allStudents = _studentRepository.GetAll();
            
            var gradeData = new List<object>();
            
            // Add all students, even those without grades
            foreach (var student in allStudents)
            {
                var nota = disciplinaNotes.FirstOrDefault(n => n.StudentId == student.Id);
                
                gradeData.Add(new
                {
                    StudentId = student.Id,
                    StudentNume = $"{student.Nume} {student.Prenume}",
                    Grupa = student.Grupa,
                    Nota = nota?.ValoareNota ?? 0,
                    DataNotarii = nota?.DataNotarii,
                    Status = nota != null ? (nota.ValoareNota >= 5 ? "Promovat" : "Nepromovat") : "Nenotat"
                });
            }
            
            dgNote.ItemsSource = gradeData;
            
            // Calculate and display summary
            var averageGrade = disciplinaNotes.Any() ? disciplinaNotes.Average(n => n.ValoareNota) : 0;
            var passedStudents = disciplinaNotes.Count(n => n.ValoareNota >= 5);
            var totalStudents = allStudents.Count;
            var passRate = totalStudents > 0 ? (double)passedStudents / totalStudents * 100 : 0;
            
            txtSummary.Text = $"Media: {Math.Round(averageGrade, 2)} | " +
                              $"Studenți promovați: {passedStudents} din {totalStudents} | " +
                              $"Procent promovabilitate: {Math.Round(passRate, 2)}%";
        }
    }
}
