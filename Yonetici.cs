using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo5
{
    public class Yonetici : Personel
    {
        public Yonetici()
        {

        }

        public decimal Bonus;

        public Yonetici(string isim, string pozisyon, decimal saatlikucret, decimal bonus) : base(isim, pozisyon)
        {
            SaatlikUcret = saatlikucret;
            Bonus = bonus;
        }
        private decimal _saatlikUcret;
        public override decimal SaatlikUcret
        {
            get { return _saatlikUcret; }
            set
            {
                if (value >= 500m)
                {
                    _saatlikUcret = value;
                }
                else
                {
                    throw new Exception("yönetici saatlik ücreti 500 den küşük olamaz.");
                }

            }
        }

        public override decimal CalismaSaati { get; set; }

        public override decimal MaasHesapla()
        {
            return _saatlikUcret * CalismaSaati + Bonus;
        }

    }
}
