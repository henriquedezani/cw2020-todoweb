using System;
using System.Collections.Generic; // ~ import
using TodoWeb.Models;
using System.Linq;
using System.Data.SqlClient; // ADO.NET

// Dapper (StackOverflow)

// DataLayer

// Repository Pattern (próximas aulas...)

namespace TodoWeb.Data
{
  public class TodoData : IDisposable
  {
    private SqlConnection connection = null;

    // construtor:
    public TodoData()
    {
      string strConn = @"Data Source=localhost; 
        Initial Catalog=BDTodo;
        User=sa;
        Password=A1b2c3d4e5!";
        
      // string strConn = @"Data Source=localhost; 
      //   Initial Catalog=BDTodo;
      //   Integrated Security=true";

      connection = new SqlConnection(strConn);
      connection.Open();
    }

    public void Dispose()
    {
      connection.Close();
    }

    public List<Todo> Read() // cRud
    {
      string sql = "SELECT * FROM Todo";

      List<Todo> lista = new List<Todo>();

      SqlCommand cmd = new SqlCommand(sql, connection);

      SqlDataReader reader = cmd.ExecuteReader();

      while(reader.Read())
      {
        Todo todo = new Todo();
        todo.Id = new Guid(reader.GetString(0));
        todo.Title = reader.GetString(1);
        todo.Done = reader.GetBoolean(2);

        lista.Add(todo);
      }

      return lista;
    }

    public Todo Read(Guid id)
    {
      string sql = "SELECT * FROM Todo WHERE Id = @id";

      Todo todo = null;

      SqlCommand cmd = new SqlCommand(sql, connection);

      cmd.Parameters.AddWithValue("@id", id.ToString());

      SqlDataReader reader = cmd.ExecuteReader();

      if(reader.Read())
      {
        todo = new Todo();
        todo.Id = new Guid((string)reader["Id"]);
        todo.Title = (string)reader["Title"];
        todo.Done = (bool)reader["Done"];
      }

      return todo;
    }

    public void Create(Todo todo) // Crud
    {
      string sql = "INSERT INTO Todo VALUES (@id, @title, @done)";

      SqlCommand cmd = new SqlCommand(sql, connection);

      cmd.Parameters.AddWithValue("@id", todo.Id);
      cmd.Parameters.AddWithValue("@title", todo.Title);
      cmd.Parameters.AddWithValue("@done", todo.Done);

      cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id) // cruD
    {
      string sql = "DELETE FROM Todo WHERE Id = @id";

      SqlCommand cmd = new SqlCommand(sql, connection);

      cmd.Parameters.AddWithValue("@id", id.ToString());

      cmd.ExecuteNonQuery();
    }

    public void Update(Todo todo) // crUd
    {
      string sql = "UPDATE Todo SET Title = @title, Done = @done WHERE Id = @id";

      SqlCommand cmd = new SqlCommand(sql, connection);

      cmd.Parameters.AddWithValue("@id", todo.Id);
      cmd.Parameters.AddWithValue("@title", todo.Title);
      cmd.Parameters.AddWithValue("@done", todo.Done);

      cmd.ExecuteNonQuery();
    }
  }
}