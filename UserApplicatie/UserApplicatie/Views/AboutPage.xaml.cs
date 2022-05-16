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
        int score= 0;
        
        public void btnIncrement_Clicked(object sender, EventArgs e)
        {
            
            score++;
            labelTotal.Text = score.ToString();
            if (score >= 10)
            {
                QR_image_test.IsVisible = true;
            }
            Console.WriteLine("test");
        }
    }
}