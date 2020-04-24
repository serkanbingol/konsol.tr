using System;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace Fundamentals.BucketCreate {
    class Program {

        static async Task Main (string[] args) {

            var client = new AmazonS3Client ();
            Console.Write ("Kontrol etmek istediğiniz bucket ismini giriniz : ");
            var bucketName = Console.ReadLine ();

            #region Bucket Kontrolu için kullanılan Kod Bloğu
            var response = await AmazonS3Util.DoesS3BucketExistAsync (client, bucketName);
            if (response) {
                Console.WriteLine ("Bu isimli bir bucket daha önceden oluşturulmuş.\n");
            } else {
                Console.WriteLine ("Bu isimle bir bucket oluşturabilirsiniz.\n");
            }
            #endregion

            Console.WriteLine ("Faydalı Bilgiler :\n* AWS S3 bucketlar benzersiz isimlendirmelere sahiptirler. AWS içinde aynı isimli 2 bucket oluşturulamaz.\n* Bucket isimlendirme kuralları için \"https://docs.aws.amazon.com/AmazonS3/latest/dev/BucketRestrictions.html\" adresinden \"Rules for Bucket Naming\" alanına göz atınız.\n* API üzerinden bucket oluşturmak istediğinizde isim kontrolü yapılmaz ve aynı isimli bir bucket var ise HTTP response olarak 409 Conflict alırız.\n* API üzerinden kontrol için \"Amazon.S3.Util\" namespace içindeki \"DoesS3BucketExistAsync()\" metodu kullanılmaktadır.\n* Parametre olarak \"AmazonS3Client\" ve \"string bucket ismi\" almaktadır.\n");
            Console.WriteLine ("Çıkmak için lütfen bir tuşa basınız");
            Console.ReadKey ();
        }
    }
}