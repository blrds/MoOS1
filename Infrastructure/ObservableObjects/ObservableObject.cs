using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MoOS1.Infrastructure.ObservableObjects
{
    /// <summary>
    /// Реализует простейший прототип класса-уведомителя
    /// </summary>
    class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
