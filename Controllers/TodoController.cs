using Microsoft.AspNetCore.Mvc;
using TodoWeb.Data;
using TodoWeb.Models;
using System.Collections.Generic;

namespace TodoWeb.Controllers
{
  public class TodoController : Controller
  {
    // [HttpGet]
    public IActionResult Index()
    {
      TodoData data = new TodoData();
      var lista = data.Read();

      return View(lista); // /Views/Todo/Index.cshtml (CS + HTML = RAZOR)

      // View(object) // estou passando um modelo de dados para a View.
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View(new Todo());
    }

    [HttpPost] // atributo // annotations
    public IActionResult Create(Todo model) // Model Binding (MVC - HTML, API - JSON)
    {
      // VALIDAÇÃO
      if(!ModelState.IsValid)
        return View(model);


      // model.Id = <input name="Id"
      // model.Title = <input name="Title"
      TodoData data = new TodoData();
      data.Create(model);

      return RedirectToAction("Index");
    }
  }
}

// TODO: 
// 1. Criar um Layout
// 2. Manipular as diretivas em um único arquivo
// 3. Adicionar TagHelpers

// localhost:5000/todo/index
// localhost:5000/todo/create
// localhost:5000/todo/update
// localhost:5000/todo/delete/1

// localhost:5000/{controller}/{action}

// localhost:5000/{class}/{method}