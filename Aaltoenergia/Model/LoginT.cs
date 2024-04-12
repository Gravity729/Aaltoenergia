using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aaltoenergia.Model
{
    class LoginT
    {
        [Key]
        public int LoginID { get; set; }// id входа тренера
        
        private string login; //логин тренера
        [StringLength(50)]
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string password; //пароль клиента
        [StringLength(128)]
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private int trainerID;// внешний ключ на таблицу Client
        public int TrainerID
        {
            get { return trainerID; }
            set
            {
                trainerID = value;
                OnPropertyChanged(nameof(TrainerID));
            }
        }
        [ForeignKey("TrainerID")]
        public Trainer Trainer { get; set; }


        public LoginT() { }
        public LoginT(int loginID, string login, string password, int trainerID)
        {
            this.LoginID = loginID;
            this.Login = login;
            this.Password = password;
            this.TrainerID = trainerID;
        }


        public LoginT ShallowCopy()
        {
            return (LoginT)this.MemberwiseClone();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
