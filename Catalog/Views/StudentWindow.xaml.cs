using System;
using System.Text.RegularExpressions;
using System.Windows;
using StudentGradeManagement.Models;
using StudentGradeManagement.Repositories;

namespace StudentGradeManagement.Views
{
    public partial class StudentWindow : Window
    {
        private readonly StudentRepository _repository;
        private readonly Student _student;
        private readonly bool _isEditMode;
        
        public StudentWindow()
        {
            InitializeComponent();
            
            _repository = new StudentRepository();
            _student = new Student();
            _isEditMode = false;
            
            Title = "Adăugare Student";
        }
        
        public StudentWindow(Student student)
        {
            InitializeComponent();
            
            _repository = new StudentRepository();
            _student = student;
            _isEditMode = true;
            
            Title = "Editare Student";
            
            // Populate fields
            txtNume.Text = student.Nume;
            txtPrenume.Text = student.Prenume;
            txtEmail.Text = student.Email;
            txtGrupa.Text = student.Grupa;
        }
        
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                // Update student object
                _student.Nume = txtNume.Text.Trim();
                _student.Prenume = txtPrenume.Text.Trim();
                _student.Email = txtEmail.Text.Trim();
                _student.Grupa = txtGrupa.Text.Trim();
                
                try
                {
                    if (_isEditMode)
                    {
                        _repository.Update(_student);
                    }
                    else
                    {
                        _repository.Add(_student);
                    }
                    
                    DialogResult = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la salvarea studentului: {ex.Message}", "Eroare", 
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        
        private bool ValidateInput()
        {
            txtValidationErrors.Text = "";
            bool isValid = true;
            
            // Validate Nume
            if (string.IsNullOrWhiteSpace(txtNume.Text))
            {
                txtValidationErrors.Text += "Numele este obligatoriu.\n";
                isValid = false;
            }
            
            // Validate Prenume
            if (string.IsNullOrWhiteSpace(txtPrenume.Text))
            {
                txtValidationErrors.Text += "Prenumele este obligatoriu.\n";
                isValid = false;
            }
            
            // Validate Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtValidationErrors.Text += "Email-ul este obligatoriu.\n";
                isValid = false;
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                txtValidationErrors.Text += "Email-ul nu este valid.\n";
                isValid = false;
            }
            
            // Validate Grupa
            if (string.IsNullOrWhiteSpace(txtGrupa.Text))
            {
                txtValidationErrors.Text += "Grupa este obligatorie.\n";
                isValid = false;
            }
            
            return isValid;
        }
    }
}
