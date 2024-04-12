using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aaltoenergia.Model
{
    class Client : INotifyPropertyChanged
    {
        [Key]
        public int ClientID { get; set; }// id клиента

        private string lName;//фамилия клиента
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
        private string fName;//фамилия клиента
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
        private string? pName;//отчество клиента
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
        private int? loginID;//внешний ключ на таблицу loginC
        public int? LoginID
        {
            get { return loginID; }
            set
            {
                loginID = value;
                OnPropertyChanged(nameof(LoginID));
            }
        }
        public LoginC LoginC { get; set; }


        private DateTime bDate; // дата рождения клиента
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

        private int passportNumber; //номер паспорта клиента
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

        private int passportSeries; //серия паспорта клиента
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
        private string phone; //номер телефона клиента
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
        private int personalSubscriptionID;//внешний ключ на таблицу PersonalSubscription
        public int PersonalSubscriptionID
        {
            get { return personalSubscriptionID; }
            set
            {
                personalSubscriptionID = value;
                OnPropertyChanged(nameof(PersonalSubscriptionID));
            }
        }
        [ForeignKey("PersonalSubscriptionID")]
        public PersonalSubscription PersonalSubscription { get; set; }

        public List<Visiting> Visiting { get; set; } = new();
        public List<Workout> Workout { get; set; } = new();

        public Client() { }
        public Client(int clientID, string lName, string fName, string pName,
       int loginID, DateTime bDate, int passportNumber, int passportSeries, string phone, string password,int personalSubscriptionID)
        {
            this.ClientID = clientID;
            this.LName = lName;
            this.FName = fName;
            this.PName = pName;
            this.LoginID = loginID;
            this.BDate = bDate;
            this.PassportNumber = passportNumber;
            this.PassportSeries = passportSeries;            
            this.Phone = phone;
            this.Password = password;            
            this.PersonalSubscriptionID = personalSubscriptionID;            
        }

        public Client ShallowCopy()
        {
            return (Client)this.MemberwiseClone();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}