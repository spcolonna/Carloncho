using UnityEngine;
using static UtilsRepository;


public class LoginRepository : IRepository
{
    public bool Exist(UserLogin user)
    {
        var result = false;

        OpenConnection();

        
        var query = "select email from user where email = \"" + user.name + "\" and password = \"" + user.password + "\" ";
        dbCommand.CommandText = query;
        dataReader = dbCommand.ExecuteReader();
        while (dataReader.Read())
        {
            Debug.Log(dataReader.GetString(0));
            result = true;
        }


        return result;
    }
}