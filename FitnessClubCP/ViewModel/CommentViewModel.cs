using FitnessClubCP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnessClubCP.ViewModel
{
    public class CommentViewModel:ViewModelBase
    {
        public ObservableCollection<Model.Comment> CurrentComments { get; set; }
        public string Textt { get { return _Textt; } set { _Textt = value; OnPropertyChanged("Textt"); } }
        private string _Textt { get; set; }
        Model.Trener CurrentTrener { get; set; }
        protected CommentViewModel()
        {
        }
        public CommentViewModel(Model.Trener ticket)
        {
            CurrentComments = new ObservableCollection<Model.Comment>();
            CurrentTrener = ticket;
            using (var db = new DB.DataBaseContext())
            {
                var currentRev = db.Comments.Where(x => x.Trener_Id == CurrentTrener.Id);
                foreach (var x in currentRev)
                {
                    CurrentComments.Add(x);
                }
            }
        }
        public ICommand CreateCom
        {
            get
            {
                return new DelegateCommand(() => { Create(); });
            }
        }
        void Create()
        {
            using (var db = new DB.DataBaseContext())
            {
                var user = db.Users.Where(x => x.Id == CurrentUser.CurrentUserID).FirstOrDefault();
                if (Textt == null || Textt == "") { return; }
                Comment com = new Comment()
                {
                    Trener_Id = CurrentTrener.Id,
                    PublicDate = DateTime.Now,
                    Text = Textt,
                    User_Id = CurrentUser.CurrentUserID,
                    UserFullName = user.Firstname + " " + user.Lastname
                };
                db.Comments.Add(com);
                db.SaveChanges();
                Textt = "";
                CurrentComments.Add(com);
            }

        }
    }
}
