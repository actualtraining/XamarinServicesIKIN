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
        private List<TodoItem> listTodoItem;
        public TampilTodoItem()
        {
            InitializeComponent();
            todoServices = new TodoItemServices();
        }

        protected async override void OnAppearing()
        {
            listTodoItem = await todoServices.GetAllTodoItem();
            lstTodo.ItemsSource = listTodoItem;
        }

        private async void btnTambah_Clicked(object sender, EventArgs e)
        {
            TambahTodoItem tambahTodo = new TambahTodoItem();
            tambahTodo.BindingContext = new TodoItem() { ID = Guid.NewGuid().ToString().Substring(0, 8) };
            await Navigation.PushAsync(tambahTodo);
        }

        private void ButtonEventClicked(object sender, EventArgs e)
        {
            var item = (Button)sender;
            if (item.Text == "Edit")
            {
                TodoItem todoItem = (from itm in listTodoItem
                                     where itm.ID == item.CommandParameter.ToString()
                                     select itm).FirstOrDefault();

            }
        }
    }
}