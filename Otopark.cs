using System;

class Otopark
{
    private Araba[] arabalar;
    private int mevcutArabaSayisi;
    private const int Kapasite = 20;
    private const int SaatlikUcret = 5;

    public Otopark()
    {
        arabalar = new Araba[Kapasite];
        mevcutArabaSayisi = 0;
    }

    public void ArabaEkle(string plaka)
    {
        if (mevcutArabaSayisi >= Kapasite)
        {
            Console.WriteLine("Otopark dolu! Yeni araba eklenemiyor.");
            return;
        }

        for (int i = 0; i < mevcutArabaSayisi; i++)
        {
            if (arabalar[i].Plaka == plaka)
            {
                Console.WriteLine("Bu araç zaten mevcut!");
                return;
            }
        }

        Araba yeniAraba = new Araba(plaka, DateTime.Now);
        arabalar[mevcutArabaSayisi] = yeniAraba;
        mevcutArabaSayisi++;
        Console.WriteLine(plaka + " plakalı araç otoparka eklendi.");
        Console.WriteLine("Giriş Saati: " + yeniAraba.GirisSaati);
    }

    public void ArabaCikar(string plaka)
    {
        int index = -1;
        for (int i = 0; i < mevcutArabaSayisi; i++)
        {
            if (arabalar[i].Plaka == plaka)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("Bu plaka ile kayıtlı araç bulunamadı!");
            return;
        }

        int ucret = SaatUcret(arabalar[index]);
        Console.WriteLine("\n" + plaka + " plakalı araç otoparkttan çıkartılıyor...");
        Console.WriteLine("Ödenmesi gereken ücret: " + ucret + " TL");

        for (int i = index; i < mevcutArabaSayisi - 1; i++)
        {
            arabalar[i] = arabalar[i + 1];
        }
        mevcutArabaSayisi--;
        Console.WriteLine("Araç çıkartıldı.");
    }

    public void MevcutAraba()
    {
        if (mevcutArabaSayisi == 0)
        {
            Console.WriteLine("Otopark boş! Hiç araç yok.");
            return;
        }

        Console.WriteLine("\n--- Otoparktaki Araçlar (Toplam: " + mevcutArabaSayisi + "/" + Kapasite + ") ---");
        for (int i = 0; i < mevcutArabaSayisi; i++)
        {
            Console.Write((i + 1) + ". ");
            arabalar[i].BilgileriGoster();
        }
    }

    public int SaatUcret(Araba araba)
    {
        TimeSpan kalisSuresi = DateTime.Now - araba.GirisSaati;
        int toplamSaat = (int)Math.Ceiling(kalisSuresi.TotalHours);
        
        if (toplamSaat < 1)
            toplamSaat = 1;

        int ucret = toplamSaat * SaatlikUcret;
        
        return ucret;
    }
}


