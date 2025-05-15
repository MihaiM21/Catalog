using System.Collections.Generic;
using System.Windows;
using StudentGradeManagement.Models;

namespace StudentGradeManagement.Views
{
    public partial class DisciplinaSelectorWindow : Window
    {
        public Disciplina SelectedDisciplina { get; private set; }
        
        public DisciplinaSelectorWindow(List<Disciplina> discipline)
        {
            InitializeComponent();
            
            lstDiscipline.ItemsSource = discipline;
            if (lstDiscipline.Items.Count > 0)
            {
                lstDiscipline.SelectedIndex = 0;
            }
        }
        
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (lstDiscipline.SelectedItem != null)
            {
                SelectedDisciplina = lstDiscipline.SelectedItem as Disciplina;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Vă rugăm să selectați o disciplină.", "Avertisment", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
