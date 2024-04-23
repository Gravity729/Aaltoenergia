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
    public class Subscription : INotifyPropertyChanged
    {
        [Key]
        public int SubscriptionID { get; set; }//id абонемента

        private decimal cost; // цена абонемента
        public decimal Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                OnPropertyChanged(nameof(Cost));
            }
        }

        private string duration; // продолжительность абонемента
        [StringLength(50)]
        public string Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }
        private int subscriptionTypeID; // внешний ключ на таблицу SubscriptionType
        public int SubscriptionTypeID
        {
            get { return subscriptionTypeID; }
            set
            {
                subscriptionTypeID = value;
                OnPropertyChanged(nameof(SubscriptionTypeID));
            }
        }
        [ForeignKey("SubscriptionTypeID")]
        public SubscriptionType SubscriptionType { get; set; }

        public List<PersonalSubscription> PersonalSubscription { get; set; } = new();

        public Subscription() { }
        public Subscription(decimal cost, string duration, int subscriptionTypeID)
        {
            this.Cost = cost;
            this.Duration = duration;
            this.SubscriptionTypeID = subscriptionTypeID;            
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
