using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tsi.Template.Core.Helpers
{
    public class JsonHelper<T>
    {

        public static T Deserialize(string filePath)
        {
            using (FileStream fsSource = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                return Deserialize(fsSource);
        }

        public static T Deserialize(Stream jsonFile)
        {
            T result;
            try
            {
                var serializer = new JsonSerializer();
                using (var sr = new StreamReader(jsonFile))
                {
                    string text = sr.ReadToEnd();
                    var errors = new List<string>();
                    var data = JsonConvert.DeserializeObject<T>(text,
                       new JsonSerializerSettings
                       {
                           PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                           Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs earg)
                           {
                               errors.Add(earg.ErrorContext.Member.ToString() + " - " + earg.ErrorContext.OriginalObject);
                               earg.ErrorContext.Handled = true;
                           }
                       });
                    result = (T)data;
                }
            }
            catch
            {
                result = default(T);
            }
            return result;
        }

        public static void Serialize(T inputObject, string outputPath)
        {
            string tmp = JsonConvert.SerializeObject(inputObject, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }
            using (StreamWriter sw = new StreamWriter(outputPath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.WriteRaw(tmp);
            }
        }

    }
}
