using System;

class Program
{
    static void Main(string[] args)
    {
        Otopark otopark = new Otopark();
        bool devam = true;

        Console.WriteLine("* Araba Park Sistemine Hoş Geldiniz *");

        while (devam)
        {
            Console.WriteLine("\n--- MENÜ ---");
            Console.WriteLine("1. Yeni Araba Ekle");
            Console.WriteLine("2. Araba Çıkar");
            Console.WriteLine("3. Mevcut Arabaları Görüntüle");
            Console.WriteLine("4. Programdan Çık");
            Console.Write("\nSeçiminiz (1-4): ");

            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    Console.Write("Araç plakasını giriniz: ");
                    string plaka = Console.ReadLine();
                    otopark.ArabaEkle(plaka.ToUpper());
                    break;

                case 2:
                    Console.Write("Çıkartılacak aracın plakasını giriniz: ");
                    string cikacakPlaka = Console.ReadLine();
                    otopark.ArabaCikar(cikacakPlaka.ToUpper());
                    break;

                case 3:
                    otopark.MevcutAraba();
                    break;

                case 4:
                    Console.WriteLine("\nProgramdan çıkılıyor...");
                    devam = false;
                    break;
            }
        }
    }
}
