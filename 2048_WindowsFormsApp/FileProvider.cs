using System.IO;
using System.Text;

namespace _2048_WindowsFormsApp
{
    public class FileProvider
    {
        public static void Replace(string fileName, string value)
        {
            var writer = new StreamWriter(fileName, false, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
        }
        public static bool Exist(string path)
        { 
            return File.Exists(path);
        }
        public static string GetValue(string fileName)
        {
            var reader = new StreamReader(fileName, Encoding.UTF8);
            var value = reader.ReadToEnd(); // считать все до конца
            reader.Close();
            return value;
        }

    }
}
