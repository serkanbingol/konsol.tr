using System;
using System.Threading.Tasks;
using Fundamentals.S3.Domain;

namespace Fundamentals.S3
{
    class Program
    {
        static async Task Main(string[] args)
        {
           S3UploadBucket test = new S3UploadBucket();
           await test.RunCode();
           Console.WriteLine ("Çıkmak için lütfen bir tuşa basınız");
            Console.ReadKey ();
        }
    }
}
