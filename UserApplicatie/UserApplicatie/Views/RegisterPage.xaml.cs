using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using UserApplicatie.ViewModels;
using UserApplicatie.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserApplicatie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    //nicky was hiierr
    public partial class RegisterPage : ContentPage
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://prullenbak-database-default-rtdb.firebaseio.com/");
        public bool isUserSignedIn = false;
        
        
        public RegisterPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        
        private void OnImageNameTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
        
        private void Button_Clicked2(object sender, EventArgs e)
        {
            isTextboxEmpty();
            isPasswordCorrect();
            checkEmail();
            //checkEmail();
            if (!isTextboxEmpty() || !isPasswordCorrect() || checkEmail() != null)
            {
                Navigation.PushAsync(new HomePage());
                isUserSignedIn = true;
                firebaseClient.Child("Data_users").PostAsync(new myDatabaseRecord { UserName = txtName.Text, UserPassword = txtPassword.Text });
            }
        }
        public string checkEmail()
        {
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))       // hier mogelijk nog meer
            {                                                                       // validatie implementeren
                txtEmail.Text = "";
                txtEmail.Placeholder = "Incorrect email";
                txtEmail.Opacity = 0.9;
                txtEmail.PlaceholderColor = Color.Red;
                return null;
            }
            return txtEmail.Text;
        }
        public bool isPasswordCorrect()
        {
            if (txtPassword.Text != txtRepeatPassword.Text || txtRepeatPassword.Text == null)
            {
                txtRepeatPassword.Text = "";
                txtRepeatPassword.Placeholder = "Not the same";
                txtRepeatPassword.Opacity = 0.9;
                txtRepeatPassword.PlaceholderColor = Color.Red;
                return true;
            }
            return false;
        }
        public bool isTextboxEmpty()
        {
            if (txtName.Text == null)
            {
                txtName.Placeholder = "Please, fill in your name";
                txtName.Opacity = 0.7;
                txtName.PlaceholderColor = Color.Red;
                return true;
            }
            else if (txtLastname.Text == null)
            {
                txtLastname.Placeholder = "Please, fill in your last name";
                txtLastname.Opacity = 0.7;
                txtLastname.PlaceholderColor = Color.Red;
                return true;
            }
            else if (txtEmail.Text == null)
            {
                txtEmail.Placeholder = "Please, fill in your email";
                txtEmail.Opacity = 0.7;
                txtEmail.PlaceholderColor = Color.Red;
                return true;
            }
            else if (txtPassword.Text == null)
            {
                txtPassword.Placeholder = "Please, fill in your password";
                txtPassword.Opacity = 0.7;
                txtPassword.PlaceholderColor = Color.Red;
                return true;
            }
            else if (txtRepeatPassword.Text == null)
            {
                txtRepeatPassword.Placeholder = "Please, fill in your repeated password";
                txtRepeatPassword.Opacity = 0.7;
                txtRepeatPassword.PlaceholderColor = Color.Red;
                return true;
            }
            return false;
        }

        private void Image_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }
    }
}