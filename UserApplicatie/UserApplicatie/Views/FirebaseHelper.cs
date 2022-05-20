using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApplicatie.Views
{
    public class FirebaseHelper
    {
        FirebaseClient firebaseClient;

        public FirebaseHelper()
        {
            firebaseClient = new FirebaseClient("https://prullenbak-database-default-rtdb.firebaseio.com/");
        }
        public async Task<string[]> GetAllPersonsNames()
        {
            return (await firebaseClient
              .Child("Data_users")
              .OnceAsync<myDatabaseRecord>()).Select(item =>
              item.Object.UserName).ToArray();
        }
        public async Task<string[]> GetAllPersonsPasswords()
        {
            return (await firebaseClient
              .Child("Data_users")
              .OnceAsync<myDatabaseRecord>()).Select(item =>
              item.Object.UserPassword).ToArray();
        }
        public async Task<int[]> GetAllPersonsPoints()
        {
            return (await firebaseClient
              .Child("Data_users")
              .OnceAsync<myDatabaseRecord>()).Select(item =>
              item.Object.userPoints).ToArray();
        }
    }
}
