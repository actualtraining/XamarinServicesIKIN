using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinServicesIKIN.Model;
using XamarinServicesIKIN.Services;

namespace XamarinServicesIKIN.ViewModel
{
    public class TodoItemViewModel : BindableObject
    {
        private TodoItemServices todoServices;
        private List<TodoItem> listTodoItem;
        public List<TodoItem> ListTodoItem
        {
            get { return listTodoItem; }
            set { listTodoItem = value; OnPropertyChanged("ListTodoItem"); }
        }

        public async Task GetAllTodoItem()
        {
            ListTodoItem = await todoServices.GetAllTodoItem();
        }

        public TodoItemViewModel()
        {
            todoServices = new TodoItemServices();
        }

    }
}
