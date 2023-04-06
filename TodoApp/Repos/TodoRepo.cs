using System.Collections.Generic;
using System.Data.SqlClient;
using TodoApp.Models;

namespace TodoApp.Repos
{
    public class TodoRepo
    {
        const string CONNECTIONSTRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\rgarn\\source\\repos\\CIS-1280-Spring-2023\\TodoApp\\TodoApp\\TodoDB.mdf;Integrated Security=True";

        public List<Todo> GetAll()
        {
            List<Todo> Todos = new List<Todo>();
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Todo;",connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Todo todo = new Todo();
                        todo.Id = reader.GetInt32(0);
                        todo.Description = reader.GetString(1);
                        todo.IsComplete = reader.GetBoolean(2);
                        Todos.Add(todo);
                    }
                }
            }
            return Todos;       
        }
    }
}
