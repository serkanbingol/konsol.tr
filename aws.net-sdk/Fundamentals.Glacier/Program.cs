using System;
using System.Threading.Tasks;
using Fundamentals.Glacier.Domain;

namespace Fundamentals.Glacier
{
    class Program
    {
         static async Task Main(string[] args)
        {
            Glacier_ArchiveTransferManager test = new Glacier_ArchiveTransferManager ();
            await test.RunCode ();
            Console.WriteLine ("Çıkmak için lütfen bir tuşa basınız");
            Console.WriteLine("Hello World!");
        }
    }
}
