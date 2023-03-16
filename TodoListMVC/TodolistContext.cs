using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TodoListMVC.Models;

namespace TodoListMVC;

public partial class TodolistContext : DbContext
{
    public TodolistContext()
    {
    }

    public TodolistContext(DbContextOptions<TodolistContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TodoItem> TodoItems { get; set; }

    public virtual DbSet<TodoList> TodoLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.IdTodoItem).HasName("PK__TodoItem__C5AB035FD2DCAF03");

            entity.ToTable("TodoItem");

            entity.HasQueryFilter(i => i.IdTodoListNavigation.UserName == UsernameState.Username);

            entity.HasOne(d => d.IdTodoListNavigation).WithMany(p => p.TodoItems)
                .HasForeignKey(d => d.IdTodoList)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdTodoList");
        });

        modelBuilder.Entity<TodoList>(entity =>
        {
            entity.HasKey(e => e.IdTodoList).HasName("PK__TodoList__AC732DF36B42C48E");

            entity.ToTable("TodoList");

            entity.HasQueryFilter(i => i.UserName ==UsernameState.Username);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
