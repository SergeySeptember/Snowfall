using Newtonsoft.Json;
using System.ComponentModel;

namespace Snowfall
{
    public class FileIOService
    {

        public static BindingList<TaskBody> LoadData(string path)
        {
            var fileExists = File.Exists(path);
            if (!fileExists)
            {
                File.CreateText(path).Dispose();
                return new BindingList<TaskBody>
                {
                    
                };
            }
            using (var reader = File.OpenText(path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TaskBody>>(fileText);
            }
        }

        public static void SaveData(object listOfCases, string path)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                string output = JsonConvert.SerializeObject(listOfCases);
                writer.Write(output);
            }

        }
    }
}
