using Firebase.Database;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserApplicatie.Views
{
    public partial class AboutPage : ContentPage
    {
        public ObservableCollection<myDatabaseRecord> DatabaseItems { get; set; } = new ObservableCollection<myDatabaseRecord>();

        FirebaseClient firebaseClient = new FirebaseClient("https://prullenbak-database-default-rtdb.firebaseio.com/");

        public AboutPage()
        {
            InitializeComponent();
            BindingContext = this;
            
            var collection = firebaseClient
                .Child("Data_users")
                .AsObservable<myDatabaseRecord>()
                .Subscribe((dbevent) =>
                {
                    if (dbevent.Object != null)
                    {
                        DatabaseItems.Clear();
                        DatabaseItems.Add(dbevent.Object);
                    }
                });
        }
        int score= 1;
        
        public void btnIncrement_Clicked(object sender, EventArgs e)
        {
            labelTotal.Text = score.ToString();
            if (score >= 10)
            {
                btnIncrement.IsVisible = false;
                QR_image_test.IsVisible = true;
                btnResetQr_test.IsVisible = true;
                lblWon.IsVisible = true;
                score = 10;
            }
            else
            {
                score++;
            }
        }
        private void btnResetQr_test_Clicked(object sender, EventArgs e)
        {
            score = 1;
            labelTotal.Text = "";
            btnIncrement.IsVisible = true;
            lblWon.IsVisible = false;
            QR_image_test.IsVisible = false;
            btnResetQr_test.IsVisible = false;

        }
    }
}