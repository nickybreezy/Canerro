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
        public int totalPointsDatabase = 0;
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

        public bool hasMaxVouchers()
        {
            return points >= 31 ? true : false;
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
        
        private async void btnIncrement_Clicked(object sender, EventArgs e)
        {
            int[] getPoints = await fh.GetAllPersonsPoints();       
            foreach (int item in getPoints)
            {
                totalPointsDatabase = item;
                Console.WriteLine(item);
            }
            Console.WriteLine(getPoints[1]);

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
            else if (hasMaxVouchers() && qrImage3Shown == false)
            {
                qrImage3Shown = true;
                QR_image_test3.IsVisible = true;
                btnIncrement.IsVisible = false;
                btnResetQr_test.IsVisible = true;
                lblWon.IsVisible = true;
                labelTotal.Text = "10 / 10";
                lblWon.Text = "";
                await DisplayAlert("Je hebt het maximaal aantal flesjes ingeleverd.", "Ga naar de bar om je coupons te innen.", "Ok");
            }
            else
            {
                labelTotal.Text = (score+1).ToString() + " / 10";
                score++;
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
                case 11:
                case 21:
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
                case 12:
                case 22:
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
                case 13:
                case 23:
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
                case 14:
                case 24:
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
                case 15:
                case 25:
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
                case 16:
                case 26:
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
                case 17:
                case 27:
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
                case 18:
                case 28:
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
                case 19:
                case 29:
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
                case 20:
                case 30:
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