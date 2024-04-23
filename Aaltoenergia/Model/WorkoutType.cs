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
    public class WorkoutType : INotifyPropertyChanged
    {
        [Key]
        public int WorkoutTypeID { get; set; }//id вида тренировки

        private string name; // название вида тренировки
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
        
        public List<Workout> Workout { get; set; } = new();

        public WorkoutType() { }
        public WorkoutType(string name)
        {
            this.Name = name;
        }

        public WorkoutType ShallowCopy()
        {
            return (WorkoutType)this.MemberwiseClone();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
