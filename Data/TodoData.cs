using System;
using System.Collections.Generic; // ~ import
using TodoWeb.Models;
using System.Linq;

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
    }

    public List<Todo> Read() // cRud
    {
      return todos;
    }

    public void Create(Todo todo) // Crud
    {
      todos.Add(todo);
    }

    public Todo Read(Guid id)
    {
      return todos.Single(t => t.Id == id);
    }

    public void Delete(Guid id) // cruD
    {
      // int index = todos.FindIndex(t => t.Id == id);
      // todos.RemoveAt(index);

      todos.Remove(Read(id));      
    }

    public void Update(Todo todo) // crUd
    {
      Todo _todo = Read(todo.Id); // reference (ponteiro).

      _todo.Title = todo.Title;
      _todo.Done = todo.Done;
    }
  }
}