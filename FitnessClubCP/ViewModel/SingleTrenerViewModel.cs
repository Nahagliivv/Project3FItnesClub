using FitnessClubCP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnessClubCP.ViewModel
{
    public class SingleTrenerViewModel: ViewModelBase
    {
        public Trener CurrentTrener { get; set; }
        public SingleTrenerViewModel(Trener tr)
        {
            CurrentTrener = tr;
            CheckDays();
            CheckFreeCapacity();
        }
        public string Fullname { get { return CurrentTrener.Firstname + " " + CurrentTrener.Lastname + " " + CurrentTrener.Middlename; } }
        public string About { get { return CurrentTrener.About; } }
        public string Sex { get { return CurrentTrener.Sex; } }
        public int Experience { get { return CurrentTrener.Experience; } }
        public int Age { get { return CurrentTrener.Age; } }
        public int Capacity { get { return CurrentTrener.MaxClients; } }
        private int _FreeCapacity { get; set; }
        public int FreeCapacity { get { return _FreeCapacity; } set { _FreeCapacity = value; OnPropertyChanged("FreeCapacity"); } }
        public string Days { get; set; } = "";
        void CheckDays()
        {
            if(CurrentTrener.Monday == true) { Days += "Понедельник "; }
            if (CurrentTrener.Tuesday == true) { Days += "Вторник "; }
            if (CurrentTrener.Wednesday == true) { Days += "Среда "; }
            if (CurrentTrener.Thursday == true) { Days += "Четверг "; }
            if (CurrentTrener.Friday == true) { Days += "Пятница "; }
            if (CurrentTrener.Saturday == true) { Days += "Суббота "; }
            if (CurrentTrener.Sunday == true) { Days += "Воскресенье "; }
        }
        void CheckFreeCapacity()
        {
            using(var db = new DB.DataBaseContext())
            {
                var cap = db.Abonements.Count(x => x.Trener_Id == CurrentTrener.Id);
                FreeCapacity = CurrentTrener.MaxClients - cap;
            }
        }
        public ICommand ShowComments
        {
            get { return new DelegateCommand(() => {  Comments(); }); }
        }
        void Comments()
        {
            var comwnd = new View.CommentWindowView(CurrentTrener);
            comwnd.ShowDialog();
        }
    }
}
