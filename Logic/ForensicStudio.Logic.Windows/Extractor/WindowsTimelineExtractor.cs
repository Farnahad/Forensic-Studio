using ForensicStudio.Core.Main.Method;
using ForensicStudio.Logic.Windows.Model;
using Microsoft.Data.Sqlite;

namespace ForensicStudio.Logic.Windows.Extractor;

// FORENSIC
public class WindowsTimelineExtractor
{
    public MethodResult<List<WindowsTimeline>> GetWindowsTimelines()
    {
        var databaseFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                               + @"\ConnectedDevicesPlatform\L.%USERNAME%.000\ActivityCache.db";
        return GetWindowsTimelines(databaseFilePath);
    }

    public MethodResult<List<WindowsTimeline>> GetWindowsTimelines(string databaseFilePath)
    {
        var windowsTimelines = new List<WindowsTimeline>();

        try
        {
            using (SqliteConnection connection = new SqliteConnection($"Data Source={databaseFilePath};Version=3;"))
            {
                connection.Open();

                string query = "SELECT * FROM Activities";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var newWindowsTimeline = new WindowsTimeline
                        {
                            ActivityId = reader["ActivityId"],
                            Title = reader["Title"],
                            AppId = reader["AppId"],
                            LastModifiedTime = reader["LastModifiedTime"]
                        };

                        windowsTimelines.Add(newWindowsTimeline);
                    }

                }
            }
        }
        catch (Exception exception)
        {
            return new MethodResult<List<WindowsTimeline>>(exception);
        }

        return new MethodResult<List<WindowsTimeline>>(windowsTimelines);
    }
}