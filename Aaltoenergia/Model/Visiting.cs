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
    class Visiting : INotifyPropertyChanged
    {
        [Key]
        public int VisitingID { get; set; }//id посещения

        private DateTime date; // дата посещения
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
        private DateTime startTime;// время начала посещения
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime
        {
            get { return startTime; }
            set
            {
                startTime = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }
        private DateTime endTime;// время конца посещения
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime
        {
            get { return endTime; }
            set
            {
                endTime = value;
                OnPropertyChanged(nameof(EndTime));
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

        public Visiting() { }
        public Visiting(int visitingID, DateTime date, DateTime startTime, DateTime endTime, int clientID)
        {
            this.VisitingID = visitingID;
            this.Date = date;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.ClientID = clientID;
        }


        public Visiting ShallowCopy()
        {
            return (Visiting)this.MemberwiseClone();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
