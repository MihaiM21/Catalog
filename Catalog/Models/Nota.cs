using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudentGradeManagement.Models
{
    public class Nota : INotifyPropertyChanged
    {
        private int _id;
        private int _studentId;
        private int _disciplinaId;
        private int _nota;
        private DateTime _dataNotarii;
        
        // Additional properties for display purposes
        private string _studentNume;
        private string _disciplinaNume;
        
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
        
        public int StudentId
        {
            get => _studentId;
            set
            {
                if (_studentId != value)
                {
                    _studentId = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public int DisciplinaId
        {
            get => _disciplinaId;
            set
            {
                if (_disciplinaId != value)
                {
                    _disciplinaId = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public int ValoareNota
        {
            get => _nota;
            set
            {
                if (_nota != value)
                {
                    _nota = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public DateTime DataNotarii
        {
            get => _dataNotarii;
            set
            {
                if (_dataNotarii != value)
                {
                    _dataNotarii = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public string StudentNume
        {
            get => _studentNume;
            set
            {
                if (_studentNume != value)
                {
                    _studentNume = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public string DisciplinaNume
        {
            get => _disciplinaNume;
            set
            {
                if (_disciplinaNume != value)
                {
                    _disciplinaNume = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
