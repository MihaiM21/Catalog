using System;
using System.Windows;
using System.Windows.Controls;
using StudentGradeManagement.Models;
using StudentGradeManagement.Repositories;

namespace StudentGradeManagement.Views
{
    public partial class NotaWindow : Window
    {
        private readonly NotaRepository _repository;
        private readonly StudentRepository _studentRepository;
        private readonly DisciplinaRepository _disciplinaRepository;
        private readonly Nota _nota;
        private readonly bool _isEditMode;
        
        public NotaWindow()
        {
            InitializeComponent();
            
            _repository = new NotaRepository();
            _studentRepository = new StudentRepository();
            _disciplinaRepository = new DisciplinaRepository();
            _nota = new Nota();
            _isEditMode = false;
            
            Title = "Adăugare Notă";
            
            // Set default date to today
            dpDataNotarii.SelectedDate = DateTime.Today;
            
            // Load students and disciplines
            LoadStudents();
            LoadDiscipline();
        }
        
        public NotaWindow(Nota nota)
        {
            InitializeComponent();
            
            _repository = new NotaRepository();
            _studentRepository = new StudentRepository();
            _disciplinaRepository = new DisciplinaRepository();
            _nota = nota;
            _isEditMode = true;
            
            Title = "Editare Notă";
            
            // Load students and disciplines
            LoadStudents();
            LoadDiscipline();
            
            // Populate fields
            sliderNota.Value = nota.ValoareNota;
            dpDataNotarii.SelectedDate = nota.DataNotarii;
            
            // Select the correct student and discipline
            foreach (var student in cmbStudent.Items)
            {
                if ((student as Student).Id == nota.StudentId)
                {
                    cmbStudent.SelectedItem = student;
                    break;
                }
            }
            
            foreach (var disciplina in cmbDisciplina.Items)
            {
                if ((disciplina as Disciplina).Id == nota.DisciplinaId)
                {
                    cmbDisciplina.SelectedItem = disciplina;
                    break;
                }
            }
        }
        
        private void LoadStudents()
        {
            cmbStudent.ItemsSource = _studentRepository.GetAll();
            if (cmbStudent.Items.Count > 0)
            {
                cmbStudent.SelectedIndex = 0;
            }
        }
        
        private void LoadDiscipline()
        {
            cmbDisciplina.ItemsSource = _disciplinaRepository.GetAll();
            if (cmbDisciplina.Items.Count > 0)
            {
                cmbDisciplina.SelectedIndex = 0;
            }
        }

        private void SliderNota_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (txtNota != null && sliderNota != null)
            {
                txtNota.Text = sliderNota.Value.ToString();
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                // Update nota object
                _nota.StudentId = (cmbStudent.SelectedItem as Student).Id;
                _nota.DisciplinaId = (cmbDisciplina.SelectedItem as Disciplina).Id;
                _nota.ValoareNota = (int)sliderNota.Value; // Make sure this is ValoareNota
                _nota.DataNotarii = dpDataNotarii.SelectedDate.Value;

                try
                {
                    if (_isEditMode)
                    {
                        _repository.Update(_nota);
                    }
                    else
                    {
                        _repository.Add(_nota);
                    }

                    DialogResult = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la salvarea notei: {ex.Message}", "Eroare",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        
        private bool ValidateInput()
        {
            txtValidationErrors.Text = "";
            bool isValid = true;
            
            // Validate Student
            if (cmbStudent.SelectedItem == null)
            {
                txtValidationErrors.Text += "Selectarea studentului este obligatorie.\n";
                isValid = false;
            }
            
            // Validate Disciplina
            if (cmbDisciplina.SelectedItem == null)
            {
                txtValidationErrors.Text += "Selectarea disciplinei este obligatorie.\n";
                isValid = false;
            }
            
            // Validate Data Notarii
            if (dpDataNotarii.SelectedDate == null)
            {
                txtValidationErrors.Text += "Data notării este obligatorie.\n";
                isValid = false;
            }
            
            return isValid;
        }
    }
}
