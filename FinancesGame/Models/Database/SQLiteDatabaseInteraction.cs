using Extensions;
using Extensions.DatabaseHelp;
using Extensions.DataTypeHelpers;
using FinancesGame;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace FinancesGameLib.Models.Database
{
    /// <summary>Represents database interaction covered by SQLite.</summary>
    public class SQLiteDatabaseInteraction
    {
        private const string _DATABASENAME = "FinancesGame.sqlite";
        private readonly string _con = $"Data Source = {Path.Combine(AppData.Location, _DATABASENAME)}; foreign keys = TRUE; Version = 3;";

        /// <summary>Verifies that the requested database exists and that its file size is greater than zero. If not, it extracts the embedded database file to the local output folder.</summary>
        public void VerifyDatabaseIntegrity() => Functions.VerifyFileIntegrity(
            Assembly.GetExecutingAssembly().GetManifestResourceStream($"FinancesGame.{_DATABASENAME}"), _DATABASENAME, AppData.Location);

        /// <summary>Retrieves a list of names from the database.</summary>
        /// <param name="tableName">Name of the table from which to retrieve the names</param>
        /// <returns>List of names from the database</returns>
        public async Task<List<string>> GetAllNames(string tableName)
        {
            List<string> names = new List<string>();
            DataSet ds = await SQLiteHelper.FillDataSet(_con, $"SELECT * FROM {tableName}");

            if (ds.Tables[0].Rows.Count > 0)
                foreach (DataRow dr in ds.Tables[0].Rows)
                    names.Add(dr["Name"].ToString());
            return names;
        }
    }
}