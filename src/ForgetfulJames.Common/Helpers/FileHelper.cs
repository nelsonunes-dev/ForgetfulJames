using System.Reflection;

namespace ForgetfulJames.Common.Helpers
{
    public static class FileHelper
    {
        public static string GetFileAsString(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resource = GetFile(fileName);

            using var stream = assembly.GetManifestResourceStream(resource);
            using var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();

            return json;
        }

        public static string GetFile(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resource = assembly.GetManifestResourceNames().Single(str => str.EndsWith(fileName));
            return resource;
        }
    }
}
