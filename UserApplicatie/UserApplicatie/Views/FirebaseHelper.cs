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
        FirebaseClient firebase;

        FirebaseHelper()
        {
            firebase = new FirebaseClient("https://fir-databasedemo-62a72.firebaseio.com/");
        }

        public async Task AddUser(string UserName)
        {
            await firebase
              .Child("Users")
              .PostAsync(new myDatabaseRecord() { UserName = UserName});
        }

        public async Task<List<myDatabaseRecord>> GetAllUsers()
        {
            return (await firebase
              .Child("Users")
              .OnceAsync<myDatabaseRecord>()).Select(item => new myDatabaseRecord
              {
                  UserName = item.Object.UserName
              }).ToList();
        }
    }
}
