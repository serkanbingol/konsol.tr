using System;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Fundamentals.S3.Core;

namespace Fundamentals.S3.Domain {
    public class S3ListBuckets : IFundamentalService {
        public async Task RunCode ()

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

        public string GetHints (string serviceName) {
            throw new NotImplementedException ();
        }

    }
}