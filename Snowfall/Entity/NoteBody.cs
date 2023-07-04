using System.ComponentModel;

namespace Snowfall.Entity
{
    public class NoteBody
    {
        private string _noteName;
        private string _description;

        [DisplayName("Список заметок")]
        public string NoteName
        {
            get => _noteName;
            set
            {
                _noteName = value;
            }
        }
        [Browsable(false)]
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
            }
        }
    }
}
