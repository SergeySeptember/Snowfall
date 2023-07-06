using Newtonsoft.Json;
using Snowfall.Entity;
using System.ComponentModel;

namespace Snowfall.Service
{
    public class FileIOService
    {
        public static BindingList<TaskBody> LoadTasksFromJson(string pathOfTasks)
        {
            var fileExists = File.Exists(pathOfTasks);
            if (!fileExists)
            {
                File.CreateText(pathOfTasks).Dispose();
                return new BindingList<TaskBody> { };
            }
            using (var reader = File.OpenText(pathOfTasks))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TaskBody>>(fileText);
            }
        }

        public static void SaveTaskToJson(object listOfCases, string pathOfTasks)
        {
            using (StreamWriter writer = File.CreateText(pathOfTasks))
            {
                string output = JsonConvert.SerializeObject(listOfCases);
                writer.Write(output);
            }
        }

        public static BindingList<NoteBody> LoadNotesFromJson(string pathOfNotes)
        {
            var fileExists = File.Exists(pathOfNotes);
            if (!fileExists)
            {
                File.CreateText(pathOfNotes).Dispose();
                return new BindingList<NoteBody> { };
            }
            using (var reader = File.OpenText(pathOfNotes))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<NoteBody>>(fileText);
            }
        }

        public static void SaveNotesToJson(object listOfNotes, string pathOfNotes)
        {
            using (StreamWriter writer = File.CreateText(pathOfNotes))
            {
                string output = JsonConvert.SerializeObject(listOfNotes);
                writer.Write(output);
            }
        }

    }
}
