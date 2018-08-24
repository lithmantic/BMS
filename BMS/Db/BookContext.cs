using BMS.Controllers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMS.Db
{
    public class BookContext
    {
        public string ConnectionString { get; set; }
        public BookContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<BookDto> GetAllBook()
        { 
            List<BookDto> list = new List<BookDto>();
            //连接数据库
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();
                //查找数据库里面的表
                MySqlCommand mscommand = new MySqlCommand("select * from book", msconnection);
                using (MySqlDataReader reader = mscommand.ExecuteReader())
                {
                    //读取数据
                    while (reader.Read())
                    {
                        list.Add(new BookDto()
                        {
                            id = reader.GetString("id"),
                            name = reader.GetString("name"),
                            description = reader.GetString("description"),
                            status = reader.GetString("status")
                        });
                    } 
                }
            } 
            return list;
        } 
    }
}
