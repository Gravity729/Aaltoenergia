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
    class PersonalSubscription : INotifyPropertyChanged
    {
        [Key]
        public int PersonalSubscriptionID { get; set; }//id персонального абонемента

        private int subscriptionID; // внешний ключ на таблицу SubscriptionType
        public int SubscriptionID
        {
            get { return subscriptionID; }
            set
            {
                subscriptionID = value;
                OnPropertyChanged(nameof(SubscriptionID));
            }
        }
        [ForeignKey("SubscriptionID")]
        public Subscription Subscription { get; set; }

        private int paymentID; // внешний ключ на таблицу Payment
        public int PaymentID
        {
            get { return paymentID; }
            set
            {
                paymentID = value;
                OnPropertyChanged(nameof(PaymentID));
            }
        }
        [ForeignKey("PaymentID")]
        public Payment Payment { get; set; }

        private int clientID; // внешний ключ на таблицу Client
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


        public PersonalSubscription() { }
        public PersonalSubscription(int personalSubscriptionID,  int subscriptionID, int paymentID, int clientID)
        {
            this.PersonalSubscriptionID = personalSubscriptionID;
            this.SubscriptionID = subscriptionID;
            this.PaymentID = paymentID;
            this.ClientID = clientID;
        }

        public Subscription ShallowCopy()
        {
            return (Subscription)this.MemberwiseClone();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
