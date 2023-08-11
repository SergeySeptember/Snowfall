using Snowfall.Service.ActionWithTasks;
using System.ComponentModel;

namespace Snowfall.Entity
{
    public class TaskBody
    {
        public TaskBody()
        {
            _time = _timeUpdate = DateTime.Now.ToString();
            _id = Guid.NewGuid().ToString();
        }

        private string _id;
        private string _task;
        private bool _status;
        private string _category;
        private string _time;
        private string _timeUpdate;
        private bool _isDeleted;

        [Browsable(false)]
        public string Id
        {
            get => _id;
            set { _id = value; }
        }

        public string Task
        {
            get => _task;
            set { _task = value; }
        }

        public bool Status
        {
            get => _status;
            set { _status = value; }
        }

        public string Category
        {
            get => _category;
            set { _category = value; }
        }

        public string Time
        {
            get => _time;
            set { _time = value; }
        }

        [Browsable(false)]
        public string TimeUpdate
        {
            get => _timeUpdate;
            set { _timeUpdate = value; }
        }

        [Browsable(false)]
        public bool IsDeleted
        {
            get => _isDeleted;
            set { _isDeleted = value; }
        }
    }
}
