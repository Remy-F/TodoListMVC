using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoListMVC.Models;

public partial class TodoList
{
    public int IdTodoList { get; set; }

    public string Nom { get; set; } = null!;

    public string? Couleur { get; set; }

    public virtual ICollection<TodoItem> TodoItems { get; } = new List<TodoItem>();
}
