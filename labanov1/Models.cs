using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace labanov1
{
    /// <summary>
    /// Класс для хранения данных профиля пользователя
    /// </summary>
    public class UserProfile
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Education { get; set; }
        public string ActivityLevel { get; set; }
    }

    /// <summary>
    /// Класс "Привычка" с поддержкой уведомлений об изменениях (для DataGrid)
    /// </summary>
    public class Habit : INotifyPropertyChanged
    {
        private string _name;
        private string _time;
        private bool _isCompleted;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string Time
        {
            get => _time;
            set { _time = value; OnPropertyChanged(); }
        }

        public bool IsCompleted
        {
            get => _isCompleted;
            set { _isCompleted = value; OnPropertyChanged(); }
        }

        // Реализация интерфейса для того, чтобы интерфейс видел изменения в коде
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}