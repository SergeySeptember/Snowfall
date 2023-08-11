using Newtonsoft.Json;
using Snowfall.Entity;
using System.ComponentModel;

namespace Snowfall.Service
{
    public static class FileIOService
    {
        private static string pathOfTasks = $"{Environment.CurrentDirectory}\\ListOfTasks.json";
        private static string pathOfNotes = $"{Environment.CurrentDirectory}\\ListOfNotes.json";

        public static BindingList<TaskBody> LoadTasksFromJson()
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

        public static void SaveTaskToJson(object listOfCases)
        {
            using (StreamWriter writer = File.CreateText(pathOfTasks))
            {
                string output = JsonConvert.SerializeObject(listOfCases);
                writer.Write(output);
            }
        }

        public static BindingList<NoteBody> LoadNotesFromJson()
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

        public static void SaveNotesToJson(object listOfNotes)
        {
            using (StreamWriter writer = File.CreateText(pathOfNotes))
            {
                string output = JsonConvert.SerializeObject(listOfNotes);
                writer.Write(output);
            }
        }

    }
}
