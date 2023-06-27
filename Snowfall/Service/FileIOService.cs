using Newtonsoft.Json;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace Snowfall.Service
{
    public class FileIOService
    {
        public static BindingList<TaskBody> LoadData(string pathOfTasks)
        {
            var fileExists = File.Exists(pathOfTasks);
            if (!fileExists)
            {
                File.CreateText(pathOfTasks).Dispose();
                return new BindingList<TaskBody>
                {

                };
            }
            using (var reader = File.OpenText(pathOfTasks))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TaskBody>>(fileText);
            }
        }

        public static void SaveData(object listOfCases, string pathOfTasks)
        {
            using (StreamWriter writer = File.CreateText(pathOfTasks))
            {
                string output = JsonConvert.SerializeObject(listOfCases);
                writer.Write(output);
            }

        }

        public static bool LoadSettings(string pathOfSettings)
        {
         var fileExists = File.Exists(pathOfSettings);
            if (!fileExists)
            {    
                using (StreamWriter writer = new StreamWriter(pathOfSettings, false))
                {
                    writer.WriteLine("first run = true");
                    writer.WriteLine("past internet connect = false");
                }
                return false;
            }
            using (var reader = File.OpenText(pathOfSettings))
            {
                var fileText = reader.ReadToEnd();
                return false;
            }
        }

        public static void SaveSettings(string pathOfSettings)
        {


        }
    }
}
