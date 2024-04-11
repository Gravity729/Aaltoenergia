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
    class Trainer : INotifyPropertyChanged
    {
        [Key]
        public int TrainerID { get; set; }// id тренера

        private string lName;//фамилия тренера

        public string LName
        {
            get { return lName; }
            set
            {
                lName = value;
                OnPropertyChanged(nameof(LName));
            }
        }
        private string fName;//фамилия тренера

        public string FName
        {
            get { return fName; }
            set
            {
                fName = value;
                OnPropertyChanged(nameof(FName));
            }
        }
        private string? pName;//отчество тренера

        public string? PName
        {
            get { return pName; }
            set
            {
                pName = value;
                OnPropertyChanged(nameof(PName));
            }
        }
        private int loginID;//внешний ключ на таблицу loginT
        public int LoginID
        {
            get { return loginID; }
            set
            {
                loginID = value;
                OnPropertyChanged(nameof(LoginID));
            }
        }
        [ForeignKey("LoginID")]
        public LoginT LoginT { get; set; }

        private string bDate; // дата рождения тренера
        public string BDate
        {
            get { return bDate; }
            set
            {
                bDate = value;
                OnPropertyChanged(nameof(BDate));
            }
        }

        private int passportNumber; //номер паспорта тренера
        public int PassportNumber
        {
            get { return passportNumber; }
            set
            {
                passportNumber = value;
                OnPropertyChanged(nameof(PassportNumber));
            }
        }

        private int passportSeries; //серия паспорта тренера
        public int PassportSeries
        {
            get { return passportSeries; }
            set
            {
                passportSeries = value;
                OnPropertyChanged(nameof(PassportSeries));
            }
        }
        private int experience; //стаж работы
        public int Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                OnPropertyChanged(nameof(Experience));
            }
        }
        private string achievements;//достижения тренера

        public string Achievements
        {
            get { return achievements; }
            set
            {
                achievements = value;
                OnPropertyChanged(nameof(Achievements));
            }
        }
        private ulong phone; //номер телефона тренера
        [RegularExpression(@"^[1-9]\d{10}$")]
        public ulong Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        private string password; //пароль тренера
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private string login; //логин тренера
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public Trainer() { }
        public Trainer(int trainerID, string lName, string fName,string pName,
       int loginID, string bDate, int passportNumber,int passportSeries,int experience, string achievements,
       ulong phone, string password, string login)
        {
            this.TrainerID = trainerID;
            this.LName = lName;
            this.FName = fName;
            this.PName = pName;
            this.LoginID = loginID;
            this.BDate = bDate;
            this.PassportNumber = passportNumber;
            this.PassportSeries = passportSeries;
            this.Experience = experience;
            this.Achievements = achievements;
            this.Phone = phone;
            this.Password = password;
            this.Login = login;
        }

        public List<Workout> Workout { get; set; } = new();

        public Trainer ShallowCopy()
        {
            return (Trainer)this.MemberwiseClone();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
