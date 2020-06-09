using System;
using System.IO;

namespace FinancesGame
{
    public static class AppData
    {
        internal static string Location = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PF Software", "FinancesGame");
    }
}