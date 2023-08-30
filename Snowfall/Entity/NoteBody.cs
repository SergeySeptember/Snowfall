using System.ComponentModel;

namespace Snowfall.Entity
{
    public class NoteBody
    {
        public NoteBody()
        {
            _timeUpdate = DateTime.Now.ToString();
        }

        private string _noteName;
        private string _description;
        private bool _isDeleted;
        private string _timeUpdate;

        public string NoteName
        {
            get => _noteName;
            set
            { _noteName = value; }
        }

        [Browsable(false)]
        public string Description
        {
            get => _description;
            set
            { _description = value; }
        }

        [Browsable(false)]
        public bool IsDeleted
        {
            get => _isDeleted;
            set { _isDeleted = value; }
        }

        [Browsable(false)]
        public string TimeUpdate
        {
            get => _timeUpdate;
            set { _timeUpdate = value; }
        }
    }
}
