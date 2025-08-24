using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSProjeDemo5
{
    public static class DosyaOkuyucu
    {
        public static List<Personel> Oku(string path)
        {
            var Veriler = JsonSerializer.Deserialize<List<GelenVeri>>(
                File.ReadAllText(path),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            ) ?? new();

            var Personeller = new List<Personel>();

            foreach (var item in Veriler)
            {
                if (string.Equals(item.title, "Yonetici", StringComparison.OrdinalIgnoreCase))
                {
                    var Yonetici = new Yonetici();
                    
                    Yonetici.İsim = item.name ?? "";
                    Yonetici.Pozisyon = "Yonetici";
                   
                    Personeller.Add(Yonetici);
                }
                else if (string.Equals(item.title, "Memur", StringComparison.OrdinalIgnoreCase))
                {
                    var Memur = new Memur();
                    Memur.İsim = item.name ?? "";
                    Memur.Pozisyon = "Memur";
                    
                    Personeller.Add(Memur);
                }

            }

            return Personeller;
        }


        private class GelenVeri
        {
            public string? title { get; set; }
            public string? name { get; set; }
            
        }
    }
}