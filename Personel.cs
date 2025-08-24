using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo5
{
    public abstract class Personel
    {

        private string _isim;

        private string _pozisyon;
        protected Personel() { }

        protected Personel(string isim, string pozisyon)
        {

            İsim = isim;
            Pozisyon = pozisyon;



        }

        public abstract decimal SaatlikUcret { get; set; }
        public abstract decimal CalismaSaati { get; set; }

        public string Pozisyon
        {
            get { return _pozisyon; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _pozisyon = value;
                }
                else
                {
                    throw new Exception("poziayon boş geçilemez.");
                }

            }
        }


        public string İsim
        {
            get { return _isim; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length < 50)
                {
                    _isim = value;
                }
                else
                {
                    throw new Exception("isim boş geçilemez ve 50 karakterden fazla olamaz.");
                }


            }
        }

        public abstract Decimal MaasHesapla();

        public override string ToString()
        {
            return $"isim: {_isim}  pozisyon: {_pozisyon} ";
        }



    }
}
