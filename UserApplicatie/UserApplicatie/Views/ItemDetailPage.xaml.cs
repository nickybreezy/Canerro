using System.ComponentModel;
using UserApplicatie.ViewModels;
using Xamarin.Forms;

namespace UserApplicatie.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            BindingContext = new ItemDetailViewModel();
        }

        private void Button_Clicked3(object sender)
        {

        }
    }
}