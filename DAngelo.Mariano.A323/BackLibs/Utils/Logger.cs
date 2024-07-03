using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackLibs.Utils
{
    public static class Logger
    {
        public static void Log(string mensaje) {
            try {
                string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log.txt");
                string logMessage = $"{DateTime.Now}: {mensaje}{Environment.NewLine}";
                File.AppendAllText(logPath, logMessage);
            }catch (Exception ex) {
                Debug.WriteLine($"No se pudo escribir en el archivo de log: {ex.Message}");
            }
        }
    }
}
