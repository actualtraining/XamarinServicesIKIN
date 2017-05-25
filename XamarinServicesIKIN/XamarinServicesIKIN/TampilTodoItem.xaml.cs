using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinServicesIKIN.Services;
using XamarinServicesIKIN.Model;
using System.Collections.ObjectModel;

namespace XamarinServicesIKIN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TampilTodoItem : ContentPage
    {
        private TodoItemServices todoServices;
        private TodoItemList todoItemList;
        public TampilTodoItem()
        {
            InitializeComponent();
            todoServices = new TodoItemServices();
        }

        protected async override void OnAppearing()
        {
            todoItemList = new TodoItemList();
            todoItemList.ListTodoItem = new ObservableCollection<TodoItem>(await todoServices.GetAllTodoItem());
            lstTodo.ItemsSource = todoItemList.ListTodoItem;
        }

        private async void btnTambah_Clicked(object sender, EventArgs e)
        {
            TambahTodoItem tambahTodo = new TambahTodoItem();
            tambahTodo.BindingContext = new TodoItem() { ID = Guid.NewGuid().ToString().Substring(0, 8) };
            await Navigation.PushAsync(tambahTodo);
        }

        private async void ButtonEventClicked(object sender, EventArgs e)
        {
            var item = (Button)sender;
            if (item.Text == "Edit")
            {
                TodoItem todoItem = (from itm in todoItemList.ListTodoItem
                                     where itm.ID == item.CommandParameter.ToString()
                                     select itm).FirstOrDefault();
                try
                {
                    await todoServices.EditTodoItem(todoItem);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Error : " + ex.Message, "OK");
                }
            }
        }
    }
}