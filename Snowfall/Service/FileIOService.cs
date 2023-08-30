using Newtonsoft.Json;
using Snowfall.Entity;
using System.ComponentModel;

namespace Snowfall.Service
{
    public static class FileIOService
    {
        private static string _pathOfTasks = $"{Environment.CurrentDirectory}\\ListOfTasks.json";
        private static string _pathOfNotes = $"{Environment.CurrentDirectory}\\ListOfNotes.json";
        private static string _pathOfSettings = $"{Environment.CurrentDirectory}\\Settings.json";

        public static BindingList<TaskBody> LoadTasksFromJson()
        {
            var fileExists = File.Exists(_pathOfTasks);
            if (!fileExists)
            {
                File.CreateText(_pathOfTasks).Dispose();
                return new BindingList<TaskBody> { };
            }
            using (var reader = File.OpenText(_pathOfTasks))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TaskBody>>(fileText);
            }
        }

        public static void SaveTaskToJson(object listOfCases)
        {
            using (StreamWriter writer = File.CreateText(_pathOfTasks))
            {
                string output = JsonConvert.SerializeObject(listOfCases);
                writer.Write(output);
            }
        }

        public static BindingList<NoteBody> LoadNotesFromJson()
        {
            var fileExists = File.Exists(_pathOfNotes);
            if (!fileExists)
            {
                File.CreateText(_pathOfNotes).Dispose();
                return new BindingList<NoteBody> { };
            }
            using (var reader = File.OpenText(_pathOfNotes))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<NoteBody>>(fileText);
            }
        }

        public static void SaveNotesToJson(object listOfNotes)
        {
            using (StreamWriter writer = File.CreateText(_pathOfNotes))
            {
                string output = JsonConvert.SerializeObject(listOfNotes);
                writer.Write(output);
            }
        }

        public static void SaveSettingsToJson(string color, bool language)
        {
            var data = new
            {
                Color = color,
                Language = language
            };

            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);

            File.WriteAllText(_pathOfSettings, jsonData);
        }

        public static string[] ReadSettings()
        {
            string[] answer = new string[2];

            if (File.Exists(_pathOfSettings))
            {
                string jsonData = File.ReadAllText(_pathOfSettings);

                var data = JsonConvert.DeserializeAnonymousType(jsonData, new
                {
                    Color = "",
                    Language = ""
                });

                answer[0] = data.Color;
                answer[1] = data.Language;
                return answer;
            }
            else
            {
                return new string[2] { "#009688", "true"};
            }
        }

    }
}
