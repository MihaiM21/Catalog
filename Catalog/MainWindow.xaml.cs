using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;
using StudentGradeManagement.Models;
using StudentGradeManagement.Repositories;
using StudentGradeManagement.Views;

namespace StudentGradeManagement
{
    public partial class MainWindow : Window
    {
        private readonly StudentRepository _studentRepository;
        private readonly DisciplinaRepository _disciplinaRepository;
        private readonly NotaRepository _notaRepository;
        
        public MainWindow()
        {
            InitializeComponent();
            
            // Initialize repositories
            _studentRepository = new StudentRepository();
            _disciplinaRepository = new DisciplinaRepository();
            _notaRepository = new NotaRepository();
            
            // Load data
            LoadStudents();
            LoadDiscipline();
            LoadNote();
            LoadComboBoxes();
        }
        
        #region Data Loading Methods
        
        private void LoadStudents()
        {
            dgStudents.ItemsSource = _studentRepository.GetAll();
        }
        
        private void LoadDiscipline()
        {
            dgDiscipline.ItemsSource = _disciplinaRepository.GetAll();
        }
        
        private void LoadNote()
        {
            var note = _notaRepository.GetAllWithDetails();
            dgNote.ItemsSource = note;
        }
        
        private void LoadComboBoxes()
        {
            // Add empty item for "All" option
            var students = new List<Student> { new Student { Id = 0, Nume = "Toți", Prenume = "Studenții" } };
            students.AddRange(_studentRepository.GetAll());
            cmbFilterStudent.ItemsSource = students;
            cmbFilterStudent.SelectedIndex = 0;
            
            var discipline = new List<Disciplina> { new Disciplina { Id = 0, Nume = "Toate Disciplinele" } };
            discipline.AddRange(_disciplinaRepository.GetAll());
            cmbFilterDisciplina.ItemsSource = discipline;
            cmbFilterDisciplina.SelectedIndex = 0;
        }
        
        private void RefreshData()
        {
            LoadStudents();
            LoadDiscipline();
            LoadNote();
            LoadComboBoxes();
        }
        
        #endregion
        
        #region Student Event Handlers
        
        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var window = new StudentWindow();
            if (window.ShowDialog() == true)
            {
                RefreshData();
            }
        }
        
