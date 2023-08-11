using Snowfall.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowfall.Service.ActionWithNotes
{
    public class IONotes
    {
        private GoogleHelper _googleHelper;
        private BindingList<NoteBody> listOfNotesGDrive = new();
        private BindingList<NoteBody> listOfNotesJSON = new();
        public IONotes(GoogleHelper googleHelper)
        {
            _googleHelper = googleHelper;
        }

        public void GetNotesFromGdrive()
        {
            int count = _googleHelper.GetCountOfNotes();
            listOfNotesGDrive = _googleHelper.GetNotes(cellName: $"A{1}", cellName2: $"B{count}");

        }
        public BindingList<NoteBody> GetNotesFromJsons()
        {
            listOfNotesJSON = FileIOService.LoadNotesFromJson();
            return listOfNotesJSON;
        }
        // todo сделать сортировку версий
        public BindingList<NoteBody> LoadAndSortNotes()
        {
            GetNotesFromGdrive();
            GetNotesFromJsons();
            FileIOService.SaveNotesToJson(listOfNotesGDrive);
            return listOfNotesGDrive;
        }
    }
}
