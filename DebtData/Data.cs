using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using PetaPoco.NetCore;

namespace DebtData
{
    public class Data
    {
        public Database connection { get; set; }
        private ConnectionStringSettings ConnectionSettings { get; set; }


        public Data()
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if(settings!=null)
            {
                ConnectionSettings = settings[0];
                MySqlConnection test = new MySqlConnection(ConnectionSettings.ConnectionString);
                connection = new Database(test);
            }
        }


        public void Insert(Debt debt)
        {
            connection.Save("Debt", "ID", debt);
        }
    }
}
