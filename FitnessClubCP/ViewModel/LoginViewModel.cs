using FitnessClubCP.DB;
using FitnessClubCP.Logic;
using FitnessClubCP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessClubCP.ViewModel
{
    public class LoginViewModel: ViewModelBase
    {
        User u;
        string password;
        string email;
        string status;
        public bool SaveUser { get; set; } = false;
        public LoginViewModel()
        {
            //Logic.GСollector.Collect();
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public ICommand Login
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    if (x != null) { RLandP(x); }
                });
            }
        }
        private void RLandP(object Pass)
        {
            var a = Pass as PasswordBox;
            Password = a.Password;
            int linq = 0;
            using (DataBaseContext db = new DataBaseContext())
            {
                linq = db.Users.Count(q => q.Email == Email);
                if (linq == 0)
                {
                    Status = "Зарегистрированного пользователя с таким Email нет";
                    return;
                }
            }
            using (DataBaseContext db = new DataBaseContext())
            {
                var lin = db.Users.Where(q => q.Email == Email).FirstOrDefault();
                u = lin;
            }
            if (HashPassword.VerifyHashedPassword(u.Password, Password))
            {
                CurrentUser.CurrentUserID = u.Id; //////////не трогать!!!,
                if (u.Email == "Rebesh.mark@gmail.com")
                {
                    App.Current.MainWindow.Hide();
                    App.Current.MainWindow = new View.AdminMainPage();
                    App.Current.MainWindow.Show();
                }
                else
                {
                    App.Current.MainWindow.Hide();
                    App.Current.MainWindow = new View.UserMainPage();
                    App.Current.MainWindow.Show();
                }
            }
            else
            {
                Status = "Неверный пароль";
                return;
            }
        }
      
        void _Reg()
        {
            App.Current.MainWindow.Hide();
            App.Current.MainWindow = new View.RegView();
            App.Current.MainWindow.Show();
        }
        public ICommand Reg
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _Reg();
                });
            }
        }
    }
}
