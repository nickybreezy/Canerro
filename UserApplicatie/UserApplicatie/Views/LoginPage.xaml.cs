using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApplicatie.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserApplicatie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(txtUsername.Text =="Tim" && txtPassword.Text =="test")
            {
                Navigation.PushAsync(new AboutPage());
            }
            else
            {
                DisplayAlert("Inloggen mislukt", "Username of Password is incorrect", "Ok");
            }
        }
    }
}