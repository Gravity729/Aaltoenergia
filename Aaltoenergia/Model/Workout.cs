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
    class Workout : INotifyPropertyChanged
    {
        [Key]
        public int WorkoutID { get; set; }//id тренировки

        private string startTime;// время тренировки
        public string StartTime
        {
            get { return startTime; }
            set
            {
                startTime = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }

        private string endTime;// время тренировки
        public string EndTime
        {
            get { return endTime; }
            set
            {
                endTime = value;
                OnPropertyChanged(nameof(EndTime));
            }
        }

        private string dayOfTheWeek; // день недели
        public string DayOfTheWeek
        {
            get { return dayOfTheWeek; }
            set
            {
                dayOfTheWeek = value;
                OnPropertyChanged(nameof(DayOfTheWeek));
            }
        }

        private uint locationOfTheEvent;// номер зала тренировки
        public uint LocationOfTheEvent
        {
            get { return locationOfTheEvent; }
            set
            {
                locationOfTheEvent = value;
                OnPropertyChanged(nameof(LocationOfTheEvent));
            }
        }

        private int workoutTypeID;// внешний ключ на таблицу WorkoutType
        public int WorkoutTypeID
        {
            get { return workoutTypeID; }
            set
            {
                workoutTypeID = value;
                OnPropertyChanged(nameof(WorkoutTypeID));
            }
        }
        [ForeignKey("WorkoutTypeID")]
        public WorkoutType WorkoutType { get; set; }

        private int trainerID;// внешний ключ на таблицу Trainer
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
        
        public List<Client> Client { get; set; } = new();

        
        public Workout() { }
        public Workout(int workoutID, string startTime, string endTime, string dayOfTheWeek,
            uint locationOfTheEvent, int workoutTypeID, int trainerID)
        {
            this.WorkoutID = workoutID;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.DayOfTheWeek = dayOfTheWeek;
            this.LocationOfTheEvent = locationOfTheEvent;
            this.WorkoutTypeID = workoutTypeID;
            this.TrainerID = trainerID;
        }

        
        public Workout ShallowCopy()
        {
            return (Workout)this.MemberwiseClone();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
