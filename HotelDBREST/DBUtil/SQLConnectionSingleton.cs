using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelDBREST.DBUtil
{
    public class SQLConnectionSingleton
    {
        private static SQLConnectionSingleton _instance = new SQLConnectionSingleton();

        public static SQLConnectionSingleton Instance => _instance;

        private SQLConnectionSingleton()
        {
            _dbConnection = new SqlConnection(ConnString);
            _dbConnection.Open();
        }

        private SqlConnection _dbConnection;

        /*
         * Lokal database
        */
        protected const String ConnString =
            @"Data Source=brinksserver.database.windows.net;Initial Catalog = BrinkTheMan; User ID = math039h; Password=Mb123456789;Connect Timeout = 30; Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";        /*
         * Cloud Database
         */
        //private const String ConnString =
        //    @"Data Source=pele-easj-dbserver.database.windows.net;Initial Catalog=pele-easj-db;User ID=peleadm;Password=Secret1!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public SqlConnection DbConnection => _dbConnection;
    }
}