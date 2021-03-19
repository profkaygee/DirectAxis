using Firebase.Storage;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var link = TestFirebase().GetAwaiter().GetResult();
            

            Console.WriteLine(link);

            Console.ReadKey();
        }

        public static async Task<string> TestFirebase()
        {
            // Get any Stream - it can be FileStream, MemoryStream or any other type of Stream
            var stream = File.Open(@"C:\Users\KagisoM\Pictures\24130511_10213511336153753_3037640252243437517_o.jpg", FileMode.Open);

            // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
            var task = new FirebaseStorage("nuddle-e7e40.appspot.com")
                .Child("data")
                .Child("random")
                .Child("testImage.png")
                .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // await the task to wait until upload completes and get the download url
            var downloadUrl = await task;

            return downloadUrl;
        }
    }
}
