using FitnessClubCP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClubCP.ViewModel
{
    public class AbonementViewModel: ViewModelBase
    {
        public ObservableCollection<TrenerInf> Treners { get; set; }
        public User CurrentUser { get; set; }
        public string FullName { get { return CurrentUser.Firstname + " " + CurrentUser.Lastname; } }
        public string Email { get { return CurrentUser.Email; } }
        public decimal ToPay { get { return CurrentUser.ToPay; } set { CurrentUser.ToPay = value; OnPropertyChanged("ToPay"); } }
        public AbonementViewModel(User u)
        {
            Treners = new ObservableCollection<TrenerInf>();
            CurrentUser = u;
            using(var db = new DB.DataBaseContext())
            {
                var abonements = db.Abonements.Where(x => x.User_Id == CurrentUser.Id);
                var treners = db.Treners.ToList();
                foreach(var x in abonements)
                {
                    foreach(var z in treners)
                    {
                        if(x.Trener_Id == z.Id) 
                        {
                            Treners.Add(new TrenerInf(z));
                            break;
                        }
                    }
                }
            }
        }
    }
    public class TrenerInf
    {
        public TrenerInf(Trener tr)
        {
            TrenerInfo ="ID:"+ tr.Id+ " " + tr.Firstname + " " + tr.Lastname + " " + tr.Middlename;  
        }
        public string TrenerInfo { get; set; }
    }
}
