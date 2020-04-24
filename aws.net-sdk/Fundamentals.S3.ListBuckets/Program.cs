using System;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;

namespace S3CreateAndList {
    class Program {
        static async Task Main (string[] args)

        {
            var client = new AmazonS3Client ();
            try {

                Console.WriteLine ("AWS S3 bucketlarınız listeleniyor...");

                var response = await client.ListBucketsAsync ();

                Console.WriteLine ($"Belirlediğiniz region üzerindeki toplam bucket sayınız : {response.Buckets.Count} adettir.");

                foreach (S3Bucket b in response.Buckets) {
                    Console.WriteLine ($"Bucket Adı : {b.BucketName} - Oluşturma Tarihi : {b.CreationDate}");
                }
            } catch (Exception e) {
                Console.WriteLine ("AWS S3 bucketlarınız listelenirken bir hata oluştu :");
                Console.WriteLine (e.Message);
            }
            Console.WriteLine ("Çıkmak için lütfen bir tuşa basınız");
            Console.ReadKey ();

        }
    }
}