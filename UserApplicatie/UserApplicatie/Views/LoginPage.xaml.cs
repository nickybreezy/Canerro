using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<myDatabaseRecord> DatabaseItems { get; set; } = new ObservableCollection<myDatabaseRecord>();
        FirebaseClient firebaseClient = new FirebaseClient("https://prullenbak-database-default-rtdb.firebaseio.com/");

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
        public void readDatabase()
        {
            BindingContext = this;
            var collection = firebaseClient
                .Child("Data_users")
                .AsObservable<myDatabaseRecord>()
                .Subscribe((dbevent) =>
                {
                    if (dbevent.Object != null)
                    {
                        DatabaseItems.Add(dbevent.Object);
                    }
                });
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            int itemsInDatabase = DatabaseItems.Count();
            
            if (RegisterPage.loginInfo.Contains("h"))
            {
                DisplayAlert("Inloggen mislukt", "Username of Password is incorrect", "Ok");
            }
            //if (txtUsername.Text == "Tim" && txtPassword.Text == "test")
            //{
            //    Navigation.PushAsync(new AboutPage());
            //}
            //else
            //{
            //    DisplayAlert("Inloggen mislukt", "Username of Password is incorrect", "Ok");
            //}
        }
    }
}