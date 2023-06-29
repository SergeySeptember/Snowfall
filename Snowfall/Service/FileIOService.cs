using Newtonsoft.Json;
using System.ComponentModel;

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

    }
}
