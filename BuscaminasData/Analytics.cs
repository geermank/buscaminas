using System;
using System.Data;
using System.IO;

namespace BuscaminasData
{
    public class Analytics
    {
        private static Analytics instance;

        public static Analytics GetInstance()
        {
            if (instance == null)
            {
                instance = new Analytics();
            }
            return instance;
        }

        private const string ANALYTICS_FILE = @"C:\Buscaminas\analytics.xml";
        
        readonly DataSet dataSet = new DataSet("Analytics");
        readonly DataTable dataTable = new DataTable("Logs");

        private Analytics()
        {
            if (File.Exists(ANALYTICS_FILE))
            {
                dataSet.ReadXml(ANALYTICS_FILE);
                dataTable = dataSet.Tables[0];
            } else
            {
                dataTable.Columns.Add("Type");
                dataTable.Columns.Add("Date");
                dataSet.Tables.Add(dataTable);
            }
        }

        public void Log(Event value)
        {
            DataRow row = dataTable.NewRow();
            row["Type"] = value.ToString();
            row["Date"] = DateTime.Now.ToString();
            dataTable.Rows.Add(row);

            dataSet.WriteXml(ANALYTICS_FILE);
        }
    }

    public enum Event
    {
        USER_CREATED,
        LOGIN,
        LOGOUT,
        MULTIPLAYER_GAME_START,
        MULTIPLAYER_GAME_END,
        SINGLE_PLAYER_GAME_START,
        SINGLE_PLAYER_GAME_END
    }
}
