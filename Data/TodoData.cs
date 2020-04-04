using System.Collections.Generic; // ~ import
using TodoWeb.Models;

// Dapper (StackOverflow)

namespace TodoWeb.Data
{
  public class TodoData
  {
    // atributo:
    private static List<Todo> todos = new List<Todo>();

    // construtor:
    public TodoData()
    {
      Todo todo1 = new Todo {
        // definir os valores das propriedades:
        Id = 1,
        Title = "Lavar o carro"
      };

      Todo todo2 = new Todo { Id = 2, Title = "Estudar .NET" };

      if(todos.Count == 0)
      {
        todos.Add(todo1);
        todos.Add(todo2);
      }
    }

    public List<Todo> Read() // cRud
    {
      return todos;
    }

    public void Create(Todo todo) // Crud
    {
      todos.Add(todo);
    }

    public void Delete(int id) // cruD
    {
      // TODO... (LinQ)
    }

    public void Update(Todo todo) // crUd
    {
      // TODO.. 
    }
  }
}