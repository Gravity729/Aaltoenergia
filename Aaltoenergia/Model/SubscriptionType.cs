using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Aaltoenergia.Model
{
    public class SubscriptionType : INotifyPropertyChanged
    {
        [Key]
        public int SubscriptionTypeID { get; set; }//id вида абонемента 

        private string name; // название абонемента
        [StringLength(50)]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public List<Subscription> Subscription { get; set; } = new();

        public SubscriptionType() { }
        public SubscriptionType(string name)
        {
           this.Name = name;
        }


        public SubscriptionType ShallowCopy()
        {
            return (SubscriptionType)this.MemberwiseClone();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
