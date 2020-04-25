using System;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Fundamentals.S3.Core;

namespace Fundamentals.S3.Domain {
    public class S3CheckBucket:IFundamentalService {
        public string GetHints(string serviceName)
        {
            throw new System.NotImplementedException();
        }

        public async Task RunCode () {

            var client = new AmazonS3Client ();
            Console.Write ("Kontrol etmek istediğiniz bucket ismini giriniz : ");
            var bucketName = Console.ReadLine ();

            #region Bucket Kontrolü için kullanılan Kod Bloğu
            var response = await AmazonS3Util.DoesS3BucketExistAsync (client, bucketName);
            if (response) {
                Console.WriteLine ("Bu isimli bir bucket daha önceden oluşturulmuş.\n");
            } else {
                Console.WriteLine ("Bu isimle bir bucket oluşturabilirsiniz.\n");
            }
            #endregion

            Console.WriteLine ("Çıkmak için lütfen bir tuşa basınız");
            Console.ReadKey ();

        }
    }
}