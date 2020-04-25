using System;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Transfer;
using Fundamentals.S3.Core;

namespace Fundamentals.S3.Domain {
    public class S3UploadBucket : IFundamentalService {
        public string GetHints (string serviceName) {
            throw new System.NotImplementedException ();
        }

        public async Task RunCode () {

            var client = new AmazonS3Client ();

            Console.Write ("Upload yapmak istediğiniz bucket ismini giriniz : ");
            var bucketName = Console.ReadLine ();

            Console.Write ("Upload yapmak istediğiniz nedir ? [Dosya = 1 , Klasör = 2] : ");
            var fileType = Console.ReadLine ();
            Console.WriteLine ();

            Console.Write ("Upload yapmak istediğiniz dosya/klasör public olarak kullanılabilsin mi ? [y/n] : ");
            var accessType = Console.ReadLine ();
            Console.WriteLine ();

            Console.Write ("Upload yapmak istediğiniz dosya/klasör tam yolunu giriniz : ");
            var filePath = Console.ReadLine ();

            #region Bucket Upload için kullanılan Kod Bloğu
            var transferUtility = new TransferUtility (client);

            switch (fileType) {

                // Dosya yüklemek için kullanılan alan
                case "1":
                    var transferForFileRequest = new TransferUtilityUploadRequest {

                        FilePath = filePath,
                        BucketName = bucketName,
                        CannedACL = (accessType == "y") ? S3CannedACL.PublicRead : S3CannedACL.Private

                    };
                    await transferUtility.UploadAsync (transferForFileRequest);
                    break;
                    // Klasör yüklemek için kullanılan alan
                case "2":
                    var transferForFolderRequest = new TransferUtilityUploadDirectoryRequest {

                        Directory = filePath,
                        BucketName = bucketName,
                        CannedACL = (accessType == "y") ? S3CannedACL.PublicRead : S3CannedACL.Private

                    };
                    await transferUtility.UploadDirectoryAsync (transferForFolderRequest);
                    break;
            }

            #endregion

        }
    }
}