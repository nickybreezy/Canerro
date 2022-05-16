using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApplicatie.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Forms.Xaml;

namespace UserApplicatie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public ObservableCollection<myDatabaseRecord> DatabaseItems { get; set; } = new ObservableCollection<myDatabaseRecord>();
        FirebaseClient firebaseClient = new FirebaseClient("https://prullenbak-database-default-rtdb.firebaseio.com/");
        FirebaseHelper fh = new FirebaseHelper();
       
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string[] allPersonsNames = await fh.GetAllPersonsNames();
            string[] allPersonsPasswords = await fh.GetAllPersonsPasswords();
            if (allPersonsNames.Contains(txtUsername.Text) && allPersonsPasswords.Contains(txtPassword.Text))
            {
                await Navigation.PushAsync(new AboutPage());
            }
            else
            {
                await DisplayAlert("Inloggen mislukt", "Username of Password is incorrect", "Ok");
            }
        }
    }
}