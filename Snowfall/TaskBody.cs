using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Snowfall
{
    public class TaskBody : INotifyPropertyChanged
    {
        private string _task;
        private bool _status;
        private string _category;
        private string _time = DateTime.Now.ToString();
        private string _timeUpdate = DateTime.Now.ToString();

        [DisplayName("Task")]
        public string Task
        {
            get => _task;
            set
            {
                _task = value;
                OnPropertyChanged();
            }
        }

        [DisplayName("Status")]
        public bool Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }
        
        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }

        public string Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        [Browsable(false)]
        public string TimeUpdate
        {
            get => _timeUpdate;
            set
            {
                _timeUpdate = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
