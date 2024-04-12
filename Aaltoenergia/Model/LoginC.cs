using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Aaltoenergia.Model
{
    class LoginC : INotifyPropertyChanged
    {
        [Key]
        public int LoginID { get; set; }// id входа клиента

        
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

        private int clientID;// внешний ключ на таблицу Client
        public int ClientID
        {
            get { return clientID; }
            set
            {
                clientID = value;
                OnPropertyChanged(nameof(ClientID));
            }
        }
        [ForeignKey("ClientID")]
        public Client Client { get; set; }

        public LoginC() { }
        public LoginC(int loginID, string phone, string password, int clientID)
        {
            this.LoginID = loginID;
            this.Phone = phone;
            this.Password = password;
            this.ClientID = clientID;
        }

        public LoginC ShallowCopy()
        {
            return (LoginC)this.MemberwiseClone();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
