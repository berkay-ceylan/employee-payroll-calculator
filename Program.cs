namespace CSProjeDemo5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool hata = false;
            string Klasor = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\jsonlar2"));
            Directory.CreateDirectory(Klasor);
            string GirdiDosyasi = Klasor + "\\Girdiler.Json";
            string Ciktidosyasi = Klasor + "\\bordro.json";

            if (!File.Exists(GirdiDosyasi))
            {
                Console.WriteLine("girdi dosyası bulunamadı: " + GirdiDosyasi);
                return;
            }


            List<Personel> personeller = DosyaOkuyucu.Oku(GirdiDosyasi);

            do
            {
                hata = false;
                try
                {
                    foreach (var item in personeller)
                    {
                        Console.WriteLine($"\n-- {item.İsim} ({item.Pozisyon}) --");

                        Console.Write("Çalışma saati: ");
                        if (!decimal.TryParse(Console.ReadLine(), out var Calismasaati)) Calismasaati = 0m;
                        item.CalismaSaati = Calismasaati;

                        

                        if (item is Yonetici y)
                        {
                            Console.Write("Saatlik ücret: ");
                            if (!decimal.TryParse(Console.ReadLine(), out var saatlikucret)) saatlikucret = 0m;
                            item.SaatlikUcret = saatlikucret;

                            Console.Write("Bonus: ");
                            if (!decimal.TryParse(Console.ReadLine(), out var bonus)) bonus = 0m;
                            y.Bonus = bonus;

                            
                        }
                        else if (item is Memur m)
                        {
                            Console.Write("Derece (1-4): ");
                            if (!int.TryParse(Console.ReadLine(), out var derece)) derece = 1;
                            m.Derece = derece;

                        }
                    }
                }
                catch (Exception ex)
                {
                    hata = true;
                    Console.WriteLine(ex.Message);
                    
                }
            } while (hata);


            Bordro.HesaplaYazVeKaydet(personeller, Ciktidosyasi);


        }
    }
}

