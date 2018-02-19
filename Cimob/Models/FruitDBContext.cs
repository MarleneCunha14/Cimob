using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace asp_net_core_mvc_mysql_template.Models
{
    public class FruitDBContext
    {
        public string ConnectionString { get; set; }
        public FruitDBContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
    
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    
        public List<Fruit> GetTopFruits()
        {
            List<Fruit> list = new List<Fruit>();
        
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM fruits ORDER BY value DESC LIMIT 5", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Fruit(){
                            id = reader.GetInt32("id"),
                            name = reader.GetString("name"),
                            value = reader.GetInt32("value")
                        });
                    }
                }
            }
            return list;
        }
    }
}