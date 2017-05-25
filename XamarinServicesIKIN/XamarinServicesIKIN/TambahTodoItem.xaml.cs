using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinServicesIKIN.Model;
using XamarinServicesIKIN.Services;

namespace XamarinServicesIKIN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TambahTodoItem : ContentPage
    {
        public TambahTodoItem()
        {
            InitializeComponent();
        }

        private async void btnTambah_Clicked(object sender, EventArgs e)
        {
            var newTodo = (TodoItem)this.BindingContext;
            TodoItemServices todoService = new TodoItemServices();
            try
            {
                await todoService.TambahTodoItem(newTodo);
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}