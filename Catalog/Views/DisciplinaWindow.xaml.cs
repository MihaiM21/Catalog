using System;
using System.Windows;
using System.Windows.Controls;
using StudentGradeManagement.Models;
using StudentGradeManagement.Repositories;

namespace StudentGradeManagement.Views
{
    public partial class DisciplinaWindow : Window
    {
        private readonly DisciplinaRepository _repository;
        private readonly Disciplina _disciplina;
        private readonly bool _isEditMode;
        
        public DisciplinaWindow()
        {
            InitializeComponent();
            
            _repository = new DisciplinaRepository();
            _disciplina = new Disciplina();
            _isEditMode = false;
            
            Title = "Adăugare Disciplină";
            cmbTipEvaluare.SelectedIndex = 0;
        }
        
        public DisciplinaWindow(Disciplina disciplina)
        {
            InitializeComponent();
            
            _repository = new DisciplinaRepository();
            _disciplina = disciplina;
            _isEditMode = true;
            
            Title = "Editare Disciplină";
            
            // Populate fields
            txtNume.Text = disciplina.Nume;
            txtAcronim.Text = disciplina.Acronim;
            
            // Select the correct evaluation type
            foreach (ComboBoxItem item in cmbTipEvaluare.Items)
            {
                if (int.Parse(item.Tag.ToString()) == disciplina.TipEvaluare)
                {
                    cmbTipEvaluare.SelectedItem = item;
                    break;
                }
            }
        }
        
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                // Update disciplina object
                _disciplina.Nume = txtNume.Text.Trim();
                _disciplina.Acronim = txtAcronim.Text.Trim();
                _disciplina.TipEvaluare = int.Parse(((ComboBoxItem)cmbTipEvaluare.SelectedItem).Tag.ToString());
                
                try
                {
                    if (_isEditMode)
                    {
                        _repository.Update(_disciplina);
                    }
                    else
                    {
                        _repository.Add(_disciplina);
                    }
                    
                    DialogResult = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la salvarea disciplinei: {ex.Message}", "Eroare", 
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
                txtValidationErrors.Text += "Numele disciplinei este obligatoriu.\n";
                isValid = false;
            }
            
            // Validate Acronim
            if (string.IsNullOrWhiteSpace(txtAcronim.Text))
            {
                txtValidationErrors.Text += "Acronimul este obligatoriu.\n";
                isValid = false;
            }
            
            // Validate Tip Evaluare
            if (cmbTipEvaluare.SelectedItem == null)
            {
                txtValidationErrors.Text += "Tipul de evaluare este obligatoriu.\n";
                isValid = false;
            }
            
            return isValid;
        }

        private void cmbTipEvaluare_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
