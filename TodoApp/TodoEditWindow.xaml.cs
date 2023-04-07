using System;
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
using System.Windows.Shapes;
using TodoApp.Models;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for TodoEditWindow.xaml
    /// </summary>
    public partial class TodoEditWindow : Window
    {
        private Todo _todo;

        public Todo Todo
        {
            get { return _todo; }
            set { _todo = value; }
        }

        public TodoEditWindow(Todo? todo = null)
        {
            if(todo == null) todo = new Todo();
            _todo = todo;
            InitializeComponent();
            txbDescription.Text = todo.Description;
            cbxIsComplete.IsChecked = todo.IsComplete;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            _todo.Description = txbDescription.Text;
            _todo.IsComplete = cbxIsComplete.IsChecked == true;
            this.DialogResult = true;   
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
