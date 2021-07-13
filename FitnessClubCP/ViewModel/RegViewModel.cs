using FitnessClubCP.DB;
using FitnessClubCP.Logic;
using FitnessClubCP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessClubCP.ViewModel
{
    public class RegViewModel : ViewModelBase
    {
        public User u;
        public RegViewModel()
        {
            u = new User();
        }
        public string Email
        {
            get { return u.Email; }
            set
            {
                u.Email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Firstname
        {
            get { return u.Firstname; }
            set
            {
                u.Firstname = value;
                OnPropertyChanged("Firstname");
            }
        }
        public string Lastname
        {
            get { return u.Lastname; }
            set
            {
                u.Lastname = value;
                OnPropertyChanged("Lastname");
            }
        }
        string errormessage;
        public string ErrorMessage
        {
            get { return errormessage; }
            set
            {
                errormessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }
        public ICommand CreateAccount
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    if (x != null) { Create(x); }
                });
            }
        }
        public void Create(object parameter)
        {
            var values = (Password)parameter;
            var password = values.pass1 as PasswordBox;
            var passwordcopy = values.pass2 as PasswordBox;
            Regex femail = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");///для почтты
            if (Email == null || !femail.IsMatch(Email))
            {
                ErrorMessage = "Неправильный формат электронной почты"; return;
            }
            using (DataBaseContext db = new DataBaseContext())
            {
                foreach (var x in db.Users)
                {
                    if (x.Email == Email) { ErrorMessage = "Пользователь с таким Email уже зарегистрирован"; return; }
                }
            }
            if (Firstname == "" || Firstname == null)
            {
                ErrorMessage = "Введите имя";
                return;
            }
            if (Lastname == "" || Lastname == null)
            {
                ErrorMessage = "Введите фамилию";
                return;
            }
            if (password.Password != passwordcopy.Password)
            {
                ErrorMessage = "Пароли не совпадают";
                return;
            }
            var rule = new Regex(@"^(?=.{8,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$");//для пароля
            if (!rule.IsMatch(password.Password))
            {
                ErrorMessage = "В пароле должны быть: цифра, буквы нижнего и верхнего \nрегистра, длина от 8 до 16 символов ";
                return;
            }
            u.Password = HashPassword.Hash(password.Password);
            using (DataBaseContext db = new DataBaseContext())
            {
                db.Users.Add(u);
                db.SaveChanges();
                App.Current.MainWindow.Hide();
                App.Current.MainWindow = new MainWindow();
                App.Current.MainWindow.Show();
            }
        }
        public ICommand Login
        {
            get
            {
                return new DelegateCommand(() => { Log(); });
            }
        }
        void Log()
        {
            App.Current.MainWindow.Hide();
            App.Current.MainWindow = new MainWindow();
            App.Current.MainWindow.Show();
        }
    }
}
