using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using StudentGradeManagement.Models;
using StudentGradeManagement.Repositories;

namespace StudentGradeManagement.Views
{
    public partial class StudentGradesWindow : Window
    {
        private readonly Student _student;
        private readonly NotaRepository _notaRepository;
        private readonly DisciplinaRepository _disciplinaRepository;
        
        public StudentGradesWindow(Student student)
        {
            InitializeComponent();
            
            _student = student;
            _notaRepository = new NotaRepository();
            _disciplinaRepository = new DisciplinaRepository();
            
            LoadStudentInfo();
            LoadGrades();
        }
        
        private void LoadStudentInfo()
        {
            txtStudentInfo.Text = $"{_student.Nume} {_student.Prenume}";
            txtStudentDetails.Text = $"Email: {_student.Email} | Grupa: {_student.Grupa}";
        }
        
        private void LoadGrades()
        {
            var studentNotes = _notaRepository.GetByStudentId(_student.Id);
            var allDisciplines = _disciplinaRepository.GetAll();
            
            var gradeData = new List<object>();
            
            // Add all disciplines, even those without grades
            foreach (var disciplina in allDisciplines)
            {
                var nota = studentNotes.FirstOrDefault(n => n.DisciplinaId == disciplina.Id);
                
                gradeData.Add(new
                {
                    DisciplinaId = disciplina.Id,
                    DisciplinaNume = disciplina.Nume,
                    Nota = nota?.ValoareNota ?? 0,
                    DataNotarii = nota?.DataNotarii,
                    Status = nota != null ? (nota.ValoareNota >= 5 ? "Promovat" : "Nepromovat") : "Nenotat"
                });
            }
            
            dgNote.ItemsSource = gradeData;
            
            // Calculate and display summary
            var averageGrade = studentNotes.Any() ? studentNotes.Average(n => n.ValoareNota) : 0;
            var passedCourses = studentNotes.Count(n => n.ValoareNota >= 5);
            var totalCourses = allDisciplines.Count;
            
            txtSummary.Text = $"Media: {Math.Round(averageGrade, 2)} | " +
                              $"Discipline promovate: {passedCourses} din {totalCourses} | " +
                              $"Procent promovabilitate: {Math.Round((double)passedCourses / totalCourses * 100, 2)}%";
        }
    }
}
