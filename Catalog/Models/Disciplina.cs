using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudentGradeManagement.Models
{
    public class Disciplina : INotifyPropertyChanged
    {
        private int _id;
        private string _nume;
        private string _acronim;
        private int _tipEvaluare; // 1 = Examen, 2 = Colocviu
        
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
                }
            }
        }
        
        public string Acronim
        {
            get => _acronim;
            set
            {
                if (_acronim != value)
                {
                    _acronim = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public int TipEvaluare
        {
            get => _tipEvaluare;
            set
            {
                if (_tipEvaluare != value)
                {
                    _tipEvaluare = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TipEvaluareString));
                }
            }
        }
        
        // Computed property for evaluation type as string
        public string TipEvaluareString
        {
            get
            {
                return TipEvaluare switch
                {
                    1 => "Examen",
                    2 => "Colocviu",
                    _ => "Necunoscut"
                };
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
