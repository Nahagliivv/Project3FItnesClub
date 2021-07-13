using FitnessClubCP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FitnessClubCP.ViewModel
{
    public class EditTrenerViewModel: AdminMainPageViewModel
    {
        Window curWnd;
        public EditTrenerViewModel(Trener tr, Window wnd)
        {
            NewTrener = tr;
            curWnd = wnd;
        }
        public ICommand Save
        {
            get { return new DelegateCommand(() => { Sav(); }); }
        }
        void Sav()
        {
            if (Firstname == null || Firstname == "")
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
            if (Age <= 18 || Age > 100)
            {
                MessageBox.Show("Возраст тренера выходит за допустимый диапазон.. 100>возраст>18");
                return;
            }
            if (Experience <= 0 || Age < Experience)
            {
                MessageBox.Show("Возраст не может быть меньше, чем опыт");
                return;
            }
            if (Sex == null || Sex == "")
            {
                MessageBox.Show("Поле пола не заполнено");
                return;
            }
            if (MaxClients < 1)
            {
                MessageBox.Show("Должен быть хотяб 1 клиент..");
                return;
            }
            int checkdays = 0;
            if (Monday == true)
            {
                checkdays++;
            }
            if (Tuesday == true)
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
            if (checkdays == 0)
            {
                MessageBox.Show("У тренера должен быть хотяб 1 рабочий день в неделю..");
                return;
            }
            using (var db = new DB.DataBaseContext())
            {
                db.Treners.Attach(NewTrener);
                db.Entry(NewTrener).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                curWnd.Close();
            }
        }
    }
}
