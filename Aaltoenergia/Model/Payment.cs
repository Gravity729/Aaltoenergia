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
    public class Payment : INotifyPropertyChanged
    {
        [Key]
        public int PaymentID { get; set; }//id оплаты

        private DateTime date;// дата оплаты
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        private decimal sum;// сумма оплаты
        public decimal Sum
        {
            get { return sum; }
            set
            {
                sum = value;
                OnPropertyChanged(nameof(Sum));
            }
        }
        private string typeOfPayment;// тип оплаты
        [StringLength(50)]
        public string TypeOfPayment
        {
            get { return typeOfPayment; }
            set
            {
                typeOfPayment = value;
                OnPropertyChanged(nameof(TypeOfPayment));
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

        public Payment() { }
        public Payment(DateTime date, decimal sum, string typeOfPayment, 
            int personalSubscriptionID)
        {
            this.Date = date;
            this.Sum = sum;
            this.TypeOfPayment = typeOfPayment;
            this.PersonalSubscriptionID = personalSubscriptionID;
        }

        public Payment ShallowCopy()
        {
            return (Payment)this.MemberwiseClone();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
