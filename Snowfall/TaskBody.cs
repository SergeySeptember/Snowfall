using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Snowfall
{
    public class TaskBody
    {
        private string _task;
        private bool _status;
        private string _category;
        private string _time = DateTime.Now.ToString();
        private string _timeUpdate = DateTime.Now.ToString();

        public string Task
        {
            get => _task;
            set
            {
                _task = value;
            }
        }

        public bool Status
        {
            get => _status;
            set
            {
                _status = value;
            }
        }
        
        public string Category
        {
            get => _category;
            set
            {
                _category = value;
            }
        }

        public string Time
        {
            get => _time;
            set
            {
                _time = value;
            }
        }

        [Browsable(false)]
        public string TimeUpdate
        {
            get => _timeUpdate;
            set
            {
                _timeUpdate = value;
            }
        }
    }
}
