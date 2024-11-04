using System;

class HashTablosu
{
    private int[] tablo; // Hash tablosunu tutan dizi
    private int boyut; // Tablo boyutunu saklar

    public HashTablosu(int boyut)
    {
        this.boyut = boyut;
        tablo = new int[boyut]; // Hash tablosunu istenen boyutla oluşturuyoruz

        // Tüm hücreleri -1 ile doldurarak başlangıçta boş olduklarını belirtiyoruz
        for (int i = 0; i < boyut; i++)
        {
            tablo[i] = -1; // Her hücreye -1 atıyoruz
        }
    }

    // Hash fonksiyonu: Anahtarın boyut ile bölümünden kalan değeri döndürür
    private int HashFonksiyonu(int anahtar)
    {
        return anahtar % boyut; // Anahtarın hash indeksini hesaplıyoruz
    }

    // Lineer Probing yöntemiyle anahtar ekleyen metot
    public void EkleLineer(int anahtar)
    {
        int hashIndeksi = HashFonksiyonu(anahtar); // Anahtar için hash indeksi hesaplıyoruz

        // Eğer hesaplanan indeks doluysa, bir sonraki indeksi kontrol ediyoruz
        while (tablo[hashIndeksi] != -1)
        {
            hashIndeksi = (hashIndeksi + 1) % boyut; // Bir sonraki indeksi bulmak için ilerliyoruz
        }
        tablo[hashIndeksi] = anahtar; // Anahtarı uygun boş yere yerleştiriyoruz
    }

    // Kuadratik Probing yöntemiyle anahtar ekleyen metot
    public void EkleKuadratik(int anahtar)
    {
        int hashIndeksi = HashFonksiyonu(anahtar); // Anahtar için hash indeksi hesaplıyoruz
        int i = 0; // Çarpan değişkeni, başlangıçta sıfır

        // Eğer hesaplanan indeks doluysa, kuadratik artışla yeni indeks buluyoruz
        while (tablo[hashIndeksi] != -1)
        {
            hashIndeksi = (hashIndeksi + (i * i)) % boyut; // İlerleme miktarını kuadratik olarak artırıyoruz
            i++; // Bir sonraki deneme için çarpanı artırıyoruz
        }
        tablo[hashIndeksi] = anahtar; // Anahtarı uygun boş yere yerleştiriyoruz
    }

    // Hash tablosundaki elemanları ekrana yazdıran metot
    public void TabloyuYazdir()
    {
        Console.WriteLine("Hash Tablosu:");
        for (int i = 0; i < boyut; i++)
        {
            if (tablo[i] == -1)
                Console.WriteLine($"{i}: Boş"); // Eğer hücre boşsa "Boş" yazdırıyoruz
            else
                Console.WriteLine($"{i}: {tablo[i]}"); // Hücredeki anahtarı yazdırıyoruz
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random rastgele = new Random(); // Rastgele sayı üretici
        int boyut = 100; // Hash tablosunun boyutu
        HashTablosu lineerProbingTablosu = new HashTablosu(boyut); // Lineer probing tablosu
        HashTablosu kuadratikProbingTablosu = new HashTablosu(boyut); // Kuadratik probing tablosu

        // 100 tane rastgele anahtar üretiyoruz ve lineer probing tablosunu dolduruyoruz
        for (int i = 0; i < 100; i++)
        {
            int anahtar = rastgele.Next(0, 1000); // 0 ile 999 arasında rastgele bir anahtar oluşturuyoruz
            Console.WriteLine($"Anahtar: {anahtar} (Lineer Probing için ekleniyor)");
            lineerProbingTablosu.EkleLineer(anahtar); // Anahtarı lineer probing ile ekliyoruz
        }

        Console.WriteLine("\nLineer Probing ile oluşturulan hash tablosu:");
        lineerProbingTablosu.TabloyuYazdir(); // Lineer probing ile oluşturulan hash tablosunu yazdırıyoruz

        // İkinci tablo için rastgele anahtarlar tekrar üretiyoruz
        for (int i = 0; i < 100; i++)
        {
            int anahtar = rastgele.Next(0, 1000); // 0 ile 999 arasında yeni bir rastgele anahtar oluşturuyoruz
            Console.WriteLine($"Anahtar: {anahtar} (Kuadratik Probing için ekleniyor)");
            kuadratikProbingTablosu.EkleKuadratik(anahtar); // Anahtarı kuadratik probing ile ekliyoruz
        }

        Console.WriteLine("\nKuadratik Probing ile oluşturulan hash tablosu:");
        kuadratikProbingTablosu.TabloyuYazdir(); // Kuadratik probing ile oluşturulan hash tablosunu yazdırıyoruz

        Console.ReadLine(); // Programın sonlanmaması için kullanıcıdan giriş bekliyoruz
    }
}
