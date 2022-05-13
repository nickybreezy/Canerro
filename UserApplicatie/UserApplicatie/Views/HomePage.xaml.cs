using Firebase.Database;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserApplicatie.Views
{
    public partial class AboutPage : ContentPage
    {
        public ObservableCollection<myDatabaseRecord> DatabaseItems { get; set; } = new ObservableCollection<myDatabaseRecord>();

        FirebaseClient firebaseClient = new FirebaseClient("https://prullenbak-database-default-rtdb.firebaseio.com/");
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        int totalTrownAway = 0;
        bool IsStartVisible = false;

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
                        totalTrownAway++;
                        if (totalTrownAway > 0)
                        {
                            IsStartVisible = true;
                        }
                    }
                });
        }
    }
}