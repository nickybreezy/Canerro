using Firebase.Database;
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
        public ObservableCollection<myDatabaseRecord> DatabaseItems { get; set; } = new ObservableCollection<myDatabaseRecord>();
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

        private void btnResetQr_test_Clicked(object sender, EventArgs e)
        {
            score = 0;
            labelTotal.Text = "0 / 10";
            btnIncrement.IsVisible = true;
            lblWon.IsVisible = false;
            QR_image_test.IsVisible = false;
            btnResetQr_test.IsVisible = false;
        }

        private void btnIncrement_Clicked(object sender, EventArgs e)
        {
            labelTotal.Text = score.ToString();
            if (score + 1 >= 10)
            {
                btnIncrement.IsVisible = false;
                QR_image_test.IsVisible = true;
                btnResetQr_test.IsVisible = true;
                lblWon.IsVisible = true;
                labelTotal.Text = (score + 1).ToString() + " / 10";
                score = 10;
            }
            else
            {
                score++;
                labelTotal.Text = score.ToString() + " / 10";
            }
        }


    }
}