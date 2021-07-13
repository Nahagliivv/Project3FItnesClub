using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FitnessClubCP.ViewModel
{
    public class UserCabViewModel: UserMainPageViewModel
    {
        public UserCabViewModel()
        {
            TrenerCollection = new System.Collections.ObjectModel.ObservableCollection<SingleTrenerViewModel>();
            using(var db = new DB.DataBaseContext())
            {
                var ab = db.Abonements.Where(x => x.User_Id == Model.CurrentUser.CurrentUserID);
                var treners = db.Treners.ToList();
                foreach(var x in ab)
                {
                    foreach(var z in treners)
                    {
                        if(x.Trener_Id == z.Id)
                        {
                            TrenerCollection.Add(new SingleTrenerViewModel(z));
                        }
                    }
                }
            }
            if(TrenerCollection.Count() == 0)
            {
                MessageStatus = Visibility.Visible;
            }
        }
        public decimal ToPay { get { return _ToPay(); } }
        public string UserName { get { return ReturnUser(); } }
        public ICommand DelTrener
        {
            get { return new DelegateCommand(() => { DeleteT(); }); }
            private set { }
        }
        decimal _ToPay()
        {
            using(var db = new DB.DataBaseContext())
            {
                return db.Users.Where(x => x.Id == Model.CurrentUser.CurrentUserID).FirstOrDefault().ToPay;
            }
        }
        void DeleteT()
        {
            if(FocusTrener == null) { return; }
            var accept = MessageBox.Show("Вы действительно хотите отказаться от занятий у выбранного тренера?", "Отмена занятий у тренера", MessageBoxButton.YesNo);
            if (accept != MessageBoxResult.Yes)
            {
                return;
            }
            using(var db = new DB.DataBaseContext())
            {
                var remTren = db.Abonements.Where(x => x.Trener_Id == FocusTrener.CurrentTrener.Id && x.User_Id == Model.CurrentUser.CurrentUserID).FirstOrDefault();
                db.Abonements.Remove(remTren);
                db.SaveChanges();
                TrenerCollection.Remove(FocusTrener);
            }
        }
        void _Home()
        {
            App.Current.MainWindow.Hide();
            App.Current.MainWindow = new View.UserMainPage();
            App.Current.MainWindow.Show();
        }
        public ICommand Home
        {
            get { return new DelegateCommand(() => { _Home(); }); }
            private set { }
        }
        string ReturnUser()
        {
            using(var db = new DB.DataBaseContext())
            {
               var u = db.Users.Find(Model.CurrentUser.CurrentUserID);
                return u.Firstname + " " + u.Lastname;
            }
        }
        ~UserCabViewModel()
        {
            Home = null;
            TrenerCollection = null;
            DelTrener = null;
        }
    }
}
