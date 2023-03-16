using System;
using System.Collections.Generic;

namespace TodoListMVC.Models;

public partial class TodoItem
{
    public int IdTodoItem { get; set; }

    public int IdTodoList { get; set; }

    public string Libelle { get; set; } = null!;

    public bool IsDone { get; set; }

    public virtual TodoList IdTodoListNavigation { get; set; } = null!;
}
