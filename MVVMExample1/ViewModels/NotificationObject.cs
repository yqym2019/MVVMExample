using System.ComponentModel;

namespace MVVMExample1
{
    class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { }; 

        public void RaisePropertyChanged(string propertyName)
        {
            if(this.PropertyChanged!=null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
