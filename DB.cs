using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sale_of_motor_vehicles {
	// подключение к базе данных
	class DB {
		MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=awtor");
	public void openConnection()
		{
			if (connection.State == System.Data.ConnectionState.Closed) connection.Open();
		}
        public void closeConnection() //Функция открывает соединение
        {
            if (connection.State == System.Data.ConnectionState.Open) connection.Close(); //Функция закрывает соединение
        }

		public MySqlConnection GetConnection() //Функция возвращает соединение 
		{
			return connection;
		}

    }

}
