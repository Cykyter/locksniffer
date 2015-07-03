using System;
using System.Configuration;
using System.IO;

namespace LockSniffer
{
    public class L�gger
    {
        public static string GetPath()
        {
            return Environment.ExpandEnvironmentVariables(ConfigurationManager.AppSettings["Path"]);
        }

        public void L�g(L�gEntry l)
        {
            File.AppendAllText(GetPath(), l.Serialize());
        }
    }
}