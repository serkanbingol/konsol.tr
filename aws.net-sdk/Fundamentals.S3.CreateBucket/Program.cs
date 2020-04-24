using System;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace Fundamentals.BucketCreate {
    class Program {

        static async Task Main (string[] args) {

            var client = new AmazonS3Client ();

            // Bucket ismi kontrolü gerçekleştiriliyor
            // 409 hatası denebilir aynı isimde başka bir bucket var hatası olabilir.
            var response = await AmazonS3Util.DoesS3BucketExistAsync (client, "testbucket1837837837837");
            if (response) {
                Console.WriteLine ("Bucket Already Exist");
            } else {
                var request = new PutBucketRequest {

                    BucketName = "testbucket1837837837837",
                    UseClientRegion = true

                };

                var bucketResponse = await client.PutBucketAsync (request);

                if (bucketResponse.HttpStatusCode == System.Net.HttpStatusCode.OK) {
                    Console.WriteLine ("Bucket Created Succesfully");
                }

            }

            Console.WriteLine ("Çıkmak için lütfen bir tuşa basınız");
            Console.ReadKey ();
        }
    }
}