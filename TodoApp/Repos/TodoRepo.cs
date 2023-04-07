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

        public void Add(Todo todo)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Todo (Description, IsComplete)
                    VALUES (@Description,@IsComplete);
                ", connection);
                cmd.Parameters.AddWithValue("Description", todo.Description);
                cmd.Parameters.AddWithValue("IsComplete", todo.IsComplete);
                connection.Open();
                cmd.ExecuteNonQuery();               
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand cmd = new SqlCommand(@"DELETE FROM Todo WHERE Id = @id;", connection);
                cmd.Parameters.AddWithValue("Id", id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
