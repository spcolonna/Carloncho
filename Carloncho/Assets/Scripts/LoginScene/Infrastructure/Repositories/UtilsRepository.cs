using Mono.Data.Sqlite;
using System.Data;

public static class UtilsRepository
{
    private static readonly string dbName = "Carloncho";
    public static IDbCommand dbCommand;
    public static IDataReader dataReader;
    private static IDbConnection dbConn;

    public static void OpenConnection()
    {
        var connString = SetDataBaseClass.SetDataBase(dbName + ".db");
        dbConn = new SqliteConnection(connString);
        dbConn.Open();
        dbCommand = dbConn.CreateCommand();
    }

    public static void CloseConnection()
    {
        dataReader.Close();
        dataReader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConn.Close();
        dbConn = null;
    }
}

