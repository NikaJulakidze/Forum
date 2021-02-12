using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Forum.Mobile.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null && !string.IsNullOrEmpty(propertyName))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
