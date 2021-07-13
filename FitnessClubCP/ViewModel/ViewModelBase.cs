using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnessClubCP.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ICommand ShDw
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ShutDown();
                });
            }
        }
        void ShutDown()
        {
            App.Current.Shutdown();
        }
        public ICommand Exit
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Ex();
                });
            }
        }
        void Ex()
        {

            App.Current.MainWindow.Hide();
            App.Current.MainWindow = new MainWindow();
            App.Current.MainWindow.Show();
        }
    }
}
