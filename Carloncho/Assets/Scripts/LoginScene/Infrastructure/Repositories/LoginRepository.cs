using Mono.Data.Sqlite;
using Mono.Data;
using System.Data;
using UnityEngine;

public class LoginRepository : IRepository
{
    private readonly string dbName = "Carloncho";

    public bool Exist(UserLogin user)
    {
        var result = false;

        var connString = SetDataBaseClass.SetDataBase(dbName + ".db");
        IDbConnection dbConn;
        IDbCommand dbCommand;
        IDataReader dataReader;

        dbConn = new SqliteConnection(connString);
        dbConn.Open();
        dbCommand = dbConn.CreateCommand();
        var query = "select email from user where email = \"" + user.name + "\" and password = \"" + user.password + "\" ";
        Debug.Log(query);
        dbCommand.CommandText = query;
        dataReader = dbCommand.ExecuteReader();
        while (dataReader.Read())
        {
            Debug.Log(dataReader.GetString(0));
            result = true;
        }

        dataReader.Close();
        dataReader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConn.Close();
        dbConn = null;

        return result;
    }
}