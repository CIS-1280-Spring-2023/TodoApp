﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TodoApp.Models;
using TodoApp.Repos;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Todo> todos;
        TodoRepo todoRepo = new TodoRepo();

        public MainWindow()
        {
            InitializeComponent();
            todos = todoRepo.GetAll();
            lbTodos.ItemsSource = todos;

        }

        private void btnAddTodo_Click(object sender, RoutedEventArgs e)
        {
            //Get todo from controls on form
            Todo todo = new Todo();
            todo.Description = txbTodo.Text;
            todo.IsComplete = false;
            //Pass todo to repo
            todoRepo.Add(todo);

            RefreshTodoListBox();
        }
        private void btnDeleteTodo_Click(object sender, RoutedEventArgs e)
        {
            //Get selected item
            Todo todo = (Todo)lbTodos.SelectedItem;

            //Delete it from database
            todoRepo.Delete(todo.Id);
            RefreshTodoListBox();
        }

        private void RefreshTodoListBox()
        {
            todos = todoRepo.GetAll();
            lbTodos.ItemsSource = todos;
        }

        private void lbTodos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Find the selected item
            Todo todo = (Todo)lbTodos.SelectedItem;

            //Open a form to edit it.
            TodoEditWindow editWindow = new TodoEditWindow(todo);
            if(editWindow.ShowDialog()==true)
            {
                todo = editWindow.Todo;
                todoRepo.Update(todo);
            }

            RefreshTodoListBox();
        }
    }
}
