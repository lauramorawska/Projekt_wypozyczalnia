using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projekt
{
    public enum EnumMiejsca { Siedmioosobowe, Dziewiecioosobowe}

    
    public class SamochodWieloosobowy : Samochod
    {
        EnumMiejsca ilosc;

        public SamochodWieloosobowy()
        {

        }

        public SamochodWieloosobowy(string marka, string model, string numerRejestracyjny, int rokProdukcji, decimal cenaZaDzienWypozyczenia, EnumMiejsca ilosc, decimal kaucja, EnumStan stan)
            : base(marka, model, numerRejestracyjny, rokProdukcji, kaucja, stan)
        {
            this.Ilosc = ilosc;
            this.CzyDostepny = true;
        }

        public EnumMiejsca Ilosc { get => ilosc; set => ilosc = value; }

        public override string ToString()
        {
            return $"Samochód wieloosobowy { base.ToString()}, {Ilosc}";
        }

    }
}