        private void BtnEditStudent_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int studentId)
            {
                var student = _studentRepository.GetById(studentId);
                if (student != null)
                {
                    var window = new StudentWindow(student);
                    if (window.ShowDialog() == true)
                    {
                        RefreshData();
                    }
                }
            }
        }
        
        private void BtnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int studentId)
            {
                var result = MessageBox.Show("Sunteți sigur că doriți să ștergeți acest student? Toate notele asociate vor fi șterse.", 
                    "Confirmare ștergere", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _studentRepository.Delete(studentId);
                        RefreshData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Eroare la ștergerea studentului: {ex.Message}", "Eroare", 
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        
        private void BtnViewStudentGrades_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int studentId)
            {
                var student = _studentRepository.GetById(studentId);
                if (student != null)
                {
                    var window = new StudentGradesWindow(student);
                    window.ShowDialog();
                }
            }
        }
        
        private void TxtStudentSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Implement search as you type
            string searchText = txtStudentSearch.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadStudents();
            }
            else
            {
                var filteredStudents = _studentRepository.GetAll()
                    .Where(s => s.Nume.ToLower().Contains(searchText) || 
                                s.Prenume.ToLower().Contains(searchText) ||
                                s.Email.ToLower().Contains(searchText) ||
                                s.Grupa.ToLower().Contains(searchText))
                    .ToList();
                dgStudents.ItemsSource = filteredStudents;
            }
        }
        
        private void BtnSearchStudent_Click(object sender, RoutedEventArgs e)
        {
            TxtStudentSearch_TextChanged(sender, null);
        }
        
        private void BtnResetStudentSearch_Click(object sender, RoutedEventArgs e)
        {
            txtStudentSearch.Clear();
            LoadStudents();
        }
        
        private void DgStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Implement selection behavior
        }
        
        #endregion
        
        #region Disciplina Event Handlers
        
        private void BtnAddDisciplina_Click(object sender, RoutedEventArgs e)
        {
            var window = new DisciplinaWindow();
            if (window.ShowDialog() == true)
            {
                RefreshData();
            }
        }
        
        private void BtnEditDisciplina_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int disciplinaId)
            {
                var disciplina = _disciplinaRepository.GetById(disciplinaId);
                if (disciplina != null)
                {
                    var window = new DisciplinaWindow(disciplina);
                    if (window.ShowDialog() == true)
                    {
                        RefreshData();
                    }
                }
            }
        }
        
        private void BtnDeleteDisciplina_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int disciplinaId)
            {
                var result = MessageBox.Show("Sunteți sigur că doriți să ștergeți această disciplină? Toate notele asociate vor fi șterse.", 
                    "Confirmare ștergere", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _disciplinaRepository.Delete(disciplinaId);
                        RefreshData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Eroare la ștergerea disciplinei: {ex.Message}", "Eroare", 
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        
        private void BtnViewDisciplinaGrades_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int disciplinaId)
            {
                var disciplina = _disciplinaRepository.GetById(disciplinaId);
                if (disciplina != null)
                {
                    var window = new DisciplinaGradesWindow(disciplina);
                    window.ShowDialog();
                }
            }
        }
        
        private void TxtDisciplinaSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtDisciplinaSearch.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadDiscipline();
            }
            else
            {
                var filteredDiscipline = _disciplinaRepository.GetAll()
                    .Where(d => d.Nume.ToLower().Contains(searchText) || 
                                d.Acronim.ToLower().Contains(searchText))
                    .ToList();
                dgDiscipline.ItemsSource = filteredDiscipline;
            }
        }
        
        private void BtnSearchDisciplina_Click(object sender, RoutedEventArgs e)
        {
            TxtDisciplinaSearch_TextChanged(sender, null);
        }
        
        private void BtnResetDisciplinaSearch_Click(object sender, RoutedEventArgs e)
        {
            txtDisciplinaSearch.Clear();
            LoadDiscipline();
        }
        
        private void DgDiscipline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Implement selection behavior
        }
        
        #endregion
        
        #region Nota Event Handlers
        
        private void BtnAddNota_Click(object sender, RoutedEventArgs e)
        {
            var window = new NotaWindow();
            if (window.ShowDialog() == true)
            {
                RefreshData();
            }
        }
        
        private void BtnEditNota_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int notaId)
            {
                var nota = _notaRepository.GetById(notaId);
                if (nota != null)
                {
                    var window = new NotaWindow(nota);
                    if (window.ShowDialog() == true)
                    {
                        RefreshData();
                    }
                }
            }
        }
        
        private void BtnDeleteNota_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int notaId)
            {
                var result = MessageBox.Show("Sunteți sigur că doriți să ștergeți această notă?", 
                    "Confirmare ștergere", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _notaRepository.Delete(notaId);
                        RefreshData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Eroare la ștergerea notei: {ex.Message}", "Eroare", 
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        
        private void CmbFilterStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyGradeFilters();
        }
        
        private void CmbFilterDisciplina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyGradeFilters();
        }
        
        private void ApplyGradeFilters()
        {
            var selectedStudent = cmbFilterStudent.SelectedItem as Student;
            var selectedDisciplina = cmbFilterDisciplina.SelectedItem as Disciplina;
            
            var filteredNotes = _notaRepository.GetAllWithDetails();
            
            if (selectedStudent != null && selectedStudent.Id != 0)
            {
                filteredNotes = filteredNotes.Where(n => n.StudentId == selectedStudent.Id).ToList();
            }
            
            if (selectedDisciplina != null && selectedDisciplina.Id != 0)
            {
                filteredNotes = filteredNotes.Where(n => n.DisciplinaId == selectedDisciplina.Id).ToList();
            }
            
            dgNote.ItemsSource = filteredNotes;
        }
        
        private void BtnResetGradeFilters_Click(object sender, RoutedEventArgs e)
        {
            cmbFilterStudent.SelectedIndex = 0;
            cmbFilterDisciplina.SelectedIndex = 0;
            LoadNote();
        }
        
        #endregion
        
        #region Report Event Handlers
        
        private void BtnGeneralReport_Click(object sender, RoutedEventArgs e)
        {
            // Generate general report with all students and their average grades
            var students = _studentRepository.GetAll();
            var reportData = new List<object>();
            
            foreach (var student in students)
            {
                var studentNotes = _notaRepository.GetAllWithDetails()
                    .Where(n => n.StudentId == student.Id)
                    .ToList();
                
                var averageGrade = studentNotes.Any() ? studentNotes.Average(n => n.ValoareNota) : 0;
                var passedCourses = studentNotes.Count(n => n.ValoareNota >= 5);
                var totalCourses = _disciplinaRepository.GetAll().Count();
                
                reportData.Add(new
                {
                    StudentId = student.Id,
                    NumeComplet = $"{student.Nume} {student.Prenume}",
                    Grupa = student.Grupa,
                    MedieGenerala = Math.Round(averageGrade, 2),
                    DisciplinePromovate = passedCourses,
                    TotalDiscipline = totalCourses,
                    ProcentajPromovare = totalCourses > 0 ? Math.Round((double)passedCourses / totalCourses * 100, 2) : 0
                });
            }
            
            // Configure DataGrid columns
            dgReport.Columns.Clear();
            dgReport.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new System.Windows.Data.Binding("StudentId") });
            dgReport.Columns.Add(new DataGridTextColumn { Header = "Nume Student", Binding = new System.Windows.Data.Binding("NumeComplet"), Width = 200 });
            dgReport.Columns.Add(new DataGridTextColumn { Header = "Grupa", Binding = new System.Windows.Data.Binding("Grupa"), Width = 100 });
            dgReport.Columns.Add(new DataGridTextColumn { Header = "Medie Generală", Binding = new System.Windows.Data.Binding("MedieGenerala"), Width = 120 });
            dgReport.Columns.Add(new DataGridTextColumn { Header = "Discipline Promovate", Binding = new System.Windows.Data.Binding("DisciplinePromovate"), Width = 150 });
            dgReport.Columns.Add(new DataGridTextColumn { Header = "Total Discipline", Binding = new System.Windows.Data.Binding("TotalDiscipline"), Width = 120 });
            dgReport.Columns.Add(new DataGridTextColumn { Header = "Procentaj Promovare", Binding = new System.Windows.Data.Binding("ProcentajPromovare"), Width = 150 });
            
            dgReport.ItemsSource = reportData;
            
            // Update summary
            var overallAverage = reportData.Any() ? reportData.Average(r => (double)r.GetType().GetProperty("MedieGenerala").GetValue(r, null)) : 0;
            txtReportSummary.Text = $"Raport General | Media generală a tuturor studenților: {Math.Round(overallAverage, 2)}";
        }
        
        private void BtnStudentReport_Click(object sender, RoutedEventArgs e)
        {
            // Show student selection dialog
            var window = new StudentSelectorWindow(_studentRepository.GetAll());
            if (window.ShowDialog() == true && window.SelectedStudent != null)
            {
                var student = window.SelectedStudent;
                var studentNotes = _notaRepository.GetAllWithDetails()
                    .Where(n => n.StudentId == student.Id)
                    .ToList();
                
                var reportData = new List<object>();
                var disciplines = _disciplinaRepository.GetAll();
                
                foreach (var disciplina in disciplines)
                {
                    var nota = studentNotes.FirstOrDefault(n => n.DisciplinaId == disciplina.Id);
                    
                    reportData.Add(new
                    {
                        DisciplinaId = disciplina.Id,
                        NumeDisciplina = disciplina.Nume,
                        Acronim = disciplina.Acronim,
                        TipEvaluare = disciplina.TipEvaluareString,
                        Nota = nota?.ValoareNota ?? 0,
                        DataNotarii = nota?.DataNotarii,
                        Status = nota != null ? (nota.ValoareNota >= 5 ? "Promovat" : "Nepromovat") : "Nenotat"
                    });
                }
                
                // Configure DataGrid columns
                dgReport.Columns.Clear();
                dgReport.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new System.Windows.Data.Binding("DisciplinaId") });
                dgReport.Columns.Add(new DataGridTextColumn { Header = "Disciplină", Binding = new System.Windows.Data.Binding("NumeDisciplina"), Width = 200 });
                dgReport.Columns.Add(new DataGridTextColumn { Header = "Acronim", Binding = new System.Windows.Data.Binding("Acronim"), Width = 100 });
                dgReport.Columns.Add(new DataGridTextColumn { Header = "Tip Evaluare", Binding = new System.Windows.Data.Binding("TipEvaluare"), Width = 120 });
                // dgReport.Columns.Add(new DataGridTextColumn { Header = "Nota", Binding = new System.Windows.Data.Binding("ValoareNota"), Width = 80 });
                // dgReport.Columns.Add(new DataGridTextColumn { Header = "Data Notării", Binding = new System.Windows.Data.Binding("DataNotarii"), Width = 120 });
                dgReport.Columns.Add(new DataGridTextColumn { Header = "Status", Binding = new System.Windows.Data.Binding("Status"), Width = 100 });
                
                dgReport.ItemsSource = reportData;
                
                // Update summary
                var averageGrade = studentNotes.Any() ? studentNotes.Average(n => n.ValoareNota) : 0;
                var passedCourses = studentNotes.Count(n => n.ValoareNota >= 5);
                txtReportSummary.Text = $"Raport pentru {student.Nume} {student.Prenume} | Media: {Math.Round(averageGrade, 2)} | " +
                                        $"Discipline promovate: {passedCourses} din {disciplines.Count()}";
            }
        }
        
        private void BtnDisciplinaReport_Click(object sender, RoutedEventArgs e)
        {
            // Show discipline selection dialog
            var window = new DisciplinaSelectorWindow(_disciplinaRepository.GetAll());
            if (window.ShowDialog() == true && window.SelectedDisciplina != null)
            {
                var disciplina = window.SelectedDisciplina;
                var disciplinaNotes = _notaRepository.GetAllWithDetails()
                    .Where(n => n.DisciplinaId == disciplina.Id)
                    .ToList();
                
                var reportData = new List<object>();
                var students = _studentRepository.GetAll();
                
                foreach (var student in students)
                {
                    var nota = disciplinaNotes.FirstOrDefault(n => n.StudentId == student.Id);
                    
                    reportData.Add(new
                    {
                        StudentId = student.Id,
                        NumeComplet = $"{student.Nume} {student.Prenume}",
                        Grupa = student.Grupa,
                        Nota = nota?.ValoareNota ?? 0,
                        DataNotarii = nota?.DataNotarii,
                        Status = nota != null ? (nota.ValoareNota >= 5 ? "Promovat" : "Nepromovat") : "Nenotat"
                    });
                }
                
                // Configure DataGrid columns
                dgReport.Columns.Clear();
                dgReport.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new System.Windows.Data.Binding("StudentId") });
                dgReport.Columns.Add(new DataGridTextColumn { Header = "Student", Binding = new System.Windows.Data.Binding("NumeComplet"), Width = 200 });
                dgReport.Columns.Add(new DataGridTextColumn { Header = "Grupa", Binding = new System.Windows.Data.Binding("Grupa"), Width = 100 });
                dgReport.Columns.Add(new DataGridTextColumn { Header = "Nota", Binding = new System.Windows.Data.Binding("ValoareNota"), Width = 80 });
                dgReport.Columns.Add(new DataGridTextColumn { Header = "Data Notării", Binding = new System.Windows.Data.Binding("DataNotarii"), Width = 120 });
                dgReport.Columns.Add(new DataGridTextColumn { Header = "Status", Binding = new System.Windows.Data.Binding("Status"), Width = 100 });
                
                dgReport.ItemsSource = reportData;
                
                // Update summary
                var averageGrade = disciplinaNotes.Any() ? disciplinaNotes.Average(n => n.ValoareNota) : 0;
                var passedStudents = disciplinaNotes.Count(n => n.ValoareNota >= 5);
                var totalStudents = students.Count();
                var passRate = totalStudents > 0 ? (double)passedStudents / totalStudents * 100 : 0;
                
                txtReportSummary.Text = $"Raport pentru {disciplina.Nume} | Media: {Math.Round(averageGrade, 2)} | " +
                                        $"Studenți promovați: {passedStudents} din {totalStudents} ({Math.Round(passRate, 2)}%)";
            }
        }
        
        private void BtnExportCsv_Click(object sender, RoutedEventArgs e)
        {
            if (dgReport.ItemsSource == null || !dgReport.Items.Count.Equals(0))
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    DefaultExt = "csv",
                    Title = "Salvare raport CSV"
                };
                
                if (saveFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        using (var writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            // Write header
                            var headers = dgReport.Columns.Select(c => c.Header.ToString()).ToList();
                            writer.WriteLine(string.Join(",", headers));
                            
                            // Write data
                            foreach (var item in dgReport.Items)
                            {
                                var values = new List<string>();
                                foreach (var column in dgReport.Columns)
                                {
                                    var binding = (column as DataGridTextColumn)?.Binding as System.Windows.Data.Binding;
                                    if (binding != null)
                                    {
                                        var property = item.GetType().GetProperty(binding.Path.Path);
                                        var value = property?.GetValue(item)?.ToString() ?? "";
                                        // Escape commas in values
                                        if (value.Contains(","))
                                        {
                                            value = $"\"{value}\"";
                                        }
                                        values.Add(value);
                                    }
                                }
                                writer.WriteLine(string.Join(",", values));
                            }
                        }
                        
                        MessageBox.Show("Raportul a fost exportat cu succes!", "Export reușit", 
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Eroare la exportul raportului: {ex.Message}", "Eroare", 
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nu există date pentru export. Generați mai întâi un raport.", 
                    "Avertisment", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        
        #endregion
    }
}
