using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSProjeDemo5
{
    public static class Bordro
    {
        public static void HesaplaYazVeKaydet(List<Personel> Personeller, string CiktiDosyasi)
        {
            var cikti = new List<object>();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=== RAPOR ===");
            Console.ForegroundColor= ConsoleColor.DarkCyan;
            Console.WriteLine($"{"İsim",-16} {"Pozisyon",-10} {"Saat",6} {"Ücret",8} {"Ana Maaş",12} {"Mesai",12} {"Bonus",8} {"Toplam",12}\n");
            Console.ResetColor();

            foreach (var item in Personeller)
            {
                decimal ana, mesai = 0m, bonus = 0m;

                if (item is Yonetici y)
                {
                    ana = y.SaatlikUcret * y.CalismaSaati;
                    mesai = 0m;
                    bonus = y.Bonus;
                }
                else if (item is Memur)
                {
                    var normal = Math.Min(180m, item.CalismaSaati);
                    var ek = Math.Max(0m, item.CalismaSaati - 180m);
                    ana = normal * item.SaatlikUcret;
                    mesai = ek * item.SaatlikUcret * 1.5m;
                }
                else
                {
                    ana = item.SaatlikUcret * item.CalismaSaati;
                }

                var toplam = ana + mesai + bonus;

                Console.WriteLine($"{item.İsim,-16} {item.Pozisyon,-10} {item.CalismaSaati,6:0} {item.SaatlikUcret,8:0} {ana,12:0} {mesai,12:0} {bonus,8:0} {toplam,12:0}");


                cikti.Add(new
                {
                    Isim = item.İsim,
                    Pozisyon = item.Pozisyon,
                    CalismaSaati = item.CalismaSaati,
                    SaatlikUcret = item.SaatlikUcret,
                    AnaMaas = ana,
                    MesaiMaasi = mesai,
                    Bonus = bonus,
                    Toplam = toplam
                });
            }

            Console.WriteLine("\n150 saaten az çalışanlar: ");
            bool bulundu = false;

            foreach (var item in Personeller)
            {
                if (item.CalismaSaati < 150m)
                {
                    Console.WriteLine($"- {item.İsim} ({item.Pozisyon}) — {item.CalismaSaati} saat");
                    bulundu = true;
                }
            }

            if (!bulundu)
                Console.WriteLine("tüm personeller 150 saatin üzerinde çalışmıştır");

            Directory.CreateDirectory(Path.GetDirectoryName(CiktiDosyasi)!);
            var json = JsonSerializer.Serialize(cikti, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(CiktiDosyasi, json);
            Console.WriteLine("\nKaydedildi: " + Path.GetFullPath(CiktiDosyasi));
        }
    }
}
