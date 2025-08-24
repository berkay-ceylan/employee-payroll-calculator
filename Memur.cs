using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo5
{
    public class Memur : Personel
    {
        public Memur()
        {

        }
        public Memur(string isim, string pozisyon, decimal saatlikUcret, int derece) : base(isim, pozisyon)
        {
            Derece = derece;
            SaatlikUcret = saatlikUcret;
        }
        public int Derece
        {
            get => _derece;
            set
            {
                if (value < 1 || value > 4)
                    throw new ArgumentOutOfRangeException("Derece 1 ile 4 arasında olmalı.");
                _derece = value;
                SaatlikUcret = DereceyeGoreUcret(value);
            }
        }
        private int _derece;
        public override decimal SaatlikUcret { get; set; }
        public override decimal CalismaSaati { get; set; }

        public override decimal MaasHesapla()
        {
            decimal normalSaat = Math.Min(180m, CalismaSaati);
            decimal mesaiSaat = Math.Max(0m, CalismaSaati - 180m);

            decimal anaOdeme = normalSaat * SaatlikUcret;
            decimal mesaiOdeme = mesaiSaat * SaatlikUcret * 1.5m;

            return anaOdeme + mesaiOdeme;
        }
        public static decimal DereceyeGoreUcret(int derece) => derece switch
        {
            1 => 500m,
            2 => 550m,
            3 => 600m,
            4 => 650m,
            _ => 500m
        };
    }
}
