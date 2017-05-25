using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinServicesIKIN.Services;
using XamarinServicesIKIN.Model;

namespace XamarinServicesIKIN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TampilTodoItem : ContentPage
    {
        private TodoItemServices todoServices;
        public TampilTodoItem()
        {
            InitializeComponent();
            todoServices = new TodoItemServices();
        }

        protected async override void OnAppearing()
        {
            lstTodo.ItemsSource = await todoServices.GetAllTodoItem();
        }
    }
}