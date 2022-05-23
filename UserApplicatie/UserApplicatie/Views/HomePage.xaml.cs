using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserApplicatie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public int score = 0;
        public int points = 0;
        public bool qrImage1Shown = false;
        public bool qrImage2Shown = false;
        public bool qrImage3Shown = false;
        public ObservableCollection<myDatabaseRecord> DatabaseItems { get; set; } = new ObservableCollection<myDatabaseRecord>();
        FirebaseHelper fh = new FirebaseHelper();
        FirebaseClient firebaseClient = new FirebaseClient("https://prullenbak-database-default-rtdb.firebaseio.com/");
        public HomePage()
        {
            InitializeComponent();
            BindingContext = this;
            labelTotal.Text = "0 / 10";
            foreach(var item in LoginPage.getDatabaseNamesList())
            {
                nameUser.Text = $"Welkom terug {item}";
            }
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

        private void btnResetQr_test_Clicked(object sender, EventArgs e)
        {
            score = 0;
            //points = 0;
            labelTotal.Text = "0 / 10";
            btnIncrement.IsVisible = true;
            lblWon.IsVisible = false;
            
            btnResetQr_test.IsVisible = false;
            image10.IsVisible = false;
            image0.IsVisible = true;
        }
        
        private void btnIncrement_Clicked(object sender, EventArgs e)
        {
            points++;
            if (points >= 10 && qrImage1Shown == false)
            {
                lblGenoegIngeleverd.IsVisible = false;
                qrImage1Shown = true;
                QR_image_test.IsVisible = true;
                btnIncrement.IsVisible = false;
                btnResetQr_test.IsVisible = true;
                lblWon.IsVisible = true;
                labelTotal.Text = "10 / 10";
            }
            else if (points >= 20 && qrImage2Shown == false)
            {
                qrImage2Shown = true;
                QR_image_test2.IsVisible = true;
                btnIncrement.IsVisible = false;
                btnResetQr_test.IsVisible = true;
                lblWon.IsVisible = true;
                labelTotal.Text = "10 / 10";
            }
            else if (points >= 30 && qrImage3Shown == false)
            {
                qrImage3Shown = true;
                QR_image_test3.IsVisible = true;
                btnIncrement.IsVisible = false;
                btnResetQr_test.IsVisible = true;
                lblWon.IsVisible = true;
                labelTotal.Text = "10 / 10";
                lblWon.Text = "Je hebt het maximaal aantal flesjes ingeleverd. \n Ga naar de bar om je coupons te innen.";
            }
            else
            {
                labelTotal.Text = (score+1).ToString() + " / 10";
                score++;
                firebaseClient.Child("Data_users").Child("-N2BHD0i8NwQ-n_FVqZx").PutAsync(new myDatabaseRecord 
                { 
                    UserName = LoginPage.getDatabaseNames(), 
                    UserPassword = LoginPage.getDatabasePassword(), 
                    userPoints = points
                });
                
            }
            switch (points)
            {
                case 0:
                    image0.IsVisible = true;
                    image1.IsVisible = false;
                    image2.IsVisible = false;
                    image3.IsVisible = false;
                    image4.IsVisible = false;
                    image5.IsVisible = false;
                    image6.IsVisible = false;
                    image7.IsVisible = false;
                    image8.IsVisible = false;
                    image9.IsVisible = false;
                    image10.IsVisible = false;
                    break;
                case 1:
                    image0.IsVisible = false;
                    image1.IsVisible = true;
                    image2.IsVisible = false;
                    image3.IsVisible = false;
                    image4.IsVisible = false;
                    image5.IsVisible = false;
                    image6.IsVisible = false;
                    image7.IsVisible = false;
                    image8.IsVisible = false;
                    image9.IsVisible = false;
                    image10.IsVisible = false;
                    break;
                case 2:
                    image0.IsVisible = false;
                    image1.IsVisible = false;
                    image2.IsVisible = true;
                    image3.IsVisible = false;
                    image4.IsVisible = false;
                    image5.IsVisible = false;
                    image6.IsVisible = false;
                    image7.IsVisible = false;
                    image8.IsVisible = false;
                    image9.IsVisible = false;
                    image10.IsVisible = false;
                    break;
                case 3:
                    image0.IsVisible = false;
                    image1.IsVisible = false;
                    image2.IsVisible = false;
                    image3.IsVisible = true;
                    image4.IsVisible = false;
                    image5.IsVisible = false;
                    image6.IsVisible = false;
                    image7.IsVisible = false;
                    image8.IsVisible = false;
                    image9.IsVisible = false;
                    image10.IsVisible = false;
                    break;
                case 4:
                    image0.IsVisible = false;
                    image1.IsVisible = false;
                    image2.IsVisible = false;
                    image3.IsVisible = false;
                    image4.IsVisible = true;
                    image5.IsVisible = false;
                    image6.IsVisible = false;
                    image7.IsVisible = false;
                    image8.IsVisible = false;
                    image9.IsVisible = false;
                    image10.IsVisible = false;
                    break;
                case 5:
                    image0.IsVisible = false;
                    image1.IsVisible = false;
                    image2.IsVisible = false;
                    image3.IsVisible = false;
                    image4.IsVisible = false;
                    image5.IsVisible = true;
                    image6.IsVisible = false;
                    image7.IsVisible = false;
                    image8.IsVisible = false;
                    image9.IsVisible = false;
                    image10.IsVisible = false;
                    break;
                case 6:
                    image0.IsVisible = false;
                    image1.IsVisible = false;
                    image2.IsVisible = false;
                    image3.IsVisible = false;
                    image4.IsVisible = false;
                    image5.IsVisible = false;
                    image6.IsVisible = true;
                    image7.IsVisible = false;
                    image8.IsVisible = false;
                    image9.IsVisible = false;
                    image10.IsVisible = false;
                    break;
                case 7:
                    image0.IsVisible = false;
                    image1.IsVisible = false;
                    image2.IsVisible = false;
                    image3.IsVisible = false;
                    image4.IsVisible = false;
                    image5.IsVisible = false;
                    image6.IsVisible = false;
                    image7.IsVisible = true;
                    image8.IsVisible = false;
                    image9.IsVisible = false;
                    image10.IsVisible = false;
                    break;
                case 8:
                    image0.IsVisible = false;
                    image1.IsVisible = false;
                    image2.IsVisible = false;
                    image3.IsVisible = false;
                    image4.IsVisible = false;
                    image5.IsVisible = false;
                    image6.IsVisible = false;
                    image7.IsVisible = false;
                    image8.IsVisible = true;
                    image9.IsVisible = false;
                    image10.IsVisible = false;
                    break;
                case 9:
                    image0.IsVisible = false;
                    image1.IsVisible = false;
                    image2.IsVisible = false;
                    image3.IsVisible = false;
                    image4.IsVisible = false;
                    image5.IsVisible = false;
                    image6.IsVisible = false;
                    image7.IsVisible = false;
                    image8.IsVisible = false;
                    image9.IsVisible = true;
                    image10.IsVisible = false;
                    break;
                case 10:
                    image0.IsVisible = false;
                    image1.IsVisible = false;
                    image2.IsVisible = false;
                    image3.IsVisible = false;
                    image4.IsVisible = false;
                    image5.IsVisible = false;
                    image6.IsVisible = false;
                    image7.IsVisible = false;
                    image8.IsVisible = false;
                    image9.IsVisible = false;
                    image10.IsVisible = true;
                    break;
            }
        }


    }
}