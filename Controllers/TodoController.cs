using Microsoft.AspNetCore.Mvc;
using TodoWeb.Data;
using TodoWeb.Models;
using System.Collections.Generic;
using System;

// F#

namespace TodoWeb.Controllers
{
  public class TodoController : Controller
  {
    // [HttpGet]
    public IActionResult Index()
    {
      using(TodoData data = new TodoData())
        return View(data.Read());
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

      model.Id = Guid.NewGuid();

      using(TodoData data = new TodoData())
        data.Create(model);

      return RedirectToAction("Index");
    }

    public IActionResult Delete(string id) {

      using(TodoData data = new TodoData())
        data.Delete(new Guid(id));

      return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(string id)  
    {
      using(TodoData data = new TodoData())
        return View(data.Read(new Guid(id)));
    }

    [HttpPost]
    public IActionResult Update(string id, Todo model) 
    {
        if(!ModelState.IsValid)
          return View(model);

        model.Id = new Guid(id);

        using(TodoData data = new TodoData())
          data.Update(model);

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