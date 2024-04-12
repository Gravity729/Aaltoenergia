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
        [StringLength(50)]
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
        [StringLength(50)]
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
        [StringLength(50)]
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

        private DateTime bDate; // дата рождения тренера
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BDate
        {
            get { return bDate; }
            set
            {
                bDate = value;
                OnPropertyChanged(nameof(BDate));
            }
        }

        private int passportNumber; //номер паспорта тренера
        [Range(10000, 99999)] // Ограничение от 10000 до 99999
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
        [Range(1000, 9999)] // Ограничение от 1000 до 9999
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
        [StringLength(150)]
        public string Achievements
        {
            get { return achievements; }
            set
            {
                achievements = value;
                OnPropertyChanged(nameof(Achievements));
            }
        }
        private string phone; //номер телефона тренера
        [Column(TypeName = "char(11)")] // указываем, что это должно быть строка длиной 11 символов
        [RegularExpression(@"^[1-9][0-9]{10}$")]
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        private string password; //пароль тренера
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

        public Trainer() { }
        public Trainer(int trainerID, string lName, string fName,string pName,
       int loginID, DateTime bDate, int passportNumber,int passportSeries,int experience, string achievements,
       string phone, string password, string login)
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
