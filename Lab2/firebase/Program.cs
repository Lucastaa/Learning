using System;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace Firebase
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Firebase installed successfully!");

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("serviceAccountKey.json")
            });

            Console.WriteLine("Firebase Admin created successfully.");
            await AddTestData();
        }

        public static string firebaseDB_URL = "https://fir-bcb83-default-rtdb.asia-southeast1.firebasedatabase.app";

        public static async Task AddTestData()
        {
            var firebase = new FirebaseClient(firebaseDB_URL);

            var testData = new
            {
                Message = "Hello Firebase!",
                TimeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
            };

            await firebase.Child("Firebase").PutAsync(testData);
            Console.WriteLine("Test data added successfully.");
        }
        //public static async Task ReadTestData()
        //{
        //    var firebase = new FirebaseClient(firebaseDB_URL);
        //    var testData = await firebase.Child("test").OnceSingleAsync<dynamic>;
        //    Console.WriteLine($"Message: {testData.Message}");
        //    Console WriteLine($"Timestamp: {testData.Timestamp}");
        //}
        //public static async Task UpdateTestData()
        //{
        //    var firebase = new FirebaseClient(firebaseDB_URL);
        //    var updatedData = new
        //    {
        //        Message = "Updated Message!",
        //        Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH: mm: ss");

        //    await firebase.Child("test").PatchAsync(updatedData);
        //    Console WriteLine("Dữ liệu đã được cập nhật");
        //}
    }
}