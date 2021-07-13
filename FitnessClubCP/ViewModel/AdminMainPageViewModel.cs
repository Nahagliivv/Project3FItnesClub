using FitnessClubCP.Model;
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
    public class AdminMainPageViewModel : ViewModelBase
    {
        public ObservableCollection<Trener> Treners { get; set; }
        public ObservableCollection<AbonementViewModel> Abonements { get; set; }
        public AbonementViewModel FocusAbonement { get;set; }
        public Trener FocusTrener { get; set; }
        protected Trener NewTrener { get; set; }
        public AdminMainPageViewModel()
        {
            NewTrener = new Trener();
            Treners = new ObservableCollection<Trener>();
            Abonements = new ObservableCollection<AbonementViewModel>();
            using (var db = new DB.DataBaseContext())
            {
                var treners = db.Treners.ToList();
                foreach (var x in treners)
                {
                    Treners.Add(x);
                }
                RefreshAbon();
            }
        }
        public string Firstname { get { return NewTrener.Firstname; } set { NewTrener.Firstname = value; OnPropertyChanged("Firstname"); } }
        public string Lastname { get { return NewTrener.Lastname; } set { NewTrener.Lastname = value; OnPropertyChanged("Lastname"); } }
        public string Sex { get { return NewTrener.Sex; } set { NewTrener.Sex = value; OnPropertyChanged("Sex"); } }
        public string About { get { return NewTrener.About; } set { NewTrener.About = value; OnPropertyChanged("About"); } }
        public string Middlename { get { return NewTrener.Middlename; } set { NewTrener.Middlename = value; OnPropertyChanged("Middlename"); } }
        public int Age { get { return NewTrener.Age; } set { NewTrener.Age = value; OnPropertyChanged("Age"); } }
        public int Experience { get { return NewTrener.Experience; } set { NewTrener.Experience = value; OnPropertyChanged("Experience"); } }
        public bool Monday { get { return NewTrener.Monday; } set { NewTrener.Monday = value; OnPropertyChanged("Monday"); } }
        public bool Tuesday { get { return NewTrener.Tuesday; } set { NewTrener.Tuesday = value; OnPropertyChanged("Tuesday"); } }
        public bool Wednesday { get { return NewTrener.Wednesday; } set { NewTrener.Wednesday = value; OnPropertyChanged("Wednesday"); } }
        public bool Thursday { get { return NewTrener.Thursday; } set { NewTrener.Thursday = value; OnPropertyChanged("Thursday"); } }
        public bool Friday { get { return NewTrener.Friday; } set { NewTrener.Friday = value; OnPropertyChanged("Friday"); } }
        public bool Saturday { get { return NewTrener.Saturday; } set { NewTrener.Saturday = value; OnPropertyChanged("Saturday"); } }
        public bool Sunday { get { return NewTrener.Sunday; } set { NewTrener.Sunday = value; OnPropertyChanged("Sunday"); } }
        public int MaxClients { get { return NewTrener.MaxClients; } set { NewTrener.MaxClients = value; OnPropertyChanged("MaxClients"); } }
        public decimal MoneyEdit { get; set; }
       
        public ICommand AddTrener
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    AddTren();
                });
            }
        }
        void AddTren()
        {
            if(Firstname == null || Firstname == "")
            {
                MessageBox.Show("Поле имени тренера не может быть пустым..");
                return;
            }
            if (Lastname == null || Lastname == "")
            {
                MessageBox.Show("Поле фамилии тренера не может быть пустым..");
                return;
            }
            if (Middlename == null || Middlename == "")
            {
                MessageBox.Show("Поле отчества тренера не может быть пустым..");
                return;
            }
            if (About == null || About == "")
            {
                MessageBox.Show("Поле информации о тренере не может быть пустым..");
                return;
            }
            if (Age <=18 || Age >100 )
            {
                MessageBox.Show("Возраст тренера выходит за допустимый диапазон.. 100>возраст>18");
                return;
            }
            if (Experience <= 0 || Age < Experience)
            {
                MessageBox.Show("Возраст не может быть меньше, чем опыт");
                return;
            }
            if(Sex==null || Sex == "")
            {
                MessageBox.Show("Поле пола не заполнено");
                return;
            }
            if(MaxClients < 1)
            {
                MessageBox.Show("Должен быть хотяб 1 клиент..");
                return;
            }
            int checkdays = 0;
            if(Monday == true)
            {
                checkdays++;
            }
            if(Tuesday == true)
            {
                checkdays++;
            }
            if (Wednesday == true)
            {
                checkdays++;
            }
            if (Thursday == true)
            {
                checkdays++;
            }
            if (Friday == true)
            {
                checkdays++;
            }
            if (Saturday == true)
            {
                checkdays++;
            }
            if (Sunday == true)
            {
                checkdays++;
            }
            if(checkdays == 0)
            {
                MessageBox.Show("У тренера должен быть хотяб 1 рабочий день в неделю..");
                return;
            }
            using(var db = new DB.DataBaseContext())
            {
                db.Treners.Add(NewTrener);
                Treners.Add(NewTrener);
                db.SaveChanges();
            }
        }
        public ICommand Delete
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Del();
                });
            }
        }
        public ICommand Edit
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Ed();
                });
            }
        }
       public ICommand AddMoney {
            get
            {
                return new DelegateCommand(() =>
                {
                    _AddMoney();
                });
            }
        }
       public ICommand RemoveMoney {
            get
            {
                return new DelegateCommand(() =>
                {
                    _RemoveMoney();
                });
            }
        }
        void Ed()
        {
            if (FocusTrener == null) return;
            var edit = new View.EditTrener(FocusTrener);
            edit.ShowDialog();
            using (var db = new DB.DataBaseContext())
            {
                Treners.Clear();
                var treners = db.Treners.ToList();
                foreach (var x in treners)
                {
                    Treners.Add(x);
                }
            }
        }
        void Del()
        {
            if(FocusTrener == null) { return; }
            using(var db = new DB.DataBaseContext())
            {
                db.Treners.Attach(FocusTrener);
                db.Treners.Remove(FocusTrener);
                Treners.Remove(FocusTrener);
                db.SaveChanges();
            }
        }
        void _AddMoney()
        {
            if(MoneyEdit == 0 || FocusAbonement ==null) { return; }
            using (var db = new DB.DataBaseContext())
            {
                FocusAbonement.CurrentUser.ToPay += MoneyEdit;
                db.Users.Attach(FocusAbonement.CurrentUser);
                db.Entry(FocusAbonement.CurrentUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                RefreshAbon();
            }
        }
        void _RemoveMoney()
        {
            if (MoneyEdit == 0 || FocusAbonement == null) { return; }
            using (var db = new DB.DataBaseContext())
            {
                FocusAbonement.CurrentUser.ToPay -= MoneyEdit;
                db.Users.Attach(FocusAbonement.CurrentUser);
                db.Entry(FocusAbonement.CurrentUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                RefreshAbon();
            }
        }
        void RefreshAbon()
        {
            Abonements.Clear();
            using (var db = new DB.DataBaseContext())
            {
                var users = db.Users.ToList();
                foreach (var x in users)
                {
                    if (db.Abonements.Count() != 0 && x.Id != Model.CurrentUser.CurrentUserID)
                    {
                        Abonements.Add(new AbonementViewModel(x));
                    }
                }
            }
        }

    }
}
