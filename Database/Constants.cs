using System.IO;
using System.Reflection;

namespace Database
{
    public class Constants
    {
        // Public
        public static string DataPath => Path.Combine(FileSystem.Current.AppDataDirectory, DatabaseFileName);

        // Private
        private const string DatabaseFileName = "TaskAppDatabase.db3";

    }
}
