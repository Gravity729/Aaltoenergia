using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aaltoenergia.Model
{
    public class ClientWorkout : INotifyPropertyChanged
    {
        [Key]
        public int ClientWorkoutID { get; set; }//id тренировки

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

        private int workoutID;// внешний ключ на таблицу Client
        public int WorkoutID
        {
            get { return workoutID; }
            set
            {
                workoutID = value;
                OnPropertyChanged(nameof(WorkoutID));
            }
        }
        [ForeignKey("WorkoutID")]
        public Workout Workout { get; set; }


        public ClientWorkout() { }
        public ClientWorkout(int clientID, int workoutID)
        {
            this.ClientID=clientID; 
            this.WorkoutID=workoutID;
        }

        public ClientWorkout ShallowCopy()
        {
            return (ClientWorkout)this.MemberwiseClone();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
