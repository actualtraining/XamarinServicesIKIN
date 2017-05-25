using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinServicesIKIN.Model
{
    public class TodoItemList : BindableObject
    {
        private ObservableCollection<TodoItem> lstTodoItem;
        public ObservableCollection<TodoItem> ListTodoItem
        {
            get { return lstTodoItem; }
            set { lstTodoItem = value; OnPropertyChanged("ListTodoItem"); }
        }

    }
}
