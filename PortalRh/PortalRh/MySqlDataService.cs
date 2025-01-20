//using MySql.Data.MySqlClient;
//using PortalRh.Models;
//using System.Data;

//namespace PortalRh
//{
//    public class MySqlDataService
//{
//    private readonly MySqlConnection _connection;

//    public MySqlDataService(MySqlConnection connection)
//    {
//        _connection = connection;
//    }

//    public async Task<List<reg_nominas>> GetDataAsync()
//    {
//        var dataList = new List<reg_nominas>();
//        await _connection.OpenAsync();

//        var command = new MySqlCommand("", _connection);
//        var reader = await command.ExecuteReaderAsync();

//        while (await reader.ReadAsync())
//        {
//            var data = new reg_nominas
//            {
//                //info = reader.GetString(reader.GetOrdinal("info"))

//            };
//            dataList.Add(data);
//        }

//        await _connection.CloseAsync();
//        return dataList;
//    }
//}


//}
