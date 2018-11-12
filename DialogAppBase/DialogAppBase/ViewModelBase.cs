using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DialogAppBase
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProp<T>(ref T item, T value, [CallerMemberName] string propName = null)
        {
            if (EqualityComparer<T>.Default.Equals(item, value)) return;
            item = value;
            NotifyPropertyChanged(propName);
        }
    }
}
