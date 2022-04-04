using System;
using System.IO;
using System.Reflection;

namespace TEST_SOFTWARE.INFRASTRUCTURE.Data
{
    public static class ConnectionProps
    {
        private static readonly string pathDirectory = Environment.CurrentDirectory;
        private static readonly string pathParent = Directory.GetParent(pathDirectory).FullName;
        private static readonly string pathDB = Path.Combine(pathParent, @"TEST_SOFTWARE.INFRASTRUCTURE\Data\BD_Local.mdf");
        public static string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + pathDB + ";Integrated Security=True";
    }
}
