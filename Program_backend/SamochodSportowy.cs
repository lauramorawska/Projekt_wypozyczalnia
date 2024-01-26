using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projekt
{
    public class SamochodSportowy : Samochod
    {
        int konieMechaniczne;
        bool podwojnyTlumik;

        public SamochodSportowy()
        {
            
        }

        public SamochodSportowy(string marka, string model, string numerRejestracyjny, int rokProdukcji, decimal cenaZaDzienWypozyczenia,
            int konieMechaniczne, bool podwojnyTlumik, decimal kaucja, EnumStan stan)

            : base(marka, model, numerRejestracyjny, rokProdukcji, kaucja, stan)
        {
            this.KonieMechaniczne = konieMechaniczne;
            this.PodwojnyTlumik = podwojnyTlumik;
            this.CzyDostepny = true;
        }
        
        public int KonieMechaniczne { get => konieMechaniczne; set => konieMechaniczne = value; }
        public bool PodwojnyTlumik { get => podwojnyTlumik; set => podwojnyTlumik = value; }

        public override string ToString()
        {
            return $"Samochód Sportowy {base.ToString()} , Konie mechaniczne: {KonieMechaniczne} KM, Podwójny Tłumik - {(PodwojnyTlumik ? "Dostępny" : "Niedostępny")}";
        }
      
    }
}
