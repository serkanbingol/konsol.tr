using System;
using System.Threading.Tasks;
using Amazon.Glacier;
using Amazon.Glacier.Transfer;
using Fundamentals.Shared.Interfaces;

namespace Fundamentals.Glacier.Domain {
    public class Glacier_ArchiveTransferManager : IFundamentalService {
        public void AddSpace () {
            Console.WriteLine ();
            Console.WriteLine ("---------- İşlem Tamamlandı ----------");
        }

        public string GetHints (string serviceName) {
            throw new System.NotImplementedException ();
        }

        public async Task RunCode () {

            var client = new AmazonGlacierClient ();
            var manager = new ArchiveTransferManager (client);

            #region ArchiveTransferManager için kullanılan Kod Bloğu
            Console.Write ("Yeni bir vault oluşturmak istiyor musunuz ?: [y/n] ");

            ConsoleKeyInfo decisionCreate = Console.ReadKey ();
            Console.WriteLine ();
            if (decisionCreate.Key == ConsoleKey.Y) {
                // High-Level API ile vault oluşturma işlemi
                Console.Write ("Oluşturmak istediğiniz glacier vault ismini giriniz : ");
                var createVaultName = Console.ReadLine ();
                await manager.CreateVaultAsync (createVaultName);
                Console.WriteLine ($"{createVaultName} isimli vault oluşturuldu");
            }
            AddSpace ();

            Console.Write ("Bir vault içine upload yapmak istiyor musnuz ?: [y/n] ");

            ConsoleKeyInfo decisionUpload = Console.ReadKey ();
            Console.WriteLine ();
            if (decisionUpload.Key == ConsoleKey.Y) {
                // High-Level API ile archive oluşturma işlemi
                Console.Write ("Upload yapmak istediğiniz glacier vault ismini giriniz : ");
                var uploadVaultName = Console.ReadLine ();
                Console.Write ("Oluşturmak istediğiniz archive  açıklamasını giriniz : ");
                var archiveDesc = Console.ReadLine ();
                Console.Write ("Upload etmek istediğiniz dosya yolunu giriniz : ");
                var filePath = Console.ReadLine ();
                var response = await manager.UploadAsync (uploadVaultName, archiveDesc, filePath);
                Console.WriteLine ($"Yüklemiş olduğunuz dosya kaydedilmiştir. ArchiveId : {response.ArchiveId} ");
            }
            AddSpace ();

            Console.Write ("Yeni bir download yapmak istiyor musunuz ?: [y/n] ");

            ConsoleKeyInfo decisionDownload = Console.ReadKey ();
            Console.WriteLine ();
            if (decisionDownload.Key == ConsoleKey.Y) {
                // High-Level API ile archive download etme işlemi
                Console.Write ("Download yapmak istediğiniz glacier vault ismini giriniz : ");
                var downloadVaultName = Console.ReadLine ();
                Console.Write ("İndirmek istediğiniz archive için ArchiveId giriniz : ");
                var archiveId = Console.ReadLine ();
                Console.Write ("Download etmek istediğiniz local dosya yolunu giriniz : ");
                var downloadPath = Console.ReadLine ();
                await manager.DownloadAsync (downloadVaultName, archiveId, downloadPath);
                Console.WriteLine ($"Dosyanız başarılı şekilde indirildi.");
            }
            AddSpace ();
            Console.Write ("Bir vault Silmek istiyor musunuz ?: [y/n] ");

            ConsoleKeyInfo decisionDelete = Console.ReadKey ();
            Console.WriteLine ();
            if (decisionDelete.Key == ConsoleKey.Y) {
                // High-Level API ile vault silme işlemi
                Console.Write ("Silmek istediğiniz glacier vault ismini giriniz : ");
                var deleteVaultName = Console.ReadLine ();
                await manager.DeleteVaultAsync (deleteVaultName);
                Console.WriteLine ($"{deleteVaultName} isimli vault başarı ile silindi.");
            }
            AddSpace ();
            #endregion
        }
    }
}