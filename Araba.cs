using System;

class Araba
{
    public string Plaka { get; set; }
    public DateTime GirisSaati { get; set; }

    public Araba(string plaka, DateTime girisSaati)
    {
        Plaka = plaka;
        GirisSaati = girisSaati;
    }

    public void BilgileriGoster()
    {
        Console.WriteLine("Plaka: " + Plaka + " - Giriş Saati: " + GirisSaati);
    }
}


