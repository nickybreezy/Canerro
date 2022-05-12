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
        public async Task<List<myDatabaseRecord>> GetAllUsers()
        {
            return (await firebaseClient
              .Child("Users")
              .OnceAsync<myDatabaseRecord>()).Select(item => new myDatabaseRecord
              {
                  UserName = item.Object.UserName
              }).ToList();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var allPersons = await GetAllUsers();
            Console.WriteLine(allPersons);
            if (RegisterPage.loginInfo.Contains(txtUsername.Text))
            {
                DisplayAlert("Inloggen mislukt", "Username of Password is incorrect", "Ok");
                Navigation.PushAsync(new AboutPage());
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