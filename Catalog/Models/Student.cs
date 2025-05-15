using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudentGradeManagement.Models
{
    public class Student : INotifyPropertyChanged
    {
        private int _id;
        private string _nume;
        private string _prenume;
        private string _email;
        private string _grupa;
        
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public string Nume
        {
            get => _nume;
            set
            {
                if (_nume != value)
                {
                    _nume = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(NumeComplet));
                }
            }
        }
        
        public string Prenume
        {
            get => _prenume;
            set
            {
                if (_prenume != value)
                {
                    _prenume = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(NumeComplet));
                }
            }
        }
        
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public string Grupa
        {
            get => _grupa;
            set
            {
                if (_grupa != value)
                {
                    _grupa = value;
                    OnPropertyChanged();
                }
            }
        }
        
        // Computed property for full name
        public string NumeComplet => $"{Nume} {Prenume}";
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
