
namespace Helpers
{
    public class FileInput : InputInterface
    {
        public string[] GetNames(string file_name)
        {
           if (System.IO.File.Exists(file_name))
           {
                string[] names = System.IO.File.ReadAllLines(file_name);
                return names;
           }
           return null;
        }
    }
}