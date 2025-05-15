using System.Collections.Generic;
using System.Windows;
using StudentGradeManagement.Models;

namespace StudentGradeManagement.Views
{
    public partial class StudentSelectorWindow : Window
    {
        public Student SelectedStudent { get; private set; }
        
        public StudentSelectorWindow(List<Student> students)
        {
            InitializeComponent();
            
            lstStudents.ItemsSource = students;
            if (lstStudents.Items.Count > 0)
            {
                lstStudents.SelectedIndex = 0;
            }
        }
        
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (lstStudents.SelectedItem != null)
            {
                SelectedStudent = lstStudents.SelectedItem as Student;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Vă rugăm să selectați un student.", "Avertisment", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
