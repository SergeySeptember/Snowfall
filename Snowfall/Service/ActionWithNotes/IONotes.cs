using Snowfall.Entity;
using System;
using System.ComponentModel;

namespace Snowfall.Service.ActionWithNotes
{
    public class IONotes
    {
        private GoogleHelper _googleHelper;
        private BindingList<NoteBody> _listOfNotesGDrive = new();
        private BindingList<NoteBody> _listOfNotesJSON = new();
        private BindingList<NoteBody> _listOfNotes = new();

        public IONotes(GoogleHelper googleHelper)
        {
            _googleHelper = googleHelper;
        }

        public void GetNotesFromGdrive(int count) => _listOfNotesGDrive = _googleHelper.GetNotes(cellName: $"A{1}", cellName2: $"D{count}");
        
        public BindingList<NoteBody> GetNotesFromJsons()
        {
            _listOfNotesJSON = FileIOService.LoadNotesFromJson();
            return _listOfNotesJSON;
        }
        // todo сделать сортировку версий
        public BindingList<NoteBody> LoadAndSortNotes()
        {
            int count = _googleHelper.GetCountOfNotes();
            if (count > 0)
            {
                GetNotesFromGdrive(count);
            }

            GetNotesFromJsons();

            int countOfRawJson = _listOfNotesJSON.Count;
            int countOfRawGDrive = _listOfNotesGDrive.Count;
            int minCount = Math.Min(countOfRawJson, countOfRawGDrive);

            BindingList<NoteBody> listOfNotes = new();

            for (int i = 0; i < minCount; i++)
            {
                var time1 = DateTime.Parse(_listOfNotesJSON[i].TimeUpdate);
                var time2 = DateTime.Parse(_listOfNotesGDrive[i].TimeUpdate);

                if (time1 > time2)
                {
                    listOfNotes.Add(_listOfNotesJSON[i]);
                }
                else
                {
                    listOfNotes.Add(_listOfNotesGDrive[i]);
                }
            }

            for (int i = minCount; i < countOfRawJson; i++)
            {
                listOfNotes.Add(_listOfNotesJSON[i]);
            }

            for (int i = minCount; i < countOfRawGDrive; i++)
            {
                listOfNotes.Add(_listOfNotesGDrive[i]);
            }

            FileIOService.SaveNotesToJson(listOfNotes);
            _listOfNotes = FilterTasks(listOfNotes);

            if (_listOfNotes.Count == 0)
            {
                _listOfNotes.Add(new NoteBody {NoteName = "Введите название", Description = "Введите текст" });
                FileIOService.SaveNotesToJson(_listOfNotesGDrive);
            }

            return _listOfNotes;
        }

        public BindingList<NoteBody> FilterTasks(BindingList<NoteBody> listOfNotes)
        {
            var filteredNotes = listOfNotes.Where(b => b.IsDeleted == false).ToList();
            listOfNotes = new BindingList<NoteBody>(filteredNotes);
            return listOfNotes;
        }

        public void DeleteNote(int index, string description, bool successConnect, BindingList<NoteBody> listOfNotes)
        {
            if (listOfNotes.Count > index && !string.IsNullOrWhiteSpace(listOfNotes[index].NoteName))
            {
                listOfNotes[index].Description = description;
                listOfNotes[index].IsDeleted = true;

                if (successConnect == true)
                {
                    int lineNumber = index + 1;
                    _googleHelper.SetNotes(cellName1: $"A{lineNumber}", cellName2: $"E{lineNumber}", listOfNotes[index].NoteName, listOfNotes[index].Description, listOfNotes[index].IsDeleted.ToString(), listOfNotes[index].TimeUpdate);
                }

                FileIOService.SaveNotesToJson(listOfNotes);
            }
        }

        public void SaveNoteChanges(int index, string description, bool successConnect, BindingList<NoteBody> listOfNotes)
        {
            if (listOfNotes.Count > index && !string.IsNullOrWhiteSpace(listOfNotes[index].NoteName))
            {
                listOfNotes[index].Description = description;

                if (successConnect == true)
                {
                    int lineNumber = index + 1;

                    _googleHelper.SetNotes(cellName1: $"A{lineNumber}", cellName2: $"E{lineNumber}", listOfNotes[index].NoteName, listOfNotes[index].Description, listOfNotes[index].IsDeleted.ToString(), listOfNotes[index].TimeUpdate);
                }

                FileIOService.SaveNotesToJson(listOfNotes);
            }
        }
    }
}
