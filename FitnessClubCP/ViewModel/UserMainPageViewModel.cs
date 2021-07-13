using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FitnessClubCP.ViewModel
{
    public class UserMainPageViewModel: ViewModelBase
    {
        public ObservableCollection<SingleTrenerViewModel> TrenerCollection { get; set; }
        public SingleTrenerViewModel FocusTrener { get; set; }
        public UserMainPageViewModel()
        {
            TrenerCollection = new ObservableCollection<SingleTrenerViewModel>();
            using(var db = new DB.DataBaseContext())
            {
                var treners = db.Treners.ToList();
                foreach(var x in treners)
                {
                    var trener = new SingleTrenerViewModel(x);
                    if(trener.FreeCapacity !=0)
                    TrenerCollection.Add(trener);
                }
            }
            if(TrenerCollection.Count() == 0)
            {
                MessageStatus = Visibility.Visible;
            }
        }
        public Visibility MessageStatus { get; set; } = Visibility.Collapsed;
        public ICommand UserCab
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    UCab();
                });
            }
            private set { }
        }
        void UCab()
        {

            App.Current.MainWindow.Hide();
            App.Current.MainWindow = new View.UserCab();
            App.Current.MainWindow.Show();
        }
      
        public ICommand AddTrener
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _AddTrener();
                });
            }
            private set { }
        }

        void _AddTrener()
        {
            if (FocusTrener == null) return;
            using(var db = new DB.DataBaseContext())
            {
                var curCheck = db.Abonements.Where(x => x.Trener_Id == FocusTrener.CurrentTrener.Id && x.User_Id == Model.CurrentUser.CurrentUserID).FirstOrDefault();
                if(curCheck != null)
                {
                    MessageBox.Show("Вы уже записаны к выбраному тренеру....");
                    return;
                }
            }
            if(FocusTrener.FreeCapacity == 0)
            {
                MessageBox.Show("У выбранного тренера уже собралась полная группа, записаться к нему сейчас невозможно");
                return;
            }
            var accept = MessageBox.Show("Вы действительно хотите записаться на занятия к выбранному тренеру?", "Запись к тренеру", MessageBoxButton.YesNo);
            if (accept != MessageBoxResult.Yes)
            {
                return;
            }
            using(var db = new DB.DataBaseContext())
            {
                db.Abonements.Add(new Model.Abonements() { User_Id = Model.CurrentUser.CurrentUserID, Trener_Id = FocusTrener.CurrentTrener.Id });
                FocusTrener.FreeCapacity--;
                db.SaveChanges();
            }
        }
        ~UserMainPageViewModel()
        {
            TrenerCollection = null;
            FocusTrener = null;
            AddTrener = null;
            UserCab = null;
        }
    }
}
